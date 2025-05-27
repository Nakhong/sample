using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Study.Day6.Model
{
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
            Console.WriteLine("＝＝＝회사 정보＝＝＝");
            Console.WriteLine($"회사명: {Name}");
            Console.WriteLine($"주소: {Address}");
            Console.WriteLine($"전화번호: {CompanyPhoneNumber}");
            Console.WriteLine();
        }
    }
}
