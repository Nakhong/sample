
using ConsoleApp1.Study.Day6.Model;
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

        //public static void test(string row)
        //{
        //    string[] parts = row.Split(';');

        //    Company company = new Company(parts[0], parts[1], parts[2]);

        //    Department department = new Department(parts[3], company);
        //    company.Departments.Add(department);

        //    Employee employee = new Employee(parts[4], parts[5], parts[6], department, parts[7]);
        //    department.Employees.Add(employee);

        //    company.PrintInfo();
        //    department.PrintInfo();
        //    employee.PrintInfo();

        //}

        public static void test(string row)
        {
            string[] majorSections = row.Split('/');
            
            string[] companyDatas = majorSections[0].Split(';');
            //필드에 들어갈 값이 3개
            if (companyDatas.Length < 3)
            {
                Console.WriteLine("회사이름;전화번호;주소;로 입력해주세요.");
                return;
            }
            Company company = new Company(companyDatas[0], companyDatas[2], companyDatas[1]);

            string departmentName = majorSections[1].TrimEnd(';');

            Department department = new Department(departmentName, company);
            company.Departments.Add(department);

            Employee employee = new Employee(parts[4], parts[5], parts[6], department, parts[7]);
            department.Employees.Add(employee);

            company.PrintInfo();
            department.PrintInfo();
            foreach (var emp in department.Employees)
            {
                emp.PrintInfo();
            }
        }
    }
}