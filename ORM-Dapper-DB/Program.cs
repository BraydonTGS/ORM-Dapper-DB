﻿using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ORM_Dapper_DB;
using System.Data;

var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

string connString = config.GetConnectionString("DefaultConnection");

IDbConnection connection = new MySqlConnection(connString);

var repo = new DapperDepartmentRepository(connection);

Console.WriteLine("Welcome to the Best Buy Database");
Console.WriteLine();
Console.Write("Please type a new Department Name: ");
var newDepartment = Console.ReadLine();
repo.InsertDepartment(newDepartment);

var departments = repo.GetDepartments();


foreach (var department in departments)
{
    Console.WriteLine($"{department.Name}: {department.DepartmentId}");
}

Console.ReadKey();

