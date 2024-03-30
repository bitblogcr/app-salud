using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Salud.Data;
using Salud.Models;
using System.Linq;

namespace Salud.Controllers
{
    public class ActividadController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ActividadController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var actividades = _db.Actividad.ToList();
            return View(actividades);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateActividad(ActividadEntity actividad)
        {
            if (ModelState.IsValid)
            {
                // Obtener el próximo ID de actividad
                int nextID = ObtenerProximoIDActividad();

                // Asignar el próximo ID a la actividad
                actividad.ID_RegistroActividad = nextID;

                // Agregar la actividad al contexto y guardar los cambios
                _db.Actividad.Add(actividad);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(actividad);
        }

        // Función para obtener el próximo ID de actividad
        private int ObtenerProximoIDActividad()
        {
            // Obtener el ID más grande actualmente en la tabla de actividades
            int maxID = _db.Actividad.Max(a => (int?)a.ID_RegistroActividad) ?? 0;

            // Devolver el siguiente ID incrementado en uno
            return maxID + 1;
        }
    }
}
