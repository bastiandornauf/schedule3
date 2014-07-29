using System;
using System.Collections.Generic;
using System.Text;

namespace HPSchedule.Datenobjekte
{
    /// <summary>
    /// mögliche Aktionen für Datenbank-Operationen
    /// </summary>
    public enum dbAction
    {
        none,
        created,
        modified,
        delete
    }
}
