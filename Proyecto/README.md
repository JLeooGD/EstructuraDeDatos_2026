```markdown
# DataCore - Proyecto de Estructuras de Datos

## 📋 Descripción General

Proyecto final para la asignatura de **Estructuras de Datos** en **UNITEC**. Implementa dos algoritmos de ordenamiento fundamentales: **Selection Sort** y **QuickSort**, con instrumentación de métricas reales (comparaciones, intercambios, tiempo de ejecución y llamadas recursivas).

| Fase | Algoritmo | Complejidad | Característica principal |
|------|-----------|-------------|--------------------------|
| **Fase 1** | Selection Sort | O(n²) | Mínimo de intercambios (O(n)) |
| **Fase 2** | QuickSort | O(n log n) promedio | Mediana de tres + InsertionSort |

---

## 🛠️ Tecnologías

- **.NET 8** (LTS)
- **C# 10+**
- **Visual Studio Code**
- **Git** y **GitHub** (Git Flow Enterprise)

---

## 📂 Estructura del proyecto

```
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
│   └── Fase2/              # FASE 2: QUICKSORT
│       ├── DataCore.csproj
│       ├── RegistroDatos.cs         # Reutilizado de Fase 1
│       ├── SelectionSort.cs         # Reutilizado de Fase 1
│       ├── QuickSort.cs             # QuickSort + mediana de tres
│       ├── Benchmark.cs             # Benchmark comparativo
│       └── Program.cs               # Orquestador (10,000 registros)
│
├── Sustento_Teorico_Fase1.docx      # Teoría Fase 1
├── Sustento_Teorico_Fase2.docx      # Teoría Fase 2
└── README.md                        # Este archivo
```

---

## 🚀 Cómo ejecutar

### Fase 1: Selection Sort

```bash
# Navegar a la carpeta de la Fase 1
cd proyecto/Fase1_DataCore

# Compilar
dotnet build

# Ejecutar
dotnet run
```

### Fase 2: QuickSort (Benchmark comparativo)

```bash
# Navegar a la carpeta de la Fase 2
cd proyecto/Fase2_DataCore

# Compilar
dotnet build

# Ejecutar
dotnet run
```

---

## 📊 Resultados obtenidos

### Fase 1: Selection Sort (n = 40)

| Métrica | Valor | Explicación |
|---------|-------|-------------|
| **Comparaciones** | 780 | `n(n-1)/2 = 40×39/2` (fijo) |
| **Intercambios** | 38 | Máximo `n-1 = 39` |
| **Tiempo** | ~0.004 ms | Medido con `Stopwatch` |

### Fase 2: Benchmark Comparativo (n = 10,000)

| Algoritmo | Tiempo | Operaciones |
|-----------|--------|-------------|
| **Selection Sort** | 207.95 ms | 49,995,000 comparaciones |
| **QuickSort** | 1.70 ms | 2,919 llamadas recursivas |
| **Ratio** | **122× más rápido** | QuickSort vs Selection Sort |

---

## 🔧 Decisiones técnicas

### Fase 1: Selection Sort

- **Inmutabilidad:** `readonly struct` para `RegistroDatos`
- **Validación:** Design by Contract en constructor
- **Intercambio:** Sintaxis de tuplas `(arr[i], arr[minIdx]) = (arr[minIdx], arr[i])` (C# 7.0+)
- **Medición:** `Stopwatch.GetTimestamp()` para alta resolución

### Fase 2: QuickSort

- **Estrategia de pivote:** Mediana de tres (evita O(n²) en datos ordenados)
- **Caso base:** InsertionSort para subarreglos < 10
- **Instrumentación:** Contador de llamadas recursivas (análisis del Call Stack)

---

## 📝 Sustento teórico

### Fase 1
1. **Gestión de Memoria: Stack vs. Heap**
   - `RegistroDatos` como `struct` se almacena en el **Stack**
   - Ventajas: acceso ultrarrápido, sin presión sobre Garbage Collector

2. **Eficiencia de Intercambios en Selection Sort**
   - Complejidad: O(n²) comparaciones, O(n) intercambios
   - Ideal cuando el costo de escritura es alto

### Fase 2
1. **Paradoja del Peor Caso**
   - Pivote fijo en arreglo ordenado → O(n²)
   - Solución: mediana de tres

2. **Eficiencia en Espacio (RAM)**
   - Variables de control se acumulan en el **Stack**
   - Profundidad: O(log n) promedio, O(n) peor caso

---

## ✅ Estado del proyecto

| Fase | Compilación | Ejecución | Métricas | Teoría |
|------|-------------|-----------|----------|--------|
| **Fase 1** | ✅ | ✅ | ✅ | ✅ |
| **Fase 2** | ✅ | ✅ | ✅ | ✅ |

---

## 🔗 Enlaces

- [Repositorio en GitHub](https://github.com/JLeooGD/EstructuraDeDatos_2026)
- [Pull Request Fase 1](https://github.com/JLeooGD/EstructuraDeDatos_2026/pulls)
- [Pull Request Fase 2](https://github.com/JLeooGD/EstructuraDeDatos_2026/pulls)

---

## 👤 Autor

**José Leonardo García Díaz**  
UNITEC - Estructura de Datos  
Agosto 2026

```
