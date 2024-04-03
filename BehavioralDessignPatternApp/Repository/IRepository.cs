using BehavioralDessignPatternApp.Model;

namespace BehavioralDessignPatternApp.Repository
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T entity);
        void Delete(int id);
        List<T> GetAll();
        T? Get(int id);
    }
}
