using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace FontIconViewer.Model
{
    /// <summary>
    /// Provides access to all <see cref="FontFamily"/> instances in <see cref="Fonts.SystemFontFamilies"/>.
    /// </summary>
    public class FontFamilies : IEnumerable<FontFamily>
    {
        readonly Dictionary<string, FontFamily> _index = new Dictionary<string, FontFamily>();
        readonly List<FontFamily> _values = new List<FontFamily>();

        /// <summary>
        /// Gets the <see cref="FontFamilies"/> for the elements in <see cref="Fonts.SystemFontFamilies"/>.
        /// </summary>
        public static readonly FontFamilies SystemFonts = new FontFamilies();

        private FontFamilies()
        {
            foreach (FontFamily family in Fonts.SystemFontFamilies)
            {
                _values.Add(family);
                _index.Add(family.Source, family);
            }
            _values.Sort(FontFamilyComparer.Comparer);

        }

        /// <summary>
        /// Gets all <see cref="FontFamily"/> instances.
        /// </summary>
        public IEnumerable<FontFamily> All
        {
            get => _values;
        }

        /// <summary>
        /// Gets the <see cref="FontFamily"/> with the given name.
        /// </summary>
        /// <param name="name">The name of the <see cref="FontFamily"/> to get.</param>
        /// <returns>The <see cref="FontFamily"/> with the specified <paramref name="name"/>; otherwise,
        /// a null reference.</returns>
        public FontFamily this[string name]
        {
            get
            {
                _index.TryGetValue(name, out FontFamily family);
                return family;
            }
        }

        /// <summary>
        ///  Returns an enumerator that iterates through the <see cref="FontFamily"/> instances.
        /// </summary>
        /// <returns>An <see cref="IEnumerator{FontFamily}"/> that can be used to iterate through the <see cref="FontFamily"/> instances.</returns>
        public IEnumerator<FontFamily> GetEnumerator()
        {
            return _values.GetEnumerator();
        }

        /// <summary>
        ///  Returns an enumerator that iterates through the <see cref="FontFamily"/> instances.
        /// </summary>
        /// <returns>An <see cref="IEnumerator"/> that can be used to iterate through the <see cref="FontFamily"/> instances..</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _values.GetEnumerator();
        }

        /// <summary>
        /// Gets an <see cref="IEnumerable{FontStyle}"/> of all <see cref="FontStyle"/> values.
        /// </summary>
        public static readonly IEnumerable<FontStyle> Styles = new List<FontStyle>()
        {
            FontStyles.Normal,
            FontStyles.Italic,
            FontStyles.Oblique
        };
    }
}
