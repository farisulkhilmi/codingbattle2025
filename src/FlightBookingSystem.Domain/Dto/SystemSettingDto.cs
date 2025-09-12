namespace FlightBookingSystem.Domain.Dto
{
    public class SystemSettingsDto
    {
        public List<Setting> Settings { get; set; }
    }

    public class Setting
    {
        public string Key { get; set; }
        public int Value { get; set; }
    }
}
