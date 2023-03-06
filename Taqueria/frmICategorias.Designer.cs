namespace Taqueria
{
    partial class frmICategorias
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
            this.dgvCategoriasInactivas = new System.Windows.Forms.DataGridView();
            this.gpbActivar = new System.Windows.Forms.GroupBox();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnActivar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoriasInactivas)).BeginInit();
            this.gpbActivar.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCategoriasInactivas
            // 
            this.dgvCategoriasInactivas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategoriasInactivas.Location = new System.Drawing.Point(12, 99);
            this.dgvCategoriasInactivas.Name = "dgvCategoriasInactivas";
            this.dgvCategoriasInactivas.Size = new System.Drawing.Size(350, 150);
            this.dgvCategoriasInactivas.TabIndex = 3;
            // 
            // gpbActivar
            // 
            this.gpbActivar.Controls.Add(this.btnRegresar);
            this.gpbActivar.Controls.Add(this.btnActivar);
            this.gpbActivar.Location = new System.Drawing.Point(12, 12);
            this.gpbActivar.Name = "gpbActivar";
            this.gpbActivar.Size = new System.Drawing.Size(350, 81);
            this.gpbActivar.TabIndex = 2;
            this.gpbActivar.TabStop = false;
            // 
            // btnRegresar
            // 
            this.btnRegresar.Location = new System.Drawing.Point(242, 30);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(75, 23);
            this.btnRegresar.TabIndex = 1;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // btnActivar
            // 
            this.btnActivar.Location = new System.Drawing.Point(21, 30);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(75, 23);
            this.btnActivar.TabIndex = 0;
            this.btnActivar.Text = "Activar";
            this.btnActivar.UseVisualStyleBackColor = true;
            this.btnActivar.Click += new System.EventHandler(this.btnActivar_Click);
            // 
            // frmICategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 267);
            this.Controls.Add(this.dgvCategoriasInactivas);
            this.Controls.Add(this.gpbActivar);
            this.MaximizeBox = false;
            this.Name = "frmICategorias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Categorias Inactivas";
            this.Load += new System.EventHandler(this.frmICategorias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategoriasInactivas)).EndInit();
            this.gpbActivar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCategoriasInactivas;
        private System.Windows.Forms.GroupBox gpbActivar;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button btnActivar;
    }
}