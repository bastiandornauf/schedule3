using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HPSchedule.Rechnungswesen;

namespace HPSchedule
{

    public static class ExtensionMethos
    {
        public static int CountSelected(this List<InvoiceSelector> p)
        {
            int sum = 0;
            foreach (InvoiceSelector s in p)
                if (s.GenerateInvoice)
                    sum++;

            return sum;
        }

        public static string ToLexOrder(this DateTime d)
        {
            return String.Format("{0:0000}-{1:00}-{2:00} {3:00}{4:00}{5:00}{6:0000}",
                d.Year,
                d.Month,
                d.Day,
                d.Hour,
                d.Minute,
                d.Second,
                d.Millisecond);
        }
    }
}
