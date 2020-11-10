using System;
using System.Collections.Generic;
using System.Linq;

namespace RPNShuntingYardCalculator
{
    class Program
    {
        //Way of input example - 5 2 3 42 2 / * + *
        static void Main(string[] args)
        {
            string[] digits = Console.ReadLine().Split(' ').Reverse().ToArray();

            Stack<string> digitsStack = new Stack<string>(digits);

            while (digitsStack.Count > 1)
            {
                List<string> elements = new List<string>();

                string currentElement = digitsStack.Pop();

                while (!IsOperator(currentElement))
                {
                    elements.Add(currentElement);
                    currentElement = digitsStack.Pop();
                }

                int first = int.Parse(elements[elements.Count - 2]);
                int second = int.Parse(elements[elements.Count - 1]);

                int result = PerformOperation(currentElement, first, second);

                digitsStack.Push(result.ToString());

                for (int i = elements.Count - 3; i >= 0 ; i--)
                {
                    digitsStack.Push(elements[i]);
                }

            }
        }

        public static int PerformOperation(string currentElement, int first, int second)
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

            throw new ArgumentException("Not a valid calculation!");
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
    }
}
