using System;

namespace DataCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║         FASE 3: LISTA SIMPLEMENTE ENLAZADA           ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");

            TablaDinamica dataCore = new TablaDinamica();

            // === PASO 1: Insertar 15 registros ===
            Console.WriteLine("\n Insertando 15 registros...");
            Random rng = new Random(42);

            for (int i = 1; i <= 15; i++)
            {
                RegistroDatos reg = new RegistroDatos(
                    id: i,
                    hash: rng.NextInt64(),
                    pesoBytes: rng.Next(10, 5001)
                );
                dataCore.InsertarFinal(reg);
                Console.WriteLine($"  [INSERT] Registro {i} añadido a la cadena.");
            }

            // === PASO 2: Eliminar 2 registros ===
            Console.WriteLine("\n Eliminando registros con Id 5 y Id 11...");
            dataCore.EliminarPorId(5);
            dataCore.EliminarPorId(11);
            Console.WriteLine("  Cadena reestructurada exitosamente. Sin NullReferenceException.");

            // === PASO 3: Convertir a arreglo y ordenar ===
            RegistroDatos[] arreglo = dataCore.ObtenerComoArreglo();
            Console.WriteLine($"\n Registros en arreglo: {arreglo.Length} (esperado: 13)");

            // Ordenar con QuickSort (Fase 2)
            QuickSort.Ordenar(arreglo);

            Console.WriteLine("\n Arreglo ordenado por Id (QuickSort):");
            foreach (var r in arreglo)
            {
                Console.WriteLine($"  {r}");
            }

            // === PASO 4: Métricas ===
            Console.WriteLine($"\n✅ Lista completada exitosamente.");
            Console.WriteLine($"   Total de registros en lista: {dataCore.ContadorRegistros}");
            Console.WriteLine($"   Total de registros en arreglo: {arreglo.Length}");

        }
    }
}