using System;
namespace ORM_Dapper_DB.Products
{
    public class Product
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public int OnSale { get; set; }
        public string StockLevel { get; set; }


        public Product()
        {
        }
    }
}

