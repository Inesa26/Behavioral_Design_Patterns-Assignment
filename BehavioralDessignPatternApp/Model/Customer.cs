using BehavioralDessignPatternApp.Interface;
using BehavioralDessignPatternApp.Strategy;

namespace BehavioralDessignPatternApp.Model
{
    public class Customer : Person, IObserver
    {
        public string? Address { get; set; }
        public INotification? Notification;

        public Customer(int id, string name, string email, string phone, string address) : base(id, name, email, phone)
        {
            Address = address;
        }

        public Customer() { }

        public void HandleEvent(Order order)
        {
            if (Notification is not null)
            {
                Notification.SendNotification(order);
            }
        }

        public void SubscribeToNotifications(INotification notification)
        {
            Notification = notification;
        }

        public void UnsubscribeFromNotifications()
        {
            Notification = null;
        }
    }
}
