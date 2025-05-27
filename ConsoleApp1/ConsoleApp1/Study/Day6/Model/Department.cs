using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Study.Day6.Model
{
    public class Department : Common
    {
        public List<Employee> Employees { get; set; }
        public Company Company { get; set; }

        public Department(string name, Company company)
        {
            Name = name;
            Company = company;
            Employees = new List<Employee>();
        }

        public void PrintInfo()
        {
            Console.WriteLine("＝＝＝부서 정보＝＝＝");
            Console.WriteLine($"부서명: {Name}");
            Console.WriteLine($"소속 회사: {Company.Name}");
            Console.WriteLine("직원 리스트:");
            foreach (var emp in Employees)
            {
                Console.WriteLine($"  - {emp.Name} (직책: {emp.EmployeePosition})");
            }
            Console.WriteLine();
        }
    }
}