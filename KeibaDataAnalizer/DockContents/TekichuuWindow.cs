using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Soma.Core;
using WeifenLuo.WinFormsUI.Docking;
using Nikochan.Keiba.KeibaDataAnalyzer.Model;
using Nikochan.Keiba.KeibaDataAnalyzer.UserControls;
using Nikochan.Keiba.KeibaDataAnalyzer.Util;

namespace Nikochan.Keiba.KeibaDataAnalyzer.DockContents
{
    public partial class TekichuuWindow : DockContent
    {
        private IList<ToushiKekka> tekichuuResultList = new List<ToushiKekka>();

        private ToushiKekka tanshou = new ToushiKekka() { Houshiki = "単勝" };

        private ToushiKekka fukushou = new ToushiKekka() { Houshiki = "複勝" };

        private ToushiKekka wakuren = new ToushiKekka() { Houshiki = "枠連" };

        private ToushiKekka umaren = new ToushiKekka() { Houshiki = "馬連" };

        private ToushiKekka umatan = new ToushiKekka() { Houshiki = "馬単" };

        private ToushiKekka wide = new ToushiKekka() { Houshiki = "ワイド" };

        private ToushiKekka sanrenpuku = new ToushiKekka() { Houshiki = "3連複" };

        private ToushiKekka sanrentan = new ToushiKekka() { Houshiki = "3連単" };

        private int count;

        private int max;

        public TekichuuWindow()
        {
            InitializeComponent();
            tekichuuResultList.Add(tanshou);
            tekichuuResultList.Add(fukushou);
            tekichuuResultList.Add(wakuren);
            tekichuuResultList.Add(umaren);
            tekichuuResultList.Add(umatan);
            tekichuuResultList.Add(wide);
            tekichuuResultList.Add(sanrenpuku);
            tekichuuResultList.Add(sanrentan);
            SouToushiKekka souToushiKekka = new SouToushiKekka(
                tanshou, fukushou, wakuren, umaren, umatan,
                wide, sanrenpuku, sanrentan) { Houshiki = "総計" };
            tekichuuResultList.Add(souToushiKekka);
        }

        private void TekichuuWindow_Load(object sender, EventArgs e)
        {
            BuildComboBox(raceSelectionComboBox, "TekichuuRace");
            BuildComboBox(shussoubaSelectionComboBox, "TekichuuShussouba");
            BuildDataGridView();
        }

        private void BuildComboBox(ToolStripComboBox cb, string domain)
        {
        	var list = ModelUtil.GetUserSQLList(domain);
            cb.ComboBox.DisplayMember = "Name";
            cb.ComboBox.DataSource = list;
        }

        private void BuildDataGridView()
        {
            dataGridView.AutoGenerateColumns = false;
            DataGridViewColumn col;
            col = new DataGridViewTextBoxColumn();
            col.DataPropertyName = "Houshiki";
            col.HeaderText = "方式";
            col.Frozen = true;
            dataGridView.Columns.Add(col);
            col = new DataGridViewTextBoxColumn();
            col.DataPropertyName = "RaceSuu";
            col.HeaderText = "レース数";
            dataGridView.Columns.Add(col);
            col = new DataGridViewTextBoxColumn();
            col.DataPropertyName = "TekichuuSuu";
            col.HeaderText = "的中数";
            dataGridView.Columns.Add(col);
            col = new DataGridViewTextBoxColumn();
            col.DataPropertyName = "TekichuuRitsu";
            col.HeaderText = "的中率";
            dataGridView.Columns.Add(col);
            col = new DataGridViewTextBoxColumn();
            col.DataPropertyName = "ToushiKin";
            col.HeaderText = "投資金";
            dataGridView.Columns.Add(col);
            col = new DataGridViewTextBoxColumn();
            col.DataPropertyName = "HaitouKin";
            col.HeaderText = "配当金";
            dataGridView.Columns.Add(col);
            col = new DataGridViewTextBoxColumn();
            col.DataPropertyName = "KaishuuRitsu";
            col.HeaderText = "回収率";
            dataGridView.Columns.Add(col);
            dataGridView.DataSource = tekichuuResultList;
        }

