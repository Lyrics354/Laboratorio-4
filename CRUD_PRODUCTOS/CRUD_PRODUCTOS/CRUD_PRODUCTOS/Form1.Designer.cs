namespace CRUD_PRODUCTOS
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            lblTitulo = new Label();
            lblFolio = new Label();
            lblNombre = new Label();
            lblPrecio = new Label();
            lblCantidad = new Label();
            lblImage = new Label();
            txtFolio = new TextBox();
            txtNombre = new TextBox();
            txtPrecio = new TextBox();
            txtCantidad = new TextBox();
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            txtBusqueda = new TextBox();
            lblBusqueda = new Label();
            label7 = new Label();
            pictureBox1 = new PictureBox();
            dgvProductos = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Precio = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            colImagen = new DataGridViewImageColumn();
            btnGuardar = new Button();
            imageList1 = new ImageList(components);
            btnModificar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            btnSalir = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(lblTitulo);
            panel1.Location = new Point(-17, 16);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(746, 61);
            panel1.TabIndex = 0;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = SystemColors.HotTrack;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(268, 3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(84, 58);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = SystemColors.ButtonFace;
            lblTitulo.Location = new Point(32, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(230, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "CRUD PRODUCTOS";
            // 
            // lblFolio
            // 
            lblFolio.AutoSize = true;
            lblFolio.Location = new Point(22, 125);
            lblFolio.Name = "lblFolio";
            lblFolio.Size = new Size(45, 20);
            lblFolio.TabIndex = 1;
            lblFolio.Text = "Folio:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(22, 177);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(67, 20);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre:";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(22, 221);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(53, 20);
            lblPrecio.TabIndex = 3;
            lblPrecio.Text = "Precio:";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(22, 264);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(76, 20);
            lblCantidad.TabIndex = 4;
            lblCantidad.Text = "Cantidad: ";
            // 
            // lblImage
            // 
            lblImage.AutoSize = true;
            lblImage.Location = new Point(322, 113);
            lblImage.Name = "lblImage";
            lblImage.Size = new Size(58, 20);
            lblImage.TabIndex = 5;
            lblImage.Text = "Image: ";
            // 
            // txtFolio
            // 
            txtFolio.Location = new Point(100, 117);
            txtFolio.Margin = new Padding(3, 4, 3, 4);
            txtFolio.Name = "txtFolio";
            txtFolio.Size = new Size(221, 27);
            txtFolio.TabIndex = 6;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(100, 170);
            txtNombre.Margin = new Padding(3, 4, 3, 4);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(221, 27);
            txtNombre.TabIndex = 7;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(101, 216);
            txtPrecio.Margin = new Padding(3, 4, 3, 4);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(221, 27);
            txtPrecio.TabIndex = 8;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(101, 267);
            txtCantidad.Margin = new Padding(3, 4, 3, 4);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(221, 27);
            txtCantidad.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.HotTrack;
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(txtBusqueda);
            panel2.Controls.Add(lblBusqueda);
            panel2.Location = new Point(0, 335);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(961, 71);
            panel2.TabIndex = 0;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(494, 20);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(55, 32);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(139, 25);
            txtBusqueda.Margin = new Padding(3, 4, 3, 4);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(337, 27);
            txtBusqueda.TabIndex = 1;
            txtBusqueda.TextChanged += txtBusqueda_TextChanged_1;
            // 
            // lblBusqueda
            // 
            lblBusqueda.AutoSize = true;
            lblBusqueda.BackColor = SystemColors.HotTrack;
            lblBusqueda.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBusqueda.ForeColor = SystemColors.ButtonFace;
            lblBusqueda.Location = new Point(32, 24);
            lblBusqueda.Name = "lblBusqueda";
            lblBusqueda.Size = new Size(101, 25);
            lblBusqueda.TabIndex = 0;
            lblBusqueda.Text = "Búsqueda:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(14, 10);
            label7.Name = "label7";
            label7.Size = new Size(38, 15);
            label7.TabIndex = 0;
            label7.Text = "label7";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(383, 113);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(276, 189);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { ID, Nombre, Precio, Cantidad, colImagen });
            dgvProductos.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvProductos.Location = new Point(0, 427);
            dgvProductos.Margin = new Padding(3, 4, 3, 4);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.RowTemplate.Height = 80;
            dgvProductos.Size = new Size(702, 300);
            dgvProductos.TabIndex = 11;
            dgvProductos.CellClick += dgvProductos_CellContentClick;
            dgvProductos.CellContentClick += dgvProductos_CellContentClick;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.Width = 125;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.MinimumWidth = 6;
            Nombre.Name = "Nombre";
            Nombre.Width = 125;
            // 
            // Precio
            // 
            Precio.HeaderText = "Precio";
            Precio.MinimumWidth = 6;
            Precio.Name = "Precio";
            Precio.Width = 125;
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cantidad";
            Cantidad.MinimumWidth = 6;
            Cantidad.Name = "Cantidad";
            Cantidad.Width = 125;
            // 
            // colImagen
            // 
            colImagen.HeaderText = "Image";
            colImagen.ImageLayout = DataGridViewImageCellLayout.Zoom;
            colImagen.MinimumWidth = 6;
            colImagen.Name = "colImagen";
            colImagen.Width = 125;
            // 
            // btnGuardar
            // 
            btnGuardar.ImageAlign = ContentAlignment.MiddleRight;
            btnGuardar.ImageKey = "agregar.png";
            btnGuardar.ImageList = imageList1;
            btnGuardar.Location = new Point(22, 756);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(101, 44);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.TextAlign = ContentAlignment.MiddleLeft;
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "diskette.png");
            imageList1.Images.SetKeyName(1, "pen.png");
            imageList1.Images.SetKeyName(2, "delete.png");
            imageList1.Images.SetKeyName(3, "clean.png");
            imageList1.Images.SetKeyName(4, "shopping-cart.png");
            imageList1.Images.SetKeyName(5, "tienda.png");
            imageList1.Images.SetKeyName(6, "limpiar.png");
            imageList1.Images.SetKeyName(7, "lapiz-3d.png");
            imageList1.Images.SetKeyName(8, "foto.png");
            imageList1.Images.SetKeyName(9, "cerrar-sesion.png");
            imageList1.Images.SetKeyName(10, "buscar.png");
            imageList1.Images.SetKeyName(11, "borrar.png");
            imageList1.Images.SetKeyName(12, "agregar.png");
            // 
            // btnModificar
            // 
            btnModificar.ImageAlign = ContentAlignment.MiddleRight;
            btnModificar.ImageKey = "lapiz-3d.png";
            btnModificar.ImageList = imageList1;
            btnModificar.Location = new Point(153, 756);
            btnModificar.Margin = new Padding(3, 4, 3, 4);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(116, 44);
            btnModificar.TabIndex = 13;
            btnModificar.Text = "Modificar";
            btnModificar.TextAlign = ContentAlignment.MiddleLeft;
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.ImageAlign = ContentAlignment.MiddleRight;
            btnEliminar.ImageKey = "borrar.png";
            btnEliminar.ImageList = imageList1;
            btnEliminar.Location = new Point(301, 756);
            btnEliminar.Margin = new Padding(3, 4, 3, 4);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(99, 44);
            btnEliminar.TabIndex = 14;
            btnEliminar.Text = "Eliminar";
            btnEliminar.TextAlign = ContentAlignment.MiddleLeft;
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.ImageAlign = ContentAlignment.MiddleRight;
            btnLimpiar.ImageKey = "limpiar.png";
            btnLimpiar.ImageList = imageList1;
            btnLimpiar.Location = new Point(439, 756);
            btnLimpiar.Margin = new Padding(3, 4, 3, 4);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(93, 46);
            btnLimpiar.TabIndex = 15;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.TextAlign = ContentAlignment.MiddleLeft;
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnSalir
            // 
            btnSalir.ImageAlign = ContentAlignment.MiddleRight;
            btnSalir.ImageKey = "cerrar-sesion.png";
            btnSalir.ImageList = imageList1;
            btnSalir.Location = new Point(569, 754);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 46);
            btnSalir.TabIndex = 16;
            btnSalir.Text = "Salir";
            btnSalir.TextAlign = ContentAlignment.MiddleLeft;
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(676, 833);
            Controls.Add(btnSalir);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnGuardar);
            Controls.Add(dgvProductos);
            Controls.Add(pictureBox1);
            Controls.Add(panel2);
            Controls.Add(txtCantidad);
            Controls.Add(txtPrecio);
            Controls.Add(txtNombre);
            Controls.Add(txtFolio);
            Controls.Add(lblImage);
            Controls.Add(lblCantidad);
            Controls.Add(lblPrecio);
            Controls.Add(lblNombre);
            Controls.Add(lblFolio);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "   ";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label lblTitulo;
        private Label lblFolio;
        private Label lblNombre;
        private Label lblPrecio;
        private Label lblCantidad;
        private Label lblImage;
        private TextBox txtFolio;
        private TextBox txtNombre;
        private TextBox txtPrecio;
        private TextBox txtCantidad;
        private Panel panel2;
        private Label label7;
        private PictureBox pictureBox1;
        private DataGridView dgvProductos;
        private Button btnGuardar;
        private Button btnModificar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private PictureBox pictureBox2;
        private TextBox txtBusqueda;
        private Label lblBusqueda;
        private ImageList imageList1;
        private PictureBox pictureBox3;
        private DataGridViewImageColumn Column1;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Precio;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewImageColumn colImage;
        private DataGridViewImageColumn colImagen;
        private Button btnSalir;
    }   
}
