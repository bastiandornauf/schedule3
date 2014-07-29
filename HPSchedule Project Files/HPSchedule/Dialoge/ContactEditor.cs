using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HPSchedule
{
    public partial class ContactEditor : Form
    {
        Contact contact;        

        public ContactEditor( Contact c )
        {
            InitializeComponent();
            contact = c;
        }

        private void ContactEditor_Load(object sender, EventArgs e)
        {
            if (contact.ContactInfo != "")
                tbContactInfo.Text = contact.ContactInfo;
            else
                tbContactInfo.Text = "???";
            
            if (contact.Label != "")
                cbLabel.Text = contact.Label;
            else
                cbLabel.SelectedIndex = 0;
        }

        private void textBoxLabel_TextChanged(object sender, EventArgs e)
        {
            if (tbContactInfo.Text == "")
            {
                errorProvider1.SetError(tbContactInfo, "Das Label darf nicht leer sein.");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            if (tbContactInfo.Text != "")
            {
                DialogResult = DialogResult.OK;

                contact.Label = cbLabel.Text;
                contact.ContactInfo = tbContactInfo.Text;

                Close();
            }
        }
    }
}