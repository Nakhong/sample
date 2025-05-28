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
        
            string path = $"{AppDomain.CurrentDomain.BaseDirectory}\\Study\\Day6\\Data.txt";

            List<string> lines = new List<string>();

            string[] line = File.ReadAllLines(path);

            foreach (string Data in line)
            {
                lines.Add(Data);
            }

            createTree.BuildOrganizationTree(lines);

            Console.ReadKey();
        }
    }
}
