using StatiiElectriceWebApp.Models.DB;

namespace StatiiElectriceWebApp.Models.ViewModels
{


    public class PrizaViewModel
    {
        public int StationId { get; set; }
        public int Tip { get; set; }
        public IEnumerable<Tip> Tipuri { get; set; }

        
    }
}
