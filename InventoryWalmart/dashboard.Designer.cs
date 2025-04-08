namespace InventoryWalmart
{
    partial class dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dashboard));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.barAcciones = new System.Windows.Forms.Panel();
            this.btnOcultar = new System.Windows.Forms.PictureBox();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.btnRestaurar = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnPuntos = new System.Windows.Forms.Button();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnEmpleado = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnDevoluciones = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnPromociones = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.logo = new System.Windows.Forms.PictureBox();
            this.inputFecha = new System.Windows.Forms.DateTimePicker();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tittleDashboard = new System.Windows.Forms.Label();
            this.panelTotalMoney = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panelDescuentos = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelBeneficiosReco = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.barAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOcultar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panelTotalMoney.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panelDescuentos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelBeneficiosReco.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
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
            this.barAcciones.Size = new System.Drawing.Size(1280, 59);
            this.barAcciones.TabIndex = 2;
            this.barAcciones.Paint += new System.Windows.Forms.PaintEventHandler(this.barAcciones_Paint);
            this.barAcciones.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barAcciones_MouseDown);
            // 
            // btnOcultar
            // 
            this.btnOcultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOcultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOcultar.Image = global::InventoryWalmart.Properties.Resources.ocultar;
            this.btnOcultar.Location = new System.Drawing.Point(1138, 12);
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
            this.btnMaximizar.Location = new System.Drawing.Point(1191, 12);
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
            this.btnCerrar.Location = new System.Drawing.Point(1236, 12);
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
            this.btnRestaurar.Location = new System.Drawing.Point(1191, 12);
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
            this.panel1.Controls.Add(this.BtnPuntos);
            this.panel1.Controls.Add(this.btnClientes);
            this.panel1.Controls.Add(this.btnEmpleado);
            this.panel1.Controls.Add(this.btnReportes);
            this.panel1.Controls.Add(this.btnDevoluciones);
            this.panel1.Controls.Add(this.btnProductos);
            this.panel1.Controls.Add(this.btnPromociones);
            this.panel1.Controls.Add(this.btnInicio);
            this.panel1.Controls.Add(this.logo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 661);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // BtnPuntos
            // 
            this.BtnPuntos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(223)))));
            this.BtnPuntos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnPuntos.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnPuntos.FlatAppearance.BorderSize = 0;
            this.BtnPuntos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPuntos.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPuntos.ForeColor = System.Drawing.Color.White;
            this.BtnPuntos.Image = global::InventoryWalmart.Properties.Resources.PointsIcon;
            this.BtnPuntos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnPuntos.Location = new System.Drawing.Point(0, 408);
            this.BtnPuntos.Name = "BtnPuntos";
            this.BtnPuntos.Padding = new System.Windows.Forms.Padding(0, 0, 100, 0);
            this.BtnPuntos.Size = new System.Drawing.Size(250, 40);
            this.BtnPuntos.TabIndex = 10;
            this.BtnPuntos.Text = "Puntos";
            this.BtnPuntos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnPuntos.UseVisualStyleBackColor = false;
            this.BtnPuntos.Click += new System.EventHandler(this.BtnPuntos_Click);
            // 
            // btnClientes
            // 
            this.btnClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(223)))));
            this.btnClientes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClientes.FlatAppearance.BorderSize = 0;
            this.btnClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClientes.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClientes.ForeColor = System.Drawing.Color.White;
            this.btnClientes.Image = global::InventoryWalmart.Properties.Resources.UsuariosIcon;
            this.btnClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClientes.Location = new System.Drawing.Point(0, 368);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Padding = new System.Windows.Forms.Padding(0, 0, 100, 0);
            this.btnClientes.Size = new System.Drawing.Size(250, 40);
            this.btnClientes.TabIndex = 7;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClientes.UseVisualStyleBackColor = false;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnEmpleado
            // 
            this.btnEmpleado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(223)))));
            this.btnEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmpleado.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEmpleado.FlatAppearance.BorderSize = 0;
            this.btnEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpleado.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmpleado.ForeColor = System.Drawing.Color.White;
            this.btnEmpleado.Image = global::InventoryWalmart.Properties.Resources.EmpleadosIcon;
            this.btnEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEmpleado.Location = new System.Drawing.Point(0, 328);
            this.btnEmpleado.Name = "btnEmpleado";
            this.btnEmpleado.Padding = new System.Windows.Forms.Padding(0, 0, 80, 0);
            this.btnEmpleado.Size = new System.Drawing.Size(250, 40);
            this.btnEmpleado.TabIndex = 6;
            this.btnEmpleado.Text = "Empleado";
            this.btnEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEmpleado.UseVisualStyleBackColor = false;
            this.btnEmpleado.Click += new System.EventHandler(this.btnEmpleado_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(223)))));
            this.btnReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReportes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportes.ForeColor = System.Drawing.Color.White;
            this.btnReportes.Image = global::InventoryWalmart.Properties.Resources.ReportesIcon;
            this.btnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.Location = new System.Drawing.Point(0, 288);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Padding = new System.Windows.Forms.Padding(0, 0, 90, 0);
            this.btnReportes.Size = new System.Drawing.Size(250, 40);
            this.btnReportes.TabIndex = 5;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReportes.UseVisualStyleBackColor = false;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnDevoluciones
            // 
            this.btnDevoluciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(223)))));
            this.btnDevoluciones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDevoluciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDevoluciones.FlatAppearance.BorderSize = 0;
            this.btnDevoluciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDevoluciones.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDevoluciones.ForeColor = System.Drawing.Color.White;
            this.btnDevoluciones.Image = global::InventoryWalmart.Properties.Resources.RenvolsosIcon;
            this.btnDevoluciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDevoluciones.Location = new System.Drawing.Point(0, 248);
            this.btnDevoluciones.Name = "btnDevoluciones";
            this.btnDevoluciones.Padding = new System.Windows.Forms.Padding(0, 0, 50, 0);
            this.btnDevoluciones.Size = new System.Drawing.Size(250, 40);
            this.btnDevoluciones.TabIndex = 4;
            this.btnDevoluciones.Text = "Devoluciones";
            this.btnDevoluciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDevoluciones.UseVisualStyleBackColor = false;
            this.btnDevoluciones.Click += new System.EventHandler(this.btnDevoluciones_Click);
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
            this.btnProductos.Location = new System.Drawing.Point(0, 208);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Padding = new System.Windows.Forms.Padding(0, 0, 75, 0);
            this.btnProductos.Size = new System.Drawing.Size(250, 40);
            this.btnProductos.TabIndex = 3;
            this.btnProductos.Text = "Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProductos.UseVisualStyleBackColor = false;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnPromociones
            // 
            this.btnPromociones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(223)))));
            this.btnPromociones.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPromociones.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPromociones.FlatAppearance.BorderSize = 0;
            this.btnPromociones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPromociones.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPromociones.ForeColor = System.Drawing.Color.White;
            this.btnPromociones.Image = ((System.Drawing.Image)(resources.GetObject("btnPromociones.Image")));
            this.btnPromociones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPromociones.Location = new System.Drawing.Point(0, 168);
            this.btnPromociones.Name = "btnPromociones";
            this.btnPromociones.Padding = new System.Windows.Forms.Padding(0, 0, 80, 0);
            this.btnPromociones.Size = new System.Drawing.Size(250, 40);
            this.btnPromociones.TabIndex = 2;
            this.btnPromociones.Text = "Beneficios";
            this.btnPromociones.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPromociones.UseVisualStyleBackColor = false;
            this.btnPromociones.Click += new System.EventHandler(this.btnPromociones_Click);
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
            this.btnInicio.Size = new System.Drawing.Size(250, 40);
            this.btnInicio.TabIndex = 1;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // logo
            // 
            this.logo.Dock = System.Windows.Forms.DockStyle.Top;
            this.logo.Image = global::InventoryWalmart.Properties.Resources.logo;
            this.logo.Location = new System.Drawing.Point(0, 0);
            this.logo.Name = "logo";
            this.logo.Padding = new System.Windows.Forms.Padding(10);
            this.logo.Size = new System.Drawing.Size(250, 128);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 0;
            this.logo.TabStop = false;
            // 
            // inputFecha
            // 
            this.inputFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputFecha.Location = new System.Drawing.Point(567, 92);
            this.inputFecha.Name = "inputFecha";
            this.inputFecha.Size = new System.Drawing.Size(446, 20);
            this.inputFecha.TabIndex = 4;
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Cursor = System.Windows.Forms.Cursors.Hand;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(300, 365);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(475, 299);
            this.chart1.TabIndex = 6;
            this.chart1.Text = "chart1";
            // 
            // tittleDashboard
            // 
            this.tittleDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tittleDashboard.AutoSize = true;
            this.tittleDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tittleDashboard.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tittleDashboard.Location = new System.Drawing.Point(974, 307);
            this.tittleDashboard.Name = "tittleDashboard";
            this.tittleDashboard.Size = new System.Drawing.Size(108, 45);
            this.tittleDashboard.TabIndex = 7;
            this.tittleDashboard.Text = "Titulo";
            // 
            // panelTotalMoney
            // 
            this.panelTotalMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTotalMoney.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(223)))));
            this.panelTotalMoney.Controls.Add(this.label1);
            this.panelTotalMoney.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelTotalMoney.Location = new System.Drawing.Point(841, 360);
            this.panelTotalMoney.Name = "panelTotalMoney";
            this.panelTotalMoney.Size = new System.Drawing.Size(172, 131);
            this.panelTotalMoney.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dinero Total";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(194)))), ((int)(((byte)(33)))));
            this.panel4.Controls.Add(this.label2);
            this.panel4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel4.Location = new System.Drawing.Point(1058, 360);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(186, 131);
            this.panel4.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dinero Ganado";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(194)))), ((int)(((byte)(33)))));
            this.panel5.Controls.Add(this.label3);
            this.panel5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel5.Location = new System.Drawing.Point(841, 516);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(172, 132);
            this.panel5.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(13, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ventas Del Dia";
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(223)))));
            this.panel6.Controls.Add(this.label4);
            this.panel6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel6.Location = new System.Drawing.Point(1058, 516);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(186, 132);
            this.panel6.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(34, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 50);
            this.label4.TabIndex = 3;
            this.label4.Text = "Trabajadores\n Activos";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel10
            // 
            this.panel10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(66)))));
            this.panel10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel10.Location = new System.Drawing.Point(982, 158);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(146, 131);
            this.panel10.TabIndex = 12;
            // 
            // panelDescuentos
            // 
            this.panelDescuentos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDescuentos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(66)))));
            this.panelDescuentos.Controls.Add(this.label5);
            this.panelDescuentos.Controls.Add(this.pictureBox3);
            this.panelDescuentos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelDescuentos.Location = new System.Drawing.Point(556, 158);
            this.panelDescuentos.Name = "panelDescuentos";
            this.panelDescuentos.Size = new System.Drawing.Size(169, 131);
            this.panelDescuentos.TabIndex = 12;
            this.panelDescuentos.Click += new System.EventHandler(this.panelDescuentos_Click);
            this.panelDescuentos.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDescuentos_Paint);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(16, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 30);
            this.label5.TabIndex = 14;
            this.label5.Text = "Descuentos";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(107, 59);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(50, 50);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(66)))));
            this.panel9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel9.Location = new System.Drawing.Point(774, 158);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(161, 131);
            this.panel9.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::InventoryWalmart.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(1191, 77);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(58, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // panelBeneficiosReco
            // 
            this.panelBeneficiosReco.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBeneficiosReco.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(32)))), ((int)(((byte)(66)))));
            this.panelBeneficiosReco.Controls.Add(this.label6);
            this.panelBeneficiosReco.Controls.Add(this.pictureBox2);
            this.panelBeneficiosReco.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelBeneficiosReco.Location = new System.Drawing.Point(338, 158);
            this.panelBeneficiosReco.Name = "panelBeneficiosReco";
            this.panelBeneficiosReco.Size = new System.Drawing.Size(166, 131);
            this.panelBeneficiosReco.TabIndex = 14;
            this.panelBeneficiosReco.Click += new System.EventHandler(this.panelBeneficiosReco_Click);
            this.panelBeneficiosReco.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBeneficiosReco_Paint);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 42);
            this.label6.TabIndex = 15;
            this.label6.Text = "Beneficios \r\ny Recompensas";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::InventoryWalmart.Properties.Resources.caja;
            this.pictureBox2.Location = new System.Drawing.Point(98, 59);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(50, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.panelBeneficiosReco);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.panelDescuentos);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panelTotalMoney);
            this.Controls.Add(this.tittleDashboard);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.inputFecha);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barAcciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "dashboard";
            this.Text = "dashboard";
            this.Load += new System.EventHandler(this.dashboard_Load);
            this.barAcciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnOcultar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panelTotalMoney.ResumeLayout(false);
            this.panelTotalMoney.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panelDescuentos.ResumeLayout(false);
            this.panelDescuentos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelBeneficiosReco.ResumeLayout(false);
            this.panelBeneficiosReco.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnEmpleado;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnDevoluciones;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnPromociones;
        private System.Windows.Forms.DateTimePicker inputFecha;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label tittleDashboard;
        private System.Windows.Forms.Panel panelTotalMoney;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panelDescuentos;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelBeneficiosReco;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button BtnPuntos;
    }
}