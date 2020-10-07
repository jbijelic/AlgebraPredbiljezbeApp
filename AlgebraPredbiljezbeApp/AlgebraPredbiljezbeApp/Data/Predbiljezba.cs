using System;
using System.Collections.Generic;

namespace AlgebraPredbiljezbeApp.Data
{
    public partial class Predbiljezba
    {
        public int Id { get; set; }
        public DateTime? Datum { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public int? SeminarId { get; set; }
        public bool Status { get; set; }

        public virtual Seminar Seminar { get; set; }
    }
}
