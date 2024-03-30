using Microsoft.AspNetCore.Mvc;
using Salud.Data;
using Salud.Models;
using System;
using System.Linq;

namespace Salud.Controllers
{
    public class DietaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DietaController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var dietas = _db.Dieta.ToList();
            return View(dietas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DietaEntity dieta)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Dieta.Add(dieta);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error al agregar la dieta: {ex.Message}");
                }
            }
            return View(dieta);
        }
    }
}
