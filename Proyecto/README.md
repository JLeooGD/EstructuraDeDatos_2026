# DataCore - Proyecto de Estructuras de Datos (v4.0)

## 📋 Descripción General

Proyecto final para la asignatura de **Estructuras de Datos** en **UNITEC**. Implementa cuatro estructuras y algoritmos fundamentales: **Selection Sort**, **QuickSort**, **Lista Simplemente Enlazada** y **Búsqueda Binaria Indexada**, con un menú interactivo completo que integra todas las funcionalidades.

| Fase       | Estructura/Algoritmo       | Complejidad         | Característica principal        |
| ---------- | -------------------------- | ------------------- | ------------------------------- |
| **Fase 1** | Selection Sort             | O(n²)               | Mínimo de intercambios (O(n))   |
| **Fase 2** | QuickSort                  | O(n log n) promedio | Mediana de tres + InsertionSort |
| **Fase 3** | Lista Simplemente Enlazada | O(n)                | Memoria dinámica en Heap        |
| **Fase 4** | Búsqueda Binaria Indexada  | O(log n)            | Menú interactivo + índice       |

---

## 🛠️ Tecnologías

* **.NET 8 (LTS)**
* **C# 10+**
* **Visual Studio Code**
* **Git** y **GitHub** (Git Flow Enterprise)

---

## 📂 Estructura del proyecto

```text
EDD/
├── .git/
├── .gitignore
├── proyecto/
│   ├── Fase1_DataCore/              # FASE 1: SELECTION SORT
│   │   ├── DataCore.csproj
│   │   ├── RegistroDatos.cs         # Struct inmutable
│   │   ├── Ordenamiento.cs          # Selection Sort + métricas
│   │   └── Program.cs               # Orquestador (40 registros)
│   │
│   ├── Fase2_DataCore/              # FASE 2: QUICKSORT
│   │   ├── DataCore.csproj
│   │   ├── RegistroDatos.cs         # Reutilizado
│   │   ├── SelectionSort.cs         # Reutilizado
│   │   ├── QuickSort.cs             # QuickSort + mediana de tres
│   │   ├── Benchmark.cs             # Benchmark comparativo
│   │   └── Program.cs               # Orquestador (10,000 registros)
│   │
│   ├── Fase3_DataCore/              # FASE 3: LISTA ENLAZADA
│   │   ├── DataCore.csproj
│   │   ├── RegistroDatos.cs         # Reutilizado
│   │   ├── SelectionSort.cs         # Reutilizado
│   │   ├── QuickSort.cs             # Reutilizado
│   │   ├── NodoRegistro.cs          # Nodo de la lista enlazada
│   │   ├── TablaDinamica.cs         # Controlador de la lista
│   │   └── Program.cs               # Orquestador (15 registros)
│   │
│   └── Fase4_DataCore/              # FASE 4: INTEGRACIÓN TOTAL
│       ├── DataCore.csproj
│       ├── RegistroDatos.cs         # Reutilizado (Fase 1)
│       ├── SelectionSort.cs         # Reutilizado (Fase 1)
│       ├── QuickSort.cs             # Reutilizado (Fase 2)
│       ├── TablaDinamica.cs         # Reutilizado (Fase 3)
│       ├── NodoRegistro.cs          # Reutilizado (Fase 3)
│       ├── BusquedaBinaria.cs       # Búsqueda binaria O(log n)
│       └── Program.cs               # Menú interactivo CLI
│
├── Sustento_Teorico_Fase1.docx      # Teoría Fase 1
├── Sustento_Teorico_Fase2.docx      # Teoría Fase 2
├── Sustento_Teorico_Fase3.docx      # Teoría Fase 3
├── Sustento_Teorico_Fase4.docx      # Teoría Fase 4
└── README.md                        # Este archivo
```

---

## 🚀 Cómo ejecutar

### Fase 4: DataCore v4.0 (Menú interactivo completo)

```bash
# Navegar a la carpeta de la Fase 4
cd proyecto/Fase4_DataCore

# Compilar
dotnet build

# Ejecutar
dotnet run
```

### Fases individuales

```bash
# Fase 1: Selection Sort
cd proyecto/Fase1_DataCore && dotnet run

# Fase 2: QuickSort (Benchmark)
cd proyecto/Fase2_DataCore && dotnet run

# Fase 3: Lista Enlazada
cd proyecto/Fase3_DataCore && dotnet run
```

---

## 📊 Resultados obtenidos

### Fase 1: Selection Sort (n = 40)

| Métrica           | Valor     | Explicación                 |
| ----------------- | --------- | --------------------------- |
| **Comparaciones** | 780       | `n(n-1)/2 = 40×39/2` (fijo) |
| **Intercambios**  | 38        | Máximo `n-1 = 39`           |
| **Tiempo**        | ~0.004 ms | Medido con `Stopwatch`      |

### Fase 2: Benchmark Comparativo (n = 10,000)

| Algoritmo          | Tiempo              | Operaciones                 |
| ------------------ | ------------------- | --------------------------- |
| **Selection Sort** | 207.95 ms           | 49,995,000 comparaciones    |
| **QuickSort**      | 1.70 ms             | 2,919 llamadas recursivas   |
| **Ratio**          | **122× más rápido** | QuickSort vs Selection Sort |

