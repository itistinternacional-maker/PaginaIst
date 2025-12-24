using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaginaIst.AccesoDatos.Data.Repository.IRepository;
using PaginaIst.Models;

namespace PaginaIst.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,IT,Mantenimiento")]
    public class RentadosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public RentadosController(IContenedorTrabajo contenedorTrabajo)
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
        public IActionResult Create(Rentados rentados)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Rentados.Add(rentados);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(rentados);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var rentados = _contenedorTrabajo.Rentados.Get(id);
            if (rentados == null) return NotFound();
            return View(rentados);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Rentados rentados)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Rentados.Update(rentados);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(rentados);
        }

        #region Llamadas a la API

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Rentados.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Rentados.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando mantenimiento" });
            }

            _contenedorTrabajo.Rentados.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Mantenimiento borrado correctamente" });
        }

        #endregion
    }
}
