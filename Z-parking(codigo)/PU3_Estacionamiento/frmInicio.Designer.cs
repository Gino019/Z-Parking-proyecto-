namespace PU3_Estacionamiento
{
    partial class frmInicio
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
            txtUsuario = new TextBox();
            txtClave = new TextBox();
            btnIngresar = new Button();
            label1 = new Label();
            lblError = new Label();
            SuspendLayout();
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(338, 138);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(125, 27);
            txtUsuario.TabIndex = 0;
            txtUsuario.TextChanged += txtUsuario_TextChanged;
            // 
            // txtClave
            // 
            txtClave.Location = new Point(338, 212);
            txtClave.Name = "txtClave";
            txtClave.PasswordChar = '*';
            txtClave.Size = new Size(125, 27);
            txtClave.TabIndex = 1;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(350, 284);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(94, 29);
            btnIngresar.TabIndex = 2;
            btnIngresar.Text = "button1";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(265, 67);
            label1.Name = "label1";
            label1.Size = new Size(239, 20);
            label1.TabIndex = 3;
            label1.Text = "“SISTEMA DE ESTACIONAMIENTO”";
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Location = new Point(369, 351);
            lblError.Name = "lblError";
            lblError.Size = new Size(50, 20);
            lblError.TabIndex = 4;
            lblError.Text = "label2";
            // 
            // frmInicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblError);
            Controls.Add(label1);
            Controls.Add(btnIngresar);
            Controls.Add(txtClave);
            Controls.Add(txtUsuario);
            Name = "frmInicio";
            Text = "frmInicio";
            Load += frmInicio_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUsuario;
        private TextBox txtClave;
        private Button btnIngresar;
        private Label label1;
        private Label lblError;
    }
}