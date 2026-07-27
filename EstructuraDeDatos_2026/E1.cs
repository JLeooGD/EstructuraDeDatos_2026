using System;
using EstructuraDeDatos2026;
namespace EstructuraDeDatos2026
{
    struct Poligono
    {
        public string Nom;
        public int NmLd;
        public double MedLd;
        public double Apt;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CALCULADORA DE POLÍGONOS REGULARES");
            Poligono miPoligono = SeleccionPoligono();
            if (miPoligono.NmLd == 0)
            {
                Console.WriteLine("Finalizado");
                return;
            }
            PedirDts(ref miPoligono);
            double areaF = CalcularArea(miPoligono);
            Console.WriteLine("RESULTADO");
            Console.WriteLine($"El área del {miPoligono.Nom} es: {areaF:F2} unidades cuadradas");
        }

        static Poligono SeleccionPoligono()
        {
            Poligono p = new Poligono();
            Console.WriteLine("\nSeleccione el polígono regular que desea calcular:");
            Console.WriteLine("1. Pentágono (5 lados)");
            Console.WriteLine("2. Hexágono (6 lados)");
            Console.WriteLine("3. Heptagono (7 lados)");
            Console.WriteLine("4. Octágono (8 lados)");
            Console.WriteLine("5. Personalizado ( Escribir el número de lados)");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");
        
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    p.Nom = "Pentágono";
                    p.NmLd = 5;
                    break;
                case "2":
                    p.Nom = "Hexágono";
                    p.NmLd = 6;
                    break;
                case "3":
                    p.Nom = "Heptágono";
                    p.NmLd = 7;
                    break;
                case "4":
                    p.Nom = "Pentágono";
                    p.NmLd = 8;
                    break;
                case "5": // <-- Lógica para la 5ta opción
                    Console.Write("Ingresa el número de lados de tu polígono: ");
                    int lados;
                    while (!int.TryParse(Console.ReadLine(), out lados) || lados < 3)
                    {
                        Console.Write("Error: Un polígono debe tener al menos 3 lados. Intenta de nuevo: ");
                    }
                    p.NmLd = lados;
                    p.Nom = $"Polígono de {lados} lados";
                    break;
                default:
                    p.NmLd = 0;
                    break;
            }

            return p;
        }

        static void PedirDts(ref Poligono p)
        {
            Console.WriteLine($"\nIngresa los datos para el {p.Nom}:");
            p.MedLd = LeerDPos("Medida de lado: ");
            p.Apt = LeerDPos("Medida de apotema: ");
        }

        static double CalcularArea(Poligono p)
        {
            double peri = p.NmLd * p.MedLd;
            double area = (peri * p.Apt) /2;
            return area;
        }

        static double LeerDPos(string mensaje)
        {
            double num;
            bool esV;

            do
            {
                Console.Write(mensaje);
                string entrada = Console.ReadLine();
                esV = double.TryParse(entrada, out num) && num > 0;
                if (!esV)
                {
                    Console.WriteLine("Error: Por favor, ingresa un número decimal positivo válido");
                }
            } while(!esV);
            return num;
        }
    }
}