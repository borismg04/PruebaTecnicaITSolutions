namespace Entity
{
    /// <summary>
    /// Entidad que representa un dispositivo de red en el sistema
    /// </summary>
    public class DevicesModel
    {
        private static int _id = 0;

        /// <summary>
        /// Identificador único del dispositivo (generado automáticamente)
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Nombre del host del dispositivo
        /// </summary>
        public string? Host_name { get; set; }

        /// <summary>
        /// Dirección IP del dispositivo
        /// </summary>
        public string? Ip_address { get; set; }

        /// <summary>
        /// Red a la que pertenece el dispositivo
        /// </summary>
        public string? Network { get; set; }

        /// <summary>
        /// Tipo de dispositivo (switch, router, firewall, server)
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        /// Constructor que asigna automáticamente un ID único al dispositivo
        /// </summary>
        public DevicesModel()
        {
            Id = ++_id;
        }
    }
}
