using Microsoft.AspNetCore.Mvc;
using StatiiElectriceWebApp.Models.DB;
using StatiiElectriceWebApp.Models.ViewModels;

namespace StatiiElectriceWebApp.Controllers
{
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
            //foreach (var item in calendar.calendars){}
            return View();
        }
    }
}
