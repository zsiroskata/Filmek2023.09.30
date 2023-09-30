using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace filmek
{
    class Program
    {
        static List<Film> filmek = new List<Film>();
        static List<Film> filmTalalat(List<Film> filmek, string kulcs)
        {
            kulcs = kulcs.ToLower();
            List<Film> talalatok = filmek.Where(film => film.Cim.ToLower().Contains(kulcs) || film.Rendezo.ToLower().Contains(kulcs)).ToList();
            return talalatok;
        }
        static void Main(string[] args)
        {
            //1.feladat Beolvasni az adatokat a filmek.txt fájlból.
            var sr = new StreamReader(
               path: @"..\..\..\filmek.txt",
               encoding: System.Text.Encoding.UTF8
                );
            while (!sr.EndOfStream)
            {
                var sor = new Film(sr.ReadLine());
                filmek.Add(sor);
            }

            //2.feladat Megszámolni, hány film van az adatbázisban.
            Console.WriteLine("2.feladat");
            Console.WriteLine($"Az adatbázisban összesen: {filmek.Count} film van.");

            //3.feladat Kérni a felhasználótól egy cím kulcsszót.
            Console.Write("3.feladat\nÍrj egy kulcsszót: ");
            string kulcsszo = Console.ReadLine();

            //4.feladat Keresni az adatbázisban olyan filmeket, amelyek a címükben vagy rendezőjükben tartalmazzák a kulcsszót, majd kiírni ezeket a filmeket.
            Console.WriteLine("\n4.feladat");
            List<Film> talalat = filmTalalat(filmek, kulcsszo);
            if (talalat.Count > 0)
            {
                Console.WriteLine("van találta");
                foreach (var film in talalat)
                {
                    Console.WriteLine($"Rendező: {film.Rendezo}, cím: {film.Cim}, év: {film.Ev}, értékelés: {film.Ertekeles}");
                }
            }
            else
            {
                Console.WriteLine($"\"{kulcsszo}\" erre a kulcsszóra nincs találat az adatbázisban");
            }

            //5.feladat Számolni az átlagos értékelést az adatbázisban található filmekre és kiírni az eredményt a konzolra.
            Console.WriteLine("\n5.feladat");
            double atlag = 0;
            foreach (var film in filmek)
            {
                atlag = film.Ertekeles + atlag;
            }
            Console.WriteLine($"A filmek értékelésének az átlaga: {atlag / filmek.Count}");

        }
    }
}
