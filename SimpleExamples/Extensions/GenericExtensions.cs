using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace SimpleExamples.Extensions
{
    public static class GenericExtensions
    {

        /// <summary>
        /// Get checked items as <see cref="T"/>
        /// </summary>
        /// <typeparam name="T">Model</typeparam>
        /// <param name="sender">CheckedListBox</param>
        /// <returns>List if one or more items are checked</returns>
        public static List<T> CheckedList<T>(this CheckedListBox sender)
            => sender.Items.Cast<T>()
                .Where((_, index) => sender.GetItemChecked(index))
                .Select(item => item)
                .ToList();

        public static bool IsNull(this object sender) => sender == null || sender == DBNull.Value || Convert.IsDBNull(sender) == true;

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
