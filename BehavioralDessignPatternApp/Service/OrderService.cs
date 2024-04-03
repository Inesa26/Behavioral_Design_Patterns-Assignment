using BehavioralDessignPatternApp.Model;
using BehavioralDessignPatternApp.Enum;
using BehavioralDessignPatternApp.Repository;
using BehavioralDessignPatternApp.Interface;

namespace BehavioralDessignPatternApp.Service
{
    public class OrderService : ISubject
    {
        private BookService bookService = BookService.GetInstance();
        private readonly StaffService staffService = new StaffService();
        private readonly List<Staff> staffList = new List<Staff>();
        private readonly IRepository<Order> _repository;
        private List<Book> booksForOrder = new List<Book>();

        public OrderService()
        {
            _repository = new RepositoryImpl<Order>(new List<Order>());
        }

        public void NotifyCustomer(Order order)
        {
            order.Customer.HandleEvent(order);
        }

        public Order? CreateNewOrder(Customer customer)
        {
            try
            {
                booksForOrder = bookService.BuyBooks();
                Order order = new Order(customer, booksForOrder);
                _repository.Add(order);
                NotifyCustomer(order);
                order.Staff = staffService.FindAvailableStaffMember();
                NotifyStaff(order);
                return order;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            return null;
        }

        public void ProcessOrder(Order order)
        {
            Console.WriteLine($"Processing order {order.Id}\n");
            UpdateOrderStatus(order, OrderStatus.ReadyForShipping);
            if (order.Staff is not null)
            {
                order.Staff.Available = true;
            }
        }

        public void UpdateOrderStatus(Order order, OrderStatus status)
        {
            order.Status = status;
            NotifyCustomer(order);
            NotifyStaff(order);
        }

        public void NotifyStaff(Order order)
        {
            order?.Staff?.HandleEvent(order);
        }
    }
}
