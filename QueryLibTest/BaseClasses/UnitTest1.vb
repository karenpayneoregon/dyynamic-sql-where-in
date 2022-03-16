Imports System.Data.SqlClient
Imports QueryLibTest.Helpers

Partial Public Class UnitTest1
    Public Shared Function GetByPrimaryKeys(pIdentifiers As List(Of Integer)) As String


        Dim customerList = New List(Of String)()

        Using cn = New SqlConnection() With {.ConnectionString = ""}
            Using cmd = New SqlCommand() With {.Connection = cn}

                cmd.CommandText = SqlWhereInParamBuilder.BuildInClause("SELECT CompanyName FROM dbo.Company WHERE id IN ({0})", "CompId", pIdentifiers)


                cmd.AddParamsToCommand("p", pIdentifiers)

                Return cmd.ActualCommandText()
            End Using
        End Using
    End Function
End Class
