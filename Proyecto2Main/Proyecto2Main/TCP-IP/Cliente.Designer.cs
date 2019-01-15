namespace Proyecto2Main.TCP_IP
{
    partial class Cliente
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
            this.txtBoxMessage = new System.Windows.Forms.TextBox();
            this.grpBoxCliente = new System.Windows.Forms.GroupBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnConectar = new System.Windows.Forms.Button();
            this.lblMandas = new System.Windows.Forms.Label();
            this.lblRecibes = new System.Windows.Forms.Label();
            this.txtBoxMandas = new System.Windows.Forms.TextBox();
            this.txtBoxRecibes = new System.Windows.Forms.TextBox();
            this.grpBoxCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBoxMessage
            // 
            this.txtBoxMessage.Location = new System.Drawing.Point(125, 134);
            this.txtBoxMessage.Name = "txtBoxMessage";
            this.txtBoxMessage.Size = new System.Drawing.Size(382, 20);
            this.txtBoxMessage.TabIndex = 0;
            // 
            // grpBoxCliente
            // 
            this.grpBoxCliente.Controls.Add(this.txtBoxRecibes);
            this.grpBoxCliente.Controls.Add(this.txtBoxMandas);
            this.grpBoxCliente.Controls.Add(this.lblRecibes);
            this.grpBoxCliente.Controls.Add(this.lblMandas);
            this.grpBoxCliente.Controls.Add(this.btnConectar);
            this.grpBoxCliente.Controls.Add(this.btnEnviar);
            this.grpBoxCliente.Controls.Add(this.lblMessage);
            this.grpBoxCliente.Controls.Add(this.txtBoxMessage);
            this.grpBoxCliente.Location = new System.Drawing.Point(36, 23);
            this.grpBoxCliente.Name = "grpBoxCliente";
            this.grpBoxCliente.Size = new System.Drawing.Size(641, 196);
            this.grpBoxCliente.TabIndex = 1;
            this.grpBoxCliente.TabStop = false;
            this.grpBoxCliente.Text = "Cliente";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(31, 137);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(91, 13);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "Mensaje a enviar:";
            // 
            // btnEnviar
            // 
            this.btnEnviar.Location = new System.Drawing.Point(540, 134);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(75, 23);
            this.btnEnviar.TabIndex = 2;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(540, 78);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(75, 23);
            this.btnConectar.TabIndex = 3;
            this.btnConectar.Text = "Conectar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // lblMandas
            // 
            this.lblMandas.AutoSize = true;
            this.lblMandas.Location = new System.Drawing.Point(63, 52);
            this.lblMandas.Name = "lblMandas";
            this.lblMandas.Size = new System.Drawing.Size(48, 13);
            this.lblMandas.TabIndex = 4;
            this.lblMandas.Text = "Mandas:";
            // 
            // lblRecibes
            // 
            this.lblRecibes.AutoSize = true;
            this.lblRecibes.Location = new System.Drawing.Point(63, 88);
            this.lblRecibes.Name = "lblRecibes";
            this.lblRecibes.Size = new System.Drawing.Size(49, 13);
            this.lblRecibes.TabIndex = 5;
            this.lblRecibes.Text = "Recibes:";
            // 
            // txtBoxMandas
            // 
            this.txtBoxMandas.Location = new System.Drawing.Point(125, 52);
            this.txtBoxMandas.Name = "txtBoxMandas";
            this.txtBoxMandas.ReadOnly = true;
            this.txtBoxMandas.Size = new System.Drawing.Size(382, 20);
            this.txtBoxMandas.TabIndex = 6;
            // 
            // txtBoxRecibes
            // 
            this.txtBoxRecibes.Location = new System.Drawing.Point(125, 85);
            this.txtBoxRecibes.Name = "txtBoxRecibes";
            this.txtBoxRecibes.ReadOnly = true;
            this.txtBoxRecibes.Size = new System.Drawing.Size(382, 20);
            this.txtBoxRecibes.TabIndex = 7;
            // 
            // Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpBoxCliente);
            this.Name = "Cliente";
            this.Text = "Cliente";
            this.Load += new System.EventHandler(this.Cliente_Load);
            this.grpBoxCliente.ResumeLayout(false);
            this.grpBoxCliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxMessage;
        private System.Windows.Forms.GroupBox grpBoxCliente;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.TextBox txtBoxRecibes;
        private System.Windows.Forms.TextBox txtBoxMandas;
        private System.Windows.Forms.Label lblRecibes;
        private System.Windows.Forms.Label lblMandas;
    }
}