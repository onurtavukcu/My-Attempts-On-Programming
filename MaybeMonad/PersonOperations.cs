using Design_Patterns.MaybeMonad;
using MaybeMonad.MaybeMonad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaybeMonad
{
    public class PersonOperations
    {
        public Maybe<Person> GetPersonFromId(int id)
        {
            var person = new Person();
            var personList = person.GetPersonList();

            var result = personList.FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                return Maybe<Person>.None;
            }

            return Maybe<Person>.From(result);
        }
    }
}
