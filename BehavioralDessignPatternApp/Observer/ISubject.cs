using BehavioralDessignPatternApp.Model;

namespace BehavioralDessignPatternApp.Interface
{
    public interface ISubject
    {
        public void NotifyCustomer(Order order);
        public void NotifyStaff(Order order);
    }
}
