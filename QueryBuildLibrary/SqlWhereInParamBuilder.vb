Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq

Public Module SqlWhereInParamBuilder
    ''' <summary>
    ''' Creates parameters for IN of the WHERE clause
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="partialClause">SELECT partly built up to WHERE IN ({0})</param>
    ''' <param name="pPrefix">Prefix for parameter names</param>
    ''' <param name="parameters">Parameter values</param>
    ''' <returns></returns>
    Public Function BuildInClause(Of T)(partialClause As String, pPrefix As String, parameters As IEnumerable(Of T)) As String
        Dim parameterNames() As String = parameters.Select(Function(paramText, paramNumber) $"@{pPrefix}{paramNumber}").ToArray()

        Dim inClause = String.Join(",", parameterNames)
        Dim whereInClause = String.Format(partialClause.Trim(), inClause)

        Return whereInClause
    End Function
    ''' <summary>
    ''' Populate parameter values
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="cmd">Valid command object</param>
    ''' <param name="pPrefix">Prefix for parameter names</param>
    ''' <param name="parameters">Parameter values</param>
    <System.Runtime.CompilerServices.Extension>
    Public Sub AddParamsToCommand(Of T)(cmd As SqlCommand, pPrefix As String, parameters As IEnumerable(Of T))
        Dim parameterValues = parameters.Select(Function(paramText) paramText.ToString()).ToArray()
        Dim parameterNames = parameterValues.Select(Function(paramText, paramNumber) $"@{pPrefix}{paramNumber}").ToArray()

        For index As Integer = 0 To parameterNames.Length - 1
            cmd.Parameters.Add(New SqlParameter() With {
                                  .ParameterName = parameterNames(index),
                                  .SqlDbType = SqlTypeHelper.GetDbType(GetType(T)),
                                  .Value = parameterValues(index)
                                  })
        Next index
    End Sub
End Module