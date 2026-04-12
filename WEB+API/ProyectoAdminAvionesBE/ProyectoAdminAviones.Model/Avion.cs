using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoAdminAviones.Model
{
    /// <summary>
    /// Representa un avión registrado en el sistema: datos técnicos, estado operativo
    /// y vínculos con la aerolínea que lo opera y el propietario legal.
    /// </summary>
    [Table("Avion")]
    public class Avion
    {
        /// <summary>Identificador único del avión en base de datos.</summary>
        [Key]
        public int IdAvion { get; set; }

        /// <summary>Nombre o denominación comercial del avión.</summary>
        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Nombre { get; set; }

        /// <summary>Modelo o familia del avión (fabricante y tipo).</summary>
        [Required(ErrorMessage = "El campo Modelo es requerido")]
        public string Modelo { get; set; }

        /// <summary>Matrícula o registro oficial de la aeronave.</summary>
        [Required(ErrorMessage = "El campo Matrícula es requerido")]
        public string Matricula { get; set; }

        /// <summary>Año en que se fabricó la aeronave.</summary>
        [Range(1900, 2027, ErrorMessage = "El año de fabricación no es válido")]
        public int AnnoFabricacion { get; set; }

        /// <summary>Indica si el avión está activo en la flota o dado de baja lógica.</summary>
        public Estado Estado { get; set; }

        /// <summary>Clave foránea hacia la aerolínea asociada.</summary>
        public int IdAerolinea { get; set; }

        /// <summary>Aerolínea que opera o administra este avión (navegación EF).</summary>
        public Aerolinea? Aerolinea { get; set; }

        /// <summary>Clave foránea hacia el propietario del avión.</summary>
        public int IdPropietario { get; set; }

        /// <summary>Persona o entidad propietaria del avión (navegación EF).</summary>
        public Propietario? Propietario { get; set; }
    }
}
