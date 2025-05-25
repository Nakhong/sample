using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Study.Day5
{
    public abstract class Common
    {
        public string Name { get; set; }
        public enum Position
        {
            //Director,// 이사
            //SeniorManager,// 수석
            //Manager,// 책임
            //SeniorAssistant,// 선임
            //Assistant// 전임
            이사,// 이사
            수석,// 수석
            책임,// 책임
            선임,// 선임
            전임// 전임
        }
    }

    public class Company : Common
    {
        public string Address { get; set; }
        public string CompanyPhoneNumber { get; set; }
        public List<Department> Departments { get; set; }

        public Company(string name, string address, string phoneNumber)
        {
            Name = name;
            Address = address;
            CompanyPhoneNumber = phoneNumber;
            Departments = new List<Department>();
        }

        public void PrintInfo()
        {
            Console.WriteLine("회사 정보");
            Console.WriteLine($"회사명: {Name}");
            Console.WriteLine($"주소: {Address}");
            Console.WriteLine($"전화번호: {CompanyPhoneNumber}");
            Console.WriteLine();
        }
    }

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
            Console.WriteLine("부서 정보");
            Console.WriteLine($"부서명: {Name}");
            Console.WriteLine($"소속 회사: {Company.Name}");
            Console.WriteLine("직원 리스트:");
            foreach (var emp in Employees)
            {
                Console.WriteLine($"  - {emp.Name} (사번: {emp.EmployeeId})");
            }
            Console.WriteLine();
        }
    }

    public class Employee : Common
    {
        public string EmployeeId { get; set; }
        public string Contact { get; set; }
        public string EmployeePosition { get; set; }
        public Department Department { get; set; }

        public Employee(string name, string employeeId, string contact, Department department, string position)
        {
            Name = name;
            EmployeeId = employeeId;
            Contact = contact;
            Department = department;
            EmployeePosition = position;
        }

        public void PrintInfo()
        {
            Console.WriteLine("직원 정보");
            Console.WriteLine($"이름: {Name}");
            Console.WriteLine($"사번: {EmployeeId}");
            Console.WriteLine($"연락처: {Contact}");
            Console.WriteLine($"소속 부서: {Department.Name}");
            Console.WriteLine($"소속 회사: {Department.Company.Name}");
            Console.WriteLine();
        }
    }
}
