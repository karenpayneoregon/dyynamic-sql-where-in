using System.Collections.Generic;
using Bogus;
using UnitTestProject.Models;

namespace UnitTestProject.Base
{
    public class BogusOperations
    {
        public static List<Part> PartsList(int count = 50)
        {
            int id = 1456;
            return new Faker<Part>()
                .CustomInstantiator(f => new Part(id++))
                .RuleFor(part =>
                        part.PartName,
                    f => f.Commerce.Product())
                .Generate(count);
        }
    }
}
