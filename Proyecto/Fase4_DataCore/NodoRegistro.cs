using System;

namespace DataCore
{
    /// <summary>
    /// Clase que representa un nodo individual en la lista enlazada.
    /// Almacenado en el Heap como Reference Type.
    /// </summary>
    public class NodoRegistro
    {
        /// <summary>
        /// Dato almacenado en este nodo (struct inmutable)
        /// </summary>
        public RegistroDatos Dato { get; set; }

        /// <summary>
        /// Referencia al siguiente nodo de la cadena
        /// null si es el último nodo
        /// </summary>
        public NodoRegistro? Siguiente { get; set; }

        /// <summary>
        /// Constructor: inicializa el dato y deja Siguiente en null
        /// </summary>
        /// <param name="dato">RegistroDatos a almacenar</param>
        public NodoRegistro(RegistroDatos dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }
}