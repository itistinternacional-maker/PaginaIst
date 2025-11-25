using Microsoft.AspNetCore.Mvc;                   // 📌 Espacio de nombres para usar controladores en ASP.NET Core
using PaginaIst.AccesoDatos.Data.Repository.IRepository; // 📌 Espacio de nombres para acceder al repositorio
using PaginaIst.Models;                          // 📌 Espacio de nombres para el modelo de datos

namespace PaginaIst.Areas.Equiposist.Controllers
    {
    [Area ( "EquiposIst" )] // 🔹 Define el área del sistema en la que se encuentra este controlador
    public class EquipoITController : Controller
        {
        // 🔹 Campo privado que almacena la referencia al repositorio
        private readonly IContenedorTrabajo _contenedorTrabajo;

        // 🔹 Constructor que recibe una instancia del contenedor de trabajo (inyección de dependencias)
        public EquipoITController ( IContenedorTrabajo contenedorTrabajo )
            {
            _contenedorTrabajo = contenedorTrabajo;  // ✅ Inicialización del repositorio
            }

        // 📌 Vista principal con la tabla de equipos
        [HttpGet]
        public IActionResult Index ()
            {
            return View ( ); // ✅ No se envían datos aquí porque el DataTable se encarga de hacerlo vía AJAX
            }

        // 📌 Vista para crear un equipo (GET)
        [HttpGet]
        public IActionResult Create ()
            {
            return View ( ); // ✅ Solo carga la vista del formulario de creación
            }

        // 📌 Método para crear un equipo (POST)
        [HttpPost]
        [ValidateAntiForgeryToken] // 🔒 Protege contra ataques CSRF
        public IActionResult Create ( EquiposIst equipo )
            {
            if ( ModelState.IsValid ) // ✅ Verifica que los datos recibidos son válidos
                {
                _contenedorTrabajo.EquiposIst.Add ( equipo ); // 🔹 Guarda el nuevo equipo en la base de datos
                _contenedorTrabajo.Save ( );                 // 🔹 Guarda los cambios
                return RedirectToAction ( nameof ( Index ) );     // 🔹 Redirige a la página principal
                }
            return View ( equipo ); // 🔎 Si hay errores, recarga el formulario con los datos ingresados
            }

        // 📌 Vista para editar un equipo (GET)
        [HttpGet]
        public IActionResult Edit ( int id )
            {
            var equipo = _contenedorTrabajo.EquiposIst.Get(id); // 🔎 Obtiene el equipo según el ID proporcionado
            if ( equipo == null )
                {
                return NotFound ( ); // 🔎 Si el equipo no existe, muestra un error 404
                }
            return View ( equipo ); // ✅ Carga la vista de edición con los datos del equipo
            }

        // 📌 Método para actualizar un equipo (POST)
        [HttpPost]
        [ValidateAntiForgeryToken] // 🔒 Protege contra ataques CSRF
        public IActionResult Edit ( EquiposIst equipo )
            {
            if ( ModelState.IsValid ) // ✅ Verifica que los datos sean válidos
                {
                _contenedorTrabajo.EquiposIst.Update ( equipo ); // 🔹 Actualiza el equipo en la base de datos
                _contenedorTrabajo.Save ( );                    // 🔹 Guarda los cambios
                return RedirectToAction ( nameof ( Index ) );        // 🔹 Redirige a la página principal
                }
            return View ( equipo ); // 🔎 Si hay errores, recarga el formulario de edición
            }

        // 📌 Método para eliminar un equipo (AJAX - DELETE)
        [HttpDelete]
        public IActionResult Delete ( int id )
            {
            var objFromDb = _contenedorTrabajo.EquiposIst.Get(id); // 🔎 Obtiene el equipo según el ID
            if ( objFromDb == null )
                {
                return Json ( new { success = false , message = "Error eliminando equipo" } ); // ❌ Si no se encuentra el equipo
                }

            _contenedorTrabajo.EquiposIst.Remove ( objFromDb ); // ✅ Elimina el equipo
            _contenedorTrabajo.Save ( );                      // ✅ Guarda los cambios
            return Json ( new { success = true , message = "Equipo eliminado correctamente" } ); // ✅ Mensaje de éxito
            }

        // 📌 ✅ Método para obtener todos los equipos (Para DataTables)
        [HttpGet]
        public IActionResult GetAll ()
            {
            // 🔹 Obtiene todos los equipos desde la base de datos
            var equipos = _contenedorTrabajo.EquiposIst.GetAll();

            // 🔎 Devuelve los datos en formato JSON con clave `data` para que DataTables pueda interpretarlos
            return Json ( new { data = equipos } );
            }
        }
    }
