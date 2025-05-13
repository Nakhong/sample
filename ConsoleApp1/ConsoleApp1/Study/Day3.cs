using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Day3
    {
        //문제 4 무작위 스트링 받아서 계산 값 출력하기 사칙연산, 소,중,대괄호 사용
        //계산할때 식을 계속 들어가면서 -랑 + / *를 찾아서 맨 마지막에 먼저 할 순위의 연산자를 넣어놓고 뒤에서부터 빼면서 계산한다.
        public void Question1()
        {
            string Expression;

            while (true)
            {
                Console.Write("식을 입력 해주세요 : ");
                string input = Console.ReadLine();

                Expression = SetBrackets(input); // 대괄호 소괄호 중괄호를 소괄호로 변경하기.

                if (IsValidExpression(Expression))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }

            //식 계산 시작
            double result = ResultExpression(Expression);

            Console.WriteLine("결과 값 : " + result);
        }

        //왼쪽으로 진행하면서 여는 괄호 찾기
        //괄호 안의 수식 계산을 해서 계산한 수식이 포함되어 있는 괄호는 제거 하고 수식을 값으로 치환
        // 괄호가 다 제거 되면 마지막 수식 계산
        //ex) (1+5*6)+2
        public double ResultExpression(string expression)
        {
            while (expression.Contains("("))
            {
                int lastOpen = expression.LastIndexOf('('); //10
                int close = expression.IndexOf(')', lastOpen); //10번째 부터 가까운 )를 찾아서 닫아줌
                string innerExpression = expression.Substring(lastOpen + 1, close - lastOpen - 1);
                double innerResult = ExpressionResult(innerExpression);
                expression = expression.Substring(0, lastOpen) + innerResult.ToString() + expression.Substring(close + 1); //문자열 붙여서 넣어줌.
            }

            return ExpressionResult(expression);
        }

        // 사칙연산 단순 계산기 (왼쪽부터 순차 계산)
        private double ExpressionResult(string expr)
        {
            return 1.23;
        }

        //올바른 식인지 확인하기.
        //모든 괄호는 짝을 이뤄야함.
        //연산자가 연속 되면 안된다.
        //식이 시작 할 때나 괄호 열리고 바로 연산자가 나오면 안됨
        //숫자 다음에는 괄호 또는 연산자가 나와야 한다.
        //닫는 괄호는 여는 괄호가 있을 때만 나와야 한다.
        //마지막 문자가 연산자면 안된다.
        //숫자가 아니면 안된다.
        public bool IsValidExpression(string expression)
        {
            List<char> parentheses = new List<char> ();
            bool isPrevOperator = true;  
            bool isPrevNumberOrBrackets = false;  

            for (int i = 0; i < expression.Length;i++)
            {
                //괄호 처리
                if (expression[i] == '(')
                {

                    parentheses.Add(expression[i]);
                    isPrevOperator = true;
                    isPrevNumberOrBrackets = false;
                }
                else if(expression[i] == ')')
                {
                    if (parentheses.Count == 0 || parentheses[parentheses.Count - 1] != '(')
                    {
                        return false;
                    }
                    parentheses.RemoveAt(parentheses.Count - 1);
                    isPrevNumberOrBrackets = true; 
                }
                // 숫자 처리
                else if (int.TryParse(expression[i].ToString(), out int result))
                {
                    isPrevNumberOrBrackets = true;
                    isPrevOperator = false;
                }
                // 연산자 처리
                else if (expression[i] == '+' || expression[i] == '-' || expression[i] == '*' || expression[i] == '/')
                {
                    if (isPrevOperator) return false;

                    isPrevOperator = true;
                    isPrevNumberOrBrackets = false;
                }
                //문자 처리
                else
                {
                    return false;
                }

            }
            // 괄호가 짝 확인
            if (parentheses.Count != 0) return false;

            // 마지막 문자가 연산자인지.
            return !isPrevOperator;
        }

        // 괄호 변경
        public static string SetBrackets(string input)
        {
            StringBuilder result = new StringBuilder();

            // 입력된 문자열의 각 문자 확인
            foreach (char brackets in input)
            {
                if (brackets == '{' || brackets == '[')
                {
                    result.Append('(');  // '{' 또는 '['이면 '('로 변경
                }
                else if (brackets == '}' || brackets == ']')
                {
                    result.Append(')');  // '}' 또는 ']'이면 ')'로 변경
                }
                else
                {
                    result.Append(brackets);  // 그 외의 문자는 그대로 추가
                }
            }

            return result.ToString();
        }

    }
}
