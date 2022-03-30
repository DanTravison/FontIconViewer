using FontIconViewer.Model;
using System.Windows;

namespace FontIconViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainViewModel();

            InitializeComponent();
        }
    }
}
