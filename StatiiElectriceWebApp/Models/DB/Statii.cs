﻿using System;
using System.Collections.Generic;

namespace StatiiElectriceWebApp.Models.DB
{
    public partial class Statii
    {
        public Statii()
        {
            Prizes = new HashSet<Prize>();
        }


        public int Id { get; set; }
        public string Nume { get; set; } = null!;
        public string Oras { get; set; } = null!;
        public string Adresa { get; set; } = null!;

        public Statii(string nume, string oras, string adresa)
        {
            Nume = nume;
            Oras = oras;
            Adresa = adresa;
        }

        public virtual ICollection<Prize> Prizes { get; set; }
    }
}
