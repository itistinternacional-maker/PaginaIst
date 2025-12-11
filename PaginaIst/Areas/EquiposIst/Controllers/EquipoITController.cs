using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaginaIst.AccesoDatos.Data.Repository.IRepository;
using PaginaIst.Models;
using PaginaIst.Services;            // IReporteEquipoService
using System;
using System.Linq;

namespace PaginaIst.Areas.Equiposist.Controllers
{
    [Area("EquiposIst")]
    public class EquipoITController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly ILogger<EquipoITController> _logger;
        private readonly IReporteEquipoService _reporteEquipoService;

        // ✅ ÚNICO CONSTRUCTOR con inyección de dependencias
        public EquipoITController(
            IContenedorTrabajo contenedorTrabajo,
            ILogger<EquipoITController> logger,
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
        public IActionResult Create(EquiposIst equipo)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.EquiposIst.Add(equipo);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(equipo);
        }

        // Editar equipo (GET)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var equipo = _contenedorTrabajo.EquiposIst.Get(id);
            if (equipo == null)
                return NotFound();

            return View(equipo);
        }

        // Editar equipo (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EquiposIst equipo)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.EquiposIst.Update(equipo);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(equipo);
        }

        // Eliminar equipo (AJAX - DELETE)
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.EquiposIst.Get(id);
            if (objFromDb == null)
                return Json(new { success = false, message = "Error eliminando equipo" });

            _contenedorTrabajo.EquiposIst.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Equipo eliminado correctamente" });
        }

        // Datos para DataTables
        [HttpGet]
        public IActionResult GetAll()
        {
            var equipos = _contenedorTrabajo.EquiposIst.GetAll();
            return Json(new { data = equipos });
        }

        // 🔹 PDF individual de un equipo
        [HttpGet]
        public IActionResult DetallePdf(int id)
        {
            var equipo = _contenedorTrabajo.EquiposIst.Get(id);
            if (equipo == null)
                return NotFound();

            var pdfBytes = _reporteEquipoService.GenerarPdfEquipo(equipo);
            var fileName = $"Equipo_{id}.pdf";

            return File(pdfBytes, "application/pdf", fileName);
        }

        // 🔹 PDF del listado (respeta el filtro del buscador)
        [HttpGet]
        public IActionResult ExportarPdf(string search)
        {
            var equipos = _contenedorTrabajo.EquiposIst.GetAll();

            if (!string.IsNullOrWhiteSpace(search))
            {
                var filtro = search.Trim().ToLower();

                // Filtro básico por campos clave
                equipos = equipos.Where(e =>
                    e.Placa.ToString().ToLower().Contains(filtro) ||
                    (!string.IsNullOrEmpty(e.Hostname) && e.Hostname.ToLower().Contains(filtro)) ||
                    (!string.IsNullOrEmpty(e.Marca) && e.Marca.ToLower().Contains(filtro)) ||
                    (!string.IsNullOrEmpty(e.Modelo) && e.Modelo.ToLower().Contains(filtro)) ||
                    (!string.IsNullOrEmpty(e.Serial) && e.Serial.ToLower().Contains(filtro))
                );
            }

            var listaFiltrada = equipos.ToList();

            // Log de auditoría
            var usuario = User?.Identity?.Name ?? "Anonimo";
            _logger.LogInformation(
                "ExportarPdf ListaEquipos | Usuario: {Usuario} | Filtro: {Filtro} | Cantidad: {Total}",
                usuario,
                search,
                listaFiltrada.Count
            );

            var pdfBytes = _reporteEquipoService.GenerarPdfListado(listaFiltrada);
            return File(pdfBytes, "application/pdf", "Lista_Equipos.pdf");
        }
    }
}


//using Microsoft.AspNetCore.Mvc;                   // 📌 Espacio de nombres para usar controladores en ASP.NET Core
//using PaginaIst.AccesoDatos.Data.Repository.IRepository; // 📌 Espacio de nombres para acceder al repositorio
//using PaginaIst.Models;                          // 📌 Espacio de nombres para el modelo de datos

//namespace PaginaIst.Areas.Equiposist.Controllers
//    {
//    [Area ( "EquiposIst" )] // 🔹 Define el área del sistema en la que se encuentra este controlador
//    public class EquipoITController : Controller
//        {
//        // 🔹 Campo privado que almacena la referencia al repositorio
//        private readonly IContenedorTrabajo _contenedorTrabajo;

