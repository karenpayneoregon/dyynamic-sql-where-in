Imports System.Data.OleDb

Public Module OleDbTypeHelper
    Private ReadOnly oleDbTypeMap As Dictionary(Of Type, OleDbType)

    Sub New()

        oleDbTypeMap = New Dictionary(Of Type, OleDbType) From {
            {GetType(String), OleDbType.VarChar},
            {GetType(Long), OleDbType.BigInt},
            {GetType(Byte()), OleDbType.Binary},
            {GetType(Boolean), OleDbType.Boolean},
            {GetType(Decimal), OleDbType.Decimal},
            {GetType(DateTime), OleDbType.Date},
            {GetType(TimeSpan), OleDbType.DBTime},
            {GetType(Double), OleDbType.Double},
            {GetType(Exception), OleDbType.Error},
            {GetType(Guid), OleDbType.Guid},
            {GetType(Integer), OleDbType.Integer},
            {GetType(Single), OleDbType.Single},
            {GetType(Short), OleDbType.SmallInt},
            {GetType(SByte), OleDbType.TinyInt},
            {GetType(ULong), OleDbType.UnsignedBigInt},
            {GetType(UInteger), OleDbType.UnsignedInt},
            {GetType(UShort), OleDbType.UnsignedSmallInt},
            {GetType(Byte), OleDbType.UnsignedTinyInt}
            }
    End Sub

    ''' <summary>
    ''' Get SqlDbType for givenType
    ''' </summary>
    ''' <param name="type"></param>
    ''' <returns><see cref="SqlDbType"/></returns>
    Public Function GetDatabaseType(ByVal type As Type) As OleDbType

        type = If(Nullable.GetUnderlyingType(type), type)

        If oleDbTypeMap.ContainsKey(type) Then
            Return oleDbTypeMap(type)
        End If

        Throw New ArgumentException($"{type.FullName} is not a supported .NET class")
    End Function
End Module