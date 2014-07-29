using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using HPSchedule.Datenobjekte;

namespace HPSchedule
{
    public partial class InvoiceGroupAndItemEditor : Form
    {
        #region dialogAllgemein
        Accounting accounting = new Accounting();
        public InvoiceGroupAndItemEditor()
        {
            InitializeComponent();
            InitialzeControls();

            accounting.LoadFromDatabase();

            UpdateControls(CtrlUpdate.all);
        }


        private void UpdateControls(CtrlUpdate action)
        {
            if (action == CtrlUpdate.all || action == CtrlUpdate.lvGroupAndItem || action == CtrlUpdate.lvItem)
                UpdateItemListView();
            if (action == CtrlUpdate.all || action == CtrlUpdate.lvGroupAndItem || action == CtrlUpdate.lvGroup)
                UpdateGroupListView();
            if (action == CtrlUpdate.all || action == CtrlUpdate.lbInsurance) {
                UpdateInsuranceListbox();
                UpdateShowListBox();
            }

            bApply.Enabled = accounting.DatabaseAction != dbAction.none;
        }

        void listBoxInsurances_DoubleClick(object sender, EventArgs e)
        {
            EditInsurance();
        }

        void listViewItems_DoubleClick(object sender, EventArgs e)
        {
            EditItem();
        }


        void listViewGroups_DoubleClick(object sender, EventArgs e)
        {
            EditGroup();
        }


        void listViewGroups_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            
            ListView lv = sender as ListView;
            if (lv == null)
                throw new Exception();

            if (e.Button == MouseButtons.Right)
            {
                if (lv.SelectedIndices.Count > 0 )
                {
                    Group selectedGroup = accounting.Groups[lv.SelectedIndices[0]];

                    if (selectedGroup.DatabaseAction == dbAction.delete)
                    {
                        mmGroupEdit.Visible = false;
                        mmGroupNew.Visible = false;
                        mmGroupDelete.Text = "Wiederherstellen";
                    }
                    else
                    {
                        mmGroupEdit.Visible = true;
                        mmGroupNew.Visible = true;
                        mmGroupDelete.Text = "Löschen";
                    }
                    mmGroupDelete.Enabled = true;
                    mmGroupEdit.Enabled = true;
                }
                else
                {
                    mmGroupDelete.Enabled = false;
                    mmGroupEdit.Enabled = false;
                }
            }
        }

        void listViewItems_MouseDown(object sender, MouseEventArgs e)
        {
            base.OnMouseDown(e);
            
            ListView lv = sender as ListView;
            if (lv == null)
                throw new Exception();

            if (e.Button == MouseButtons.Right)
            {
                if (lv.SelectedIndices.Count > 0)
                {
                    InvoiceItem selectedItem = accounting.Items[lv.SelectedIndices[0]];

                    if (selectedItem.DatabaseAction == dbAction.delete)
                    {
                        mmItemEdit.Visible = false;
                        mmItemNew.Visible = false;
                        mmItemDelete.Text = "Wiederherstellen";
                    }
                    else
                    {
                        mmItemEdit.Visible = true;
                        mmItemNew.Visible = true;
                        mmItemDelete.Text = "Löschen";
                    }
                    mmItemDelete.Enabled = true;
                    mmItemEdit.Enabled = true;
                }
                else
                {
                    mmItemDelete.Enabled = false;
                    mmItemEdit.Enabled = false;
                }
            }
        }

        void listBoxInsurances_MouseDown(object sender, MouseEventArgs e)
        {
            ListBox lb = sender as ListBox;
            if( lb == null)
                throw new Exception();


            if (e.Button == MouseButtons.Right)
            {
                if (lb.SelectedIndex >= 0)
                {
                    if (accounting.Insurances[lb.SelectedIndex].DatabaseAction == dbAction.delete)
                    {
                        mmInsuranceEdit.Visible = false;
                        mmInsuranceNew.Visible = false;
                        mmInsuranceDelete.Text = "Wiederherstellen";
                    }
                    else
                    {
                        mmInsuranceEdit.Visible = true;
                        mmInsuranceNew.Visible = true;
                        mmInsuranceDelete.Text = "Löschen";                        
                    }
                    mmInsuranceDelete.Enabled = true;
                    mmInsuranceEdit.Enabled = true;
                }
                else
                {
                    mmInsuranceDelete.Enabled = false;
                    mmInsuranceEdit.Enabled = false;
                }
            }
        }

        private void InitialzeControls()
        {
            tabControl1.Selecting += new TabControlCancelEventHandler(tabControl1_Selecting);

            listBoxInsurances.MouseDown += new MouseEventHandler(listBoxInsurances_MouseDown);
            listBoxInsurances.DoubleClick += new EventHandler(listBoxInsurances_DoubleClick);
            listViewItems.MouseDown += new MouseEventHandler(listViewItems_MouseDown);
            listViewItems.DoubleClick += new EventHandler(listViewItems_DoubleClick);
            listViewGroups.MouseDown += new MouseEventHandler(listViewGroups_MouseDown);
            listViewGroups.DoubleClick += new EventHandler(listViewGroups_DoubleClick);

            
            listViewGroups.View = View.Details;
            listViewItems.View = View.Details;
        }

