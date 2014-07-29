using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using HPSchedule.Rechnungswesen;

namespace HPSchedule.Dialoge
{
    public partial class TestRechnungsdruck : KryptonForm
    {
        public TestRechnungsdruck()
        {
            InitializeComponent();
            kryptonRichTextBox1.Text = String.Empty;

            InitializeBackgroundWorker();
        }
        BackgroundWorker worker = new BackgroundWorker(); 
        InvoiceAutomator automator = new InvoiceAutomator();
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        private void TestRechnungsdruck_Load(object sender, EventArgs e)
        {
            kryptonRichTextBox1.Text = "Bitte warten...";
            kryptonRichTextBox1.ReadOnly = true;
            worker.RunWorkerAsync();
            

            
            
            

        }


        #region BackgroundWorker

        private void InitializeBackgroundWorker()
        {
           
            worker.WorkerSupportsCancellation = false;
            worker.WorkerReportsProgress = false ;

            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            kryptonRichTextBox1.Text = e.ProgressPercentage.ToString();
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            sw.Stop();
            this.UseWaitCursor = false;
            kryptonRichTextBox1.ReadOnly = false;


            kryptonRichTextBox1.SuspendLayout();
            kryptonRichTextBox1.Text = String.Empty;

            foreach (InvoiceRecipient r in automator.Recipients)
                kryptonRichTextBox1.AppendText(
                    String.Format("{0} => {1:c}", r.ToString(), r.Sum) + Environment.NewLine);
            kryptonRichTextBox1.ResumeLayout();

            FlashWindow.Flash(this);
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {         
            this.UseWaitCursor = true;
            sw.Start();
            automator.CollectData();

            //müsste worker.reportprogress einbauen
        }

        #endregion

    }
}