//        // 🔹 Constructor que recibe una instancia del contenedor de trabajo (inyección de dependencias)
//        public EquipoITController ( IContenedorTrabajo contenedorTrabajo )
//            {
//            _contenedorTrabajo = contenedorTrabajo;  // ✅ Inicialización del repositorio
//            }

//        // 📌 Vista principal con la tabla de equipos
//        [HttpGet]
//        public IActionResult Index ()
//            {
//            return View ( ); // ✅ No se envían datos aquí porque el DataTable se encarga de hacerlo vía AJAX
//            }

//        // 📌 Vista para crear un equipo (GET)
//        [HttpGet]
//        public IActionResult Create ()
//            {
//            return View ( ); // ✅ Solo carga la vista del formulario de creación
//            }

//        // 📌 Método para crear un equipo (POST)
//        [HttpPost]
//        [ValidateAntiForgeryToken] // 🔒 Protege contra ataques CSRF
//        public IActionResult Create ( EquiposIst equipo )
//            {
//            if ( ModelState.IsValid ) // ✅ Verifica que los datos recibidos son válidos
//                {
//                _contenedorTrabajo.EquiposIst.Add ( equipo ); // 🔹 Guarda el nuevo equipo en la base de datos
//                _contenedorTrabajo.Save ( );                 // 🔹 Guarda los cambios
//                return RedirectToAction ( nameof ( Index ) );     // 🔹 Redirige a la página principal
//                }
//            return View ( equipo ); // 🔎 Si hay errores, recarga el formulario con los datos ingresados
//            }

//        // 📌 Vista para editar un equipo (GET)
//        [HttpGet]
//        public IActionResult Edit ( int id )
//            {
//            var equipo = _contenedorTrabajo.EquiposIst.Get(id); // 🔎 Obtiene el equipo según el ID proporcionado
//            if ( equipo == null )
//                {
//                return NotFound ( ); // 🔎 Si el equipo no existe, muestra un error 404
//                }
//            return View ( equipo ); // ✅ Carga la vista de edición con los datos del equipo
//            }

//        // 📌 Método para actualizar un equipo (POST)
//        [HttpPost]
//        [ValidateAntiForgeryToken] // 🔒 Protege contra ataques CSRF
//        public IActionResult Edit ( EquiposIst equipo )
//            {
//            if ( ModelState.IsValid ) // ✅ Verifica que los datos sean válidos
//                {
//                _contenedorTrabajo.EquiposIst.Update ( equipo ); // 🔹 Actualiza el equipo en la base de datos
//                _contenedorTrabajo.Save ( );                    // 🔹 Guarda los cambios
//                return RedirectToAction ( nameof ( Index ) );        // 🔹 Redirige a la página principal
//                }
//            return View ( equipo ); // 🔎 Si hay errores, recarga el formulario de edición
//            }

//        // 📌 Método para eliminar un equipo (AJAX - DELETE)
//        [HttpDelete]
//        public IActionResult Delete ( int id )
//            {
//            var objFromDb = _contenedorTrabajo.EquiposIst.Get(id); // 🔎 Obtiene el equipo según el ID
//            if ( objFromDb == null )
//                {
//                return Json ( new { success = false , message = "Error eliminando equipo" } ); // ❌ Si no se encuentra el equipo
//                }

//            _contenedorTrabajo.EquiposIst.Remove ( objFromDb ); // ✅ Elimina el equipo
//            _contenedorTrabajo.Save ( );                      // ✅ Guarda los cambios
//            return Json ( new { success = true , message = "Equipo eliminado correctamente" } ); // ✅ Mensaje de éxito
//            }

//        // 📌 ✅ Método para obtener todos los equipos (Para DataTables)
//        [HttpGet]
//        public IActionResult GetAll ()
//            {
//            // 🔹 Obtiene todos los equipos desde la base de datos
//            var equipos = _contenedorTrabajo.EquiposIst.GetAll();

//            // 🔎 Devuelve los datos en formato JSON con clave `data` para que DataTables pueda interpretarlos
//            return Json ( new { data = equipos } );
//            }
//        }
//    }
