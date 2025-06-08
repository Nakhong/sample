
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

        public enum EmployeeAction
        {
            GoBackToDepartment, 
            GoBackToCompany,   
            ExitProgram         
        }

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
            PrintOrganizationTree();
        }


        // 조직도 출력의 전체 흐름을 제어하는 메인 메서드
        public void PrintOrganizationTree()
        {
            while (true) // 전체 루프
            {
                Company company = SelectCompany();
                if (company == null) // -1 입력으로 프로그램 종료
                {
                    Console.WriteLine("프로그램을 종료합니다.");
                    break;
                }

                // 부서 선택 루프
                while (true)
                {
                    Department department = SelectDepartment(company);
                    if (department == null) // -1 입력으로 회사 선택으로 돌아가기
                    {
                        break; // 부서 선택 루프를 빠져나가 회사 선택 루프의 다음 반복으로 SelectCompany 호출
                    }

                    // 직원 조회 및 액션 처리
                    EmployeeAction action = DisplayEmployees(department);
                    if (action == EmployeeAction.GoBackToDepartment)
                    {
                        continue; // 부서 선택 루프의 다음 반복으로 SelectDepartment호출
                    }
                    else if (action == EmployeeAction.GoBackToCompany)
                    {
                        break; // 부서 선택 루프를 빠져나가 회사 선택 루프의 다음 반복으로 SelectCompany 호출
                    }
                }
            }
        }

        private void printList<T>(Dictionary<string, T> dictionaries) where T : Common
        {
            if (typeof(T).Name == "Company")
            {
                Console.WriteLine("--- 회사 목록입니다. (-1 입력 시 종료) ---");
            }
            else if (typeof(T).Name == "Department")
            {
                Console.WriteLine("--- 부서 목록입니다. (-1 입력 시 회사 선택으로 돌아가기) ---");
            }
            else if (typeof(T).Name == "Employee")
            {
                Console.WriteLine("--- 직원 목록입니다. (-1 입력 시 부서 선택으로 돌아가기) ---");
            }

            if (dictionaries.Count() > 0)
            {
                foreach (var key in dictionaries.Keys)
                {
                    Console.WriteLine(key);
                }
            }
            else
            {
                Console.WriteLine("목록이 비어 있습니다.");
            }
        }

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

            if (list.Count() > 0)
            {
                foreach (var item in list)
                {
                    Console.WriteLine(item.Name); // Common 클래스의 Name 사용
                }
            }
            else
            {
                Console.WriteLine("목록이 비어 있습니다.");
            }
        }

        // 회사 선택 로직을 담당하는 메서드
        private Company SelectCompany()
        {
            string companyName;
            Company selectedCompany = null;

            while (selectedCompany == null)
            {
                printList(companies);
                Console.Write("회사 이름을 입력하세요 (-1 입력 시 프로그램 종료): ");
                companyName = Console.ReadLine();

                if (companyName == "-1")
                {
                    return null; // 프로그램 종료
                }

                if (ValidateKey(companies, companyName))
                {
                    selectedCompany = companies[companyName];
                }
                else
                {
                    Console.WriteLine("잘못된 회사 이름입니다. 다시 입력해주세요.");
                }
            }
            return selectedCompany;
        }

        // 부서 선택 로직을 담당하는 메서드
        private Department SelectDepartment(Company company)
        {
            string departmentName;
            Department selectedDepartment = null;

            while (selectedDepartment == null)
            {
                printList(company.Departments);
                Console.Write($"'{company.Name}'의 부서 이름을 입력하세요 (-1 입력 시 회사 선택으로 돌아가기): ");
                departmentName = Console.ReadLine();

                if (departmentName == "-1")
                {
                    return null; // 회사 선택으로 돌아가기
                }
                
                selectedDepartment = company.Departments.FirstOrDefault(d => d.Name == departmentName);

                if (selectedDepartment == null)
                {
                    Console.WriteLine("잘못된 부서 이름입니다. 다시 입력해주세요.");
                }

            }
            return selectedDepartment;
        }

        // 직원을 포지션별로 출력하거나 전체를 출력하는 로직을 담당하는 메서드
        private EmployeeAction DisplayEmployees(Department department)
        {
            string input;
            while (true)
            {
                Console.WriteLine($"--- {department.Name} 부서 직원 목록입니다. ---");
                Console.Write("전체 / 직급 / -1 입력 시 부서 선택으로 돌아가기 / -2 입력 시 회사 선택으로 돌아가기 :");
                input = Console.ReadLine();

                if (input == "-1")
                {
                    return EmployeeAction.GoBackToDepartment;
                }else if (input == "-2")
                {
                    return EmployeeAction.GoBackToCompany;
                }
                else if (input == "전체")
                {
                    if (department.Employees.Count() > 0)
                    {
                        foreach (var emp in department.Employees)
                        {
                            Console.WriteLine($"이름: {emp.Name}, 직급: {emp.EmployeePosition}, 연락처: {emp.Contact}, 이메일: {emp.Email}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("직원 목록이 비어 있습니다.");
                    }
                }
                else // 특정 직급으로 조회
                {
                    var filteredEmployees = department.Employees
                                                    .Where(e => e.EmployeePosition.ToLower() == input.ToLower())
                                                    .ToList();

                    if (filteredEmployees.Count() > 0)
                    {
                        Console.WriteLine($"--- '{input}' 직원 목록입니다. ---");
                        foreach (var emp in filteredEmployees)
                        {
                            Console.WriteLine($"이름: {emp.Name}, 직급: {emp.EmployeePosition}, 연락처: {emp.Contact}, 이메일: {emp.Email}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"'{input}' 직급의 직원이 없습니다.");
                    }
                }
                Console.WriteLine();
            }
        }


        private bool ValidateKey<T>(Dictionary<string, T> dictionary, string key) where T : Common
        {
            return dictionary.ContainsKey(key);
        }
    }
}