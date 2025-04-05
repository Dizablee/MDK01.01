using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

public class Store
{
    public List<Product> Products { get; private set; } = new List<Product>();
    public List<Sale> Sales { get; private set; } = new List<Sale>();

    public void LoadProducts(string filePath)
    {
        Products.Clear();
        foreach (var line in File.ReadLines(filePath))
        {
            var parts = line.Split(';');
            if (parts.Length == 4 && decimal.TryParse(parts[2], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price))
            {
                Products.Add(new Product { Brand = parts[0], Model = parts[1], Price = price, Category = parts[3] });
            }
        }
    }
    public List<ProductStock> CalculateStock()
    {
        var stock = Products.ToDictionary(p => p.Model, p => p.Quantity);

        foreach (var sale in Sales)
        {
            if (stock.ContainsKey(sale.Model))
            {
                stock[sale.Model] = sale.Quantity;
            }
        }

        return stock.Select(s => new ProductStock { Model = s.Key, RemainingQuantity = s.Value }).ToList();
    }

    public void LoadSales(string filePath)
    {
        Sales.Clear();  // Очищаем список перед загрузкой нового файла
        foreach (var line in File.ReadLines(filePath))
        {
            var parts = line.Split(';');
            if (parts.Length == 4 && DateTime.TryParse(parts[2], out DateTime date) && int.TryParse(parts[3], out int quantity))
            {
                Sales.Add(new Sale { Brand = parts[0], Model = parts[1], SaleDate = date, Quantity = quantity });
            }

        }
    }

    public List<Sale> GetSalesReport(DateTime start, DateTime end)
    {
        return Sales.Where(s => s.SaleDate >= start && s.SaleDate <= end).ToList();
    }
}  