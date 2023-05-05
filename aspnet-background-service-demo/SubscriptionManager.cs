using aspnet_background_service_demo.DataAccess;
using aspnet_background_service_demo.Models;

namespace aspnet_background_service_demo
{
    public class SubscriptionManager
    {
        private IEnumerable<Subscriber> _subscribers;


        public SubscriptionManager() => _subscribers = Data.GetSubscribers();

        public virtual IEnumerable<Subscriber> GetAllSubscribers() => _subscribers;

    }
}