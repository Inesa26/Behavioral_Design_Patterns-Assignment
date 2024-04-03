using BehavioralDessignPatternApp.Model;

namespace BehavioralDessignPatternApp.Repository
{
    public class RepositoryImpl<T> : IRepository<T> where T : Entity
    {
        private readonly List<T> _entities;
        public RepositoryImpl(List<T> entities)
        {
            _entities = entities;
        }
        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void Delete(int id)
        {
            T? toDelete = _entities.Find(entity => entity.Id == id);
            if (toDelete != null)
            {
                _entities.Remove(toDelete);
            }

        }

        public T? Get(int id)
        {
            return _entities.Find(entity => entity.Id == id);
        }

        public List<T> GetAll()
        {
            return _entities;
        }
    }
}
