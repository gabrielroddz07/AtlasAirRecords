namespace ProyectoAdminAviones.Model
{
    /// <summary>
    /// Estado lógico de un avión en la flota: permite activar o desactivar
    /// sin eliminar el registro histórico.
    /// </summary>
    public enum Estado
    {
        /// <summary>El avión cuenta como parte activa de la flota.</summary>
        Activo = 1,

        /// <summary>El avión está dado de baja o inactivo en el sistema.</summary>
        Inactivo = 2,
    }
}
