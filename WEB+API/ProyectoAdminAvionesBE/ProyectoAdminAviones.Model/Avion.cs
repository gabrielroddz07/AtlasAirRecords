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

        [Required(ErrorMessage = "El campo Matrícula es requerido")]
        public string Matricula { get; set; }

        [Range(1900, 2027, ErrorMessage = "El año de fabricación no es válido")]
        public int AnnoFabricacion { get; set; }

        public Estado Estado { get; set; }

        public int IdAerolinea { get; set; }
        public Aerolinea? Aerolinea { get; set; }

        public int IdPropietario { get; set; }
        public Propietario? Propietario { get; set; }
    }
}