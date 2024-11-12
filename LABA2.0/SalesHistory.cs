using System;
using System.Collections.Generic;

namespace LABA2._0
{
    public class SalesHistory
    {
        private Dictionary<Game, (int totalSales, decimal totalRevenue)> salesReport;

        public SalesHistory()
        {
            salesReport = new Dictionary<Game, (int totalSales, decimal totalRevenue)>();
        }

        public void RecordSale(Game game, int salesCount)
        {
            if (!salesReport.ContainsKey(game))
            {
                salesReport[game] = (0, 0);
            }

            var currentSalesData = salesReport[game];
            currentSalesData.totalSales += salesCount;
            currentSalesData.totalRevenue += salesCount * game.GetPrice();

            salesReport[game] = currentSalesData;
        }

        public void PrintSalesReport()
        {
            foreach (var report in salesReport)
            {
                Console.WriteLine($"Игра: {report.Key.GetName()} (Жанр: {report.Key.GetGenre()})");
                Console.WriteLine($"Общее количество продаж: {report.Value.totalSales}");
                Console.WriteLine($"Общая выручка: {report.Value.totalRevenue}");
                Console.WriteLine();
            }
        }
    }
}