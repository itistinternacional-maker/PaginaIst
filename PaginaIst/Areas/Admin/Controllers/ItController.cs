using Microsoft.AspNetCore.Mvc;
using PaginaIst.AccesoDatos.Data.Repository.IRepository;
using PaginaIst.Models;

namespace PaginaIst.Areas.Admin.Controllers
    {
    //[Authorize(Roles = "Administrador")]
    [Area ( "Admin" )]
    public class ItController : Controller
        {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public ItController ( IContenedorTrabajo contenedorTrabajo )
            {
            _contenedorTrabajo = contenedorTrabajo;
            }

        [HttpGet]
        public IActionResult Index ()
            {
            return View ( );
            }

        //[AllowAnonymous]
        [HttpGet]
        public IActionResult Create ()
            {
            return View ( );
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create ( PaginaIst.Models.Mantenimiento mantenimiento )
            {
            if ( ModelState.IsValid )
                {
                //Logica para guardar en BD
                _contenedorTrabajo.Mantenimiento.Add ( mantenimiento );
                _contenedorTrabajo.Save ( );
                return RedirectToAction ( nameof ( Index ) );
                }

            return View ( mantenimiento );
            }

        [HttpGet]
        public IActionResult Edit ( int id )
            {
            PaginaIst.Models.Mantenimiento mantenimiento = new PaginaIst.Models.Mantenimiento();
            mantenimiento = _contenedorTrabajo.Mantenimiento.Get ( id );
            if ( mantenimiento == null )
                {
                return NotFound ( );
                }

            return View ( mantenimiento );
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit ( PaginaIst.Models.Mantenimiento mantenimiento )
            {
            if ( ModelState.IsValid )
                {
                //Logica para actualizar en BD
                _contenedorTrabajo.Mantenimiento.Update ( mantenimiento );
                _contenedorTrabajo.Save ( );
                return RedirectToAction ( nameof ( Index ) );
                }

            return View ( mantenimiento );
            }



        #region Llamadas a la API
        [HttpGet]
        public IActionResult GetAll ()
            {
            return Json ( new { data = _contenedorTrabajo.Mantenimiento.GetAll ( ) } );
            }


        [HttpDelete]
        public IActionResult Delete ( int id )
            {
            var objFromDb = _contenedorTrabajo.Mantenimiento.Get( id );
            if ( objFromDb == null )
                {
                return Json ( new { success = false , message = "Error borrando mantenimiento" } );
                }

            _contenedorTrabajo.Mantenimiento.Remove ( objFromDb );
            _contenedorTrabajo.Save ( );
            return Json ( new { success = true , message = "Categoría Borrada Correctamente" } );
            }

        #endregion
        }
    }
