using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;

namespace SqlCoreUtilityLibrary.Classes
{
    public static class OleDbWhereInParamBuilder
    {
        /// <summary>
        /// Creates parameters for IN of the WHERE clause
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="partialClause">SELECT partly built up to WHERE IN ({0})</param>
        /// <param name="pPrefix">Prefix for parameter names</param>
        /// <param name="parameters">Parameter values</param>
        /// <returns></returns>
        public static string BuildInClause<T>(string partialClause, string pPrefix, IEnumerable<T> parameters)
        {
            string[] parameterNames = parameters.Select((paramText, paramNumber) 
                => $"@{pPrefix}{paramNumber}").ToArray();

            var inClause = string.Join(",", parameterNames);
            var whereInClause = string.Format(partialClause.Trim(), inClause);

            return whereInClause;

        }
        /// <summary>
        /// Populate parameter values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cmd">Valid command object</param>
        /// <param name="pPrefix">Prefix for parameter names</param>
        /// <param name="parameters">Parameter values</param>
        public static void AddParamsToCommand<T>(this OleDbCommand cmd, string pPrefix, IEnumerable<T> parameters)
        {
            var parameterValues = parameters.Select((paramText) => 
                paramText.ToString()).ToArray();

            var parameterNames = parameterValues.
                Select((paramText, paramNumber) 
                    => $"@{pPrefix}{paramNumber}").ToArray();

             
            for (int index = 0; index < parameterNames.Length; index++)
            {
                cmd.Parameters.Add(new OleDbParameter()
                {
                    ParameterName = parameterNames[index],
                    OleDbType = OleDbTypeHelper.GetDatabaseType(typeof(T)),
                    Value = parameterValues[index]
                });
            }
        }
    }
}
