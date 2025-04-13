using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

public class Store
{
    public List<Product> Products { get; set; } = new List<Product>();
    public List<Sale> Sales { get; set; } = new List<Sale>();

    public List<ProductStock> CalculateStock()
    {
        // Сначала создаём словарь с начальными остатками из товаров
        var stock = Products.GroupBy(p => p.Model).ToDictionary(g => g.Key, g => g.Sum(p => p.Quantity));
     


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
    public List<Sale> GetSalesReport(DateTime start, DateTime end)
    {
        return Sales.Where(s => s.SaleDate >= start && s.SaleDate <= end).ToList();
    }
}  