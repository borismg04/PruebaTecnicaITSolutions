using DTO;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace PruebaTecnicaItSolution.Controllers
{
    [Route("")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IDevicesServices _devicesServices;

        public DevicesController(IDevicesServices devicesServices)
        {
            _devicesServices = devicesServices;
        }

        [HttpPost]
        [Route("Devices")]
        public IActionResult CreateDevices([FromBody] DeviceInputModel device)
        {
            var result = _devicesServices.CreateDevices(device);
            return StatusCode(result.statusCode, result);
        }

        [HttpGet]
        [Route("Devices/network/{network}")]
        public IActionResult GetDevicesNetwork(string network)
        {
            var result = _devicesServices.GetDevicesNetwork(network);
            return StatusCode(result.statusCode, result);
        }
    }
}
