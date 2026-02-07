using CRM.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

    private void UnternehmenButton_Click(object sender, RoutedEventArgs e)
        {
            var unternehmenView = new Views.UnternehmenListView();
            MainContentArea.Content = unternehmenView;
        }

    private void VersicherterButton_Click(object sender, RoutedEventArgs e)
        {
            var versicherterView = new Views.VersicherterListView();
            MainContentArea.Content = versicherterView;
        }
    }

}