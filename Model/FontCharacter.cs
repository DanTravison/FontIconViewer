using System;

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
        public FontCharacter(string label, string glyph)
        {
            Label = label;
            Glyph = glyph;
            Id = string.Format("U+{0:X4}", Convert.ToUInt16(glyph[0]));
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
