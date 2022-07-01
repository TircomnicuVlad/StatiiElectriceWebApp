using System;
using System.Collections.Generic;

namespace StatiiElectriceWebApp.Models.DB
{
    public partial class Tip
    {
        public Tip()
        {
            Prizes = new HashSet<Prize>();
        }

        public int Id { get; set; }
        public string Nume { get; set; } = null!;

        public virtual ICollection<Prize> Prizes { get; set; }
    }
}
