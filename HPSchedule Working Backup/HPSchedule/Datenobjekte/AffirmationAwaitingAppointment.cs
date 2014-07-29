using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace HPSchedule.Datenobjekte
{
    public class AffirmationAwaitingAppointment
    {
        public AffirmationAwaitingAppointment(long appointmentId)
        {
            
            this.AppointmentId = appointmentId; 
        }
        [Browsable(false)]
        public long AppointmentId { get; set; }
        [Browsable(false)]
        public string Label { get; set; }

        public bool Occured { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        

        [Browsable(false)]
        public long TreatmentId { get; set; }
        [Browsable(false)]
        public long InvoiceId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Diagnosis { get; set; }
        public string Treatment { get; set; }

        public void LoadDetailsFromDatabase()
        {
            throw new Exception("Not yet implemented!");
        }

        public void SetOccuredInDB()
        {
            DoDatabaseMagic.SetAppointmentAsOccured(this.AppointmentId);
        }


    }
}
