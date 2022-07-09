using Microsoft.AspNetCore.Mvc;
using StatiiElectriceWebApp.Models.DB;
using StatiiElectriceWebApp.Models.ViewModels;

namespace StatiiElectriceWebApp.Controllers
{

    public static class DateTimeExtensions
    {
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }
    public class DisponibilitateController : Controller
    {
        private readonly StatiiIncarcareElectriceContext _context;

        public DisponibilitateController(StatiiIncarcareElectriceContext statiiIncarcare)
        {
            _context = statiiIncarcare;
        }

        public IActionResult Index(int id)
        {
            CalendarViewModel calendar = new CalendarViewModel();
            //var y = _context.Rezervaris.FirstOrDefault();
            //var z = y.StartDate;
            //var x = DateTime.Now.StartOfWeek(DayOfWeek.Saturday);
            //var k = z.Date == x.Date;
            foreach (var item in calendar.calendars)
            {
                var day = DateTime.Now.StartOfWeek(item.DayOfWeek);
                item.rezervari = _context.Rezervaris.
                    Where(r => r.PrizaId == id && r.StartDate.Date == day)
                    .ToList();
            }
            return View(calendar);
        }
    }
}
