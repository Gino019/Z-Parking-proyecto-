namespace PU3_Estacionamiento
{
    partial class frmPrincipal
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
            label1 = new Label();
            btnSalir = new Button();
            btnSalidaVehiculo = new Button();
            btnControlEstacionamiento = new Button();
            btnRegistrarVehiculo = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(332, 49);
            label1.Name = "label1";
            label1.Size = new Size(119, 20);
            label1.TabIndex = 0;
            label1.Text = "“Menú Principal”";
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(332, 351);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(94, 29);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnSalidaVehiculo
            // 
            btnSalidaVehiculo.Location = new Point(311, 242);
            btnSalidaVehiculo.Name = "btnSalidaVehiculo";
            btnSalidaVehiculo.Size = new Size(160, 29);
            btnSalidaVehiculo.TabIndex = 2;
            btnSalidaVehiculo.Text = "Salida Vehiculo";
            btnSalidaVehiculo.UseVisualStyleBackColor = true;
            btnSalidaVehiculo.Click += btnSalidaVehiculo_Click;
            // 
            // btnControlEstacionamiento
            // 
            btnControlEstacionamiento.Location = new Point(296, 172);
            btnControlEstacionamiento.Name = "btnControlEstacionamiento";
            btnControlEstacionamiento.Size = new Size(194, 29);
            btnControlEstacionamiento.TabIndex = 3;
            btnControlEstacionamiento.Text = "Control Estacionamiento";
            btnControlEstacionamiento.UseVisualStyleBackColor = true;
            btnControlEstacionamiento.Click += btnControlEstacionamiento_Click;
            // 
            // btnRegistrarVehiculo
            // 
            btnRegistrarVehiculo.Location = new Point(311, 111);
            btnRegistrarVehiculo.Name = "btnRegistrarVehiculo";
            btnRegistrarVehiculo.Size = new Size(150, 29);
            btnRegistrarVehiculo.TabIndex = 4;
            btnRegistrarVehiculo.Text = "Registrar Vehiculo";
            btnRegistrarVehiculo.UseVisualStyleBackColor = true;
            btnRegistrarVehiculo.Click += btnRegistrarVehiculo_Click;
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRegistrarVehiculo);
            Controls.Add(btnControlEstacionamiento);
            Controls.Add(btnSalidaVehiculo);
            Controls.Add(btnSalir);
            Controls.Add(label1);
            Name = "frmPrincipal";
            Text = "frmPrincipal";
            Load += frmPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnSalir;
        private Button btnSalidaVehiculo;
        private Button btnControlEstacionamiento;
        private Button btnRegistrarVehiculo;
    }
}