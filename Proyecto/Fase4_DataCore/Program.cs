using System;

namespace DataCore
{
    class Program
    {
        private static TablaDinamica _tabla = new TablaDinamica();
        private static Random _rng = new Random();
        private static RegistroDatos[]? _arregloIndexado = null;

        static void Main(string[] args)
        {
            Console.WriteLine("╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("║       DATACORE v4.0 - SISTEMA DE GESTIÓN DE DATOS     ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════╝");

            CargarDatosEjemplo();

            int opcion;
            do
            {
                MostrarMenu();
                string? input = Console.ReadLine();

                if (!int.TryParse(input, out opcion))
                {
                    Console.WriteLine("❌ ERROR: Ingresa un número válido (1-6).");
                    Pausa();
                    continue;
                }

                try
                {
                    switch (opcion)
                    {
                        case 1: InsertarRegistro(); break;
                        case 2: EliminarRegistro(); break;
                        case 3: MostrarRegistros(); break;
                        case 4: IndexarYOrdenar(); break;
                        case 5: EjecutarBusquedaBinaria(); break;
                        case 6: Console.WriteLine("\n👋 Saliendo del sistema..."); break;
                        default: Console.WriteLine("❌ Opción inválida. Elige 1-6."); Pausa(); break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("❌ ERROR: Formato de entrada inválido.");
                    Pausa();
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine($"❌ ERROR: Referencia nula. Detalle: {ex.Message}");
                    Pausa();
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"❌ ERROR: Índice fuera de rango. Detalle: {ex.Message}");
                    Pausa();
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"❌ ERROR: Operación inválida. Detalle: {ex.Message}");
                    Pausa();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ ERROR INESPERADO: {ex.Message}");
                    Pausa();
                }

            } while (opcion != 6);

            Console.WriteLine("\n✅ Proyecto DataCore v4.0 finalizado correctamente.");
        }

        // ============== MÉTODOS AUXILIARES ==============

        static void Pausa()
        {
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
        }

        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("════════════════════════════════════════════════════════════");
            Console.WriteLine("                   MENÚ PRINCIPAL DATACORE");
            Console.WriteLine($"            Registros actuales: {_tabla.ContadorRegistros}");
            Console.WriteLine("════════════════════════════════════════════════════════════");
            Console.WriteLine("  1. Insertar registro");
            Console.WriteLine("  2. Eliminar registro por ID");
            Console.WriteLine("  3. Mostrar todos los registros");
            Console.WriteLine("  4. Indexar y ordenar (preparar para búsqueda binaria)");
            Console.WriteLine("  5. Búsqueda binaria por ID");
            Console.WriteLine("  6. Salir");
            Console.WriteLine("════════════════════════════════════════════════════════════");
            Console.Write("  Elige una opción: ");
        }

        static void CargarDatosEjemplo()
        {
            Console.WriteLine("\n Cargando 10 registros de ejemplo...");
            for (int i = 1; i <= 10; i++)
            {
                var reg = new RegistroDatos(
                    id: i,
                    hash: _rng.NextInt64(),
                    pesoBytes: _rng.Next(10, 5001)
                );
                _tabla.InsertarFinal(reg);
            }
            Console.WriteLine($"✅ {_tabla.ContadorRegistros} registros cargados.");
            Pausa();
        }

        static void InsertarRegistro()
        {
            Console.Write("  ID del registro: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("❌ ID inválido. Debe ser un número entero.");
                Pausa();
                return;
            }

            // Validar que el ID no exista ya (opcional)
            // Podrías recorrer la lista para verificar, pero lo dejamos simple

            var nuevo = new RegistroDatos(
                id: id,
                hash: _rng.NextInt64(),
                pesoBytes: _rng.Next(10, 5001)
            );

            _tabla.InsertarFinal(nuevo);
            Console.WriteLine($"✅ Registro con ID {id} insertado correctamente.");
            Pausa();
        }

        static void EliminarRegistro()
        {
            Console.Write("  ID del registro a eliminar: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("❌ ID inválido. Debe ser un número entero.");
                Pausa();
                return;
            }

            int contadorAntes = _tabla.ContadorRegistros;
            _tabla.EliminarPorId(id);
            int contadorDespues = _tabla.ContadorRegistros;

            if (contadorDespues < contadorAntes)
                Console.WriteLine($"✅ Registro con ID {id} eliminado correctamente.");
            else
                Console.WriteLine($"⚠️ No se encontró ningún registro con ID {id}.");

            Pausa();
        }

        static void MostrarRegistros()
        {
            if (_tabla.ContadorRegistros == 0)
            {
                Console.WriteLine(" La tabla está vacía. No hay registros para mostrar.");
                Pausa();
                return;
            }

            Console.WriteLine($"\n📋 Lista de registros ({_tabla.ContadorRegistros} totales):");
            _tabla.ImprimirLista();
            Pausa();
        }

        static void IndexarYOrdenar()
        {
            if (_tabla.ContadorRegistros == 0)
            {
                Console.WriteLine("❌ No hay registros para indexar. La tabla está vacía.");
                _arregloIndexado = null;
                Pausa();
                return;
            }

            Console.WriteLine("🔄 Extrayendo registros de la lista enlazada...");
            _arregloIndexado = _tabla.ObtenerComoArreglo();
            Console.WriteLine($"✅ {_arregloIndexado.Length} registros extraídos.");

            Console.WriteLine("🔄 Ordenando arreglo con QuickSort...");
            QuickSort.Ordenar(_arregloIndexado);
            Console.WriteLine("✅ Arreglo ordenado correctamente. Listo para búsquedas binarias.");

            // --- MOSTRAR MUESTRA INTELIGENTE ---
            Console.WriteLine("\n📋 Arreglo ordenado por ID:");
            int total = _arregloIndexado.Length;

            if (total <= 20)
            {
                // Si son 20 o menos, mostrar todos
                foreach (var r in _arregloIndexado)
                {
                    Console.WriteLine($"  {r}");
                }
            }
            else
            {
                // Si son más de 20, mostrar solo los primeros 5
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"  {_arregloIndexado[i]}");
                }
                Console.WriteLine($"  ... y {total - 5} registros más.");
            }

            Pausa();
        }

        static void EjecutarBusquedaBinaria()
        {
            if (_arregloIndexado == null || _arregloIndexado.Length == 0)
            {
                Console.WriteLine("❌ No hay índice disponible. Ejecuta primero la opción 4 (Indexar y ordenar).");
                Pausa();
                return;
            }

            Console.Write("  ID a buscar: ");
            if (!int.TryParse(Console.ReadLine(), out int idBuscado))
            {
                Console.WriteLine("❌ ID inválido. Debe ser un número entero.");
                Pausa();
                return;
            }

            var (registro, comparaciones) = BusquedaBinaria.Buscar(_arregloIndexado, idBuscado);

            if (registro != null)
            {
                Console.WriteLine($"✅ Registro encontrado: {registro}");
                Console.WriteLine($"   🔢 Comparaciones realizadas: {comparaciones} (O(log n))");
            }
            else
            {
                Console.WriteLine($"❌ No se encontró ningún registro con ID {idBuscado}.");
                Console.WriteLine($"   🔢 Comparaciones realizadas: {comparaciones} (O(log n))");
            }

            Pausa();
        }
    }
}