using System;
using System.Data;
using Dapper;

namespace ORM_Dapper_DB
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        // IDbConnection comes from system data //
        // Because its readonly you can only give it value during the initialization or in it's class constructor //
        // The value will never change //
        private readonly IDbConnection _connection;

        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        // Return a collection of department objects // 
        public IEnumerable<Department> GetDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM Departments");
        }


        // Execute will execute a parameterized query for us //
        public void InsertDepartment(string newDepartment)
        {
            _connection.Execute("INSERT INTO Departments (Name) VALUES (@departmentName);", new { departmentName = newDepartment });
        }
    }
}

