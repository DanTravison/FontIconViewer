using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Media;

namespace FontIconViewer.Model
{
    /// <summary>
    /// Provides a view model for a <see cref="FontCharacter"/> collection. 
    /// </summary>
    public class FontCharactersViewModel
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of this class
        /// </summary>
        /// <param name="type">The type containing the static fields for valid glyphs.</param>
        /// <param name="family">The <see cref="FontFamily"/> of the font.</param>
        /// <param name="fontSize">The font size to use for display.</param>
        public FontCharactersViewModel(Type type, FontFamily family, string familyName)
        {
            Family = family;
            Items = GetItems(type);
            FamilyName = familyName;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets the string form of the font's family name
        /// </summary>
        public string FamilyName
        {
            get;
        }

        /// <summary>
        /// Gets the <see cref="FontFamily"/>
        /// </summary>
        public FontFamily Family
        {
            get;
        }

        /// <summary>
        /// Gets the <see cref="FontCharacter"/> collection.
        /// </summary>
        public IEnumerable<FontCharacter> Items
        {
            get;
        }

        #endregion Properties

        static IEnumerable<FontCharacter> GetItems(Type type)
        {
            List<FontCharacter> items = new List<FontCharacter>();
            foreach (FieldInfo info in type.GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                if (info.FieldType != typeof(string))
                {
                    continue;
                }
                string infoValue = info.GetValue(null) as string;
                if (string.IsNullOrEmpty(infoValue))
                {
                    continue;
                }

                string id = string.Format("U+{0:X4}", (byte)infoValue[0]);
                FontCharacter item = new FontCharacter(info.Name, infoValue, id);
                items.Add(item);
            }
            return items;
        }
    }
}
