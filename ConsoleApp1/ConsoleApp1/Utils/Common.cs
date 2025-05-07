using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Utils
{
    public class Common
    {
        public bool a(int N, string Message) {
            // 양의 정수 N > 1 확인
            while (true)
            {
                Console.Write(Message);
                string input = Console.ReadLine();

                if (int.TryParse(input, out N) && N > 1)
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 양의 정수만 입력 해주세요. N > 1");
                }
            }
        }
    }
}
