using System;
using System.Collections.Generic;
using System.Data;

namespace SqlUtilityLibrary
{
    public static class SqlTypeHelper
    {
        private static readonly Dictionary<Type, SqlDbType> TypeMap;

        // Create and populate the dictionary in the static constructor
        static SqlTypeHelper()
        {
            TypeMap = new Dictionary<Type, SqlDbType>
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

            /* not in above then added them */
        }

        /// <summary>
        /// Get SqlDbType for givenType
        /// </summary>
        /// <param name="giveType"></param>
        /// <returns><see cref="SqlDbType"/></returns>
        public static SqlDbType GetDbType(Type giveType)
        {
            // Allow nullable types to be handled
            giveType = Nullable.GetUnderlyingType(giveType) ?? giveType;

            if (TypeMap.ContainsKey(giveType))
            {
                return TypeMap[giveType];
            }

            throw new ArgumentException($"{giveType.FullName} is not a supported .NET class");
        }
    }
}
