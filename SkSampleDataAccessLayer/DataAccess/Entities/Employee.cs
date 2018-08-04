using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkSampleDataAccessLayer.DataAccess.Entities
{
    [Table("Employees", Schema = "dbo")]
    public class Employee
    {
        [Key]
        public int EmployeedId { get; set; }
        public string EmployeeName { get; set; }
        public DateTime EmployeeBirthday { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}