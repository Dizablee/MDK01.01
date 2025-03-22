using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using static System.Formats.Asn1.AsnWriter;
using ClassLibrary1;

[TestClass]
public class StoreTests
{
    private Store _store;
    private string _productsFilePath;
    private string _salesFilePath;

    [TestInitialize]
    public void Setup()
    {
        _store = new Store();

        // Create temporary files for testing
        _productsFilePath = Path.GetTempFileName();
        _salesFilePath = Path.GetTempFileName();
    }

    [TestCleanup]
    public void TearDown()
    {
        // Clean up temporary files
        File.Delete(_productsFilePath);
        File.Delete(_salesFilePath);
    }

    [TestMethod]
    public void LoadProducts_ValidFile_ProductsLoadedCorrectly()
    {
        // Arrange
        string productsData = "BrandA;Model1;10.50;CategoryX\nBrandB;Model2;20.00;CategoryY\nBrandC;Model3;5.75;CategoryZ";
        File.WriteAllText(_productsFilePath, productsData);

        // Act
        _store.LoadProducts(_productsFilePath);

        // Assert
        Assert.AreEqual(3, _store.Products.Count);
        Assert.AreEqual("BrandA", _store.Products[0].Brand);
        Assert.AreEqual("Model1", _store.Products[0].Model);
        Assert.AreEqual(10.50m, _store.Products[0].Price);
        Assert.AreEqual("CategoryX", _store.Products[0].Category);

        Assert.AreEqual("BrandB", _store.Products[1].Brand);
        Assert.AreEqual("Model2", _store.Products[1].Model);
        Assert.AreEqual(20.00m, _store.Products[1].Price);
        Assert.AreEqual("CategoryY", _store.Products[1].Category);

        Assert.AreEqual("BrandC", _store.Products[2].Brand);
        Assert.AreEqual("Model3", _store.Products[2].Model);
        Assert.AreEqual(5.75m, _store.Products[2].Price);
        Assert.AreEqual("CategoryZ", _store.Products[2].Category);
    }

    [TestMethod]
    public void LoadProducts_InvalidFile_ProductsNotLoaded()
    {
        // Arrange
        string productsData = "BrandA;Model1;InvalidPrice;CategoryX\nBrandB;Model2;20.00;CategoryY";
        File.WriteAllText(_productsFilePath, productsData);

        // Act
        _store.LoadProducts(_productsFilePath);

        // Assert
        Assert.AreEqual(0, _store.Products.Count);
    }

    [TestMethod]
    public void LoadProducts_EmptyFile_ProductsListIsEmpty()
    {
        // Arrange
        File.WriteAllText(_productsFilePath, "");

        // Act
        _store.LoadProducts(_productsFilePath);

        // Assert
        Assert.AreEqual(0, _store.Products.Count);
    }

    [TestMethod]
    public void LoadSales_ValidFile_SalesLoadedCorrectly()
    {
        // Arrange
        string salesData = "BrandA;Model1;2023-10-26;5\nBrandB;Model2;2023-10-27;10\nBrandC;Model3;2023-10-28;2";
        File.WriteAllText(_salesFilePath, salesData);

        // Act
        _store.LoadSales(_salesFilePath);

        // Assert
        Assert.AreEqual(3, _store.Sales.Count);
        Assert.AreEqual("BrandA", _store.Sales[0].Brand);
        Assert.AreEqual("Model1", _store.Sales[0].Model);
        Assert.AreEqual(new DateTime(2023, 10, 26), _store.Sales[0].SaleDate);
        Assert.AreEqual(5, _store.Sales[0].Quantity);

        Assert.AreEqual("BrandB", _store.Sales[1].Brand);
        Assert.AreEqual("Model2", _store.Sales[1].Model);
        Assert.AreEqual(new DateTime(2023, 10, 27), _store.Sales[1].SaleDate);
        Assert.AreEqual(10, _store.Sales[1].Quantity);

        Assert.AreEqual("BrandC", _store.Sales[2].Brand);
        Assert.AreEqual("Model3", _store.Sales[2].Model);
        Assert.AreEqual(new DateTime(2023, 10, 28), _store.Sales[2].SaleDate);
        Assert.AreEqual(2, _store.Sales[2].Quantity);
    }

