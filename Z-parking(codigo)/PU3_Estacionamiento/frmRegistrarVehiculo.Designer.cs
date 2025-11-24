namespace PU3_Estacionamiento
{
    partial class frmRegistrarVehiculo
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
            txtNombre = new TextBox();
            txtDNI = new TextBox();
            txtModelo = new TextBox();
            txtColor = new TextBox();
            txtTelefono = new TextBox();
            txtPlaca = new TextBox();
            txtCorreo = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            btnRegistrar = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(307, 51);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(145, 20);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registro de Vehículo";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(362, 119);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(125, 27);
            txtNombre.TabIndex = 1;
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(362, 167);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(125, 27);
            txtDNI.TabIndex = 2;
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(362, 364);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(125, 27);
            txtModelo.TabIndex = 3;
            // 
            // txtColor
            // 
            txtColor.Location = new Point(362, 411);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(125, 27);
            txtColor.TabIndex = 4;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(362, 219);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(125, 27);
            txtTelefono.TabIndex = 5;
            // 
            // txtPlaca
            // 
            txtPlaca.Location = new Point(362, 310);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(125, 27);
            txtPlaca.TabIndex = 6;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(362, 265);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(125, 27);
            txtCorreo.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(163, 122);
            label1.Name = "label1";
            label1.Size = new Size(163, 20);
            label1.TabIndex = 8;
            label1.Text = "Nombre del conductor:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(288, 170);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 9;
            label2.Text = "DNI:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(256, 222);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 10;
            label3.Text = "Teléfono:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(266, 272);
            label4.Name = "label4";
            label4.Size = new Size(57, 20);
            label4.TabIndex = 11;
            label4.Text = "Correo:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(266, 317);
            label6.Name = "label6";
            label6.Size = new Size(47, 20);
            label6.TabIndex = 13;
            label6.Text = "Placa:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(266, 371);
            label7.Name = "label7";
            label7.Size = new Size(64, 20);
            label7.TabIndex = 14;
            label7.Text = "Modelo:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(266, 418);
            label8.Name = "label8";
            label8.Size = new Size(48, 20);
            label8.TabIndex = 15;
            label8.Text = "Color:";
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(362, 510);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(94, 29);
            btnRegistrar.TabIndex = 17;
            btnRegistrar.Text = "button1";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(266, 519);
            label5.Name = "label5";
            label5.Size = new Size(71, 20);
            label5.TabIndex = 18;
            label5.Text = "Registrar:";
            // 
            // frmRegistrarVehiculo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(878, 600);
            Controls.Add(label5);
            Controls.Add(btnRegistrar);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtCorreo);
            Controls.Add(txtPlaca);
            Controls.Add(txtTelefono);
            Controls.Add(txtColor);
            Controls.Add(txtModelo);
            Controls.Add(txtDNI);
            Controls.Add(txtNombre);
            Controls.Add(lblTitulo);
            Name = "frmRegistrarVehiculo";
            Text = "frmRegistrarVehiculo";
            Load += frmRegistrarVehiculo_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private TextBox txtNombre;
        private TextBox txtDNI;
        private TextBox txtModelo;
        private TextBox txtColor;
        private TextBox txtTelefono;
        private TextBox txtPlaca;
        private TextBox txtCorreo;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label7;
        private Label label8;
        private Button btnRegistrar;
        private Label label5;
    }
}