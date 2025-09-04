using DTO;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PruebaTecnicaItSolution.Controllers
{
    /// <summary>
    /// Controlador para la gestión de dispositivos de red
    /// </summary>
    [Route("")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IDevicesServices _devicesServices;

        /// <summary>
        /// Constructor del controlador de dispositivos
        /// </summary>
        /// <param name="devicesServices">Servicio de dispositivos inyectado</param>
        public DevicesController(IDevicesServices devicesServices)
        {
            _devicesServices = devicesServices;
        }

        /// <summary>
        /// Crea un nuevo dispositivo de red
        /// </summary>
        /// <param name="device">Datos del dispositivo a crear</param>
        /// <returns>Respuesta con el dispositivo creado o error</returns>
        /// <response code="200">Dispositivo creado exitosamente</response>
        /// <response code="400">Datos de entrada inválidos</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpPost]
        [Route("Devices")]
        [ProducesResponseType(typeof(ResponseModel), 200)]
        [ProducesResponseType(typeof(ResponseModel), 400)]
        [ProducesResponseType(typeof(ResponseModel), 500)]
        public IActionResult CreateDevices([FromBody] DeviceInputModel device)
        {
            var result = _devicesServices.CreateDevices(device);
            return StatusCode(result.statusCode, result);
        }

        /// <summary>
        /// Obtiene todos los dispositivos de una red específica
        /// </summary>
        /// <param name="network">Nombre de la red a consultar</param>
        /// <returns>Lista de dispositivos de la red especificada</returns>
        /// <response code="200">Consulta exitosa con dispositivos encontrados</response>
        /// <response code="400">Parámetro de red inválido</response>
        /// <response code="404">No se encontraron dispositivos en la red</response>
        /// <response code="500">Error interno del servidor</response>
        [HttpGet]
        [Route("Devices/network/{network}")]
        [ProducesResponseType(typeof(ResponseModel), 200)]
        [ProducesResponseType(typeof(ResponseModel), 400)]
        [ProducesResponseType(typeof(ResponseModel), 404)]
        [ProducesResponseType(typeof(ResponseModel), 500)]
        public IActionResult GetDevicesNetwork(string network)
        {
            var result = _devicesServices.GetDevicesNetwork(network);
            return StatusCode(result.statusCode, result);
        }
    }
}
