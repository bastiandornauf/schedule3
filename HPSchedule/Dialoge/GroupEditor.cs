using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using global::HPSchedule.Datenobjekte;

namespace HPSchedule.Dialoge
{
    public partial class GroupEditor : Form
    {
        private Group group;
        private Accounting accounting;

        private List<InvoiceItem> groupItems;
        private List<InvoiceItem> accountingItems;
        Dialoge.ShowFees showFeesDlg = new ShowFees( new List<string>() );

        public GroupEditor(Group g, Accounting a)
        {
            InitializeComponent();
            
            group = g;
            accounting = a;
            
            accountingItems = accounting.Items;
            groupItems = new List<InvoiceItem>();
            foreach (long itemId in group.InvoiceItems)
            {
                groupItems.Add(accounting.GetItem(itemId));
            }
            
            InitializeControls();

            this.FormClosing += new FormClosingEventHandler(GroupEditor_FormClosing);
            showFeesDlg.Show();
            showFeesDlg.Visible = false;

            LoadDataToForm();
        
        }

        void GroupEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            // sorge dafür, daß das Tool-Window verschwindet
            showFeesDlg.StayOpen = false;
            showFeesDlg.Close();
        }

        private void LoadDataToForm()
        {
            listViewItems.Items.Clear();
            foreach (InvoiceItem i in accountingItems)
            {
                ListViewItem li;
                li = listViewItems.Items.Add(i.Number.ToString());
                li.SubItems.Add(i.Description);
                li.SubItems.Add(i.Id.ToString() );
            }

            listViewGroup.Items.Clear();
            foreach (InvoiceItem i in groupItems)
            {
                
                ListViewItem li;
                if (i != null)
                {
                    li = listViewGroup.Items.Add(i.Number.ToString());
                    li.SubItems.Add(i.Description);
                    li.SubItems.Add(i.Id.ToString());
                }
                else
                {
                    li = listViewGroup.Items.Add("?");
                    li.SubItems.Add("Artikel unbekannt");
                }
            }

            tbLabel.Text = group.Label;

            UpdateShowFees();
        }

        private void UpdateShowFees()
        {
            List<string> values = new List<string>();
            foreach (Insurance insurance in accounting.Insurances)
            {
                values.Add(insurance.Label);
                
                double sum = 0;
                foreach (InvoiceItem item in groupItems)
                {
                    if (item != null)
                    {
                        //System.Diagnostics.Debug.WriteLine(item);
                        Fee f = item.GetFee(insurance.Id);
                        //System.Diagnostics.Debug.WriteLine(f);
                        if (f != null)
                        {
                            //System.Diagnostics.Debug.WriteLine(sum);
                            sum += f.Amount;

                        }
                    }
                }
                values.Add(String.Format("{0:c}", sum));
            }

            showFeesDlg.UpdateContent(values);
        }

        private void InitializeControls()
        {
            listViewGroup.AllowDrop = true;
            listViewGroup.ItemDrag += new ItemDragEventHandler(listViewGroup_ItemDrag);
            listViewGroup.DragEnter += new DragEventHandler(listViewGroup_DragEnter);
            listViewGroup.DragDrop += new DragEventHandler(listViewGroup_DragDrop);

            listViewGroup.View = View.Details;
            listViewGroup.FullRowSelect = true;
            listViewGroup.Columns.Add("Nummer");
            listViewGroup.Columns.Add("Beschreibung");
            listViewGroup.Columns.Add("ID");
            int w = (int)((0.95*listViewGroup.Width) / 8);
            listViewGroup.Columns[0].Width = w * 1;
            listViewGroup.Columns[1].Width = w * 6;
            listViewGroup.Columns[2].Width = w * 1;

            listViewGroup.MouseDown += new MouseEventHandler(listView_MouseDown);

            listViewItems.AllowDrop = true;
            listViewItems.ItemDrag += new ItemDragEventHandler(listViewItems_ItemDrag);
            listViewItems.DragEnter += new DragEventHandler(listViewItems_DragEnter);
            listViewItems.DragDrop += new DragEventHandler(listViewItems_DragDrop);

            listViewItems.MouseDown += new MouseEventHandler(listView_MouseDown);

            listViewItems.View = View.Details;
            listViewItems.FullRowSelect = true;
            listViewItems.Columns.Add("Nummer");
            listViewItems.Columns.Add("Beschreibung");
            listViewItems.Columns.Add("ID");
            w = listViewGroup.Width / 8;
            listViewItems.Columns[0].Width = w * 1;
            listViewItems.Columns[1].Width = w * 6;
            listViewItems.Columns[2].Width = w * 1;


            tbLabel.TextChanged += new EventHandler(tbLabel_TextChanged);
        }

