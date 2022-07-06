using System;
using System.Collections.Generic;

namespace StatiiElectriceWebApp.Models.DB
{
    public partial class Rezervari
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PrizaId { get; set; }
        public string NrMasina { get; set; } = null!;
        public int? UserId { get; set; }

        public virtual Prize Priza { get; set; } = null!;
        public virtual Useri? User { get; set; }

        public Rezervari( DateTime startDate, DateTime endDate, int prizaId, string nrMasina)
        {
            Id = new Guid();
            StartDate = startDate;
            EndDate = endDate;
            PrizaId = prizaId;
            NrMasina = nrMasina;
        }
    }
}
