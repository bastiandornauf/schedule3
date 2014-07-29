/* Developed by Ertan Tike (ertan.tike@moreum.com) */

using System;
using System.Collections.Generic;
using System.Text;

namespace Calendar
{
    public class AppointmentEventArgs : EventArgs
    {
        public AppointmentEventArgs( DVAppointment appointment )
        {
            m_Appointment = appointment;
        }

        private DVAppointment m_Appointment;

        public DVAppointment Appointment
        {
            get { return m_Appointment; }
        }

    }
}
