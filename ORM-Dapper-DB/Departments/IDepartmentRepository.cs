using System;
namespace ORM_Dapper_DB
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments();

    }
}

