using System;
using System.Collections.Generic;

namespace LABA2._0
{
    public class SalesHistory
    {
        private Dictionary<Genre, (int totalSales, decimal totalRevenue)> salesReport;

        public SalesHistory()
        {
            salesReport = new Dictionary<Genre, (int totalSales, decimal totalRevenue)>();
            foreach (var genre in Enum.GetValues(typeof(Genre)))
            {
                salesReport[(Genre)genre] = (0, 0);
            }
        }

        public void RecordSale(Game game, int salesCount)
        {
            var genre = game.GetGenre();
            var price = game.GetPrice();

            var currentSalesData = salesReport[genre];
            currentSalesData.totalSales += salesCount;
            currentSalesData.totalRevenue += salesCount * price;

            salesReport[genre] = currentSalesData;
        }

        public void PrintSalesReport()
        {
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