using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS.Primer1.Model
{
    public class Employee
    {
        public Employee(string name)
        {
            this.name = name;
        }

        public string name { get; set; }
        public List<Employee> Employees
        {
            get
            {
                return EmployeesList;
            }
        }

        public void isEmployeeOf(Employee p)
        {
            EmployeesList.Add(p);
        }

        List<Employee> EmployeesList = new List<Employee>();

        public override string ToString()
        {
            return name;
        }
    }
}
