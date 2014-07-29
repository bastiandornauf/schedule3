/* Developed by Ertan Tike (ertan.tike@moreum.com) */

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Calendar
{
    public class DVAppointment
    {
        public bool isTreatment;
        public bool isModified;
        public long treatmentId;

        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        private bool inPlaceEditing;
        public bool InPlaceEditable
        {
            get { return inPlaceEditing; }
            set { inPlaceEditing = value; }

        }
        public DVAppointment()
        {
            color = Color.White;
            borderColor = Color.Blue;
            textColor = Color.Black;
            
            title = "New Appointment";
            inPlaceEditing = true;
            isModified = false;
            isTreatment = false;
        }

        private string group;
        
        public string Group
        {
            get { return group; }
            set { group = value; }
        }
        
        private DateTime startDate;

        public DateTime StartDate
        {
            get
            {
                return startDate;
            }
            set
            {
                startDate = value;
                OnStartDateChanged();

            }
        }
        protected virtual void OnStartDateChanged()            
        {
            isModified = true;
        }

        private DateTime endDate;

        public DateTime EndDate
        {
            get
            {
                return endDate;
            }
            set
            {
                endDate = value;
                OnEndDateChanged();
            }
        }
        protected virtual void OnEndDateChanged()
        {
            isModified = true;
        }

        private bool locked = false;

        [System.ComponentModel.DefaultValue(false)]
        public bool Locked
        {
            get { return locked; }
            set
            {
                locked = value;
                OnLockedChanged();
            }
        }

        protected virtual void OnLockedChanged()
        {
        }

        private Color color = Color.White;

        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        private Color textColor = Color.Black;

        public Color TextColor
        {
            get { return textColor; }
            set { textColor = value; }
        }

        private Color borderColor = Color.Blue;

        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
            }
        }

        private string title = "";

        [System.ComponentModel.DefaultValue("")]
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnTitleChanged();
            }
        }
        protected virtual void OnTitleChanged()
        {
            isModified = true;
        }

        internal int conflictCount;
        internal bool allDayEvent;

        public bool Intersects( DVAppointment other ) 
        {
            return this.Intersects(other.startDate) || this.Intersects(other.endDate);
        }
        public bool Intersects(DateTime time)
        {
            if (this.startDate.CompareTo(time)<=0 && this.endDate.CompareTo(time)>=0)
                return true;
            else
                return false;
        }
    }
}
