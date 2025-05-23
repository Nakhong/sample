using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Study.Day5
{
    class Day5
    {
    }
    public abstract class Entity
    {
        public string Name { get; set; }
        public abstract void PrintInfo();
    }

    public class Company : Entity
    {
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string BusinessNumber { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();

        public override void PrintInfo()
        {
            Console.WriteLine($"[회사 정보]");
            Console.WriteLine($"회사명: {Name}");
            Console.WriteLine($"주소: {Address}");
            Console.WriteLine($"전화번호: {PhoneNumber}");
            Console.WriteLine($"사업자 번호: {BusinessNumber}");
        }
    }

    public class Department : Entity
    {
        public string DepartmentCode { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();
        public Company Company { get; set; }

        public override void PrintInfo()
        {
            Console.WriteLine($"[부서 정보]");
            Console.WriteLine($"부서명: {Name}");
            Console.WriteLine($"부서 코드: {DepartmentCode}");
            Console.WriteLine($"소속 회사: {Company?.Name}");
            Console.WriteLine("직원 리스트:");
            foreach (var emp in Employees)
            {
                Console.WriteLine($"  - {emp.Name} (사번: {emp.EmployeeId})");
            }
        }
    }

    public class Employee : Entity
    {
        public string EmployeeId { get; set; }
        public string Contact { get; set; }
        public Department Department { get; set; }

        public override void PrintInfo()
        {
            Console.WriteLine($"[직원 정보]");
            Console.WriteLine($"이름: {Name}");
            Console.WriteLine($"사번: {EmployeeId}");
            Console.WriteLine($"연락처: {Contact}");
            Console.WriteLine($"소속 부서: {Department?.Name}");
            Console.WriteLine($"소속 회사: {Department?.Company?.Name}");
        }


        var company = new Company
        {
            Name = "퍼플렉시티",
            Address = "서울특별시 강남구",
            PhoneNumber = "02-1234-5678",
            BusinessNumber = "123-45-67890"
        };

        var devDept = new Department { Name = "개발팀", DepartmentCode = "DEV", Company = company };
        company.Departments.Add(devDept);

var emp1 = new Employee { Name = "홍길동", EmployeeId = "2025001", Contact = "010-1111-2222", Department = devDept };
        devDept.Employees.Add(emp1);

// 다형성 활용
List<Entity> entities = new List<Entity> { company, devDept, emp1 };
foreach (var entity in entities)
{
    entity.PrintInfo();
    Console.WriteLine();
}
}

}
