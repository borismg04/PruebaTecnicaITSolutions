using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /// <summary>
    /// Modelo de respuesta para consultas de dispositivos por red
    /// Contiene solo la información relevante para mostrar al cliente
    /// </summary>
    public class DevicesNetworkModel
    {
        /// <summary>
        /// Nombre del host del dispositivo
        /// </summary>
        /// <example>router-main</example>
        public string? Host_name { get; set; }

        /// <summary>
        /// Dirección IP del dispositivo
        /// </summary>
        /// <example>192.168.1.1</example>
        public string? Ip_address { get; set; }

        /// <summary>
        /// Tipo de dispositivo de red
        /// </summary>
        /// <example>router</example>
        public string? Type { get; set; }
    }
}
