using ConsoleApp1.Study.Day5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1


{
    class Program
    {
        static void Main(string[] args)
        {
            //Day1 day1 = new Day1();
            //Day2 day2 = new Day2();
            //Day3 day3 = new Day3();
            //day3.Question1();
            //day2.Question3();
            //Console.ReadKey();

            test("이삭엔지니어링;경기도 군포시;0313610800;DS사업본부;홍화낙;20230602;01075519505;전임");
            Console.ReadKey();
        }

        public static void test(string row) {
            string[] parts = row.Split(';');
            Company company = new Company(parts[0], parts[1], parts[2]);

            Department department = new Department (parts[3],company);
            company.Departments.Add(department);

            Employee employee = new Employee (parts[4],parts[5],parts[6],department,parts[7]);
            department.Employees.Add(employee);

            company.PrintInfo();
            department.PrintInfo();
            employee.PrintInfo();

        }
    }
}
