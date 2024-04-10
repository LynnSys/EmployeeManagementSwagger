using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class EmployeeDto
    {
        public Name EmployeeName { get; set; }
        public int EmployeeAge { get; set; }
        public int EmployeeSalary { get; set; }

        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must contain exactly 10 numeric digits")]
        public string PhoneNo { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        public Department Dept { get; set; }
    }
    public class Name
    {
        [Required] public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        [Required] public string LastName { get; set; }

    }
}
