using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HPSchedule.Dialoge
{
    public partial class AskBoolean : Form
    {
        public bool Value {get; set;}
        public string Caption { get; set; }
        public string Question { get; set; }
        
        public AskBoolean()
        {
            InitializeComponent();
            
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Value = checkBox1.Checked;
            this.Close();
        }

        private void AskBoolean_Load(object sender, EventArgs e)
        {
            label1.Text = Question;
            checkBox1.Text = Caption;
            checkBox1.Checked = Value;
        }
    }
}
