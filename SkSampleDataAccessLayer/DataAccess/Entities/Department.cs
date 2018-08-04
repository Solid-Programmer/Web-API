using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkSampleDataAccessLayer.DataAccess.Entities
{
    [Table("Departments", Schema = "dbo")]
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public IEnumerable<Employee> Employee { get; set; }

    }
}
