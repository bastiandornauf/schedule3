using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HPSchedule.Dialoge
{
    public partial class AskStringForm : Form
    {
        public AskStringForm()
        {
            InitializeComponent();
        }

        private string result;        
        public string Result
        {
            get { return result; }
            set { 
                textBox1.Text = value;
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


        private void bOK_Click(object sender, EventArgs e)
        {
            result = textBox1.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}