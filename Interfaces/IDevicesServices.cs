using DTO;
using Entity;

namespace Interfaces
{
    public interface IDevicesServices
    {
        ResponseModel CreateDevices(DeviceInputModel device);
        ResponseModel GetDevicesNetwork(string network);
    }
}
