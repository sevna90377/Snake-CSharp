using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Waz
    {
        private List<Vector2> cialo;
        private Vector2 kierunek;
        private int rozmiarSiatki;
        private int szerokoscEkranu;
        private int wysokoscEkranu;
        private bool rosnij;

        public Waz(int rozmiarSiatki, int szerokoscEkranu, int wysokoscEkranu)
        {
            this.rozmiarSiatki = rozmiarSiatki;
            this.szerokoscEkranu = szerokoscEkranu;
            this.wysokoscEkranu = wysokoscEkranu;
            cialo = new List<Vector2>();
            cialo.Add(new Vector2(szerokoscEkranu / 2, wysokoscEkranu / 2));
            kierunek = new Vector2(1, 0);
            rosnij = false;
        }

        public void Poruszaj()
        {
            Vector2 glowa = cialo[0];
            Vector2 nowaGlowa = new Vector2(glowa.X + kierunek.X * rozmiarSiatki, glowa.Y + kierunek.Y * rozmiarSiatki);

            if (rosnij)
            {
                cialo.Insert(0, nowaGlowa);
                rosnij = false;
            }
            else
            {
                for(int i = cialo.Count - 1; i > 0; i--)
                {
                    cialo[i] = cialo[i - 1];
                }
                cialo[0] = nowaGlowa;
            }

            if (nowaGlowa.X >= szerokoscEkranu) 
                nowaGlowa.X = 0;
            if (nowaGlowa.X < 0) 
                nowaGlowa.X = szerokoscEkranu - rozmiarSiatki;
            if (nowaGlowa.Y >= wysokoscEkranu) 
                nowaGlowa.Y = 0;
            if (nowaGlowa.Y < 0) 
                nowaGlowa.Y = wysokoscEkranu - rozmiarSiatki;

            cialo[0] = nowaGlowa;
        }

        private void Rosnij()
        {
            rosnij = true;
        }

        public void ZmienKierunek(Vector2 nowyKierunek)
        {
            if ((kierunek.X + nowyKierunek.X != 0) || (kierunek.Y +
            nowyKierunek.Y != 0))
            {
                kierunek = nowyKierunek;
            }
        }

        public void Rysuj()
        {
            foreach (var segment in cialo)
            {
                Raylib.DrawRectangle((int)segment.X, (int)segment.Y,
                rozmiarSiatki, rozmiarSiatki, Color.Green);
            }
        }

        public bool SprawdzKolizje(Vector2 pozycja)
        {
            foreach (var segment in cialo)
            {
                if (segment == pozycja)
                {
                    return true;
                }
            }
            return false;
        }

        public bool SprawdzKolizjeZeSoba()
        {
            Vector2 glowa = cialo[0];
            for (int i = 1; i < cialo.Count; i++)
            {
                if (cialo[i] == glowa)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
