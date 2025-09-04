using DataBase;
using DTO;
using Entity;
using Interfaces;
using System;
using System.Net;

namespace Services
{
    public class DevicesServices : ResponseService, IDevicesServices
    {
        private readonly DataBaseInput _dataBaseInput;

        public DevicesServices(DataBaseInput dataBaseInput)
        {
            _dataBaseInput = dataBaseInput;
        }

        public ResponseModel CreateDevices(DeviceInputModel device)
        {
            try
            {
                var entity = new DevicesModel
                {
                    Host_name = device.Host_name,
                    Ip_address = device.Ip_address,
                    Network = device.Network,
                    Type = device.Type
                };

                _dataBaseInput.Devices.Add(entity);
                _dataBaseInput.SaveChanges();

                return CreateResult("Creado Correctamente", true, entity, 200);
            }
            catch (Exception ex)
            {
                return CreateResult(ex.Message, false, null, 500);
            }
        }

        public ResponseModel GetDevicesNetwork(string network)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(network))
                    return CreateResult("Parámetro 'network' inválido", false, null, 400);

                var decodedNetwork = WebUtility.UrlDecode(network).Trim();

                var result = _dataBaseInput.Devices
                    .Where(x => x.Network == decodedNetwork)
                    .Select(d => new DevicesNetworkModel
                    {
                        Host_name = d.Host_name,
                        Ip_address = d.Ip_address,
                        Type = d.Type
                    })
                    .ToList();

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