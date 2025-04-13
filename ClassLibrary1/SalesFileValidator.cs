using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary1
{
    public class SalesFileValidator
    {
        public List<Product> Products { get; private set; } = new List<Product>();
        public List<Sale> Sales { get; private set; } = new List<Sale>();

        public int InvalidProductLinesCount { get; private set; }
        public int InvalidSalesLinesCount { get; private set; }

        public void LoadProducts(string filePath)
        {
            Products.Clear();
            InvalidProductLinesCount = 0;

            foreach (var line in File.ReadLines(filePath))
            {
                var parts = line.Split(';');
                if (parts.Length != 5)
                {
                    InvalidProductLinesCount++;
                    continue;
                }

                bool isPriceValid = decimal.TryParse(parts[2], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price);
                bool isQuantityValid = int.TryParse(parts[4], out int quantity);

                if (!isPriceValid || !isQuantityValid)
                {
                    InvalidProductLinesCount++;
                    continue;
                }

                Products.Add(new Product
                {
                    Brand = parts[0],
                    Model = parts[1],
                    Price = price,
                    Category = parts[3],
                    Quantity = quantity
                });
            }
        }

        public void LoadSales(string filePath)
        {
            Sales.Clear();
            InvalidSalesLinesCount = 0;

            foreach (var line in File.ReadLines(filePath))
            {
                var parts = line.Split(';');
                if (parts.Length != 4)
                {
                    InvalidSalesLinesCount++;
                    continue;
                }

                bool isDateValid = DateTime.TryParse(parts[2], out DateTime date);
                bool isQuantityValid = int.TryParse(parts[3], out int quantity);

                if (!isDateValid || !isQuantityValid)
                {
                    InvalidSalesLinesCount++;
                    continue;
                }

                Sales.Add(new Sale
                {
                    Brand = parts[0],
                    Model = parts[1],
                    SaleDate = date,
                    Quantity = quantity
                });

            }
        }
                public List<ParsedLine> LoadProductFileWithValidation(string filePath)
        {
            Products.Clear();
            var parsedLines = new List<ParsedLine>();

            foreach (var line in File.ReadLines(filePath))
            {
                var parts = line.Split(';');
                if (parts.Length != 5)
                {
                    parsedLines.Add(new ParsedLine { RawLine = line, IsValid = false, ErrorMessage = "Неверное количество столбцов" });
                    continue;
                }

                bool isPriceValid = decimal.TryParse(parts[2], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price);
                bool isQuantityValid = int.TryParse(parts[4], out int quantity);

                if (!isPriceValid || !isQuantityValid)
                {
                    parsedLines.Add(new ParsedLine { RawLine = line, IsValid = false, ErrorMessage = "Ошибка в числе или цене" });
                    continue;
                }

                Products.Add(new Product
                {
                    Brand = parts[0],
                    Model = parts[1],
                    Price = price,
                    Category = parts[3],
                    Quantity = quantity
                });

                parsedLines.Add(new ParsedLine { RawLine = line, IsValid = true });
            }

            return parsedLines;
        }
        public List<ParsedLine> LoadSalesFileWithValidation(string filePath)
        {
            Sales.Clear();
            var parsedLines = new List<ParsedLine>();

            foreach (var line in File.ReadLines(filePath))
            {
                var parts = line.Split(';');
                if (parts.Length != 4)
                {
                    parsedLines.Add(new ParsedLine { RawLine = line, IsValid = false, ErrorMessage = "Неверное количество столбцов" });
                    continue;
                }

                bool isDateValid = DateTime.TryParse(parts[2], out DateTime date);
                bool isQuantityValid = int.TryParse(parts[3], out int quantity);

                if (!isDateValid || !isQuantityValid)
                {
                    parsedLines.Add(new ParsedLine { RawLine = line, IsValid = false, ErrorMessage = "Ошибка в дате или количестве" });
                    continue;
                }

                Sales.Add(new Sale
                {
                    Brand = parts[0],
                    Model = parts[1],
                    SaleDate = date,
                    Quantity = quantity
                });

                parsedLines.Add(new ParsedLine { RawLine = line, IsValid = true });
            }

            return parsedLines;
        }
    }
}
        
    
