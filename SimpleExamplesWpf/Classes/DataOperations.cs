using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DbLibrary.LanguageExtensions;
using Microsoft.Extensions.Configuration;
using SqlCoreUtilityLibrary.Classes;

namespace SimpleExamplesWpf.Classes
{
    public class DataOperations
    {
        public delegate void CommandText(string sender);
        public static event CommandText GetCommandText;

        private static string _connectionString = "";

        public static string GetSqlWhereDatabaseConnection()
        {
            if (string.IsNullOrWhiteSpace(_connectionString))
            {
                var config = ReadAppsettings(out _);
                _connectionString = config.GetConnectionString("WhereDatabaseConnection");
            }

            return _connectionString;
        }

        /// <summary>
        /// Get all companies from the database table
        /// </summary>
        /// <returns></returns>
        public static List<Country> GetCountries()
        {
            var list = new List<Country>();

            using var cn = new SqlConnection() { ConnectionString = GetSqlWhereDatabaseConnection() };
            using var cmd = new SqlCommand()
            {
                Connection = cn, 
                CommandText = "SELECT Id, [Name] FROM dbo.Countries;"
            };

            cn.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Country() {Id = reader.GetInt32(0), Name = reader.GetString(1)});
            }

            return list;
        }

        /// <summary>
        /// Get company names from array of identifiers
        /// </summary>
        /// <param name="pIdentifiers">CheckedListBox selections</param>
        /// <returns>List of companies</returns>
        public static (List<string> list, Exception exception) GetByPrimaryKeys(List<int> pIdentifiers)
        {

            var customerList = new List<string>();

            using var cn = new SqlConnection() { ConnectionString = GetSqlWhereDatabaseConnection() };
            using var cmd = new SqlCommand() { Connection = cn };

            // create one parameter for each key in pIdentifiers
            cmd.CommandText = SqlWhereInParamBuilder
                .BuildInClause("SELECT [Name] FROM dbo.Countries WHERE Id IN ({0})", "pId",
                    pIdentifiers);

            // populate each parameter with values from pIdentifiers
            cmd.AddParamsToCommand("pId", pIdentifiers);

            GetCommandText?.Invoke(cmd.ActualCommandText());

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

        private static IConfigurationRoot ReadAppsettings(out IConfigurationBuilder builder)
        {
            builder = new ConfigurationBuilder().AddJsonFile(
                "appsettings.json", optional: 
                false, reloadOnChange: 
                true);

            IConfigurationRoot config = builder.Build();

            return config;

        }
    }
}
