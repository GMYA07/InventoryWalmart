namespace InventoryWalmart.views.Cajero
{
    partial class viewRegistrarVentaCajero
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(viewRegistrarVentaCajero));
            this.barAcciones = new System.Windows.Forms.Panel();
            this.btnOcultar = new System.Windows.Forms.PictureBox();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.btnRestaurar = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.logo = new System.Windows.Forms.PictureBox();
            this.labelVenta = new System.Windows.Forms.Label();
            this.tablaVenta = new System.Windows.Forms.DataGridView();
            this.colIdProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrecio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFinalizarVenta = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.labelMostrarTotal = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMostrarBeneficios = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.btnAplicarBeneficios = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.btnAplicarCodDesc = new System.Windows.Forms.Button();
            this.inputCodigoDescuento = new System.Windows.Forms.TextBox();
            this.inputTargetaCliente = new System.Windows.Forms.TextBox();
            this.tablaBeneficiosAplicables = new System.Windows.Forms.DataGridView();
            this.colNameBenefit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPtsReq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPorcenDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.checkTieneTargeta = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.selectMetodoPago = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.inputCantidadProducto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.inputCodigoProducto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnQuitarProductoLista = new System.Windows.Forms.Button();
            this.inputCantidadRetirar = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnLimpiarTodaLista = new System.Windows.Forms.Button();
            this.labelTextDescApli = new System.Windows.Forms.Label();
            this.labelDescuentoApli = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.labelMostrarSubtotalCompra = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.labelDescuentoDinero = new System.Windows.Forms.Label();
            this.inputDui = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.barAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOcultar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaVenta)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaBeneficiosAplicables)).BeginInit();
            this.SuspendLayout();
            // 
            // barAcciones
            // 
            this.barAcciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(223)))));
            this.barAcciones.Controls.Add(this.btnOcultar);
            this.barAcciones.Controls.Add(this.btnMaximizar);
            this.barAcciones.Controls.Add(this.btnCerrar);
            this.barAcciones.Controls.Add(this.btnRestaurar);
            this.barAcciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.barAcciones.Location = new System.Drawing.Point(0, 0);
            this.barAcciones.Name = "barAcciones";
            this.barAcciones.Size = new System.Drawing.Size(1533, 59);
            this.barAcciones.TabIndex = 3;
            this.barAcciones.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barAcciones_MouseDown);
            // 
            // btnOcultar
            // 
            this.btnOcultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOcultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOcultar.Image = global::InventoryWalmart.Properties.Resources.ocultar;
            this.btnOcultar.Location = new System.Drawing.Point(1391, 12);
            this.btnOcultar.Name = "btnOcultar";
            this.btnOcultar.Size = new System.Drawing.Size(30, 30);
            this.btnOcultar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnOcultar.TabIndex = 4;
            this.btnOcultar.TabStop = false;
            this.btnOcultar.Click += new System.EventHandler(this.btnOcultar_Click);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximizar.Image")));
            this.btnMaximizar.Location = new System.Drawing.Point(1444, 12);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(30, 30);
            this.btnMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMaximizar.TabIndex = 3;
            this.btnMaximizar.TabStop = false;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(1489, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(32, 32);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.TabStop = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestaurar.Image = ((System.Drawing.Image)(resources.GetObject("btnRestaurar.Image")));
            this.btnRestaurar.Location = new System.Drawing.Point(1444, 12);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(30, 30);
            this.btnRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRestaurar.TabIndex = 3;
            this.btnRestaurar.TabStop = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(223)))));
            this.panel1.Controls.Add(this.btnProductos);
            this.panel1.Controls.Add(this.btnInicio);
            this.panel1.Controls.Add(this.logo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(213, 661);
            this.panel1.TabIndex = 4;
            // 
            // btnProductos
            // 
            this.btnProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(223)))));
            this.btnProductos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.ForeColor = System.Drawing.Color.White;
            this.btnProductos.Image = global::InventoryWalmart.Properties.Resources.ProductosIcon;
            this.btnProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.Location = new System.Drawing.Point(0, 168);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Padding = new System.Windows.Forms.Padding(0, 0, 75, 0);
            this.btnProductos.Size = new System.Drawing.Size(213, 40);
            this.btnProductos.TabIndex = 3;
            this.btnProductos.Text = "Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProductos.UseVisualStyleBackColor = false;
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(114)))), ((int)(((byte)(223)))));
            this.btnInicio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInicio.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInicio.ForeColor = System.Drawing.Color.White;
            this.btnInicio.Image = global::InventoryWalmart.Properties.Resources.DashboardIcon;
            this.btnInicio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.Location = new System.Drawing.Point(0, 128);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Padding = new System.Windows.Forms.Padding(0, 0, 120, 0);
            this.btnInicio.Size = new System.Drawing.Size(213, 40);
            this.btnInicio.TabIndex = 1;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInicio.UseVisualStyleBackColor = false;
            // 
            // logo
            // 
            this.logo.Dock = System.Windows.Forms.DockStyle.Top;
            this.logo.Image = global::InventoryWalmart.Properties.Resources.logo;
            this.logo.Location = new System.Drawing.Point(0, 0);
            this.logo.Name = "logo";
            this.logo.Padding = new System.Windows.Forms.Padding(10);
            this.logo.Size = new System.Drawing.Size(213, 128);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 0;
            this.logo.TabStop = false;
            // 
            // labelVenta
            // 
            this.labelVenta.AutoSize = true;
            this.labelVenta.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVenta.Location = new System.Drawing.Point(243, 88);
            this.labelVenta.Name = "labelVenta";
            this.labelVenta.Size = new System.Drawing.Size(273, 47);
            this.labelVenta.TabIndex = 19;
            this.labelVenta.Text = "Registrar Venta";
            // 
            // tablaVenta
            // 
            this.tablaVenta.AllowUserToAddRows = false;
            this.tablaVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaVenta.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdProducto,
            this.colProducto,
            this.colCantidad,
            this.colPrecio,
            this.colSubtotal});
            this.tablaVenta.Location = new System.Drawing.Point(951, 170);
            this.tablaVenta.Name = "tablaVenta";
            this.tablaVenta.Size = new System.Drawing.Size(548, 354);
            this.tablaVenta.TabIndex = 20;
            this.tablaVenta.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaVenta_CellContentClick);
            // 
            // colIdProducto
            // 
            this.colIdProducto.HeaderText = "Id";
            this.colIdProducto.Name = "colIdProducto";
            // 
            // colProducto
            // 
            this.colProducto.HeaderText = "Producto";
            this.colProducto.Name = "colProducto";
            // 
            // colCantidad
            // 
            this.colCantidad.HeaderText = "Cantidad";
            this.colCantidad.Name = "colCantidad";
            // 
            // colPrecio
            // 
            this.colPrecio.HeaderText = "Precio";
            this.colPrecio.Name = "colPrecio";
            // 
            // colSubtotal
            // 
            this.colSubtotal.HeaderText = "Subtotal";
            this.colSubtotal.Name = "colSubtotal";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1204, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 40);
            this.label1.TabIndex = 21;
            this.label1.Text = "Venta";
            // 
            // btnFinalizarVenta
            // 
            this.btnFinalizarVenta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(223)))));
            this.btnFinalizarVenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFinalizarVenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinalizarVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizarVenta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizarVenta.ForeColor = System.Drawing.Color.White;
            this.btnFinalizarVenta.Location = new System.Drawing.Point(1227, 656);
            this.btnFinalizarVenta.Name = "btnFinalizarVenta";
            this.btnFinalizarVenta.Size = new System.Drawing.Size(272, 39);
            this.btnFinalizarVenta.TabIndex = 22;
            this.btnFinalizarVenta.Text = "Finalizar Venta ->";
            this.btnFinalizarVenta.UseVisualStyleBackColor = false;
            this.btnFinalizarVenta.Click += new System.EventHandler(this.btnFinalizarVenta_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(1223, 626);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "Total de compra: ";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // labelMostrarTotal
            // 
            this.labelMostrarTotal.AutoSize = true;
            this.labelMostrarTotal.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMostrarTotal.Location = new System.Drawing.Point(1373, 626);
            this.labelMostrarTotal.Name = "labelMostrarTotal";
            this.labelMostrarTotal.Size = new System.Drawing.Size(18, 20);
            this.labelMostrarTotal.TabIndex = 25;
            this.labelMostrarTotal.Text = "0";
            this.labelMostrarTotal.Click += new System.EventHandler(this.labelMostrarTotal_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.inputDui);
            this.groupBox1.Controls.Add(this.btnMostrarBeneficios);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.btnAplicarBeneficios);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.btnAplicarCodDesc);
            this.groupBox1.Controls.Add(this.inputCodigoDescuento);
            this.groupBox1.Controls.Add(this.inputTargetaCliente);
            this.groupBox1.Controls.Add(this.tablaBeneficiosAplicables);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.checkTieneTargeta);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.selectMetodoPago);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnAgregar);
            this.groupBox1.Controls.Add(this.inputCantidadProducto);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.inputCodigoProducto);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(234, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(688, 550);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnMostrarBeneficios
            // 
            this.btnMostrarBeneficios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(223)))));
            this.btnMostrarBeneficios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnMostrarBeneficios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMostrarBeneficios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMostrarBeneficios.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMostrarBeneficios.ForeColor = System.Drawing.Color.White;
            this.btnMostrarBeneficios.Location = new System.Drawing.Point(16, 416);
            this.btnMostrarBeneficios.Name = "btnMostrarBeneficios";
            this.btnMostrarBeneficios.Size = new System.Drawing.Size(121, 39);
            this.btnMostrarBeneficios.TabIndex = 65;
            this.btnMostrarBeneficios.Text = "Mostrar Beneficios Targeta\r\n\r\n";
            this.btnMostrarBeneficios.UseVisualStyleBackColor = false;
            this.btnMostrarBeneficios.Click += new System.EventHandler(this.btnMostrarBeneficios_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Red;
            this.label19.Location = new System.Drawing.Point(13, 471);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(199, 15);
            this.label19.TabIndex = 63;
            this.label19.Text = "Descuento de compra (Beneficio): ";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(141, 513);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(13, 13);
            this.label15.TabIndex = 64;
            this.label15.Text = "0";
            this.label15.Visible = false;
            // 
            // btnAplicarBeneficios
            // 
            this.btnAplicarBeneficios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(223)))));
            this.btnAplicarBeneficios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAplicarBeneficios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAplicarBeneficios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicarBeneficios.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicarBeneficios.ForeColor = System.Drawing.Color.White;
            this.btnAplicarBeneficios.Location = new System.Drawing.Point(144, 416);
            this.btnAplicarBeneficios.Name = "btnAplicarBeneficios";
            this.btnAplicarBeneficios.Size = new System.Drawing.Size(138, 39);
            this.btnAplicarBeneficios.TabIndex = 52;
            this.btnAplicarBeneficios.Text = "Aplicar Beneficios de \r\nTargeta";
            this.btnAplicarBeneficios.UseVisualStyleBackColor = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(15, 497);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(145, 26);
            this.label18.TabIndex = 63;
            this.label18.Text = "Se ha aplicado el beneficio\r\ncon un descuento del:";
            this.label18.Visible = false;
            // 
            // btnAplicarCodDesc
            // 
            this.btnAplicarCodDesc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(223)))));
            this.btnAplicarCodDesc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAplicarCodDesc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAplicarCodDesc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAplicarCodDesc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAplicarCodDesc.ForeColor = System.Drawing.Color.White;
            this.btnAplicarCodDesc.Location = new System.Drawing.Point(511, 200);
            this.btnAplicarCodDesc.Name = "btnAplicarCodDesc";
            this.btnAplicarCodDesc.Size = new System.Drawing.Size(132, 43);
            this.btnAplicarCodDesc.TabIndex = 50;
            this.btnAplicarCodDesc.Text = "Aplicar Codigo de Descuento";
            this.btnAplicarCodDesc.UseVisualStyleBackColor = false;
            this.btnAplicarCodDesc.Click += new System.EventHandler(this.btnAplicarCodDesc_Click);
            // 
            // inputCodigoDescuento
            // 
            this.inputCodigoDescuento.Location = new System.Drawing.Point(327, 212);
            this.inputCodigoDescuento.Name = "inputCodigoDescuento";
            this.inputCodigoDescuento.Size = new System.Drawing.Size(168, 20);
            this.inputCodigoDescuento.TabIndex = 49;
            // 
            // inputTargetaCliente
            // 
            this.inputTargetaCliente.Enabled = false;
            this.inputTargetaCliente.Location = new System.Drawing.Point(16, 318);
            this.inputTargetaCliente.Name = "inputTargetaCliente";
            this.inputTargetaCliente.Size = new System.Drawing.Size(222, 20);
            this.inputTargetaCliente.TabIndex = 48;
            // 
            // tablaBeneficiosAplicables
            // 
            this.tablaBeneficiosAplicables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaBeneficiosAplicables.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNameBenefit,
            this.colPtsReq,
            this.colPorcenDescuento});
            this.tablaBeneficiosAplicables.Location = new System.Drawing.Point(339, 301);
            this.tablaBeneficiosAplicables.Name = "tablaBeneficiosAplicables";
            this.tablaBeneficiosAplicables.Size = new System.Drawing.Size(343, 243);
            this.tablaBeneficiosAplicables.TabIndex = 47;
            // 
            // colNameBenefit
            // 
            this.colNameBenefit.HeaderText = "Beneficio";
            this.colNameBenefit.Name = "colNameBenefit";
            // 
            // colPtsReq
            // 
            this.colPtsReq.HeaderText = "Puntos Requeridos";
            this.colPtsReq.Name = "colPtsReq";
            // 
            // colPorcenDescuento
            // 
            this.colPorcenDescuento.HeaderText = "Porcentaje de Descuento";
            this.colPorcenDescuento.Name = "colPorcenDescuento";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(323, 176);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(171, 21);
            this.label12.TabIndex = 45;
            this.label12.Text = "codigo de Descuento";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(323, 263);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(172, 21);
            this.label11.TabIndex = 44;
            this.label11.Text = "Beneficios Aplicables\r\n";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(252, 302);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "¿Tiene?";
            // 
            // checkTieneTargeta
            // 
            this.checkTieneTargeta.AutoSize = true;
            this.checkTieneTargeta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkTieneTargeta.Location = new System.Drawing.Point(267, 318);
            this.checkTieneTargeta.Name = "checkTieneTargeta";
            this.checkTieneTargeta.Size = new System.Drawing.Size(15, 14);
            this.checkTieneTargeta.TabIndex = 38;
            this.checkTieneTargeta.UseVisualStyleBackColor = true;
            this.checkTieneTargeta.CheckedChanged += new System.EventHandler(this.checkTieneTargeta_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 21);
            this.label7.TabIndex = 37;
            this.label7.Text = "Targeta Cliente";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 21);
            this.label6.TabIndex = 35;
            this.label6.Text = "Metodo de Pago";
            // 
            // selectMetodoPago
            // 
            this.selectMetodoPago.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectMetodoPago.DisplayMember = "id_payment_method";
            this.selectMetodoPago.FormattingEnabled = true;
            this.selectMetodoPago.Items.AddRange(new object[] {
            "Efectivo",
            "Targeta"});
            this.selectMetodoPago.Location = new System.Drawing.Point(17, 211);
            this.selectMetodoPago.Name = "selectMetodoPago";
            this.selectMetodoPago.Size = new System.Drawing.Size(265, 21);
            this.selectMetodoPago.TabIndex = 34;
            this.selectMetodoPago.ValueMember = "id_payment_method";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(230, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 21);
            this.label5.TabIndex = 33;
            this.label5.Text = "cantidad";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(223)))));
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Location = new System.Drawing.Point(379, 98);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(89, 39);
            this.btnAgregar.TabIndex = 27;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // inputCantidadProducto
            // 
            this.inputCantidadProducto.Location = new System.Drawing.Point(229, 110);
            this.inputCantidadProducto.Name = "inputCantidadProducto";
            this.inputCantidadProducto.Size = new System.Drawing.Size(73, 20);
            this.inputCantidadProducto.TabIndex = 30;
            this.inputCantidadProducto.Text = "0";
            this.inputCantidadProducto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 21);
            this.label4.TabIndex = 29;
            this.label4.Text = "codigo ";
            // 
            // inputCodigoProducto
            // 
            this.inputCodigoProducto.Location = new System.Drawing.Point(17, 110);
            this.inputCodigoProducto.Name = "inputCodigoProducto";
            this.inputCodigoProducto.Size = new System.Drawing.Size(142, 20);
            this.inputCodigoProducto.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 30);
            this.label2.TabIndex = 27;
            this.label2.Text = "Agregar Producto";
            // 
            // btnQuitarProductoLista
            // 
            this.btnQuitarProductoLista.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(223)))));
            this.btnQuitarProductoLista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarProductoLista.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQuitarProductoLista.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitarProductoLista.ForeColor = System.Drawing.Color.White;
            this.btnQuitarProductoLista.Location = new System.Drawing.Point(1182, 536);
            this.btnQuitarProductoLista.Name = "btnQuitarProductoLista";
            this.btnQuitarProductoLista.Size = new System.Drawing.Size(100, 45);
            this.btnQuitarProductoLista.TabIndex = 50;
            this.btnQuitarProductoLista.Text = "Quitar de la lista";
            this.btnQuitarProductoLista.UseVisualStyleBackColor = false;
            this.btnQuitarProductoLista.Click += new System.EventHandler(this.btnQuitarProductoLista_Click);
            // 
            // inputCantidadRetirar
            // 
            this.inputCantidadRetirar.Location = new System.Drawing.Point(1003, 561);
            this.inputCantidadRetirar.Name = "inputCantidadRetirar";
            this.inputCantidadRetirar.Size = new System.Drawing.Size(73, 20);
            this.inputCantidadRetirar.TabIndex = 50;
            this.inputCantidadRetirar.Text = "0";
            this.inputCantidadRetirar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.inputCantidadRetirar.TextChanged += new System.EventHandler(this.inputCantidadRetirar_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1000, 537);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 17);
            this.label9.TabIndex = 50;
            this.label9.Text = "cantidad";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1353, 626);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 20);
            this.label10.TabIndex = 52;
            this.label10.Text = "$";
            // 
            // btnLimpiarTodaLista
            // 
            this.btnLimpiarTodaLista.BackColor = System.Drawing.Color.Red;
            this.btnLimpiarTodaLista.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLimpiarTodaLista.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLimpiarTodaLista.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiarTodaLista.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarTodaLista.Location = new System.Drawing.Point(1357, 537);
            this.btnLimpiarTodaLista.Name = "btnLimpiarTodaLista";
            this.btnLimpiarTodaLista.Size = new System.Drawing.Size(100, 45);
            this.btnLimpiarTodaLista.TabIndex = 54;
            this.btnLimpiarTodaLista.Text = "Limpiar Toda la lista";
            this.btnLimpiarTodaLista.UseVisualStyleBackColor = false;
            this.btnLimpiarTodaLista.Click += new System.EventHandler(this.btnLimpiarTodaLista_Click);
            // 
            // labelTextDescApli
            // 
            this.labelTextDescApli.AutoSize = true;
            this.labelTextDescApli.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextDescApli.ForeColor = System.Drawing.Color.Red;
            this.labelTextDescApli.Location = new System.Drawing.Point(947, 662);
            this.labelTextDescApli.Name = "labelTextDescApli";
            this.labelTextDescApli.Size = new System.Drawing.Size(102, 26);
            this.labelTextDescApli.TabIndex = 55;
            this.labelTextDescApli.Text = "Se ha aplicado un \r\ndescuento del: ";
            this.labelTextDescApli.Visible = false;
            // 
            // labelDescuentoApli
            // 
            this.labelDescuentoApli.AutoSize = true;
            this.labelDescuentoApli.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescuentoApli.Location = new System.Drawing.Point(1048, 675);
            this.labelDescuentoApli.Name = "labelDescuentoApli";
            this.labelDescuentoApli.Size = new System.Drawing.Size(15, 17);
            this.labelDescuentoApli.TabIndex = 56;
            this.labelDescuentoApli.Text = "0";
            this.labelDescuentoApli.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(945, 631);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(116, 13);
            this.label13.TabIndex = 57;
            this.label13.Text = "SubTotal de compra: ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(1063, 631);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(15, 17);
            this.label14.TabIndex = 59;
            this.label14.Text = "$";
            // 
            // labelMostrarSubtotalCompra
            // 
            this.labelMostrarSubtotalCompra.AutoSize = true;
            this.labelMostrarSubtotalCompra.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMostrarSubtotalCompra.Location = new System.Drawing.Point(1082, 631);
            this.labelMostrarSubtotalCompra.Name = "labelMostrarSubtotalCompra";
            this.labelMostrarSubtotalCompra.Size = new System.Drawing.Size(15, 17);
            this.labelMostrarSubtotalCompra.TabIndex = 58;
            this.labelMostrarSubtotalCompra.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(945, 604);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(173, 13);
            this.label16.TabIndex = 60;
            this.label16.Text = "Descuento de compra (codigo): ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(1120, 604);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(15, 17);
            this.label17.TabIndex = 61;
            this.label17.Text = "$";
            // 
            // labelDescuentoDinero
            // 
            this.labelDescuentoDinero.AutoSize = true;
            this.labelDescuentoDinero.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescuentoDinero.Location = new System.Drawing.Point(1139, 604);
            this.labelDescuentoDinero.Name = "labelDescuentoDinero";
            this.labelDescuentoDinero.Size = new System.Drawing.Size(15, 17);
            this.labelDescuentoDinero.TabIndex = 62;
            this.labelDescuentoDinero.Text = "0";
            // 
            // inputDui
            // 
            this.inputDui.Enabled = false;
            this.inputDui.Location = new System.Drawing.Point(17, 376);
            this.inputDui.Name = "inputDui";
            this.inputDui.Size = new System.Drawing.Size(222, 20);
            this.inputDui.TabIndex = 66;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(14, 352);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(37, 21);
            this.label20.TabIndex = 67;
            this.label20.Text = "Dui";
            // 
            // viewRegistrarVentaCajero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1533, 720);
            this.Controls.Add(this.labelDescuentoDinero);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.labelMostrarSubtotalCompra);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.labelDescuentoApli);
            this.Controls.Add(this.labelTextDescApli);
            this.Controls.Add(this.btnLimpiarTodaLista);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.labelMostrarTotal);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.inputCantidadRetirar);
            this.Controls.Add(this.btnQuitarProductoLista);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnFinalizarVenta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tablaVenta);
            this.Controls.Add(this.labelVenta);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barAcciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "viewRegistrarVentaCajero";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "viewRegistrarVentaCajero";
            this.Load += new System.EventHandler(this.viewRegistrarVentaCajero_Load);
            this.barAcciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnOcultar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablaVenta)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablaBeneficiosAplicables)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel barAcciones;
        private System.Windows.Forms.PictureBox btnOcultar;
        private System.Windows.Forms.PictureBox btnMaximizar;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.PictureBox btnRestaurar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Label labelVenta;
        private System.Windows.Forms.DataGridView tablaVenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFinalizarVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrecio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubtotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelMostrarTotal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox inputCodigoProducto;
        private System.Windows.Forms.TextBox inputCantidadProducto;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox selectMetodoPago;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkTieneTargeta;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView tablaBeneficiosAplicables;
        private System.Windows.Forms.TextBox inputTargetaCliente;
        private System.Windows.Forms.TextBox inputCodigoDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNameBenefit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPtsReq;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPorcenDescuento;
        private System.Windows.Forms.Button btnQuitarProductoLista;
        private System.Windows.Forms.TextBox inputCantidadRetirar;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnLimpiarTodaLista;
        private System.Windows.Forms.Button btnAplicarCodDesc;
        private System.Windows.Forms.Label labelTextDescApli;
        private System.Windows.Forms.Label labelDescuentoApli;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labelMostrarSubtotalCompra;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label labelDescuentoDinero;
        private System.Windows.Forms.Button btnAplicarBeneficios;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button btnMostrarBeneficios;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox inputDui;
    }
}