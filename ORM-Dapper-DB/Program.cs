using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORM_Dapper_DB;
using ORM_Dapper_DB.Products;
using System.Data;
using static System.Console;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection connection = new MySqlConnection(connString);

var repo = new DapperDepartmentRepository(connection);

// Adding a New Department to the BestBuy DB //
//Console.WriteLine("Welcome to the Best Buy Database");
//Console.WriteLine();
//Console.Write("Please type a new Department Name: ");
//var newDepartment = Console.ReadLine();
//repo.InsertDepartment(newDepartment);
// Getting all of the Departments //
var departments = repo.GetDepartments();

//foreach (var department in departments)
//{
//    Console.WriteLine($"> Department Name: {department.Name} DepartmentId: {department.DepartmentId}");
//    Console.WriteLine();
//}

var prodRepo = new DapperProductRepository(connection);

var products = prodRepo.GetProducts();

foreach (var product in products)
{
    WriteLine();
    WriteLine($"> ProductId: {product.ProductId} Name: {product.Name} Price: {product.Price}\n> CategoryId: {product.CategoryId} OnSale: {product.OnSale} Stock Level: {product.StockLevel}");
    WriteLine();
}

WriteLine("Please Add a New Product to the Best Buy DataBase\n");
Write("> Please Enter a Product Name: ");
var name = ReadLine();
Write("> Please Enter a Product Price: ");
var price = Double.Parse(ReadLine());
Write("> Please Enter a CategoryId (1-10): ");
var categoryId = int.Parse(ReadLine());
Write("> Please Enter the Stock Amount: ");
var stock = ReadLine();


prodRepo.InsertProduct(name, price, categoryId, stock);

foreach (var product in products)
{
    WriteLine();
    WriteLine($"> ProductId: {product.ProductId} Name: {product.Name} Price: {product.Price}\n> CategoryId: {product.CategoryId} OnSale: {product.OnSale} Stock Level: {product.StockLevel}");
    WriteLine();
}



ReadKey();

