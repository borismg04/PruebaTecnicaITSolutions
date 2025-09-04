using System.ComponentModel.DataAnnotations;

namespace DTO
{
    /// <summary>
    /// Modelo de entrada para la creación de dispositivos de red
    /// </summary>
    public class DeviceInputModel
    {
        private string[] validateType = ["switch", "router", "firewall", "server"];

        /// <summary>
        /// Identificador del dispositivo (opcional para creación)
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del host del dispositivo
        /// </summary>
        /// <example>switch-01</example>
        public string? Host_name { get; set; }

        /// <summary>
        /// Dirección IP del dispositivo
        /// </summary>
        /// <example>192.168.1.10</example>
        public string? Ip_address { get; set; }

        /// <summary>
        /// Red a la que pertenece el dispositivo
        /// </summary>
        /// <example>LAN-Principal</example>
        public string? Network { get; set; }

        /// <summary>
        /// Tipo de dispositivo de red
        /// </summary>
        /// <example>switch</example>
        [RegularExpression("^(switch|router|firewall|server)$", ErrorMessage = "Tipo inválido. Valores permitidos: switch, router, firewall, server")]
        public string? Type { get; set; }
    }
}
