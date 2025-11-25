using Microsoft.AspNetCore.Mvc; // ✅ Espacio de nombres para controladores y acciones en ASP.NET Core
using PaginaIst.AccesoDatos.Data.Repository.IRepository; // ✅ Espacio de nombres del repositorio
using PaginaIst.Models; // ✅ Espacio de nombres del modelo `PaginasIst`

namespace PaginaIst.Areas.Admin.Controllers
    {
    [Area ( "Admin" )] // ✅ Define el área a la que pertenece este controlador
    public class ContrasenaController : Controller
        {
        // 🔹 Campo privado que almacena la referencia al repositorio
        private readonly IContenedorTrabajo _contenedorTrabajo;

        // 🔹 Constructor que recibe el contenedor de trabajo mediante inyección de dependencias
        public ContrasenaController ( IContenedorTrabajo contenedorTrabajo )
            {
            _contenedorTrabajo = contenedorTrabajo;
            }

        // ✅ Vista principal (GET)
        [HttpGet]
        public IActionResult Index ()
            {
            return View ( ); // ✅ No pasa datos porque el DataTable se encarga de cargarlos vía AJAX
            }

        // ✅ Vista para crear un nuevo registro (GET)
        [HttpGet]
        public IActionResult Create ()
            {
            return View ( ); // ✅ Carga la vista del formulario de creación
            }

        // ✅ Acción para crear un nuevo registro (POST)
        [HttpPost]
        [ValidateAntiForgeryToken] // 🔒 Protección contra CSRF
        public IActionResult Create ( PaginasIst paginasIst )
            {
            if ( ModelState.IsValid ) // ✅ Verifica que los datos recibidos son válidos
                {
                // 🔹 Lógica para guardar el nuevo registro en la base de datos
                _contenedorTrabajo.PaginasIst.Add ( paginasIst );
                _contenedorTrabajo.Save ( ); // ✅ Guarda los cambios
                return RedirectToAction ( nameof ( Index ) ); // 🔹 Redirige a la página principal
                }

            // 🔎 Si hay errores, se recarga el formulario con los datos ingresados
            return View ( paginasIst );
            }

        // ✅ Vista para editar un registro (GET)
        [HttpGet]
        public IActionResult Edit ( int id )
            {
            // 🔹 Busca el registro en la base de datos por su ID
            PaginasIst paginaIst = _contenedorTrabajo.PaginasIst.Get(id);

            if ( paginaIst == null )
                {
                return NotFound ( ); // 🔎 Si el registro no existe, se muestra un error 404
                }

            return View ( paginaIst ); // ✅ Carga la vista con los datos del registro
            }

        // ✅ Acción para actualizar un registro existente (POST)
        [HttpPost]
        [ValidateAntiForgeryToken] // 🔒 Protección contra CSRF
        public IActionResult Edit ( PaginasIst paginasIst )
            {
            if ( ModelState.IsValid ) // ✅ Verifica que los datos sean válidos
                {
                // 🔹 Lógica para actualizar el registro en la base de datos
                _contenedorTrabajo.PaginasIst.Update ( paginasIst );
                _contenedorTrabajo.Save ( ); // ✅ Guarda los cambios
                return RedirectToAction ( nameof ( Index ) ); // 🔹 Redirige a la página principal
                }

            // 🔎 Si hay errores, recarga el formulario con los datos ingresados
            return View ( paginasIst );
            }

        #region Llamadas a la API

        // ✅ API para obtener todos los registros en formato JSON (DataTables)
        [HttpGet]
        public IActionResult GetAll ()
            {
            // 🔹 Retorna los datos en formato JSON con clave `data` (necesario para DataTables)
            return Json ( new { data = _contenedorTrabajo.PaginasIst.GetAll ( ) } );
            }

        // ✅ API para eliminar un registro
        [HttpDelete]
        public IActionResult Delete ( int id )
            {
            // 🔹 Busca el registro en la base de datos por su ID
            var objFromDb = _contenedorTrabajo.PaginasIst.Get(id);

            if ( objFromDb == null )
                {
                return Json ( new { success = false , message = "Error borrando categoría" } ); // ❌ Error si no se encuentra el registro
                }

            // 🔹 Elimina el registro
            _contenedorTrabajo.PaginasIst.Remove ( objFromDb );
            _contenedorTrabajo.Save ( ); // ✅ Guarda los cambios

            return Json ( new { success = true , message = "Categoría Borrada Correctamente" } ); // ✅ Mensaje de éxito
            }

        #endregion
        }
    }
