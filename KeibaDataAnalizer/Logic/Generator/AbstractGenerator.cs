using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Soma.Core;

using Nikochan.Keiba.KeibaDataAnalyzer.Model;

namespace Nikochan.Keiba.KeibaDataAnalyzer.Logic.Generator
{
	/// <summary>
	/// Description of AbstractGenerator.
	/// </summary>
	public abstract class AbstractGenerator : IGenerator
	{
		public class Updater{
			private Component component;
			
			public Updater(Component control){
				this.component = control;
			}
			
			public string Text{
				set{
					if(component is Control){
						var control = component as Control;
						control.Text = value;
					} else if (component is ToolStripItem) {
						var toolStripItem = component as ToolStripItem;
						toolStripItem.Text = value;
					}
					Application.DoEvents();
				}
			}
		}

		public abstract string Name {get;}
		
		public void Generate(Component component){
			var updater = new Updater(component);
			Generate(updater);
		}
		
		protected abstract void Generate(Updater updater);
	}
}
