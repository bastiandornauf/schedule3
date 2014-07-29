using System;
using System.Collections.Generic;
using System.Text;

namespace HPSchedule.Rechnungswesen
{
    public class InsuranceList : List<Insurance>
    {
        public void Add(long id, string label)
        {
            Insurance newItem = new Insurance();
            newItem.Id = id;
            newItem.Label = label;

            Add(newItem);
        }

        public string GetLabel(long id)
        {
            return Find(i => i.Id == id).Label;
        }
    }
}