        private void editRaceSQLButton_Click(object sender, EventArgs e)
        {
            var editSQLLWindow = new EditSQLWindow();
            editSQLLWindow.ShowDialog(raceSelectionComboBox.ComboBox, "TekichuuRace");
        }

        private void editHorseSQLButton_Click(object sender, EventArgs e)
        {
            var editSQLLWindow = new EditSQLWindow();
            editSQLLWindow.ShowDialog(shussoubaSelectionComboBox.ComboBox, "TekichuuShussouba");
        }

        class SelectionSQL
        {
            internal string Race { get; set; }

            internal string Shussouba { get; set; }
        }

        private void executeButton_Click(object sender, EventArgs e)
        {
            SelectionSQL selectionSQL = new SelectionSQL();
            var raceUserSQL = (UserSQL)raceSelectionComboBox.ComboBox.SelectedItem;
            selectionSQL.Race = raceUserSQL.SQL;
            var kyousoubaUserSQL = (UserSQL)shussoubaSelectionComboBox.ComboBox.SelectedItem;
            selectionSQL.Shussouba = kyousoubaUserSQL.SQL;


            toolStrip.Enabled = false;
            flowLayoutPanel.Enabled = false;
            backgroundWorker.RunWorkerAsync(selectionSQL);
        }

        private void Calc(IList<dynamic> list, RaceHaitou haitou)
        {
        	if(list.Count == 0){
        		return;
        	}
        	IDynamicObject dynamicObject = (IDynamicObject)list[0];
        	
            if (dynamicObject.ContainsKey("Umaban"))
            {
                CalcTanshou(list, haitou);
                CalcFukushou(list, haitou);
                CalcUmaren(list, haitou);
                CalcUmatan(list, haitou);
                CalcWideUmaren(list, haitou);
                CalcSanrenpuku(list, haitou);
                CalcSanrentan(list, haitou);
            }
            if (dynamicObject.ContainsKey("Wakuban"))
            {
                CalcWakuren(list, haitou);
            }
        }

        private void CalcTanshou(IList<dynamic> list, RaceHaitou haitou)
        {
            if (!tanshouUserControl.Checked)
            {
                return;
            }
            var joui = tanshouUserControl.Tousuu;
            tanshou.RaceSuu = (tanshou.RaceSuu ?? 0) + 1;
            for (var ri = 0; ri < joui && ri < list.Count; ri++)
            {
                IDynamicObject row = (IDynamicObject)list[ri];
                var umaban = (int)row[tanshouUserControl.ColumnName];
                tanshou.ToushiKin = (tanshou.ToushiKin ?? 0) + 100;
                var tanUmabanArray = new int?[]{ haitou.TanUmaban1,
                    haitou.TanUmaban2, haitou.TanUmaban3};
                var tanshouHaitoukinArray = new int?[] { haitou.TanshouHaitoukin1,
                    haitou.TanshouHaitoukin2, haitou.TanshouHaitoukin3 };
                for (int i = 0; i < tanUmabanArray.Length; i++)
                {
                    var tanUmaban = tanUmabanArray[i];
                    if (tanUmaban == null)
                    {
                        break;
                    }
                    if (tanUmaban.Value == umaban)
                    {
                        tanshou.TekichuuSuu = (tanshou.TekichuuSuu ?? 0) + 1;
                        tanshou.HaitouKin = (tanshou.HaitouKin ?? 0) + tanshouHaitoukinArray[i].Value;
                    }
                }
            }
        }

