namespace PU3_Estacionamiento
{
    partial class frmBoleta
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
            label2 = new Label();
            btnImprimir = new Button();
            btnEnviarCorreo = new Button();
            lblBoleta = new Label();
            lblDatos = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(255, 131);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 0;
            label1.Text = "Imprimir";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(198, 202);
            label2.Name = "label2";
            label2.Size = new Size(123, 20);
            label2.TabIndex = 1;
            label2.Text = "Enviar por correo";
            label2.Click += label2_Click;
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(353, 122);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(94, 29);
            btnImprimir.TabIndex = 2;
            btnImprimir.Text = "button1";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // btnEnviarCorreo
            // 
            btnEnviarCorreo.Location = new Point(353, 198);
            btnEnviarCorreo.Name = "btnEnviarCorreo";
            btnEnviarCorreo.Size = new Size(94, 29);
            btnEnviarCorreo.TabIndex = 3;
            btnEnviarCorreo.Text = "button2";
            btnEnviarCorreo.UseVisualStyleBackColor = true;
            btnEnviarCorreo.Click += btnEnviarCorreo_Click;
            // 
            // lblBoleta
            // 
            lblBoleta.AutoSize = true;
            lblBoleta.Location = new Point(376, 30);
            lblBoleta.Name = "lblBoleta";
            lblBoleta.Size = new Size(47, 20);
            lblBoleta.TabIndex = 4;
            lblBoleta.Text = "Título";
            // 
            // lblDatos
            // 
            lblDatos.AutoSize = true;
            lblDatos.Location = new Point(376, 68);
            lblDatos.Name = "lblDatos";
            lblDatos.Size = new Size(187, 20);
            lblDatos.TabIndex = 5;
            lblDatos.Text = "Muestra resumen del ticket";
            // 
            // frmBoleta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblDatos);
            Controls.Add(lblBoleta);
            Controls.Add(btnEnviarCorreo);
            Controls.Add(btnImprimir);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "frmBoleta";
            Text = "frmBoleta";
            Load += frmBoleta_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btnImprimir;
        private Button btnEnviarCorreo;
        private Label lblBoleta;
        private Label lblDatos;
    }
}