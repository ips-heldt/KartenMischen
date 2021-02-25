namespace KartenMischen
{
    /// <summary>
    /// Diese Klasse stellt die Eigenschaften einer Spielkarte bereit.
    /// Da in einem Spiel mehrere unterschiedliche Karten existieren,
    /// kann diese Klasse nicht statisch sein.
    /// </summary>
    public class Karte
    {
        public int Augenzahl { get; private set; }
        public string Name { get; private set; }
        public Kartenfarbe Farbe { get; private set; }

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="Augen">Augenzahl der Karte</param>
        /// <param name="Name">Bezeichnung der Karte</param>
        /// <param name="Farbe">Kartenfarbe</param>
        public Karte(int Augen, string Name, Kartenfarbe Farbe)
        {
            this.Augenzahl = Augen;
            this.Name = Name;
            this.Farbe = Farbe;
        }
    }
}