        private void CalcFukushou(IList<dynamic> list, RaceHaitou haitou)
        {
            if (!fukushouUserControl.Checked)
            {
                return;
            }
            var joui = fukushouUserControl.Tousuu;
            fukushou.RaceSuu = (fukushou.RaceSuu ?? 0) + 1;
            for (var ri = 0; ri < joui && ri < list.Count; ri++)
            {
                IDynamicObject row = (IDynamicObject)list[ri];
                var umaban = (int)row[fukushouUserControl.ColumnName];
                fukushou.ToushiKin = (fukushou.ToushiKin ?? 0) + 100;
                var fukuUmabanArray = new int?[]{ haitou.FukuUmaban1,
                    haitou.FukuUmaban2, haitou.FukuUmaban3,
                    haitou.FukuUmaban4, haitou.FukuUmaban5};
                var fukushouHaitoukinArray = new int?[] { haitou.FukushouHaitoukin1,
                    haitou.FukushouHaitoukin2, haitou.FukushouHaitoukin3,
                    haitou.FukushouHaitoukin4, haitou.FukushouHaitoukin5};
                for (int i = 0; i < fukuUmabanArray.Length; i++)
                {
                    var fukuUmaban = fukuUmabanArray[i];
                    if (fukuUmaban == null)
                    {
                        break;
                    }
                    if (fukuUmaban.Value == umaban)
                    {
                        fukushou.TekichuuSuu = (fukushou.TekichuuSuu ?? 0) + 1;
                        fukushou.HaitouKin = (fukushou.HaitouKin ?? 0) + fukushouHaitoukinArray[i].Value;
                    }
                }
            }
        }

        private void CalcWakuren(IList<dynamic> list, RaceHaitou haitou)
        {
            if (!wakurenUserControl.Checked)
            {
                return;
            }
            var renList = GetArrangementList(wakurenUserControl, list);
            wakuren.RaceSuu = (wakuren.RaceSuu ?? 0) + 1;
            foreach (var ren in renList)
            {
                wakuren.ToushiKin = (wakuren.ToushiKin ?? 0) + 100;
                var wakuren1Array = new int?[] { haitou.Wakuren11, haitou.Wakuren21, haitou.Wakuren31 };
                var wakuren2Array = new int?[] { haitou.Wakuren12, haitou.Wakuren22, haitou.Wakuren32 };
                var wakurenHaitoukinArray = new int?[] { haitou.WakurenHaitoukin1,
                    haitou.WakurenHaitoukin2, haitou.WakurenHaitoukin3 };
                for (int i = 0; i < wakuren1Array.Length; i++)
                {
                    int? wakuren1 = wakuren1Array[i];
                    if (wakuren1 == null)
                    {
                        break;
                    }
                    int? wakuren2 = wakuren2Array[i];
                    if (ren[0] == wakuren1.Value && ren[1] == wakuren2.Value)
                    {
                        wakuren.TekichuuSuu = (wakuren.TekichuuSuu ?? 0) + 1;
                        wakuren.HaitouKin = (wakuren.HaitouKin ?? 0) + wakurenHaitoukinArray[i].Value;
                    }
                }
            }
        }

        private void CalcUmaren(IList<dynamic> list, RaceHaitou haitou)
        {
            if (!umarenUserControl.Checked)
            {
                return;
            }
            if (haitou.Umaren11 == null)
            {
                return;
            }
            var renList = GetArrangementList(umarenUserControl, list);
            umaren.RaceSuu = (umaren.RaceSuu ?? 0) + 1;
            foreach (var ren in renList)
            {
                umaren.ToushiKin = (umaren.ToushiKin ?? 0) + 100;
                var umaren1Array = new int?[] { haitou.Umaren11, haitou.Umaren21, haitou.Umaren31 };
                var umaren2Array = new int?[] { haitou.Umaren12, haitou.Umaren22, haitou.Umaren32 };
                var umarenHaitoukinArray = new int?[] { haitou.UmarenHaitoukin1,
                    haitou.UmarenHaitoukin2, haitou.UmarenHaitoukin3 };
                for (int i = 0; i < umaren1Array.Length; i++)
                {
                    int? umaren1 = umaren1Array[i];
                    if (umaren1 == null)
                    {
                        break;
                    }
                    int? umaren2 = umaren2Array[i];
                    if (ren[0] == umaren1.Value && ren[1] == umaren2.Value)
                    {
                        umaren.TekichuuSuu = (umaren.TekichuuSuu ?? 0) + 1;
                        umaren.HaitouKin = (umaren.HaitouKin ?? 0) + umarenHaitoukinArray[i].Value;
                    }
                }
            }
        }

