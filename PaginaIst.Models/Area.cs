using System.ComponentModel.DataAnnotations;

namespace PaginaIst.Models
    {
    public class Area
        {
        [Key]
        public int Id { get; set; }

        [Required ( ErrorMessage = "El área es obligatorio" )]
        [Display ( Name = "Nombre Area" )]
        public string? Nombre { get; set; }

        }
    }