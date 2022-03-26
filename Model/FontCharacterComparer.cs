using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FontIconViewer.Model
{
    /// <summary>
    /// Provides an <see cref="IComparer{FontCharacter}"/> and <see cref="IEqualityComparer{FontCharacter}"/>.
    /// </summary>
    internal class FontCharacterComparer : IComparer<FontCharacter>, IEqualityComparer<FontCharacter>
    {
        bool _byGlyph;

        /// <summary>
        /// Provides an <see cref="IComparer{FontCharacter}"/> for comparing two <see cref="FontCharacter"/> instances by the <see cref="FontCharacter.Label"/>
        /// </summary>
        public static readonly FontCharacterComparer ByLabelComparer = new FontCharacterComparer(false);

        /// <summary>
        /// Provides an <see cref="IComparer{FontCharacter}"/> for comparing two <see cref="FontCharacter"/> instances by the <see cref="FontCharacter.Glyph"/>
        /// </summary>
        public static readonly FontCharacterComparer ByGlyphComparer = new FontCharacterComparer(true);

        private FontCharacterComparer(bool byGlyph)
        {
            _byGlyph = byGlyph;
        }

        /// <summary>
        /// Compares two <see cref="FontCharacter"/> instances.
        /// </summary>
        /// <param name="x">The first <see cref="FontCharacter"/> to compare.</param>
        /// <param name="y">The second <see cref="FontCharacter"/> to compare.</param>
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
        public int Compare(FontCharacter x, FontCharacter y)
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

            if (_byGlyph)
            {
                return StringComparer.CurrentCulture.Compare(x.Glyph, y.Glyph);
            }
            return StringComparer.CurrentCulture.Compare(x.Label, y.Label);
        }

        /// <summary>
        /// Determines whether the specified <see cref="FontCharacter"/> objects equal.
        /// </summary>
        /// <param name="x">The first <see cref="FontCharacter"/> to compare.</param>
        /// <param name="y">The second <see cref="FontCharacter"/> to compare.</param>
        /// <returns>true if the specified objects are equal; otherwise, false.</returns>
        public bool Equals(FontCharacter x, FontCharacter y)
        {
            return Compare(x, y) == 0;
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <param name="obj">The <see cref="FontCharacter"/> for which a hash code is to be returned.</param>
        /// <returns><see cref="FontCharacter.Glyph.GetHashCode"/>.</returns>
        public int GetHashCode(FontCharacter obj)
        {
            return obj.Glyph.GetHashCode();
        }
    }

}
