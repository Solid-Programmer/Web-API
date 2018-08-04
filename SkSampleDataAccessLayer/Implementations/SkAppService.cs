using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkSampleContractsLayer.Contracts.BusinessEntities;
using SkSampleContractsLayer.Contracts.Interfaces;
using SkSampleDataAccessLayer.DataAccess.Interfaces;

namespace SkSampleDataAccessLayer.Implementations
{
    public class SkAppService :ISkAppService
    {
        public readonly IEmployeeRepository EmployeeRepository;
        public readonly IDepartmentRepository DepartmentRepository;

        public SkAppService(IEmployeeRepository employeeRepository, IDepartmentRepository departmentRepository)
        {
            EmployeeRepository = employeeRepository;
            DepartmentRepository = departmentRepository;
        }

        public IEnumerable<EmployeeDataModel> GetPagedEmployeeDataById(int id, int pageSize = 10, int pageNo = 1)
        {
            try
            {
                var employeeData = EmployeeRepository.GetPagedEmployeeById(id, pageSize, pageNo);
                var departmentData = DepartmentRepository.GetPagedDepartmentById(id, pageSize, pageNo);
                var employeeDataModel = from e in employeeData
                    join d in departmentData
                        on e.EmployeedId equals d.DepartmentId
                    select new EmployeeDataModel
                    {
                        EmployeedId = e.EmployeedId,
                        EmployeeName = e.EmployeeName,
                        Age = (DateTime.Today.Year - e.EmployeeBirthday.Year),
                        DepartmentName = d.DepartmentName
                    };
                return employeeDataModel.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public IEnumerable<EmployeeDataModel> GetPagedEmployeeDataByName(string name, int pageSize = 10, int pageNo = 1)
        {
            try
            {
                var employeeData = EmployeeRepository.GetPagedEmployeeByName(name, pageSize, pageNo).ToList();
                var departmentData = DepartmentRepository.DepartmentPagedData(pageSize, pageNo).ToList();
                var employeeDataModel = from e in employeeData
                    join d in departmentData
                        on e.DepartmentId equals d.DepartmentId into x
                    from result in x.DefaultIfEmpty()
                    select new EmployeeDataModel
                    {
                        EmployeedId = e.EmployeedId,
                        EmployeeName = e.EmployeeName,
                        Age = (DateTime.Today.Year - e.EmployeeBirthday.Year),
                        DepartmentName = result.DepartmentName
                    };
                return employeeDataModel.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
