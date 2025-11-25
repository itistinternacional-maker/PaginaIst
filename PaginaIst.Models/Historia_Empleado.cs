using System;
using System.ComponentModel.DataAnnotations;

namespace PaginaIst.Models
    {
    public class Historia_Empleado
        {
        [Key]
        public int Id { get; set; }

        [Required ( ErrorMessage = "El ID Empleado obligatorio" )]
        [Display ( Name = "ID Empleado" )]
        public int ID_EMPLEADO { get; set; }

        [Display ( Name = "Fecha de Ingreso" )]
        public DateTime? FECHA_INGRESO { get; set; }

        [Display ( Name = "Fecha de Retiro" )]
        public DateTime? FECHA_RETIRO { get; set; }

        }
    }
