using Microsoft.AspNetCore.Mvc;
using StatiiElectriceWebApp.Models;
using System.Diagnostics;
using StatiiElectriceWebApp.Models.ViewModels;
using Newtonsoft.Json;
using StatiiElectriceWebApp.Models.DB;

namespace StatiiElectriceWebApp.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public readonly StatiiIncarcareElectriceContext _context;
        public HomeController(ILogger<HomeController> logger, StatiiIncarcareElectriceContext context)
        {
            _logger = logger;
            _context = context;
        }

        private CalendarViewModel GetBookingsForWeek(DateTime startWeek)
        {
            CalendarViewModel calendar = new CalendarViewModel();

            calendar.StartWeekDay = startWeek.ToString();
            var i = -7;
            foreach (var item in calendar.calendars)
            {
                item.Date = startWeek.AddDays(i).Date;
                item.rezervari = _context.Rezervaris.
                    Where(r => r.StartDate.Date == startWeek.AddDays(i))
                    .ToList();
                i++;
            }

            return calendar;
        }
        public ActionResult Index()
        {
            /*Seeding rudimentar
            DateTime StartTime = DateTime.Parse("2022-07-04 00:00:00.000");
            DateTime EndTime = DateTime.Parse("2022-07-04 01:00:00.000");
            for (int k = 0; k < 24; k++)
            {
                StartTime = StartTime.AddHours(k);
                EndTime = EndTime.AddHours(k);
                Rezervari rezervari = new Rezervari(StartTime, EndTime, 1, "OT01VLD");
                _context.Rezervaris.Add(rezervari);
            }
            _context.SaveChanges();
            */

            double count = 24, y = 0;
            List<DataPoint> dataPoints = new List<DataPoint>();

            var day = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            DateTime startWeek = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            List<Rezervari> calendar = _context.Rezervaris
                .Where(r => r.StartDate.Date >= startWeek.AddDays(-7) &&
            r.StartDate.Date <= startWeek.AddDays(-1))
                .OrderBy(r => r.StartDate.Hour)
                .ToList();

            int j = 0;
            for (int i = 0; i <= count; i++)
            {
                y = 0;
                while (j < calendar.Count && calendar[j].StartDate.Hour == i)
                {
                    y++;
                    j++;
                }
                dataPoints.Add(new DataPoint(i, y));
            }

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}