using System;
using DataCore;

// Generador de datos pseudoaleatorios
var rng = new Random();

// Crear array de 40 registros
var arreglo = new RegistroDatos[40];

try
{
    for (int i = 0; i < arreglo.Length; i++)
    {
        arreglo[i] = new RegistroDatos(
            id: rng.Next(1, 1001),
            hash: rng.NextInt64(),
            pesoBytes: rng.Next(10, 5001)
        );
    }
}
catch (ArgumentException ex)
{
    Console.WriteLine($" Error al crear registro: {ex.Message}");
    return 1;
}

// ============================================================
//  ESTADO INICIAL
// ============================================================
Console.WriteLine("╔════════════════════════════════════════════════════════╗");
Console.WriteLine("║              ESTADO INICIAL DEL ARRAY                 ║");
Console.WriteLine("╚════════════════════════════════════════════════════════╝");
foreach (var r in arreglo)
{
    Console.WriteLine(r);
}

Console.WriteLine("\n Ejecutando Selection Sort instrumentado...\n");

// ============================================================
//  EJECUCIÓN DEL ALGORITMO
// ============================================================
var metricas = Ordenador.OrdenarPorSeleccion(arreglo);

// ============================================================
//  ESTADO FINAL
// ============================================================
Console.WriteLine("╔════════════════════════════════════════════════════════╗");
Console.WriteLine("║              ESTADO FINAL ORDENADO                   ║");
Console.WriteLine("╚════════════════════════════════════════════════════════╝");
foreach (var r in arreglo)
{
    Console.WriteLine(r);
}

// ============================================================
//  MÉTRICAS DE RENDIMIENTO
// ============================================================
Console.WriteLine(metricas);

return 0;