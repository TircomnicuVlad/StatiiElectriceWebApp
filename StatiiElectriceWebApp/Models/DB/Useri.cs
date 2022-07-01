using System;
using System.Collections.Generic;

namespace StatiiElectriceWebApp.Models.DB
{
    public partial class Useri
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Parola { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
