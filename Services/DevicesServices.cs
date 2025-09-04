using DataBase;
using DTO;
using Entity;
using Interfaces;
using System;
using System.Net;

namespace Services
{
    /// <summary>
    /// Servicio para la gestión de dispositivos de red
    /// Implementa la lógica de negocio para crear y consultar dispositivos
    /// </summary>
    public class DevicesServices : ResponseService, IDevicesServices
    {
        private readonly DataBaseInput _dataBaseInput;

        /// <summary>
        /// Constructor del servicio de dispositivos
        /// </summary>
        /// <param name="dataBaseInput">Contexto de base de datos inyectado</param>
        public DevicesServices(DataBaseInput dataBaseInput)
        {
            _dataBaseInput = dataBaseInput;
        }

        /// <summary>
        /// Crea un nuevo dispositivo de red en la base de datos
        /// </summary>
        /// <param name="device">Datos del dispositivo a crear</param>
        /// <returns>Respuesta con el dispositivo creado o información de error</returns>
        public ResponseModel CreateDevices(DeviceInputModel device)
        {
            try
            {
                // Mapeo de DTO a entidad
                var entity = new DevicesModel
                {
                    Host_name = device.Host_name,
                    Ip_address = device.Ip_address,
                    Network = device.Network,
                    Type = device.Type
                };

                // Guardar en base de datos
                _dataBaseInput.Devices.Add(entity);
                _dataBaseInput.SaveChanges();

                return CreateResult("Creado Correctamente", true, entity, 200);
            }
            catch (Exception ex)
            {
                return CreateResult(ex.Message, false, null, 500);
            }
        }

        /// <summary>
        /// Obtiene todos los dispositivos pertenecientes a una red específica
        /// </summary>
        /// <param name="network">Nombre de la red a consultar</param>
        /// <returns>Respuesta con lista de dispositivos o información de error</returns>
        public ResponseModel GetDevicesNetwork(string network)
        {
            try
            {
                // Validación de parámetro de entrada
                if (string.IsNullOrWhiteSpace(network))
                    return CreateResult("Parámetro 'network' inválido", false, null, 400);

                // Decodificación de URL para manejar caracteres especiales
                var decodedNetwork = WebUtility.UrlDecode(network).Trim();

                // Consulta y mapeo a DTO de salida
                var result = _dataBaseInput.Devices
                    .Where(x => x.Network == decodedNetwork)
                    .Select(d => new DevicesNetworkModel
                    {
                        Host_name = d.Host_name,
                        Ip_address = d.Ip_address,
                        Type = d.Type
                    })
                    .ToList();

                // Validación de resultados
                if (result == null || result.Count == 0)
                {
                    return CreateResult("No se encontraron dispositivos en la red especificada", false, null, 404);
                }

                return CreateResult("Consulta Exitosa", true, result, 200);
            }
            catch (Exception ex)
            {
                return CreateResult(ex.Message, false, null, 500);
            }
        }
    }
}