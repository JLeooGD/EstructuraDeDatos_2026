using System;
using System.Diagnostics;
using System.Linq;

namespace DataCore
{
    /// <summary>
    /// Métricas de ejecución (reutilizado de Fase 1).
    /// </summary>
    public readonly struct MetricasOrdenacion
    {
        public int TotalComparaciones { get; }
        public int TotalIntercambios { get; }
        public double TiempoEjecucionMs { get; }
        public string EstadoInicial { get; }

        public MetricasOrdenacion(int comparaciones, int intercambios, double tiempoMs, string estadoInicial)
        {
            TotalComparaciones = comparaciones;
            TotalIntercambios = intercambios;
            TiempoEjecucionMs = tiempoMs;
            EstadoInicial = estadoInicial;
        }

        public override string ToString()
        {
            return @"
╔══════════════════════════════════════════════════════════════════╗
║                    REPORTE DE MÉTRICAS                          ║
╠══════════════════════════════════════════════════════════════════╣
║  Estado inicial del arreglo: " + EstadoInicial.PadRight(35) + @" ║
║  Comparaciones realizadas:  " + TotalComparaciones.ToString().PadRight(35) + @" ║
║  Intercambios reales:       " + TotalIntercambios.ToString().PadRight(35) + @" ║
║  Tiempo de ejecución:       " + TiempoEjecucionMs.ToString("F4").PadRight(35) + @" ms
╚══════════════════════════════════════════════════════════════════╝";
        }
    }

    /// <summary>
    /// Algoritmo Selection Sort (reutilizado de Fase 1).
    /// </summary>
    public static class SelectionSort
    {
        public static MetricasOrdenacion Ordenar(RegistroDatos[] arr)
        {
            string estadoInicial = ObtenerEstadoInicial(arr);
            int comparaciones = 0;
            int intercambios = 0;

            Stopwatch sw = Stopwatch.StartNew();

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int indiceMinimo = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    comparaciones++;
                    if (arr[j].Id < arr[indiceMinimo].Id)
                        indiceMinimo = j;
                }

                if (indiceMinimo != i)
                {
                    (arr[i], arr[indiceMinimo]) = (arr[indiceMinimo], arr[i]);
                    intercambios++;
                }
            }

            sw.Stop();

            return new MetricasOrdenacion(comparaciones, intercambios, sw.Elapsed.TotalMilliseconds, estadoInicial);
        }

        private static string ObtenerEstadoInicial(RegistroDatos[] arr)
        {
            if (arr.Length == 0) return "[]";
            int mostrar = Math.Min(5, arr.Length);
            var primeros = string.Join(", ", arr.Take(mostrar).Select(r => r.Id));
            var ultimos = arr.Length > 5
                ? string.Join(", ", arr.Skip(arr.Length - mostrar).Select(r => r.Id))
                : "";
            return arr.Length > 5 ? $"[{primeros}, ..., {ultimos}]" : $"[{primeros}]";
        }
    }
}