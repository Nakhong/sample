
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

            string allEmployeesRaw = majorSections[2].TrimStart(',').TrimEnd(';');

            string[] employeeRecords = allEmployeesRaw.Split(',');

            foreach (string empRecord in employeeRecords)
            {
                string[] empFields = empRecord.Split(';');

                if (empFields.Length == 7)
                {
                    string empName = empFields[0];
                    string empAge = empFields[1];
                    string empGender = empFields[2];
                    string empPosition = empFields[3];
                    string empContact = empFields[4];
                    string empEmail = empFields[5];

                    Employee employee = new Employee(empName, empAge, empGender, empPosition, empContact, empEmail, department);
                    department.Employees.Add(employee);
                }
                else
                {
                    Console.WriteLine($"작성한 부분의 값이 올바르지 않아서 에러가 났습니다.");
                }
            }

            company.PrintInfo();
            department.PrintInfo();
            foreach (var emp in department.Employees)
            {
                emp.PrintInfo();
            }
        }
    }
}