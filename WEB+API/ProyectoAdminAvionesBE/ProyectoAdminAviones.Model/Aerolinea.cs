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

        [Required(ErrorMessage = "El campo Telefono es requerido")]
        public string Telefono { get; set; }

        public ICollection<Avion>? Aviones { get; set; }
    }
}