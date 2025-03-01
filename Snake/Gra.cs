using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace Snake
{
    public class Gra
    {
        private Waz waz;
        private Jedzenie jedzenie;
        private bool czyKoniecGry;
        private int szerokoscEkranu;
        private int wysokoscEkranu;
        private int rozmiarSiatki;
        private int punkty = 0;
        private int szybkosc = 10;

        private void Inicjalizuj()
        {
            szerokoscEkranu = 800;
            wysokoscEkranu = 640;
            rozmiarSiatki = 40;
            czyKoniecGry = false;

            Raylib.InitWindow(szerokoscEkranu, wysokoscEkranu, "Gra Waz");
            Raylib.SetTargetFPS(szybkosc);

            waz = new Waz(rozmiarSiatki, szerokoscEkranu, wysokoscEkranu);
            jedzenie = new Jedzenie(szerokoscEkranu, wysokoscEkranu, rozmiarSiatki);
        }
        private void Rysuj()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib_cs.Color.Black);

            waz.Rysuj();
            jedzenie.Rysuj();

            Raylib.DrawText(punkty.ToString().PadLeft(2, '0'), 20, 20, 40, Raylib_cs.Color.White);

            if (czyKoniecGry)
            {
                Raylib.DrawText("Koniec Gry", szerokoscEkranu / 2 - 180, wysokoscEkranu / 2 - 70, 30, Raylib_cs.Color.Red);
                Raylib.DrawText("Nacisnij Enter aby zaczac ponownie", szerokoscEkranu / 2 - 270, wysokoscEkranu / 2 + 20, 30, Raylib_cs.Color.White);
            }


            Raylib.EndDrawing();    
        }

        public void Uruchom()
        {
            Inicjalizuj();
            while (!Raylib.WindowShouldClose())
            {
                Aktualizuj();
                Rysuj();
            }
            Raylib.CloseWindow();
        }

        public void Aktualizuj()
        {
            if (czyKoniecGry)
            {
                if (Raylib.IsKeyPressed(KeyboardKey.Enter))
                {
                    UruchomPonownie();
                }
                return;
            }

            if (Raylib.IsKeyPressed(KeyboardKey.Up)) waz.ZmienKierunek(new Vector2(0, -1));
            if (Raylib.IsKeyPressed(KeyboardKey.Down)) waz.ZmienKierunek(new Vector2(0, 1));
            if (Raylib.IsKeyPressed(KeyboardKey.Left)) waz.ZmienKierunek(new Vector2(-1, 0));
            if (Raylib.IsKeyPressed(KeyboardKey.Right)) waz.ZmienKierunek(new Vector2(1, 0));

            if (waz.SprawdzKolizje(jedzenie.Pozycja))
            {
                waz.Rosnij();
                jedzenie.GenerujNowaPozycje();
                punkty++;
                szybkosc = Math.Min(60, szybkosc + 1);
                Raylib.SetTargetFPS(szybkosc);
            }

            waz.Poruszaj();

            if (waz.SprawdzKolizjeZeSoba())
            {
                czyKoniecGry = true;
            }

        }
        public void UruchomPonownie()
        {
            punkty = 0;
            szybkosc = 10;
            waz = new Waz(rozmiarSiatki, szerokoscEkranu, wysokoscEkranu);
            jedzenie = new Jedzenie(szerokoscEkranu, wysokoscEkranu, rozmiarSiatki);
            czyKoniecGry = false;
            Raylib.SetTargetFPS(szybkosc);
        }
    }
}
