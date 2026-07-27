using System;

readonly struct CoordenadaGPS
{
    public double Latitud { get; }
    public double Longitud { get; }

    public CoordenadaGPS(double lat, double lon)
    {
        // Validación de latitud
        if (lat < -90 || lat > 90)
        {
            throw new ArgumentOutOfRangeException(
                nameof(lat),
                "Latitud fuera del rango [-90, 90].");
        }

        // Validación de longitud
        if (lon < -180 || lon > 180)
        {
            throw new ArgumentOutOfRangeException(
                nameof(lon),
                "Longitud fuera del rango [-180, 180].");
        }

        Latitud = lat;
        Longitud = lon;
    }

    public void ImprimirUbicacion()
    {
        Console.WriteLine($"Latitud: {Latitud}");
        Console.WriteLine($"Longitud: {Longitud}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=======================================");
        Console.WriteLine("COORDENADAS GPS CON STRUCT");
        Console.WriteLine("=======================================\n");

        try
        {
            Console.Write("Latitud: ");
            double lat = double.Parse(Console.ReadLine());

            Console.Write("Longitud: ");
            double lon = double.Parse(Console.ReadLine());

            CoordenadaGPS c1 = new CoordenadaGPS(lat, lon);

            // Copia por valor
            CoordenadaGPS c2 = c1;

            // Reasignar c2 con otra ubicación (Berlín)
            c2 = new CoordenadaGPS(52.5200, 13.4050);

            Console.WriteLine("\n--- c1 ---");
            c1.ImprimirUbicacion();

            Console.WriteLine("\n--- c2 ---");
            c2.ImprimirUbicacion();
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine("\nERROR:");
            Console.WriteLine(ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("\nError: Debes ingresar únicamente números.");
        }

        Console.WriteLine("\nPresiona una tecla para salir...");
        Console.ReadKey();
    }
}