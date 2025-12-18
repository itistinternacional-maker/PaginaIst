using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaginaIst.AccesoDatos.Data.Repository.IRepository;
using PaginaIst.Models;
using PaginaIst.Services;            // IReporteEquipoService
using System;
using System.Linq;

namespace PaginaIst.Areas.EquiposRentados.Controllers
{
    [Area("EquiposRentados")]
    public class EquipoRentadosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly ILogger<EquipoRentadosController> _logger;
        private readonly IReporteEquipoService _reporteEquipoService;

        // ✅ ÚNICO CONSTRUCTOR con inyección de dependencias
        public EquipoRentadosController(
            IContenedorTrabajo contenedorTrabajo,
            ILogger<EquipoRentadosController> logger,
            IReporteEquipoService reporteEquipoService)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _logger = logger;
            _reporteEquipoService = reporteEquipoService;
        }

        // Vista principal
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // Crear equipo (GET)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Crear equipo (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.EquiposRentados equiporentados)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.EquiposRentados.Add(equiporentados);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(equiporentados);
        }

        // Editar equipo (GET)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var equipo = _contenedorTrabajo.EquiposRentados.Get(id);
            if (equipo == null)
                return NotFound();

            return View(equipo);
        }

        // Editar equipo (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Models.EquiposRentados equipoRentados)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.EquiposRentados.Update(equipoRentados);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(equipoRentados);
        }

        // Eliminar equipo (AJAX - DELETE)
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.EquiposRentados.Get(id);
            if (objFromDb == null)
                return Json(new { success = false, message = "Error eliminando equipo" });

            _contenedorTrabajo.EquiposRentados.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Equipo eliminado correctamente" });
        }

        // Datos para DataTables
        [HttpGet]
        public IActionResult GetAll()
        {
            var equipos = _contenedorTrabajo.EquiposRentados.GetAll();
            return Json(new { data = equipos });
        }

        //// 🔹 PDF individual de un equipo
        //[HttpGet]
        //public IActionResult DetallePdf(int id)
        //{
        //    var equiporentado = _contenedorTrabajo.EquiposRentados.Get(id);
        //    if (equiporentado == null)
        //        return NotFound();

        //    var pdfBytes = _reporteEquipoService.GenerarPdfEquipo(equiporentado);
        //    var fileName = $"Equipo_{id}.pdf";

        //    return File(pdfBytes, "application/pdf", fileName);
        //}

        //// 🔹 PDF del listado (respeta el filtro del buscador)
        //[HttpGet]
        //public IActionResult ExportarPdf(string search)
        //{
        //    var equipos = _contenedorTrabajo.EquiposRentados.GetAll();

        //    if (!string.IsNullOrWhiteSpace(search))
        //    {
        //        var filtro = search.Trim().ToLower();

        //        // Filtro básico por campos clave
        //        equipos = equipos.Where(e =>
        //            e.Placa.ToString().ToLower().Contains(filtro) ||
        //            (!string.IsNullOrEmpty(e.Hostname) && e.Hostname.ToLower().Contains(filtro)) ||
        //            (!string.IsNullOrEmpty(e.Marca) && e.Marca.ToLower().Contains(filtro)) ||
        //            (!string.IsNullOrEmpty(e.Modelo) && e.Modelo.ToLower().Contains(filtro)) ||
        //            (!string.IsNullOrEmpty(e.Serial) && e.Serial.ToLower().Contains(filtro))
        //        );
        //    }

            //var listaFiltrada = equipos.ToList();

            // Log de auditoría
            //var usuario = User?.Identity?.Name ?? "Anonimo";
            //_logger.LogInformation(
            //    "ExportarPdf ListaEquipos | Usuario: {Usuario} | Filtro: {Filtro} | Cantidad: {Total}",
            //    usuario,
            //    search,
            //    listaFiltrada.Count
            //);

            //var pdfBytes = _reporteEquipoService.GenerarPdfListado(listaFiltrada);
            //return File(pdfBytes, "application/pdf", "HOJA DE VIDA.pdf");
        }
    }
