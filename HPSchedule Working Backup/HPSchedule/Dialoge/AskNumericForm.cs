using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HPSchedule
{
    public partial class AskNumericForm : Form
    {
        private int result;
        
        public int Result
        {
            get { return result; }
        }
        public string Label
        {
            set { label1.Text = value; }
        }

        public string Title
        {
            set { this.Text = value; }
        }
    
        public AskNumericForm()
        {
            InitializeComponent();
            
        }

        private void AskNumericForm_Load(object sender, EventArgs e)
        {

        }

        private void bOK_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(textBox1.Text, out result))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
                DialogResult = DialogResult.Cancel;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!Int32.TryParse(textBox1.Text, out result))
                errorProvider1.SetError(textBox1, "Bitte geben Sie eine ganze Zahl ein.");
            else
                errorProvider1.SetError(textBox1, "");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void bCancel_Click(object sender, EventArgs e)
        {

        }
    }
}