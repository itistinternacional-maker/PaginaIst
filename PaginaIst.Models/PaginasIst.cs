using System.ComponentModel.DataAnnotations;

namespace PaginaIst.Models
    {
    public class PaginasIst
        {
        [Key]
        public int Id { get; set; }

        [Required ( ErrorMessage = "La URL es obligatorio" )]
        [Display ( Name = "Nombre Url" )]
        public string Url { get; set; }

        [Required ( ErrorMessage = "La descripción es obligatoria" )]
        [Display ( Name = "Descripción" )]
        public string Descripcion { get; set; }

        [Display ( Name = "Observación" )]
        public string Observacion { get; set; }

        [Required ( ErrorMessage = "El Usuario es obligatorio" )]
        [Display ( Name = "Nombre Usuario" )]
        public string Usuario { get; set; }

        [Required ( ErrorMessage = "La Contraseña es obligatoria" )]
        [Display ( Name = "Contraseña" )]
        public string Contraseña { get; set; }
        }
    }
