using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HPSchedule
{
    public partial class AddressEditor : Form
    {
        Address a;

        public AddressEditor(Address address)
        {
            InitializeComponent();
            a = address;
        }

        private void AddressEditor_Load(object sender, EventArgs e)
        {
            tbStreet.Text = a.Street;
            tbInfo.Text = a.AdditionalInfo;
            tbPostcode.Text = a.PostCode;
            tbPlace.Text = a.Place;
            tbCountry.Text = a.Country;

            AddressCheck( a.UseForInvoice) ;
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            
            a.Street = tbStreet.Text;
            a.AdditionalInfo = tbInfo.Text;
            a.PostCode = tbPostcode.Text;
            a.Place = tbPlace.Text;
            a.Country = tbCountry.Text;

            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        void AddressCheck(bool check)
        {
            if (check)
                label6.Text = "Adresse wird als Rechnungsanschrift verwendet.";
            else
                label6.Text = "";
        }


 

    }
}