### Fase 3: Lista Simplemente Enlazada

| Métrica                  | Valor                  |
| ------------------------ | ---------------------- |
| **Registros insertados** | 15                     |
| **Registros eliminados** | 2 (Ids 5 y 11)         |
| **Registros finales**    | 13                     |
| **Estructura**           | Lista enlazada en Heap |
| **Ordenamiento**         | QuickSort (Fase 2)     |

### Fase 4: DataCore v4.0

| Característica                | Descripción                                                     |
| ----------------------------- | --------------------------------------------------------------- |
| **Menú interactivo**          | 6 opciones: Insertar, Eliminar, Mostrar, Indexar, Buscar, Salir |
| **Búsqueda binaria**          | O(log n) sobre arreglo ordenado                                 |
| **Contador de comparaciones** | Muestra cuántas comparaciones realizó la búsqueda               |
| **Manejo de errores**         | `try-catch` individual por opción + `int.TryParse`              |
| **Casos borde**               | Lista vacía, elemento no encontrado, entrada inválida           |

---

## 🔧 Decisiones técnicas

### Fase 1: Selection Sort

* **Inmutabilidad:** `readonly struct` para `RegistroDatos`
* **Validación:** Design by Contract en constructor
* **Intercambio:** Sintaxis de tuplas `(arr[i], arr[minIdx]) = (arr[minIdx], arr[i])` (C# 7.0+)
* **Medición:** `Stopwatch.GetTimestamp()` para alta resolución

### Fase 2: QuickSort

* **Estrategia de pivote:** Mediana de tres (evita O(n²) en datos ordenados)
* **Caso base:** InsertionSort para subarreglos < 10
* **Instrumentación:** Contador de llamadas recursivas (análisis del Call Stack)

### Fase 3: Lista Simplemente Enlazada

* **Memoria dinámica:** Nodos alojados en el Heap con `new NodoRegistro()`
* **Operaciones:** `InsertarInicio()` O(1), `InsertarFinal()` O(n), `EliminarPorId()` O(n)
* **Interoperabilidad:** `ObtenerComoArreglo()` como puente con algoritmos de Fases 1 y 2

### Fase 4: Integración total

* **Búsqueda binaria:** Implementada sobre arreglo ordenado con contador de comparaciones
* **Menú CLI:** Bucle `do-while` con validación de entrada y pausas para mejorar UX
* **Indexación:** Extracción de la lista enlazada a arreglo + ordenamiento con QuickSort
* **Manejo de excepciones:** Captura específica por opción (`FormatException`, `NullReferenceException`, etc.)

---

## 📝 Sustento teórico

### Fase 1

1. **Gestión de Memoria: Stack vs. Heap**

   * `RegistroDatos` como `struct` se almacena en el **Stack**
   * Ventajas: acceso ultrarrápido, sin presión sobre Garbage Collector

2. **Eficiencia de Intercambios en Selection Sort**

   * Complejidad: O(n²) comparaciones, O(n) intercambios

### Fase 2

1. **Paradoja del Peor Caso**

   * Pivote fijo en arreglo ordenado → O(n²)
   * Solución: mediana de tres

2. **Eficiencia en Espacio (RAM)**

   * Variables de control se acumulan en el **Stack**
   * Profundidad: O(log n) promedio, O(n) peor caso

### Fase 3

1. **Memoria Heap vs Arreglos Estáticos**

   * Arreglos: bloque contiguo fijo
   * Listas: nodos individuales (crecimiento dinámico)

2. **Stack vs Heap en Nodos**

   * Referencia en Stack, objeto en Heap
   * Garbage Collector libera nodos sin referencias

### Fase 4

1. **La Necesidad del Índice**

   * La lista enlazada no permite acceso aleatorio O(1)
   * Se extrae a arreglo ordenado para búsqueda binaria

2. **O(n) vs O(log n)**

   * Para 1,000,000 registros: lineal = 1,000,000 comparaciones; binaria ≈ 20 comparaciones

3. **Git Flow y main**

   * Ramas independientes aíslan desarrollo y protegen `main`

---

## ✅ Estado del proyecto

| Fase       | Compilación | Ejecución | Métricas | Teoría | Menú interactivo |
| ---------- | ----------- | --------- | -------- | ------ | ---------------- |
| **Fase 1** | ✅           | ✅         | ✅        | ✅      | ❌                |
| **Fase 2** | ✅           | ✅         | ✅        | ✅      | ❌                |
| **Fase 3** | ✅           | ✅         | ✅        | ✅      | ❌                |
| **Fase 4** | ✅           | ✅         | ✅        | ✅      | ✅                |

---

## 🔗 Enlaces

* [Repositorio en GitHub](https://github.com/JLeooGD/EstructuraDeDatos_2026)

---

## 👤 Autor

**José Leonardo García Díaz**
UNITEC - Estructura de Datos
Agosto 2026

---

## 📅 Fechas de entrega

| Fase       | Fecha               |
| ---------- | ------------------- |
| **Fase 1** | 2 de agosto de 2026 |
| **Fase 2** | Agosto 2026         |
| **Fase 3** | Agosto 2026         |
| **Fase 4** | Agosto 2026         |

```
```