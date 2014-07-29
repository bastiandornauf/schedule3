using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HPSchedule.Dialoge
{
    public partial class AskDoubleForm : Form
    {
        private double result;
        public double Result
        {
            get { return result; }
            set
            {
                textBox1.Text = String.Format("{0:c}", value);
                result = value;
            }
        }
        public string Label
        {
            set { label1.Text = value; }
        }

        public string Title
        {
            set { this.Text = value; }
        }
   
        public AskDoubleForm()
        {
            InitializeComponent();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            if (Double.TryParse(textBox1.Text.Replace('€', ' ').Trim(), out result))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if( ! Double.TryParse( textBox1.Text.Replace('€', ' ').Trim(), out result ) )
                errorProvider1.SetError(textBox1, "Geben Sie einen Betrag ein.");
            else
                errorProvider1.Clear();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}