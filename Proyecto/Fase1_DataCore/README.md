```markdown
# DataCore - Fase 1

## 📋 Descripción
Implementación de la Fase 1 del proyecto DataCore para la asignatura de **Estructura de Datos** en **UNITEC**.

### Algoritmo implementado
- **Selection Sort** instrumentado con métricas reales:
  - ✅ Comparaciones realizadas
  - ✅ Intercambios efectuados
  - ✅ Tiempo de ejecución (con `Stopwatch`)
  - ✅ Estado inicial del arreglo (primeros y últimos 5 elementos)

### Estructura de datos
- `RegistroDatos` como `readonly struct` inmutable
- Validación por contrato en el constructor
- Campos:
  - `Id` (int) - Llave de ordenamiento
  - `HashValidation` (long) - Código de verificación
  - `PesoBytes` (int) - Tamaño en bytes

## 🛠️ Tecnologías
- **.NET 8** (LTS)
- **C# 10+**
- **Visual Studio Code**
- **Git** y **GitHub** (Git Flow Enterprise)

## 📊 Métricas obtenidas (n = 40)
| Métrica | Valor | Explicación |
|---------|-------|-------------|
| **Tamaño del array** | 40 | Registros generados aleatoriamente |
| **Comparaciones** | 780 | `40 × 39 / 2 = 780` (fijo en Selection Sort) |
| **Intercambios** | 38 | Máximo `n-1 = 39` |
| **Tiempo de ejecución** | ~0.004 ms | Medido con `Stopwatch.GetTimestamp()` |
| **Estado inicial** | `[311, 53, 487, ..., 25, 374]` | Primeros y últimos 5 elementos |

## 📂 Estructura del proyecto
```
EDD/
├── .git/
├── .gitignore
├── proyecto/
│   └── Fase1_DataCore/
│       ├── DataCore.csproj      # Proyecto .NET 8
│       ├── Program.cs           # Orquestador (40 registros)
│       ├── RegistroDatos.cs     # Struct inmutable
│       └── Ordenamiento.cs      # Selection Sort + métricas
├── Sustento_Teorico_Fase1.docx  # Sustento teórico
└── README.md                    # Este archivo
```

## 🚀 Cómo ejecutar
```bash
# Navegar a la carpeta del proyecto
cd proyecto/Fase1_DataCore

# Compilar
dotnet build

# Ejecutar
dotnet run
```

## 📝 Sustento teórico
Las siguientes preguntas fueron respondidas en `Sustento_Teorico_Fase1.docx`:

### 1. Gestión de Memoria: Stack vs. Heap
¿Si modelas `RegistroDatos` como un `struct` (tipo de valor) en lugar de una `class` (tipo de referencia), ¿en qué espacio de la memoria física RAM se almacenará el lote inicial al procesarse localmente dentro de una función?

**Respuesta:** Se almacena en el **Stack**, lo que garantiza acceso ultrarrápido, liberación automática y sin presión sobre el Garbage Collector.

### 2. Eficiencia de Intercambios en Selection Sort
¿Por qué Selection Sort es eficiente en términos de intercambios y cuál es su complejidad?

**Respuesta:** Selection Sort realiza exactamente `n(n-1)/2` comparaciones (O(n²)), pero garantiza como máximo `n-1` intercambios (O(n)). Esto lo hace ideal cuando el costo de escritura es alto.

## 🔧 Decisiones técnicas
- **Inmutabilidad:** Uso de `readonly struct` para evitar mutaciones accidentales
- **Intercambio:** Sintaxis de tuplas `(arr[i], arr[minIdx]) = (arr[minIdx], arr[i])` (C# 7.0+)
- **Medición:** `Stopwatch.GetTimestamp()` para alta resolución
- **Comparaciones:** Implementación de `IEquatable<RegistroDatos>` para evitar boxing

## ✅ Estado del proyecto
| Aspecto | Estado |
|---------|--------|
| **Compilación** | ✅ Sin errores ni warnings |
| **Ejecución** | ✅ Exitosa |
| **Métricas** | ✅ Correctas |
| **Sustento teórico** | ✅ Completado |
| **Git Flow** | ✅ Rama `feature/proyecto-fase1-selection` |

## 🔗 Enlaces
- [Repositorio en GitHub](https://github.com/JLeooGD/EstructuraDeDatos_2026)

## 👤 Autor
**José Leonardo García Díaz**  
UNITEC - Estructura de Datos  
Agosto 2026

## 📅 Fecha de entrega
2 de agosto de 2026