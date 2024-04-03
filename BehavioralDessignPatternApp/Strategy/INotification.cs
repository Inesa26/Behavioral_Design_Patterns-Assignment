using BehavioralDessignPatternApp.Model;

namespace BehavioralDessignPatternApp.Strategy
{
    public interface INotification
    {
        public void SendNotification(Order order);
    }
}
