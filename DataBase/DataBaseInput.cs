using Entity;
using Microsoft.EntityFrameworkCore;

namespace DataBase
{
    public class DataBaseInput : DbContext
    {
        public DataBaseInput(DbContextOptions<DataBaseInput> options) : base(options)
        {
        }

        public DbSet<DevicesModel> Devices { get; set; }
    }
}
