using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.SqlServer.TransactSql.ScriptDom;

namespace SimpleExamplesWpf.Classes
{
    public class QueryParsers
    {
        public static IList<ParseError> ParseErrors { get; set; }
        /// <summary>
        /// Format SQL off one line to indented into many lines
        /// </summary>
        /// <param name="query">SQL statement to format</param>
        /// <returns>Formatted SQL</returns>
        public static string Format(string query)
        {
            TSql120Parser parser = new(false);

            var parsedQuery = parser.Parse(
                new StringReader(query), 
                out var errors);

            if (errors.Count > 0)
            {
                ParseErrors = errors;
            }

            var generator = new Sql120ScriptGenerator(new SqlScriptGeneratorOptions()
            {
                KeywordCasing = KeywordCasing.Uppercase,
                IncludeSemicolons = true,
                NewLineBeforeFromClause = true,
                NewLineBeforeOrderByClause = true,
                NewLineBeforeWhereClause = true,
                AlignClauseBodies = false
            });

            generator.GenerateScript(parsedQuery, out var formattedQuery);

            return formattedQuery;

        }


        /// <summary>
        /// Get each parameter for WHERE clause
        /// </summary>
        /// <param name="sql">SQL with parameters</param>
        /// <returns></returns>
        public static (List<string> list, List<string> exceptions) GetVariables(string sql)
        {
            List<TSqlParserToken> queryTokens = TokenizeSql(sql, out var errors);

            if (errors != null)
            {
                return (null, errors);
            }

            var parameters = new List<string>();

            parameters.AddRange(queryTokens
                .Where(token => token.TokenType == TSqlTokenType.Variable)
                .Select(token => token.Text)
                .ToList());

            return (parameters, null);
        }

        private static List<TSqlParserToken> TokenizeSql(string sql, out List<string> parserErrors)
        {
            using TextReader textReader = new StringReader(sql);
            var parser = new TSql120Parser(true);


            var queryTokens = parser.GetTokenStream(textReader, out var errors);
            parserErrors = errors.Any()
                ? errors.Select(e => $"Error: {e.Number}; Line: {e.Line}; Column: {e.Column}; Offset: {e.Offset};  Message: {e.Message};").ToList()
                : null;
            return queryTokens.ToList();
        }

    }
}
