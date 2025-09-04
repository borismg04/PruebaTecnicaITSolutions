using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    /// <summary>
    /// Contexto de base de datos para la aplicación de gestión de dispositivos
    /// Maneja la configuración y acceso a datos usando Entity Framework Core
    /// </summary>
    public class DataBaseInput : DbContext
    {
        /// <summary>
        /// Constructor del contexto de base de datos
        /// </summary>
        /// <param name="options">Opciones de configuración del DbContext</param>
        public DataBaseInput(DbContextOptions<DataBaseInput> options) : base(options)
        {
        }

        /// <summary>
        /// Conjunto de entidades de dispositivos en la base de datos
        /// </summary>
        public DbSet<DevicesModel> Devices { get; set; }
    }
}
