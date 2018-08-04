using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkSampleDataAccessLayer.DataAccess;
using SkSampleDataAccessLayer.DataAccess.Interfaces;
using SkSampleDataAccessLayer.DataAccess.Repositories;

namespace SkSampleApplicationTests.IntegrationTests
{
    public class EmployeeRepositoryTest
    {
        private IEmployeeRepository _employeeRepository;

        [SetUp]
        public void Initialize()
        {
            var context = new SkAppContext(ConfigurationManager.ConnectionStrings["SampleAppConnection"].ConnectionString);
            _employeeRepository = new EmployeeRepository(context);

        }


        [Test]
        public void must_return_one_record_by_name()
        {
            string Name = "Naresh";

            var data = _employeeRepository.GetPagedEmployeeByName(Name).ToList();

            if (!data.Any())
            {
                Assert.Warn("There is no data in the table for this test case");
            }

            else
                Assert.IsTrue(data.Any());
        }

        [Test]
        public void must_return_one_record_by_id()
        {
            int id = 3;

            var data = _employeeRepository.GetPagedEmployeeById(id).ToList();

            if (!data.Any())
            {
                Assert.Warn("There is no data in the table for this test case");
            }

            else
                Assert.IsTrue(data.Any());
        }

        [Test]
        public void must_do_paging_by_name()
        {
            int pageSize = 5;
            int pageNo = 1;
            string Name = "Samar";

            var data = _employeeRepository.GetPagedEmployeeByName(Name, pageSize, pageNo).ToList();

            if (!data.Any())
            {
                Assert.Warn("There is no data in the table for this test case");
            }

            Assert.IsTrue(data.All(x => x.EmployeeName.ToUpper() == Name.ToUpper()));
        }

        [Test]
        public void must_do_paging_by_id()
        {
            int pageSize = 5;
            int pageNo = 2;
            int id = 5;

            var data = _employeeRepository.GetPagedEmployeeById(id, pageSize, pageNo).ToList();

            if (!data.Any())
            {
                Assert.Warn("There is no data in the table for this test case");
            }

            Assert.IsTrue(data.All(x => x.EmployeedId == id));
        }

    }
}
