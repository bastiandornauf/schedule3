using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using HPSchedule.Rechnungswesen;
using System.Threading;
using HPSchedule.Datenobjekte;

namespace HPSchedule.Dialoge
{
    public partial class InvoicePrinter : Form
    {
        public InvoicePrinter(InvoiceAutomator a, List<InvoiceSelector> s)
        {
            InitializeComponent();

            // prüfe Parameter
            if (a != null)
                automator = a;
            else
                throw new ArgumentNullException("a", "InvoiceAutomator must not be null");

            if (s != null)
                selectedInvoices = s;
            else
                throw new ArgumentNullException("s", "List<InvoiceSelector> must not be null");
            // Eventhandler
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);

            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = false;
        }

  
        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.PerformStep();
            SetLabelText(++act, max);
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker myWorker = (BackgroundWorker)sender;

            foreach (InvoiceSelector s in selectedInvoices)
            {
                if (s.GenerateInvoice)
                {
                    //Thread.Sleep(250);
                    Invoice currentInvoice = new Invoice();
                    currentInvoice.Generate(s.Recipient);
                    currentInvoice.Save();
                    currentInvoice.Print();
                    myWorker.ReportProgress(0, null);
                }
            }
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = progressBar1.Maximum;
            kryptonLabel1.Text = "Beendet.";
            this.Close(); 
        }

        InvoiceAutomator automator;
        List<InvoiceSelector> selectedInvoices;
        BackgroundWorker worker = new BackgroundWorker();
        int act = 0;
        int max = 0;

        private void InvoicePrinter_Load(object sender, EventArgs e)
        {
            // Richte Progressbar und Statusdialog ein
            max = selectedInvoices.CountSelected();

            progressBar1.Maximum = max;
            progressBar1.Minimum = 0;
            progressBar1.Step = 1;


            // Rufe Backgroundworker auf
            worker.RunWorkerAsync();
        }

        private void SetLabelText(int actual, int maximum)
        {
            kryptonLabel1.Text = String.Format("Erstelle Rechnung {0} von {1}", actual, maximum);
        }

        private void InvoicePrinter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (worker.IsBusy)
            {
                MessageBox.Show("Druckvorgang kann nicht abgebrochen werden.");
                e.Cancel = true;
            }
        }
    }
}
