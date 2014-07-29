using System;
using System.Collections.Generic;
using System.Text;

namespace HPSchedule.Rechnungswesen
{
    public class FeeList : List<Fee>
    {
        public void Add(long insuranceId, double amount)
        {
            Fee newItem = new Fee();
            newItem.InsuranceId = insuranceId;
            newItem.Amount = amount;
            this.Add(newItem);
        }

        public double GetAmount(long insuranceId)
        {
            Fee fee = Find(f => f.InsuranceId == insuranceId);
            return (fee == null) ? 0.0 : fee.Amount;

        }
    }
}
