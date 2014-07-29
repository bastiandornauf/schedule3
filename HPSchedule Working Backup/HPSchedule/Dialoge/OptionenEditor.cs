using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HPSchedule.Dialoge.Optionen;

namespace HPSchedule.Dialoge
{
    public partial class OptionenEditor : Form
    {
        public OptionenEditor(OptionEntry firstChoice)
        {
            InitializeComponent();
            InitializeTreeView();

            groupBox1.Text = TVItems.Label(OptionEntry.Wurzel);

            if( treeView.Nodes.Count > 0 )
                foreach (TreeNode node in treeView.Nodes[0].Nodes)
                {
                    if (node.Text == TVItems.Label(firstChoice))
                    {
                        treeView.SelectedNode = node;
                        break;
                    }
                }
        }

        public OptionenEditor() : this(OptionEntry.Wurzel)
        {}

        private void InitializeTreeView()
        {
            TreeNode root, node, subnode;
            
            treeView.ImageList = imageList1;
            treeView.ShowRootLines = false;

            //----- Wurzel -----
            root = treeView.Nodes.Add(TVItems.Label(OptionEntry.Wurzel));
            root.ImageIndex = TVItems.ImageIndex(OptionEntry.Wurzel);
            root.SelectedImageIndex = TVItems.ImageIndex(OptionEntry.Wurzel);


            //----- Praxis -----
            node = root.Nodes.Add(TVItems.Label(OptionEntry.Praxis));
            node.ImageIndex = TVItems.ImageIndex(OptionEntry.Praxis);
            node.SelectedImageIndex = TVItems.ImageIndex(OptionEntry.Praxis);

            subnode = node.Nodes.Add("Behandler");
            subnode.ImageIndex = TVItems.ImageIndex(OptionEntry.Unterpunkt);
            subnode.SelectedImageIndex = TVItems.ImageIndex(OptionEntry.Unterpunkt);

            subnode = node.Nodes.Add("Räume");
            subnode.ImageIndex = TVItems.ImageIndex(OptionEntry.Unterpunkt);
            subnode.SelectedImageIndex = TVItems.ImageIndex(OptionEntry.Unterpunkt);
            
            //----- Datenbank -----
            node = root.Nodes.Add(TVItems.Label(OptionEntry.Datenbank));
            node.ImageIndex = TVItems.ImageIndex(OptionEntry.Datenbank);
            node.SelectedImageIndex = TVItems.ImageIndex(OptionEntry.Datenbank);

            subnode = node.Nodes.Add("lokaler MySQL-Server");
            subnode.ImageIndex = TVItems.ImageIndex(OptionEntry.Unterpunkt);
            subnode.SelectedImageIndex = TVItems.ImageIndex(OptionEntry.Unterpunkt);

            subnode = node.Nodes.Add("entfernter MySQL-Server");
            subnode.ImageIndex = TVItems.ImageIndex(OptionEntry.Unterpunkt);
            subnode.SelectedImageIndex = TVItems.ImageIndex(OptionEntry.Unterpunkt);

            //----- Anzeige -----
            node = root.Nodes.Add(TVItems.Label(OptionEntry.Anzeige));
            node.ImageIndex = TVItems.ImageIndex(OptionEntry.Anzeige);
            node.SelectedImageIndex = TVItems.ImageIndex(OptionEntry.Anzeige);

            subnode = node.Nodes.Add("Kalendar");
            subnode.ImageIndex = TVItems.ImageIndex(OptionEntry.Unterpunkt);
            subnode.SelectedImageIndex = TVItems.ImageIndex(OptionEntry.Unterpunkt);


            treeView.ExpandAll();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            // Wenn ein Control geladen war, sichere dessen Daten vor dem Wechsel
            if (panel1.Controls.Count != 0)
            {
                OptionControl optionCtrl = panel1.Controls[0] as OptionControl;
                if (optionCtrl != null)
                    optionCtrl.SaveData();
            }            
            
            Close();
        }

        private struct TVItems
        {
            public static string Label(OptionEntry e)
            {
                switch( e ) {
                    case OptionEntry.Wurzel: 
                        return "Optionen";
                    case OptionEntry.Anzeige:
                        return "Anzeige";
                    case OptionEntry.Praxis:
                        return "Praxis";
                    case OptionEntry.Datenbank:
                        return "Datenbank";
                    case OptionEntry.Unterpunkt:
                        return "";
                }
                return "";
            }

            public static int ImageIndex(OptionEntry e)
            {
                switch (e)
                {
                    case OptionEntry.Wurzel:
                        return 0;
                    case OptionEntry.Anzeige:
                        return 3;
                    case OptionEntry.Praxis:
                        return 2;
                    case OptionEntry.Datenbank:
                        return 4;
                    case OptionEntry.Unterpunkt:
                        return 1;
                }
                return 0;
            }
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            OptionControl optionCtrl;
            // Wenn keine gültige Auswahl ...
            TreeNode node = treeView.SelectedNode;
            if (node == null || node == treeView.TopNode)
            {
                groupBox1.Text = TVItems.Label(OptionEntry.Wurzel);
                return;
            }

            groupBox1.Text = node.Text;

            // Wenn ein Control geladen war, sichere dessen Daten vor dem Wechsel
            if (panel1.Controls.Count != 0)
            {
                optionCtrl = panel1.Controls[0] as OptionControl;
                if (optionCtrl != null)
                    optionCtrl.SaveData();
            }

            panel1.Controls.Clear();            
            switch (node.Text)
            {
                case "lokaler MySQL-Server":
                    panel1.Controls.Add(new Dialoge.Optionen.PanelDatabaseConnection());
                    break;
                case "Kalendar":
                    panel1.Controls.Add(new Dialoge.Optionen.PanelDayView());
                    break;
                case "Behandler":
                    panel1.Controls.Add(new Dialoge.Optionen.PanelHealer());
                    break;
                case "Räume":
                    break;
                default:
                    break;
            }

            // Wenn jetzt Control geladen ist, lade dessen Daten
            if (panel1.Controls.Count != 0)
            {
                panel1.Controls[0].Dock = DockStyle.Fill;
                optionCtrl = panel1.Controls[0] as OptionControl;
                if (optionCtrl != null)
                    optionCtrl.LoadData();
            }

        }

    }
    public  enum OptionEntry
    {
        Wurzel,
        Praxis,
        Datenbank,
        Anzeige,
        Unterpunkt

    }


}