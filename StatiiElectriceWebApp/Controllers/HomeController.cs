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

        public ActionResult Index()
        {
            //Seeding rudimentar
            //DateTime StartTime = DateTime.Parse("2022-07-04 01:00:00.000");
            //DateTime EndTime = DateTime.Parse("2022-07-04 02:00:00.000");
            //for (int k = 0; k < 7; k++)
            //{
            //    for (int k1 = 0; k1 < 11; k1++)
            //    {
            //        Rezervari rezervari = new Rezervari(StartTime, EndTime, 2, "TM77NTR");
            //        _context.Rezervaris.Add(rezervari);
            //        StartTime = StartTime.AddHours(2);
            //        EndTime = EndTime.AddHours(2);
            //    }
            //}
            //_context.SaveChanges();


            double count = 7, y;
            List<DataPoint> dataPoints = new List<DataPoint>();

            var day = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            DateTime startWeek = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
            DateTime start = startWeek.AddDays(-7).Date;
            List<Rezervari> calendar = _context.Rezervaris
                .Where(r => r.StartDate.Date >= startWeek.AddDays(-7) &&
            r.StartDate.Date <= startWeek.AddDays(-1))
                .OrderBy(r => r.StartDate)
                .ToList();

            int j = 0;
            for (DateTime i = start; i < start.AddDays(count); i = i.AddDays(1))
            {
                y = 0;
                while (j < calendar.Count && calendar[j].StartDate.Date == i)
                {
                    y++;
                    j++;
                }
                dataPoints.Add(new DataPoint($"{i.DayOfWeek.ToString()} ({i.Date.ToShortDateString()})", y));
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