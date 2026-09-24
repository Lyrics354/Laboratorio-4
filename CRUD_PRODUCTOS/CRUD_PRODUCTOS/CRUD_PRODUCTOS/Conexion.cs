using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySqlConnector;
using System.Windows.Forms;   // ← agrega esta si no está, para que funcione MessageBox

namespace CRUD_PRODUCTOS
{
    public class Conexion
    {
        private static string cadenaConexion = "Server=localhost;Database=productosdb;Uid=root;Pwd=shenhua194";

        // Obtiene una conexión abierta a MySQL
        public static MySqlConnection ObtenerConexion()
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(cadenaConexion);
                conexion.Open();
                return conexion;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al conectar: " + ex.Message);
                return null;
            }
        }

        // Trae la lista de productos, con filtro opcional de búsqueda
        public static List<Producto> GetProductos(string filtro)
        {
            List<Producto> listaProductos = new List<Producto>();
            string query = "SELECT id, nombre, precio, cantidad, imagen FROM productos";

            if (!string.IsNullOrEmpty(filtro))
            {
                query += " WHERE id LIKE @filtro OR nombre LIKE @filtro " +
                          " OR precio LIKE @filtro OR cantidad LIKE @filtro";
            }

            using (MySqlConnection conn = ObtenerConexion())
            {
                if (conn == null) return listaProductos;

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(filtro))
                    {
                        cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
                    }

                    using (MySqlDataReader mReader = cmd.ExecuteReader())
                    {
                        while (mReader.Read())
                        {
                            Producto prod = new Producto();

                            prod.Id = Convert.ToInt32(mReader["id"]);
                            prod.Nombre = mReader["nombre"].ToString();
                            prod.Precio = Convert.ToDecimal(mReader["precio"]);
                            prod.Cantidad = Convert.ToInt32(mReader["cantidad"]);
                            prod.Imagen = mReader["imagen"] != DBNull.Value ? (byte[])mReader["imagen"] : null;

                            listaProductos.Add(prod);
                        }
                        mReader.Close();
                    }
                }
            }

            return listaProductos;
        }

        /// <summary>
        /// Indica si ya existe un producto con ese nombre (comparación insensible a mayúsculas).
        /// Al modificar un producto, pásale idExcluir = idSeleccionado para no chocar consigo mismo.
        /// </summary>
        public static bool ExisteProductoPorNombre(string nombre, int idExcluir = 0)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                return false;

            string query = "SELECT COUNT(*) FROM productos WHERE UPPER(nombre) = UPPER(@nombre) AND id <> @idExcluir";

            try
            {
                using (MySqlConnection conn = ObtenerConexion())
                {
                    if (conn == null) return false;

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre.Trim());
                        cmd.Parameters.AddWithValue("@idExcluir", idExcluir);

                        long total = Convert.ToInt64(cmd.ExecuteScalar());
                        return total > 0;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error al verificar nombre duplicado: " + ex.Message);
                // Ante un error de conexión, no bloqueamos al usuario por esto;
                // dejamos que el INSERT/UPDATE falle más adelante si hay un problema real.
                return false;
            }
        }

        // Insert genérico y seguro (evita inyección SQL)
        public static bool InsertSeguro(string tbName, Dictionary<string, object> data)
        {
            var columns = string.Join(", ", data.Keys);
            var placeholders = "@" + string.Join(", @", data.Keys);
            string sql = $"INSERT INTO {tbName} ({columns}) VALUES ({placeholders})";

            try
            {
                using (MySqlConnection conexion = ObtenerConexion())
                {
                    if (conexion == null) return false;

                    using (MySqlCommand stmt = new MySqlCommand(sql, conexion))
                    {
                        foreach (var kvp in data)
                        {
                            stmt.Parameters.AddWithValue("@" + kvp.Key, kvp.Value ?? DBNull.Value);
                        }

                        stmt.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en INSERT: " + ex.Message);
                MessageBox.Show("Error en INSERT: " + ex.Message);
                return false;
            }
        }

        // Update genérico y seguro, por id
        public static bool UpdateSeguro(string tbName, Dictionary<string, object> data, int id)
        {
            var sets = string.Join(", ", data.Keys.Select(k => $"{k} = @{k}"));
            string sql = $"UPDATE {tbName} SET {sets} WHERE id = @id";

            try
            {
                using (MySqlConnection conexion = ObtenerConexion())
                {
                    if (conexion == null) return false;

                    using (MySqlCommand stmt = new MySqlCommand(sql, conexion))
                    {
                        foreach (var kvp in data)
                        {
                            stmt.Parameters.AddWithValue("@" + kvp.Key, kvp.Value ?? DBNull.Value);
                        }
                        stmt.Parameters.AddWithValue("@id", id);

                        stmt.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en UPDATE: " + ex.Message);
                return false;
            }
        }

        // Delete seguro, por id
        public static bool DeleteSeguro(string tbName, int id)
        {
            string sql = $"DELETE FROM {tbName} WHERE id = @id";

            try
            {
                using (MySqlConnection conexion = ObtenerConexion())
                {
                    if (conexion == null) return false;

                    using (MySqlCommand stmt = new MySqlCommand(sql, conexion))
                    {
                        stmt.Parameters.AddWithValue("@id", id);
                        stmt.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error en DELETE: " + ex.Message);
                return false;
            }
        }
    }
}