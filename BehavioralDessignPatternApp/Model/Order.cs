

using BehavioralDessignPatternApp.Enum;

namespace BehavioralDessignPatternApp.Model
{
    public class Order : Entity
    {
        public OrderStatus Status { get; set; } = OrderStatus.Confirmed;
        public List<Book> Books;
        public Customer Customer { get; set; }
        public Staff? Staff { get; set; }

        public Order(Customer customer, List<Book> books)
        {
            Id = new Random().Next(100000, 999999);
            Books = books;
            Customer = customer;

        }
    }
}
