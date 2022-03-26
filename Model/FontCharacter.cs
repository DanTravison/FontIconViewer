using System.Globalization;

namespace FontIconViewer.Model
{
    /// <summary>
    /// Provides a class for describing a character in a font.
    /// </summary>
    public class FontCharacter
    {
        /// <summary>
        /// Initializes a new instance of this class.
        /// </summary>
        /// <param name="label">The display text for the item</param>
        /// <param name="glyph">The string containing the character.</param>
        /// <param name="id">The formatted character id for the character (U+000X)</param>
        public FontCharacter(string label, string glyph, string id)
        {
            Label = label;
            Glyph = glyph;
            Id = id;
        }

        /// <summary>
        /// Gets the display string for the item.
        /// </summary>
        public string Label
        {
            get;
        }

        /// <summary>
        /// Gets the string glyph for item.
        /// </summary>
        public string Glyph
        {
            get;
        }

        /// <summary>
        /// Gets the formatted character identifier
        /// </summary>
        public string Id
        {
            get;
        }
    }
}
