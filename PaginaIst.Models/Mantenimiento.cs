using System;
using System.ComponentModel.DataAnnotations;

namespace PaginaIst.Models
    {
    public class Mantenimiento
        {
        [Key]
        public int Id { get; set; }

        [Required ( ErrorMessage = "La fecha es obligatoria" )]
        [Display ( Name = "Fecha" )]
        public DateTime Fecha { get; set; } // Nuevo campo Fecha

        [Required ( ErrorMessage = "La placa es obligatoria" )]
        [Display ( Name = "Placa" )]
        public int Placa { get; set; } // Nuevo campo Placa}    

        [Required ( ErrorMessage = "El tipo mannto es obligatorio" )]
        [Display ( Name = "Tipo_mantto" )]
        public int Tipo_mantto { get; set; }

        [Required ( ErrorMessage = "El comentario es obligatorio" )]
        [Display ( Name = "Comentario" )]
        public string? Comentario { get; set; }

        [Required ( ErrorMessage = "La ruta es obligatoria" )]
        [Display ( Name = "Ruta_evidencias" )]
        public string Ruta_evidencias { get; set; }
        }
    }
