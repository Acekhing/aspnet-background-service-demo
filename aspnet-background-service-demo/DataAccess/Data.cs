using aspnet_background_service_demo.Models;

namespace aspnet_background_service_demo.DataAccess
{
    public static class Data
    {
        public static List<Subscriber> GetSubscribers() => new List<Subscriber>
        {
            new()
            {
                Id = 1,
                UserName = "Test",
                Email = "test@test.com",
                Gender = "Male",
                DeviceId = Guid.NewGuid().ToString(),
                Country = "Ghana",
                Age = 25
            }
        };
    }
}
