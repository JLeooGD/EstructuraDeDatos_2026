using System;

Console.WriteLine("=== Anatomía de la Recursividad ===\n");

bool salir = false;
while (!salir)
{
    Console.Clear();
    Console.WriteLine("--- Menú Práctico Entregable 7 ---");
    Console.WriteLine("1. Ejercicio A: Conteo Regresivo Visualizador (Call Stack)");
    Console.WriteLine("2. Ejercicio B: Sumatoria Acumulativa");
    Console.WriteLine("3. Salir del Programa");
    Console.WriteLine("----------------------------------");
    
    int opcion = LeerEntero("Selecciona una opción: ");
    Console.WriteLine();

    switch (opcion)
    {
        case 1:
            Console.WriteLine("--- Ejecutando Conteo Regresivo ---");
            int nConteo = LeerEnteroPositivo("Introduce el número inicial para el conteo: ");
            Console.WriteLine("\n[Inicio de las llamadas recursivas en el Call Stack]");
            ConteoRegresivo(nConteo);
            Console.WriteLine("[Fin de la ejecución del Call Stack]");
            Console.WriteLine("\n🚀 ¡Despegue!\n");
            PausarYLimpiar();
            break;

        case 2:
            Console.WriteLine("--- Ejecutando Sumatoria Acumulativa ---");
            int nSumatoria = LeerEnteroPositivo("Introduce el número límite (n): ");
            int resultado = Sumatoria(nSumatoria);
            Console.WriteLine($"\n✓ La sumatoria acumulativa desde 1 hasta {nSumatoria} es: {resultado}\n");
            PausarYLimpiar();
            break;

        case 3:
            salir = true;
            Console.WriteLine("Saliendo del programa...");
            break;

        default:
            Console.WriteLine("Opción no válida. Intenta de nuevo.\n");
            PausarYLimpiar();
            break;
    }
}

// =========================================================================
// ALGORITMOS RECURSIVOS (EJERCICIO A Y EJERCICIO B)
// =========================================================================

static void ConteoRegresivo(int n)
{
    // CASO BASE: Condición de parada obligatoria
    if (n < 0)
    {
        Console.WriteLine("Caso base alcanzado (n < 0). Frenando recursión.");
        return;
    }

    // ACCIÓN ANTES DE LA RECURSIÓN (Fase de Apilamiento / Push)
    Console.WriteLine($"[APILANDO] en Call Stack -> Entrada al método con n = {n}");

    // CASO RECURSIVO: Llamada al mismo método con un subproblema menor (n - 1)
    ConteoRegresivo(n - 1);

    // ACCIÓN DESPUÉS DE LA RECURSIÓN (Fase de Desapilamiento / Pop)
    Console.WriteLine($"[LIBERANDO] del Call Stack -> Retorno del método con n = {n}");
}

static int Sumatoria(int n)
{
    // CASO BASE: El elemento neutro de la suma
    if (n == 0)
    {
        return 0;
    }

    // CASO RECURSIVO: Suma el valor actual 'n' con la descomposición del subproblema (n - 1)
    return n + Sumatoria(n - 1);
}

// =========================================================================
// MÉTODOS AUXILIARES DE VALIDACIÓN CONTROLADA
// =========================================================================

static void PausarYLimpiar()
{
    Console.WriteLine("Presiona [ENTER] para regresar al menú principal...");
    Console.ReadLine();
}

static int LeerEntero(string mensaje)
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
            Console.WriteLine("Entrada inválida. Por favor, introduce un número entero.");
        }
    } while (!esValido);

    return numero;
}

static int LeerEnteroPositivo(string mensaje)
{
    int numero;
    do
    {
        numero = LeerEntero(mensaje);
        if (numero < 0)
        {
            Console.WriteLine("Error: El número debe ser entero positivo (mayor o igual a 0).");
        }
    } while (numero < 0);

    return numero;
}