using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAdminAviones.Model
{
    /// <summary>
    /// Aerolínea registrada: datos de contacto, país y fecha de fundación,
    /// con la colección de aviones vinculados a esa compañía.
    /// </summary>
    [Table("Aerolinea")]
    public class Aerolinea
    {
        /// <summary>Identificador único de la aerolínea.</summary>
        [Key]
        public int IdAerolinea { get; set; }

        /// <summary>Nombre comercial o legal de la aerolínea.</summary>
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Nombre { get; set; }

        /// <summary>Teléfono de contacto principal.</summary>
        [Required(ErrorMessage = "El campo Teléfono es requerido")]
        public string Telefono { get; set; }

        /// <summary>País de origen o sede principal.</summary>
        [Required(ErrorMessage = "El campo País es requerido")]
        public string Pais { get; set; }

        /// <summary>Correo electrónico de contacto.</summary>
        [Required(ErrorMessage = "El campo Correo es requerido")]
        [EmailAddress(ErrorMessage = "Debe ser un correo válido")]
        public string Correo { get; set; }

        /// <summary>Fecha en que se fundó la aerolínea.</summary>
        [Required(ErrorMessage = "La fecha de fundación es requerida")]
        [DataType(DataType.Date)]
        public DateTime FechaFundacion { get; set; }

        /// <summary>Aviones asociados a esta aerolínea (navegación EF).</summary>
        public ICollection<Avion>? Aviones { get; set; }
    }
}
