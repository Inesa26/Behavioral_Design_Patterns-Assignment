namespace BehavioralDessignPatternApp.Model
{
    public abstract class Person : Entity
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

       public Person(int id, string name, string email, string phone) : base(id) 
        {
            Name = name;
            Email = email;
            Phone = phone;
        }

        public Person() { }
    }
}
