using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaybeMonad.MaybeMonad
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<Person> GetPersonList()
        {
            List<Person> PersonList = new List<Person>();

            Person Person1 = new Person()
            {
                Id = 1,
                Name = "Test1",
                Surname = "Test1",
            };

            Person Person2 = new Person()
            {
                Id = 2,
                Name = "Test2",
                Surname = "Test2"
            };

            Person Person3 = new Person()
            {
                Id = 3,
                Name = "Test3",
                Surname = "Test3"
            };

            PersonList.Add(Person1);
            PersonList.Add(Person2);
            PersonList.Add(Person3);

            return PersonList;
        }

        public override string ToString()
        {
            return $"Person [Id={Id}, Name={Name}, Surname= {Surname}]";
        }
    }
}
