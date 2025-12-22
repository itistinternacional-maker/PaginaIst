using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaginaIst.AccesoDatos.Data.Repository.IRepository;
using PaginaIst.Models;

namespace PaginaIst.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,IT,Mantenimiento")]
    public class MantenimientosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public MantenimientosController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Mantenimiento mantenimiento)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Mantenimiento.Add(mantenimiento);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(mantenimiento);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var mantenimiento = _contenedorTrabajo.Mantenimiento.Get(id);
            if (mantenimiento == null) return NotFound();
            return View(mantenimiento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Mantenimiento mantenimiento)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Mantenimiento.Update(mantenimiento);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(mantenimiento);
        }

        #region Llamadas a la API

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Mantenimiento.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Mantenimiento.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando mantenimiento" });
            }

            _contenedorTrabajo.Mantenimiento.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Mantenimiento borrado correctamente" });
        }

        #endregion
    }
}
