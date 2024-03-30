// PersonaController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Salud.Data;
using Salud.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Salud.Controllers
{
    public class PersonaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PersonaController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var personas = await _db.Personas.ToListAsync();
            return View(personas);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePersona(PersonasEntity persona, IFormFile fotoPerfil)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (fotoPerfil != null && fotoPerfil.Length > 0)
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            await fotoPerfil.CopyToAsync(memoryStream);
                            persona.FotoPerfil = memoryStream.ToArray();
                        }
                    }

                    _db.Personas.Add(persona);
                    await _db.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error al crear la persona: {ex.Message}");
                }
            }

            return View(persona);
        }
    }
}
