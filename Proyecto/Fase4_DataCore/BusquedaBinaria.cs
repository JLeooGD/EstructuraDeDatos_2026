using System;

namespace DataCore
{
    /// <summary>
    /// Proporciona métodos de búsqueda eficientes sobre arreglos ordenados.
    /// </summary>
    public static class BusquedaBinaria
    {
        /// <summary>
        /// Busca un registro por su Id en un arreglo ordenado usando búsqueda binaria.
        /// Complejidad temporal: O(log n) | Espacial: O(1)
        /// </summary>
        public static (RegistroDatos? registro, int comparaciones) Buscar(RegistroDatos[] arreglo, int idBuscado)
        {
            if (arreglo == null || arreglo.Length == 0)
                return (null, 0);

            int izquierda = 0;
            int derecha = arreglo.Length - 1;
            int comparaciones = 0;

            while (izquierda <= derecha)
            {
                int medio = izquierda + (derecha - izquierda) / 2;
                comparaciones++;

                if (arreglo[medio].Id == idBuscado)
                    return (arreglo[medio], comparaciones);

                if (arreglo[medio].Id < idBuscado)
                    izquierda = medio + 1;
                else
                    derecha = medio - 1;
            }

            return (null, comparaciones);
        }
    }
}