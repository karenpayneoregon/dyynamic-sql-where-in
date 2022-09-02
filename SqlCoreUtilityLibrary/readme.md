# About

provides methods for writing [SQL WHERE IN](https://docs.microsoft.com/en-us/sql/t-sql/language-elements/in-transact-sql?view=sql-server-2017) conditions in C# dynamically for SQL-Server tables using SqlClient data provider. WHERE IN condition are used to assist for an alternative to using OR conditions in a SELECT and DELETE statement are most common. 

## Simple example

In this example the goal is to get company names (kept to one column for simplicity) where one or more keys (for the primary key CompId) are passed in.


In the following SQL `{0}` is important which indicates to the `SqlWhereInParamBuilder` how to properly inject keys into the query.

```sql
SELECT CompanyName FROM dbo.Company WHERE id IN ({0})
```

Then `cmd.AddParamsToCommand("CompId", pIdentifiers);` adds parameters to, in this case `cmd` object.

Note  that the following  `cmd.ActualCommandText()` provides you to see the actual query with parameter values, it is not part of this library but is available in the source repository in the project `DbLibrary` which should only be used in development, never in production.


```csharp
        public static (List<string> list, Exception exception) GetByPrimaryKeys(List<int> pIdentifiers)
        {

            var customerList = new List<string>();

            using var cn = new SqlConnection() { ConnectionString = ... };
            using var cmd = new SqlCommand() { Connection = cn };

            // create one parameter for each key in pIdentifiers
            cmd.CommandText = SqlWhereInParamBuilder
                .BuildInClause("SELECT CompanyName FROM dbo.Company WHERE id IN ({0})", "CompId",
                    pIdentifiers);

            // populate each parameter with values from pIdentifiers
            cmd.AddParamsToCommand("CompId", pIdentifiers);

            //GetCommandText?.Invoke(cmd.ActualCommandText());

            try
            {
                cn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        customerList.Add(reader.GetString(0));
                    }
                }

                return (customerList, null);
            }
            catch (Exception ex)
            {
                return (null, ex);
            }
        }
```

# Using in your project

For novice developers, clone the source repository, create the database (script is in the root of the solution), build the projects.

Inspect code in `SimpleExample` then run the project and see the results.

# Data providers

The majority of testing was done with SQL-Server with limited testing on Oracle and Microsoft Access. If needed for other databases follow what was done for SQL-Server and create one for your provider. The key is in `types` as in the class `SqlTypeHelper`.


# See also

Microsoft TechNet

[SQL-Server dynamic C#: Dynamic WHERE IN conditions in C#for SQL Server](https://social.technet.microsoft.com/wiki/contents/articles/51874.sql-server-dynamic-c-dynamic-where-in-conditions-in-c-for-sql-server.aspx)

