using System;

namespace EstructuraDeDatos2026
{
    class Program
    {
        static void Main(string[] args)
        {
            int miE = 5;
            Console.WriteLine("\n--- Prueba con 'int' (Value Type) ---");
            Console.WriteLine($"Valor inicial antes de la función: {miE}");
            CambV(miE);
            Console.WriteLine($"Valor final después de la función: {miE} (¡No cambió!)");
            int[] miA = { 10, 20, 30 };
            Console.WriteLine("\n--- Prueba con 'int[]' (Reference Type) ---");
            Console.WriteLine($"Primer elemento antes de la función: {miA[0]}");
            CamR(miA);
            Console.WriteLine($"Primer elemento después de la función: {miA[0]} (¡Sí cambió!)");
        }
        static void CambV(int x)
        {
            x = 100;
        }

        static void CamR(int[] arr)
        {
            arr[0] = 100; 
        }
    }
}