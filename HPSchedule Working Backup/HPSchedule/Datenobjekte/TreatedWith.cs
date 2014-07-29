using System;
using System.Collections.Generic;
using System.Text;

namespace HPSchedule.Datenobjekte
{
    public class TreatedWith
    {
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
        
        private long group;

        public long GroupId
        {
            get { return group; }
            set { group = value;
                  isGroup = true;
                }
        }

        public string Label { get; set; }

        private long item;

        public long ItemId
        {
            get { return item; }
            set { 
                item = value;
                isGroup = false;
                }
        }

        public int TariffMain { get; set; }
        public int TariffSub { get; set; }
        public string Description { get; set; }

        private bool isGroup;

        public bool IsGroup
        {
            get { return isGroup; }
        }

        public bool IsItem
        {
            get
            {
                return !isGroup;
            }
        }

        public override string ToString()
        {
            if (IsGroup)
                return String.Format("[{0}]", Label);
            else
                return String.Format("({0}.{1} {2})", TariffMain, TariffSub, Description);
        }
    }
}
