using System;
using System.Collections.Generic;
using System.Linq;

namespace EstructuraDeDatos2026
{
    public class Producto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public Producto(int id, string nombre, double precio, int cantidad)
        { // Validando el Entregable Bimestral 3 de Estructura de Datos
            ID = id;
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }
        public override string ToString()
        {
            return $"[{ID}] {Nombre} - ${Precio:F2} | Stock: {Cantidad}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEMA DE GESTIÓN DE INVENTARIO ===");


            List<Producto> inventario = new List<Producto>
            {
                new Producto(1, "Laptop Lenovo", 15999.00, 10),
                new Producto(2, "Mouse Inalámbrico", 349.00, 25),
                new Producto(3, "Teclado Mecánico", 899.00, 0),
                new Producto(4, "Monitor 24\"", 4500.00, 5),
                new Producto(5, "Audífonos Sony", 1200.00, 0)
            };

            inventario.Add(new Producto(6, "Webcam HD", 750.00, 12));

            var otroProducto = new Producto(7, "Hub USB-C", 450.00, 8);
            inventario.Add(otroProducto);

            var porPrecio = inventario.OrderByDescending(p => p.Precio).ToList();
            Console.WriteLine("\n>> Productos ordenados por Precio (DESC):");
            foreach (var p in porPrecio)
            {
                Console.WriteLine(p);
            }

            var agotados = inventario.Where(p => p.Cantidad == 0).ToList();
            Console.WriteLine("\n>> Alerta de Productos Agotados:");
            if (agotados.Count == 0)
            {
                Console.WriteLine("No hay productos agotados.");
            }
            else
            {
                agotados.ForEach(p => Console.WriteLine(p));
            }


           
            Dictionary<int, Producto> catalogo = inventario.ToDictionary(p => p.ID, p => p);

            BuscarPorID(catalogo);

            Console.WriteLine("\n======================================================");
        }

        static void BuscarPorID(Dictionary<int, Producto> catalogo)
        {
            Console.WriteLine("\n=== BÚSQUEDA INSTANTÁNEA EN DICTIONARY ===");
            Console.Write("Ingresa el ID del producto a buscar: ");
            
            if (int.TryParse(Console.ReadLine(), out int idBuscado))
            {
                if (catalogo.TryGetValue(idBuscado, out Producto encontrado))
                {
                    Console.WriteLine($"\n¡Éxito! Producto Encontrado: {encontrado}");
                }
                else
                {
                    Console.WriteLine($"\nError: El ID [{idBuscado}] no existe en el catálogo.");
                }
            }
            else
            {
                Console.WriteLine("Error: Por favor ingresa un ID numérico válido.");
            }
        }
    }
}