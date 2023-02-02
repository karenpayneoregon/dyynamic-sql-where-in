using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DbPeekQueryLibrary.LanguageExtensions;
using Microsoft.Extensions.Configuration;
using WhereInUtilityLibrary.Classes;

namespace SimpleExamples.Classes;

public class DataOperations
{
    public delegate void CommandText(string sender);
    public static event CommandText GetCommandText;

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
    /// Get all companies from the database table
    /// </summary>
    /// <returns></returns>
    public static List<Company> GetCompanies()
    {
        var list = new List<Company>();

        using var cn = new SqlConnection() { ConnectionString = GetSqlConnection() };
        using var cmd = new SqlCommand()
        {
            Connection = cn, 
            CommandText = "SELECT id, CompanyName FROM dbo.Company ORDER BY CompanyName;"
        };

        cn.Open();
        var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            list.Add(new Company() {Id = reader.GetInt32(0), Name = reader.GetString(1)});
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

        using var cn = new SqlConnection() { ConnectionString = GetSqlConnection() };
        using var cmd = new SqlCommand() { Connection = cn };

        // create one parameter for each key in pIdentifiers
        cmd.CommandText = SqlWhereInParamBuilder
            .BuildInClause("SELECT CompanyName FROM dbo.Company WHERE id IN ({0})", "CompId",
                pIdentifiers);

        // populate each parameter with values from pIdentifiers
        cmd.AddParamsToCommand("CompId", pIdentifiers);

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