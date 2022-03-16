
<TestClass()> Partial Public Class UnitTest1

    <TestMethod()> Public Sub CreateCommandParametersForSqlServer()

        Dim Identifiers As New List(Of Integer) From {10, 22, 4, 66}

        Dim expected = "SELECT CompanyName FROM dbo.Company WHERE id IN (@CompId0,@CompId1,@CompId2,@CompId3)"
        Dim result = GetByPrimaryKeys(Identifiers)

        Assert.AreEqual(result, expected)

    End Sub

End Class