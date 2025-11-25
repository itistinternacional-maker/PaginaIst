using System.ComponentModel.DataAnnotations;

namespace PaginaIst.Models
    {
    public class Recursos
        {
        [Key]
        public int Id { get; set; }

        [Required ( ErrorMessage = "El nombre es obligatorio" )]
        [Display ( Name = "Nombre" )]
        public string Nombre { get; set; }

        [Required ( ErrorMessage = "La descripción es obligatoria" )]
        [Display ( Name = "Descripción" )]
        public string Descripcion { get; set; }

        }
    }
