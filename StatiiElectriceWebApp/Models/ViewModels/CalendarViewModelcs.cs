using StatiiElectriceWebApp.Models.DB;
using System.Collections.Generic;

namespace StatiiElectriceWebApp.Models.ViewModels
{

    public class CalendarViewModelcs
    {
        public DayOfWeek DayOfWeek { get; set; }
        public List<Rezervari> rezervari { get; set; }

        public CalendarViewModelcs(DayOfWeek dayOfWeek)
        {
            DayOfWeek = dayOfWeek;
        }
    }
}
