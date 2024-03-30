using Microsoft.AspNetCore.Mvc;
using Salud.Data;
using Salud.Models;
using System;
using System.Linq;

namespace Salud.Controllers
{
    public class MetaSaludController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MetaSaludController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var metasSalud = _db.metaSalud.ToList();
            return View(metasSalud);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MetaSalud metaSalud)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.metaSalud.Add(metaSalud);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error al agregar la meta de salud: {ex.Message}");
                }
            }
            return View(metaSalud);
        }
    }
}