        void listView_MouseDown(object sender, MouseEventArgs e)
        {
            ListView ctrl = sender as ListView;
            if (ctrl == null)
                return;

            if (ctrl.Name == "listViewItems") 
            {
                zurGruppeHinzufuegenToolStripMenuItem.Visible = true;
                ausDerGruppeEntfernenToolStripMenuItem.Visible = false;
            } else if(ctrl.Name == "listViewGroup") {
                zurGruppeHinzufuegenToolStripMenuItem.Visible = false;
                ausDerGruppeEntfernenToolStripMenuItem.Visible = true;
            } 
        }

        void tbLabel_TextChanged(object sender, EventArgs e)
        {
            if( group.Label != tbLabel.Text )
                group.DatabaseAction = dbAction.modified;
        }

        #region dragdrop

        void listViewItems_DragDrop(object sender, DragEventArgs e)
        {
            // Löschen aus der Quelle            
            InvoiceItem[] itemsToRemove = (InvoiceItem[])e.Data.GetData("dragdrop2");
            foreach (InvoiceItem i in itemsToRemove)
            {
                RemoveGroupItem(i);
            }
            group.DatabaseAction = dbAction.modified;
            LoadDataToForm();            
        }

        private void RemoveGroupItem(InvoiceItem i)
        {
            int index = -1;
            for (int node = 0; node < groupItems.Count; node++)
            {
                if (groupItems[node].Id == i.Id)
                {
                    index = node;
                    break;
                }
            }
            if (index >= 0)
                groupItems.RemoveAt(index);

        }

        void listViewItems_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("dragdrop2"))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        void listViewItems_ItemDrag(object sender, ItemDragEventArgs e)
        {
            InvoiceItem[] dragArray = GetSelectedItems(listViewItems);
            DataObject obj = new DataObject("dragdrop", dragArray);            
            this.listViewItems.DoDragDrop(obj, DragDropEffects.Copy);
        }

        private void listViewGroup_DragDrop(object sender, DragEventArgs e)
        {
            groupItems.AddRange((InvoiceItem[])e.Data.GetData("dragdrop"));
            group.DatabaseAction = dbAction.modified;
            LoadDataToForm();
        }

        void listViewGroup_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("dragdrop"))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        void listViewGroup_ItemDrag(object sender, ItemDragEventArgs e)
        {
            InvoiceItem[] dragArray = GetSelectedItems(listViewGroup);
            DataObject obj = new DataObject("dragdrop2", dragArray);
            this.listViewGroup.DoDragDrop(obj, DragDropEffects.Move);

        }

        private InvoiceItem[] GetSelectedItems(ListView ctrl)
        {
            if( ctrl == null )
                throw new Exception("Parameter nicht gültiges ListView-Objekt");
         
            InvoiceItem[] dragArray = new InvoiceItem[ctrl.SelectedItems.Count];
            for (int iter = 0; iter < ctrl.SelectedItems.Count; iter++)
            {
                dragArray[iter] = new InvoiceItem();
                InvoiceItem a = dragArray[iter];
                InvoiceItem b;
                if( ctrl.Name == "listViewGroup" )
                    b = groupItems[ctrl.SelectedIndices[iter]];
                else
                    b = accountingItems[ctrl.SelectedIndices[iter]];

                a.Id = b.Id;
                a.Description = b.Description;
                a.Number.Main = b.Number.Main;
                a.Number.Sub = b.Number.Sub;
                foreach (Fee f in b.Fees)
                    a.Fees.Add(f);
            }
            return dragArray;
        }

        #endregion

        private void bOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            LoadDataFromFrom();
            Close();
        }

        private void LoadDataFromFrom()
        {                              
            group.Label = tbLabel.Text;
            group.InvoiceItems.Clear();
            foreach (InvoiceItem i in groupItems)
                group.InvoiceItems.Add(i.Id);            
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cbShowFees_CheckedChanged(object sender, EventArgs e)
        {
            if (showFeesDlg.Visible)
                showFeesDlg.Visible = false;
            else
                showFeesDlg.Visible = true;
        }

        private void ausDerGruppeEntfernenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach( InvoiceItem i in GetSelectedItems( listViewGroup ) ) 
            {
                RemoveGroupItem( i );   
            }
            group.DatabaseAction = dbAction.modified;
            LoadDataToForm();
        }

        private void zurGruppeHinzufügenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupItems.AddRange(GetSelectedItems(listViewItems));
            group.DatabaseAction = dbAction.modified;
            LoadDataToForm();
        }
    }
}