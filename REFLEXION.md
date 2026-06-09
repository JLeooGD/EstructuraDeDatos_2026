Respuestas a las Preguntas de Reflexión Final (Entregable 5)
Adjunto mis conclusiones y el análisis personal sobre la práctica de Árboles Binarios, Big O y Recursión, enfocándome en el razonamiento lógico detrás de cada concepto solicitado en la rúbrica.
1 . Sobre la estructura del árbol
Pregunta: Si insertas los nodos en este orden: 10, 5, 15, 3, 7, 12, 20, ¿cómo quedaría el árbol visualmente? Dibuja la jerarquía y determina la altura del árbol resultante.
Respuesta:
Siguiendo la regla de que los valores menores van a la izquierda de cada nodo y los mayores a la derecha, la estructura se acomoda de forma completamente simétrica:
```text
        10
       /  \
      5    15
     / \   / \
    3   7 12  20
Altura del árbol: La altura es 2 (contada por el número de aristas/conexiones máximas desde la raíz hasta la hoja más profunda) o Nivel 3 si contamos el número de niveles de nodos. Al estar perfectamente balanceado, ofrece el mejor rendimiento posible.
2. Sobre la complejidad Big O
Pregunta: Ahora inserta los nodos en este orden: 1, 2, 3, 4, 5, 6, 7. ¿Cómo queda el árbol? ¿Por qué la búsqueda ya no es O(log n) en este caso? ¿Qué nombre recibe este problema y qué solución existe?
Respuesta:
Al insertar los elementos en un orden estrictamente creciente, el árbol pierde su estructura ramificada y se convierte en una línea recta descendente hacia la derecha:
   1
    \
     2
      \
       3
        \
         4
          \
           5
            \
             6
              \
               7
Por qué ya no es O(log n)? Debido a que no existen subárboles izquierdos, el algoritmo ya no puede descartar la mitad de las opciones en cada paso. Se ve obligado a recorrer los nodos uno por uno de forma secuencial, igual que en una lista enlazada. Su complejidad en el peor de los casos se degrada a O(n).
El nombre del problema, a este se le conoce como un árbol degenerado o árbol desbalanceado. Su solución para resolver esto sin importar el orden en que se introduzcan los datos, se utilizan estructuras de árboles auto-balanceables que reestructuran sus nodos mediante rotaciones dinámicas, como los Árboles AVL o los Árboles Red-Black (Rojinegros).
3. Sobre la recursión
Pregunta: Explica con tus propias palabras la diferencia entre el caso base y el caso recursivo en la función BuscarNodo. ¿Qué ocurriría si eliminases el caso base? ¿Qué error se produciría en tiempo de ejecución?
Respuesta:
El caso base es la condición de parada del algoritmo. En BuscarNodo tenemos dos: cuando el nodo actual es null (el ID no existe) o cuando el ID coincide con el del nodo actual.
El caso recursivo es la instrucción que divide el problema en una versión más pequeña, llamando a la misma función pero pasando como argumento el hijo izquierdo o el hijo derecho según corresponda.
Si se elimina el caso base, el algoritmo se ejecutaría de manera infinita porque nunca encontraría un freno.
El error en tiempo de ejecución, provocaría un desbordamiento de pila, arrojando la excepción StackOverflowException, lo que colapsaría el programa inmediatamente al quedarse sin memoria para registrar las llamadas del método.
4. Sobre aplicaciones reales
Pregunta: Nombra dos situaciones del mundo real donde un árbol binario de búsqueda sería más eficiente que una lista ordenada. Justifica por qué la complejidad O(log n) marca la diferencia en esos casos concretos.
Respuesta:
Tablas de enrutamiento IP en routers de red de alto tráfico: Los routers de internet procesan millones de paquetes por segundo y deben decidir instantáneamente el camino de salida comparando IPs. Y una lista ordenada requeriría un costo de inserción/modificación lineal O(n) muy costoso. Un árbol binario mantiene búsquedas y actualizaciones en O(logn), evitando cuellos de botella en la red.
Sistemas de autocompletado y búsqueda en plataformas de Streaming: Cuando el usuario escribe el nombre de una canción o película, el sistema busca en catálogos de millones de registros en tiempo real. La complejidad O(logn) descarta millones de opciones no deseadas en unos pocos pasos lógicos, entregando una respuesta en milisegundos que el usuario percibe como inmediata, algo imposible de mantener de forma dinámica con listas ordenadas de gran tamaño.