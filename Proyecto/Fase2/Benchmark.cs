using System;
using System.Diagnostics;

namespace DataCore
{
    /// <summary>
    /// Orquestador de benchmarking comparativo entre SelectionSort y QuickSort.
    /// </summary>
    public static class Benchmark
    {
        public static void Ejecutar(int tamaño = 10_000)
        {
            Console.WriteLine($@"
╔═══════════════════════════════════════════════════════════════╗
║           BENCHMARK COMPARATIVO: SELECTION vs QUICKSORT      ║
║              Tamaño del arreglo: {tamaño:N0} registros                   ║
╚═══════════════════════════════════════════════════════════════╝
");

            // 1. Generar datos con semilla fija para reproducibilidad
            var arregloOriginal = GenerarArregloAleatorio(tamaño);

            // 2. Clonar para condiciones idénticas
            var copiaSeleccion = (RegistroDatos[])arregloOriginal.Clone();
            var copiaQuickSort = (RegistroDatos[])arregloOriginal.Clone();

            // 3. Benchmark: Selection Sort (Fase 1)
            Console.WriteLine("▶ Ejecutando Selection Sort...");
            var swSeleccion = Stopwatch.StartNew();
            var metricasSeleccion = SelectionSort.Ordenar(copiaSeleccion);
            swSeleccion.Stop();

            // 4. Benchmark: QuickSort (Fase 2)
            Console.WriteLine("▶ Ejecutando QuickSort...");
            var swQuickSort = Stopwatch.StartNew();
            QuickSort.Ordenar(copiaQuickSort);
            swQuickSort.Stop();

            // 5. Calcular ratio
            double ratio = swQuickSort.Elapsed.TotalMilliseconds > 0
                ? swSeleccion.Elapsed.TotalMilliseconds / swQuickSort.Elapsed.TotalMilliseconds
                : double.PositiveInfinity;

            // 6. Reporte comparativo
            Console.WriteLine($@"
╔═══════════════════════════════════════════════════════════════╗
║                    REPORTE COMPARATIVO                        ║
╠═══════════════════════════════════════════════════════════════╣
║                                                               ║
║    SELECTION SORT (Fase 1)                                  ║
║     • Comparaciones:   {metricasSeleccion.TotalComparaciones,12:N0}                         ║
║     • Intercambios:    {metricasSeleccion.TotalIntercambios,12:N0}                         ║
║     • Tiempo:          {swSeleccion.Elapsed.TotalMilliseconds,12:F2} ms                      ║
║                                                               ║
║  ⚡ QUICKSORT (Fase 2)                                       ║
║     • Llamadas recursivas: {QuickSort.ContadorLlamadas,12:N0}                         ║
║     • Tiempo:           {swQuickSort.Elapsed.TotalMilliseconds,12:F2} ms                      ║
║                                                               ║
╠═══════════════════════════════════════════════════════════════╣
║    RATIO DE VELOCIDAD:                                      ║
║     QuickSort fue {ratio:F0}x más rápido
╚═══════════════════════════════════════════════════════════════╝
");
        }

        private static RegistroDatos[] GenerarArregloAleatorio(int cantidad)
        {
            Random rnd = new Random(42); // Semilla fija para reproducibilidad
            var arreglo = new RegistroDatos[cantidad];

            for (int i = 0; i < cantidad; i++)
            {
                arreglo[i] = new RegistroDatos(
                    id: rnd.Next(1, 100_001),
                    hash: rnd.NextInt64(),
                    pesoBytes: rnd.Next(10, 5001)
                );
            }

            return arreglo;
        }
    }
}