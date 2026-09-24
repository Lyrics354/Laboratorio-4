using System.Drawing.Imaging;

namespace CRUD_PRODUCTOS
{
    /// <summary>
    /// Librería de utilidades para convertir imágenes hacia y desde arreglos de bytes.
    /// Se usa tanto al guardar en la base de datos (ImageToByteArray) como al leerla
    /// para mostrarla en el DataGridView / PictureBox (ByteArrayToImage).
    /// </summary>
    public static class ImagenHelper
    {
        /// <summary>
        /// Convierte una Image en un arreglo de bytes en formato PNG para guardarla en la BD.
        /// </summary>
        public static byte[]? ImageToByteArray(Image? image)
        {
            if (image == null)
                return null;

            using (MemoryStream mMemoryStream = new MemoryStream())
            {
                // Se fuerza PNG en lugar de usar image.RawFormat, porque RawFormat
                // puede venir null cuando la imagen fue clonada en memoria
                // (por ejemplo, al leerla de vuelta desde la base de datos),
                // lo que provoca ArgumentNullException: Parameter 'encoder'.
                image.Save(mMemoryStream, ImageFormat.Png);
                return mMemoryStream.ToArray();
            }
        }

        /// <summary>
        /// Convierte un arreglo de bytes proveniente de la BD en una Image lista para mostrar.
        /// Clona el bitmap para poder cerrar el MemoryStream sin que la imagen deje de ser válida.
        /// </summary>
        public static Image? ByteArrayToImage(byte[]? bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return null;

            using (MemoryStream ms = new MemoryStream(bytes))
            using (Bitmap bmpOriginal = new Bitmap(ms))
            {
                return new Bitmap(bmpOriginal); // clon, para que sobreviva al Dispose del stream
            }
        }
    }
}