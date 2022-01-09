using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SimpleExamples.Classes;

namespace SimpleExamples.Extensions
{
    public static class GenericExtensions
    {
        public static List<Company> CheckedList(this CheckedListBox source)
            => source.Items.Cast<Company>()
                .Where((item, index) => source.GetItemChecked(index)).Select(item => item)
                .ToList();
        public static bool IsNull(this object sender)
        {
            return sender == null || sender == DBNull.Value || Convert.IsDBNull(sender) == true;
        }

        /// <summary>
        /// Is the instance of a class null
        /// </summary>
        /// <typeparam name="T">Concrete class type</typeparam>
        /// <param name="senderInstance">Instance of concrete class</param>
        /// <returns>True if null, false if not null</returns>
        public static bool IsNull<T>(this T senderInstance) where T : new() => senderInstance is null;

        /// <summary>
        /// Is the instance of a class not null
        /// </summary>
        /// <typeparam name="T">Concrete class type</typeparam>
        /// <param name="senderInstance">Instance of concrete class</param>
        /// <returns>True if not null, false if null</returns>
        public static bool IsNotNull<T>(this T senderInstance) where T : new() => !senderInstance.IsNull();

    }
}
