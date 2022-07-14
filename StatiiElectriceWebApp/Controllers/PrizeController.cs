using Microsoft.AspNetCore.Mvc;
using StatiiElectriceWebApp.Models.DB;
using StatiiElectriceWebApp.Models.ViewModels;

namespace StatiiElectriceWebApp.Controllers
{
    public class PrizeController : Controller
    {
        public readonly StatiiIncarcareElectriceContext _context;

        public PrizeController(StatiiIncarcareElectriceContext context)
        {
            _context = context;
        }

        public IActionResult AddToStation(int id)
        {
            PrizaViewModel model = new PrizaViewModel();

            model.StationId = id;
            model.Tipuri = _context.Tips.ToList();

            return View(model);
        }

        public IActionResult Add(PrizaViewModel model)
        {
            //Prize p = new Prize(Int32.Parse(model["StationId"]), Int32.Parse(model["Tip"]));
            Prize p = new Prize(model.Tip, model.StationId);
            _context.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Details", "StatiiIncarcare", new {id = model.StationId });
        }

        public IActionResult Delete(int id)
        {
            Prize p = _context.Prizes.FirstOrDefault(s => s.Id == id);
            List<Rezervari> rezervari = _context.Rezervaris.Where(r => r.PrizaId == id).ToList();
            foreach(Rezervari item in rezervari)
            {
                _context.Rezervaris.Remove(item);
            }

            _context.Prizes.Remove(p);
            _context.SaveChanges();
            return RedirectToAction("Details", "StatiiIncarcare", new { id = p.StatieId });
        }
    }
}
