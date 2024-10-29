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
                new Game("Grand Thief Auto 5", Genre.Action, 1500),
                new Game("Skyrim", Genre.RPG, 690),
                new Game("Frostpunk 2", Genre.Strategy, 340),
                new Game("Outlust 2", Genre.Horror, 2000),
                new Game("FiFA 12", Genre.Sport, 210),
            };

            Dictionary<Genre, (int totalSales, decimal totalRevenue)> salesReport = new Dictionary<Genre, (int totalSales, decimal totalRevenue)>();

            foreach (var genre in Enum.GetValues(typeof(Genre)))
            {
                salesReport[(Genre)genre] = (0, 0);
            }

            int[,] fixedSales = new int[,]
            {
                { 3, 2, 1 },
                { 2, 3, 2 },
                { 1, 1, 0 },
                { 0, 2, 1 },
                { 1, 1, 1 }
            };

            for (int day = 0; day < 3; day++)
            {
                foreach (var game in games)
                {
                    int genreIndex = (int)game.Genre;
                    int salesCount = fixedSales[genreIndex, day];

                    var currentSalesData = salesReport[game.Genre];

                    currentSalesData.totalSales += salesCount;

                    currentSalesData.totalRevenue += salesCount * game.Price;

                    salesReport[game.Genre] = currentSalesData;
                }
            }

            Console.WriteLine("Отчёт по продажам игр по жанрам:");
            foreach (var report in salesReport)
            {
                Console.WriteLine($"Жанр: {report.Key}");
                Console.WriteLine($"Общее количество продаж: {report.Value.totalSales}");
                Console.WriteLine($"Общая выручка: {report.Value.totalRevenue}");
                Console.WriteLine();
            }
        }
    }
}