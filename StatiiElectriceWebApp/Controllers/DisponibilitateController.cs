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
            var day = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            CalendarViewModel calendar = GetBookingsForWeek(id, day);
            return View(calendar);
        }

        private CalendarViewModel GetBookingsForWeek(int id, DateTime startWeek)
        {
            CalendarViewModel calendar = new CalendarViewModel();
            calendar.PrizaId = id;
            //calendar.Iterator = 0;
            //var y = _context.Rezervaris.FirstOrDefault();
            //var z = y.StartDate;
            //var x = DateTime.Now.StartOfWeek(DayOfWeek.Saturday);
            //var k = z.Date == x.Date;
          
            calendar.StartWeekDay = startWeek.ToString();
            var i = 0;
            foreach (var item in calendar.calendars)
            {
                item.Date = startWeek.AddDays(i).Date;
                item.rezervari = _context.Rezervaris.
                    Where(r => r.PrizaId == id && r.StartDate.Date == startWeek.AddDays(i))
                    .ToList();
                i++;
            }

            return calendar;
        }

        public IActionResult Next(string startDate, int id)
        {
            var day = DateTime.Parse(startDate).AddDays(7).StartOfWeek(DayOfWeek.Monday);
            CalendarViewModel calendar = GetBookingsForWeek(id, day);
            return View("Index", calendar);
            //calendar.Iterator++;
            //var day = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            //var i = 0;
            //foreach (var item in calendar.calendars)
            //{
            //    item.Date = day.AddDays(i).Date;
            //    item.rezervari = _context.Rezervaris.
            //        Where(r => r.PrizaId == calendar.PrizaId && r.StartDate.Date == day.AddDays(i))
            //        .ToList();
            //    i++;
            //}
            //return View("Index", calendar);
        }
        public IActionResult Previous(string startDate, int id)
        {
            var day = DateTime.Parse(startDate).AddDays(-7).StartOfWeek(DayOfWeek.Monday);
            CalendarViewModel calendar = GetBookingsForWeek(id, day);
            return View("Index", calendar);
        }
    }
}
