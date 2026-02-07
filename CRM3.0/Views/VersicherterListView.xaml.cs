using CRM.Data;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CRM.Views
{
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

        private void NeuerVersicherterButton_Click(object sender, RoutedEventArgs e)
        {
            // Formular anzeigen
            var formView = new VersicherterFormView();

            // Events abonnieren
            formView.OnSaved += (s, args) =>
            {
                LoadData(); // Liste aktualisieren
                ZurückZurListe(); // Zurück zur Liste
            };
            formView.OnCancelled += (s, args) =>
            {
                ZurückZurListe(); // Zurück zur Liste
            };

            // Hauptbereich wechseln
            var mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainContentArea.Content = formView; 
            }
        }

        private void ZurückZurListe()
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainContentArea.Content = new VersicherterListView(); 
            }
        }
    }
}