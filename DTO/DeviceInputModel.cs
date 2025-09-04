using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class DeviceInputModel
    {
        private string[] validateType = ["switch", "router", "firewall", "server"];
        private string? _type;

        public int Id { get; set; }
        public string? Host_name { get; set; }
        public string? Ip_address { get; set; }
        public string? Network { get; set; }

        [RegularExpression("^(switch|router|firewall|server)$", ErrorMessage = "Tipo inválido. Valores permitidos: switch, router, firewall, server")]
        public string? Type { get; set; }
    }
}
