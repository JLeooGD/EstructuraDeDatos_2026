using System;

namespace InsertionSortApp
{
    // FASE 3 (Parte A): Estructura de Datos Transaccion
    struct Transaccion
    {
        public int Id;          // Identificador único de la transacción
        public double Monto;    // Importe en moneda local
        public long Timestamp;  // Marca de tiempo en milisegundos (epoch Unix)

        // Constructor para facilitar la inicialización de cada registro
        public Transaccion(int id, double monto, long timestamp)
        {
            Id = id;
            Monto = monto;
            Timestamp = timestamp;
        }

        // Override de ToString para visualización legible y alineada en consola
        public override string ToString()
        {
            return $"ID: {Id,4} | Monto: {Monto,10:F2} | Timestamp: {Timestamp}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // FASE 3 (Parte C): Módulo Main y Pruebas de Estrés
                // Bitácora con capacidad para 50 transacciones
                Transaccion[] bitacora = new Transaccion[50];
                Random rng = new Random();

                // Bloque 1: Primeros 45 elementos con IDs en orden ascendente (0 a 44)
                for (int i = 0; i < 45; i++)
                {
                    bitacora[i] = new Transaccion(
                        id: i + 1,
                        monto: Math.Round(rng.NextDouble() * 9999.99 + 0.01, 2),
                        timestamp: DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + (i * 100)
                    );
                }

                // Bloque 2: Últimos 5 elementos con IDs desordenados (registros tardíos)
                int[] idsAleatorios = new int[] { 78, 3, 99, 12, 55 };
                for (int i = 0; i < 5; i++)
                {
                    bitacora[45 + i] = new Transaccion(
                        id: idsAleatorios[i],
                        monto: Math.Round(rng.NextDouble() * 9999.99 + 0.01, 2),
                        timestamp: DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() + ((45 + i) * 100)
                    );
                }

                Console.WriteLine("=== OPTIMIZADOR DE BITÁCORAS DE TRANSACCIONES ===");
                Console.WriteLine("=== Estado Inicial (Muestra desordenada al final) ===");
                ImprimirBitacora(bitacora);

                // Ejecución del ordenamiento instrumentado
                int totalDesplazamientos = OrdenarPorInsercion(bitacora);

                Console.WriteLine("\n=== Transacciones Ordenadas por ID ===");
                ImprimirBitacora(bitacora);

                // Cálculo de métricas de rendimiento
                int peorCasoTeorico = (50 * 49) / 2; // n(n-1)/2 = 1225
                double porcentajeEficiencia = (1.0 - ((double)totalDesplazamientos / peorCasoTeorico)) * 100;

                Console.WriteLine($"\nTotal de desplazamientos realizados: {totalDesplazamientos}");
                Console.WriteLine($"Eficiencia: {porcentajeEficiencia:F1}% mejor que el peor caso (Máx. teórico: {peorCasoTeorico})");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"\n[ERROR] Desbordamiento de datos: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"\n[ERROR] Formato de entrada inválido: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[ERROR Inesperado]: {ex.Message}");
            }
        }

        // FASE 3 (Parte B): Módulo de Insertion Sort instrumentado
        static int OrdenarPorInsercion(Transaccion[] arr)
        {
            int contadorDesplazamientos = 0;
            int n = arr.Length;

            // El subarreglo arr[0] ya se considera ordenado por definición
            for (int i = 1; i < n; i++)
            {
                Transaccion clave = arr[i]; // Elemento que se desea insertar
                int j = i - 1;              // Índice para recorrer la zona ordenada

                // Mientras existan elementos con ID mayor que la clave, se desplazan a la derecha
                while (j >= 0 && arr[j].Id > clave.Id)
                {
                    arr[j + 1] = arr[j];    // Abre espacio desplazando el valor
                    contadorDesplazamientos++;
                    j--;                    // Avanza hacia la izquierda
                }

                // Coloca la clave en la posición correcta (j + 1)
                arr[j + 1] = clave;
            }

            return contadorDesplazamientos;
        }

        // Método auxiliar para la impresión ordenada en consola
        static void ImprimirBitacora(Transaccion[] arr)
        {
            foreach (var t in arr)
            {
                Console.WriteLine(t.ToString());
            }
        }
    }
}
