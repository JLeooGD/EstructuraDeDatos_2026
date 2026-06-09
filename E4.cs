using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Algoritmos Recursivos ===\n");

        Console.Write("Ingresa un número para calcular su factorial: ");
        if (int.TryParse(Console.ReadLine(), out int numFactorial))
        {
            try
            {
                long resultadoFactorial = CalcularFactorial(numFactorial);
                Console.WriteLine($"{numFactorial}! = {resultadoFactorial}");
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
                Console.WriteLine($"Fibonacci({numFib}) = {resultadoFibonacci}");
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

        Console.WriteLine("\n=============================================");
        Console.WriteLine("Presiona cualquier tecla para salir...");
        Console.ReadKey();
    }

    static long CalcularFactorial(int n)
    {
        if (n < 0)
        {
            throw new ArgumentException("No existe el factorial de números negativos.");
        }

        if (n == 0 || n == 1)
        {
            return 1;
        }

        return n * CalcularFactorial(n - 1);
    }
    static long GenerarFibonacci(int n)
    {
        if (n < 0)
        {
            throw new ArgumentException("La posición (n) debe ser un entero positivo.");
        }
        if (n == 0) return 0;
        if (n == 1) return 1;
        return GenerarFibonacci(n - 1) + GenerarFibonacci(n - 2);
    }
}