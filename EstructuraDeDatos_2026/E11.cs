using System;

class Program
{
    // Búsqueda Lineal O(n)
    static int BusquedaLineal(int[] arr, int objetivo, out int iteraciones)
    {
        iteraciones = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            iteraciones++;
            if (arr[i] == objetivo)
            {
                return i;
            }
        }
        return -1;
    }

    // Búsqueda Binaria O(log n)
    static int BusquedaBinaria(int[] arr, int objetivo, out int iteraciones)
    {
        iteraciones = 0;
        int izquierda = 0;
        int derecha = arr.Length - 1;

        while (izquierda <= derecha)
        {
            iteraciones++;
            // Variación segura contra overflow
            int centro = izquierda + (derecha - izquierda) / 2;

            if (arr[centro] == objetivo)
            {
                return centro;
            }

            if (arr[centro] < objetivo)
            {
                izquierda = centro + 1;
            }
            else
            {
                derecha = centro - 1;
            }
        }

        return -1;
    }

    static void Main()
    {
        Console.WriteLine("=======================================");
        Console.WriteLine("MOTOR DE BÚSQUEDA DE MATRÍCULAS");
        Console.WriteLine("=======================================\n");

        // Generador de datos: 10,000 matrículas ordenadas consecutivamente
        int[] matriculas = new int[10000];
        for (int i = 0; i < matriculas.Length; i++)
        {
            matriculas[i] = i + 1;
        }

        try
        {
            Console.Write("Ingresa la matrícula a buscar: ");
            int objetivo = int.Parse(Console.ReadLine());

            int iterLineal, iterBinaria;
            int idxLineal = BusquedaLineal(matriculas, objetivo, out iterLineal);
            int idxBinaria = BusquedaBinaria(matriculas, objetivo, out iterBinaria);

            Console.WriteLine("\n=== REPORTE DE BÚSQUEDA ===");
            Console.WriteLine($"Tamaño del arreglo: {matriculas.Length}");
            Console.WriteLine($"Matrícula objetivo: {objetivo}");

            if (idxLineal != -1)
                Console.WriteLine($"[Lineal] Encontrado en índice: {idxLineal}");
            else
                Console.WriteLine("[Lineal] No encontrado.");
            Console.WriteLine($"[Lineal] Iteraciones realizadas: {iterLineal}");

            if (idxBinaria != -1)
                Console.WriteLine($"[Binaria] Encontrado en índice: {idxBinaria}");
            else
                Console.WriteLine("[Binaria] No encontrado.");
            Console.WriteLine($"[Binaria] Iteraciones realizadas: {iterBinaria}");

            Console.WriteLine("\nObservación:");
            Console.WriteLine("La búsqueda lineal evalúa elemento por elemento de forma secuencial.");
            Console.WriteLine("La búsqueda binaria reduce el espacio de búsqueda por mitades logarítmicas.");
        }
        catch (FormatException)
        {
            Console.WriteLine("\nError: Debes ingresar únicamente números enteros.");
        }

        Console.WriteLine("\nPresiona una tecla para salir...");
        Console.ReadKey();
    }
}