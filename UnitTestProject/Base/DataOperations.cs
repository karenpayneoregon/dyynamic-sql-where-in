using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbPeekQueryLibrary.LanguageExtensions;
using Microsoft.Extensions.Configuration;
using WhereInUtilityLibrary.Classes;

namespace UnitTestProject.Base
{
    public class DataOperations
    {
        private static string _connectionString = "";

        public static string GetSqlConnection()
        {
            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                var config = ReadAppsettings(out _);
                _connectionString = config.GetConnectionString("DatabaseConnection");
            }

            return _connectionString;
        }

        /// <summary>
        /// Creates a dynamic WHERE IN condition based on existing company names
        /// </summary>
        /// <param name="pNames">List of existing company names</param>
        /// <returns>List of customer keys</returns>
        /// <remarks>
        /// This is a base version while <see cref="GetByPrimaryKeys"/> does the same 
        /// slightly different configuration
        /// </remarks>
        public static (List<int> list, Exception exception) GetCustomersKeysBack(List<string> pNames)
        {

            var customerList = new List<int>();

            using var cn = new SqlConnection() { ConnectionString = GetSqlConnection() };
            using var cmd = new SqlCommand() { Connection = cn };
            // Create a parameter for each value in pNames


            cmd.CommandText = SqlWhereInParamBuilder.BuildInClause(
                "SELECT id FROM dbo.Company WHERE CompanyName IN ({0})", "CompName", pNames);

            // populate parameters created in BuildInClause
            cmd.AddParamsToCommand("CompName", pNames);

            try
            {
                cn.Open();

                // After running this test click on the test method calling 
                // this method and select "output" to view the SELECT statement.
                //Debug.WriteLine(cmd.ActualCommandText());

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        customerList.Add(reader.GetInt32(0));
                    }
                }

                return (customerList, null);
            }
            catch (Exception ex)
            {
                return (null, ex);
            }

        }

        public static (List<string> list, Exception exception) GetCustomersNamesBackFromAccess(List<string> pNames)
        {
            var customerList = new List<string>();

            var connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=NorthWind.accdb";

            using var cn = new OleDbConnection() { ConnectionString = connectionString };
            using var cmd = new OleDbCommand() { Connection = cn };

            cmd.CommandText = OleDbWhereInParamBuilder
                .BuildInClause("SELECT C.CompanyName, C.ContactName FROM Customers AS C WHERE (C.ContactTitle) IN ({0})", "CompName",
                    pNames);

            cmd.AddParamsToCommand("CompName", pNames);

            /*
             * Produces
             *
             * SELECT
             *      C.CompanyName, C.ContactName
             * FROM Customers AS C
             * WHERE (C.ContactTitle) IN ('Marketing Assistant','Owner','Sales Agent')
             */

            foreach (OleDbParameter parameter in cmd.Parameters)
            {
                Debug.WriteLine(parameter.ParameterName);
            }

            Debug.WriteLine("");

            try
            {
                cn.Open();
                Debug.WriteLine(cmd.ActualCommandText());
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

        /// <summary>
        /// Creates a dynamic WHERE IN condition based on existing company names. The
        /// method <see cref="GetCustomersKeysBack"/> is more likely to be used this 
        /// this one as it returns keys for names while this one returns the names 
        /// given names
        /// </summary>
        /// <param name="pNames">List of existing company names</param>

        public static (List<string> list, Exception exception) GetCustomersNamesBack(List<string> pNames)
        {

            var customerList = new List<string>();

            using var cn = new SqlConnection() { ConnectionString = GetSqlConnection() };
            using var cmd = new SqlCommand() { Connection = cn };

            cmd.CommandText = SqlWhereInParamBuilder
                .BuildInClause("SELECT CompanyName FROM dbo.Company WHERE CompanyName IN ({0})", "CompName",
                    pNames);

            cmd.AddParamsToCommand("CompName", pNames);

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
        
        /// <summary>
        /// Creates a dynamic WHERE IN condition based on existing company primary keys
        /// </summary>
        /// <param name="pIdentifiers">List of existing company primary keys</param>
        /// <returns>List of customer names</returns>
        public static (List<string> list, Exception exception) GetByPrimaryKeys(List<int> pIdentifiers)
        {

            var customerList = new List<string>();

            using var cn = new SqlConnection() { ConnectionString = GetSqlConnection() };
            using var cmd = new SqlCommand() { Connection = cn };
            // create one parameter for each key in pIdentifiers
            cmd.CommandText = SqlWhereInParamBuilder
                .BuildInClause("SELECT CompanyName FROM dbo.Company WHERE id IN ({0})", "CompId",
                    pIdentifiers);

            // populate each parameter with values from pIdentifiers
            cmd.AddParamsToCommand("CompId", pIdentifiers);
            Debug.WriteLine(cmd.ActualCommandText());
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

        public static (List<string> list, Exception exception) GetByPrimaryKeys_NotIn(List<int> pIdentifiers)
        {

            var customerList = new List<string>();

            using var cn = new SqlConnection() { ConnectionString = GetSqlConnection() };
            using var cmd = new SqlCommand() { Connection = cn };
            cmd.CommandText = SqlWhereInParamBuilder.BuildInClause(
                "SELECT CompanyName FROM dbo.Company WHERE id NOT IN ({0})", "CompId",
                pIdentifiers);

            cmd.AddParamsToCommand("CompId", pIdentifiers);

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

        /// <summary>
        /// Create dynamic WHERE IN condition for type Date. 
        /// </summary>
        /// <param name="pStartDates"></param>
        /// <returns></returns>
        /// <remarks>
        /// * There are various forms of 'Date' and in this case we are using a Date.
        /// * Note parameters are setup before creating a connection/command then
        ///   the parameter values are set in after the command has been created which
        ///   is different from the other methods above.
        /// </remarks>
        public static (List<int> list, Exception exception) GetStartDatesList(List<string> pStartDates)
        {

            var datePrimaryKeyList = new List<int>();

            using var cn = new SqlConnection() { ConnectionString = GetSqlConnection() };
            var selectStatement = SqlWhereInParamBuilder.BuildInClause(
                "SELECT e.EventID, e.StartDate FROM dbo.Events AS e WHERE StartDate IN ({0})",
                "sd",
                pStartDates);

            using var cmd = new SqlCommand() { Connection = cn, CommandText = selectStatement };
            cmd.AddParamsToCommand("sd", pStartDates);

            try
            {
                cn.Open();
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        datePrimaryKeyList.Add(reader.GetInt32(0));
                    }
                }

                return (datePrimaryKeyList, null);
            }
            catch (Exception ex)
            {
                return (null, ex);
            }
        }
        private static IConfigurationRoot ReadAppsettings(out IConfigurationBuilder builder)
        {
            builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();
            return config;
        }
    }
}
