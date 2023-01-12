using Assessment_5.Models;

namespace Assessment_5
{
    public class PersonRepository
    {
        public int Age { get; set; }
        public string UserName { get; set; }
        public bool CanDrink { get; set; }
        public bool CanDrive { get; set; }

        private List<PersonViewModel> _mockPersons;

        public PersonRepository()
        {
            CreateMockPersonList();
        }

        private void CreateMockPersonList()
        {
            _mockPersons= new List<PersonViewModel>();
            _mockPersons.Add(new PersonViewModel { Age = 3, UserName = "Gus", CanDrink = false, CanDrive = false });
            _mockPersons.Add(new PersonViewModel { Age = 15, UserName = "Larry", CanDrink = false, CanDrive = false });
            _mockPersons.Add(new PersonViewModel { Age = 20, UserName = "Betty", CanDrink = false, CanDrive = true });
            _mockPersons.Add(new PersonViewModel { Age = 25, UserName = "Sarah", CanDrink = true, CanDrive = true });
            _mockPersons.Add(new PersonViewModel { Age = 30, UserName = "Tim", CanDrink = true, CanDrive = true });
        }

        public IEnumerable<PersonViewModel> GetMockPersons()
        {
            return _mockPersons;
        }
        public void CreatePerson(PersonViewModel person)
        {
            _mockPersons.Add(person);
        }
    }
}
