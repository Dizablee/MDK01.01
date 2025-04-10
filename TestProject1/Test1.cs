using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using ClassLibrary1; // Здесь находятся Product, Sale, ProductStock
using System.Linq;

namespace StoreTests
{
    [TestClass]
    public class StoreCalculateStockTests
    {
        [TestMethod]
        public void CalculateStock_Correct()
        {
            // Arrange
            var store = new Store();

            store.Products.AddRange(new List<Product>
            {
                new Product { Brand = "Apple", Model = "iPhone 13", Price = 999, Category = "Smartphone", Quantity = 10 },
                new Product { Brand = "Samsung", Model = "Galaxy S21", Price = 799, Category = "Smartphone", Quantity = 8 }
            });

            store.Sales.AddRange(new List<Sale>
            {
                new Sale { Brand = "Apple", Model = "iPhone 13", SaleDate = DateTime.Now, Quantity = 3 },
                new Sale { Brand = "Samsung", Model = "Galaxy S21", SaleDate = DateTime.Now, Quantity = 10 } // Продано больше, чем есть
            });

            // Act
            var stockList = store.CalculateStock();

            // Assert
            Assert.AreEqual(2, stockList.Count);

            var iphoneStock = stockList.FirstOrDefault(p => p.Model == "iPhone 13");
            var samsungStock = stockList.FirstOrDefault(p => p.Model == "Galaxy S21");

            Assert.IsNotNull(iphoneStock);
            Assert.IsNotNull(samsungStock);

            Assert.AreEqual(7, iphoneStock.RemainingQuantity);    // 10 - 3 = 7
            Assert.AreEqual(0, samsungStock.RemainingQuantity);   // 8 - 10 = -2 => 0
        }
    }
}