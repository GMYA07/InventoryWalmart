namespace InventoryWalmart
{
    partial class FormAddProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddProduct));
            this.LblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_categoria = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescrip = new System.Windows.Forms.TextBox();
            this.LblDescripcion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RdoInactivo = new System.Windows.Forms.RadioButton();
            this.RdoActivo = new System.Windows.Forms.RadioButton();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.DtpInicio = new System.Windows.Forms.DateTimePicker();
            this.LblDevolucion = new System.Windows.Forms.Label();
            this.TxtNombreProduc = new System.Windows.Forms.TextBox();
            this.LblEmail = new System.Windows.Forms.Label();
            this.TxtIdProduct = new System.Windows.Forms.TextBox();
            this.LblIngresaDUI = new System.Windows.Forms.Label();
            this.barAcciones = new System.Windows.Forms.Panel();
            this.btnOcultar = new System.Windows.Forms.PictureBox();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.btnRestaurar = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.barAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOcultar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).BeginInit();
            this.SuspendLayout();
            // 
            // LblTitulo
            // 
            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new System.Drawing.Font("Segoe UI Semibold", 18.75F, System.Drawing.FontStyle.Bold);
            this.LblTitulo.Location = new System.Drawing.Point(105, 0);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(120, 35);
            this.LblTitulo.TabIndex = 18;
            this.LblTitulo.Text = "Producto";
            this.LblTitulo.Click += new System.EventHandler(this.LblTitulo_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.LblTitulo);
            this.panel1.Controls.Add(this.txtStock);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtPrecio);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cb_categoria);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDescrip);
            this.panel1.Controls.Add(this.LblDescripcion);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.RdoInactivo);
            this.panel1.Controls.Add(this.RdoActivo);
            this.panel1.Controls.Add(this.btnAgregar);
            this.panel1.Controls.Add(this.DtpInicio);
            this.panel1.Controls.Add(this.LblDevolucion);
            this.panel1.Controls.Add(this.TxtNombreProduc);
            this.panel1.Controls.Add(this.LblEmail);
            this.panel1.Controls.Add(this.TxtIdProduct);
            this.panel1.Controls.Add(this.LblIngresaDUI);
            this.panel1.Location = new System.Drawing.Point(21, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 573);
            this.panel1.TabIndex = 19;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(38, 290);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(271, 20);
            this.txtStock.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(34, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 19);
            this.label4.TabIndex = 31;
            this.label4.Text = "Stock";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(38, 230);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(271, 20);
            this.txtPrecio.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(34, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 19);
            this.label3.TabIndex = 29;
            this.label3.Text = "Precio";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // cb_categoria
            // 
            this.cb_categoria.FormattingEnabled = true;
            this.cb_categoria.Items.AddRange(new object[] {
            "Electronicos",
            "Electrodomesticos",
            "Ropa",
            "Juguetes",
            "Comida"});
            this.cb_categoria.Location = new System.Drawing.Point(111, 166);
            this.cb_categoria.Name = "cb_categoria";
            this.cb_categoria.Size = new System.Drawing.Size(191, 21);
            this.cb_categoria.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(34, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 27;
            this.label2.Text = "Categoria";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtDescrip
            // 
            this.txtDescrip.Location = new System.Drawing.Point(52, 449);
            this.txtDescrip.Multiline = true;
            this.txtDescrip.Name = "txtDescrip";
            this.txtDescrip.Size = new System.Drawing.Size(250, 49);
            this.txtDescrip.TabIndex = 26;
            // 
            // LblDescripcion
            // 
            this.LblDescripcion.AutoSize = true;
            this.LblDescripcion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LblDescripcion.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.LblDescripcion.Location = new System.Drawing.Point(34, 427);
            this.LblDescripcion.Name = "LblDescripcion";
            this.LblDescripcion.Size = new System.Drawing.Size(83, 19);
            this.LblDescripcion.TabIndex = 17;
            this.LblDescripcion.Text = "Descripcion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(34, 392);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 19);
            this.label1.TabIndex = 25;
            this.label1.Text = "Estado";
            // 
            // RdoInactivo
            // 
            this.RdoInactivo.AutoSize = true;
            this.RdoInactivo.Location = new System.Drawing.Point(203, 393);
            this.RdoInactivo.Name = "RdoInactivo";
            this.RdoInactivo.Size = new System.Drawing.Size(63, 17);
            this.RdoInactivo.TabIndex = 24;
            this.RdoInactivo.TabStop = true;
            this.RdoInactivo.Text = "Inactivo";
            this.RdoInactivo.UseVisualStyleBackColor = true;
            // 
            // RdoActivo
            // 
            this.RdoActivo.AutoSize = true;
            this.RdoActivo.Checked = true;
            this.RdoActivo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RdoActivo.Location = new System.Drawing.Point(111, 393);
            this.RdoActivo.Name = "RdoActivo";
            this.RdoActivo.Size = new System.Drawing.Size(55, 17);
            this.RdoActivo.TabIndex = 23;
            this.RdoActivo.TabStop = true;
            this.RdoActivo.Text = "Activo";
            this.RdoActivo.UseVisualStyleBackColor = true;
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
            this.btnAgregar.Location = new System.Drawing.Point(96, 515);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Padding = new System.Windows.Forms.Padding(10, 0, 35, 0);
            this.btnAgregar.Size = new System.Drawing.Size(170, 45);
            this.btnAgregar.TabIndex = 21;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = false;
            // 
            // DtpInicio
            // 
            this.DtpInicio.Location = new System.Drawing.Point(38, 351);
            this.DtpInicio.Name = "DtpInicio";
            this.DtpInicio.Size = new System.Drawing.Size(200, 20);
            this.DtpInicio.TabIndex = 18;
            // 
            // LblDevolucion
            // 
            this.LblDevolucion.AutoSize = true;
            this.LblDevolucion.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.LblDevolucion.Location = new System.Drawing.Point(34, 323);
            this.LblDevolucion.Name = "LblDevolucion";
            this.LblDevolucion.Size = new System.Drawing.Size(45, 19);
            this.LblDevolucion.TabIndex = 17;
            this.LblDevolucion.Text = "Fecha";
            this.LblDevolucion.Click += new System.EventHandler(this.LblDevolucion_Click);
            // 
            // TxtNombreProduc
            // 
            this.TxtNombreProduc.Location = new System.Drawing.Point(38, 125);
            this.TxtNombreProduc.Name = "TxtNombreProduc";
            this.TxtNombreProduc.Size = new System.Drawing.Size(271, 20);
            this.TxtNombreProduc.TabIndex = 16;
            // 
            // LblEmail
            // 
            this.LblEmail.AutoSize = true;
            this.LblEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.LblEmail.Location = new System.Drawing.Point(34, 103);
            this.LblEmail.Name = "LblEmail";
            this.LblEmail.Size = new System.Drawing.Size(144, 19);
            this.LblEmail.TabIndex = 15;
            this.LblEmail.Text = "Nombre del producto";
            // 
            // TxtIdProduct
            // 
            this.TxtIdProduct.Location = new System.Drawing.Point(38, 72);
            this.TxtIdProduct.Name = "TxtIdProduct";
            this.TxtIdProduct.Size = new System.Drawing.Size(271, 20);
            this.TxtIdProduct.TabIndex = 8;
            // 
            // LblIngresaDUI
            // 
            this.LblIngresaDUI.AutoSize = true;
            this.LblIngresaDUI.BackColor = System.Drawing.Color.WhiteSmoke;
            this.LblIngresaDUI.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.LblIngresaDUI.Location = new System.Drawing.Point(34, 50);
            this.LblIngresaDUI.Name = "LblIngresaDUI";
            this.LblIngresaDUI.Size = new System.Drawing.Size(107, 19);
            this.LblIngresaDUI.TabIndex = 7;
            this.LblIngresaDUI.Text = "ID del producto";
            this.LblIngresaDUI.Click += new System.EventHandler(this.LblIngresaDUI_Click);
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
            this.barAcciones.Name = "barAcciones";
            this.barAcciones.Size = new System.Drawing.Size(410, 59);
            this.barAcciones.TabIndex = 17;
            // 
            // btnOcultar
            // 
            this.btnOcultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOcultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOcultar.Image = global::InventoryWalmart.Properties.Resources.ocultar;
            this.btnOcultar.Location = new System.Drawing.Point(268, 12);
            this.btnOcultar.Name = "btnOcultar";
            this.btnOcultar.Size = new System.Drawing.Size(30, 30);
            this.btnOcultar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnOcultar.TabIndex = 4;
            this.btnOcultar.TabStop = false;
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximizar.Image")));
            this.btnMaximizar.Location = new System.Drawing.Point(321, 12);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(30, 30);
            this.btnMaximizar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnMaximizar.TabIndex = 3;
            this.btnMaximizar.TabStop = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(366, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(32, 32);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.TabStop = false;
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestaurar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRestaurar.Image = ((System.Drawing.Image)(resources.GetObject("btnRestaurar.Image")));
            this.btnRestaurar.Location = new System.Drawing.Point(321, 12);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(30, 30);
            this.btnRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRestaurar.TabIndex = 3;
            this.btnRestaurar.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(194)))), ((int)(((byte)(33)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Image = global::InventoryWalmart.Properties.Resources.IconoRegresar1;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 35);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // FormAddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(410, 664);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barAcciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAddProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAddProduct";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.barAcciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnOcultar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDescrip;
        private System.Windows.Forms.Label LblDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton RdoInactivo;
        private System.Windows.Forms.RadioButton RdoActivo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DateTimePicker DtpInicio;
        private System.Windows.Forms.Label LblDevolucion;
        private System.Windows.Forms.TextBox TxtNombreProduc;
        private System.Windows.Forms.Label LblEmail;
        private System.Windows.Forms.TextBox TxtIdProduct;
        private System.Windows.Forms.Label LblIngresaDUI;
        private System.Windows.Forms.Panel barAcciones;
        private System.Windows.Forms.PictureBox btnOcultar;
        private System.Windows.Forms.PictureBox btnMaximizar;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.PictureBox btnRestaurar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_categoria;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label3;
    }
}