using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAdminAviones.Model
{
    [Table("Propietario")]
    public class Propietario
    {
        [Key]
        public int IdPropietario { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Identificación es requerido")]
        public string Identificacion { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es requerido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo Correo es requerido")]
        [EmailAddress(ErrorMessage = "Debe ser un correo válido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        public ICollection<Avion>? Aviones { get; set; }
    }
}