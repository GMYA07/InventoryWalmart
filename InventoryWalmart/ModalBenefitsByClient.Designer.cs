namespace InventoryWalmart
{
    partial class ModalBenefitsByClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModalBenefitsByClient));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.barAcciones = new System.Windows.Forms.Panel();
            this.btnOcultar = new System.Windows.Forms.PictureBox();
            this.btnMaximizar = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.btnRestaurar = new System.Windows.Forms.PictureBox();
            this.tableBenefitsRewards = new System.Windows.Forms.DataGridView();
            this.columnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnBenefits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDescripBene = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPorcentajeDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateStartD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateEndD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPointsReq = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCard = new System.Windows.Forms.Label();
            this.barAcciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOcultar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBenefitsRewards)).BeginInit();
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
            this.barAcciones.Size = new System.Drawing.Size(1042, 59);
            this.barAcciones.TabIndex = 6;
            this.barAcciones.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barAcciones_MouseDown);
            // 
            // btnOcultar
            // 
            this.btnOcultar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOcultar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOcultar.Image = global::InventoryWalmart.Properties.Resources.ocultar;
            this.btnOcultar.Location = new System.Drawing.Point(900, 12);
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
            this.btnMaximizar.Location = new System.Drawing.Point(953, 14);
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
            this.btnCerrar.Location = new System.Drawing.Point(998, 12);
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
            this.btnRestaurar.Location = new System.Drawing.Point(953, 12);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(30, 30);
            this.btnRestaurar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRestaurar.TabIndex = 3;
            this.btnRestaurar.TabStop = false;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // tableBenefitsRewards
            // 
            this.tableBenefitsRewards.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tableBenefitsRewards.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tableBenefitsRewards.BackgroundColor = System.Drawing.Color.White;
            this.tableBenefitsRewards.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableBenefitsRewards.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableBenefitsRewards.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tableBenefitsRewards.ColumnHeadersHeight = 70;
            this.tableBenefitsRewards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.tableBenefitsRewards.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnID,
            this.columnBenefits,
            this.ColumnDescripBene,
            this.ColumnPorcentajeDesc,
            this.ColumnDateStartD,
            this.ColumnDateEndD,
            this.ColumnPointsReq});
            this.tableBenefitsRewards.EnableHeadersVisualStyles = false;
            this.tableBenefitsRewards.Location = new System.Drawing.Point(103, 181);
            this.tableBenefitsRewards.Margin = new System.Windows.Forms.Padding(2);
            this.tableBenefitsRewards.Name = "tableBenefitsRewards";
            this.tableBenefitsRewards.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(207)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tableBenefitsRewards.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tableBenefitsRewards.RowHeadersVisible = false;
            this.tableBenefitsRewards.RowHeadersWidth = 51;
            this.tableBenefitsRewards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tableBenefitsRewards.Size = new System.Drawing.Size(845, 332);
            this.tableBenefitsRewards.TabIndex = 11;
            // 
            // columnID
            // 
            this.columnID.DataPropertyName = "IdBenefit";
            this.columnID.HeaderText = "ID";
            this.columnID.MinimumWidth = 6;
            this.columnID.Name = "columnID";
            // 
            // columnBenefits
            // 
            this.columnBenefits.DataPropertyName = "benefitName";
            this.columnBenefits.HeaderText = "Beneficio";
            this.columnBenefits.MinimumWidth = 6;
            this.columnBenefits.Name = "columnBenefits";
            // 
            // ColumnDescripBene
            // 
            this.ColumnDescripBene.DataPropertyName = "description";
            this.ColumnDescripBene.HeaderText = "Descripcion Beneficio";
            this.ColumnDescripBene.MinimumWidth = 6;
            this.ColumnDescripBene.Name = "ColumnDescripBene";
            // 
            // ColumnPorcentajeDesc
            // 
            this.ColumnPorcentajeDesc.DataPropertyName = "DiscountPercent";
            this.ColumnPorcentajeDesc.HeaderText = "Porcentaje \nDescuento";
            this.ColumnPorcentajeDesc.MinimumWidth = 6;
            this.ColumnPorcentajeDesc.Name = "ColumnPorcentajeDesc";
            // 
            // ColumnDateStartD
            // 
            this.ColumnDateStartD.DataPropertyName = "StartDate";
            this.ColumnDateStartD.HeaderText = "Fecha Inicio \nDescuento";
            this.ColumnDateStartD.MinimumWidth = 6;
            this.ColumnDateStartD.Name = "ColumnDateStartD";
            // 
            // ColumnDateEndD
            // 
            this.ColumnDateEndD.DataPropertyName = "EndDate";
            this.ColumnDateEndD.HeaderText = "Fecha Final \nDescuento";
            this.ColumnDateEndD.MinimumWidth = 6;
            this.ColumnDateEndD.Name = "ColumnDateEndD";
            // 
            // ColumnPointsReq
            // 
            this.ColumnPointsReq.DataPropertyName = "PointsRequierd";
            this.ColumnPointsReq.HeaderText = "Puntos\nRequeridos";
            this.ColumnPointsReq.MinimumWidth = 6;
            this.ColumnPointsReq.Name = "ColumnPointsReq";
            // 
            // lblCard
            // 
            this.lblCard.AutoSize = true;
            this.lblCard.Location = new System.Drawing.Point(490, 102);
            this.lblCard.Name = "lblCard";
            this.lblCard.Size = new System.Drawing.Size(31, 13);
            this.lblCard.TabIndex = 12;
            this.lblCard.Text = "carta";
            // 
            // ModalBenefitsByClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1042, 596);
            this.Controls.Add(this.lblCard);
            this.Controls.Add(this.tableBenefitsRewards);
            this.Controls.Add(this.barAcciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ModalBenefitsByClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModalBenefitsByClient";
            this.barAcciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnOcultar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximizar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRestaurar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableBenefitsRewards)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel barAcciones;
        private System.Windows.Forms.PictureBox btnOcultar;
        private System.Windows.Forms.PictureBox btnMaximizar;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.PictureBox btnRestaurar;
        private System.Windows.Forms.DataGridView tableBenefitsRewards;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnBenefits;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescripBene;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPorcentajeDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateStartD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateEndD;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPointsReq;
        private System.Windows.Forms.Label lblCard;
    }
}