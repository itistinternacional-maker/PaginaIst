using System;
using System.ComponentModel.DataAnnotations;

namespace PaginaIst.Models
    {
    public class Software
        {
        [Key]
        public int id { get; set; }

        [Required ( ErrorMessage = "El nombre es obligatorio" )]
        [Display ( Name = "Nombre" )]
        public string NOMBRE { get; set; }

        [Required ( ErrorMessage = "La Llave Licencia es obligatoria" )]
        [Display ( Name = "Llave Licencia" )]
        public string LLAVE_LICENCIA { get; set; }

        [Required ( ErrorMessage = "El ID Tipo Software es obligatoria" )]
        [Display ( Name = "ID Tipo Software" )]
        public string ID_TIPO_SOFTWARE { get; set; }

        [Display ( Name = "Fecha de Compra" )]
        public DateTime? FECHA_COMPRA { get; set; }

        [Required ( ErrorMessage = "El NIT Proveedor es obligatoria" )]
        [Display ( Name = "NIT Proveedor" )]
        public string NIT_PROVEEDOR { get; set; }
        }
    }
