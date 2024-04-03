using BehavioralDessignPatternApp.Model;
using BehavioralDessignPatternApp.Repository;

namespace BehavioralDessignPatternApp.Service
{
    public class StaffService
    {
        private IRepository<Staff> _repository;
        private List<Staff> _staffs = new List<Staff>();

        public StaffService()
        {
            _repository = new RepositoryImpl<Staff>(new List<Staff>() {
        new Staff{ Id = 1, Name = "Andrei", Email = "Andrei@gmail.com", Phone = "154861545451", Available = false},
        new Staff{ Id = 2, Name = "Maria", Email = "maria@gmail.com", Phone = "9876543210"},
        new Staff{ Id = 3, Name = "Alex", Email = "alex@gmail.com", Phone = "1234567890"},
        new Staff{ Id = 4, Name = "Sofia", Email = "sophia@gmail.com", Phone = "4567891230"},
        });
        }

        public void addStaffMember(Staff member)
        {
            _repository.Add(member);
        }

        public Staff FindAvailableStaffMember()
        {
            _staffs = _repository.GetAll();
            Staff? availableStaff = _staffs.First(staff => staff.Available == true);
            if (availableStaff != null)
            {
                availableStaff.Available = false;
                return availableStaff;
            }
            throw new ArgumentNullException("No available staff member to process the order.");
        }
    }
}
