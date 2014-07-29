using System;
using System.Collections.Generic;
using System.Text;
using HPSchedule.Datenobjekte;

namespace HPSchedule.Rechnungswesen
{
    public class InvoicePrintDevice
    {
        public Invoice Data { get; set; }
        
        public virtual void Print()
        {
        }

        public virtual void Init(Invoice data)
        {
            Data = data;
        }
    }
}
