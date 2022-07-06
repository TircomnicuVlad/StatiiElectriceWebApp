using System.ComponentModel.DataAnnotations;

namespace StatiiElectriceWebApp.Models.ViewModels
{
    public class RezervariViewModel
    {
        public int PlugId;
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        public int PrizaId { get; set; }
        [Required(ErrorMessage = "Introdu nr de inmatriculare al masinii")]
        public string NrMasina { get; set; }
    }
}
