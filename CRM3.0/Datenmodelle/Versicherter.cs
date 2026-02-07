namespace CRM.Datenmodelle
{
	public class Versicherter
	{
		// Primärschlüssel für Datenbank
		public int Id { get; set; }

		// Grunddaten
		public string Vorname { get; set; }
		public string Nachname { get; set; }
		public string Firma { get; set; }

		// Kontaktdaten
		public string Email { get; set; }
		public string Telefon { get; set; }
		public string Mobil { get; set; }

		// Adresse
		public string Straße { get; set; }
		public string PLZ { get; set; }
		public string Ort { get; set; }
		public string Land { get; set; }

		// Metadaten
		public DateTime ErstelltAm { get; set; }
		public DateTime? GeändertAm { get; set; }
		public string Notizen { get; set; }

		// Optional: Berechnete Property für Anzeige
		public string VollständigerName => $"{Vorname} {Nachname}";
	}
}