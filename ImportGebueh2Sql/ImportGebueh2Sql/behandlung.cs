using System;
using System.Collections.Generic;
using System.Text;

namespace ImportGebueh2Sql
{
    public class TreatmentFingerprint
    {
        public long PatientId;
        public long Id;
        public string Diagnose;
        public string Behandlung;

        public override bool Equals(object obj)
        {
            TreatmentFingerprint other = obj as TreatmentFingerprint;
            if (obj == null)
                return false;
            else
                return PatientId == other.PatientId && Diagnose == other.Diagnose && Behandlung == other.Behandlung;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }

}
