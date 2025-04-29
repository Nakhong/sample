using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1._20250428
{
    public class Test1
    {
        //문제 1 정수형 변수 a, 실수형 변수 b 두 변수를 선언하고 초기화한 뒤, 두 수의 합을 출력하시오.
        public void Question1() {
            int a = 1;
            double b = 3.3;

            Console.WriteLine($"{a}+{b} = {a+b}");
        }
        //문제 2 문자형 변수 c를 선언하고 초기화한 후, 해당 문자의 유니코드 번호에 5를 더한 값을 출력하시오.
        public void Question2()
        {
            string c = "h";

            int result = Convert.ToInt32(c[0]) + 5;

            Console.WriteLine($"문자열 :{c} 더한 값 : {result}");
        }

        //문제 3 문자열형 변수 str1, str2를 선언하고 각각 초기화한 뒤, 두 문자열을 하나로 이어 붙여 출력하시오.
        public void Question3()
        {
            string str1 = "홍";
            string str2 = "화낙";

            Console.WriteLine($"{str1}{str2}");
        }

        //문제 4 논리형 변수 isPass를 선언하고 true로 초기화한 뒤, 이를 반전시킨 값을 출력하시오.
        public void Question4()
        {
            Boolean isPass = true;

            Console.WriteLine($"{!isPass}");
        }

        //문제 5 정수형 변수 x를 선언하여 10을 저장하고, x에 3을 곱한 후, 2로 나눈 나머지를 출력하시오.
        public void Question5()
        {
            int x = 10;

            Console.WriteLine($"x : {x}, {(x * 3) % 2}");
        }

        //문제 6 세 개의 정수형 변수를 선언하고 각각 다른 값을 저장한 뒤, 세 수의 평균을 실수형으로 출력하시오.
        public void Question6()
        {
            int a = 10;
            int b = 5;
            int c = 1;

            Console.WriteLine($"a : {a}, b : {b}, c : {c} = {(double)(a + b + c) / 3}");
        }

        //문제 7 문자열형 변수 str1, str2에 각각 숫자로 구성된 문자열을 저장하고, 두 문자열을 정수로 변환한 뒤 곱한 결과를 출력하시오.
        public void Question7()
        {
            string str1 = "12";
            string str2 = "8";

            int parseStr1 = StringToIntUsingArray(str1);
            int parseStr2 = StringToIntUsingArray(str2);

            Console.WriteLine($"str1 : {str1}, str2 : {str2} = {parseStr1 * parseStr2}");
        }

        //문제 8 실수형 변수 x, y를 선언하고 초기화한 뒤, 두 수를 더하고, 곱하고, 나눈 결과를 한 줄에 모두 출력하시오.
        public void Question8()
        {
            double x = 12.5;
            double y = 8.12;

            double sum = x + y;
            double multiply = x * y;
            double division = x / y;

            // 결과를 한 줄에 출력
            Console.WriteLine($"두 수의 합: {sum}, 곱: {multiply}, 나눗셈 결과: {division}");
        }

        int StringToIntUsingArray(string str)
        {
            int result = 0;
            char[] charArray = str.ToCharArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                result = result * 10 + (charArray[i] - '0');
            }

            return result;
        }

    }
}
