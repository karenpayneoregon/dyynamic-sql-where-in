Imports System
Imports System.Collections.Generic
Imports System.Data

Public Module SqlTypeHelper
    Private ReadOnly TypeMap As Dictionary(Of Type, SqlDbType)

    ' Create and populate the dictionary in the static constructor
    Sub New()
        TypeMap = New Dictionary(Of Type, SqlDbType) From {
            {GetType(String), SqlDbType.NVarChar},
            {GetType(Char()), SqlDbType.NVarChar},
            {GetType(Byte), SqlDbType.TinyInt},
            {GetType(Short), SqlDbType.SmallInt},
            {GetType(Integer), SqlDbType.Int},
            {GetType(Long), SqlDbType.BigInt},
            {GetType(Byte()), SqlDbType.Image},
            {GetType(Boolean), SqlDbType.Bit},
            {GetType(DateTime), SqlDbType.DateTime2},
            {GetType(DateTimeOffset), SqlDbType.DateTimeOffset},
            {GetType(Decimal), SqlDbType.Money},
            {GetType(Single), SqlDbType.Real},
            {GetType(Double), SqlDbType.Float},
            {GetType(TimeSpan), SqlDbType.Time}
            }

        ' not in above then added them 
    End Sub

    ''' <summary>
    ''' Get SqlDbType for givenType
    ''' </summary>
    ''' <param name="giveType"></param>
    ''' <returns><see cref="SqlDbType"/></returns>
    Public Function GetDbType(ByVal giveType As Type) As SqlDbType
        ' Allow nullable types to be handled
        giveType = If(Nullable.GetUnderlyingType(giveType), giveType)

        If TypeMap.ContainsKey(giveType) Then
            Return TypeMap(giveType)
        End If

        Throw New ArgumentException($"{giveType.FullName} is not a supported .NET class")
    End Function
End Module