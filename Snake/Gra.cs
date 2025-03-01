using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace Snake
{
    public class Gra
    {
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
        }
        private void Rysuj()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib_cs.Color.Black);

            Raylib.DrawText(punkty.ToString().PadLeft(2, '0'), 20, 20, 40, Raylib_cs.Color.White);

            if (!czyKoniecGry)
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
                //Aktualizuj();
                Rysuj();
            }
            Raylib.CloseWindow();
        }
    }
}
