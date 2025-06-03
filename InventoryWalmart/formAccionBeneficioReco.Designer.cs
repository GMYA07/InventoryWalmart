namespace InventoryWalmart
{
    partial class formAccionBeneficioReco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formAccionBeneficioReco));
            this.barAcciones = new System.Windows.Forms.Panel();
            this.btnOcultar = new System.Windows.Forms.PictureBox();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.btnRestaurar = new System.Windows.Forms.PictureBox();
            this.tituloForm = new System.Windows.Forms.Label();
            this.labelNombreBene = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBeneficio = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtDescrip = new System.Windows.Forms.TextBox();
            this.labelDescrip = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtPuntos = new System.Windows.Forms.TextBox();
            this.labelPtsReque = new System.Windows.Forms.Label();
            this.labelPorcentaje = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.DTPInicio = new System.Windows.Forms.DateTimePicker();
            this.DTPfin = new System.Windows.Forms.DateTimePicker();
            this.labelDateStart = new System.Windows.Forms.Label();
            this.labelEnd = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.barAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOcultar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // barAcciones
            // 
            this.barAcciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(114)))), ((int)(((byte)(223)))));
            this.barAcciones.Controls.Add(this.button1);
            this.barAcciones.Controls.Add(this.btnOcultar);
            this.barAcciones.Controls.Add(this.btnMaximizar);
            this.barAcciones.Controls.Add(this.btnCerrar);
            this.barAcciones.Controls.Add(this.btnRestaurar);
            this.barAcciones.Dock = System.Windows.Forms.DockStyle.Top;
            this.barAcciones.Location = new System.Drawing.Point(0, 0);
            this.barAcciones.Name = "barAcciones";
            this.barAcciones.Size = new System.Drawing.Size(500, 59);
            this.barAcciones.TabIndex = 4;
            this.barAcciones.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barAcciones_MouseDown);
            // 
            // btnOcultar
            // 
            this.btnOcultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOcultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOcultar.Image = global::InventoryWalmart.Properties.Resources.ocultar;
            this.btnOcultar.Location = new System.Drawing.Point(358, 12);
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
            this.btnMaximizar.Location = new System.Drawing.Point(411, 12);
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
            this.btnCerrar.Location = new System.Drawing.Point(456, 12);
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
            this.btnRestaurar.Location = new System.Drawing.Point(411, 12);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(30, 30);
            this.btnRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRestaurar.TabIndex = 3;
            this.btnRestaurar.TabStop = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // tituloForm
            // 
            this.tituloForm.AutoSize = true;
            this.tituloForm.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tituloForm.Location = new System.Drawing.Point(81, 100);
            this.tituloForm.Name = "tituloForm";
            this.tituloForm.Size = new System.Drawing.Size(353, 80);
            this.tituloForm.TabIndex = 6;
            this.tituloForm.Text = "Agregar \r\nBeneficio o Recompensa";
            this.tituloForm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelNombreBene
            // 
            this.labelNombreBene.AutoSize = true;
            this.labelNombreBene.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreBene.Location = new System.Drawing.Point(10, 17);
            this.labelNombreBene.Name = "labelNombreBene";
            this.labelNombreBene.Size = new System.Drawing.Size(261, 21);
            this.labelNombreBene.TabIndex = 8;
            this.labelNombreBene.Text = "Nombre Beneficio / Recompensa";
            this.labelNombreBene.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtBeneficio);
            this.panel1.Controls.Add(this.labelNombreBene);
            this.panel1.Location = new System.Drawing.Point(86, 210);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 75);
            this.panel1.TabIndex = 9;
            // 
            // txtBeneficio
            // 
            this.txtBeneficio.BackColor = System.Drawing.Color.White;
            this.txtBeneficio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBeneficio.Location = new System.Drawing.Point(14, 41);
            this.txtBeneficio.Name = "txtBeneficio";
            this.txtBeneficio.Size = new System.Drawing.Size(293, 20);
            this.txtBeneficio.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtDescrip);
            this.panel2.Controls.Add(this.labelDescrip);
            this.panel2.Location = new System.Drawing.Point(86, 305);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(317, 140);
            this.panel2.TabIndex = 10;
            // 
            // txtDescrip
            // 
            this.txtDescrip.BackColor = System.Drawing.Color.White;
            this.txtDescrip.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescrip.Location = new System.Drawing.Point(14, 41);
            this.txtDescrip.Multiline = true;
            this.txtDescrip.Name = "txtDescrip";
            this.txtDescrip.Size = new System.Drawing.Size(293, 87);
            this.txtDescrip.TabIndex = 9;
            // 
            // labelDescrip
            // 
            this.labelDescrip.AutoSize = true;
            this.labelDescrip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescrip.Location = new System.Drawing.Point(10, 17);
            this.labelDescrip.Name = "labelDescrip";
            this.labelDescrip.Size = new System.Drawing.Size(288, 21);
            this.labelDescrip.TabIndex = 8;
            this.labelDescrip.Text = "Descripcion Beneficio / Recompensa\r\n";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txtPuntos);
            this.panel3.Controls.Add(this.labelPtsReque);
            this.panel3.Controls.Add(this.labelPorcentaje);
            this.panel3.Controls.Add(this.txtDescuento);
            this.panel3.Location = new System.Drawing.Point(68, 468);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(362, 72);
            this.panel3.TabIndex = 11;
            // 
            // txtPuntos
            // 
            this.txtPuntos.BackColor = System.Drawing.Color.White;
            this.txtPuntos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPuntos.Location = new System.Drawing.Point(197, 40);
            this.txtPuntos.Name = "txtPuntos";
            this.txtPuntos.Size = new System.Drawing.Size(157, 20);
            this.txtPuntos.TabIndex = 12;
            // 
            // labelPtsReque
            // 
            this.labelPtsReque.AutoSize = true;
            this.labelPtsReque.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPtsReque.Location = new System.Drawing.Point(198, 17);
            this.labelPtsReque.Name = "labelPtsReque";
            this.labelPtsReque.Size = new System.Drawing.Size(141, 20);
            this.labelPtsReque.TabIndex = 11;
            this.labelPtsReque.Text = "Puntos Requeridos\r\n";
            this.labelPtsReque.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelPorcentaje
            // 
            this.labelPorcentaje.AutoSize = true;
            this.labelPorcentaje.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPorcentaje.Location = new System.Drawing.Point(16, 17);
            this.labelPorcentaje.Name = "labelPorcentaje";
            this.labelPorcentaje.Size = new System.Drawing.Size(161, 20);
            this.labelPorcentaje.TabIndex = 10;
            this.labelPorcentaje.Text = "Porcentaje Descuento";
            this.labelPorcentaje.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDescuento
            // 
            this.txtDescuento.BackColor = System.Drawing.Color.White;
            this.txtDescuento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescuento.Location = new System.Drawing.Point(20, 40);
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(157, 20);
            this.txtDescuento.TabIndex = 9;
            // 
            // DTPInicio
            // 
            this.DTPInicio.Location = new System.Drawing.Point(60, 578);
            this.DTPInicio.Name = "DTPInicio";
            this.DTPInicio.Size = new System.Drawing.Size(185, 20);
            this.DTPInicio.TabIndex = 12;
            this.DTPInicio.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // DTPfin
            // 
            this.DTPfin.Location = new System.Drawing.Point(256, 578);
            this.DTPfin.Name = "DTPfin";
            this.DTPfin.Size = new System.Drawing.Size(185, 20);
            this.DTPfin.TabIndex = 13;
            // 
            // labelDateStart
            // 
            this.labelDateStart.AutoSize = true;
            this.labelDateStart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateStart.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.labelDateStart.Location = new System.Drawing.Point(57, 560);
            this.labelDateStart.Name = "labelDateStart";
            this.labelDateStart.Size = new System.Drawing.Size(135, 15);
            this.labelDateStart.TabIndex = 13;
            this.labelDateStart.Text = "Fecha Inicio Descuento";
            this.labelDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelEnd
            // 
            this.labelEnd.AutoSize = true;
            this.labelEnd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEnd.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.labelEnd.Location = new System.Drawing.Point(258, 560);
            this.labelEnd.Name = "labelEnd";
            this.labelEnd.Size = new System.Drawing.Size(130, 15);
            this.labelEnd.TabIndex = 14;
            this.labelEnd.Text = "Fecha Final Descuento";
            this.labelEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btnAgregar.Location = new System.Drawing.Point(166, 636);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Padding = new System.Windows.Forms.Padding(10, 0, 35, 0);
            this.btnAgregar.Size = new System.Drawing.Size(170, 45);
            this.btnAgregar.TabIndex = 15;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(194)))), ((int)(((byte)(33)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Image = global::InventoryWalmart.Properties.Resources.IconoRegresar1;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 35);
            this.button1.TabIndex = 6;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // formAccionBeneficioReco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 720);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.labelEnd);
            this.Controls.Add(this.labelDateStart);
            this.Controls.Add(this.DTPfin);
            this.Controls.Add(this.DTPInicio);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tituloForm);
            this.Controls.Add(this.barAcciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formAccionBeneficioReco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formAgregarBeneficio";
            this.Load += new System.EventHandler(this.formAgregarBeneficio_Load);
            this.barAcciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnOcultar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel barAcciones;
        private System.Windows.Forms.PictureBox btnOcultar;
        private System.Windows.Forms.PictureBox btnMaximizar;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.PictureBox btnRestaurar;
        private System.Windows.Forms.Label tituloForm;
        private System.Windows.Forms.Label labelNombreBene;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtBeneficio;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtDescrip;
        private System.Windows.Forms.Label labelDescrip;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label labelPorcentaje;
        private System.Windows.Forms.TextBox txtPuntos;
        private System.Windows.Forms.Label labelPtsReque;
        private System.Windows.Forms.DateTimePicker DTPInicio;
        private System.Windows.Forms.DateTimePicker DTPfin;
        private System.Windows.Forms.Label labelDateStart;
        private System.Windows.Forms.Label labelEnd;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button button1;
    }
}