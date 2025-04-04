﻿using ClassLibrary1;
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
            if (parts.Length == 5 && decimal.TryParse(parts[2], NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price) && int.TryParse(parts[4], out int quantity))
            {
                Products.Add(new Product { Brand = parts[0], Model = parts[1], Price = price, Category = parts[3], Quantity = quantity });
            }
        }
    }
    public List<ProductStock> CalculateStock()
    {
        // Сначала создаём словарь с начальными остатками из товаров
        var stock = Products.ToDictionary(p => p.Model, p => p.Quantity);

        // Затем вычитаем количество из продаж
        foreach (var sale in Sales)
        {
            if (stock.ContainsKey(sale.Model))
            {
                stock[sale.Model] -= sale.Quantity;
            }
        }

        // Формируем итоговый список остатков
        var result = from product in Products
                     where stock.ContainsKey(product.Model)
                     select new ProductStock
                     {
                         Brand = product.Brand,
                         Model = product.Model,
                         RemainingQuantity = stock[product.Model] < 0 ? 0 : stock[product.Model]
                     };

        return result.ToList();

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