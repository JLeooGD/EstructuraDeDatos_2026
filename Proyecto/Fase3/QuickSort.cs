using System;

namespace DataCore
{
    /// <summary>
    /// Algoritmo QuickSort recursivo instrumentado (Fase 2).
    /// </summary>
    public static class QuickSort
    {
        public static int ContadorLlamadas { get; private set; }

        public static void Ordenar(RegistroDatos[] arr)
        {
            ContadorLlamadas = 0;
            QuickSortRecursivo(arr, 0, arr.Length - 1);
        }

        private static void QuickSortRecursivo(RegistroDatos[] arr, int bajo, int alto)
        {
            ContadorLlamadas++;

            if (bajo >= alto) return;

            // OPTIMIZACIÓN: InsertionSort para sublistas pequeñas
            if (alto - bajo < 10)
            {
                InsertionSort(arr, bajo, alto);
                return;
            }

            int indicePivote = Particionar(arr, bajo, alto);

            QuickSortRecursivo(arr, bajo, indicePivote - 1);
            QuickSortRecursivo(arr, indicePivote + 1, alto);
        }

        private static int Particionar(RegistroDatos[] arr, int bajo, int alto)
        {
            // --- ESTRATEGIA: Mediana de tres ---
            int medio = (bajo + alto) / 2;
            int pivoteIdx = MedianaDeTres(arr, bajo, medio, alto);

            // Mover pivote al final
            (arr[pivoteIdx], arr[alto]) = (arr[alto], arr[pivoteIdx]);
            RegistroDatos pivote = arr[alto];

            // --- Esquema de partición Lomuto ---
            int i = bajo - 1;

            for (int j = bajo; j < alto; j++)
            {
                if (arr[j].Id <= pivote.Id)
                {
                    i++;
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }

            (arr[i + 1], arr[alto]) = (arr[alto], arr[i + 1]);
            return i + 1;
        }

        private static int MedianaDeTres(RegistroDatos[] arr, int bajo, int medio, int alto)
        {
            int a = arr[bajo].Id;
            int b = arr[medio].Id;
            int c = arr[alto].Id;

            if (a <= b && b <= c) return medio;
            if (c <= b && b <= a) return medio;
            if (b <= a && a <= c) return bajo;
            if (c <= a && a <= b) return bajo;
            return alto;
        }

        private static void InsertionSort(RegistroDatos[] arr, int bajo, int alto)
        {
            for (int i = bajo + 1; i <= alto; i++)
            {
                RegistroDatos actual = arr[i];
                int j = i - 1;

                while (j >= bajo && arr[j].Id > actual.Id)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = actual;
            }
        }
    }
}