
using BehavioralDessignPatternApp.Model;

namespace BehavioralDessignPatternApp.Strategy
{
    public class CustomerEmailNotification : INotification
    {
        public void SendNotification(Order order)
        {
            Console.WriteLine($"Dear {order.Customer.Name},\n"
                 + $"We wanted to inform you that your order with Number {order.Id} is {order.Status}.\n"
                 + "Thank you for shopping with us!\n"
                 + "Sincerely,\n"
                 + "Your Bookstore Team\n");
        }
    }
}
