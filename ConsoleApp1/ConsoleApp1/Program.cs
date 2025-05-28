using ConsoleApp1.Study.Day5;
using ConsoleApp1.Study.Day6.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1


{
    class Program
    {
        static void Main(string[] args)
        {
            CreateTree createTree = new CreateTree();

            string path = $"{AppDomain.CurrentDomain.BaseDirectory}Day6\\Data.txt";

            // 각 줄을 배열로 읽음
            string[] lines = File.ReadAllLines(path);

            Console.ReadKey();
        }
    }
}
