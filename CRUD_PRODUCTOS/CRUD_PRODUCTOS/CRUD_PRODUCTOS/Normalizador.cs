using System.Globalization;
using System.Text.RegularExpressions;

namespace CRUD_PRODUCTOS
{
    /// <summary>
    /// Reglas de normalización de datos antes de guardarlos, para evitar
    /// inconsistencias como espacios extra, mayúsculas/minúsculas mezcladas
    /// o decimales con más de 2 posiciones.
    /// </summary>
    public static class Normalizador
    {
        /// <summary>
        /// Limpia espacios, colapsa espacios múltiples y aplica Formato Título
        /// (Ej: "  arroz   BLANCO " -> "Arroz Blanco").
        /// Esto es clave para que la comparación de duplicados sea consistente:
        /// "ARROZ", "arroz" y "Arroz" terminan guardados de la misma forma.
        /// </summary>
        public static string NormalizarNombre(string? valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return string.Empty;

            string limpio = valor.Trim();
            limpio = Regex.Replace(limpio, @"\s+", " "); // colapsa espacios dobles/triples

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(limpio.ToLower(CultureInfo.CurrentCulture));
        }

        /// <summary>Redondea el precio a 2 decimales.</summary>
        public static decimal NormalizarPrecio(decimal precio)
        {
            return Math.Round(precio, 2, MidpointRounding.AwayFromZero);
        }

        /// <summary>Evita cantidades negativas.</summary>
        public static int NormalizarCantidad(int cantidad)
        {
            return cantidad < 0 ? 0 : cantidad;
        }
    }
}