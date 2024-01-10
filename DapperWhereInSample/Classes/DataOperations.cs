using ConfigurationLibrary.Classes;
using Microsoft.Data.SqlClient;
using System.Collections.Immutable;
using Dapper;

namespace DapperWhereInSample.Classes;
internal class DataOperations
{
    public static IReadOnlyList<ContactTypes> ContactTypesListDapper(params int[] identifiers)
    {
        using var cn = new SqlConnection(ConfigurationHelper.ConnectionString());
        return cn.Query<ContactTypes>(SqlStatements.GetContactTypesWhereIn, new { Identifiers = identifiers }).ToImmutableList();
    }
}