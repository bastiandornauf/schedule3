using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using HPSchedule.Datenobjekte;
using System.Globalization;


namespace HPSchedule
{
    class DoDatabaseMagic
    {
        #region Appointments and Calendar
        public static void GetAppointments(ref List<Appointment> appointments, DateTime from, DateTime to)
        {
            string whereClause = String.Format("WHERE startDate BETWEEN {0} AND {1}",
                Database.formatDatetimeQuoted(from),
                Database.formatDatetimeQuoted(to)
            );
            GetAppointments(ref appointments, whereClause);
        }

        public static void GetAppointments(ref List<Appointment> appointments)
        {
            GetAppointments(ref appointments, "");
        }

        private static void GetAppointments(ref List<Appointment> appointments, string where)
        {
            appointments.Clear();

            Database db = new Database();
       
            //string cmd = "SELECT a.id, startDate, endDate, a.label, a.treatmentId"+
            //            "colorR, colorG, colorB, "+
            //            "firstname, lastname "+
            //            "FROM appointment AS a "+
            //            "LEFT JOIN treatment AS t ON t.id = a.treatmentid "+
            //            "LEFT JOIN healer AS h ON t.healerid = h.id "+
            //            "LEFT JOIN patient AS p ON t.patientid = p.id ";
            // versuch mit dem View DayView
            string cmd = "SELECT * FROM dayview";
            //db.SetCommand(cmd + " WHERE occured=false " + where.Replace("WHERE", "AND") + ";");
            db.SetCommand(cmd + " " + where + ";");

            try
            {

                db.ExecuteReader();
                if (db.ReaderHasRows)
                {
                    while (db.Read())
                    {
                        // Einen Termin erzeugen und ablegen
                        Appointment a = new Appointment();

                        a.Id = db.GetLong("id");
                        a.StartDate = db.GetDateTime("startDate");
                        a.EndDate = db.GetDateTime("endDate");
                        a.Title = db.GetString("label");
                        a.Occured = db.GetBool("occured");

                        long tId = db.GetLong("treatmentId");
                        if (tId == 0)
                        {
                            a.IsTreatment = false;
                            a.InPlaceEditable = true;
                        }
                        else
                        {
                            a.InPlaceEditable = false;
                            a.IsTreatment = true;
                            a.treatmentId = tId;
                            a.Title = String.Format("{0}, {1}", db.GetString("lastname"), db.GetString("firstname"));
                            if (!db.IsNull("colorR"))
                                a.BorderColor = Color.FromArgb(db.GetInt("colorR"), db.GetInt("colorG"), db.GetInt("colorB"));
                            else
                                a.BorderColor = Color.LightBlue; // DEFAULT
                        }
                        a.IsModified = false;

                        if (a.Occured) // bestätigte Termin hervorherben!
                        {
                            //a.BorderColor = a.BorderColor;
                            a.TextColor = Color.White;
                            a.Color = Color.Gray;
                        }

                        appointments.Add(a);
                    }

                }
            }
            catch (Exception ex)
            {
                db.ReportError("DoDatabaseMagic::GetAppointments:  " + ex.Message);
                throw new ApplicationException("Datenbank-Fehler aufgetreten");
            }
            finally
            {
                db.Close();
            }

        }

