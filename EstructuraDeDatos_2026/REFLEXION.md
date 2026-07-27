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
```
```markdown
---

## Cuestionario de Evaluación - Clase 7: Dominando la Lógica y Anatomía de la Recursividad

### 1. Conceptual
* **Pregunta:** Define con tus propias palabras qué es la recursividad. ¿En qué se diferencia fundamentalmente de un ciclo `while` o `for`? Da un ejemplo de un problema que sea más natural expresar de forma recursiva.
* **Respuesta:** La recursividad es una técnica de diseño de algoritmos en la que una función se resuelve a sí misma invocándose una o más veces con una versión más simple o reducida del problema original, aplicando la estrategia de "Divide y Vencerás". La diferencia fundamental con los ciclos iterativos (`for` o `while`) radica en el manejo de la memoria y el flujo de control: mientras que la iteración utiliza variables locales para actualizar un estado dentro de un único bloque de ejecución continuo, la recursividad suspende la ejecución de la función actual y apila un nuevo *marco de activación* en el *Call Stack* por cada llamada. Esto significa que el resultado recursivo se construye "de adentro hacia afuera" durante la fase de retorno, mientras que el bucle lo hace de forma lineal hacia adelante. Un ejemplo de un problema que es sumamente natural expresar de forma recursiva es la exploración de sistemas de archivos (carpetas que contienen subcarpetas de manera indefinida) o el recorrido de estructuras de datos no lineales como los árboles binarios.

### 2. Análisis de Código
* **Pregunta:** El siguiente código tiene un error crítico. Identifícalo, explica qué excepción produciría en tiempo de ejecución y corrígelo:
  ```csharp
  static int Factorial(int n) {
      return n * Factorial(n - 1);
  }

```

* **Respuesta:** El error crítico en el código es la ausencia total de un caso base. Al no existir una condición de salida que detenga las llamadas recursivas, la función continuará invocándose de manera infinita hacia números negativos (`Factorial(-1)`, `Factorial(-2)`, etc.). En tiempo de ejecución, cada una de estas llamadas continuará creando e introduciendo marcos de activación en la pila de memoria hasta agotar el límite físico asignado por el entorno de ejecución de .NET. Esto producirá de forma inevitable la excepción `StackOverflowException`, la cual finalizará el proceso de la aplicación abruptamente sin posibilidad de ser capturada mediante bloques `try/catch`.
La corrección consiste en implementar explícitamente el caso base para detener la recursión cuando n llegue a 0 o 1:
```csharp
static int Factorial(int n) {
    // CASO BASE: Detiene la recursión y retorna un valor concreto
    if (n <= 1) return 1;

    // CASO RECURSIVO: Reduce el problema acercándose al caso base
    return n * Factorial(n - 1);
}

```

### 3. Call Stack

* **Pregunta:** Dibuja o describe en texto el estado exacto del Call Stack en cada paso cuando se ejecuta `SumarHasta(4)`. Indica cuántos marcos de activación hay en memoria en el punto de máxima profundidad y cuál es el orden en que se liberan.
* **Respuesta:** El comportamiento del *Call Stack* para `SumarHasta(4)` se divide en dos fases bien definidas (Apilado y Retorno) bajo el principio LIFO (Last In, First Out):
**Fase 1: Invocación (Apilado)**
* **Paso 1:** Se invoca el método desde `Main`. Se crea el primer marco de activación. `Stack = [ SumarHasta(4) ]`.
* **Paso 2:** `SumarHasta(4)` evalúa que no es caso base y llama a `SumarHasta(3)`. `Stack = [ SumarHasta(4), SumarHasta(3) ]`.
* **Paso 3:** `SumarHasta(3)` llama a `SumarHasta(2)`. `Stack = [ SumarHasta(4), SumarHasta(3), SumarHasta(2) ]`.
* **Paso 4:** `SumarHasta(2)` llama a `SumarHasta(1)`. `Stack = [ SumarHasta(4), SumarHasta(3), SumarHasta(2), SumarHasta(1) ]`.


Punto de máxima profundidad, en este punto hay 4 marcos de activación simultáneos en memoria correspondientes a la función recursiva (más el marco del método que la invocó, como `Main`).
**Fase 2: Resolución (Retorno / Desapilado)**
Los marcos se liberan en orden inverso al que fueron creados (LIFO), resolviendo las operaciones de arriba hacia abajo:
* **Paso 5:** `SumarHasta(1)` alcanza el caso base y retorna `1`. Se destruye su marco. `Stack = [ SumarHasta(4), SumarHasta(3), SumarHasta(2) ]`.
* **Paso 6:** `SumarHasta(2)` reanuda su ejecución, recibe el `1`, calcula `2 + 1 = 3` y retorna `3`. Se destruye su marco. `Stack = [ SumarHasta(4), SumarHasta(3) ]`.
* **Paso 7:** `SumarHasta(3)` recibe el `3`, calcula `3 + 3 = 6` y retorna `6`. Se destruye su marco. `Stack = [ SumarHasta(4) ]`.
* **Paso 8:** `SumarHasta(4)` recibe el `6`, realiza el cálculo final `4 + 6 = 10` y retorna `10`. La pila queda vacía de llamadas recursivas `Stack = [ ]`.

### 4. Aplicación

* **Pregunta:** Un compañero afirma que siempre es mejor usar un ciclo `for` en lugar de recursividad porque es más eficiente en memoria. ¿Estás de acuerdo? Argumenta tu respuesta mencionando al menos un caso donde la recursividad es la herramienta superior.
* **Respuesta:** No estoy de acuerdo con la afirmación absoluta de que "siempre" es mejor usar un ciclo `for`. Si bien es técnicamente cierto que un ciclo `for` es más eficiente en términos de memoria cruda porque opera mediante variables locales sobre un único marco de ejecución (evitando el costo de apilar múltiples marcos de activación en el *Call Stack*), la eficiencia en el desarrollo de software no solo se mide en hardware, sino también en legibilidad, mantenibilidad y la naturaleza del problema. Existen escenarios complejos donde un enfoque iterativo requiere que el programador implemente y gestione manualmente su propia estructura de pila (Pila en el *Heap*), volviendo el código sumamente prolijo, confuso y propenso a errores lógicos. La recursividad es una herramienta notablemente superior al trabajar con estructuras de datos inherentemente recursivas, como los árboles jerárquicos o los gráficos. Por ejemplo, en el algoritmo de ordenamiento *QuickSort* o al realizar un recorrido en profundidad (*DFS*) sobre un árbol de decisiones, la recursividad permite escribir soluciones elegantes y limpias en pocas líneas de código, reflejando directamente la estructura lógica del subproblema matemático.

### 5. Predicción

* **Pregunta:** ¿Qué imprimiría en consola la siguiente llamada: `ImprimirCuentaRegresiva(3)`? Escribe la salida esperada línea por línea sin ejecutar el código.
* **Respuesta:** Tomando como base la estructura explicada en la guía (donde el mensaje de apilado se ejecuta antes de la llamada recursiva y el de liberación se posiciona estratégicamente después de esta), la salida exacta línea por línea en la consola es:
```text
[APILANDO] Marco con número: 3
[APILANDO] Marco con número: 2
[APILANDO] Marco con número: 1
¡Despegue! 🚀
[LIBERANDO] Marco con número: 1
[LIBERANDO] Marco con número: 2
[LIBERANDO] Marco con número: 3

```



```

```