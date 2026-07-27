using System;
using System.Numerics;

class Program
{
    //========================================================
    // FACTORIAL RECURSIVO CON INT
    //========================================================
    static int FactorialInt(int n)
    {
        if (n == 0 || n == 1)
            return 1;

        return n * FactorialInt(n - 1);
    }

    //========================================================
    // FACTORIAL ITERATIVO CON INT
    //========================================================
    static int FactorialIterativo(int n)
    {
        int resultado = 1;

        for (int i = 2; i <= n; i++)
        {
            resultado *= i;
        }

        return resultado;
    }

    //========================================================
    // FACTORIAL CON BIGINTEGER
    //========================================================
    static BigInteger FactorialProfesional(BigInteger n)
    {
        if (n == 0 || n == 1)
            return BigInteger.One;

        return n * FactorialProfesional(n - 1);
    }

    static void Main()
    {
        Console.WriteLine("==============================================");
        Console.WriteLine("FACTORIAL RECURSIVO VS ITERATIVO");
        Console.WriteLine("==============================================\n");

        Console.WriteLine($"{"n",-5} {"Recursivo",-20} {"Iterativo",-20}");

        for (int i = 1; i <= 20; i++)
        {
            Console.WriteLine($"{i,-5} {FactorialInt(i),-20} {FactorialIterativo(i),-20}");
        }

        /*
         * PUNTO DE QUIEBRE (OVERFLOW)
         *
         * El tipo int almacena hasta:
         * 2,147,483,647
         *
         * 12! = 479,001,600  -> Correcto
         * 13! = 6,227,020,800 -> Ya no cabe en int.
         *
         * A partir de n = 13 ocurre Arithmetic Overflow.
         * El programa comienza a mostrar valores negativos
         * o incorrectos debido al wraparound.
         */

        Console.WriteLine("\n==============================================");
        Console.WriteLine("FACTORIAL CON BIGINTEGER");
        Console.WriteLine("==============================================\n");

        BigInteger resultado = FactorialProfesional(100);

        Console.WriteLine("100! =");
        Console.WriteLine(resultado);

        Console.WriteLine("\nPresione una tecla para salir...");
        Console.ReadKey();
    }
}