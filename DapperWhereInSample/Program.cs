using DapperWhereInSample.Classes;

namespace DapperWhereInSample;

internal partial class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(ObjectDumper.Dump(DataOperations.ContactTypesListDapper(1, 3, 6)));
        Console.ReadLine();
    }
}