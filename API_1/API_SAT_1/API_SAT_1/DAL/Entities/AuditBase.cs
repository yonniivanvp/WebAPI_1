using System.ComponentModel.DataAnnotations;

namespace API_SAT_1.DAL.Entities
{
    public class AuditBase
    {
        [Key] //DataAnnotation me sirve para definir que esta propiedad ID es un PK
        [Required] //Para campos obligatorios, osea que deben tener un valor (No permite nulls)
        public virtual Guid Id { get; set; } //Será la PK de tosas las tablas de mi BD
        public virtual DateTime? CreatedDate { get; set; } //Campos nuleables, notacion elvis (?) permite guardar nulos
        public virtual DateTime? ModifiedDate { get; set; } //Campos nuleables
    }
}
