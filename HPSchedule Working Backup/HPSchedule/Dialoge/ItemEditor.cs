using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HPSchedule.Datenobjekte;

namespace HPSchedule.Dialoge
{
    public partial class ItemEditor : Form
    {
        InvoiceItem item;
        Accounting accounting;
        public ItemEditor( InvoiceItem i, Accounting a)
        {
            InitializeComponent();

            item = i;
            accounting = a;

            UpdateFields();

            listViewFees.DoubleClick += new EventHandler(listViewFees_DoubleClick);
        }

        private void UpdateFields()
        {
            tbDescription.Text = item.Description;
            tbNumber.Text = item.Number.ToStringVerbose();

            listViewFees.Items.Clear();
            //foreach (Fee f in item.Fees)
            //{   
            //    ListViewItem li;
            //    Insurance insurance = accounting.GetInsurance( f.Insurance );
            //    if (insurance != null)
            //    {
            //        li = listViewFees.Items.Add(insurance.Label);
            //        li.SubItems.Add(f.Amount.ToString("c"));
            //    }
            //}
            foreach (Insurance i in accounting.Insurances)
            {
                ListViewItem li;
                li = listViewFees.Items.Add(i.Label);

                bool valueFound = false;
                foreach (Fee f in item.Fees)
                {
                    if (f.Insurance == i.Id)
                    {
                        li.SubItems.Add(f.Amount.ToString("c"));
                        valueFound = true;
                        break;
                    }
                }
                if( ! valueFound )
                    li.SubItems.Add("n/a");

            }
        }
        private void ReadFields()
        {
            item.Description = tbDescription.Text;
            if (TariffNumber.CheckFormat(tbNumber.Text))
            {
                item.Number.Parse(tbNumber.Text);
            }
            else
                throw new ArgumentException("Konnte TariffNumber nicht parsen!");
        }

        void listViewFees_DoubleClick(object sender, EventArgs e)
        {
            EditFee();

        }

        private void EditFee()
        {
            if (listViewFees.SelectedIndices[0] < 0)
                return;
            
            // suche Fee zur angegeben Insurance raus ...
            long insuranceId = accounting.Insurances[listViewFees.SelectedIndices[0]].Id;
            Fee f = null ;
            foreach( Fee node in item.Fees )
                if( node.Insurance == insuranceId )
                {
                    f = node;
                    break;
                }
            
            // wenn nicht existent, lege neuen an
            bool createNewFee = false;
            if (f == null)
            {
                f = new Fee();
                f.Insurance = insuranceId;
                f.Amount = 0;

                createNewFee = true;
            }
            
            // Dialog zum Betrag eingeben aufrufen
            string msg = "Betrag für " + accounting.GetInsurance(f.Insurance).Label + " eingeben.";
            AskDoubleForm dlg = new AskDoubleForm();
            dlg.Title = "Betrag eingeben";
            dlg.Label = msg;
            dlg.Result = f.Amount;

            if (dlg.ShowDialog() == DialogResult.OK)
            {

                f.Amount = dlg.Result; 
                
                if (createNewFee)
                {
                    item.Fees.Add(f);
                    f.DatabaseAction = dbAction.created;
                }
                else
                    f.DatabaseAction = dbAction.modified;

                UpdateFields();
            }
        }

        private void listViewFees_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bOK_Click(object sender, EventArgs e)
        {
            if (TariffNumber.CheckFormat(tbNumber.Text))
            {
                ReadFields();
                
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void tbNumber_TextChanged(object sender, EventArgs e)
        {
            if (TariffNumber.CheckFormat(tbNumber.Text))
            {
                errorProvider1.Clear();
            }
            else
            {
                errorProvider1.SetError(tbNumber, "Geben Sie eine GebüH-Nummer (#.#) ein.");
            }
        }

        private void mmEditFee_Click(object sender, EventArgs e)
        {
            EditFee();
        }


    }
}