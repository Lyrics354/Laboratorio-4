# Laboratorio 4 - Base de Datos - CRUD

📅 Fecha: 14/09/2026

📄 Contenido del Repositorio

Aplicación de escritorio en C# (Windows Forms) que implementa un CRUD completo
de productos, conectado a una base de datos MySQL. Permite capturar datos
textuales (nombre, precio, cantidad) y gráficos (imagen del producto), validarlos,
normalizarlos y persistirlos usando `Dictionary<string, object>` y `MemoryStream`
para el manejo binario de imágenes.

## 🛠️ Tecnologías Utilizadas

- **Lenguaje / Framework:** C# — .NET (Windows Forms)
- **Base de datos:** MySQL
- **Conector:** MySqlConnector (instalado vía NuGet)
- **Herramientas:** Visual Studio, MySQL Workbench, Git

## 💻 Capturas de Pantalla y Problemas

### Interfaz Principal

<img width="670" height="862" alt="image" src="https://github.com/user-attachments/assets/04ebc382-7789-4a01-ae99-3dae7b6fd814" />

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

## 🚀 Instrucciones de Ejecución / Uso

1. **Clonar el repositorio**
   ```
[   git clone <url-del-repositorio>
](https://github.com/Lyrics354/Laboratorio-4.git)
    ```

2. **Configurar la base de datos**
   - Instalar MySQL Installer y MySQL Workbench.
   - Verificar que el servicio de MySQL (`MySQL80` o el instalado) esté activo
     (`services.msc`) o que `MySQL Notifier` esté encendido.
   - Ejecutar el script `database/productos.sql` en MySQL Workbench para crear
     la base de datos `productosdb` y la tabla `productos`.

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
