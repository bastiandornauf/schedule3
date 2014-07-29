using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HPSchedule.Rechnungswesen
{
    public class Treatments : List<Treatment>
    {
        public void LoadFromDatabase(Accounting a)
        {
            Database db = new Database();
            DataTable dt = new DataTable();
            try
            {
                // Insurance
                db.SetCommand("SELECT * FROM treatedwith NATURAL JOIN treatment ORDER BY treatmentId;");
                dt = db.Table();

                long last = -1;
                Treatment t = new Treatment();
                t.Id = last;
                
                foreach (DataRow row in dt.Rows)
                {
                    if ((long)row["treatmentId"] != last)
                    {
                        if (last != -1)
                        {
                            Add(t);
                            t = new Treatment();
                        }
                        t.PatientId = (long)row["patientId"];
                        t.Diagnosis = (string)row["diagnosis"];
                        t.Id = (long)row["treatmentId"];
                        last = t.Id;
                    }

                    if (row.IsNull("invoiceGroupId"))
                    // Group ist NULL also Item
                    {
                        t.Items.Add(a.ItemById((long)row["invoiceItemId"]));
                    }
                    else
                    {
                        t.Groups.Add(a.GroupById((long)row["invoiceGroupId"]));
                    }
                }
                if (t.Id != -1)
                    Add(t);
            }
            catch (Exception e)
            {
                db.ReportError("Rechnungswese.Treatments->LoadFromDatabase(): " + e.Message);
            }
            finally
            {

                // Datenbank schließen
                db.Close();
            }
        }
    }
}
