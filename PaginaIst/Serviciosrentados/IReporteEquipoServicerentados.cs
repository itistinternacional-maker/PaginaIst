using PaginaIst.Models;
using System.Collections.Generic;

namespace PaginaIst.Servicesrentados
{
    /// <summary>
    /// Servicio para generar reportes PDF de equipos.
    /// </summary>
    public interface IReporteEquipoServicerentados
    {
        /// <summary>Genera un PDF con la ficha de un solo equipo.</summary>
        byte[] GenerarPdfEquipo(EquiposRentados equiporentados);

        /// <summary>Genera un PDF con la lista de equipos.</summary>
        byte[] GenerarPdfListado(IEnumerable<EquiposRentados> equiposrentados);
    }
}
