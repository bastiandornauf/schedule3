using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HPSchedule.Rechnungswesen;
using ComponentFactory.Krypton.Toolkit;

namespace HPSchedule.Dialoge
{
    public partial class InvoicePrintingDlg : KryptonForm
    {
        public InvoicePrintingDlg()
        {
            InitializeComponent();
            InitializeBackgroundWorker();
            InitializeSettingComponent();

            invoiceDgv.CellEndEdit += new DataGridViewCellEventHandler(invoiceDgv_CellEndEdit);

            this.FormClosing += new FormClosingEventHandler(InvoicePrintingDlg_FormClosing);
        }

        void InvoicePrintingDlg_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (invoiceSelectorList.CountSelected() > 0)
            {
                Dialoge.InvoicePrinter printer = new InvoicePrinter(automator, invoiceSelectorList);
                printer.Show();
            }
        }

        void invoiceDgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            UpdateStatusBar();
        }

        BackgroundWorker worker = new BackgroundWorker();
        InvoiceAutomator automator = new InvoiceAutomator();
        List<InvoiceSelector> invoiceSelectorList = new List<InvoiceSelector>();
        BindingSource bs = new BindingSource();


        DataTable settingsDt = new DataTable();
        DataTable invoicesDt = new DataTable();
        #region BackgroundWorker

        private void InitializeBackgroundWorker()
        {

            worker.WorkerSupportsCancellation = false;
            worker.WorkerReportsProgress = false;

            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            //worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
        }
        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            foreach( InvoiceRecipient r in automator.Recipients ) {
                invoiceSelectorList.Add(new InvoiceSelector(r));
            }
            CheckAllSelectors();

            invoiceSelectorList.Sort();
            bs.DataSource = invoiceSelectorList;
            //bs.Sort = "LastName ASC, FirstName ASC";
            invoiceDgv.DataSource = bs; //invoiceSelectorList;

            invoiceDgv.Columns["Total"].DefaultCellStyle.Format = "c";
            invoiceDgv.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            invoiceDgv.Columns["NumberOfAppointments"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            invoiceDgv.Columns["SinceLastAppointment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            invoiceDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            invoiceDgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

   
            DialogueWaiting(false);
            UpdateStatusBar();

            
            FlashWindow.Flash(this);
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            
            automator.CollectData();
            //müsste worker.reportprogress einbauen
        }

        #endregion

        DataRow conditionCount;
        DataRow conditionLast;
        DataRow conditionTotal;
        
        private void InitializeSettingComponent()
        {
            DataColumn col = new DataColumn("Description", typeof(string));
            col.ReadOnly = true;

            settingsDt.Columns.Add(col);

            col = new DataColumn("Value", typeof(int));
            settingsDt.Columns.Add(col);

            conditionCount = settingsDt.NewRow();
            conditionCount["Description"] = "Anzahl Termine";
            conditionCount["Value"] = 12;
            settingsDt.Rows.Add(conditionCount);

            conditionLast = settingsDt.NewRow();
            conditionLast["Description"] = "Tage seit letzter Behandlung";
            conditionLast["Value"] = 30;
            settingsDt.Rows.Add(conditionLast);

            conditionTotal = settingsDt.NewRow();
            conditionTotal["Description"] = "Rechnungsbetrag (€)";
            conditionTotal["Value"] = 1000;
            settingsDt.Rows.Add(conditionTotal);


            settingsDgv.DataSource = settingsDt;
            settingsDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            settingsDgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            settingsDgv.Columns["Value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }


        private void InvoicePrintingDlg_Load(object sender, EventArgs e)
        {
            DialogueWaiting(true); 
            worker.RunWorkerAsync();
        }

        private void DialogueWaiting(bool p)
        {
            this.UseWaitCursor = p;

            invoiceDgv.Enabled = !p;
            settingsDgv.Enabled = !p;

            toolStripStatusLabel1.Text = p ? "Bitte warten ..." : "";
        }

        private void CheckAllSelectors()
        {
            foreach (InvoiceSelector s in invoiceSelectorList)
            {
                s.CheckState((int)conditionCount["Value"], (Double)((int)conditionTotal["Value"]), (int)conditionLast["Value"]);
            }
        }

        private void UpdateStatusBar()
        {
            int totalCount = automator.Recipients.Count;

            double sum = 0.0;
            int selectedCount = 0;

            foreach (InvoiceSelector s in invoiceSelectorList)
            {
                if (s.GenerateInvoice)
                {
                    selectedCount++;
                    sum += s.Total;
                }
            }


            toolStripStatusLabel1.Text = String.Format("Es sind {0} von {1} möglichen Rechnungen ausgewählt. Gesamtsumme {2:c}",
                selectedCount, totalCount, sum);
        }

        private void aktualisierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //todo: überprüfe eingaben
            foreach (InvoiceSelector s in invoiceSelectorList)
                s.CheckState((int)conditionCount["Value"], (Double)((int)conditionTotal["Value"]), (int)conditionLast["Value"]);

            UpdateInvoiceDgv();
        }

        private void alleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (InvoiceSelector s in invoiceSelectorList)
                s.GenerateInvoice = true;

            UpdateInvoiceDgv();
        }

        private void keineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (InvoiceSelector s in invoiceSelectorList)
                s.GenerateInvoice = false;

            UpdateInvoiceDgv();

        }

        private void UpdateInvoiceDgv()
        {
            DialogueWaiting(true);
            invoiceDgv.SuspendLayout();
            invoiceDgv.DataSource = invoiceSelectorList;
            invoiceDgv.ResumeLayout();
            invoiceDgv.Invalidate();
            DialogueWaiting(false);
            UpdateStatusBar();
        }

    }

}
