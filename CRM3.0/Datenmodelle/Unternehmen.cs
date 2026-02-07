using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Datenmodelle
{
    public class Unternehmen
    {
        // Primärschlüssel für Datenbank
        public int Id { get; set; }

        // Grunddaten
        public string? Firmenname { get; set; }
        public string? Rechtsform { get; set; } // z.B. GmbH, AG, KG
        public string? Branche { get; set; }

        // Kontaktdaten
        public string? Email { get; set; }
        public string? Telefon { get; set; }
        public string? Fax { get; set; }
        public string? Website { get; set; }

        // Adresse
        public string? Straße { get; set; }
        public string? PLZ { get; set; }
        public string? Ort { get; set; }
        public string? Land { get; set; }

        // Geschäftsdaten
        public string? Handelsregisternummer { get; set; }
        public string? Steuernummer { get; set; }
        public string? UStIdNr { get; set; } // Umsatzsteuer-Identifikationsnummer

        // Ansprechpartner
        public string? AnsprechpartnerName { get; set; }
        public string? AnsprechpartnerPosition { get; set; }

        // Metadaten
        public DateTime ErstelltAm { get; set; }
        public DateTime? GeändertAm { get; set; }
        public string? Notizen { get; set; }

        // Optional: Berechnete Property für Anzeige
        public string VollständigerName => string.IsNullOrEmpty(Rechtsform)
            ? Firmenname ?? ""
            : $"{Firmenname} {Rechtsform}";
    }
}