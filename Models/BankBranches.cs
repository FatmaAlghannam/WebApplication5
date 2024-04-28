using System.ComponentModel.DataAnnotations;
using WebApplication2.Models;

namespace WebApplication5.Models
{
    public class BankBranches
    {
        public string LocationName { get; set; }
        public int Id { get; set; }
        public string LocationURL { get; set; }
        public string Branchmanger { get; set; }
        public int EmployeeCount { get; set; }
        public List<Employee> Employees { get; set; }
    }
   
}
