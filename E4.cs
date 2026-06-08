using System;
namespace EstructuraDeDatos2026
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Algoritmos Recursivos ===");
            Console.WriteLine("Entregable Bimestral 4 - UNITEC\n");
            Console.Write("Ingresa un número para calcular su factorial: ");
            if (int.TryParse(Console.ReadLine(), out int numFactorial))
            {
                try
                {
                    long resultadoFactorial = CalcularFactorial(numFactorial);
                    Console.WriteLine($"Resultado: {numFactorial}! = {resultadoFactorial}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error en Factorial: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Error: Por favor, ingresa un número entero válido.");
            }
            Console.Write("\nIngresa la posición de Fibonacci (n): ");
            if (int.TryParse(Console.ReadLine(), out int numFib))
            {
                try
                {
                    long resultadoFibonacci = GenerarFibonacci(numFib);
                    Console.WriteLine($"Resultado: Fibonacci({numFib}) = {resultadoFibonacci}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error en Fibonacci: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Error: Por favor, ingresa un número entero válido.");
            }

            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
        static long CalcularFactorial(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("No existe factorial de números negativos.");
            }
            if (n == 0 || n == 1)
            {
                return 1;
            }
            // Caso Recursivo: n! = n * (n - 1)!
            return n * CalcularFactorial(n - 1);
        }
        static long GenerarFibonacci(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("La posición n debe ser un entero positivo.");
            }
            if (n == 0)
            {
                return 0;
            }
            // Caso Base 2: Si n es 1, devuelve 1
            if (n == 1)
            {
                return 1;
            }

            // Caso Recursivo Doble: Fib(n) = Fib(n-1) + Fib(n-2)
            return GenerarFibonacci(n - 1) + GenerarFibonacci(n - 2);
        }
    }
}
