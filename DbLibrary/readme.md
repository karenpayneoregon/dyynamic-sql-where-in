# About

This package contains a language extension method to reveal a parameterized SQL statement written using a managed data provider in C# or VB.NET programming languages.

Example usage, a query has syntax issues which mainly come from a developer writing a query in code rather than writing the query in, for SQL-Server SSMS, for Oracle, Toad or Microsoft Access in Access.

## Requirements

Queries use `name parameters`, makes no sense to use this with string concatenated string as you can `see` parameter values already.

- For Oracle the parameter is prefixed with `:`, 

- For SQL-Server `@`.  
- For MS-Access (which many use `?` but not with this exension) `@`.  
