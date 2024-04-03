using BehavioralDessignPatternApp.Model;
using BehavioralDessignPatternApp.Repository;

namespace BehavioralDessignPatternApp.Service
{
    public class CustomerService
    {
        private readonly IRepository<Customer> _repository;

        public CustomerService()
        {
            _repository = new RepositoryImpl<Customer>(new List<Customer>()
            {
               new Customer { Id = 1, Name = "Andrei Popescu", Address = "Str. Mihai Viteazu nr. 15", Phone = "0721123456", Email = "andrei.popescu@gmail.com" },
               new Customer { Id = 2, Name = "Elena Ionescu", Address = "Bd. Igor Vieru nr. 20", Phone = "0732123456", Email = "elena.ionescu@gmail.com" },
               new Customer { Id = 3, Name = "Mihai Stoica", Address = "Str. Renasterii  nr. 10", Phone = "0743123456", Email = "mihai.stoica@gmail.com" },
               new Customer { Id = 4, Name = "Ana Dumitrescu", Address = "Bd. Mircea cel Batran nr. 5", Phone = "0754123456", Email = "ana.dumitrescu@gmail.com" }
        });
        }

        public Customer SearchCustomer(int id)
        {
            Customer? customer = _repository.Get(id);

            if (customer == null)
            {
                throw new ArgumentException($"Customer with ID {id} not found.");
                
            }

            return customer;
        }


    }
}
