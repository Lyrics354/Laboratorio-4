# Laboratorio 4 - Base de Datos - CRUD

📅 Fecha: 14/09/2026
🔄 Última actualización: 12/10/2026

## 📄 Contenido del Repositorio

Aplicación de escritorio en C# (Windows Forms) que implementa un CRUD completo
de productos, conectado a una base de datos MySQL. Permite capturar datos
textuales (nombre, precio, cantidad) y gráficos (imagen del producto), validarlos,
normalizarlos y persistirlos usando `Dictionary<string, object>` y `MemoryStream`
para el manejo binario de imágenes.

Cada producto registra además su **fecha de creación (`FechaC`)** y su
**fecha de última modificación (`FechaM`)**, que se muestran en el
`DataGridView` junto al resto de los datos.

## ✨ Funcionalidades

- **Crear, leer, modificar y eliminar** productos (con confirmación al eliminar y al salir).
- **Búsqueda en vivo** por id, nombre, precio o cantidad mientras se escribe.
- **Imagen del producto** seleccionada desde archivo y guardada en la BD como binario (PNG).
- **Validación de campos** con el patrón `IValidadorCampo` + `ErrorProvider`.
- **Normalización de datos** antes de guardar (espacios, formato título, 2 decimales, sin cantidades negativas).
- **Nombre único** sin distinguir mayúsculas/minúsculas (`ValidadorNombreUnico`).
- **Fechas de auditoría** gestionadas automáticamente por MySQL:
  - `FechaC`: se asigna sola al insertar (`DEFAULT CURRENT_TIMESTAMP`).
  - `FechaM`: queda vacía hasta la primera modificación y se actualiza sola en cada `UPDATE` (`ON UPDATE CURRENT_TIMESTAMP`).
  - En el grid se muestran con formato `dd/MM/yyyy HH:mm` y son de solo lectura.

## 🛠️ Tecnologías Utilizadas

- **Lenguaje / Framework:** C# — .NET (Windows Forms)
- **Base de datos:** MySQL
- **Conector:** MySqlConnector (instalado vía NuGet)
- **Herramientas:** Visual Studio, MySQL Workbench, Git

## 💻 Capturas de Pantalla y Problemas

### Interfaz Principal

<img width="670" height="862" alt="image" src="https://github.com/user-attachments/assets/04ebc382-7789-4a01-ae99-3dae7b6fd814" />
<img width="698" height="866" alt="image" src="https://github.com/user-attachments/assets/310b4bea-6e98-4b10-8f20-5e871f46c0e5" />

### Problemas resueltos durante el laboratorio

- **`System.NullReferenceException` al hacer clic en una fila del grid**
  (`dgvProductos_CellContentClick`): ocurría porque `fila.Cells["Nombre"].Value`
  podía venir `null`. Se corrigió usando el operador `?.ToString() ?? ""` en
  lugar de `.ToString()` directo.

- **`System.ArgumentNullException: 'Value cannot be null. (Parameter 'encoder')'`**
  al guardar una imagen (`ImageToByteArray`): ocurría porque `image.RawFormat`
  venía `null` en imágenes clonadas en memoria (como las que vienen de la base
  de datos). Se corrigió forzando el formato `ImageFormat.Png` en el `Save()`.

- **Nombres de producto duplicados** (ej. "Arroz" vs "ARROZ"): se implementó
  normalización de texto (`Normalizador.NormalizarNombre`) y un validador de
  negocio (`ValidadorNombreUnico`) que consulta la base de datos de forma
  insensible a mayúsculas/minúsculas antes de permitir guardar o modificar.

- **`FechaM` nula en productos nunca modificados**: al leer de la BD,
  `mReader["FechaM"]` devuelve `DBNull.Value`. Se declaró la propiedad como
  `DateTime?` en `Producto` y se valida contra `DBNull.Value` en
  `Conexion.GetProductos` antes de convertir, para que la celda quede vacía
  en lugar de lanzar una excepción.

## 🚀 Instrucciones de Ejecución / Uso

1. **Clonar el repositorio**
   ```
   git clone https://github.com/Lyrics354/Laboratorio-4.git
   ```

2. **Configurar la base de datos**
   - Instalar MySQL Installer y MySQL Workbench.
   - Verificar que el servicio de MySQL (`MySQL80` o el instalado) esté activo
     (`services.msc`) o que `MySQL Notifier` esté encendido.
   - Ejecutar el script `database/productos.sql` en MySQL Workbench para crear
     la base de datos `productosdb` y la tabla `productos`.
   - Si la tabla ya existía antes de esta versión, agregar las columnas de fechas:
     ```sql
     ALTER TABLE productos
       ADD COLUMN FechaC DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
       ADD COLUMN FechaM DATETIME NULL ON UPDATE CURRENT_TIMESTAMP;
     ```

3. **Configurar el entorno local**
   - Abrir el proyecto en Visual Studio (Aplicación de Windows Forms, .NET).
   - Revisar la cadena de conexión en `Conexion.cs`:
     ```csharp
     private static string cadenaConexion =
         "Server=localhost;Database=productosdb;Uid=root;Pwd=TU_PASSWORD";
     ```
   - El paquete `MySqlConnector` se restaura automáticamente vía NuGet al
     compilar (no requiere instalación manual del Connector/NET).

4. **Ejecutar el comando de arranque**
   - Compilar y ejecutar con `F5` (o `Fn + F5` en laptops) desde Visual Studio.

> **Nota:** si se presiona *Modificar* sin cambiar ningún dato, MySQL no
> considera que la fila cambió y `FechaM` no se actualiza.

## 📁 Estructura de Carpetas o Directorios

```plaintext
Laboratorio/
├── 01-CRUD_PRODUCTOS
│   ├── Form1.cs              # Formulario principal (CRUD, grid, búsqueda)
│   ├── Conexion.cs           # Acceso a MySQL (Get, Insert, Update, Delete)
│   ├── Producto.cs           # Modelo (incluye FechaC y FechaM)
│   ├── Validadores.cs        # IValidadorCampo y validadores
│   ├── Normalizador.cs       # Reglas de normalización
│   └── ImagenHelper.cs       # Conversión Image <-> byte[]
├── 02-Guia para desarrollar esta asignacion (pdf)
├── 03-Consulta SQL (Query - CRUD + Las 3 consultas)
└── README.md                 # Documentación del proyecto
```

## 👤 Autor y Contexto

- **Nombre:** Wilson Wu
- **Institución:** Universidad Tecnológica de Panamá (UTP) — Facultad de
  Ingeniería en Sistemas, Campus Víctor Levi Sasso
- **Curso:** Herramientas de Programación Aplicada III (.Net) — Grupo 1IL133
- **Instructor:** Ing. Irina Fong
- **Fecha de Realización:** 14/09/2026

## 📚 Referencias

- Laboratorio: Introducción a Base de Datos con MySQL — Ing. Irina Fong
- Descarga del apk MySql: [MySQL Installer](https://dev.mysql.com/downloads/installer/)
- Documentación oficial de [MySqlConnector](https://mysqlconnector.net/)
- MySQL: [Inicialización y actualización automática de DATETIME](https://dev.mysql.com/doc/refman/8.0/en/timestamp-initialization.html)
