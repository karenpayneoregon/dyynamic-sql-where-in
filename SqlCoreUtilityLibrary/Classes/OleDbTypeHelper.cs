using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;

namespace SqlCoreUtilityLibrary.Classes
{
    public static class OleDbTypeHelper
    {
        private static readonly Dictionary<Type, OleDbType> oleDbTypeMap;

        static OleDbTypeHelper()
        {

            oleDbTypeMap = new Dictionary<Type, OleDbType>
            {
                [typeof(string)] = OleDbType.VarChar,
                [typeof(long)] = OleDbType.BigInt,
                [typeof(byte[])] = OleDbType.Binary,
                [typeof(bool)] = OleDbType.Boolean,
                [typeof(decimal)] = OleDbType.Decimal,
                [typeof(DateTime)] = OleDbType.Date,
                [typeof(TimeSpan)] = OleDbType.DBTime,
                [typeof(double)] = OleDbType.Double,
                [typeof(Exception)] =OleDbType.Error,
                [typeof(Guid)] =  OleDbType.Guid,
                [typeof(int)]  = OleDbType.Integer,
                [typeof(float)] = OleDbType.Single,
                [typeof(short)] = OleDbType.SmallInt,
                [typeof(sbyte)] = OleDbType.TinyInt,
                [typeof(ulong)] = OleDbType.UnsignedBigInt,
                [typeof(uint)] = OleDbType.UnsignedInt,
                [typeof(ushort)] = OleDbType.UnsignedSmallInt,
                [typeof(byte)] = OleDbType.UnsignedTinyInt 
            };
        }
        
        /// <summary>
        /// Get SqlDbType for givenType
        /// </summary>
        /// <param name="type"></param>
        /// <returns><see cref="SqlDbType"/></returns>
        public static OleDbType GetDatabaseType(Type type)
        {

            type = Nullable.GetUnderlyingType(type) ?? type;

            if (oleDbTypeMap.ContainsKey(type))
            {
                return oleDbTypeMap[type];
            }

            throw new ArgumentException($"{type.FullName} is not a supported .NET class");
        }
    }
}
