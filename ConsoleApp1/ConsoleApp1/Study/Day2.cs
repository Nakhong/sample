using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Day2
    {
            public Day2()
            {
                Question1();
                Question2();
                Question3();
                Question4();
            }

            //문제 1 사용자로부터 양의 정수 N을 입력받아, 2부터 N까지의 모든 소수를 배열에 저장한 뒤 출력하세요. 어떤 소수도 N의 제곱근보다 큰 수로 나눠지지 않는다는 규칙이 있다.
            public void Question1()
            {   
            //입력 -> while로 양의 정수 확인 -> for문으로 소수 확인 -> 결과
            List<int> arrNum = new List<int>();
            int N;

            // 양의 정수 N > 1 확인
            while(true){
                Console.Write("양의 정수 입력 : ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out N) && N > 1) 
                {
                    break;
                }
                else {
                    Console.WriteLine("잘못된 입력입니다. 양의 정수만 입력 해주세요. N > 1");
                }
            }

            for (int num = 2; num <= N; num++) //2부터 N까지 반복
            {
                bool isPrime = true; // flag 선언

                for (int i = 2; i <= Math.Sqrt(num); i++)
                {
                    if (num % i == 0)  //제곱근까지 나누어 떨어지는지 체크
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime) // 나누어 떨어지지 않으면 배열에 추가.
                {
                    arrNum.Add(num);
                }
            }

            string result = string.Join(",", arrNum); //Join()으로 배열 -> String
            Console.WriteLine($"결과 값:{result}");
        }

        //문제 2 정수를 무작위로 입력하면 크기 순서대로 출력하는 알고리즘을 구현하세요. 버블정렬 사용.
        public void Question2()
        {
            Console.Write(",로 구분 된 무작위 정수 입력 : ");
            string input = Console.ReadLine();

            int[] numberArr = input.Split(',').Select(int.Parse).ToArray();      

            int temp;

            for (int i = 0; i < numberArr.Length - 1; i++)
            {
                for (int j = 0; j < numberArr.Length - 1; j++)
                {
                    if (numberArr[j] > numberArr[j + 1])
                    {
                        temp = numberArr[j + 1];
                        numberArr[j + 1] = numberArr[j];
                        numberArr[j] = temp;
                    }
                }
            }
            Console.WriteLine($"정렬된 배열:{string.Join(", ", numberArr)}");
        }

        //문제 3 *찍기 문제 (무한 반복) 1. 몇줄?(-1은 종료) 입력: 3; 2. 1.상(우) 2.상(좌) 3.하(우) 4. 하(좌) 5. 전체
        public void Question3()
        {
            Console.Write("줄을 입력하세요: ");
            int N;

            string inputLine = Console.ReadLine();
            string inputCommand;

            if (int.TryParse(inputLine, out N) && N > 0)
            {
                Console.Write("1.상(우), 2.상(좌), 3.하(우), 4.하(좌) : ");
                inputCommand = Console.ReadLine();

                if(inputCommand == "1") //상(우)
                {
                    for (int i = 1; i <= N; i++)
                    {
                        for (int j = 1; j <= N - i; j++)
                        {
                            Console.Write(" ");
                        }
                        for (int k = 1; k <= i; k++)
                        {
                            Console.Write("*");
                        }
                        Console.Write("\n");
                    }
                }
                else if (inputCommand == "2") //상(좌)
                {
                    for (int i = 1; i <= N; i++)
                    {
                        for (int j = 1; j <= i; j++)
                        {
                            Console.Write("*");
                        }
                        Console.Write("\n");
                    }
                }
                else if (inputCommand == "3") //하(우)
                {
                    for (int i = N; i >= 1; i--)
                    {
                        for (int j = 1; j <= N - i; j++)
                        {
                            Console.Write(" ");
                        }
                        for (int k = 1; k <= i; k++)
                        {
                            Console.Write("*");
                        }
                        Console.Write("\n");
                    }
                }
                else if (inputCommand == "4") //하(좌)
                {
                    for (int i = N; i >= 1; i--)
                    {
                        for (int j = 1; j <= i; j++)
                        {
                            Console.Write("*");
                        }
                        Console.Write("\n");
                    }
                }
                else if (inputCommand == "5") //전체 --마름모
                {
                    if (N % 2 == 0)
                    {
                        Console.WriteLine($"입력한 {N}은 짝수입니다. 입력한 {N}에 +1을 더 합니다.");
                        N += 1;
                    }
                    int middle = N / 2;

                    for (int i = 0; i <= middle; i++)
                    {
                        for (int j = 1; j <= middle - i; j++)
                        {
                            Console.Write(" ");
                        }

                        for (int j = 1; j <= 2 * i + 1; j++)
                        {
                            Console.Write("*");
                        }

                        Console.Write("\n");
                    }

                    for (int i = middle - 1; i >= 0; i--)
                    {
                        for (int j = 1; j <= middle - i; j++)
                        {
                            Console.Write(" ");
                        }

                        for (int j = 1; j <= 2 * i + 1; j++)
                        {
                            Console.Write("*");
                        }

                        Console.Write("\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("유효한 정수를 입력하세요.");
            }

        }
        //문제 4 무작위 스트링 받아서 계산 값 출력하기 사칙연산, 소,중,대괄호 사용
        public void Question4()
        {



        }

        //문제 5 Getter, Setter 사용법 찾기
        public class Person
        {
            private string name;
            public string Name
            {
                get { return name; }
                set
                {
                    if (value =="홍화낙" && value !=null)
                    {
                        name = value;
                    }
                    else {
                        name = "";
                    }
                }
            }
        }

        /* 접근제어자
         * private : 같은 클래스 내에서만 접근
         * protected: 같은 클래스 또는 상속받은 자식 클래스만 접근
         * public : 모두 접근 가능.
         */

        //문제 6 Program.cs 조사
        /* Program.cs에서 namespace란 클래스 간 이름 충돌을 방지하고, 모듈화해준다.
         * class Program의 이름은 변경이 가능하지만, 일반적으로 진입점으로 사용하기 때문에 변경하지 않습니다.
         * Main 메서드는 반드시 static이여야 하고, C# 애플리케이션의 진입점입니다. 애플리케이션이 시작될 때 Main 메서드는 호출되는 첫 번째 메서드입니다. 이름은 변경할 수 없습니다.
         * Main 메서드의 return은 int,Task 형식으로 반환형식을 가질 수 있습니다.
         * static은 실행 시 메모리에 저장되어 인스턴스 선언하지 않아도, 사용할 수 있는 상태가 됩니다.
         */
    }
}

