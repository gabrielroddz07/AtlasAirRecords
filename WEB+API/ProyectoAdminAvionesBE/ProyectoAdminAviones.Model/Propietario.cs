using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAdminAviones.Model
{
    /// <summary>
    /// Propietario de una o más aeronaves: datos personales de contacto
    /// e identificación, con la lista de aviones de su titularidad.
    /// </summary>
    [Table("Propietario")]
    public class Propietario
    {
        /// <summary>Identificador único del propietario.</summary>
        [Key]
        public int IdPropietario { get; set; }

        /// <summary>Nombre completo o razón social.</summary>
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Nombre { get; set; }

        /// <summary>Documento de identificación (cédula, pasaporte, etc.).</summary>
        [Required(ErrorMessage = "El campo Identificación es requerido")]
        public string Identificacion { get; set; }

        /// <summary>Teléfono de contacto.</summary>
        [Required(ErrorMessage = "El campo Teléfono es requerido")]
        public string Telefono { get; set; }

        /// <summary>Correo electrónico de contacto.</summary>
        [Required(ErrorMessage = "El campo Correo es requerido")]
        [EmailAddress(ErrorMessage = "Debe ser un correo válido")]
        public string Correo { get; set; }

        /// <summary>Fecha de nacimiento del propietario (persona física).</summary>
        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        /// <summary>Aviones de titularidad de este propietario (navegación EF).</summary>
        public ICollection<Avion>? Aviones { get; set; }
    }
}