        private void CalcUmatan(IList<dynamic> list, RaceHaitou haitou)
        {
            if (!umatanUserControl.Checked)
            {
                return;
            }
            if (haitou.Umatan11 == null)
            {
                return;
            }
            var renList = GetArrangementList(umatanUserControl, list);
            umatan.RaceSuu = (umatan.RaceSuu ?? 0) + 1;
            foreach (var ren in renList)
            {
                umatan.ToushiKin = (umatan.ToushiKin ?? 0) + 100;
                var umatan1Array = new int?[] { haitou.Umatan11, haitou.Umatan21, haitou.Umatan31 };
                var umatan2Array = new int?[] { haitou.Umatan12, haitou.Umatan22, haitou.Umatan32 };
                var umatanHaitoukinArray = new int?[] { haitou.UmatanHaitoukin1,
                    haitou.UmatanHaitoukin2, haitou.UmatanHaitoukin3 };
                for (int i = 0; i < umatan1Array.Length; i++)
                {
                    int? umatan1 = umatan1Array[i];
                    if (umatan1 == null)
                    {
                        break;
                    }
                    int? umatan2 = umatan2Array[i];
                    if (ren[0] == umatan1.Value && ren[1] == umatan2.Value)
                    {
                        umatan.TekichuuSuu = (umatan.TekichuuSuu ?? 0) + 1;
                        umatan.HaitouKin = (umatan.HaitouKin ?? 0) + umatanHaitoukinArray[i].Value;
                    }
                }
            }
        }

        private void CalcWideUmaren(IList<dynamic> list, RaceHaitou haitou)
        {
            if (!wideUserControl.Checked)
            {
                return;
            }
            if (haitou.WideUmaren11 == null)
            {
                return;
            }
            var renList = GetArrangementList(wideUserControl, list);
            wide.RaceSuu = (wide.RaceSuu ?? 0) + 1;
            foreach (var ren in renList)
            {
                wide.ToushiKin = (wide.ToushiKin ?? 0) + 100;
                var wideUmaren1Array = new int?[] { haitou.WideUmaren11, haitou.WideUmaren21,
                    haitou.WideUmaren31, haitou.WideUmaren41, haitou.WideUmaren51,
                    haitou.WideUmaren61, haitou.WideUmaren71 };
                var wideUmaren2Array = new int?[] { haitou.WideUmaren12, haitou.WideUmaren22,
                    haitou.WideUmaren32, haitou.WideUmaren42, haitou.WideUmaren52,
                    haitou.WideUmaren62, haitou.WideUmaren72 };
                var wideUmarenHaitoukinArray = new int?[] { haitou.WideUmarenHaitoukin1,
                    haitou.WideUmarenHaitoukin2, haitou.WideUmarenHaitoukin3,
                    haitou.WideUmarenHaitoukin4, haitou.WideUmarenHaitoukin5,
                    haitou.WideUmarenHaitoukin6, haitou.WideUmarenHaitoukin7 };
                for (int i = 0; i < wideUmaren1Array.Length; i++)
                {
                    int? wideUmaren1 = wideUmaren1Array[i];
                    if (wideUmaren1 == null)
                    {
                        break;
                    }
                    int? wideUmaren2 = wideUmaren2Array[i];
                    if (ren[0] == wideUmaren1.Value && ren[1] == wideUmaren2.Value)
                    {
                        wide.TekichuuSuu = (wide.TekichuuSuu ?? 0) + 1;
                        wide.HaitouKin = (wide.HaitouKin ?? 0) + wideUmarenHaitoukinArray[i].Value;
                    }
                }
            }
        }

