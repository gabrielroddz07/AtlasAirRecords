using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAdminAviones.Model
{
    [Table("Avion")]
    public class Avion
    {
        [Key]
        public int IdAvion { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Modelo es requerido")]
        public string Modelo { get; set; }

        public Estado Estado { get; set; }

        public int IdAerolinea { get; set; }
        public Aerolinea? Aerolinea { get; set; }
    }
}