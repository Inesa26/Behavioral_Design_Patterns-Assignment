using BehavioralDessignPatternApp.Model;

namespace BehavioralDessignPatternApp.Interface
{
    public interface IObserver
    {
        public void HandleEvent(Order order);
    }
}
