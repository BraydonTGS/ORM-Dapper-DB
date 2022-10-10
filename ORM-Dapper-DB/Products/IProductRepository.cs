using System;
namespace ORM_Dapper_DB.Products
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
    }
}

