using System.ComponentModel.DataAnnotations;
using System.Timers;

namespace API_SAT_1.DAL.Entities
{
    public class Country : AuditBase
    {
        [Display(Name = "Pais")] // Para pintar el nombre en el FrontEnd
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres")] //Longitud de caracteres maxima que esta propiedad me permite tener, Ej: varchar(50)
        [Required(ErrorMessage = "¡El campo {0} es obligatorio!")]
        public String Name { get; set; } //varchar(50)
    }
}
