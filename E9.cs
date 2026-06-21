using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Ingresa un número (35-43): ");
        string input = Console.ReadLine();

        // FASE 3 - MODULO C: Validación de entrada robusta
        if (!int.TryParse(input, out int n) || n < 0)
        {
            Console.WriteLine("Error: ingresa un número entero positivo válido.");
            return;
        }

        // Para prevenir cuelgues accidentales excesivos en el método inseguro
        if (n > 45)
        {
            Console.WriteLine("Aviso: Valores mayores a 45 pueden demorar demasiado en Fuerza Bruta.");
        }

        Stopwatch sw = new Stopwatch();

        // ==========================================
        // MÓDULO A: Fibonacci Tradicional (Fuerza Bruta)
        // ==========================================
        Console.WriteLine("\n--- Ejecutando Método Inseguro (Fuerza Bruta) ---");
        sw.Restart();
        long r1 = FibonacciInseguro(n);
        sw.Stop();
        
        Console.WriteLine($"Inseguro: F({n}) = {r1}");
        Console.WriteLine($"Tiempo: {sw.ElapsedMilliseconds} ms");

        // ==========================================
        // MÓDULO B: Fibonacci Avanzado (Memoization)
        // ==========================================
        Console.WriteLine("\n--- Ejecutando Método Pro (Memoization) ---");
        
        // Inicialización del arreglo caché con tamaño n + 1
        long[] cache = new long[n + 1];
        
        // Asignación del valor centinela -1 (indica que no ha sido calculado)
        for (int i = 0; i <= n; i++)
        {
            cache[i] = -1;
        }

        sw.Restart();
        long r2 = FibonacciPro(n, cache);
        sw.Stop();

        Console.WriteLine($"Pro: F({n}) = {r2}");
        Console.WriteLine($"Tiempo: {sw.ElapsedMilliseconds} ms");
        
        Console.WriteLine("\n------------------------------------------------");
        Console.WriteLine("Métricas analizadas con éxito. El costo de procesamiento se redujo a O(n).");
    }
    // Módulo A: Algoritmo clásico recursivo sin optimizar. Complejidad O(2^n).
    public static long FibonacciInseguro(int n)
    {
        // Casos base
        if (n == 0) return 0;
        if (n == 1) return 1;

        // Doble bifurcación recursiva redundante
        return FibonacciInseguro(n - 1) + FibonacciInseguro(n - 2);
    }
    // Módulo B: Algoritmo optimizado mediante Caché (Memoization). Complejidad O(n).
    public static long FibonacciPro(int n, long[] cache)
    {
        // Casos base
        if (n == 0) return 0;
        if (n == 1) return 1;

        // Condición del centinela: ¿Ya se calculó previamente?
        if (cache[n] != -1)
        {
            return cache[n]; // Retorno inmediato en tiempo constante O(1)
        }

        // Calcular, almacenar en la caché y retornar
        cache[n] = FibonacciPro(n - 1, cache) + FibonacciPro(n - 2, cache);
        return cache[n];
    }
}