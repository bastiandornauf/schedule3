using System;
using System.Collections.Generic;
using System.Text;

namespace HPSchedule.Datenobjekte
{
    /// <summary>
    /// Ein Datenobjekt, da� auf einer Datenbank beruht
    /// </summary>
    public interface IDatabasedObject
    {
        /// <summary>
        /// Speichert den Zustand der Daten bezogen aud den Datenbestand in der DB ab
        /// </summary>
        dbAction DatabaseAction { get; set; }

        /// <summary>
        /// Speichere die Daten in die DB
        /// </summary>
        void SaveToDatabase();
    }

    /// <summary>
    /// Ein IDatabasedObject, da� eine ID ben�tigt
    /// </summary>
    public interface IUniqueDatabasedObject : IDatabasedObject
    {
        /// <summary>
        /// Lade den durch id bezeichneten Datensatz aus der DB
        /// </summary>
        void LoadFromDatabase(long id);
    }

    /// <summary>
    /// Ein IDatabasedObject, da� eine Sammlung von Daten besitzt
    /// UND ohne id generiert werden kann
    /// </summary>
    public interface IDatabasedCollection : IDatabasedObject
    {

        /// <summary>
        /// Lade alle Daten aus der DB
        /// </summary>
        void LoadFromDatabase();
    }
}
