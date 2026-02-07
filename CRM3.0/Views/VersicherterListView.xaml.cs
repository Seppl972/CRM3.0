using CRM.Data;
using System;
using System.Collections.Generic;
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

namespace CRM.Views
{
    /// <summary>
    /// Interaktionslogik für VersicherterListView.xaml
    /// </summary>
    public partial class VersicherterListView : UserControl
    {
        public VersicherterListView()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (var db = new CrmDbContext())
            {
                var versicherte = db.Versicherte.ToList();
                VersicherteDataGrid.ItemsSource = versicherte;
            }
        }
    }
}
