using DTO;
using Entity;

namespace Interfaces
{
    /// <summary>
    /// Interfaz que define el contrato para el servicio de gestión de dispositivos de red
    /// </summary>
    public interface IDevicesServices
    {
        /// <summary>
        /// Crea un nuevo dispositivo de red
        /// </summary>
        /// <param name="device">Datos del dispositivo a crear</param>
        /// <returns>Respuesta estándar con el resultado de la operación</returns>
        ResponseModel CreateDevices(DeviceInputModel device);

        /// <summary>
        /// Obtiene todos los dispositivos pertenecientes a una red específica
        /// </summary>
        /// <param name="network">Nombre de la red a consultar</param>
        /// <returns>Respuesta estándar con la lista de dispositivos encontrados</returns>
        ResponseModel GetDevicesNetwork(string network);
    }
}
