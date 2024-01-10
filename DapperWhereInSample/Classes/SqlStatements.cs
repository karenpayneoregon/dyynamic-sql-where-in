namespace DapperWhereInSample.Classes;

public class SqlStatements
{
    public static string GetContactTypesWhereIn =>
        "SELECT Identifier, ContactType FROM dbo.ContactTypes WHERE Identifier IN @Identifiers";

}