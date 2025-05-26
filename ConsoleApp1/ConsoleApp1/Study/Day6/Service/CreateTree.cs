using ConsoleApp1.Study.Day5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Study.Day6.Service
{
    public class CreateTree
    {
        public Dictionary<string, string> Data { get; set; }

        public static void test(string row)
        {
            string[] parts = row.Split(';');

            Company company = new Company(parts[0], parts[1], parts[2]);

            Department department = new Department(parts[3], company);
            company.Departments.Add(department);

            Employee employee = new Employee(parts[4], parts[5], parts[6], department, parts[7]);
            department.Employees.Add(employee);

            company.PrintInfo();
            department.PrintInfo();
            employee.PrintInfo();

        }
    }
}