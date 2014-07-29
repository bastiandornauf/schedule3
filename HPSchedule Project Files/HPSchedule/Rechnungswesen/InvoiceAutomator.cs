using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace HPSchedule.Rechnungswesen
{
    public class InvoiceAutomator
    {
        private Accounting accounting = new Accounting();
        private AppointmentsForInvoice appointments = new AppointmentsForInvoice();
        private Treatments treatments = new Treatments();

        public Accounting Accounting { get { return accounting; } }
        public AppointmentsForInvoice Appointments { get { return appointments; } }
        public Treatments Treatments { get { return treatments; } }
        
        public List<InvoiceRecipient> Recipients { get { return Appointments.Recipients; } }
        
        public delegate void ReportProgressCallback(int p);
        public ReportProgressCallback ReportProgress = null;

        private void ReportProgressSafe(int p)
        {
            if(ReportProgress != null)
                ReportProgress(p);
        }

        public void CollectData() {
            accounting.LoadFromDatabase();
            ReportProgressSafe(10);
            appointments.LoadFromDatabase();
            ReportProgressSafe(30);
            treatments.LoadFromDatabase(accounting);
            ReportProgressSafe(50);
            foreach (InvoiceRecipient r in appointments.Recipients)
            {
                if (r.Insurance != null)
                    r.Insurance = Accounting.Insurances.Find(i => i.Id == r.Insurance.Id);
                else
                    r.Insurance = Accounting.Insurances[0];
                double sum = 0.0;
                int count = r.Appointments.Count;
                int index = 0;
                foreach (InvoiceAppointment a in r.Appointments)
                {
                    ReportProgressSafe(50+50*(index/count));
                    index++;

                    Treatment t = treatments.Find( o => o.Id == a.TreatmentId );
                    
                    if (t != null)
                    {
                        foreach (Item i in t.AllItems())
                            if (i != null && r != null)
                                sum += i.Fees.GetAmount(r.Insurance.Id);


                        InvoiceTreatmentDetails td = r.Treatments.Find(o => o.Id == t.Id);

                        if (td == null) {
                            td = new InvoiceTreatmentDetails();
                            td.Id = t.Id;
                            foreach (Item i in t.AllItems() )
                                if(i !=null)
                                {
                                    td.Items.Add(i);
                                    td.Amount += i.Fees.GetAmount(r.Insurance.Id);
                                   
                                }
                            r.Treatments.Add(td);
                        }
                        td.Appointments.Add(a);
                    }


                }
                r.Sum = sum;
                

                // fülle Treatment details



            } 
        }

       
    }

}
