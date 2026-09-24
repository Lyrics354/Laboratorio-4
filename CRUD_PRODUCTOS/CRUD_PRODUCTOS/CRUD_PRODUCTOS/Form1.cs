namespace CRUD_PRODUCTOS
{
    public partial class Form1 : Form
    {
        private List<Producto> listaProductos;
        private Dictionary<string, object> myProducto = new Dictionary<string, object>();
        private int idSeleccionado = 0;   // guarda el id del producto seleccionado en el grid

        // No está en el Designer: se crea aquí para mostrar los mensajes de validación
        // junto a cada TextBox (mismo patrón del ejemplo con errorProvider1).
        private ErrorProvider errorProvider1 = new ErrorProvider();

        public Form1()
        {
            InitializeComponent();
            listaProductos = new List<Producto>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarProductos();
        }

        // ---------------------------------------------------
        // Cargar productos en el DataGridView (con filtro opcional)
        // ---------------------------------------------------
        private void cargarProductos(string filtro = "")
        {
            dgvProductos.Rows.Clear();
            dgvProductos.Refresh();

            listaProductos = Conexion.GetProductos(filtro);

            foreach (var prod in listaProductos)
            {
                Image? img = ImagenHelper.ByteArrayToImage(prod.Imagen);
                dgvProductos.Rows.Add(prod.Id, prod.Nombre, prod.Precio, prod.Cantidad, img);
            }
        } // fin de cargarProductos

        // ---------------------------------------------------
        // Búsqueda en vivo mientras se escribe
        // ---------------------------------------------------
        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            cargarProductos(txtBusqueda.Text.Trim());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Seleccionar imagen del producto";
                openFileDialog.Filter = "Archivos de imagen|.jpg;.jpeg;.png;.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        // ---------------------------------------------------
        // Validación de los campos antes de guardar / modificar
        // Usa el patrón IValidadorCampo + ErrorProvider (ver Validadores.cs)
        // ---------------------------------------------------
        private bool datosCorrectos()
        {
            var camposAValidar = new List<(TextBox txt, IValidadorCampo validador)>
            {
                (txtNombre,   new ValidadorTexto()),
                (txtPrecio,   new ValidadorDecimal()),
                (txtCantidad, new ValidadorEntero()),
            };

            bool todoOk = true;

            foreach (var item in camposAValidar)
            {
                if (!item.validador.EsValido(item.txt.Text))
                {
                    errorProvider1.SetError(item.txt, item.validador.MensajeError);
                    todoOk = false;
                }
                else
                {
                    errorProvider1.SetError(item.txt, string.Empty); // limpia si está bien
                }
            }

            // Regla de negocio: nombre único. Solo se evalúa si el formato ya es válido,
            // para no golpear la base de datos con datos incompletos y para no pisar
            // el mensaje de error de ValidadorTexto sobre el mismo campo.
            if (todoOk)
            {
                var validadorNombreUnico = new ValidadorNombreUnico(
                    nombre => Conexion.ExisteProductoPorNombre(nombre, idSeleccionado));

                if (!validadorNombreUnico.EsValido(txtNombre.Text))
                {
                    errorProvider1.SetError(txtNombre, validadorNombreUnico.MensajeError);
                    todoOk = false;
                }
            }

            return todoOk;
        } // fin de datosCorrectos

        // ---------------------------------------------------
        // Cargar los datos del formulario al diccionario myProducto
        // (aquí se aplica la normalización antes de guardar)
        // ---------------------------------------------------
        private void CargarDatosProductos()
        {
            myProducto["Cantidad"] = Normalizador.NormalizarCantidad(int.Parse(txtCantidad.Text.Trim()));
            myProducto["Precio"] = Normalizador.NormalizarPrecio(decimal.Parse(txtPrecio.Text.Trim()));
            myProducto["Nombre"] = Normalizador.NormalizarNombre(txtNombre.Text);
            myProducto["Imagen"] = ImagenHelper.ImageToByteArray(pictureBox1.Image);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (datosCorrectos())
            {
                CargarDatosProductos();

                if (Conexion.InsertSeguro("productos", myProducto))
                {
                    MessageBox.Show("Se ha guardado satisfactoriamente el registro");
                    cargarProductos();
                    limpiarFormulario();
                }
            }
        }

        // ---------------------------------------------------
        // Limpiar campos del formulario
        // ---------------------------------------------------
        private void limpiarFormulario()
        {
            txtNombre.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            pictureBox1.Image = null;
            myProducto.Clear();

            errorProvider1.SetError(txtNombre, string.Empty);
            errorProvider1.SetError(txtPrecio, string.Empty);
            errorProvider1.SetError(txtCantidad, string.Empty);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un producto de la lista para eliminar");
                return;
            }

            DialogResult confirmacion = MessageBox.Show(
                "¿Seguro que deseas eliminar este producto?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                if (Conexion.DeleteSeguro("productos", idSeleccionado))
                {
                    MessageBox.Show("Se ha eliminado el registro");
                    cargarProductos();
                    limpiarFormulario();
                    idSeleccionado = 0;
                }
                else
                {
                    MessageBox.Show("Ocurrió un error al eliminar el registro");
                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un producto de la lista para modificar");
                return;
            }

            if (!datosCorrectos())
            {
                return;
            }

            CargarDatosProductos();

            if (Conexion.UpdateSeguro("productos", myProducto, idSeleccionado))
            {
                MessageBox.Show("Se ha modificado satisfactoriamente el registro");
                cargarProductos();
                limpiarFormulario();
                idSeleccionado = 0;
            }
            else
            {
                MessageBox.Show("Ocurrió un error al modificar el registro");
            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Evita error si se hace clic en el encabezado

            DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

            object idValue = fila.Cells["ID"].Value;
            idSeleccionado = (idValue != null && idValue != DBNull.Value)
                ? Convert.ToInt32(idValue)
                : 0;

            txtNombre.Text = fila.Cells["Nombre"].Value?.ToString() ?? "";
            txtPrecio.Text = fila.Cells["Precio"].Value?.ToString() ?? "";
            txtCantidad.Text = fila.Cells["Cantidad"].Value?.ToString() ?? "";

            object imgValue = fila.Cells["colImagen"].Value;
            if (imgValue != null && imgValue != DBNull.Value)
            {
                pictureBox1.Image = (Image)imgValue;
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void txtBusqueda_TextChanged_1(object sender, EventArgs e)
        {
            cargarProductos(txtBusqueda.Text.Trim());
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show(
            "¿Seguro que deseas salir?",
            "Confirmar salida",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}