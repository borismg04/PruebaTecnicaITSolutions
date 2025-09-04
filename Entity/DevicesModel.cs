namespace Entity
{
    public class DevicesModel
    {
        private static int _id = 0;

        public int Id { get; private set; }
        public string? Host_name { get; set; }
        public string? Ip_address { get; set; }
        public string? Network { get; set; }
        public string? Type { get; set; }

        public DevicesModel()
        {
            Id = ++_id;
        }
    }
}
