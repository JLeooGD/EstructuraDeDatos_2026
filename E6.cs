using System;

public class Jugador
{
    public string Nombre { get; set; }
    public int Puntuacion { get; set; }

    public Jugador(string nombre, int puntuacion)
    {
        Nombre = nombre;
        Puntuacion = puntuacion;
    }
}

class Program
{
    static void Main(string[] args)
    {
            Console.WriteLine("--- Módulo 1: Uso de 'ref' (Entrada Dinámica) ---");
            int valorA = LeerEntero("Introduce el valor para A: ");
            int valorB = LeerEntero("Introduce el valor para B: ");

            Console.WriteLine($"\nValores antes del intercambio -> A: {valorA}, B: {valorB}");
            Intercambiar(ref valorA, ref valorB);
            Console.WriteLine($"Valores después del intercambio -> A: {valorA}, B: {valorB}\n");
            Console.WriteLine("--------------------------------------------------\n");
            Console.WriteLine("--- Módulo 2: Uso de 'out' (Entrada Dinámica) ---");
            int dividendo = LeerEntero("Introduce el dividendo (número a dividir): ");
            int divisor = LeerEntero("Introduce el divisor (entre cuánto dividir): ");
            Console.WriteLine();
            if (CalcularYValidar(dividendo, divisor, out int cociente, out int residuo))
            {
                Console.WriteLine($"✓ División procesada correctamente:");
                Console.WriteLine($"  Cociente: {cociente}");
                Console.WriteLine($"  Residuo: {residuo}\n");
            }
            else
            {
                Console.WriteLine($"✗ Error: El divisor no puede ser {divisor}. Operación inválida.\n");
            }
            Console.WriteLine("--------------------------------------------------\n");
            Console.WriteLine("--- Módulo 3: Referencias de Objetos en el Heap ---");
            Console.Write("Introduce el nombre del jugador: ");
            string nombreIngresado = Console.ReadLine() ?? "Jugador Anónimo";
            int ptsIngresados = LeerEntero("Introduce su puntuación inicial: ");

            Jugador jugador1 = new Jugador(nombreIngresado, ptsIngresados);
            Jugador jugador2 = jugador1;

            Console.WriteLine($"\nAntes de la mutación -> J1: {jugador1.Nombre} ({jugador1.Puntuacion} pts), J2: {jugador2.Nombre} ({jugador2.Puntuacion} pts)");
            
            int nuevaPuntuacion = LeerEntero($"\nIntroduce la nueva puntuación para actualizar a través de J2: ");
            jugador2.Puntuacion = nuevaPuntuacion;
            
            Console.WriteLine($"\nDespués de la mutación -> J1: {jugador1.Nombre} ({jugador1.Puntuacion} pts), J2: {jugador2.Nombre} ({jugador2.Puntuacion} pts)");
            Console.WriteLine("-> Confirmado: J1 cambió de valor de manera automática debido a que J2 apunta exactamente al mismo bloque en el Heap.\n");

            Console.WriteLine("Presiona cualquier tecla para cerrar la consola...");
            Console.ReadKey();
        }
        public static int LeerEntero(string mensaje)
        {
            int numero;
            bool esValido;
            do
            {
                Console.Write(mensaje);
                string? entrada = Console.ReadLine();
                esValido = int.TryParse(entrada, out numero);

                if (!esValido)
                {
                    Console.WriteLine("Entrada inválida. Por favor, introduce un número entero válido.");
                }
            } while (!esValido);

            return numero;
        }

        public static void Intercambiar(ref int a, ref int b)
        {
            int temporal = a;
            a = b;
            b = temporal;
        }

        public static bool CalcularYValidar(int dividendo, int divisor, out int cociente, out int residuo)
        {
            if (divisor == 0)
            {
                cociente = 0;
                residuo = 0;
                return false;
            }

            cociente = dividendo / divisor;
            residuo = dividendo % divisor;
            return true;
        }
    }