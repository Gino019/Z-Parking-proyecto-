namespace PU3_Estacionamiento
{
    partial class frmSalidaVehiculo
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
            lblTitulo = new Label();
            label2 = new Label();
            label3 = new Label();
            lblEntrada = new Label();
            txtPlaca = new TextBox();
            btnBuscar = new Button();
            lblSalida = new Label();
            lblCosto = new Label();
            btnRegistrarSalida = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(313, 45);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(128, 20);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registro de salida";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(188, 120);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 1;
            label2.Text = "Placa a buscar:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(214, 186);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 2;
            label3.Text = "Buscar:";
            // 
            // lblEntrada
            // 
            lblEntrada.AutoSize = true;
            lblEntrada.Location = new Point(175, 248);
            lblEntrada.Name = "lblEntrada";
            lblEntrada.Size = new Size(97, 20);
            lblEntrada.TabIndex = 3;
            lblEntrada.Text = "Hora entrada";
            // 
            // txtPlaca
            // 
            txtPlaca.Location = new Point(335, 120);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(125, 27);
            txtPlaca.TabIndex = 4;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(356, 177);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(94, 29);
            btnBuscar.TabIndex = 5;
            btnBuscar.Text = "button1";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblSalida
            // 
            lblSalida.AutoSize = true;
            lblSalida.Location = new Point(189, 298);
            lblSalida.Name = "lblSalida";
            lblSalida.Size = new Size(85, 20);
            lblSalida.TabIndex = 6;
            lblSalida.Text = "Hora salida";
            // 
            // lblCosto
            // 
            lblCosto.AutoSize = true;
            lblCosto.Location = new Point(199, 339);
            lblCosto.Name = "lblCosto";
            lblCosto.Size = new Size(82, 20);
            lblCosto.TabIndex = 7;
            lblCosto.Text = "Costo total";
            // 
            // btnRegistrarSalida
            // 
            btnRegistrarSalida.Location = new Point(366, 383);
            btnRegistrarSalida.Name = "btnRegistrarSalida";
            btnRegistrarSalida.Size = new Size(94, 29);
            btnRegistrarSalida.TabIndex = 8;
            btnRegistrarSalida.Text = "button1";
            btnRegistrarSalida.UseVisualStyleBackColor = true;
            btnRegistrarSalida.Click += btnRegistrarSalida_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(220, 387);
            label1.Name = "label1";
            label1.Size = new Size(118, 20);
            label1.TabIndex = 9;
            label1.Text = "Confirmar salida";
            // 
            // frmSalidaVehiculo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnRegistrarSalida);
            Controls.Add(lblCosto);
            Controls.Add(lblSalida);
            Controls.Add(btnBuscar);
            Controls.Add(txtPlaca);
            Controls.Add(lblEntrada);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lblTitulo);
            Name = "frmSalidaVehiculo";
            Text = "frmSalidaVehiculo";
            Load += frmSalidaVehiculo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label label2;
        private Label label3;
        private Label lblEntrada;
        private TextBox txtPlaca;
        private Button btnBuscar;
        private Label lblSalida;
        private Label lblCosto;
        private Button btnRegistrarSalida;
        private Label label1;
    }
}