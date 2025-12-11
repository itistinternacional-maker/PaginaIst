using PaginaIst.Models;
using System.Collections.Generic;

namespace PaginaIst.Services
{
    /// <summary>
    /// Servicio para generar reportes PDF de equipos.
    /// </summary>
    public interface IReporteEquipoService
    {
        /// <summary>Genera un PDF con la ficha de un solo equipo.</summary>
        byte[] GenerarPdfEquipo(EquiposIst equipo);

        /// <summary>Genera un PDF con la lista de equipos.</summary>
        byte[] GenerarPdfListado(IEnumerable<EquiposIst> equipos);
    }
}
