using System;
using System.Collections.Generic;

namespace StatiiElectriceWebApp.Models.DB
{
    public partial class Prize
    {
        public int Id { get; set; }
        public int StatieId { get; set; }
        public int TipId { get; set; }

        public virtual Statii Statie { get; set; } = null!;
        public virtual Tip Tip { get; set; } = null!;
    }
}
