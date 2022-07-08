﻿using Microsoft.AspNetCore.Mvc;
using NodaTime;
using StatiiElectriceWebApp.Models.DB;
using StatiiElectriceWebApp.Models.ViewModels;

namespace StatiiElectriceWebApp.Controllers
{
    public class RezervariController : Controller
    {
        public readonly StatiiIncarcareElectriceContext _context;

        public RezervariController(StatiiIncarcareElectriceContext context)
        {
            _context = context;
        }
        public IActionResult Create(int id)
        {
            RezervariViewModel rezervare = new RezervariViewModel();
            rezervare.PrizaId = id;
            return View(rezervare);
        }

        public IActionResult Add(RezervariViewModel form)
        {
            if (ModelState.IsValid)
            {
                Rezervari rezervari = new Rezervari(form.StartDate, form.EndDate, form.PrizaId, form.NrMasina);
                if (rezervari.StartDate >= rezervari.EndDate)
                {
                    ModelState.AddModelError(nameof(RezervariViewModel.EndDate), "Data sau ora invalida");
                }
                else if (rezervari.StartDate < DateTime.Now)
                {
                    ModelState.AddModelError(nameof(RezervariViewModel.StartDate), "Data sau ora invalida");
                }
                else
                {
                    var rezervaris = _context.Rezervaris.
                        Any(r => ((r.StartDate >= rezervari.StartDate && r.StartDate < rezervari.EndDate)
                        || (r.EndDate > rezervari.StartDate && r.EndDate <= rezervari.EndDate) ||
                        (r.StartDate < rezervari.StartDate && r.EndDate > rezervari.EndDate))
                        && r.PrizaId == rezervari.PrizaId);
                    if (rezervaris)
                    {
                        ModelState.AddModelError(nameof(RezervariViewModel.StartDate), "Exista deja o rezervare in aceast interval");
                    }
                    else
                    {
                        _context.Add(rezervari);
                        _context.SaveChanges();
                        return RedirectToAction("GetStatii", "StatiiIncarcare");
                    }
                }
            }
            //ModelState.ClearValidationState(nameof(RezervariViewModel.NrMasina));
            //ModelState.AddModelError(nameof(RezervariViewModel.StartDate), "Introdu o data si o ora valida");
            //ModelState.AddModelError(nameof(RezervariViewModel.EndDate), "Introdu o data si o ora valida");
            //ModelState.AddModelError(nameof(RezervariViewModel.NrMasina), "Introdu nr de inmatriculare al masinii");

            return View("Create", form);
        }
    }
}
