using System;
using System.ComponentModel.DataAnnotations;

namespace PaginaIst.Models
    {
    public class Historia_Mantenimiento
        {
        [Key]
        public int Id { get; set; }

        [Required ( ErrorMessage = "El ID equipo obligatorio" )]
        [Display ( Name = "ID equipo" )]
        public int ID_EQUIPO { get; set; }

        [Required ( ErrorMessage = "El ID Mantenimiento obligatorio" )]
        [Display ( Name = "ID Mantenimiento" )]
        public int ID_MTTO { get; set; }

        [Display ( Name = "Fecha de Mantenimiento" )]
        public DateTime Fecha_MTTO { get; set; }

        [Display ( Name = "Fecha de Mantenimiento Futura" )]
        public DateTime Fecha_MTTO_FUTURO { get; set; }

        }
    }
