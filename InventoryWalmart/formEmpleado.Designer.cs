namespace InventoryWalmart
{
    partial class formEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formEmpleado));
            this.barAcciones = new System.Windows.Forms.Panel();
            this.btnOcultar = new System.Windows.Forms.PictureBox();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.btnRestaurar = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comb_departemeto = new System.Windows.Forms.ComboBox();
            this.comb_distritos = new System.Windows.Forms.ComboBox();
            this.comb_cargo = new System.Windows.Forms.ComboBox();
            this.date_fechaContracion = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.tex_dui = new System.Windows.Forms.TextBox();
            this.tex_telefono = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.DtpNacimiento = new System.Windows.Forms.DateTimePicker();
            this.LblNacimiento = new System.Windows.Forms.Label();
            this.LblEmail = new System.Windows.Forms.Label();
            this.LblDUI = new System.Windows.Forms.Label();
            this.LblTelefono = new System.Windows.Forms.Label();
            this.TxtApellido = new System.Windows.Forms.TextBox();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.LblApellido = new System.Windows.Forms.Label();
            this.LblNombre = new System.Windows.Forms.Label();
            this.tex_user = new System.Windows.Forms.TextBox();
            this.tex_pass = new System.Windows.Forms.TextBox();
            this.btR_status_account_activo = new System.Windows.Forms.RadioButton();
            this.btR_status_account_desactivo = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.barAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOcultar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // barAcciones
            // 
            this.barAcciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(223)))));
            this.barAcciones.Controls.Add(this.btnOcultar);
            this.barAcciones.Controls.Add(this.btnMaximizar);
            this.barAcciones.Controls.Add(this.btnCerrar);
            this.barAcciones.Controls.Add(this.btnRestaurar);
            this.barAcciones.Controls.Add(this.button1);
            this.barAcciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.barAcciones.Location = new System.Drawing.Point(0, 0);
            this.barAcciones.Margin = new System.Windows.Forms.Padding(4);
            this.barAcciones.Name = "barAcciones";
            this.barAcciones.Size = new System.Drawing.Size(579, 73);
            this.barAcciones.TabIndex = 3;
            this.barAcciones.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barAcciones_MouseDown);
            // 
            // btnOcultar
            // 
            this.btnOcultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOcultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOcultar.Image = global::InventoryWalmart.Properties.Resources.ocultar;
            this.btnOcultar.Location = new System.Drawing.Point(389, 15);
            this.btnOcultar.Margin = new System.Windows.Forms.Padding(4);
            this.btnOcultar.Name = "btnOcultar";
            this.btnOcultar.Size = new System.Drawing.Size(40, 37);
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
            this.btnMaximizar.Location = new System.Drawing.Point(460, 15);
            this.btnMaximizar.Margin = new System.Windows.Forms.Padding(4);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(40, 37);
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
            this.btnCerrar.Location = new System.Drawing.Point(520, 15);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(43, 39);
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
            this.btnRestaurar.Location = new System.Drawing.Point(460, 15);
            this.btnRestaurar.Margin = new System.Windows.Forms.Padding(4);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(40, 37);
            this.btnRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRestaurar.TabIndex = 3;
            this.btnRestaurar.TabStop = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(194)))), ((int)(((byte)(33)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Image = global::InventoryWalmart.Properties.Resources.IconoRegresar1;
            this.button1.Location = new System.Drawing.Point(16, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 43);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btR_status_account_desactivo);
            this.panel1.Controls.Add(this.btR_status_account_activo);
            this.panel1.Controls.Add(this.tex_pass);
            this.panel1.Controls.Add(this.tex_user);
            this.panel1.Controls.Add(this.comb_departemeto);
            this.panel1.Controls.Add(this.comb_distritos);
            this.panel1.Controls.Add(this.comb_cargo);
            this.panel1.Controls.Add(this.date_fechaContracion);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tex_dui);
            this.panel1.Controls.Add(this.tex_telefono);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnAgregar);
            this.panel1.Controls.Add(this.btnModificar);
            this.panel1.Controls.Add(this.DtpNacimiento);
            this.panel1.Controls.Add(this.LblNacimiento);
            this.panel1.Controls.Add(this.LblEmail);
            this.panel1.Controls.Add(this.LblDUI);
            this.panel1.Controls.Add(this.LblTelefono);
            this.panel1.Controls.Add(this.TxtApellido);
            this.panel1.Controls.Add(this.TxtNombre);
            this.panel1.Controls.Add(this.LblApellido);
            this.panel1.Controls.Add(this.LblNombre);
            this.panel1.Location = new System.Drawing.Point(45, 102);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(489, 626);
            this.panel1.TabIndex = 12;
            // 
            // comb_departemeto
            // 
            this.comb_departemeto.FormattingEnabled = true;
            this.comb_departemeto.Location = new System.Drawing.Point(48, 428);
            this.comb_departemeto.Margin = new System.Windows.Forms.Padding(4);
            this.comb_departemeto.Name = "comb_departemeto";
            this.comb_departemeto.Size = new System.Drawing.Size(162, 24);
            this.comb_departemeto.TabIndex = 30;
            // 
            // comb_distritos
            // 
            this.comb_distritos.FormattingEnabled = true;
            this.comb_distritos.Location = new System.Drawing.Point(229, 428);
            this.comb_distritos.Margin = new System.Windows.Forms.Padding(4);
            this.comb_distritos.Name = "comb_distritos";
            this.comb_distritos.Size = new System.Drawing.Size(199, 24);
            this.comb_distritos.TabIndex = 29;
            // 
            // comb_cargo
            // 
            this.comb_cargo.FormattingEnabled = true;
            this.comb_cargo.Location = new System.Drawing.Point(52, 505);
            this.comb_cargo.Margin = new System.Windows.Forms.Padding(4);
            this.comb_cargo.Name = "comb_cargo";
            this.comb_cargo.Size = new System.Drawing.Size(170, 24);
            this.comb_cargo.TabIndex = 28;
            // 
            // date_fechaContracion
            // 
            this.date_fechaContracion.Location = new System.Drawing.Point(76, 290);
            this.date_fechaContracion.Margin = new System.Windows.Forms.Padding(4);
            this.date_fechaContracion.Name = "date_fechaContracion";
            this.date_fechaContracion.Size = new System.Drawing.Size(353, 22);
            this.date_fechaContracion.TabIndex = 27;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(71, 256);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 23);
            this.label3.TabIndex = 26;
            this.label3.Text = "Fecha de contratacion";
            // 
            // tex_dui
            // 
            this.tex_dui.Location = new System.Drawing.Point(279, 132);
            this.tex_dui.Margin = new System.Windows.Forms.Padding(4);
            this.tex_dui.Name = "tex_dui";
            this.tex_dui.Size = new System.Drawing.Size(179, 22);
            this.tex_dui.TabIndex = 25;
            this.tex_dui.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tex_telefono
            // 
            this.tex_telefono.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tex_telefono.Location = new System.Drawing.Point(51, 132);
            this.tex_telefono.Margin = new System.Windows.Forms.Padding(4);
            this.tex_telefono.Name = "tex_telefono";
            this.tex_telefono.Size = new System.Drawing.Size(160, 22);
            this.tex_telefono.TabIndex = 23;
            this.tex_telefono.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(273, 105);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 23);
            this.label1.TabIndex = 24;
            this.label1.Text = "DUI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(45, 105);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 23);
            this.label2.TabIndex = 22;
            this.label2.Text = "Telefono";
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(170)))), ((int)(((byte)(28)))));
            this.btnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Image = global::InventoryWalmart.Properties.Resources.iconoAgregar;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(127, 557);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Padding = new System.Windows.Forms.Padding(13, 0, 47, 0);
            this.btnAgregar.Size = new System.Drawing.Size(227, 55);
            this.btnAgregar.TabIndex = 21;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(223)))));
            this.btnModificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.White;
            this.btnModificar.Image = global::InventoryWalmart.Properties.Resources.iconoModificar;
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificar.Location = new System.Drawing.Point(127, 557);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Padding = new System.Windows.Forms.Padding(0, 0, 53, 0);
            this.btnModificar.Size = new System.Drawing.Size(227, 55);
            this.btnModificar.TabIndex = 20;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnModificar.UseVisualStyleBackColor = false;
            // 
            // DtpNacimiento
            // 
            this.DtpNacimiento.Location = new System.Drawing.Point(76, 213);
            this.DtpNacimiento.Margin = new System.Windows.Forms.Padding(4);
            this.DtpNacimiento.Name = "DtpNacimiento";
            this.DtpNacimiento.Size = new System.Drawing.Size(378, 22);
            this.DtpNacimiento.TabIndex = 18;
            // 
            // LblNacimiento
            // 
            this.LblNacimiento.AutoSize = true;
            this.LblNacimiento.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.LblNacimiento.Location = new System.Drawing.Point(71, 178);
            this.LblNacimiento.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblNacimiento.Name = "LblNacimiento";
            this.LblNacimiento.Size = new System.Drawing.Size(169, 23);
            this.LblNacimiento.TabIndex = 17;
            this.LblNacimiento.Text = "Fecha de nacimiento";
            // 
            // LblEmail
            // 
            this.LblEmail.AutoSize = true;
            this.LblEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.LblEmail.Location = new System.Drawing.Point(44, 401);
            this.LblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblEmail.Name = "LblEmail";
            this.LblEmail.Size = new System.Drawing.Size(111, 23);
            this.LblEmail.TabIndex = 15;
            this.LblEmail.Text = "Departameto";
            // 
            // LblDUI
            // 
            this.LblDUI.AutoSize = true;
            this.LblDUI.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.LblDUI.Location = new System.Drawing.Point(263, 401);
            this.LblDUI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblDUI.Name = "LblDUI";
            this.LblDUI.Size = new System.Drawing.Size(65, 23);
            this.LblDUI.TabIndex = 13;
            this.LblDUI.Text = "Distrito";
            // 
            // LblTelefono
            // 
            this.LblTelefono.AutoSize = true;
            this.LblTelefono.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.LblTelefono.Location = new System.Drawing.Point(47, 478);
            this.LblTelefono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblTelefono.Name = "LblTelefono";
            this.LblTelefono.Size = new System.Drawing.Size(85, 23);
            this.LblTelefono.TabIndex = 11;
            this.LblTelefono.Text = "Rol/cargo";
            // 
            // TxtApellido
            // 
            this.TxtApellido.Location = new System.Drawing.Point(279, 55);
            this.TxtApellido.Margin = new System.Windows.Forms.Padding(4);
            this.TxtApellido.Name = "TxtApellido";
            this.TxtApellido.Size = new System.Drawing.Size(179, 22);
            this.TxtApellido.TabIndex = 10;
            this.TxtApellido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(51, 55);
            this.TxtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(160, 22);
            this.TxtNombre.TabIndex = 8;
            this.TxtNombre.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LblApellido
            // 
            this.LblApellido.AutoSize = true;
            this.LblApellido.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.LblApellido.Location = new System.Drawing.Point(273, 28);
            this.LblApellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblApellido.Name = "LblApellido";
            this.LblApellido.Size = new System.Drawing.Size(72, 23);
            this.LblApellido.TabIndex = 9;
            this.LblApellido.Text = "Apellido";
            // 
            // LblNombre
            // 
            this.LblNombre.AutoSize = true;
            this.LblNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.LblNombre.Location = new System.Drawing.Point(45, 28);
            this.LblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblNombre.Name = "LblNombre";
            this.LblNombre.Size = new System.Drawing.Size(73, 23);
            this.LblNombre.TabIndex = 7;
            this.LblNombre.Text = "Nombre";
            // 
            // tex_user
            // 
            this.tex_user.Location = new System.Drawing.Point(75, 356);
            this.tex_user.Margin = new System.Windows.Forms.Padding(4);
            this.tex_user.Name = "tex_user";
            this.tex_user.Size = new System.Drawing.Size(160, 22);
            this.tex_user.TabIndex = 31;
            this.tex_user.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tex_pass
            // 
            this.tex_pass.Location = new System.Drawing.Point(268, 356);
            this.tex_pass.Margin = new System.Windows.Forms.Padding(4);
            this.tex_pass.Name = "tex_pass";
            this.tex_pass.Size = new System.Drawing.Size(160, 22);
            this.tex_pass.TabIndex = 32;
            this.tex_pass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btR_status_account_activo
            // 
            this.btR_status_account_activo.AutoSize = true;
            this.btR_status_account_activo.Checked = true;
            this.btR_status_account_activo.Location = new System.Drawing.Point(314, 478);
            this.btR_status_account_activo.Name = "btR_status_account_activo";
            this.btR_status_account_activo.Size = new System.Drawing.Size(65, 20);
            this.btR_status_account_activo.TabIndex = 33;
            this.btR_status_account_activo.TabStop = true;
            this.btR_status_account_activo.Text = "Activo";
            this.btR_status_account_activo.UseVisualStyleBackColor = true;
            // 
            // btR_status_account_desactivo
            // 
            this.btR_status_account_desactivo.AutoSize = true;
            this.btR_status_account_desactivo.Location = new System.Drawing.Point(314, 506);
            this.btR_status_account_desactivo.Name = "btR_status_account_desactivo";
            this.btR_status_account_desactivo.Size = new System.Drawing.Size(87, 20);
            this.btR_status_account_desactivo.TabIndex = 34;
            this.btR_status_account_desactivo.TabStop = true;
            this.btR_status_account_desactivo.Text = "NO activo";
            this.btR_status_account_desactivo.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(73, 327);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 23);
            this.label4.TabIndex = 35;
            this.label4.Text = "Usuario ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(274, 329);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 23);
            this.label5.TabIndex = 36;
            this.label5.Text = "Contraseña";
            // 
            // formEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(579, 761);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barAcciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "formEmpleado";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formEmpleado";
            this.barAcciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnOcultar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel barAcciones;
        private System.Windows.Forms.PictureBox btnOcultar;
        private System.Windows.Forms.PictureBox btnMaximizar;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.PictureBox btnRestaurar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.DateTimePicker DtpNacimiento;
        private System.Windows.Forms.Label LblNacimiento;
        private System.Windows.Forms.Label LblEmail;
        private System.Windows.Forms.Label LblDUI;
        private System.Windows.Forms.Label LblTelefono;
        private System.Windows.Forms.TextBox TxtApellido;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label LblApellido;
        private System.Windows.Forms.Label LblNombre;
        private System.Windows.Forms.DateTimePicker date_fechaContracion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tex_dui;
        private System.Windows.Forms.TextBox tex_telefono;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comb_cargo;
        private System.Windows.Forms.ComboBox comb_departemeto;
        private System.Windows.Forms.ComboBox comb_distritos;
        private System.Windows.Forms.RadioButton btR_status_account_desactivo;
        private System.Windows.Forms.RadioButton btR_status_account_activo;
        private System.Windows.Forms.TextBox tex_pass;
        private System.Windows.Forms.TextBox tex_user;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}