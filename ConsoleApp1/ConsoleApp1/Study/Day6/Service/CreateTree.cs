
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
        // 회사와 부서를 저장
        private Dictionary<string, Company> companies = new Dictionary<string, Company>();
        private Dictionary<string, Department> departments = new Dictionary<string, Department>();

        // 데이터를 파싱하여 트리를 구성하는 초기 메서드
        public void BuildOrganizationTree(List<string> rowData)
        {

            foreach (string row in rowData)
            {
                string[] parts = row.Split(';');

                if (parts.Length < 8)
                {
                    Console.WriteLine($"데이터 형식이 맞지 않습니다. '{row}'");
                    return;
                }

                string companyName = parts[0];
                string companyPhone = parts[1];
                string companyAddress = parts[2];
                string departmentName = parts[3];
                string empName = parts[4];
                string empPosition = parts[5];
                string empContact = parts[6];
                string empEmail = parts[7];

                // 회사 객체 가져오기 또는 새로 생성
                Company currentCompany;
                if (!companies.ContainsKey(companyName))
                {
                    currentCompany = new Company(companyName, companyAddress, companyPhone);
                    companies.Add(companyName, currentCompany);
                }
                else
                {
                    currentCompany = companies[companyName];
                }

                // 부서 객체 가져오기 또는 새로 생성
                string departmentKey = $"{departmentName}";
                Department currentDepartment;
                if (!departments.ContainsKey(departmentKey))
                {
                    currentDepartment = new Department(departmentName, currentCompany);
                    currentCompany.Departments.Add(currentDepartment);
                    departments.Add(departmentKey, currentDepartment);
                }
                else
                {
                    currentDepartment = departments[departmentKey];
                }

                // 직원 객체 생성 및 부서에 추가
                Employee employee = new Employee(empName, empPosition, empContact, empEmail, currentDepartment);
                currentDepartment.Employees.Add(employee);
            }
        }
    }
}