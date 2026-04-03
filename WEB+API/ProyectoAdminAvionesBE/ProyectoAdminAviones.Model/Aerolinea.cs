using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAdminAviones.Model
{
    [Table("Aerolinea")]
    public class Aerolinea
    {
        [Key]
        public int IdAerolinea { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es requerido")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El campo País es requerido")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "El campo Correo es requerido")]
        [EmailAddress(ErrorMessage = "Debe ser un correo válido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "La fecha de fundación es requerida")]
        [DataType(DataType.Date)]
        public DateTime FechaFundacion { get; set; }

        public ICollection<Avion>? Aviones { get; set; }
    }
}