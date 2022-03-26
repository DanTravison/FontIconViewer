using System;
using System.Collections.Generic;
using System.Windows.Media;

namespace FontIconViewer.Model
{
    /// <summary>
    /// Provides an <see cref="IComparer{FontFamily}"/>
    /// </summary>
    internal class FontFamilyComparer : IComparer<FontFamily>, IEqualityComparer<FontFamily>
    {
        /// <summary>
        /// Provides an <see cref="IComparer{FontFamily}"/> for comparing two <see cref="FontFamily"/> instances.
        /// </summary>
        public static readonly FontFamilyComparer Comparer = new FontFamilyComparer();

        private FontFamilyComparer()
        {
        }

        /// <summary>
        /// Compares two <see cref="FontFamily"/> instances.
        /// </summary>
        /// <param name="x">The first <see cref="FontFamily"/> to compare.</param>
        /// <param name="y">The second <see cref="FontFamily"/> to compare.</param>
        /// <returns>
        /// <list type="table">
        ///     <listheader>
        ///         <term>Value</term>
        ///         <description>Description</description>
        ///     </listheader>
        ///     <item>
        ///         <term>Less than zero</term>
        ///         <description><paramref name="x"/> is less than <paramref name="y"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term>Zero</term>
        ///         <description>This <paramref name="x"/> is equal to <paramref name="y"/>.</description>
        ///     </item>
        ///     <item>
        ///         <term>Greater than zero.</term>
        ///         <description><paramref name="x"/> is greater than <paramref name="y"/>.</description>
        ///     </item>
        /// </list>
        /// </returns>		
        public int Compare(FontFamily x, FontFamily y)
        {
            if (x == null && y == null)
            {
                return 0;
            }
            else if (x == null)
            {
                return -1;
            }
            else if (y == null)
            {
                return 1;
            }
            return StringComparer.CurrentCulture.Compare(x.Source, y.Source);
        }

        /// <summary>
        /// Determines whether the specified <see cref="FontFamily"/> objects equal.
        /// </summary>
        /// <param name="x">The first <see cref="FontFamily"/> to compare.</param>
        /// <param name="y">The second <see cref="FontFamily"/> to compare.</param>
        /// <returns>true if the specified objects are equal; otherwise, false.</returns>
        public bool Equals(FontFamily x, FontFamily y)
        {
            return Compare(x, y) == 0;
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The <see cref="FontFamily"/> for which a hash code is to be returned.</param>
        /// <returns><see cref="FontFamily.GetHashCode"/>.</returns>
        public int GetHashCode(FontFamily obj)
        {
            return obj.GetHashCode();
        }
    }
}
