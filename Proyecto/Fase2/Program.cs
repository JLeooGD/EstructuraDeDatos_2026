using System;

namespace DataCore
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("╔════════════════════════════════════════════════════════╗");
                Console.WriteLine("║              FASE 2: QUICKSORT                        ║");
                Console.WriteLine("╚════════════════════════════════════════════════════════╝");

                Benchmark.Ejecutar(tamaño: 10_000);

                Console.WriteLine("\n✅ Benchmark completado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error: {ex.Message}");
                Console.WriteLine($"Detalle: {ex.StackTrace}");
            }
        }
    }
}