        private void CalcSanrenpuku(IList<dynamic> list, RaceHaitou haitou)
        {
            if (!sanrenpukuUserControl.Checked)
            {
                return;
            }
            if (haitou.Sanrenpuku11 == null)
            {
                return;
            }
            var renList = GetArrangementList(sanrenpukuUserControl, list);
            sanrenpuku.RaceSuu = (sanrenpuku.RaceSuu ?? 0) + 1;
            foreach (var ren in renList)
            {
                sanrenpuku.ToushiKin = (sanrenpuku.ToushiKin ?? 0) + 100;
                var sanrenpuku1Array = new int?[] { haitou.Sanrenpuku11, haitou.Sanrenpuku21, haitou.Sanrenpuku31 };
                var sanrenpuku2Array = new int?[] { haitou.Sanrenpuku12, haitou.Sanrenpuku22, haitou.Sanrenpuku32 };
                var sanrenpuku3Array = new int?[] { haitou.Sanrenpuku13, haitou.Sanrenpuku23, haitou.Sanrenpuku33 };
                var sanrenpukuHaitoukinArray = new int?[] { haitou.SanrenpukuHaitoukin1,
                    haitou.SanrenpukuHaitoukin2, haitou.SanrenpukuHaitoukin3 };
                for (int i = 0; i < sanrenpuku1Array.Length; i++)
                {
                    int? sanrenpuku1 = sanrenpuku1Array[i];
                    if (sanrenpuku1 == null)
                    {
                        break;
                    }
                    int? sanrenpuku2 = sanrenpuku2Array[i];
                    int? sanrenpuku3 = sanrenpuku3Array[i];
                    if (ren[0] == sanrenpuku1.Value && ren[1] == sanrenpuku2.Value && ren[2] == sanrenpuku3.Value)
                    {
                        sanrenpuku.TekichuuSuu = (sanrenpuku.TekichuuSuu ?? 0) + 1;
                        sanrenpuku.HaitouKin = (sanrenpuku.HaitouKin ?? 0) + sanrenpukuHaitoukinArray[i].Value;
                    }
                }
            }
        }

        private void CalcSanrentan(IList<dynamic> list, RaceHaitou haitou)
        {
            if (!sanrentanUserControl.Checked)
            {
                return;
            }
            if (haitou.Sanrentan11 == null)
            {
                return;
            }
            var renList = GetArrangementList(sanrentanUserControl, list);
            sanrentan.RaceSuu = (sanrentan.RaceSuu ?? 0) + 1;
            foreach (var ren in renList)
            {
                sanrentan.ToushiKin = (sanrentan.ToushiKin ?? 0) + 100;
                var sanrentan1Array = new int?[] { haitou.Sanrentan11, haitou.Sanrentan21, haitou.Sanrentan31 };
                var sanrentan2Array = new int?[] { haitou.Sanrentan12, haitou.Sanrentan22, haitou.Sanrentan32 };
                var sanrentan3Array = new int?[] { haitou.Sanrentan13, haitou.Sanrentan23, haitou.Sanrentan33 };
                var sanrentanHaitoukinArray = new int?[] { haitou.SanrentanHaitoukin1,
                    haitou.SanrentanHaitoukin2, haitou.SanrentanHaitoukin3 };
                for (int i = 0; i < sanrentan1Array.Length; i++)
                {
                    int? sanrentan1 = sanrentan1Array[i];
                    if (sanrentan1 == null)
                    {
                        break;
                    }
                    int? sanrentan2 = sanrentan2Array[i];
                    int? sanrentan3 = sanrentan3Array[i];
                    if (ren[0] == sanrentan1.Value && ren[1] == sanrentan2.Value && ren[2] == sanrentan3.Value)
                    {
                        sanrentan.TekichuuSuu = (sanrentan.TekichuuSuu ?? 0) + 1;
                        sanrentan.HaitouKin = (sanrentan.HaitouKin ?? 0) + sanrentanHaitoukinArray[i].Value;
                    }
                }
            }
        }

