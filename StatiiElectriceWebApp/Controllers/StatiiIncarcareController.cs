using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StatiiElectriceWebApp.Models.DB;

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

            var statie = _statiiIncarcare.Statiis
            .FirstOrDefault(m => m.Id == id);
            if (statie == null)
            {
                return NotFound();
            }

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
            return View();
        }

        // POST: StatiiIncarcareController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StatiiIncarcareController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StatiiIncarcareController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
