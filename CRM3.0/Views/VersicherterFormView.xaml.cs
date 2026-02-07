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
using CRM.Data;
using CRM.Datenmodelle;

namespace CRM.Views
{
    public partial class VersicherterFormView : UserControl
    {
        public event EventHandler? OnSaved;
        public event EventHandler? OnCancelled;

        public VersicherterFormView()
        {
            InitializeComponent();
        }

        private void SpeichernButton_Click(object sender, RoutedEventArgs e)
        {
            // Validierung
            if (string.IsNullOrWhiteSpace(VornameTextBox.Text) || string.IsNullOrWhiteSpace(NachnameTextBox.Text))
            {
                MessageBox.Show("Bitte Vor- und Nachname eingeben!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Neuen Versicherten erstellen
            var versicherter = new Versicherter
            {
                Vorname = VornameTextBox.Text,
                Nachname = NachnameTextBox.Text,
                Firma = FirmaTextBox.Text,
                Email = EmailTextBox.Text,
                Telefon = TelefonTextBox.Text,
                Mobil = MobilTextBox.Text,
                Straße = StraßeTextBox.Text,
                PLZ = PLZTextBox.Text,
                Ort = OrtTextBox.Text,
                Notizen = NotizenTextBox.Text,
                ErstelltAm = DateTime.Now
            };

            // In Datenbank speichern
            using (var db = new CrmDbContext())
            {
                db.Versicherte.Add(versicherter);
                db.SaveChanges();
            }

            MessageBox.Show("Versicherter erfolgreich gespeichert!", "Erfolg", MessageBoxButton.OK, MessageBoxImage.Information);

            // Event auslösen, damit die Liste aktualisiert wird
            OnSaved?.Invoke(this, EventArgs.Empty);
        }

        private void AbbrechenButton_Click(object sender, RoutedEventArgs e)
        {
            // Direkt zur Liste zurück
            var mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainContentArea.Content = new VersicherterListView();
            }
        }
    }
}