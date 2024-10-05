using System;

namespace GenericCalculator
{
    // Generic class for Calculator
    public class Calculator<T> where T : struct
    {
        // Generic method for addition
        public T Add(T a, T b)
        {
            return (dynamic)a + (dynamic)b;
        }

        // Generic method for subtraction
        public T Subtract(T a, T b)
        {
            return (dynamic)a - (dynamic)b;
        }

        // Generic method for multiplication
        public T Multiply(T a, T b)
        {
            return (dynamic)a * (dynamic)b;
        }

        // Generic method for division
        public T Divide(T a, T b)
        {
            if ((dynamic)b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero");
            }
            return (dynamic)a / (dynamic)b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Calculator<double> calculator = new Calculator<double>();
            double a = GetInput<double>("Enter first double: ");
            double b = GetInput<double>("Enter second double: ");
            PerformCalculations(calculator, a, b);
        }

        // Generic method to get user input and convert it to the required type
        static T GetInput<T>(string prompt) where T : struct
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();
            return (T)Convert.ChangeType(input, typeof(T));
        }

        // Method to perform calculations
        static void PerformCalculations<T>(Calculator<T> calculator, T a, T b) where T : struct
        {
            Console.WriteLine($"Addition: {calculator.Add(a, b)}");
            Console.WriteLine($"Subtraction: {calculator.Subtract(a, b)}");
            Console.WriteLine($"Multiplication: {calculator.Multiply(a, b)}");

            try
            {
                Console.WriteLine($"Division: {calculator.Divide(a, b)}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
