using BehavioralDessignPatternApp.Interface;
using BehavioralDessignPatternApp.Service;
using BehavioralDessignPatternApp.Strategy;

namespace BehavioralDessignPatternApp.Model
{
    public class Staff : Person, IObserver
    {
        public bool Available { get; set; } = true;
        public INotification? Notification;

        public Staff(int id, string name, string email, string phone, bool available) : base(id, name, email, phone)
        {
            Available = available;
        }

        public Staff() { }

        public void HandleEvent(Order order)
        {
            if (Notification is not null)
            {
                Notification.SendNotification(order);
            }
        }

        public void SubscribeToNotifications()
        {
            Notification = new StaffEmailNotification();
        }

        public void UnsubscribeFromNotifications()
        {
            Notification = null;
        }
    }
}
