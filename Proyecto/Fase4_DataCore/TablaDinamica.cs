using System;

namespace DataCore
{
    /// <summary>
    /// Controlador de la lista simplemente enlazada.
    /// Administra la cabeza, el contador y las operaciones de la lista.
    /// </summary>
    public class TablaDinamica
    {
        private NodoRegistro? cabeza;
        private int contadorRegistros;

        /// <summary>
        /// Constructor: inicializa lista vacía
        /// </summary>
        public TablaDinamica()
        {
            cabeza = null;
            contadorRegistros = 0;
        }

        /// <summary>
        /// Obtiene la cantidad de registros almacenados (O(1))
        /// </summary>
        public int ContadorRegistros => contadorRegistros;

        /// <summary>
        /// Inserta un nuevo nodo al inicio de la lista (O(1))
        /// </summary>
        public void InsertarInicio(RegistroDatos nuevoRegistro)
        {
            if (nuevoRegistro.Equals(default(RegistroDatos)))
                throw new ArgumentNullException(nameof(nuevoRegistro), "El registro no puede ser nulo o vacío.");

            NodoRegistro nuevoNodo = new NodoRegistro(nuevoRegistro);
            nuevoNodo.Siguiente = cabeza;
            cabeza = nuevoNodo;
            contadorRegistros++;
        }

        /// <summary>
        /// Inserta un nuevo nodo al final de la lista (O(n))
        /// </summary>
        public void InsertarFinal(RegistroDatos nuevoRegistro)
        {
            if (nuevoRegistro.Equals(default(RegistroDatos)))
                throw new ArgumentNullException(nameof(nuevoRegistro), "El registro no puede ser nulo o vacío.");

            NodoRegistro nuevoNodo = new NodoRegistro(nuevoRegistro);

            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                NodoRegistro actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }
            contadorRegistros++;
        }

        /// <summary>
        /// Elimina el primer nodo cuyo Id coincida con el valor indicado (O(n))
        /// </summary>
        public void EliminarPorId(int idTarget)
        {
            // Caso: lista vacía
            if (cabeza == null)
                return;

            // Caso especial: eliminar la cabeza
            if (cabeza.Dato.Id == idTarget)
            {
                cabeza = cabeza.Siguiente;
                contadorRegistros--;
                return;
            }

            // Caso general: buscar en el resto de la lista
            NodoRegistro anterior = cabeza;
            NodoRegistro actual = cabeza.Siguiente!; // El ! indica que no es null

            while (actual != null)
            {
                if (actual.Dato.Id == idTarget)
                {
                    // Reconectar saltando el nodo a eliminar
                    anterior.Siguiente = actual.Siguiente;
                    contadorRegistros--;
                    return;
                }
                anterior = actual;
                actual = actual.Siguiente!;
            }

            // Si llega aquí, no se encontró el Id
            // (no se lanza excepción, solo no se elimina nada)
        }

        /// <summary>
        /// Convierte la lista enlazada a un arreglo estático (O(n))
        /// </summary>
        public RegistroDatos[] ObtenerComoArreglo()
        {
            RegistroDatos[] resultado = new RegistroDatos[contadorRegistros];
            NodoRegistro? actual = cabeza;
            int i = 0;

            while (actual != null)
            {
                resultado[i] = actual.Dato;
                actual = actual.Siguiente;
                i++;
            }

            return resultado;
        }

        /// <summary>
        /// Muestra todos los registros de la lista en consola (O(n))
        /// </summary>
        public void ImprimirLista()
        {
            NodoRegistro? actual = cabeza;
            int i = 0;

            if (actual == null)
            {
                Console.WriteLine("La lista está vacía.");
                return;
            }

            while (actual != null)
            {
                Console.WriteLine($"  [{i}] {actual.Dato}");
                actual = actual.Siguiente;
                i++;
            }
        }
    }
}