using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    f => f.Person.Avatar)
                .Generate(count);
        }
    }
}