        private IList<Arrangement> GetArrangementList(RenTanUserControl userControl, IList<dynamic> list)
        {
            var arrangementList = new List<Arrangement>();

            for (var jikuIndex = 0;
                jikuIndex < userControl.JikuTousuu && jikuIndex < list.Count;
                jikuIndex++)
            {
            	var jikuRow = (IDynamicObject)list[jikuIndex];
                var jiku = (int)jikuRow[userControl.ColumnName];

                var aiteList = new List<int>(userControl.JouiTousuu - 1);
                for (var jouiIndex = 0;
                    jouiIndex < userControl.JouiTousuu && jouiIndex < list.Count;
                    jouiIndex++)
                {
                    if (jikuIndex == jouiIndex)
                    {
                        continue;
                    }
                    var aiteRow = (IDynamicObject)list[jouiIndex];
                    var aite = (int)aiteRow[userControl.ColumnName];
                    aiteList.Add(aite);
                }
                var aiteArray = aiteList.ToArray();

                foreach (var items in Permutation.GetElements<int>(aiteArray, userControl.Length - 1))
                {
                    var array = new int[userControl.Length];
                    array[0] = jiku;
                    items.CopyTo(array, 1);

                    Arrangement arrangement;
                    if (userControl.IsRen)
                    {
                        arrangement = new Ren(array);
                    }
                    else
                    {
                        arrangement = new Tan(array);
                    }
                    if (!arrangementList.Contains(arrangement))
                    {
                        arrangementList.Add(arrangement);
                    }
                }
            }

            return arrangementList;
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var selectionSQL = (SelectionSQL)e.Argument;

			IList<dynamic> raceList;            
            using(var transaction = new Transaction()){
            	var db = transaction.DB;
            	var con = transaction.Connection;
            	raceList = db.Query<dynamic>(con, selectionSQL.Race);
            }

            this.max = raceList.Count;
            Reset();
            foreach (IDictionary<string, object> row in raceList)
            {
                var id = (long)row["Id"];
                IList<dynamic> shussoubaList;
                RaceHaitou haitou;
	            using(var transaction = new Transaction()){
	            	var db = transaction.DB;
	            	var con = transaction.Connection;
	            	shussoubaList = db.Query<dynamic>(con, selectionSQL.Shussouba, id);
	            	haitou = db.Find<RaceHaitou>(con, id);
                }
                
                Calc(shussoubaList, haitou);
                this.count++;
                backgroundWorker.ReportProgress(count * 100 / max);
            }
        }

        private void Reset()
        {
            this.count = 0;
            tanshou.Reset();
            fukushou.Reset();
            wakuren.Reset();
            umaren.Reset();
            umatan.Reset();
            wide.Reset();
            sanrenpuku.Reset();
            sanrentan.Reset();
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = tekichuuResultList;
            this.toolStripProgressBar.Value = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.flowLayoutPanel.Enabled = true;
            this.toolStrip.Enabled = true;
        }
    }

    public class ToushiKekka
    {
        public virtual string Houshiki { get; set; }

        public virtual int? RaceSuu { get; set; }

        public virtual int? TekichuuSuu { get; set; }

        public virtual string TekichuuRitsu
        {
            get
            {
                if (RaceSuu == null || TekichuuSuu == null || RaceSuu.Value == 0)
                {
                    return null;
                }
                double rate = (double)TekichuuSuu / (double)RaceSuu * 100.0;
                return rate.ToString("##.#");
            }
        }

        public virtual int? ToushiKin { get; set; }

        public virtual int? HaitouKin { get; set; }

        public virtual string KaishuuRitsu
        {
            get
            {
                if (ToushiKin == null || HaitouKin == null || ToushiKin.Value == 0)
                {
                    return null;
                }
                double rate = (double)HaitouKin / (double)ToushiKin * 100.0;
                return rate.ToString("##.#");
            }
        }

        public virtual void Reset()
        {
            RaceSuu = null;
            TekichuuSuu = null;
            ToushiKin = null;
            HaitouKin = null;
        }

    }

    public class SouToushiKekka : ToushiKekka
    {
        private ToushiKekka tanshou;

        private ToushiKekka fukushou;

