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
    public partial class UnternehmenFormView : UserControl
    {
        public event EventHandler? OnSaved;
        public event EventHandler? OnCancelled;

        public UnternehmenFormView()
        {
            InitializeComponent();
        }

        private void SpeichernButton_Click(object sender, RoutedEventArgs e)
        {
            // Validierung
            if (string.IsNullOrWhiteSpace(FirmennameTextBox.Text))
            {
                MessageBox.Show("Bitte Firmenname eingeben!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Neues Unternehmen erstellen
            var unternehmen = new Unternehmen
            {
                Firmenname = FirmennameTextBox.Text,
                Rechtsform = RechtsformTextBox.Text,
                Branche = BrancheTextBox.Text,
                Email = EmailTextBox.Text,
                Telefon = TelefonTextBox.Text,
                Straße = StraßeTextBox.Text,
                PLZ = PLZTextBox.Text,
                Ort = OrtTextBox.Text,
                ErstelltAm = DateTime.Now
            };

            // In Datenbank speichern
            using (var db = new CrmDbContext())
            {
                db.Unternehmen.Add(unternehmen);
                db.SaveChanges();
            }

            MessageBox.Show("Unternehmen erfolgreich gespeichert!", "Erfolg", MessageBoxButton.OK, MessageBoxImage.Information);

            // Event auslösen, damit die Liste aktualisiert wird
            OnSaved?.Invoke(this, EventArgs.Empty);
        }

        private void AbbrechenButton_Click(object sender, RoutedEventArgs e)
        {
            // Direkt zur Liste zurück
            var mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {
                mainWindow.MainContentArea.Content = new UnternehmenListView();
            }
        }
    }
}