        void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (accounting.DatabaseAction != dbAction.none)
            {
                if (MessageBox.Show("Wollen Sie die Änderungen übernehmen?", "Vorsicht", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ApplyChanges();
                }
                else
                    e.Cancel = true;
            }
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            accounting.SaveToDatabase();
            Close();
        }
        private void listBoxInsurance_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControls(CtrlUpdate.lvGroupAndItem);
        }

        private void comboBoxShowFeesBasedOnInsurance_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControls(CtrlUpdate.lvGroupAndItem);
        }


        #endregion


        #region insurance
        /// <summary>
        /// Füllt die Listbox der Abrechnungs-Arten mit Werten.
        /// </summary>
        void UpdateInsuranceListbox()
        {
            listBoxInsurances.Items.Clear();

            foreach (Insurance i in accounting.Insurances)
            {
                if( i.DatabaseAction == dbAction.delete )
                    listBoxInsurances.Items.Add(i.Label + " [wird gelöscht]");
                else
                    listBoxInsurances.Items.Add(i.Label);
            }
        }
        
        private void UpdateShowListBox()
        {
            comboBoxShowFeesBasedOnInsurance.Items.Clear();
            foreach (Insurance i in accounting.Insurances)
            {
                if (i.DatabaseAction == dbAction.delete)
                    comboBoxShowFeesBasedOnInsurance.Items.Add("---"+i.Label+"---");
                    //listBoxShowFeesAsInsurance.Items.Add("("+i.Label+")");
                else
                    //listBoxShowFeesAsInsurance.Items.Add(i.Label);
                    comboBoxShowFeesBasedOnInsurance.Items.Add(i.Label);
            }
        }

        private void mmInsuranceNew_Click(object sender, EventArgs e)
        {
            // Editor für neue Abrechnungsart starten
            Dialoge.AskStringForm dlg = new Dialoge.AskStringForm();

            dlg.Title = "Neue Abrechnungs-Art";
            dlg.Label = "Geben Sie einen Namen für die neue Abrechnungs-Art ein.";

            if (dlg.ShowDialog() == DialogResult.OK)
            {                
                // Erzeuge den neuen Eintrag
                Insurance newInsurance = new Insurance();
                
                newInsurance.Label = dlg.Result;
                newInsurance.DatabaseAction = dbAction.created;

                accounting.Insurances.Add(newInsurance);
                accounting.DatabaseAction = dbAction.modified;

                UpdateControls(CtrlUpdate.lbInsurance);
            }           
        }

        private void mmInsuranceEdit_Click(object sender, EventArgs e)
        {
            EditInsurance();
        }
        private void EditInsurance()
        {
            Dialoge.AskStringForm dlg = new Dialoge.AskStringForm();

            dlg.Title = "Abrechnungs-Art ändern";
            dlg.Label = "Geben Sie einen neuen Namen für die Abrechnungs-Art ein.";
            dlg.Result = accounting.Insurances[listBoxInsurances.SelectedIndex].Label;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // ändere den Eintrag
                accounting.Insurances[listBoxInsurances.SelectedIndex].Label = dlg.Result;
                accounting.Insurances[listBoxInsurances.SelectedIndex].DatabaseAction = dbAction.modified;

                accounting.DatabaseAction = dbAction.modified;

                UpdateControls(CtrlUpdate.lbInsurance);
            }
        }


        private void mmInsuranceDelete_Click(object sender, EventArgs e)
        {
            if (accounting.Insurances[listBoxInsurances.SelectedIndex].DatabaseAction == dbAction.delete)
            {
                accounting.Insurances[listBoxInsurances.SelectedIndex].DatabaseAction = dbAction.modified;
            }
            else
            {
                accounting.Insurances[listBoxInsurances.SelectedIndex].DatabaseAction = dbAction.delete;
            }
            accounting.DatabaseAction = dbAction.modified;
            UpdateControls(CtrlUpdate.lbInsurance);
        }
        #endregion

        #region group
        private void UpdateGroupListView()
        {
            listViewGroups.Items.Clear();

            foreach (Group g in accounting.Groups)
            {
                if (g.DatabaseAction != dbAction.delete)
                {
                    ListViewItem li;
                    li = listViewGroups.Items.Add(g.Label);
                    li.SubItems.Add(g.GetItemsAsString());
                    li.SubItems.Add(accounting.SumGroupFeeAsString(g, comboBoxShowFeesBasedOnInsurance.SelectedIndex));
                    if (g.Id > 0)
                        li.SubItems.Add(g.Id.ToString());
                    else
                        li.SubItems.Add("?");
                }
                else
                {
                    ListViewItem li;
                    li = listViewGroups.Items.Add("---");
                    li.SubItems.Add("---wird gelöscht---");
                    li.SubItems.Add("---");
                    li.SubItems.Add(g.Id.ToString());
                }
            }
        }
        private void mmGroupNew_Click(object sender, EventArgs e)
        {
            Group g = new Group();
            Dialoge.GroupEditor dlg = new global::HPSchedule.Dialoge.GroupEditor(g, accounting);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                g.DatabaseAction = dbAction.created;
                accounting.DatabaseAction = dbAction.modified;
                accounting.Groups.Add(g);

                UpdateControls(CtrlUpdate.lvGroup);
            }
        }

        private void mmGroupEdit_Click(object sender, EventArgs e)
        {
            EditGroup();
        }
        private void EditGroup()
        {
            if (listViewGroups.SelectedIndices.Count > 0)
            {
                Group g = accounting.Groups[listViewGroups.SelectedIndices[0]];
                Dialoge.GroupEditor dlg = new global::HPSchedule.Dialoge.GroupEditor(g, accounting);
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    accounting.DatabaseAction = dbAction.modified; 
                    UpdateControls(CtrlUpdate.lvGroup);
                }
            }
        }


        private void mmGroupDelete_Click(object sender, EventArgs e)
        {
            Group g = accounting.Groups[listViewGroups.SelectedIndices[0]];
            if (g.DatabaseAction != dbAction.delete)
                g.DatabaseAction = dbAction.delete;
            else
                g.DatabaseAction = dbAction.modified;

            accounting.DatabaseAction = dbAction.modified;

            UpdateControls(CtrlUpdate.lvGroup);
        }
        #endregion

        #region items
        private void UpdateItemListView()
        {
            listViewItems.Items.Clear();

            foreach (InvoiceItem i in accounting.Items)
            {
                
                ListViewItem li;
                if (i.DatabaseAction != dbAction.delete)
                {
                    li = listViewItems.Items.Add(i.Number.ToString());
                    li.SubItems.Add(i.Description);

                    string f;
                    if (comboBoxShowFeesBasedOnInsurance.SelectedIndex >= 0 && comboBoxShowFeesBasedOnInsurance.SelectedIndex < i.Fees.Count)
                        f = String.Format("{0:c}", i.Fees[comboBoxShowFeesBasedOnInsurance.SelectedIndex].Amount);
                    else
                        f = "?";

                    li.SubItems.Add(f);
                    if (i.Id > 0)
                        li.SubItems.Add(i.Id.ToString());
                    else
                        li.SubItems.Add("?");
                }
                else
                {
                    li = listViewItems.Items.Add("---");
                    li.SubItems.Add("---wird gelöscht---");
                    li.SubItems.Add("---");
                    li.SubItems.Add(i.Id.ToString());

                }
            }
        }

        private void mmItemNew_Click(object sender, EventArgs e)
        {
            InvoiceItem newItem = new InvoiceItem();
            Dialoge.ItemEditor editor = new global::HPSchedule.Dialoge.ItemEditor(newItem, accounting);
            if (editor.ShowDialog() == DialogResult.OK)
            {
                newItem.DatabaseAction = dbAction.created;
                accounting.DatabaseAction = dbAction.modified;
                accounting.Items.Add(newItem);

                UpdateControls(CtrlUpdate.lvItem);
            }

        }

        private void mmItemEdit_Click(object sender, EventArgs e)
        {
            EditItem();
        }
        private void EditItem()
        {
            InvoiceItem item = accounting.Items[listViewItems.SelectedIndices[0]];
            Dialoge.ItemEditor editor = new global::HPSchedule.Dialoge.ItemEditor(item, accounting);

            if (editor.ShowDialog() == DialogResult.OK)
            {
                item.DatabaseAction = dbAction.modified;
                accounting.DatabaseAction = dbAction.modified;

                UpdateControls(CtrlUpdate.lvItem);
            }
        }

        private void mmItemDelete_Click(object sender, EventArgs e)
        {
            InvoiceItem item = accounting.Items[listViewItems.SelectedIndices[0]];
            
            if (item.DatabaseAction != dbAction.delete)
                item.DatabaseAction = dbAction.delete;
            else
                item.DatabaseAction = dbAction.modified;
            accounting.DatabaseAction = dbAction.modified;

            UpdateControls(CtrlUpdate.lvItem);
        }

        #endregion

        private void bApply_Click(object sender, EventArgs e)
        {
            ApplyChanges();
        }

        void ApplyChanges()
        {
            accounting.SaveToDatabase();

            accounting = new Accounting();
            accounting.LoadFromDatabase();

            UpdateControls(CtrlUpdate.all);

        }

        private enum CtrlUpdate
        {
            lvGroupAndItem,
            lvGroup,
            lvItem,
            lbInsurance,
            all
        }
    }


}