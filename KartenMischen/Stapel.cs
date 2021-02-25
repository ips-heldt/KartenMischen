using System;

namespace KartenMischen
{
    /// <summary>
    /// Enumeration welche die einzelnen Farben beinhaltet
    /// </summary>
    public enum Kartenfarbe
    {
        Rot = 0,
        Gruen = 1,
        Pik = 2,
        Karo = 3
    }

    /// <summary>
    /// Klasse Kartenstapel, sie besitzt alle Eigenschaften und Methoden
    /// eines klassischen Kartenstapels. Er hat mehrere einzelen Karten
    /// und kann gemischt werden
    /// </summary>
    public class Stapel
    {
        static Random rand;
        public int Kartenzahl = 0;
        public Karte[] Karten { get; private set; } = null;

        /// <summary>
        /// Konstruktor, der einen leeren Kartenstapel mit x Elementen instanziiert.
        /// Nach dem Aufruf erhält man einen gemischten Kartenstapel mit x Karten.
        /// </summary>
        /// <param name="AnzahlKarten"></param>
        public Stapel(int AnzahlKarten)
        {
            Karten = new Karte[AnzahlKarten];
            Anlegen();
            Karten = Mischen(Karten);
        }

        /// <summary>
        /// Diese Methode erstellt den Kartenstapel, also für jedes Element des Stapels
        /// eine Karte.
        /// </summary>
        private void Anlegen()
        {
            int Farben = 0;
            int numKarte = 0;
            int maxKarte = this.Karten.GetLength(0) / 4 + 7;
            Kartenfarbe KFarbe = Kartenfarbe.Gruen;

            while (numKarte < Karten.GetLength(0)) {
                switch (Farben)
                {
                    case 0:
                        KFarbe = Kartenfarbe.Gruen;
                        break;
                    case 1:
                        KFarbe = Kartenfarbe.Karo;
                        break;
                    case 2:
                        KFarbe = Kartenfarbe.Pik;
                        break;
                    case 3:
                        KFarbe = Kartenfarbe.Rot;
                        break;
                }
                for (int i = 7; i < maxKarte; i++)
                {
                    switch (i)
                    {
                        case 11:
                            Karten[numKarte] = new Karte(10, "bube", KFarbe);
                            Karten[++numKarte] = new Karte(10, "dame", KFarbe);
                            Karten[++numKarte] = new Karte(10, "könig", KFarbe);
                            Karten[++numKarte] = new Karte(10, "as", KFarbe);
                            i = 14;
                            break;
                        default:
                            Karten[numKarte] = new Karte(i, i.ToString(), KFarbe);
                            break;
                    }
                    numKarte++;
                }
                Farben++;
            }
        }

        /// <summary>
        /// Diese Methode mischt den vorhandenen Stapel, zufällig neu
        /// </summary>
        private static Karte[] Mischen(Karte[] Karten)
        {
            rand = new Random(0);
            Karte[] Gemischt = new Karte[Karten.GetLength(0)];

            for(int i = 0; i < Karten.GetLength(0); i++)
            {
                int pos;

                do
                {
                    pos = rand.Next(Karten.GetLength(0));
                } while (Gemischt.GetValue(pos) != null);
                Gemischt[pos] = Karten[i];
            }
            return Gemischt;
        }

        /// <summary>
        /// Überläd die Standard-Methode ToString() und gibt stattdessen den
        /// Inhalt des Stapels aus.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string Result = "";

            foreach(Karte k in this.Karten)
            {
                switch (k.Farbe)
                {
                    case Kartenfarbe.Gruen:
                        Result += String.Format("grün_{0}\n", k.Name);
                        break;
                    case Kartenfarbe.Rot:
                        Result += String.Format("rot_{0}\n", k.Name);
                        break;
                    case Kartenfarbe.Pik:
                        Result += String.Format("pik_{0}\n", k.Name);
                        break;
                    case Kartenfarbe.Karo:
                        Result += String.Format("karo_{0}\n", k.Name);
                        break;
                    default:
                        break;
                }
                
            }
            return Result;
        }
    }
}
