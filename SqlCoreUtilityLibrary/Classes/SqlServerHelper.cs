using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlCoreUtilityLibrary.Classes
{
    public class SqlServerHelper
    {
        /// <summary>
        /// Get column names for a SQL-Server database table
        /// </summary>
        /// <param name="connectionString">Valid connection string</param>
        /// <param name="tableName">Table name to get column name</param>
        /// <param name="schema">Database schema, defaults to dbo</param>
        /// <returns></returns>
        public static (List<string> columnNames, Exception exception) ColumnNames(string connectionString, string tableName, string schema = "dbo")
        {
            List<string> list = new List<string>();

            using var cn = new SqlConnection() { ConnectionString = connectionString };
            using var cmd = new SqlCommand() { Connection = cn };

            cmd.CommandText = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{tableName}' " + 
                              $"AND TABLE_SCHEMA='{schema}' AND DATA_TYPE = 'nvarchar'";


            try
            {
                cn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        list.Add(reader.GetString(0));
                    }
                }

                return (list, null);
            }
            catch (Exception e)
            {
                return (null, e);
            }
            
        }
    }
}
