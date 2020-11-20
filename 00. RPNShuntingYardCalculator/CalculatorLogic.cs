using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShuntingYard
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            Console.WriteLine("Type Exit to end.");

            while ((command = Console.ReadLine()) != "Exit")
            {

                Console.WriteLine(
                    RPNCalculator(
                    ShuntingYard(command)
                    )
                   );
            }
        }

        static float RPNCalculator(string input)
        {

            string[] digits = input.Split(' ').Reverse().ToArray();

            Stack<string> digitsStack = new Stack<string>(digits);

            while (digitsStack.Count > 2)
            {
                List<string> elements = new List<string>();

                string currentElement = digitsStack.Pop();

                while (!IsOperator(currentElement))
                {
                    elements.Add(currentElement);
                    currentElement = digitsStack.Pop();
                }

                float first = float.Parse(elements[elements.Count - 2]);
                float second = float.Parse(elements[elements.Count - 1]);

                float result = PerformOperation(currentElement, first, second);

                digitsStack.Push(result.ToString());

                for (int i = elements.Count - 3; i >= 0; i--)
                {
                    digitsStack.Push(elements[i]);
                }
            }

            return float.Parse(digitsStack.Pop());
        }

        static string ShuntingYard(string input)
        {
            string[] expression = input.Split(" ");

            Stack<string> operationStack = new Stack<string>();

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < expression.Length; i++)
            {
                if (IsOperator(expression[i]))
                {
                    if (operationStack.Count > 0)
                    {
                        var oldPrecedence = OperatorPrecedence(operationStack.Peek());

                        var currentPrecedence = OperatorPrecedence(expression[i]);

                        if (oldPrecedence >= currentPrecedence)
                        {
                            output.Append(operationStack.Pop() + " ");
                        }
                    }

                    operationStack.Push(expression[i]);

                }
                else if (expression[i] == "(")
                {
                    operationStack.Push(expression[i]);
                }
                else if (expression[i] == ")")
                {
                    while (operationStack.Peek() != "(")
                    {
                        output.Append(operationStack.Pop() + " ");
                    }

                    operationStack.Pop();
                }
                else
                {
                    output.Append(expression[i] + " ");
                }
            }

            while (operationStack.Count > 0)
            {
                output.Append(operationStack.Pop() + " ");
            }

            return output.ToString();
        }

        static bool IsOperator(string element)
        {
            switch (element)
            {
                case "+":
                    return true;
                case "-":
                    return true;
                case "*":
                    return true;
                case "/":
                    return true;
            }

            return false;
        }

        static int OperatorPrecedence(string input)
        {
            switch (input)
            {
                case "+":
                    return 2;
                case "-":
                    return 2;
                case "*":
                    return 3;
                case "/":
                    return 3;
                case "(":
                    return 1;
            }

            throw new ArgumentException();
        }

        public static float PerformOperation(string currentElement, float first, float second)
        {
            switch (currentElement)
            {
                case "+":
                    return first + second;
                case "-":
                    return first - second;
                case "*":
                    return first * second;
                case "/":
                    return first / second;
            }

            throw new ArgumentException();
        }
    }
}

