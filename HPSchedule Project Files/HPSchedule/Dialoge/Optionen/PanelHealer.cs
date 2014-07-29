using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HPSchedule.Datenobjekte;

namespace HPSchedule.Dialoge.Optionen
{
    public partial class PanelHealer : OptionControl
    {
        public PanelHealer()
        {
            InitializeComponent();
            //colorDialog1.AllowFullOpen = false;
        }

        public override void LoadData()
        {
            foreach (Healer h in DoDatabaseMagic.GetHealerList())
            {
                listBox1.Items.Add(h);
            }            
        }
        public override void SaveData()
        {
            foreach (Healer h in listBox1.Items)
                DoDatabaseMagic.SaveHealer(h);
        }
        
        private void neuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Healer newHealer = new Healer();

            newHealer.Name = "Neuer Behandler";
            newHealer.Color = Color.Red;
            newHealer.DatabaseAction = dbAction.created;

            listBox1.Items.Add(newHealer);
        }


        private void farbeFestlegenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Healer h = listBox1.SelectedItem as Healer;
            if (h == null || h.DatabaseAction == dbAction.delete)
                return;

            colorDialog1.Color = h.Color;
            if (colorDialog1.ShowDialog()== DialogResult.OK)
            {
                h.Color = colorDialog1.Color;
                if( h.DatabaseAction != dbAction.created )
                    h.DatabaseAction = dbAction.modified;
            }
        }

        private void namenBearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Healer h = listBox1.SelectedItem as Healer;
            if (h == null || h.DatabaseAction == dbAction.delete)
                return;

            AskStringForm dlg = new AskStringForm();
            dlg.Title = "Behandler";
            dlg.Label = "Geben Sie bitte einen Namen an.";
            dlg.Result = h.Name;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                h.Name = dlg.Result;
                if( h.DatabaseAction != dbAction.created )
                    h.DatabaseAction = dbAction.modified;

                UpdateListBox();
            }
        }

        private void UpdateListBox()
        {
            // Weil es keine Update-Funktion bei veränderung gibt hier also ein Workaround
            List<Healer> liste = new List<Healer>();

            foreach (Healer node in listBox1.Items)
                liste.Add(node);

            listBox1.Items.Clear();

            foreach (Healer node in liste)
                listBox1.Items.Add(node);

        }

        private void entfernenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Healer h = listBox1.SelectedItem as Healer;
            if (h == null)
                return;

            if (h.DatabaseAction!= dbAction.delete)
            {
                h.Name = "[wird gelöscht] " + h.Name;
                h.DatabaseAction = dbAction.delete;

                UpdateListBox();
            }
        }
    }
}
