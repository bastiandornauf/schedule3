using System;
using System.Collections.Generic;
using System.Text;

namespace HPSchedule.Rechnungswesen
{
    public class Treatment
    {
        public long Id { get; set; }
        public long PatientId { get; set; }
        
        public string Diagnosis { get; set; }
        
        public long RoomId { get; set; }
        public long HealerId { get; set; }

        private List<Group> groups = new List<Group>();
        public List<Group> Groups { get { return groups; } }

        private List<Item> items = new List<Item>();
        public List<Item> Items { get { return items; } }

        public List<Item> AllItems()
        {
            List<Item> allItems = new List<Item>();

            foreach (Item i in Items)
                allItems.Add(i);

            foreach (Group g in Groups)
                foreach (Item i in g.Items)
                    allItems.Add(i);

            allItems.Sort();

            return allItems;
        }
    }
}
