using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaginaIst.AccesoDatos.Data.Repository.IRepository;
using PaginaIst.Models;
using PaginaIst.Servicesrentados;   // ✅ importante
using System;
using System.Linq;

namespace PaginaIst.Areas.EquiposRentados.Controllers
    {
    [Area ( "EquiposRentados" )]
    public class EquipoRentadosController : Controller
        {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly ILogger<EquipoRentadosController> _logger;
        private readonly IReporteEquipoServicerentados _reporteEquipoService; // ✅

        public EquipoRentadosController (
            IContenedorTrabajo contenedorTrabajo ,
            ILogger<EquipoRentadosController> logger ,
            IReporteEquipoServicerentados reporteEquipoService ) // ✅
            {
            _contenedorTrabajo = contenedorTrabajo;
            _logger = logger;
            _reporteEquipoService = reporteEquipoService;
            }

        [HttpGet]
        public IActionResult Index () => View ( );

        [HttpGet]
        public IActionResult Create () => View ( );

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create ( Models.EquiposRentados equiporentados )
            {
            if ( ModelState.IsValid )
                {
                _contenedorTrabajo.EquiposRentados.Add ( equiporentados ); // ✅ correcto
                _contenedorTrabajo.Save ( );
                return RedirectToAction ( nameof ( Index ) );
                }
            return View ( equiporentados );
            }

        [HttpGet]
        public IActionResult Edit ( int id )
            {
            var equipo = _contenedorTrabajo.EquiposRentados.Get(id);
            if ( equipo == null ) return NotFound ( );
            return View ( equipo );
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit ( Models.EquiposRentados equiporentados )
            {
            if ( ModelState.IsValid )
                {
                _contenedorTrabajo.EquiposRentados.Update ( equiporentados ); // ✅ correcto
                _contenedorTrabajo.Save ( );
                return RedirectToAction ( nameof ( Index ) );
                }
            return View ( equiporentados );
            }

        [HttpDelete]
        public IActionResult Delete ( int id )
            {
            var objFromDb = _contenedorTrabajo.EquiposRentados.Get(id);
            if ( objFromDb == null )
                return Json ( new { success = false , message = "Error eliminando equipo" } );

            _contenedorTrabajo.EquiposRentados.Remove ( objFromDb );
            _contenedorTrabajo.Save ( );
            return Json ( new { success = true , message = "Equipo eliminado correctamente" } );
            }

        [HttpGet]
        public IActionResult GetAll ()
            {
            var equiporentados = _contenedorTrabajo.EquiposRentados.GetAll();
            return Json ( new { data = equiporentados } );
            }

        // PDF individual
        [HttpGet]
        public IActionResult DetallePdf ( int id )
            {
            var equiporentados = _contenedorTrabajo.EquiposRentados.Get(id);
            if ( equiporentados == null ) return NotFound ( );

            var pdfBytes = _reporteEquipoService.GenerarPdfEquipo(equiporentados); // ✅
            return File ( pdfBytes , "application/pdf" , $"Equipo_{id}.pdf" );
            }

        // PDF listado
        [HttpGet]
        public IActionResult ExportarPdf ( string search )
            {
            var equiporentados = _contenedorTrabajo.EquiposRentados.GetAll();

            if ( !string.IsNullOrWhiteSpace ( search ) )
                {
                var filtro = search.Trim().ToLower();

                equiporentados = equiporentados.Where ( e =>
                    e.Placa.ToString ( ).ToLower ( ).Contains ( filtro ) ||
                    (!string.IsNullOrEmpty ( e.Hostname ) && e.Hostname.ToLower ( ).Contains ( filtro )) ||
                    (!string.IsNullOrEmpty ( e.Marca ) && e.Marca.ToLower ( ).Contains ( filtro )) ||
                    (!string.IsNullOrEmpty ( e.Modelo ) && e.Modelo.ToLower ( ).Contains ( filtro )) ||
                    (!string.IsNullOrEmpty ( e.Serial ) && e.Serial.ToLower ( ).Contains ( filtro ))
                );
                }

            var listaFiltrada = equiporentados.ToList();

            var usuario = User?.Identity?.Name ?? "Anonimo";
            _logger.LogInformation (
                "ExportarPdf ListaEquiposRentados | Usuario: {Usuario} | Filtro: {Filtro} | Cantidad: {Total}" ,
                usuario , search , listaFiltrada.Count
            );

            var pdfBytes = _reporteEquipoService.GenerarPdfListado(listaFiltrada); // ✅ ahora sí
            return File ( pdfBytes , "application/pdf" , "HOJA DE VIDA.pdf" );
            }
        }
    }
