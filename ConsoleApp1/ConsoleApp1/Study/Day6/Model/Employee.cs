using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Study.Day6.Model
{
    public class Employee : Common
    {
        public string Age { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Gender { get; set; }
        public string EmployeePosition { get; set; }
        public Department Department { get; set; }
        
        public Employee(string name, string age, string gender, string position, string contact, string email, Department department)
        {
            Name = name;
            Email = email;
            Age = age;
            Gender = gender;
            EmployeePosition = position;
            Contact = contact;
            Email = email;
            Department = department;
            EmployeePosition = position;
        }

        public void PrintInfo()
        {
            Console.WriteLine("＝＝＝직원 정보＝＝＝");
            Console.WriteLine($"이름: {Name}");
            Console.WriteLine($"이메일: {Email}");
            Console.WriteLine($"나이: {Age}");
            Console.WriteLine($"성별: {Gender}");
            Console.WriteLine($"직책: {EmployeePosition}");
            Console.WriteLine($"연락처: {Contact}");
            Console.WriteLine($"이메일: {Email}");
            Console.WriteLine($"소속 부서: {Department.Name}");
            Console.WriteLine($"소속 회사: {Department.Company.Name}");
            Console.WriteLine();
        }
    }
}