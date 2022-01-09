using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace SqlCoreUtilityLibrary.Classes
{
    public static class SqlTypeHelper
    {
        private static readonly Dictionary<Type, SqlDbType> sqlTypeMap;
        private static readonly Dictionary<Type, OleDbType> oleDbTypeMap;

        static SqlTypeHelper()
        {
            sqlTypeMap = new Dictionary<Type, SqlDbType>
            {
                [typeof(string)] = SqlDbType.NVarChar,
                [typeof(char[])] = SqlDbType.NVarChar,
                [typeof(byte)] = SqlDbType.TinyInt,
                [typeof(short)] = SqlDbType.SmallInt,
                [typeof(int)] = SqlDbType.Int,
                [typeof(long)] = SqlDbType.BigInt,
                [typeof(byte[])] = SqlDbType.Image,
                [typeof(bool)] = SqlDbType.Bit,
                [typeof(DateTime)] = SqlDbType.DateTime2,
                [typeof(DateTimeOffset)] = SqlDbType.DateTimeOffset,
                [typeof(decimal)] = SqlDbType.Money,
                [typeof(float)] = SqlDbType.Real,
                [typeof(double)] = SqlDbType.Float,
                [typeof(TimeSpan)] = SqlDbType.Time
            };

            oleDbTypeMap = new Dictionary<Type, OleDbType>
            {
                [typeof(string)] = OleDbType.VarChar ,
                [typeof(long)] = OleDbType.BigInt ,
                [typeof(byte[])] = OleDbType.Binary ,
                [typeof(bool)] = OleDbType.Boolean ,
                [typeof(decimal)] = OleDbType.Decimal ,
                [typeof(DateTime)] = OleDbType.Date ,
                [typeof(TimeSpan)] = OleDbType.DBTime ,
                [typeof(double)] = OleDbType.Double ,
                [typeof(Exception)] =OleDbType.Error ,
                [typeof(Guid)] =  OleDbType.Guid ,
                [typeof(int)]  = OleDbType.Integer ,
                [typeof(float)] = OleDbType.Single ,
                [typeof(short)] = OleDbType.SmallInt ,
                [typeof(sbyte)] = OleDbType.TinyInt ,
                [typeof(ulong)] = OleDbType.UnsignedBigInt ,
                [typeof(uint)] = OleDbType.UnsignedInt ,
                [typeof(ushort)] = OleDbType.UnsignedSmallInt ,
                [typeof(byte)] = OleDbType.UnsignedTinyInt 
            };
        }
        
        /// <summary>
        /// Get SqlDbType for givenType
        /// </summary>
        /// <param name="type"></param>
        /// <returns><see cref="SqlDbType"/></returns>
        public static SqlDbType GetDatabaseType(Type type)
        {

            type = Nullable.GetUnderlyingType(type) ?? type;

            if (sqlTypeMap.ContainsKey(type))
            {
                return sqlTypeMap[type];
            }

            throw new ArgumentException($"{type.FullName} is not a supported .NET class");
        }
    }
}
