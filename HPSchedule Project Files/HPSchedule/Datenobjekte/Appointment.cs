using System;
using System.Collections.Generic;
using System.Text;

using Calendar;
using System.Drawing;

namespace HPSchedule
{
    class Appointment : DVAppointment
    {
        public Appointment()
        {
            base.TextColor = Color.Black;
        }
        public Appointment(DVAppointment ap)
        {
            this.StartDate = ap.StartDate;
            this.EndDate = ap.EndDate;
            this.Title = ap.Title;

            this.BorderColor = ap.BorderColor;
            this.Color = ap.Color;
            this.TextColor = ap.TextColor;

            this.isModified = ap.isModified;
            this.isTreatment = ap.isTreatment;
            this.treatmentId = ap.treatmentId;

            this.Id = ap.Id;
            this.InPlaceEditable = ap.InPlaceEditable;

            this.Group = ap.Group;           
        }

        public new string Group
        {
            get { return ""; }
            set { }
        }

        public new Color Color
        {
            get
            {
                if (base.isTreatment)
                    return Color.White;
                else
                    return Color.Khaki;
            }
            set
            {
                base.Color = value;
            }
        }
            
        public new string Title {
            get
            {
                if (base.isTreatment)
                    return "TERMIN";
                else
                    return base.Title;
            }
            set
            {
                base.Title = value;
            }        
        }

        public bool IsTreatment
        {
            get { return base.isTreatment; }
            set {
                if (value)
                {
                    base.Color = Color.White;
                }
                else
                {
                    base.Color = Color.Khaki;
                    base.BorderColor = Color.Khaki;
                }
                base.isTreatment = value; 
            }
        }
        public bool IsModified
        {
            get { return base.isModified; }
            set { base.isModified = value; }
     
        }
        private bool occured;

        public bool Occured
        {
            get { return occured; }
            set { occured = value; }
        }

    }
}
