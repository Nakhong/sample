using ConsoleApp1.Study.Day5;
using ConsoleApp1.Study.Day6.Service;
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
            CreateTree createTree = new CreateTree();

            createTree.test("");
            Console.ReadKey();
        }
    }
}
