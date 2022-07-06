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

        public Prize() { }
        public Prize(int tipId, int statieId)
        {
            StatieId = statieId;
            TipId = tipId;
        }

        public Prize(int tipId, int statieId, int id)
        {
            StatieId = statieId;
            TipId = tipId;
            Id = id;
        }
    }
}
