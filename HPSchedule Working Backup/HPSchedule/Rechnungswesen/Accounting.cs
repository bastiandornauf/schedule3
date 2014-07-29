using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HPSchedule.Rechnungswesen
{
    public class Accounting
    {
        #region data member
        private List<Item> items = new List<Item>();
        public List<Item> Items { get { return items; } }

        private List<Group> groups = new List<Group>();
        public List<Group> Groups { get { return groups; } }

        //private FeeList fees = new FeeList();
        //public FeeList Fees { get { return fees; } }

        private InsuranceList insurances = new InsuranceList();
        public InsuranceList Insurances { get { return insurances; } }

        #endregion

        /// <summary>
        /// Lädt alle Informationen über Gebühren, Artikel und Gruppen aus der Datenbank.
        /// </summary>
        public void LoadFromDatabase()
        {
            Database db = new Database();
            DataTable dt = new DataTable();


            try
            {
                // Insurance
                db.SetCommand("SELECT * FROM insurance;");
                dt = db.Table();

                foreach (DataRow row in dt.Rows)
                {
                    insurances.Add((long)row["id"], (string)row["label"]);
                }


                // Items
                db.SetCommand("select i.id, i.description, i.tariffmain, i.tariffsub, " +
                              "       f.insuranceId, f.fee " +
                              "from invoiceitem as i, fee as f " +
                              "where (f.invoiceItemId = i.Id);");
                dt = db.Table();
                long lastItem = -1;
                Item newItem = new Item();
                foreach (DataRow row in dt.Rows)
                {
                    if (lastItem != (long)row["id"])
                    {
                        if (lastItem != -1)
                        {
                            items.Add(newItem);
                        }
                        newItem = new Item();

                        newItem.Id = (long)row["id"];
                        newItem.TariffMain = (int)row["tariffmain"];
                        newItem.TariffSub = (int)row["tariffsub"];
                        newItem.Description = (string)row["description"];
                        lastItem = newItem.Id;
                    }
                    newItem.Fees.Add((long)row["insuranceId"], (double)row["fee"]);
                }
                items.Add(newItem);

                // Gruppen
                db.SetCommand("select g.id, g.label, i.invoiceItemId from invoicegroup as g, groupitems as i where g.id = i.invoicegroupid order by invoiceGroupId;");
                dt = db.Table();
                lastItem = -1;
                Group newGroup = new Group();
                foreach (DataRow row in dt.Rows)
                {
                    if (lastItem != (long)row["id"])
                    {
                        if (lastItem != -1)
                        {
                            groups.Add(newGroup);
                        }
                        newGroup = new Group();

                        newGroup.Id = (long)row["id"];
                        newGroup.Label = (string)row["label"];

                        lastItem = newGroup.Id;
                    }
                    newGroup.Items.Add(items.Find(i => i.Id == (long)row["invoiceItemId"]));
                }
                groups.Add(newGroup);

            }
            catch (Exception e)
            {
                db.ReportError("Rechnungswese.Accounting->FillFromDatabase(): " + e.Message);
            }
            finally
            {
                // Datenbank schließen
                db.Close();
            }
        }


        public Group GroupById(long groupId)
        {
            return Groups.Find(g => g.Id == groupId);
        }
        public Item ItemById(long itemId)
        {
            return Items.Find(i => i.Id == itemId);
        }
    }
}
