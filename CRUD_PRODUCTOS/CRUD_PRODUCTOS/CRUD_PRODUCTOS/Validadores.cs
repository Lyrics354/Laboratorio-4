namespace CRUD_PRODUCTOS
{
    /// <summary>
    /// Contrato común para todos los validadores de campo del formulario.
    /// </summary>
    public interface IValidadorCampo
    {
        bool EsValido(string? valor);
        string MensajeError { get; }
    }

    // 1. Validador para Texto (ej. Nombre del producto)
    public class ValidadorTexto : IValidadorCampo
    {
        public string MensajeError { get; private set; } = string.Empty;

        public bool EsValido(string? valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                MensajeError = "El campo de texto no puede estar vacío.";
                return false;
            }
            return true;
        }
    }

    // 2. Validador para Decimales (ej. Precio)
    public class ValidadorDecimal : IValidadorCampo
    {
        public string MensajeError { get; private set; } = string.Empty;

        public bool EsValido(string? valor)
        {
            if (string.IsNullOrWhiteSpace(valor) || !decimal.TryParse(valor, out decimal resultado) || resultado < 0)
            {
                MensajeError = "Debe ingresar un número decimal válido.";
                return false;
            }
            return true;
        }
    }

    // 3. Validador para Enteros (ej. Cantidad)
    public class ValidadorEntero : IValidadorCampo
    {
        public string MensajeError { get; private set; } = string.Empty;

        public bool EsValido(string? valor)
        {
            if (string.IsNullOrWhiteSpace(valor) || !int.TryParse(valor, out int resultado) || resultado < 0)
            {
                MensajeError = "Debe ingresar un número entero válido.";
                return false;
            }
            return true;
        }
    }

    /// <summary>
    /// 4. Validador de negocio: verifica que no exista ya un producto con el mismo nombre.
    /// No accede directamente a la base de datos: recibe una función (delegate) que hace
    /// la consulta, para no acoplar el validador a Conexion/MySQL. Así se puede reutilizar
    /// y probar de forma aislada.
    /// </summary>
    public class ValidadorNombreUnico : IValidadorCampo
    {
        private readonly Func<string, bool> _existeEnBaseDeDatos;

        public string MensajeError { get; private set; } = string.Empty;

        public ValidadorNombreUnico(Func<string, bool> existeEnBaseDeDatos)
        {
            _existeEnBaseDeDatos = existeEnBaseDeDatos;
        }

        public bool EsValido(string? valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                MensajeError = "El nombre no puede estar vacío.";
                return false;
            }

            string nombreNormalizado = Normalizador.NormalizarNombre(valor);

            if (_existeEnBaseDeDatos(nombreNormalizado))
            {
                MensajeError = $"Ya existe un producto llamado \"{nombreNormalizado}\".";
                return false;
            }

            return true;
        }
    }
}