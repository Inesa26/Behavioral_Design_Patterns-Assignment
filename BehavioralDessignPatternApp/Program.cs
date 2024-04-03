using BehavioralDessignPatternApp.Model;
using BehavioralDessignPatternApp.Service;
using BehavioralDessignPatternApp.Strategy;

namespace BehavioralDessignPatternApp
{
    public class Program
    {
        public static void Main(string[] args)
        {

            CustomerService customerService = new CustomerService();
            OrderService orderService = new OrderService();

            Customer customer = customerService.SearchCustomer(1);
            customer.SubscribeToNotifications(new CustomerEmailNotification());

            Order? order = orderService.CreateNewOrder(customer);
            if(order != null)
            {
                Staff? staff = order.Staff;
                staff?.SubscribeToNotifications();
                Console.WriteLine("===============================================================");
                orderService.ProcessOrder(order);
            }
        }
    }
}
