using System;
using System.Collections.Generic;

namespace AlgebraPredbiljezbeApp.Data
{
    public partial class Seminar
    {
        public Seminar()
        {
            Predbiljezba = new HashSet<Predbiljezba>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public DateTime? Datum { get; set; }
        public bool Popunjen { get; set; }

        public virtual ICollection<Predbiljezba> Predbiljezba { get; set; }
    }
}
