using System;
using System.Collections.Generic;
using System.Linq;
using SkSampleDataAccessLayer.DataAccess.Entities;
using SkSampleDataAccessLayer.DataAccess.Interfaces;

namespace SkSampleDataAccessLayer.DataAccess.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee, SkAppContext>, IEmployeeRepository
    {
        private readonly SkAppContext _context;

        public EmployeeRepository(SkAppContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Employee> GetPagedEmployeeByName(string name, int pageSize = 15, int pageNo = 1)
        {
            var query = EmployeePagedData(pageSize, pageNo).Where(x => x.EmployeeName.ToUpper() == name.ToUpper());
            return query;

        }

        public IQueryable<Employee> GetPagedEmployeeById(int id, int pageSize = 15, int pageNo = 1)
        {
            var query = EmployeePagedData(pageSize, pageNo).Where(x => x.EmployeedId == id);
            return query;

        }

        public IQueryable<Employee> EmployeePagedData(int pageSize = 15, int pageNo = 1)
        {
            var query = _context.Employees.OrderBy(x => x.EmployeedId).Skip((pageNo - 1) * pageSize).Take(pageSize);
            return query;

        }
    }
}
