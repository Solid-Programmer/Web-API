using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkSampleContractsLayer.Contracts.BusinessEntities;

namespace SkSampleContractsLayer.Contracts.Interfaces
{
    public interface ISkAppService
    {
        IEnumerable<EmployeeDataModel> GetPagedEmployeeDataById(int id, int pageSize = 10, int pageNo = 1);
        IEnumerable<EmployeeDataModel> GetPagedEmployeeDataByName(string name, int pageSize = 10, int pageNo = 1);
    }
}
