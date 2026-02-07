using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CRM.Datenmodelle;

namespace CRM.Data
{
    public class DatabaseInitializer
    {
        public static void Initialize()
        {
            using (var db = new CrmDbContext())
            {
                // Prüfen ob schon Daten vorhanden sind
                if (db.Unternehmen.Any() || db.Versicherte.Any())
                    return; // Bereits Daten vorhanden

                // Testdaten für Unternehmen
                db.Unternehmen.AddRange(
                    new Unternehmen
                    {
                        Firmenname = "Mustermann GmbH",
                        Rechtsform = "GmbH",
                        Ort = "München",
                        Telefon = "089-123456",
                        Email = "info@mustermann.de",
                        ErstelltAm = DateTime.Now
                    },
                    new Unternehmen
                    {
                        Firmenname = "Schmidt & Partner",
                        Rechtsform = "GbR",
                        Ort = "Hamburg",
                        Telefon = "040-789012",
                        Email = "kontakt@schmidt.de",
                        ErstelltAm = DateTime.Now
                    },
                    new Unternehmen
                    {
                        Firmenname = "Technik Solutions",
                        Rechtsform = "AG",
                        Ort = "Berlin",
                        Telefon = "030-345678",
                        Email = "info@technik-solutions.de",
                        ErstelltAm = DateTime.Now
                    }
                );

                // Testdaten für Versicherte
                db.Versicherte.AddRange(
                    new Versicherter
                    {
                        Vorname = "Max",
                        Nachname = "Mustermann",
                        Firma = "Mustermann GmbH",
                        Ort = "München",
                        Telefon = "0171-1234567",
                        Email = "max@mustermann.de",
                        ErstelltAm = DateTime.Now
                    },
                    new Versicherter
                    {
                        Vorname = "Anna",
                        Nachname = "Schmidt",
                        Firma = "Schmidt & Partner",
                        Ort = "Hamburg",
                        Telefon = "0172-9876543",
                        Email = "anna@schmidt.de",
                        ErstelltAm = DateTime.Now
                    },
                    new Versicherter
                    {
                        Vorname = "Peter",
                        Nachname = "Müller",
                        Firma = "Technik Solutions",
                        Ort = "Berlin",
                        Telefon = "0173-5555555",
                        Email = "peter@technik.de",
                        ErstelltAm = DateTime.Now
                    }
                );

                db.SaveChanges();
            }
        }
    }
}