using Microsoft.AspNetCore.Mvc;
using PaginaIst.Models;
using System.Diagnostics;

namespace PaginaIst.Areas.Usuario.Controllers
    {
    [Area( "Usuario" )]

    public class RecursosController : Controller

        {
        private readonly ILogger<RecursosController> _logger;

        public RecursosController ( ILogger<RecursosController> logger )
            {
            _logger = logger;
            }

        public IActionResult Index ()
            {
            return View();
            }

        public IActionResult Privacy ()
            {
            return View();
            }

        [ResponseCache( Duration = 0 , Location = ResponseCacheLocation.None , NoStore = true )]
        public IActionResult Error ()
            {
            return View( new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier } );
            }
        }
    }
