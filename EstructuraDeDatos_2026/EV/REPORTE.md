# REPORTE.md
# Simulacro de Examen Bimestral – Clase 11
**Materia:** Estructura de Datos – C#  
**Proyecto:** Sistema de Monitoreo de Conexiones de Red
## Auditoría de Código
### 1. Clase: Nodo
**Fallo detectado:** La asignación `n2 = n1` se interpretó como una copia del objeto.
**Principio violado:** Manejo de tipos por referencia (Reference Types).
**Severidad:** Alta.
**Corrección aplicada:** Se explicó que ambos objetos apuntan a la misma dirección de memoria. Para obtener una copia independiente se puede implementar una copia profunda (Deep Copy) o utilizar un `struct` cuando sea apropiado.
### 2. Clase: PuntoDeRed
**Fallo detectado:** No existía validación para las coordenadas geográficas.
**Principio violado:** Validación de datos (Fail Fast).
**Severidad:** Alta.
**Corrección aplicada:** Se agregaron validaciones en el constructor para verificar que la latitud esté entre -90 y 90 grados y la longitud entre -180 y 180 grados. En caso contrario se lanza una excepción `ArgumentOutOfRangeException`.
### 3. Clase: ServidorConexion
**Fallo detectado:** La lista de códigos de respuesta podía contener un valor `null`.
**Principio violado:** Programación defensiva.
**Severidad:** Media.
**Corrección aplicada:** Se inicializa una lista vacía cuando el parámetro recibido es `null`, evitando errores durante la ejecución.
### 4. Clase: ServidorConexion
**Fallo detectado:** El cálculo de Fibonacci realizaba llamadas recursivas repetidas.
**Principio violado:** Optimización de algoritmos.
**Severidad:** Alta.
**Corrección aplicada:** Se implementó Memoization utilizando un arreglo de caché para almacenar resultados previamente calculados y evitar operaciones repetitivas.
### 5. Clase: Program
**Fallo detectado:** No existía manejo de excepciones para datos ingresados por el usuario.
**Principio violado:** Robustez del sistema.
**Severidad:** Alta.
**Corrección aplicada:** Se implementaron bloques `try-catch` para controlar errores de formato, rango y desbordamiento.
### 6. Clase: Program
**Fallo detectado:** El filtrado de servidores se realizaba de forma manual.
**Principio violado:** Código poco mantenible.
**Severidad:** Baja.
**Corrección aplicada:** Se implementaron consultas LINQ utilizando `Where()` y `Contains()` para mejorar la legibilidad y organización del código.
# Conclusión
Durante la auditoría se detectaron problemas relacionados con el manejo de referencias, validación de datos, optimización del algoritmo y control de excepciones. Después de aplicar las correcciones, el sistema cumple con los requisitos del simulacro, utilizando correctamente `struct`, `class`, recursividad con Memoization, consultas LINQ y manejo de excepciones para obtener un código más seguro, eficiente y fácil de mantener.