        private ToushiKekka wakuren;

        private ToushiKekka umaren;

        private ToushiKekka umatan;

        private ToushiKekka wide;

        private ToushiKekka sanrenpuku;

        private ToushiKekka sanrentan;
        
        public SouToushiKekka(
            ToushiKekka tanshou,
            ToushiKekka fukushou,
            ToushiKekka wakuren,
            ToushiKekka umaren,
            ToushiKekka umatan,
            ToushiKekka wide,
            ToushiKekka sanrenpuku,
            ToushiKekka sanrentan
            )
        {
            this.tanshou = tanshou;
            this.fukushou = fukushou;
            this.wakuren = wakuren;
            this.umaren = umaren;
            this.umatan = umatan;
            this.wide = wide;
            this.sanrenpuku = sanrenpuku;
            this.sanrentan = sanrentan;
        }

        public override int? RaceSuu
        {
            get
            {
                return null;
            }
            set
            {
                throw new InvalidOperationException();
            }
        }

        public override int? TekichuuSuu
        {
            get
            {
                return null;
            }
            set
            {
                throw new InvalidOperationException();
            }
        }

        public override int? ToushiKin
        {
            get
            {
                if (tanshou.ToushiKin == null &&
                    fukushou.ToushiKin == null &&
                    wakuren.ToushiKin == null &&
                    umaren.ToushiKin == null &&
                    umatan.ToushiKin == null &&
                    wide.ToushiKin == null &&
                    sanrenpuku.ToushiKin == null &&
                    sanrentan.ToushiKin == null)
                {
                    return null;
                }
                return
                    (tanshou.ToushiKin ?? 0) +
                    (fukushou.ToushiKin ?? 0) +
                    (wakuren.ToushiKin ?? 0) +
                    (umaren.ToushiKin ?? 0) +
                    (umatan.ToushiKin ?? 0) +
                    (wide.ToushiKin ?? 0) +
                    (sanrenpuku.ToushiKin ?? 0) +
                    (sanrentan.ToushiKin ?? 0);
            }
            set
            {
                throw new InvalidOperationException();
            }
        }

        public override int? HaitouKin
        {
            get
            {
                if (tanshou.HaitouKin == null &&
                    fukushou.HaitouKin == null &&
                    wakuren.HaitouKin == null &&
                    umaren.HaitouKin == null &&
                    umatan.HaitouKin == null &&
                    wide.HaitouKin == null &&
                    sanrenpuku.HaitouKin == null &&
                    sanrentan.HaitouKin == null)
                {
                    return null;
                }
                return 
                    (tanshou.HaitouKin ?? 0) +
                    (fukushou.HaitouKin ?? 0) +
                    (wakuren.HaitouKin ?? 0) +
                    (umaren.HaitouKin ?? 0) +
                    (umatan.HaitouKin ?? 0) +
                    (wide.HaitouKin ?? 0) +
                    (sanrenpuku.HaitouKin ?? 0) +
                    (sanrentan.HaitouKin ?? 0);
            }
            set
            {
                throw new InvalidOperationException();
            }
        }
    }

    public class Arrangement
    {
        private int[] array;

        protected Arrangement(int[] array, bool conbination)
        {
            if (conbination)
            {
                Array.Sort<int>(array);
            }
            this.array = array;
        }

        public int this[int index]
        {
            get
            {
                return array[index];
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!(obj is Arrangement))
            {
                return false;
            }
            Arrangement arrangement = (Arrangement)obj;
            if (this.array.Length != arrangement.array.Length)
            {
                return false;
            }
            for (int i = 0; i < this.array.Length; i++)
            {
                if (this.array[i] != arrangement.array[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                foreach (var item in array)
                {
                    hashCode += item.GetHashCode();
                }
                return hashCode;
            }
        }
    }

    public class Tan : Arrangement
    {
        public Tan(int[] array)
            : base(array, false)
        {
        }
    }

    public class Ren : Arrangement
    {
        public Ren(int[] array)
            : base(array, true)
        {
        }
    }

}
