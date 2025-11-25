using System.ComponentModel.DataAnnotations;

namespace PaginaIst.Models
    {
    public class Empleados
        {
        [Key]
        public string cedula { get; set; }

        [Required ( ErrorMessage = "El nombre obligatorio" )]
        [Display ( Name = "Nombre " )]
        public string nombre { get; set; }

        [Required ( ErrorMessage = "El apellido obligatoria" )]
        [Display ( Name = "Apellido" )]
        public string Apellido { get; set; }

        [Required ( ErrorMessage = "El cargo es obligatoria" )]
        [Display ( Name = "Cargo" )]
        public string Cargo { get; set; }

        [Display ( Name = "Fecha Ingreso" )]
        public string Fecha_Ingreso { get; set; }

        [Display ( Name = "Fecha Salida" )]
        public string Fecha_Salida { get; set; }

        [Required ( ErrorMessage = "La ID área es obligatoria" )]
        [Display ( Name = "Id área" )]
        public string area { get; set; }

        [Required ( ErrorMessage = "La dirección área es obligatoria" )]
        [Display ( Name = "Dirección Residencia" )]
        public string direccion { get; set; }

        [Display ( Name = "ID Salario" )]
        public string Id_Salario { get; set; }

        [Required ( ErrorMessage = "La placa es obligatoria" )]
        [Display ( Name = "Placa" )]
        public string placa { get; set; }
        }
    }
