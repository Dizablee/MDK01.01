using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LABA2._0   
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                List<Game> games = new List<Game>()
            {
                new Game("Grand Theft Auto 5", Genre.Action, 1500),
                new Game("Skyrim", Genre.RPG, 690),
                new Game("Frostpunk 2", Genre.Strategy, 340),
                new Game("Outlast 2", Genre.Horror, 2000),
                new Game("FIFA 12", Genre.Sport, 210),
            };

                SalesHistory salesHistory = new SalesHistory();

                
                salesHistory.RecordSale(games[0], 3);
                salesHistory.RecordSale(games[1], 2);
                salesHistory.RecordSale(games[2], 1);
                salesHistory.RecordSale(games[3], 2);
                salesHistory.RecordSale(games[4], 1);

                Console.WriteLine("Отчёт по продажам игр по жанрам:");
                salesHistory.PrintSalesReport();
            }
        }
    }