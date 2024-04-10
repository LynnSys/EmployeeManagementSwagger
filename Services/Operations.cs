using OperationsInterface;
using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
namespace CRUDOperations
{
    public class Operations : IOperations
    {
        string filepath = "./EmployeeData.json";
        private static List<Employee> EmployeeList = new List<Employee>();
        public Operations()
        {
            DeSerialzeFromJson(filepath);
        }
        public static void SerializeToJason(List<Employee> empList, string filepath)
        {
            try
            {
                string jsonString = JsonConvert.SerializeObject(empList);
                File.WriteAllText(filepath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void DeSerialzeFromJson(string filepath)
        {
            try
            {
                string jsonString = File.ReadAllText(filepath);
                EmployeeList = JsonConvert.DeserializeObject<List<Employee>>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine("List is empty: " + ex.Message);
            }

        }
     

        public Employee RetrieveEmployeeByID(string id)
        {
            try
            {
                Employee? employee = EmployeeList.FirstOrDefault(x => x.EmployeeID == id);
                return employee;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while retrieving employee: " + ex.Message);
                throw;
            }

        }

        public List<Employee> GetEmployeeList()
        {
            try
            {
                return EmployeeList;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


        public void AddEmployee(EmployeeDto e)
        {
            try
            {
                Employee emp = new Employee(e);
                EmployeeList.Add(emp);
                SerializeToJason(EmployeeList, filepath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot add Employee: " + ex.Message);
            }
        }

        
        public void UpdateEmployee(string eId, EmployeeDto updatedEmp)
        {
            try
            {
                Employee e = RetrieveEmployeeByID(eId);
                if (e != null)
                {
                    e.EmployeeAge = updatedEmp.EmployeeAge;
                    e.EmployeeName = updatedEmp.EmployeeName;
                    e.EmployeeSalary = updatedEmp.EmployeeSalary;
                    e.email = updatedEmp.Email;
                    e.phoneNo = updatedEmp.PhoneNo;
                    e.Dept = updatedEmp.Dept;
                    e.LastUpdated = DateTime.Now;
                }
                SerializeToJason(EmployeeList, filepath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Object with employee id " + eId + "does not exist: " + ex.Message);
            }
        }
        public void DeleteEmployee(string id)
        {
            try
            {
                Employee? employee = EmployeeList.FirstOrDefault(x => x.EmployeeID == id);
                EmployeeList.Remove(employee);
                SerializeToJason(EmployeeList, filepath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while deleting employee: " + ex.Message);
            }

        }

        public List<Employee> GetEmployeesByDepartment(int id)
        {
            try
            {
                var employee = EmployeeList.FindAll(x => x.Dept == (Department)id).ToList();
                return employee;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetEmployeesByDepartment: {ex.Message}");
                throw;
            }
        }

        public int GetCountOfEmployeesByDepartment(int id)
        {
            try
            {
                int count = EmployeeList.Count(emp => emp.Dept == (Department)id);

                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetCountOfEmployeesByDepartment: {ex.Message}");
                throw;
            }

        }
        public List<Employee> LastUpdatedEmployee()
        {
            try
            {
                List<Employee> lastUpdated = EmployeeList.OrderByDescending(x => x.LastUpdated)
                    .Take(5)
                    .ToList();
                return lastUpdated;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Last Updated Employee: {ex.Message}");
                throw;
            }
        }
        public void SoftDeleteEmployee(string id)
        {
            try
            {
                Employee? employee = EmployeeList.FirstOrDefault(x => x.EmployeeID == id);
                employee.isActive = true;
                SerializeToJason(EmployeeList, filepath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Soft Deleting: {ex.Message}");
                throw;
            }
        }
        public List<Employee> GetTopSalariesEmployeesDepartmentWise(int count)
        {
            try
            {
                return EmployeeList.GroupBy(x => x.Dept)
                    .SelectMany(group => group.OrderByDescending(x => x.EmployeeSalary).Take(count)).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetTopSalariesEmployeesDepartmentWise : {ex.Message}");
                throw;
            }
        }

    }
}