        public static string GetNameOfTreatedPatient(long treatmentId)
        {
            string name = "<NA>";
            Database db = new Database();
            db.SetCommand( String.Format("select firstname, lastname from patient join treatment on patient.id = patientid where treatment.id ={0} limit 1;", treatmentId));
            try
            {
                db.ExecuteReader();
                if (db.ReaderHasRows)
                {
                    while (db.Read())
                    {
                        name = String.Format("{0}, {1}",
                            db.GetString("lastname"),
                            db.GetString("firstname") );                        
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Datenbankzugriff " + e.Message);
            }
            finally
            {
                db.Close();
            }
            return name;
        }
        public static Color  GetColorOfTreatingHealer(long treatmentId)
        {
            Color resultColor = Color.LightSteelBlue; //DEFAULT
            
            Database db = new Database(); 
            db.SetCommand( String.Format("SELECT colorR, colorG, colorB FROM healer JOIN treatment ON treatment.healerid = healer.id WHERE treatment.id = {0} LIMIT 1;",
                treatmentId));
            try
            {
                db.ExecuteReader();
                if (db.ReaderHasRows)
                // in jedem Falle schau ich mir nur eine Zeile an
                {
                    db.Read();
                    if (!db.IsNull("colorR"))
                        resultColor = Color.FromArgb(db.GetInt("colorR"), db.GetInt("colorG"), db.GetInt("colorB"));
                }
            }
            catch (Exception e)
            {
                db.ReportError("Getting Color of Healer... " + e.Message);
            }
            finally
            {
                db.Close();
            }
            return resultColor;
        }
        
        public static void UpdateAppointment(Appointment ap)
        {
            //UPDATE tbl_namen SET spalte1 = neuer_wert1 WHERE id = 1;
            Database db = new Database();
            db.SetCommand( String.Format("UPDATE appointment SET startdate={0}, enddate={1}, label={2} WHERE id={3};",
                Database.formatDatetimeQuoted( ap.StartDate ),
                Database.formatDatetimeQuoted( ap.EndDate ),
                Database.QuoteMarks( ap.Title ),
                ap.Id ));
            try
            {
                db.Execute();
            }
            catch (Exception e)
            {
                db.ReportError("Updating Appointments ..." + e.Message);
            }
            finally
            {
                db.Close();
            }

        }
        
        public static void NewAppointment(Appointment ap) 
        {
            if (ap.StartDate == null || ap.EndDate == null)
            {
#if DEBUG
                throw new Exception("DoDatabaseMagic:NewAppointment   Start or Enddate is null");
#else
                return;
#endif
                
            }
            if (ap.StartDate == DateTime.MinValue || ap.EndDate == DateTime.MinValue)
            {
#if DEBUG
                throw new Exception("DoDatabaseMagic:NewAppointment MinValue statt null abgefangen!");
#endif
            }
            Database db = new Database();
            db.SetCommand(String.Format("INSERT INTO appointment (startdate, enddate, label, treatmentid, occured) VALUES ({0}, {1}, {2}, {3}, {4});",
                Database.formatDatetimeQuoted(ap.StartDate),
                Database.formatDatetimeQuoted(ap.EndDate),
                Database.QuoteMarks(ap.Title),
                ap.isTreatment? ap.treatmentId.ToString() : "null",
                "false"));
            try
            {
                db.Execute();
                ap.Id = db.Command.LastInsertedId;
            }
            catch (Exception e)
            {
                db.ReportError("Inserting new Appointment ..." + e.Message);
            }
            finally
            {
                db.Close();
            }
        }

        public static void GetBirthdayPeople(ref List<PatientNameAndId> result)
        {
            Database db = new Database();
            db.SetCommand(String.Format("SELECT lastname, firstname, dateOfBirth, id from patient where month(dateofbirth)={0} and dayofmonth(dateofbirth)={1} ORDER BY dateofbirth;",
                DateTime.Now.Month,
                DateTime.Now.Day));

            string firstname;
            string lastname;
            long id;
            DateTime dayofbirth;

            try
            {
                db.ExecuteReader();
                if (db.ReaderHasRows)
                {
                    while (db.Read())
                    {
                        lastname = db.GetString("lastname");
                        firstname = db.GetString("firstname");
                        dayofbirth = db.GetDateTime("dateofbirth");
                        id = db.GetLong("id");

                        int alter = Helferlein.AllThoseTinyHelper.CalculateAge(dayofbirth);

                        result.Add(new PatientNameAndId(firstname, lastname, "[" + dayofbirth.Year.ToString()+", "+ alter.ToString()+ "]", id));
                    }
                }
            }
            catch (Exception e)
            {
                db.ReportError("Generating Birthdaylist" + e.Message);
            }
            finally
            {
                db.Close();
            }
        }

        internal static void DeleteAppointment(long appointmentId)
        {
            Database db = new Database();
            db.SetCommand(String.Format("DELETE FROM appointment WHERE id={0};",
                 appointmentId));
            try
            {
                db.Execute();
            }
            catch (Exception e)
            {
                db.ReportError("Deleting Appointment ..." + e.Message);
            }
            finally
            {
                db.Close();
            }
        }
        internal static int DeleteNextAppointments(long appointmentId, DateTime date)
        {
            Database db = new Database();
            int result = -1;
            long patientId = db.GetNumeric("appointment JOIN treatment ON treatmentId=treatment.id", "patientId", "appointment.id=" + appointmentId.ToString());


            db.SetCommand(String.Format("DELETE appointment FROM (appointment JOIN treatment ON treatmentId=treatment.id) WHERE patientId={0} AND startdate >= {1};",
                 patientId,
                 Database.formatDatetimeQuoted(date)));
            try
            {
                result = db.ExecuteWithResult();
            }
            catch (Exception e)
            {
                db.ReportError("Deleting next Appointments ..." + e.Message);
            }
            finally
            {
                db.Close();
            }
            return result;
        }

        #endregion

        #region Patient

        internal static PatientNameAndId GetPatient(long patientId)
        {
            Database db = new Database();
            PatientNameAndId patient = null;

            db.SetCommand("SELECT firstname, lastname,title FROM patient WHERE id="+patientId+" LIMIT 1;");
            try
            {
                db.ExecuteReader();
                if (db.ReaderHasRows)
                {
                    if (db.Read())
                    {
                        patient = new PatientNameAndId();
                        patient.Id = patientId;
                        patient.Firstname = db.GetString("firstname");
                        patient.Lastname = db.GetString("lastname");
                        patient.Title = db.GetString("title");
                    }
                }                     
            }
            catch (Exception e)
            {
                throw new Exception("GetPatient " + e.Message);
            }
            finally
            {
                db.Close();
            }
            return patient;
        }

        public static void FindMatchingPatients(string searchString, ref List<PatientNameAndId> resultList) 
        {
            // Zerlege den Namens-Suchstring in alle Möglichen Elemente
            string s = searchString.Trim().Replace(',', ' ');
            string[] stringElements = s.Split(' ');
            s = "";
            if ( stringElements.Length == 2) // wenn genau 2 besondere Abfrage
            {
                //s = String.Format("((firstname LIKE {0} AND lastname LIKE {1}) OR (firstname LIKE {1} AND lastname LIKE {0}))",
                //    Database.QuoteMarks(stringElements[0].Trim() + "%"),
                //    Database.QuoteMarks( stringElements[1].Trim() + "%" )
                //);

                // TODO alternative

                s = String.Format("((CONCAT( firstname, lastname ) LIKE {0}) AND (CONCAT( firstname, lastname) LIKE {1}))",
                    Database.QuoteMarks("%"+stringElements[0].Trim()+"%"),
                     Database.QuoteMarks("%"+stringElements[1].Trim()+"%"));
            } else 
            foreach( string item in stringElements ) {
                if (item.Trim() != "")
                {
                    string t = Database.QuoteMarks("%" + item.Trim() + "%");

                    if (s != "")
                        s += " AND ";
                    //s += "(firstname LIKE " + t + " OR lastname LIKE " + t + ")";
                    s += "(CONCAT( firstname, lastname ) LIKE " + t + ")";
                }
            }
            // wenn kein Parameter übrig, abbrechen
            if (s == "")
                return;
            // sonst alle passenden Patienten raussuchen
            Database db = new Database();
            db.SetCommand(String.Format("SELECT firstname, lastname, id FROM PATIENT WHERE {0} ORDER BY lastname, firstname;",
               s));
            try
            {
                db.ExecuteReader();
                if (db.ReaderHasRows)
                {
                    while (db.Read())
                    {
                        PatientNameAndId item = new PatientNameAndId();
                        
                        item.Firstname = db.GetString( "firstname" );
                        item.Lastname = db.GetString( "lastname" );
                        item.Id = db.GetLong("id");

                        resultList.Add( item );
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Datenbankzugriff " + e.Message);
            }
            finally
            {
                db.Close();
            }
        }

    
        internal static void FillPatientNameAndIdList(ref List<PatientNameAndId> liste)
        {
 	        /*
             * SELECT firstname, lastname, id 
             * FROM patient;
             */
            Database db = new Database();
            db.SetCommand("SELECT firstname, lastname, id FROM patient ;");
            try
            {
                db.ExecuteReader();
                if (db.ReaderHasRows)
                {
                    while (db.Read())
                    {
                        PatientNameAndId item = new PatientNameAndId();
                        
                        item.Firstname = db.GetString( "firstname" );
                        item.Lastname = db.GetString( "lastname" );
                        item.Id = db.GetLong("id");

                        liste.Add( item );
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Datenbankzugriff " + e.Message);
            }
            finally
            {
                db.Close();
            }       
        }


        internal static Patient LadePatient(long pid)
        {
            Patient p = new Patient();            
            Database db = new Database();


            db.SetCommand(String.Format("SELECT * FROM patient WHERE id = {0};", pid));
            try
            {
                db.ExecuteReader();
                if (db.ReaderHasRows)
                {
                    while (db.Read())
                    {
                        p.Id = db.GetLong("id");
                        p.DateOfBirth = db.GetDateTime("dateOfBirth");
                        p.DateOfDeath = db.GetDateTime("dateOfDeath", DateTime.MinValue);
                        p.IsDead = !(p.DateOfDeath == DateTime.MinValue);
                        p.Comments = db.GetString("comments");
                        p.Male = db.GetBool("male");

                        p.Name.Title = db.GetString("title");
                        p.Name.Firstname = db.GetString("firstName");
                        p.Name.Lastname = db.GetString("lastName");
                        p.Occupation = db.GetString("occupation");
                        p.PublicComments = db.GetString("publicComments");
                        p.InsuranceId = db.GetLong("InsuranceId");
                        p.MethodOfPayment = db.GetInt("methodOfPayment");
                        p.HealerId = db.GetLong("healerId");

                        // evtl. hier schon die Id's auflösen??                        
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Patient wurde aus DB geholt: " + e.Message);
            }
            finally
            {
                db.Close();
            }

            LadeKontakteUndAdressen(ref p, pid);

            return p;

        }

        private static void LadeKontakteUndAdressen(ref Patient p, long pid)
        {
            // ---------------- KONTAKTE
            Database db = new Database();
            db.SetCommand(String.Format("SELECT * FROM contacts WHERE patientId = {0} ;", pid));
            try
            {
                db.ExecuteReader();
                if (db.ReaderHasRows)
                {
                    while (db.Read())
                    {
                        Contact c = new Contact();
                        
                        c.Id = db.GetLong("id");
                        c.Label = db.GetString("label", "Kontakt");
                        c.ContactInfo = db.GetString("contactInfo");

                        p.Contacts.Add(c);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Datenbankzugriff " + e.Message);
            }
            finally
            {
                db.Close();
            }
            // ------------ ADRESSEN --------------
            db.SetCommand(String.Format("SELECT * FROM address WHERE patientId = {0} ;", pid));
            try
            {
                db.ExecuteReader();
                if (db.ReaderHasRows)
                {
                    while (db.Read())
                    {
                        Address a = new Address();

                        a.Id = db.GetLong("id");
                        a.Street = db.GetString("street");
                        a.AdditionalInfo = db.GetString("additionalInfo");
                        a.PostCode = db.GetString("postcode");
                        a.Place = db.GetString("place");
                        a.Country = db.GetString("country");
                        a.UseForInvoice =  db.GetBool("useforinvoice", false);

                        p.Addresses.Add( a );
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Datenbankzugriff " + e.Message);
            }
            finally
            {
                db.Close();
            }

            // Teste ob ein UseForInvoice existiert, sonst setze ersten Eintrag
            bool  foundADefaultValue = false;
            foreach (Address node in p.Addresses)
                foundADefaultValue |= node.UseForInvoice;

            if (p.Addresses.Count > 0 && !foundADefaultValue)
                p.Addresses[0].UseForInvoice = true;
        }

        internal static void UpdatePatient(Patient p)
        {
            Database db = new Database();
            string set = string.Format("{0}={1}, {2}={3}, {4}={5}, {6}={7}, {8}={9}, {10}={11}, {12}={13}, {14}={15}, {16}={17}, {18}={19}, {20}={21}, {22}={23}",
                            "dateOfBirth", Database.formatDatetimeQuoted( p.DateOfBirth ),
                            "dateOfDeath", p.IsDead?Database.formatDatetimeQuoted( p.DateOfDeath ):"null",
                            "comments", Database.QuoteMarks( p.Comments ),
                            "male", p.Male?"true":"false",
                            "title", Database.QuoteMarks( p.Name.Title ),
                            "firstName", Database.QuoteMarks( p.Name.Firstname ),
                            "lastName", Database.QuoteMarks( p.Name.Lastname ),
                            "occupation", Database.QuoteMarks( p.Occupation ),
                            "InsuranceId", p.InsuranceId,
                            "methodOfPayment", p.MethodOfPayment, 
                            "publicComments", Database.QuoteMarks( p.PublicComments ),
                            "healerId", p.HealerId
            );
            db.SetCommand(String.Format("UPDATE patient SET {0} WHERE id={1};",
                set,
                p.Id));
            try
            {
                db.Execute();
            }
            catch (Exception e)
            {
                db.ReportError("Updating Patient ..." + e.Message);
            }
            finally
            {
                db.Close();
            }

            foreach (Address a in p.Addresses)
            {
                if (a.toBeDeleted)
                    DeleteAddress(a.Id);
                else
                    SaveAddress(a, p.Id, false);
            }

            foreach (Contact c in p.Contacts) 
            {
                if (c.toBeDeleted)
                    DeleteContact(c.Id);
                else
                    SaveContact(c, p.Id, false);
            }
        }

        private static void DeleteContact(long p)
        {
            Database db = new Database();
            db.DeleteFromTable("contacts", p);
        }

        private static void DeleteAddress(long p)
        {
            Database db = new Database();
            db.DeleteFromTable("address", p);
        }

        internal static void CreateNewPatient(Patient p)
        {
            Database db = new Database();
            string set = string.Format("({0}, {2}, {4}, {6}, {8}, {10}, {12}, {14}, {16}, {18}, {20}, {22}) VALUES ({1}, {3}, {5}, {7}, {9}, {11}, {13}, {15}, {17}, {19}, {21}, {23})",
                            "dateOfBirth", Database.formatDatetimeQuoted(p.DateOfBirth),
                            "dateOfDeath", p.IsDead ? Database.formatDatetimeQuoted(p.DateOfDeath) : "null",
                            "comments", Database.QuoteMarks(p.Comments),
                            "male", p.Male ? "true" : "false",
                            "title", Database.QuoteMarks(p.Name.Title),
                            "firstName", Database.QuoteMarks(p.Name.Firstname),
                            "lastName", Database.QuoteMarks(p.Name.Lastname),
                            "occupation", Database.QuoteMarks(p.Occupation),
                            "InsuranceId", p.InsuranceId,
                            "methodOfPayment", p.MethodOfPayment,
                            "publicComments", Database.QuoteMarks(p.PublicComments),
                            "healerId", p.HealerId
            );
            db.SetCommand(String.Format("INSERT INTO patient {0};",
                set));
            try
            {
                db.Execute();
                p.Id = db.Command.LastInsertedId;
            }
            catch (Exception e)
            {
                db.ReportError("Updating Patient ..." + e.Message);
            }
            finally
            {
                db.Close();
            }

            foreach (Address a in p.Addresses)
                SaveAddress(a, p.Id, true);

            foreach (Contact c in p.Contacts)
                SaveContact(c, p.Id, true);
        }
        internal static void SaveContact(Contact c, long patientId, bool skipTestAndSave)
        {
            Database db = new Database();
            // Default-Handlung: neu anlegen
            string insertCmd = String.Format("INSERT INTO contacts (label, contactInfo, patientId) VALUES ({0}, {1}, {2});",
                Database.QuoteMarks(c.Label),
                Database.QuoteMarks(c.ContactInfo),
                patientId);
            db.SetCommand(insertCmd);

            if (!skipTestAndSave)
            {
                // sieh nach ob existiert
                int found = db.Count("contacts", String.Format("id={0}", c.Id));
                if (found > 0)
                {
                    // dann änder
                    db.SetCommand(String.Format("UPDATE contacts SET label={0}, contactInfo={1}, patientId={2} WHERE id={3};",
                        Database.QuoteMarks(c.Label),
                        Database.QuoteMarks(c.ContactInfo),
                        patientId,
                        c.Id));
                }
                else 
                    db.SetCommand(insertCmd);

            }
            try
            {
                db.Execute();
            }
            catch (Exception e)
            {
                db.ReportError("Saving Contacts ..." + e.Message);
            }
            finally
            {
                db.Close();
            }
        }
        internal static void SaveAddress(Address a, long patientId, bool skipTestAndSave)
        {
            Database db = new Database();
            // Default-Handlung: neu anlegen
            string insertCmd = String.Format("INSERT INTO address (street, additionalInfo, postcode, place, country, useforinvoice, patientId) VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6});",
                Database.QuoteMarks(a.Street),
                Database.QuoteMarks(a.AdditionalInfo),
                Database.QuoteMarks(a.PostCode),
                Database.QuoteMarks(a.Place),
                Database.QuoteMarks(a.Country),
                a.UseForInvoice ? "true" : "false",
                patientId);
            
            db.SetCommand(insertCmd);
            if (!skipTestAndSave)
            {
                // sieh nach ob existiert            
                int found = db.Count("address", String.Format("id={0}", a.Id));
                if (found > 0)
                {
                    // dann änder
                    db.SetCommand(String.Format("UPDATE address SET street={0}, additionalInfo={1}, postcode={2}, place={3}, country={4}, useforinvoice={5}, patientId={6} WHERE id={7};",
                        Database.QuoteMarks(a.Street),
                        Database.QuoteMarks(a.AdditionalInfo),
                        Database.QuoteMarks(a.PostCode),
                        Database.QuoteMarks(a.Place),
                        Database.QuoteMarks(a.Country),
                        a.UseForInvoice ? "true" : "false",
                        patientId,
                        a.Id));
                }
                else
                    db.SetCommand(insertCmd);
            }
            try
            {
                db.Execute();
            }
            catch (Exception e)
            {
                db.ReportError("Saving Addresses  ..." + e.Message);
            }
            finally
            {
                db.Close();
            }
        }

        internal static long GetPatientIdFromAppointment(long p)
        {
            Database db = new Database();
            return db.GetNumeric("appointment JOIN treatment ON appointment.treatmentid=treatment.id",
                          "patientId",
                          "appointment.id="+p.ToString() );
        }

        internal static object[] GetListOfAdditionalPatientInfos(long patientId)
        {
            Database db = new Database();            
            object[] resultList = new object[5];
            
            
            //firstTreatment
            db.SetCommand("SELECT startdate FROM appointment JOIN treatment ON appointment.treatmentId=treatment.id where treatment.patientId = "+patientId.ToString()+" ORDER BY startdate LIMIT 1;");
            try { 
                db.ExecuteReader();
                if( db.ReaderHasRows && db.Read() )
                    resultList[0] = db.GetDateTime("startdate");
            } catch( Exception e) {
                db.ReportError( "GetListOfAdditionalPatientInfos[0]: "+e.Message );
            } finally {
                db.Close();
            }
                            
            //latestTreatment
            db.SetCommand("SELECT startdate FROM appointment JOIN treatment ON appointment.treatmentId=treatment.id where treatment.patientId = "+patientId.ToString()+" ORDER BY startdate DESC LIMIT 1;");
            try { 
                db.ExecuteReader();
                if( db.ReaderHasRows && db.Read() )
                    resultList[1] = db.GetDateTime("startdate");
            } catch( Exception e) {
                db.ReportError( "GetListOfAdditionalPatientInfos[1]: "+e.Message );
            } finally {
                db.Close();
            }

            //openTreatmentCount
            db.SetCommand("SELECT COUNT(*) FROM appointment JOIN treatment ON appointment.treatmentId=treatment.id WHERE treatment.patientId = " + patientId.ToString() + " AND invoiceId IS NULL;");
            try { 
                db.ExecuteReader();
                if( db.ReaderHasRows && db.Read() )
                    resultList[2] = db.GetInt("COUNT(*)");
            } catch( Exception e) {
                db.ReportError( "GetListOfAdditionalPatientInfos[2]: "+e.Message );
            } finally {
                db.Close();
            }

            //totalTreatmentCount
            db.SetCommand("SELECT COUNT(*) FROM appointment JOIN treatment ON appointment.treatmentId=treatment.id WHERE treatment.patientId = " + patientId.ToString() + " AND invoiceId IS NULL;");
            try
            { 
                db.ExecuteReader();
                if( db.ReaderHasRows && db.Read() )
                    resultList[3] = db.GetInt("COUNT(*)");
            } catch( Exception e) {
                db.ReportError( "GetListOfAdditionalPatientInfos[3]: "+e.Message );
            } finally {
                db.Close();
            }
            
            //behandler
            List<string> behandler = new List<string>() ;
            List<int> treatmentCount = new List<int>() ;
            int count = 0;

            db.SetCommand("SELECT name, COUNT(name) AS treatmentCount FROM appointment join treatment on appointment.treatmentid=treatment.id JOIN healer ON healerId=healer.id WHERE patientId = " + patientId.ToString() + "  GROUP BY name ORDER BY treatmentCount DESC;");
            try { 
                db.ExecuteReader();
                if( db.ReaderHasRows )
                    while (db.Read())
                    {
                        behandler.Add(db.GetString("name"));                        
                        int tc = db.GetInt("treatmentCount");
                        treatmentCount.Add(tc);
                        count += tc;
                    }
            } catch( Exception e) {
                db.ReportError( "GetListOfAdditionalPatientInfos[4]: "+e.Message );
            } finally {
                db.Close();
            }
            string behandlerResult = "";
            if (behandler.Count > 1)
            {
                for (int iter = 0; iter < behandler.Count; iter++)
                {
                    if (behandlerResult != String.Empty)
                        behandlerResult += ", ";

                    behandlerResult += String.Format("{0} ({1:0%})", behandler[iter], (double)treatmentCount[iter] / (double)count);
                }
            }
            else if (behandler.Count == 1)
            {
                behandlerResult = behandler[0];
            }
            else
            {
                behandlerResult = "noch keine Behandlungen";
            }

            resultList[4] = behandlerResult ;

            return resultList;
        }
        

        #endregion

        #region Accounting
        #region loading
        internal static void LoadAccountingFromDB(Accounting accounting)
        {
            Database db = new Database();

            GetInsurancesFromDB(db, accounting.Insurances);
            GetGroupsFromDB(db, accounting.Groups);
            GetItemsFromDB(db, accounting.Items);
            return;
        }


        private static void GetItemsFromDB(Database db, List<InvoiceItem> list)
        {
            db.SetCommand("SELECT i.id, tariffMain, tariffSub, description, f.id as feeId, insuranceId, fee FROM invoiceitem AS i LEFT JOIN fee AS f ON i.id = f.invoiceitemid;");
            long lastId = -1;
            InvoiceItem i = null;
            try
            {
                db.ExecuteReader();

                if (db.ReaderHasRows)
                {
                    while (db.Read())
                    {
                        if( db.GetLong("id") == lastId ) {
                            Fee f = new Fee();
                            f.Id = db.GetLong("feeId");
                            f.Insurance = db.GetLong("insuranceId");
                            f.Amount = db.GetDouble("fee");
                            i.Fees.Add(f);
                        }
                        else
                        {
                            if( i == null ) {
                                i = new InvoiceItem();
                            }
                            else {
                                list.Add(i);
                                i = new InvoiceItem();
                            }
                            i.Id = db.GetLong("id");
                            i.Description = db.GetString("description");
                            i.Number.Main = db.GetInt("tariffMain");
                            i.Number.Sub = db.GetInt("tariffSub");

                            Fee f = new Fee();
                            f.Id = db.GetLong("feeId");
                            f.Insurance = db.GetLong("insuranceId");
                            f.Amount = db.GetDouble("fee");
                            i.Fees.Add(f);
                        }
                        lastId = db.GetLong("id");
                    }
                    if (i != null)
                        list.Add(i);
                }
            }
            catch (Exception e)
            {
                db.ReportError("Get Items ... " + e.Message);
            }
            finally
            {
                db.Close();
            }
        }

        private static void GetGroupsFromDB(Database db, List<Group> list)
        {
            db.SetCommand("select g.id, g.label, i.invoiceitemid from invoicegroup as g left join groupitems as i on i.invoicegroupid = g.id;");
            Group g = null;
            long lastId=-1;
            try
            {
                db.ExecuteReader();
                if (db.ReaderHasRows)
                {
                    while (db.Read())
                    {
                        if (db.GetLong("id") == lastId)
                        {
                            g.InvoiceItems.Add(db.GetLong("invoiceItemId"));
                        }
                        else
                        {
                            if (g == null)
                            {
                                g = new Group();
                            }
                            else
                            {
                                list.Add(g);
                                g = new Group();
                            }
                            g.Id = db.GetLong("id");
                            g.Label = db.GetString("label");
                            if(! db.IsNull("invoiceItemId"))
                                g.InvoiceItems.Add(db.GetLong("invoiceItemId"));

                        }
                        lastId = db.GetLong("id");
                    }
                    if (g != null)
                        list.Add(g);
                }
            }
            catch (Exception e)
            {
                db.ReportError("Getting Groups ... " + e.Message);
            }
            finally
            {
                db.Close();
            }
        }

        private static void GetInsurancesFromDB(Database db, List<Insurance> list)
        {
            db.SetCommand("SELECT id, label FROM insurance;");
            Insurance insurance;

            try
            {
                db.ExecuteReader();
                if (db.ReaderHasRows)
                {
                    while (db.Read())
                    {
                        insurance = new Insurance();
                        insurance.Label = db.GetString("label");
                        insurance.Id = db.GetLong("id");

                        list.Add(insurance);
                    }
                }
            }
            catch (Exception e)
            {
                db.ReportError("Getting Insurances ... " + e.Message);
            }
            finally
            {
                db.Close();
            }
        }
        #endregion 

        #region saving
        internal static void SaveAccountingToDB(Accounting accounting)
        {
            if (accounting.DatabaseAction == dbAction.none)
                return;

            foreach (Insurance insurance in accounting.Insurances)
            {
                switch (insurance.DatabaseAction)
                {
                    case dbAction.created:
                        CreateInsurance(insurance);
                        break;
                    case dbAction.modified:
                        AlterInsurance(insurance);
                        break;
                    case dbAction.delete:
                        DeleteInsurance(insurance);
                        break;
                    case dbAction.none:
                        break;
                }
                insurance.DatabaseAction = dbAction.none;
            }

            foreach (InvoiceItem item in accounting.Items)
            {
                switch (item.DatabaseAction)
                {
                    case dbAction.created:
                        CreateInvoiceItem(item);
                        break;
                    case dbAction.modified:
                        AlterInvoiceItem(item);
                        break;
                    case dbAction.delete:
                        DeleteInvoiceItem(item);
                        break;
                    case dbAction.none:
                        break;
                }
                item.DatabaseAction = dbAction.none;
            }

            foreach (Group group in accounting.Groups)
            {
                switch (group.DatabaseAction)
                {
                    case dbAction.created:
                        CreateGroup(group);
                        break;
                    case dbAction.modified:
                        AlterGroup(group);
                        break;
                    case dbAction.delete:
                        DeleteGroup(group);
                        break;
                    case dbAction.none:
                        break;
                }
                group.DatabaseAction = dbAction.none;
            }
            
            accounting.DatabaseAction = dbAction.none;
        }
        
        #region insurance related methods

        private static void DeleteInsurance(Insurance insurance)
        {
            Database db = new Database();
            db.SetCommand("DELETE FROM insurance WHERE id="+insurance.Id+";");
            try
            {
                db.Execute();
            }
            catch (Exception e)
            {
                db.ReportError("DeleteInsurance: " + e.Message);
            }
            finally
            {
                db.Close();
            }

            db = new Database();
            db.SetCommand("DELETE FROM fee WHERE insuranceId="+insurance.Id+";");
            try
            {
                db.Execute();
            }
            catch (Exception e)
            {
                db.ReportError("DeleteInsurance/Fee: " + e.Message);
            }
            finally
            {
                db.Close();
            }
        }

        private static void AlterInsurance(Insurance insurance)
        {
            Database db = new Database();

            db.SetCommand( "UPDATE insurance SET label="+Database.QuoteMarks(insurance.Label)+"WHERE id="+insurance.Id.ToString()+";" );
            try
            {
                db.Execute();
            }
            catch (Exception e)
            {
                db.ReportError("AlterInsurance: " + e.Message);
            }
            finally
            {
                db.Close();
            }
        }
        
        private static void CreateInsurance(Insurance insurance)
        {
            Database db = new Database();
            string query = String.Format("INSERT INTO insurance (label) values ({0});", Database.QuoteMarks(insurance.Label));
            db.SetCommand(query);
            try
            {
                db.Execute();
            }
            catch (Exception e)
            {
                db.ReportError("CreateInsurance: " + e.Message);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion

        #region InvoiceItems related methods

        private static void DeleteInvoiceItem(InvoiceItem item)
        {
            Database db = new Database();
            db.SetCommand("DELETE FROM invoiceItem WHERE id=" + item.Id + ";");
            try
            {
                db.Execute();
            }
            catch (Exception e)
            {
                db.ReportError("DeleteInvoiceItem: " + e.Message);
            }
            finally
            {
                db.Close();
            }
            
            
            db = new Database();
            db.SetCommand("DELETE FROM fee WHERE invoiceItemId=" + item.Id + ";");
            try
            {
                db.Execute();
            }
            catch (Exception e)
            {
                db.ReportError("DeleteInvoiceItem/Fee: " + e.Message);
            }
            finally
            {
                db.Close();
            }

            db = new Database();
            db.SetCommand("DELETE FROM groupitems WHERE invoiceItemId=" + item.Id + ";");
            try
            {
                db.Execute();
            }
            catch (Exception e)
            {
                db.ReportError("DeleteInvoiceItem/Groupitem: " + e.Message);
            }
            finally
            {
                db.Close();
            }

        }

        private static void AlterInvoiceItem(InvoiceItem item)
        {
            Database db = new Database();
            string query = String.Format("UPDATE invoiceItem SET description={0}, tariffMain={1}, tariffSub={2} WHERE id={3};",
                Database.QuoteMarks(item.Description),
                item.Number.Main,
                item.Number.Sub,
                item.Id
            );
            db.SetCommand(query);
            try
            {
                db.Execute();
            }
            catch (Exception e)
            {
                db.ReportError("AlterInvoiceItem: " + e.Message);
            }
            finally
            {
                db.Close();
            }
            SaveFees(item);

        }
        
        private static void CreateInvoiceItem(InvoiceItem item)
        {
            Database db = new Database();
            string query = String.Format("INSERT INTO invoiceItem (description, tariffMain, tariffSub) values ({0},{1},{2});",
                Database.QuoteMarks(item.Description),
                item.Number.Main,
                item.Number.Sub
            ); 
            
            db.SetCommand(query);
            try
            {
                db.Execute();
                item.Id = db.Command.LastInsertedId;
            }
            catch (Exception e)
            {
                db.ReportError("CreateInvoiceItem: " + e.Message);
            }
            finally
            {
                db.Close();
            }
           SaveFees( item);
       }

        #endregion

        #region fee related methods
        private static void SaveFees(InvoiceItem item)
        {
           foreach (Fee f in item.Fees)
           {
               if (f != null)
               {
                   switch (f.DatabaseAction)
                   {
                       case dbAction.created:
                           CreateFee(f, item.Id);
                           break;
                       case dbAction.modified:
                           AlterFee(f, item.Id);
                           break;
                       case dbAction.delete:
                           DeleteFee(f);
                           break;
                       case dbAction.none:
                           break;
                   }
                   f.DatabaseAction = dbAction.none;
               }

           }

        }
        private static void DeleteFee(Fee f)
        {
           Database db = new Database();
           db.SetCommand("DELETE FROM fee WHERE id=" + f.Id + ";");
           try
           {
               db.Execute();
           }
           catch (Exception e)
           {
               db.ReportError("DeleteFee: " + e.Message);
           }
           finally
           {
               db.Close();
           }
        }

        private static void AlterFee(Fee f, long itemId)
        {
           Database db = new Database();
           string query = String.Format("UPDATE fee SET invoiceItemId={0}, insuranceId={1}, fee={2} WHERE id={3};",
               itemId,
               f.Insurance,
               Database.QuoteMarks(f.Amount.ToString(CultureInfo.InvariantCulture.NumberFormat)),
               f.Id
           );
           db.SetCommand(query);
           try
           {
               db.Execute();
           }
           catch (Exception e)
           {
               db.ReportError("AlterFee: " + e.Message);
           }
           finally
           {
               db.Close();
           }
        }

        private static void CreateFee(Fee f, long itemId)
        {
           Database db = new Database();
           
           string query = String.Format("INSERT INTO fee (invoiceItemId, insuranceId, fee) VALUES ({0}, {1}, {2});",
               itemId,
               f.Insurance,
               Database.QuoteMarks(f.Amount.ToString(CultureInfo.InvariantCulture.NumberFormat))
               );
           db.SetCommand(query);
           try
           {
               db.Execute();
               f.Id = db.Command.LastInsertedId;
           }
           catch (Exception e)
           {
               db.ReportError("CreateFee: " + e.Message);
           }
           finally
           {
               db.Close();
           }
        }
        #endregion

        #region group related methods
        private static void DeleteGroup(Group group)
        {
            Database db = new Database();
            db.SetCommand("DELETE FROM invoicegroup WHERE id=" + group.Id + ";");
            try
            {
                db.Execute();
            }
            catch (Exception e)
            {
                db.ReportError("DeleteGroup: " + e.Message);
            }
            finally
            {
                db.Close();
            }
            DeleteAllGroupItems(group);        
        }

        private static void AlterGroup(Group group)
        {
            Database db = new Database();
            db.SetCommand("UPDATE invoicegroup SET label="+Database.QuoteMarks(group.Label)+"WHERE id=" + group.Id + ";");
            try
            {
                db.Execute();
            }
            catch (Exception e)
            {
                db.ReportError("DeleteInsurance: " + e.Message);
            }
            finally
            {
                db.Close();
            }

            DeleteAllGroupItems(group);
            SaveAllGroupItems(group);

        }

        private static void SaveAllGroupItems(Group group)
        {
            foreach (long itemId in group.InvoiceItems)
            {
                SaveSingleGroupItem(group.Id, itemId);
            }
        }

        private static void SaveSingleGroupItem(long groupId,long itemId)
        { 	
            Database db = new Database();
            db.SetCommand(String.Format("INSERT INTO groupItems (invoiceGroupId, invoiceItemId) VALUES ({0}, {1});",
                groupId,
                itemId
            ));
            try
            {
                db.Execute();
            }
            catch (Exception e)
            {
                db.ReportError("SaveSingleGroupItem: " + e.Message);
            }
            finally
            {
                db.Close();
            }
        }

        private static void DeleteAllGroupItems(Group group)
        {
            Database db = new Database();
            db.SetCommand("DELETE FROM groupitems WHERE invoiceGroupId=" + group.Id + ";");
            try
            {
                db.Execute();
            }
            catch (Exception e)
            {
                db.ReportError("DeleteAllGroupItems: " + e.Message);
            }
            finally
            {
                db.Close();
            }
        }

        private static void CreateGroup(Group group)
        {
            Database db = new Database();
            db.SetCommand("INSERT INTO invoicegroup (label) VALUES (" + Database.QuoteMarks(group.Label) +");");
            try
            {
                db.Execute();
                group.Id = db.Command.LastInsertedId;
            }
            catch (Exception e)
            {
                db.ReportError("CreateGroup: " + e.Message);
            }
            finally
            {
                db.Close();
            }

            DeleteAllGroupItems(group);
            SaveAllGroupItems(group);
        }


        #endregion

        #endregion

        #endregion




        internal static void LoadRoomToList(ref List<Room> room)
        {
            Database db = new Database();
            db.SetCommand("SELECT id,label FROM room;");
            room.Clear();

            try
            {
                db.ExecuteReader();

                if (db.ReaderHasRows)
                {
                    while (db.Read())
                    {
                        Room r = new Room();

                        r.Label = db.GetString("label");
                        r.Id = db.GetLong("id");
                        r.DatabaseAction = dbAction.none;

                        room.Add( r );
                    }
                }
            }
            catch (Exception e)
            {
                db.ReportError("LoadRoomToList" + e.Message);
            }
            finally
            {
                db.Close();
            }
        }

        internal static void LoadLastTreatments(ref List<Treatment> treatments, long patientId)
        {
            LoadLastTreatments(ref treatments, patientId, 5); 
        }

        internal static void LoadLastTreatments(ref List<Treatment> treatments, long patientId, int limit)
        {
            string query = String.Format("SELECT * FROM appointment JOIN treatment ON appointment.treatmentid = treatment.id WHERE treatment.patientid={0} ORDER BY startDate DESC LIMIT {1};",
                patientId,
                limit //Limit treatments
            );

            treatments.Clear();
            Database db = new Database();
            db.SetCommand(query);

            try
            {
                db.ExecuteReader();

                if (db.ReaderHasRows)
                {
                    while (db.Read())
                    {
                        Treatment t = new Treatment();

                        t.Id = db.GetLong("treatmentId");
                        t.Diagnosis = db.GetString("diagnosis");
                        t.HealerId = db.GetLong("healerId");
                        t.RoomId = db.GetLong("roomId");

                        t.StartDate = db.GetDateTime("startDate");
                        t.EndDate = db.GetDateTime("endDate");

                        t.DatabaseAction = dbAction.none;

                        GetTreatedWithItems(ref t.items, t.Id);

                        treatments.Add(t);
                    }
                }

            }
            catch (Exception e)
            {
                db.ReportError("LoadLastTreatments: " + e.Message);
            }
            finally
            {
                db.Close();
            }
        }

        private static void GetTreatedWithItems(ref List<TreatedWith> list, long treatmentId)
        {
            
            string query = String.Format(
                    @"SELECT tw.id,  tw.invoiceGroupId, tw.invoiceItemId,
                             g.label,
                             i.tariffMain, i.tariffSub, i.description 

                      FROM treatedwith AS tw, 
                           invoiceGroup AS g,
                           invoiceItem AS i

                      WHERE (tw.invoiceGroupId = g.id OR
                             tw.invoiceItemId = i.id)
                            AND tw.treatmentid={0}
                      GROUP BY id;", treatmentId );

            list.Clear();
            Database db = new Database();
            db.SetCommand(query);

            try
            {
                db.ExecuteReader();

                if (db.ReaderHasRows)
                {
                    while (db.Read())
                    {
                        TreatedWith t = new TreatedWith();

                        t.Id = db.GetLong("id");
                        if (db.IsNull("invoiceGroupId"))
                        {
                            t.ItemId = db.GetLong("invoiceItemId");
                            t.TariffMain = db.GetInt("tariffMain");
                            t.TariffSub = db.GetInt("tariffSub");
                            t.Description = db.GetString("description");
                        }
                        else
                        {
                            t.GroupId = db.GetLong("invoiceGroupId");
                            t.Label = db.GetString("label");

                        }
                        t.DatabaseAction = dbAction.none;

                        list.Add(t);
                    }
                }

            }
            catch (Exception e)
            {
                db.ReportError("LoadLastTreatments: " + e.Message);
            }
            finally
            {
                db.Close();
            }
        }

        internal static void NewTreatment(Appointment a, Treatment t)
        {
            if( t.DatabaseAction == dbAction.created ) {
                CreateNewTreatment(t);
                a.treatmentId = t.Id;
            } else {
                a.treatmentId = t.Id;
            }
            NewAppointment(a);
        }

        private static void CreateNewTreatment( Treatment t)
        {
            Database db = new Database();

            string query = String.Format("INSERT INTO treatment (patientId, diagnosis, healerId, roomId) VALUES ({0},{1},{2},{3});",
                t.PatientId.ToString(),
                Database.QuoteMarks(t.Diagnosis),
                t.HealerId.ToString(),
                t.RoomId.ToString()
            );
            db.SetCommand(query);
            try
            {
                db.Execute();
                t.Id = db.Command.LastInsertedId;
            }
            catch (Exception e)
            {
                db.ReportError("NewTreatment: " + e.Message);
            }
            finally
            {
                db.Close();
            }
            SetTreatedWithRelations(t);

            t.DatabaseAction = dbAction.none;
        }

        private static void SetTreatedWithRelations(Treatment t)
        {
            Database db = new Database();

            foreach (TreatedWith tw in t.items)
            {
                string query = String.Format("INSERT INTO treatedWith (invoiceItemId, invoiceGroupId, treatmentId) VALUES ({0}, {1}, {2});",
                    tw.IsItem ? tw.ItemId.ToString() : "null",
                    tw.IsGroup ? tw.GroupId.ToString() : "null",
                    t.Id );

                db.SetCommand(query);

                try { db.Execute(); }
                catch (Exception e) { db.ReportError("SetTreatedWithRelations: " + e.Message); }
                finally { db.Close(); }

                tw.DatabaseAction = dbAction.none;
            }
        }

        internal static Treatment GetTreatment(long appointmentId)
        {
            Treatment result = null;
            
            string query = String.Format("SELECT * FROM appointment JOIN treatment ON appointment.treatmentid = treatment.id WHERE appointment.Id={0} LIMIT 1;",
                appointmentId.ToString()
            );
            Database db = new Database();
            db.SetCommand(query);

            try
            {
                db.ExecuteReader();

                if (db.ReaderHasRows)
                {
                    if (db.Read())
                    {
                        result = new Treatment();

                        result.Id = db.GetLong("treatmentId");
                        result.Diagnosis = db.GetString("diagnosis");
                        result.HealerId = db.GetLong("healerId");
                        result.RoomId = db.GetLong("roomId");

                        result.PatientId = db.GetLong("patientId");

                        result.StartDate = db.GetDateTime("startDate");
                        result.EndDate = db.GetDateTime("endDate");

                        result.DatabaseAction = dbAction.none;

                        GetTreatedWithItems(ref result.items, result.Id);

                    }
                }

            }
            catch (Exception e)
            {
                db.ReportError("GetTreatment: " + e.Message);
            }
            finally
            {
                db.Close();
            }
            return result;

        }

        internal static void AlterTreatment(Appointment a, Treatment t)
        {
            if( t.DatabaseAction == dbAction.created ) {
                CreateNewTreatment(t);
            }

            Database db = new Database();
            string query = String.Format("UPDATE appointment SET treatmentId={0} WHERE id={1};",
                t.Id.ToString(),
                a.Id.ToString()
            );
            db.SetCommand(query);

            try { db.Execute(); }
            catch (Exception e) { db.ReportError("AlterTreatment: " + e.Message); }
            finally { db.Close(); }        
        }

        


        #region Healer
        internal static void SaveHealer(Healer h)
        {
            switch( h.DatabaseAction ) 
            {
                case dbAction.created:
                    CreateHealer(h);
                    break;

                case dbAction.modified:
                    AlterHealter(h);
                    break;

                case dbAction.delete:
                    DeleteHealer(h);
                    break;

                case dbAction.none:
                default:
                    break;
            }
            h.DatabaseAction = dbAction.none;
        }

        private static void DeleteHealer(Healer h)
        {
            Database db = new Database();
            string query = String.Format("DELETE FROM healer WHERE id={0};", h.Id.ToString());
            db.SetCommand(query);

            try
            {
                db.Execute();
            }
            catch (Exception e)
            {
                db.ReportError("SaveHealer/Delete: " + e.Message);
            }
            finally
            {
                db.Close();
            }
        }

        private static void AlterHealter(Healer h)
        {
            Database db = new Database();
            string query = String.Format("UPDATE healer SET name={0}, colorR={1}, colorG={2}, colorB={3} WHERE id={4};",
                Database.QuoteMarks( h.Name ),
                h.Color.R,
                h.Color.G,
                h.Color.B,
                h.Id );
            db.SetCommand(query);

            try
            {
                db.Execute();
            }
            catch (Exception e)
            {
                db.ReportError("SaveHealer/Alter: " + e.Message);
            }
            finally
            {
                db.Close();
            }
        }

        private static void CreateHealer(Healer h)
        {
            Database db = new Database();
            string query = String.Format("INSERT INTO healer (name, colorR, colorG, colorB) VALUES ({0}, {1}, {2}, {3});",
                Database.QuoteMarks( h.Name ),
                h.Color.R,
                h.Color.G,
                h.Color.B );
            db.SetCommand(query);

            try
            {
                db.Execute();
                h.Id = db.Command.LastInsertedId;
            }
            catch (Exception e)
            {
                db.ReportError("SaveHealer/...: " + e.Message);
            }
            finally
            {
                db.Close();
            }
        }
        
        internal static List<Healer> GetHealerList()
        {
            List<Healer> resultList = new List<Healer>();

            Database db = new Database();
            db.SetCommand("SELECT * FROM healer;");
            try
            {
                db.ExecuteReader();
                if (db.ReaderHasRows)
                {
                    while (db.Read())
                    {
                        Healer healer = new Healer();

                        healer.Name = db.GetString("name");
                        healer.Color = Color.FromArgb(db.GetInt("ColorR"), db.GetInt("ColorG"), db.GetInt("ColorB"));
                        healer.Id = db.GetInt("id");

                        healer.DatabaseAction = dbAction.none;

                        resultList.Add(healer);
                    }
                }
            }
            catch (Exception e)
            {
                db.ReportError("GetHealer: " + e.Message);
            }
            finally
            {
                db.Close();
            }
            return resultList;
        }

        internal static void LoadHealerToList(ref List<Healer> healer)
        {
            Database db = new Database();
            db.SetCommand("SELECT * FROM healer;");
            healer.Clear();

            try
            {
                db.ExecuteReader();

                if (db.ReaderHasRows)
                {
                    while (db.Read())
                    {
                        Healer h = new Healer();
                        h.Id = db.GetLong("id");
                        h.Name = db.GetString("name");
                        h.SetColor(db.GetInt("colorR"), db.GetInt("colorG"), db.GetInt("colorB"));
                        h.DatabaseAction = dbAction.none;

                        healer.Add(h);
                    }
                }
            }
            catch (Exception e)
            {
                db.ReportError("LoadHealerToList" + e.Message);
            }
            finally
            {
                db.Close();
            }
        }

        #endregion

        internal static List<Datenobjekte.AffirmationAwaitingAppointment> GetAppointmentsWaitingForAffirmation()
        {
            List<Datenobjekte.AffirmationAwaitingAppointment> result = new List<Datenobjekte.AffirmationAwaitingAppointment>();
            Datenobjekte.AffirmationAwaitingAppointment appointment =null;
            Database db = new Database();

            db.SetCommand("select * from treatedWithItems as t,affirmationawaitingappointments as a where t.treatmentId = a.treatmentid;");
            try
            {
                System.Data.DataTable dt = db.Table();
                dt.Columns["invoiceGroupId"].AllowDBNull = true;

                long lastId = -1;
                StringBuilder treatmentAsString = new StringBuilder();

                foreach (System.Data.DataRow row in dt.Rows)
                {
                    if (lastId != (long)row["id"])
                    {
                        // ggfs. vorheriges Appointment abspeichern

                        if (appointment != null)
                        {
                            appointment.Treatment = treatmentAsString.ToString();
                            result.Add(appointment);
                        }

                        // Neues Appointment begonnen ...
                        appointment = new Datenobjekte.AffirmationAwaitingAppointment((long)row["id"]);
                        lastId = (long)row["id"];
                        treatmentAsString = new StringBuilder();

                        appointment.TreatmentId = (long)row["treatmentId"];
                        appointment.Start = (DateTime)row["startDate"];
                        appointment.End = (DateTime)row["endDate"];
                        appointment.Label = (string)row["label"];

                        appointment.FirstName = (string)row["firstName"];
                        appointment.LastName = (string)row["lastName"];
                        appointment.Diagnosis = (string)row["diagnosis"];


                    }
                    
                    if (treatmentAsString.Length != 0)
                        treatmentAsString.Append(", ");

                    if (row.IsNull("invoiceGroupId"))
                    {
                        // ist Item, hinzufügen
                        treatmentAsString.AppendFormat("<{0}.{1} {2}>",
                            (int)row["tariffMain"],
                            (int)row["tariffSub"],
                            (string)row["description"]);
                    }
                    else
                    {
                        // ist gruppe
                        treatmentAsString.AppendFormat("[{0}]",
                            (string)row["label"]);
                    }

                    

                }
                if (appointment != null)
                {
                    appointment.Treatment = treatmentAsString.ToString();
                    result.Add(appointment);
                }

            }
            catch (Exception e)
            {
                db.ReportError("GetAppointmentsWaitingForAffirmation: " + e.Message);
            }
            finally
            {
                db.Close();
            }
            return result;
        }
            
 

        internal static List<long> GetAppointmentsWaitingForAffirmationAsIds()
        {
            List<long> result = new List<long>();
            Database db = new Database();

            db.SetCommand(
                        @"SELECT id FROM appointment 
                      WHERE startdate < now() 
                            AND occured = false
                            AND treatmentId IS NOT NULL;");

            try
            {
                System.Data.DataTable dt = db.Table();

                foreach (System.Data.DataRow row in dt.Rows)
                    result.Add((long)row["id"]);

            }
            catch (Exception e)
            {
                db.ReportError("GetAppointmentsWaitingForAffirmation: " + e.Message);
            }
            finally
            {
                db.Close();
            }
            return result;
        }

        internal static void SetAppointmentAsOccured(long id)
        {
            Database db = new Database();
            string query = String.Format("UPDATE appointment SET occured=true WHERE id={0};",id);
            db.SetCommand(query);
            try
            {
                db.Execute();
            }
            catch (Exception e)
            {
                db.ReportError("SetAppointmentAsOccured: " + e.Message);
            }
            finally
            {
                db.Close();
            }
        }



        internal static System.Data.DataTable GetDataTableOfAppointmentsToInvoice(long patientId)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            Database db = new Database();

            db.SetCommand( String.Format(
                        @"SELECT * FROM appointment, treatment
                          WHERE appointment.treatmentId = treatment.id
                                AND startdate < now() 
                                AND occured = true
                                AND treatmentId IS NOT NULL
                                AND invoiceId IS NULL
                                AND patientId = {0};", patientId));


            try
            {
                dt = db.Table();

            }
            catch (Exception e)
            {
                db.ReportError("GetDataTableOfAppointmentsToInvoice: " + e.Message);
            }
            finally
            {
                db.Close();
            }
            return dt;
        }

        internal static List<Treatment> GetTreatmentsOfAppointmentsToInvoice(long patientId)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            List<Treatment> treatments = new List<Treatment>();

            Database db = new Database();

            db.SetCommand(String.Format(
                        @"SELECT * FROM appointment, treatment
                          WHERE appointment.treatmentId = treatment.id
                                AND startdate < now() 
                                AND occured = true
                                AND treatmentId IS NOT NULL
                                AND invoiceId IS NULL
                                AND patientId = {0}
                          GROUP BY treatment.id;", patientId));


            try
            {
                dt = db.Table();
                    
                foreach( System.Data.DataRow row in dt.Rows ) {
                    Treatment t = new Treatment();
                        t = GetTreatment((long)row["id"]);
                        treatments.Add(t);
                }
 

            }
            catch (Exception e)
            {
                db.ReportError("GetDataTableOfAppointmentsToInvoice: " + e.Message);
            }
            finally
            {
                db.Close();
            }
            return treatments;
        }

        internal static List<Appointment> GetAppointmentsForTreatment(long treatmentId)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            List<Appointment> appointments = new List<Appointment>();

            Database db = new Database();

            db.SetCommand(String.Format(
                        @"SELECT * FROM appointment
                          WHERE appointment.treatmentId = {0}
                                AND startdate < now() 
                                AND occured = true
                                AND invoiceId IS NULL;", treatmentId));


            try
            {
                dt = db.Table();

                foreach (System.Data.DataRow row in dt.Rows)
                {
                    Appointment a = new Appointment();

                    a.StartDate = (DateTime)row["startDate"];
                    a.EndDate = (DateTime)row["endDate"];
                    a.Id = (long)row["id"];

                    appointments.Add(a);
                }


            }
            catch (Exception e)
            {
                db.ReportError("GetDataTableOfAppointmentsToInvoice: " + e.Message);
            }
            finally
            {
                db.Close();
            }
            return appointments;
        }

    }//END OF CLASS 'DO_DATABASE_MAGIC'
}//END OF NAMESPACE
