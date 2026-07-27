using System;
using System.Collections.Generic;
using System.Linq;

namespace SimulacroClase11
{
    // ============================
    // Struct PuntoDeRed
    // ============================
    public struct PuntoDeRed
    {
        public double Latitud { get; }
        public double Longitud { get; }

        public PuntoDeRed(double latitud, double longitud)
        {
            if (latitud < -90 || latitud > 90)
                throw new ArgumentOutOfRangeException(nameof(latitud),
                    "La latitud debe estar entre -90 y 90.");

            if (longitud < -180 || longitud > 180)
                throw new ArgumentOutOfRangeException(nameof(longitud),
                    "La longitud debe estar entre -180 y 180.");

            Latitud = latitud;
            Longitud = longitud;
        }

        public override string ToString()
        {
            return $"({Latitud}°, {Longitud}°)";
        }
    }

    // ============================
    // Clase ServidorConexion
    // ============================
    public class ServidorConexion
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public PuntoDeRed Ubicacion { get; set; }
        public List<int> CodigosRespuesta { get; set; }

        private readonly long[] cache = new long[100];

        public ServidorConexion(int id, string nombre,
            PuntoDeRed ubicacion,
            List<int> codigos)
        {
            ID = id;
            Nombre = nombre;
            Ubicacion = ubicacion;
            CodigosRespuesta = codigos ?? new List<int>();
        }

        public long DiagnosticarLatencia(int n, out string alerta)
        {
            if (n < 0 || n >= 100)
                throw new ArgumentOutOfRangeException(nameof(n),
                    "n debe estar entre 0 y 99.");

            if (n <= 1)
            {
                alerta = "";
                return n;
            }

            if (cache[n] != 0)
            {
                alerta = "";
                return cache[n];
            }

            cache[n] = DiagnosticarLatencia(n - 1, out _) +
                       DiagnosticarLatencia(n - 2, out _);

            if (cache[n] > 10000)
                alerta = $"ALERTA: Índice de estrés crítico en {Nombre}";
            else
                alerta = "";

            return cache[n];
        }

        public override string ToString()
        {
            return $"[{ID}] {Nombre} @ {Ubicacion}";
        }
    }

    // ============================
    // Programa Principal
    // ============================
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<ServidorConexion> servidores = new List<ServidorConexion>()
                {
                    new ServidorConexion(
                        1,
                        "Servidor-CDMX",
                        new PuntoDeRed(19.43, -99.13),
                        new List<int>{200,200,500}),

                    new ServidorConexion(
                        2,
                        "Servidor-NYC",
                        new PuntoDeRed(40.71,-74.01),
                        new List<int>{200,404}),

                    new ServidorConexion(
                        3,
                        "Servidor-Sydney",
                        new PuntoDeRed(-33.87,151.21),
                        new List<int>{500,500}),

                    new ServidorConexion(
                        4,
                        "Servidor-Londres",
                        new PuntoDeRed(51.51,-0.13),
                        new List<int>{200,200,200})
                };

                Console.WriteLine("===== SERVIDORES CRÍTICOS =====");

                var criticos = servidores.Where(s =>
                    s.Ubicacion.Latitud > 0 &&
                    s.CodigosRespuesta.Contains(500));

                foreach (var servidor in criticos)
                {
                    Console.WriteLine(servidor);
                }

                Console.WriteLine();

                Console.WriteLine("===== DIAGNÓSTICO =====");

                long resultado =
                    servidores[0].DiagnosticarLatencia(15, out string alerta);

                Console.WriteLine($"Resultado Fibonacci: {resultado}");

                if (!string.IsNullOrEmpty(alerta))
                    Console.WriteLine(alerta);

                Console.WriteLine();

                Console.Write("Ingrese una latitud: ");

                string entrada = Console.ReadLine();

                if (!double.TryParse(entrada, out double latitud))
                    throw new FormatException("La entrada no es un número válido.");

                PuntoDeRed punto = new PuntoDeRed(latitud, 0);

                Console.WriteLine("Punto creado correctamente:");
                Console.WriteLine(punto);
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"[ERROR DE FORMATO] {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"[ERROR DE RANGO] {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"[DESBORDAMIENTO] {ex.Message}");
            }

            Console.WriteLine();
            Console.WriteLine("Presiona cualquier tecla para finalizar...");
            Console.ReadKey();
        }
    }
}