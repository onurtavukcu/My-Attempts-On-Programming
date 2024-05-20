using Design_Patterns.MaybeMonad;
using MaybeMonad.MaybeMonad;

namespace MaybeMonad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start");

            var personOp = new PersonOperations();

            var result = personOp.GetPersonFromId(1);
            var result2 = personOp.GetPersonFromId(2);
            var result3 = personOp.GetPersonFromId(3);
            var result4 = personOp.GetPersonFromId(4);

            Console.WriteLine(result.HasValue ? result.MaybeValue.ToString() : Maybe<Person>.None.ToString());
            Console.WriteLine(result2.HasValue ? result2.MaybeValue.ToString() : Maybe<Person>.None.ToString());
            Console.WriteLine(result3.HasValue ? result3.MaybeValue.ToString() : Maybe<Person>.None.ToString());
            Console.WriteLine(result4.HasValue ? result4.MaybeValue.ToString() : Maybe<Person>.None.ToString());

            Console.ReadKey();
        }
    }
}
