using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;

namespace FontIconViewer.Model
{
    internal class MainViewModel : ObservableObject
    {
        #region Static initialization

        static List<FontCharactersViewModel> _fonts;

        static readonly (string, Type)[] _fontInfo =
        {
            (
                "Segoe MDL2 Assets",
                typeof(SegoeMDL2Assets)
            ),
            (
                "Segoe Fluent Icons",
                typeof(SegoeFluentIcons)
            )
        };

        static MainViewModel()
        {
            _fonts = new List<FontCharactersViewModel>();
            foreach ((string Family, Type GlyphType) info in _fontInfo)
            {
                FontFamily family = FontFamilies.SystemFonts[info.Family];
                if (family != null)
                {
                    _fonts.Add(new FontCharactersViewModel(info.GlyphType, family, info.Family));
                }
            }
        }

        #endregion Static initialization

        #region Fields

        string _searchTerm = string.Empty;

        /// <summary>
        /// The items currently displayed
        /// </summary>
        IEnumerable<FontCharacter> _items;

        /// <summary>
        /// The selected <see cref="FontCharactersViewModel"/>.
        /// </summary>
        FontCharactersViewModel _selectedItem;

        #endregion Fields

        public MainViewModel()
        {
            SearchCommand = new Command(Search, true);
            ClearSearchCommand = new Command(ClearSearch, true);
            Fonts = _fonts;
            SelectedItem = _fonts[0];
         }

        #region Properties

        public IEnumerable<FontCharactersViewModel> Fonts
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the <see cref="FontCharacter"/> collection.
        /// </summary>
        public IEnumerable<FontCharacter> Items
        {
            get => _items ?? _selectedItem.Items;
            private set
            {
                if (value == null)
                {
                    value = _selectedItem.Items;
                }

                if (!object.ReferenceEquals(value, Items))
                {
                    _items = value;
                    OnPropertyChanged(ItemsChangedEventArgs);
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected <see cref="FontCharactersViewModel"/>
        /// </summary>
        public FontCharactersViewModel SelectedItem 
        {
            get => _selectedItem;
            set
            {
                if (!object.ReferenceEquals(value, _selectedItem))
                {
                    _selectedItem = value;
                    OnPropertyChanged(SelectedItemChangedEventArgs);
                    SearchTerm = string.Empty;
                }
            }
        }

        /// <summary>
        /// Gets or sets the string to use to search <see cref="Items"/>.
        /// </summary>
        public string SearchTerm
        {
            get => _searchTerm;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    value = string.Empty;
                }

                if (StringComparer.CurrentCultureIgnoreCase.Compare(value, _searchTerm) != 0)
                {
                    _searchTerm = value;
                    Items = _selectedItem.Items;
                    OnPropertyChanged(SearchTermChangedEventArgs);
                }
            }
        }

        /// <summary>
        /// Gets the <see cref="Command"/> to search using <see cref="SearchTerm"/>.
        /// </summary>
        public Command SearchCommand
        {
            get;
        }

        /// <summary>
        /// Resets the <see cref="SearchTerm"/>
        /// </summary>
        public Command ClearSearchCommand
        {
            get;
        }

        #endregion Properties

        #region Search

        void ClearSearch(Command item)
        {
            SearchTerm = string.Empty;
            Items = _selectedItem.Items;
        }

        void Search(Command item)
        {
            Items = Search(_searchTerm);
        }

        IEnumerable<FontCharacter> Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                return _selectedItem.Items;
            }
            List<FontCharacter> result = new List<FontCharacter>();

            // Brute force search
            foreach (FontCharacter item in _selectedItem.Items)
            {
                if 
                (
                    item.Label.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase)
                    ||
                    item.Id.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase)
                )
                {
                    result.Add(item);
                }
            }

            return result;
        }

        #endregion Search
 
        #region Cached PropertyChangedEventArgs

        static readonly PropertyChangedEventArgs ItemsChangedEventArgs = new PropertyChangedEventArgs(nameof(Items));
        static readonly PropertyChangedEventArgs SelectedItemChangedEventArgs = new PropertyChangedEventArgs(nameof(SelectedItem));
        static readonly PropertyChangedEventArgs SearchTermChangedEventArgs = new PropertyChangedEventArgs(nameof(SearchTerm));

        #endregion Cached PropertyChangedEventArgs

    }
}
