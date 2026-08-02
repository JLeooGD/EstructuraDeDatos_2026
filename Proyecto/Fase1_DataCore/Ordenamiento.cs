using System;
using System.Diagnostics;
using System.Linq;

namespace DataCore;

/// <summary>
/// Métricas de ejecución del algoritmo de ordenamiento.
/// </summary>
public readonly struct MetricasOrdenamiento
{
    public int Comparaciones { get; }
    public int Intercambios { get; }
    public double TiempoMs { get; }
    public int Tamaño { get; }
    public string EstadoInicial { get; }

    public MetricasOrdenamiento(int comparaciones, int intercambios, double tiempoMs, int tamaño, string estadoInicial)
    {
        Comparaciones = comparaciones;
        Intercambios = intercambios;
        TiempoMs = tiempoMs;
        Tamaño = tamaño;
        EstadoInicial = estadoInicial;
    }

    public override string ToString()
    {
        return $"""
                ═══════════════════════════════════════════════
                          MÉTRICAS DE ORDENAMIENTO
                ═══════════════════════════════════════════════
                  Tamaño del array:        {Tamaño}
                  Comparaciones:           {Comparaciones}
                  Intercambios:            {Intercambios}
                  Tiempo de ejecución:     {TiempoMs:F3} ms
                  Estado inicial:          {EstadoInicial}
                ═══════════════════════════════════════════════
                """;
    }
}

/// <summary>
/// Algoritmo Selection Sort instrumentado con métricas reales.
/// </summary>
public static class Ordenador
{
    public static MetricasOrdenamiento OrdenarPorSeleccion(RegistroDatos[] arr)
    {
        // Capturar estado inicial (primeros y últimos 5 elementos)
        string estadoInicial = ObtenerEstadoInicial(arr);

        int comparaciones = 0;
        int intercambios = 0;

        // Iniciar medición de alta resolución
        long startTimestamp = Stopwatch.GetTimestamp();

        for (int i = 0; i < arr.Length - 1; i++)
        {
            int indiceMinimo = i;

            // Búsqueda del mínimo en subarreglo restante
            for (int j = i + 1; j < arr.Length; j++)
            {
                comparaciones++;
                if (arr[j].Id < arr[indiceMinimo].Id)
                {
                    indiceMinimo = j;
                }
            }

            // Intercambio condicional usando tuplas (C# 7.0+)
            if (indiceMinimo != i)
            {
                (arr[i], arr[indiceMinimo]) = (arr[indiceMinimo], arr[i]);
                intercambios++;
            }
        }

        // Calcular tiempo transcurrido
        double elapsedMs = (Stopwatch.GetTimestamp() - startTimestamp) * 1000.0 / Stopwatch.Frequency;

        return new MetricasOrdenamiento(
            comparaciones,
            intercambios,
            elapsedMs,
            arr.Length,
            estadoInicial
        );
    }

    private static string ObtenerEstadoInicial(RegistroDatos[] arr)
    {
        if (arr.Length == 0) return "[]";

        int mostrar = Math.Min(5, arr.Length);
        var primeros = string.Join(", ", arr.Take(mostrar).Select(r => r.Id));
        var ultimos = arr.Length > 5
            ? string.Join(", ", arr.Skip(arr.Length - mostrar).Select(r => r.Id))
            : "";

        return arr.Length > 5
            ? $"[{primeros}, ..., {ultimos}]"
            : $"[{primeros}]";
    }
}