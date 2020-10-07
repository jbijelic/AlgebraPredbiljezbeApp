using System;
using System.Collections.Generic;

namespace AlgebraPredbiljezbeApp.Data
{
    public partial class Zaposlenik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Password { get; set; }
    }
}
