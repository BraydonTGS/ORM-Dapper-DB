using System;
using System.Data;
using Dapper;

namespace ORM_Dapper_DB.Products
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _connection.Query<Product>("SELECT * FROM Products p ORDER BY p.ProductId DESC LIMIT 5;");
        }

        // Insert a New Product //
        public void InsertProduct(string name, double price, int categoryId, int sale, string stock)
        {
            _connection.Execute("INSERT INTO Products (Name, Price, CategoryID, OnSale, StockLevel) VALUES (@name, @price, @categoryID, @sale, @stock);",
            new { name = name, price = price, categoryId = categoryId, sale = sale, stock = stock });

        }

        // Update a Product //
        public void UpdateProduct(int prodId, string name, double price, int categoryId, int sale, string stock)
        {
            _connection.Execute("UPDATE Products SET Name = @name, Price = @price, CategoryID = @categoryId, OnSale = @sale, StockLevel = @stock WHERE ProductID = @prodId;", new { name = name, price = price, categoryId = categoryId, sale = sale, stock = stock, prodId = prodId, });
        }

        // Delete a Product //

        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM reviews WHERE ProductID = @productID;",
               new { productID = productID });

            _connection.Execute("DELETE FROM sales WHERE ProductID = @productID;",
               new { productID = productID });

            _connection.Execute("DELETE FROM products WHERE ProductID = @productID;",
               new { productID = productID });
        }
    }
}

