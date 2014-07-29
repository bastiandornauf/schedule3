using System;
using System.Collections.Generic;
using System.Text;

namespace HPSchedule.Datenobjekte
{
    public class Treatment
    {
        public Treatment()  {
            items = new List<TreatedWith>();
            diagnosis = "";
        }

        private long patientId;

        public long PatientId
        {
            get { return patientId; }
            set { patientId = value; }
        }


        private dbAction databaseAction;

        public dbAction DatabaseAction
        {
            get { return databaseAction; }
            set { databaseAction = value; }
        }

        
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private string diagnosis;

        public string Diagnosis
        {
            get { return diagnosis; }
            set { diagnosis = value; }
        }

        private long healerId;

        public long HealerId
        {
            get { return healerId; }
            set { healerId = value; }
        }

        private long roomId;

        public long RoomId
        {
            get { return roomId; }
            set { roomId = value; }
        }

        private DateTime startDate;

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        private DateTime endDate;

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public List<TreatedWith> items;

        internal bool Contains(Group g)
        {
            foreach (TreatedWith tw in items)
            {
                if (tw.IsGroup && tw.GroupId == g.Id)
                    return true;
            }
            return false;
        }
        internal bool Contains(InvoiceItem i)
        {
            foreach (TreatedWith tw in items)
            {
                if (tw.IsItem && tw.ItemId == i.Id)
                    return true;
            }
            return false;
        }
    }
}
