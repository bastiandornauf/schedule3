using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HPSchedule.Rechnungswesen
{
    public class AppointmentsForInvoice
    {
        private List<InvoiceRecipient> recipients = new List<InvoiceRecipient>();
        public List<InvoiceRecipient> Recipients { get { return recipients; } }

        public void LoadFromDatabase()
        {
            LoadFromDatabase(String.Empty);
        }

        public void LoadFromDatabase(string filter)
        {
            Database db = new Database();
            DataTable dt = new DataTable();
            try
            {
                // Insurance
                db.SetCommand(String.Format(@"SELECT * FROM appointmentsForInvoice {0} ORDER BY patientId;",
                    (String.IsNullOrEmpty(filter)?String.Empty:"WHERE "+filter)
                    ));
                dt = db.Table();
                long lastPatient = -1;
                InvoiceRecipient patient = new InvoiceRecipient();
                foreach (DataRow row in dt.Rows)
                {
                    if( lastPatient != (long)row["patientId"] ) 
                    {
                        if( lastPatient != -1 )
                        {
                            recipients.Add( patient );
                            patient = new InvoiceRecipient();
                        }
                        patient.Insurance = new Insurance();
                        patient.FirstName = (string)row["firstName"];
                        patient.LastName = (string)row["lastName"];
                        patient.PatientId = (long)row["patientId"];
                        patient.Insurance.Id = (long)row["insuranceId"];
                        patient.MethodOfPayment = (int)row["methodOfPayment"];
                        lastPatient = patient.PatientId;
                    }
                  
                    InvoiceAppointment i = new InvoiceAppointment();

                    i.Id = (long)row["id"];
                    i.Label = (string)row["label"];
                    i.Start = (DateTime)row["startDate"];
                    i.End = (DateTime)row["endDate"];
                    i.TreatmentId = (long)row["treatmentId"];

                    patient.Appointments.Add(i);
                }
                recipients.Add(patient);
            }
            catch (Exception e)
            {
                db.ReportError("Rechnungswese.AppointmentsForInvoice->LoadFromDatabase(): " + e.Message);
            }
            finally
            {

                // Datenbank schließen
                db.Close();
            }
        }
    }
}
