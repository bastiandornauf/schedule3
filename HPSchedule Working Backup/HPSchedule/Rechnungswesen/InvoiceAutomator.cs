using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

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




        public void CollectData() {
            accounting.LoadFromDatabase();
            appointments.LoadFromDatabase();
            treatments.LoadFromDatabase(accounting);

            foreach (InvoiceRecipient r in appointments.Recipients)
            {
                r.Insurance = Accounting.Insurances.Find(i => i.Id == r.Insurance.Id);
                double sum = 0.0;
                foreach (InvoiceAppointment a in r.Appointments)
                {
                    Treatment t = treatments.Find( o => o.Id == a.TreatmentId );
                    if (t != null)
                    {
                        foreach (Item i in t.AllItems())
                            sum += i.Fees.GetAmount(r.Insurance.Id);


                        InvoiceTreatmentDetails td = r.Treatments.Find(o => o.Id == t.Id);

                        if (td == null) {
                            td = new InvoiceTreatmentDetails();
                            td.Id = t.Id;
                            foreach (Item i in t.AllItems() )
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
