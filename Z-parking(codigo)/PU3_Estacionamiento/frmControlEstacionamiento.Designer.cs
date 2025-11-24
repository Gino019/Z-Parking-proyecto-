namespace PU3_Estacionamiento
{
    partial class frmControlEstacionamiento
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
            btnEspacio1 = new Button();
            btnEspacio2 = new Button();
            btnEspacio3 = new Button();
            btnEspacio4 = new Button();
            btnEspacio5 = new Button();
            btnActualizar = new Button();
            dgvOcupacion = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvOcupacion).BeginInit();
            SuspendLayout();
            // 
            // btnEspacio1
            // 
            btnEspacio1.Location = new Point(136, 34);
            btnEspacio1.Name = "btnEspacio1";
            btnEspacio1.Size = new Size(156, 135);
            btnEspacio1.TabIndex = 0;
            btnEspacio1.Text = "button1";
            btnEspacio1.UseVisualStyleBackColor = true;
            btnEspacio1.Click += btnEspacio_Click;
            // 
            // btnEspacio2
            // 
            btnEspacio2.Location = new Point(361, 34);
            btnEspacio2.Name = "btnEspacio2";
            btnEspacio2.Size = new Size(156, 135);
            btnEspacio2.TabIndex = 1;
            btnEspacio2.Text = "button2";
            btnEspacio2.UseVisualStyleBackColor = true;
            btnEspacio2.Click += btnEspacio_Click;
            // 
            // btnEspacio3
            // 
            btnEspacio3.Location = new Point(591, 34);
            btnEspacio3.Name = "btnEspacio3";
            btnEspacio3.Size = new Size(156, 135);
            btnEspacio3.TabIndex = 2;
            btnEspacio3.Text = "button3";
            btnEspacio3.UseVisualStyleBackColor = true;
            btnEspacio3.Click += btnEspacio_Click;
            // 
            // btnEspacio4
            // 
            btnEspacio4.Location = new Point(816, 34);
            btnEspacio4.Name = "btnEspacio4";
            btnEspacio4.Size = new Size(156, 135);
            btnEspacio4.TabIndex = 3;
            btnEspacio4.Text = "button4";
            btnEspacio4.UseVisualStyleBackColor = true;
            btnEspacio4.Click += btnEspacio_Click;
            // 
            // btnEspacio5
            // 
            btnEspacio5.Location = new Point(136, 206);
            btnEspacio5.Name = "btnEspacio5";
            btnEspacio5.Size = new Size(156, 132);
            btnEspacio5.TabIndex = 4;
            btnEspacio5.Text = "button5";
            btnEspacio5.UseVisualStyleBackColor = true;
            btnEspacio5.Click += btnEspacio_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(475, 689);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(199, 63);
            btnActualizar.TabIndex = 8;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // dgvOcupacion
            // 
            dgvOcupacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOcupacion.Location = new Point(136, 365);
            dgvOcupacion.Name = "dgvOcupacion";
            dgvOcupacion.ReadOnly = true;
            dgvOcupacion.RowHeadersWidth = 51;
            dgvOcupacion.Size = new Size(836, 307);
            dgvOcupacion.TabIndex = 9;
            // 
            // frmControlEstacionamiento
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1083, 775);
            Controls.Add(dgvOcupacion);
            Controls.Add(btnActualizar);
            Controls.Add(btnEspacio5);
            Controls.Add(btnEspacio4);
            Controls.Add(btnEspacio3);
            Controls.Add(btnEspacio2);
            Controls.Add(btnEspacio1);
            Name = "frmControlEstacionamiento";
            Text = "frmControlEstacionamiento";
            Load += frmControlEstacionamiento_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOcupacion).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnEspacio1;
        private Button btnEspacio2;
        private Button btnEspacio3;
        private Button btnEspacio4;
        private Button btnEspacio5;
        private Button btnActualizar;
        private DataGridView dgvOcupacion;
    }
}