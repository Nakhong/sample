
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
            //트리 입출력
            printOrganizationTree();
        }

        public void printOrganizationTree()
        {
            printList(companies);   //회사 목록 출력

            string companyName = Console.ReadLine();    //회사 입력 받기.
            string departmentName;
            string employeePosition;

            foreach (var data in companies)
            {
                if (validationKey(companies,companyName))
                {
                    //Name과 같은 key가 있으면 그 data를 가지고 for문을 돌린다.
                    printList(data.Value.Departments);
                    departmentName = Console.ReadLine();
                    
                    if (validationKey(departments,departmentName))
                    {
                        employeePosition = Console.ReadLine(); // 포지션 입력
                        printEmployees();
                    }
                }
                else
                {

                    Console.WriteLine("다시 입력해주세요");
                    printOrganizationTree();
                }
            }
        }

        // 회사
        private void printList<T>(Dictionary<string, T> dictionaries) where T : Company
        {
            if (typeof(T).Name == "Company")
            {
                Console.WriteLine("--- 회사 목록입니다. ---");
            }

            if (dictionaries.Any()) // 딕셔너리에 요소가 있는지 확인
            {
                foreach (var datas in dictionaries.Values)
                {
                    Console.WriteLine($"{datas.Name} {datas.Address} {datas.CompanyPhoneNumber}");
                }
                Console.Write("회사명을 입력해주세요 :");
            }
            else
            {
                Console.WriteLine("목록이 비어 있습니다.");
            }
        }

        // 리스트의 Name 속성을 출력
        private void printList<T>(List<T> list) where T : Common
        {
            if (typeof(T).Name == "Department")
            {
                Console.WriteLine("--- 부서 목록입니다. ---");
            }
            else if (typeof(T).Name == "Employee")
            {
                Console.WriteLine("--- 직원 목록입니다. ---");
            }

            if (list.Any())
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                Console.WriteLine("목록이 비어 있습니다.");
            }
        }

        private bool validationKey<T>(Dictionary<string,T> dictionaries,string name) where T : Common
        {
            foreach (var key in dictionaries.Keys)
            {
                if (key == name)
                {
                    return true;
                }
            }
            return false;
        }

        private void printEmployees()
        {

        }
    }
}