    [TestMethod]
    public void LoadSales_InvalidFile_SalesNotLoaded()
    {
        // Arrange
        string salesData = "BrandA;Model1;InvalidDate;5\nBrandB;Model2;2023-10-27;10";
        File.WriteAllText(_salesFilePath, salesData);

        // Act
        _store.LoadSales(_salesFilePath);

        // Assert
        Assert.AreEqual(0, _store.Sales.Count);
    }

    [TestMethod]
    public void LoadSales_EmptyFile_SalesListIsEmpty()
    {
        // Arrange
        File.WriteAllText(_salesFilePath, "");

        // Act
        _store.LoadSales(_salesFilePath);

        // Assert
        Assert.AreEqual(0, _store.Sales.Count);
    }

    [TestMethod]
    public void GetSalesReport_ValidRange_ReturnsCorrectSales()
    {
        // Arrange
        _store.Sales.Add(new Sale { Brand = "BrandA", Model = "Model1", SaleDate = new DateTime(2023, 10, 26), Quantity = 5 });
        _store.Sales.Add(new Sale { Brand = "BrandB", Model = "Model2", SaleDate = new DateTime(2023, 10, 27), Quantity = 10 });
        _store.Sales.Add(new Sale { Brand = "BrandC", Model = "Model3", SaleDate = new DateTime(2023, 10, 28), Quantity = 2 });
        _store.Sales.Add(new Sale { Brand = "BrandD", Model = "Model4", SaleDate = new DateTime(2023, 10, 29), Quantity = 7 });

        // Act
        var salesReport = _store.GetSalesReport(new DateTime(2023, 10, 27), new DateTime(2023, 10, 28));

        // Assert
        Assert.AreEqual(2, salesReport.Count);
        Assert.AreEqual("BrandB", salesReport[0].Brand);
        Assert.AreEqual("BrandC", salesReport[1].Brand);
    }

    [TestMethod]
    public void GetSalesReport_EmptyRange_ReturnsEmptyList()
    {
        // Arrange
        {
            _store.Sales.Add(new Sale { Brand = "BrandA", Model = "Model1", SaleDate = new DateTime(2023, 10, 26), Quantity = 5 });
            _store.Sales.Add(new Sale { Brand = "BrandB", Model = "Model2", SaleDate = new DateTime(2023, 10, 27), Quantity = 10 });
        };

        // Act
        var salesReport = _store.GetSalesReport(new DateTime(2023, 10, 28), new DateTime(2023, 10, 29));

        // Assert
        Assert.AreEqual(0, salesReport.Count);
    }

    [TestMethod]
    public void GetSalesReport_StartDateAfterEndDate_ReturnsEmptyList()
    {
        // Arrange
        
        {
            _store.Sales.Add(new Sale { Brand = "BrandA", Model = "Model1", SaleDate = new DateTime(2023, 10, 26), Quantity = 5 });
            _store.Sales.Add(new Sale { Brand = "BrandB", Model = "Model2", SaleDate = new DateTime(2023, 10, 27), Quantity = 10 });
        };

        // Act
        var salesReport = _store.GetSalesReport(new DateTime(2023, 10, 28), new DateTime(2023, 10, 26));

        // Assert
        Assert.AreEqual(0, salesReport.Count);
    }

    [TestMethod]
    public void LoadProducts_ClearsExistingProducts()
    {
        // Arrange
       
        {
            _store.Products.Add(new Product { Brand = "OldBrand", Model = "OldModel", Price = 99.99m, Category = "OldCategory" });
        }

        string productsData = "BrandA;Model1;10.50;CategoryX";
        File.WriteAllText(_productsFilePath, productsData);

        // Act
        _store.LoadProducts(_productsFilePath);

        // Assert
        Assert.AreEqual(1, _store.Products.Count);
        Assert.AreEqual("BrandA", _store.Products[0].Brand);
    }

    [TestMethod]
    public void LoadSales_ClearsExistingSales()
    {
        // Arrange
      
        {
            _store.Sales.Add(new Sale { Brand = "OldBrand", Model = "OldModel", SaleDate = DateTime.Now, Quantity = 1 });
        }

        string salesData = "BrandA;Model1;2023-10-26;5";
        File.WriteAllText(_salesFilePath, salesData);

        // Act
        _store.LoadSales(_salesFilePath);

        // Assert
        Assert.AreEqual(1, _store.Sales.Count);
        Assert.AreEqual("BrandA", _store.Sales[0].Brand);
    }
}