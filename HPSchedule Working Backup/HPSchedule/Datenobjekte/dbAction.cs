using System;
using System.Collections.Generic;
using System.Text;

namespace HPSchedule.Datenobjekte
{
    /// <summary>
    /// m�gliche Aktionen f�r Datenbank-Operationen
    /// </summary>
    public enum dbAction
    {
        none,
        created,
        modified,
        delete
    }
}
