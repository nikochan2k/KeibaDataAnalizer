using System;
using System.Transactions;
using System.Diagnostics;
using System.Data;
using System.Data.Common;
using Soma.Core;
using NLog;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Model
{

	public class Transaction : IDisposable
	{
		/// <summary>
		/// Description of Configuration.
		/// </summary>
		private class Configuration : SQLiteConfig
		{
			private static readonly Logger LOGGER = LogManager.GetCurrentClassLogger();
			
			public static readonly Configuration INSTANCE = new Configuration();
			
			private static Action<PreparedStatement> logAction = p => {
				if (LOGGER.IsDebugEnabled) {
					LOGGER.Debug(p.Text + " " + p.Parameters.ToString());
				}
			};

			public override string ConnectionString {
				get {
					return "Data Source=Keiba.sqlite";
				}
			}
			
			public override Action<PreparedStatement> Logger {
				get {
					return logAction;
				}
			}
		}
		
		private static readonly ILocalDb localDb = new LocalDb(Configuration.INSTANCE);
		
		private static DbConnection connection;
		
		private static int recursiveCount = 0;
		
		private static TransactionScope transactionScope;
		
		public Transaction()
		{
			if (connection == null) {
				connection = localDb.CreateConnection();
			} else if (connection.State == ConnectionState.Broken
			        || connection.State == ConnectionState.Closed) {
				connection.Dispose();
				connection = localDb.CreateConnection();
			}
			localDb.Execute(connection, "PRAGMA synchronous = OFF");
			localDb.Execute(connection, "PRAGMA temp_store = MEMORY");
			localDb.Execute(connection, "PRAGMA journal_mode = MEMORY");
			if (recursiveCount == 0) {
				transactionScope = new TransactionScope();
			}
			recursiveCount++;
		}
		
		public ILocalDb DB {
			get {
				return localDb;
			}
		}
		
		public DbConnection Connection {
			get {
				return connection;
			}
		}
		
		public void Commit()
		{
			if (recursiveCount == 1) {
				transactionScope.Complete();
			}
		}
		
		public void Dispose()
		{
			if (recursiveCount > 0) {
				recursiveCount--;
			}
			if (recursiveCount == 0) {
				try {
					transactionScope.Dispose();
				}
				// disable once EmptyGeneralCatchClause
				catch {
				}
				transactionScope = null;
			}
		}
	}
	
}
