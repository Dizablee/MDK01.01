namespace TestProject1
{
    [TestClass]
    public class SalesReportTests
    {
        //  Класс для представления сущности Sale
        public class Sale
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int Quantity { get; set; }
            public DateTime SaleDate { get; set; }
        }

        // Класс для хранения и обработки продаж, содержащий метод GetSalesReport
        public class SalesProcessor
        {
            public List<Sale> Sales { get; set; } = new List<Sale>();

            public List<Sale> GetSalesReport(DateTime start, DateTime end)
            {
                return Sales.Where(s => s.SaleDate >= start && s.SaleDate <= end).ToList();
            }
        }

        // Класс для генерации отчета (как в исходном коде)
        public static class ReportGenerator
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


        [TestMethod]
        public void GetSalesReport_ReturnsSalesWithinDateRange()
        {
            // Arrange
            SalesProcessor processor = new SalesProcessor();
            processor.Sales = new List<Sale>
    {
        new Sale { Brand = "BrandA", Model = "Model1", Quantity = 10, SaleDate = new DateTime(2023, 01, 01) },
        new Sale { Brand = "BrandB", Model = "Model2", Quantity = 5, SaleDate = new DateTime(2023, 01, 15) },
        new Sale { Brand = "BrandC", Model = "Model3", Quantity = 2, SaleDate = new DateTime(2023, 02, 01) },
        new Sale { Brand = "BrandD", Model = "Model4", Quantity = 8, SaleDate = new DateTime(2023, 02, 15) },
        new Sale { Brand = "BrandE", Model = "Model5", Quantity = 3, SaleDate = new DateTime(2023, 03, 01) }
    };

            DateTime startDate = new DateTime(2023, 01, 10);
            DateTime endDate = new DateTime(2023, 02, 15);

            // Act
            List<Sale> report = processor.GetSalesReport(startDate, endDate);

            // Assert
            Assert.AreEqual(3, report.Count); // Ожидаем 3 продажи в диапазоне дат.
            Assert.IsTrue(report.All(s => s.SaleDate >= startDate && s.SaleDate <= endDate));
        }

        [TestMethod]
        public void GetSalesReport_ReturnsEmptyListWhenNoSalesInRange()
        {
            // Arrange
            SalesProcessor processor = new SalesProcessor();
            processor.Sales = new List<Sale>
            {
                new Sale { Brand = "BrandA", Model = "Model1", Quantity = 10, SaleDate = new DateTime(2023, 01, 01) },
                new Sale { Brand = "BrandB", Model = "Model2", Quantity = 5, SaleDate = new DateTime(2023, 03, 01) }
            };

            DateTime startDate = new DateTime(2023, 02, 01);
            DateTime endDate = new DateTime(2023, 02, 28);

            // Act
            List<Sale> report = processor.GetSalesReport(startDate, endDate);

            // Assert
            Assert.AreEqual(0, report.Count); // Ожидаем пустой список, т.к. нет продаж в диапазоне.
        }

        [TestMethod]
        public void GetSalesReport_HandlesStartAndEndDateSame()
        {
            // Arrange
            SalesProcessor processor = new SalesProcessor();
            processor.Sales = new List<Sale>
            {
                new Sale { Brand = "BrandA", Model = "Model1", Quantity = 10, SaleDate = new DateTime(2023, 01, 15) },
                new Sale { Brand = "BrandB", Model = "Model2", Quantity = 5, SaleDate = new DateTime(2023, 02, 15) }
            };

            DateTime sameDate = new DateTime(2023, 01, 15);

            // Act
            List<Sale> report = processor.GetSalesReport(sameDate, sameDate);

            // Assert
            Assert.AreEqual(1, report.Count); // Ожидаем 1 продажу, т.к. дата продажи совпадает с начальной и конечной датой.
            Assert.AreEqual(sameDate, report[0].SaleDate); // Проверяем, что дата продажи совпадает с заданной датой.
        }


        [TestMethod]
        public void GenerateReport_CreatesFileWithCorrectContent()
        {
            // Arrange
            List<Sale> sales = new List<Sale>
            {
                new Sale { Brand = "BrandX", Model = "Car1", Quantity = 2, SaleDate = new DateTime(2023, 10, 26) },
                new Sale { Brand = "BrandY", Model = "Truck2", Quantity = 1, SaleDate = new DateTime(2023, 10, 27) }
            };

            string filePath = "test_report.txt";

            // Clean up the file before the test
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }


            // Act
            ReportGenerator.GenerateReport(sales, filePath);

            // Assert
            Assert.IsTrue(File.Exists(filePath));

            string[] lines = File.ReadAllLines(filePath);
            Assert.AreEqual("Отчет о продажах:", lines[0]);
            Assert.AreEqual("BrandX Car1 - 2 шт. Дата: 26.10.2023 0:00:00", lines[1]);
            Assert.AreEqual("BrandY Truck2 - 1 шт. Дата: 27.10.2023 0:00:00", lines[2]);

            // Clean up the file after the test
            File.Delete(filePath);
        }
    }
}
