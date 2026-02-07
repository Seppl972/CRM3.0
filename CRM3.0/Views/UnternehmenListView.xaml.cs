using CRM.Data;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CRM.Views
{
    public partial class UnternehmenListView : UserControl
    {
        public UnternehmenListView()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (var db = new CrmDbContext())
            {
                var unternehmen = db.Unternehmen.ToList();
                UnternehmenDataGrid.ItemsSource = unternehmen;
            }
        }

        private void NeuesUnternehmenButton_Click(object sender, RoutedEventArgs e)
        {
            // Formular anzeigen
            var formView = new UnternehmenFormView();

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
                mainWindow.MainContentArea.Content = new UnternehmenListView(); 
            }
        }
    }
}