using System;
namespace ORM_Dapper_DB.Products
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public bool OnSale { get; set; }
        public string StockLevel { get; set; }




        public Product()
        {
        }
    }
}

