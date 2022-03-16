Option Infer On

Imports System.Runtime.CompilerServices
Imports System.Text

Namespace Helpers

    Public Module ProviderCommandExtensions
        <Extension()>
        Public Function ActualCommandText(pCommand As IDbCommand, Optional pProvider As CommandProvider = CommandProvider.SqlServer, Optional pQualifier As String = "@") As String
            Dim sb = New StringBuilder(pCommand.CommandText)

            If pProvider <> CommandProvider.Oracle Then
                ' test for at least one parameter without a name, if found stop here.
                Dim emptyParameterNames = (
                        From parameter In pCommand.Parameters.Cast(Of IDataParameter)()
                        Where String.IsNullOrWhiteSpace(parameter.ParameterName)
                        Select parameter).FirstOrDefault()

                If emptyParameterNames IsNot Nothing Then
                    Return pCommand.CommandText
                End If
            ElseIf pProvider = CommandProvider.Oracle Then
                pQualifier = ":"
            End If


            For Each parameter As IDataParameter In pCommand.Parameters

                If (parameter.DbType = DbType.AnsiString) OrElse (parameter.DbType = DbType.AnsiStringFixedLength) OrElse (parameter.DbType = DbType.Date) OrElse (parameter.DbType = DbType.DateTime) OrElse (parameter.DbType = DbType.DateTime2) OrElse (parameter.DbType = DbType.Guid) OrElse (parameter.DbType = DbType.String) OrElse (parameter.DbType = DbType.StringFixedLength) OrElse (parameter.DbType = DbType.Time) OrElse (parameter.DbType = DbType.Xml) Then
                    If parameter.ParameterName.Substring(0, 1) = pQualifier Then
                        If parameter.Value Is Nothing Then
                            Throw New Exception($"no value given for parameter '{parameter.ParameterName}'")
                        End If

                        sb = sb.Replace(parameter.ParameterName, $"'{parameter.Value.ToString().Replace("'", "''")}'")

                    Else
                        sb = sb.Replace(String.Concat(pQualifier, parameter.ParameterName), $"'{parameter.Value.ToString().Replace("'", "''")}'")
                    End If
                Else
                    '                    
                    '                     * Dummy up a INSERT Oracle statement where the RETURNING has no
                    '                     * value for that parameter so return the parameter name instead
                    '                     * rather than a value.
                    '                     
                    If pProvider = CommandProvider.Oracle Then
                        If parameter.Value Is Nothing Then
                            sb = sb.Replace(parameter.ParameterName, parameter.ParameterName)
                        Else
                            sb = sb.Replace(parameter.ParameterName, parameter.Value.ToString())
                        End If
                    Else
                        sb = sb.Replace(parameter.ParameterName, parameter.Value.ToString())
                    End If

                End If
            Next parameter

            Return sb.ToString()

        End Function

    End Module
End Namespace