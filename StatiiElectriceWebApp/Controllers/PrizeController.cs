using Microsoft.AspNetCore.Mvc;
using StatiiElectriceWebApp.Models.DB;
using StatiiElectriceWebApp.Models.ViewModels;

namespace StatiiElectriceWebApp.Controllers
{
    public class PrizeController : Controller
    {
        public readonly StatiiIncarcareElectriceContext _context;
        public IActionResult AddToStation(int id)
        {
            PrizaViewModel model = new PrizaViewModel();

            model.StationId = id;
            model.Tipuri = _context.Tips.ToList();

            return View(model);
        }

        public IActionResult Add(int id, PrizaViewModel model)
        {

            return View(id);
        }
    }
}
