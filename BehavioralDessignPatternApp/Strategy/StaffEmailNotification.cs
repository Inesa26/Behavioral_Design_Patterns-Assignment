using BehavioralDessignPatternApp.Interface;
using BehavioralDessignPatternApp.Model;

namespace BehavioralDessignPatternApp.Strategy
{
    public class StaffEmailNotification : INotification
    {
        public void SendNotification(Order order)
        {
            Console.WriteLine($"Dear {order?.Staff?.Name},\n"
            + $"Order with Number {order?.Id} status is {order?.Status}.\n"
            + "Please proceed with the necessary actions.\n"
            + "Thank you for your attention!\n"
            + "Sincerely,\n"
            + "Your Bookstore Team\n");
        }
    }
}
