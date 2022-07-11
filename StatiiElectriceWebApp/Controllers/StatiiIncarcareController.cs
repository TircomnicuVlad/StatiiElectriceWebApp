using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StatiiElectriceWebApp.Models.DB;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;

namespace StatiiElectriceWebApp.Controllers
{
    public class StatiiIncarcareController : Controller
    {
        private readonly StatiiIncarcareElectriceContext _statiiIncarcare;

        public StatiiIncarcareController (StatiiIncarcareElectriceContext statiiIncarcare)
        {
            _statiiIncarcare = statiiIncarcare;
        }

        // GET: StatiiIncarcareController
        public ActionResult GetStatii()
        {
            var statii = _statiiIncarcare.Statiis.ToList();
            return View(statii);
        }

        // GET: StatiiIncarcareController/Details/5
        public ActionResult Details(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Statii statie = _statiiIncarcare.Statiis.Include(x => x.Prizes).ThenInclude(s => s.Tip)
            .FirstOrDefault(m => m.Id == id);
            if (statie == null)
            {
                return NotFound();
            }

           /* statie.Prizes = _statiiIncarcare.Prizes.Where(p => p.StatieId.Equals(statie.Id)).ToArray();
            foreach (Prize item in statie.Prizes){
                item.Tip = _statiiIncarcare.Tips.FirstOrDefault(t => t.Id == item.TipId);
            }*/

            return View(statie);
        }

        // GET: StatiiIncarcareController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: StatiiIncarcareController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( IFormCollection form)
        {
            Statii statie = new Statii(form["nume"], form["oras"], form["adresa"]);
            _statiiIncarcare.
                Statiis.Add(statie);
            _statiiIncarcare.SaveChanges();
            return RedirectToAction("GetStatii");
        }

        // GET: StatiiIncarcareController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Statii statie = _statiiIncarcare.Statiis
            .FirstOrDefault(m => m.Id == id);
            if (statie == null)
            {
                return NotFound();
            }
            return View(statie);
        }

        // POST: StatiiIncarcareController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(IFormCollection form)
        {
            var statie = new Statii(Int32.Parse(form["id"]) ,form["nume"], form["Oras"], form["Adresa"]);

            _statiiIncarcare.Statiis.Update(statie);
            _statiiIncarcare.SaveChanges();
            return RedirectToAction("GetStatii");
        }

        // POST: StatiiIncarcareController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Statii statie = _statiiIncarcare.Statiis.FirstOrDefault(s => s.Id == id);

            _statiiIncarcare.Statiis.Remove(statie);
            _statiiIncarcare.SaveChanges();
            return RedirectToAction("GetStatii");
        }

        public ActionResult Filter(IFormCollection form)
        {
            String txt = form["search"];
            if (txt == null)
            {
                return RedirectToAction("GetStatii");
            }

            List <Statii> statii = _statiiIncarcare.Statiis.
                Where(s => s.Nume.Contains(txt) || s.Adresa.Contains(txt) 
                || s.Oras.Contains(txt)).ToList();
            return View("GetStatii", statii);
        }

    }
}
