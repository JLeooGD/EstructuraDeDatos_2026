using System;

public class Nodo
{
    public int ID { get; set; }
    public string Dato { get; set; }

    public Nodo? HijoIzquierdo { get; set; }
    public Nodo? HijoDerecho { get; set; }

    public Nodo(int id, string dato)
    {
        ID = id;
        Dato = dato;
    }
}

public class ArbolBinario
{
    public static Nodo InsertarNodo(Nodo? raiz, Nodo nuevoNodo)
    {
        if (raiz == null)
            return nuevoNodo;
        if (nuevoNodo.ID < raiz.ID)
        {
            raiz.HijoIzquierdo = InsertarNodo(
                raiz.HijoIzquierdo,
                nuevoNodo);
        }
        else if (nuevoNodo.ID > raiz.ID)
        {
            raiz.HijoDerecho = InsertarNodo(
                raiz.HijoDerecho,
                nuevoNodo);
        }

        return raiz;
    }

    public static string? BuscarNodo(Nodo? raiz, int idTarget)
    {
        if (raiz == null)
            return null;
        if (idTarget == raiz.ID)
            return raiz.Dato;
        if (idTarget < raiz.ID)
        {
            return BuscarNodo(
                raiz.HijoIzquierdo,
                idTarget);
        }
        else
        {
            return BuscarNodo(
                raiz.HijoDerecho,
                idTarget);
        }
    }
}

class Program
{
    static void Main()
    {
        Nodo raiz = new Nodo(5, "Raíz");
        raiz = ArbolBinario.InsertarNodo(
            raiz,
            new Nodo(3, "Izquierda"));
        raiz = ArbolBinario.InsertarNodo(
            raiz,
            new Nodo(7, "Derecha"));
        raiz = ArbolBinario.InsertarNodo(
            raiz,
            new Nodo(2, "Izquierda de 3"));
        raiz = ArbolBinario.InsertarNodo(
            raiz,
            new Nodo(4, "Derecha de 3"));
        raiz = ArbolBinario.InsertarNodo(
            raiz,
            new Nodo(6, "Izquierda de 7"));
        raiz = ArbolBinario.InsertarNodo(
            raiz,
            new Nodo(8, "Derecha de 7"));
        Console.WriteLine("Buscar ID 3:");
        Console.WriteLine(
            ArbolBinario.BuscarNodo(raiz, 3)
            ?? "No encontrado");

        Console.WriteLine();

        Console.WriteLine("Buscar ID 7:");
        Console.WriteLine(
            ArbolBinario.BuscarNodo(raiz, 7)
            ?? "No encontrado");

        Console.WriteLine();

        Console.WriteLine("Buscar ID 10:");
        Console.WriteLine(
            ArbolBinario.BuscarNodo(raiz, 10)
            ?? "No encontrado");
    }
}