using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Jedzenie
    {
        public Vector2 Pozycja { get; private set; }

        private int szerokoscEkranu;
        private int wysokoscEkranu;
        private int rozmiarSiatki;

        public Jedzenie(int szerokoscEkranu, int wysokoscEkranu, int rozmiarSiatki)
        {
            this.szerokoscEkranu = szerokoscEkranu;
            this.wysokoscEkranu = wysokoscEkranu;
            this.rozmiarSiatki = rozmiarSiatki;
            GenerujNowaPozycje();
        }

        public void GenerujNowaPozycje()
        {
            Random random = new Random();
            int x = random.Next(0, szerokoscEkranu / rozmiarSiatki) * rozmiarSiatki;
            int y = random.Next(0, wysokoscEkranu / rozmiarSiatki) * rozmiarSiatki;
            Pozycja = new Vector2(x, y);
        }
        public void Rysuj()
        {
            Raylib.DrawRectangle((int)Pozycja.X, (int)Pozycja.Y, rozmiarSiatki, rozmiarSiatki, Raylib_cs.Color.DarkPurple);
        }

    }
}
