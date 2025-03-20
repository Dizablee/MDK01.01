using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ClassLibrary1
{
    public class ReportGenerator
    {
        public static void GenerateReport(List<Sale> sales, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine("Отчет о продажах:");
                foreach (var sale in sales)
                {
                    sw.WriteLine($"{sale.Brand} {sale.Model} - {sale.Quantity} шт. Дата: {sale.SaleDate}");
                }
            }
            Console.WriteLine($"Отчет сохранен в файл {filePath}");
        }
    }
}
