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
            return _connection.Query<Product>("SELECT * FROM Products p ORDER BY p.ProductId DESC LIMIT 50;");
        }

        // Insert a New Product //
        public void InsertProduct(string name, double price, int categoryId, string stock)
        {
            _connection.Execute("INSERT INTO Products (Name, Price, CategoryID, StockLevel) VALUES (@name, @price, @categoryID, @stock);", new Product { Name = name, Price = price, CategoryId = categoryId, StockLevel = stock });
        }
    }
}

