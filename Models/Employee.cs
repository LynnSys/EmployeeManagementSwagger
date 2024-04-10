using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;

namespace EmployeeManagementSystem.Models
{
    public class Employee
    {
        public string EmployeeID { get;set; }
        public bool isActive { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime CreatedDate { get; set; }


        public Name EmployeeName { get; set; }
        public int EmployeeAge { get; set; }
        public int EmployeeSalary { get; set; }
        public string email {  get; set; }
        public string phoneNo { get; set; }
         
        public Department Dept { get; set; }

        public Employee()
        {
            EmployeeID = Guid.NewGuid().ToString();
            isActive = true;
            CreatedDate = DateTime.Now;
            LastUpdated = DateTime.Now;

        }
        public Employee(EmployeeDto dto)
        {
            this.EmployeeID = Guid.NewGuid().ToString();
            this.EmployeeName = dto.EmployeeName;
            this.EmployeeAge = dto.EmployeeAge;
            this.EmployeeSalary = dto.EmployeeSalary;
            this.Dept = dto.Dept;
            this.isActive = true;
            this.CreatedDate = DateTime.Now;
            this.LastUpdated = DateTime.Now;
        }
    }
}
