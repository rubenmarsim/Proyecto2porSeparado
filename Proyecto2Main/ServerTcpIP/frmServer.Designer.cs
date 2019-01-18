namespace ServerTcpIP
{
    partial class frmServer
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpBoxServer = new System.Windows.Forms.GroupBox();
            this.txtBoxMandas = new System.Windows.Forms.TextBox();
            this.txtBoxRecibes = new System.Windows.Forms.TextBox();
            this.lblMandas = new System.Windows.Forms.Label();
            this.lblRecibes = new System.Windows.Forms.Label();
            this.lblClientStatus = new System.Windows.Forms.Label();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.btnApagar = new System.Windows.Forms.Button();
            this.grpBoxServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxServer
            // 
            this.grpBoxServer.Controls.Add(this.btnApagar);
            this.grpBoxServer.Controls.Add(this.txtBoxMandas);
            this.grpBoxServer.Controls.Add(this.txtBoxRecibes);
            this.grpBoxServer.Controls.Add(this.lblMandas);
            this.grpBoxServer.Controls.Add(this.lblRecibes);
            this.grpBoxServer.Controls.Add(this.lblClientStatus);
            this.grpBoxServer.Controls.Add(this.lblServerStatus);
            this.grpBoxServer.Location = new System.Drawing.Point(12, 12);
            this.grpBoxServer.Name = "grpBoxServer";
            this.grpBoxServer.Size = new System.Drawing.Size(383, 197);
            this.grpBoxServer.TabIndex = 0;
            this.grpBoxServer.TabStop = false;
            this.grpBoxServer.Text = "Server";
            // 
            // txtBoxMandas
            // 
            this.txtBoxMandas.Location = new System.Drawing.Point(80, 135);
            this.txtBoxMandas.Name = "txtBoxMandas";
            this.txtBoxMandas.ReadOnly = true;
            this.txtBoxMandas.Size = new System.Drawing.Size(263, 20);
            this.txtBoxMandas.TabIndex = 7;
            this.txtBoxMandas.Text = "Por la alianza!";
            // 
            // txtBoxRecibes
            // 
            this.txtBoxRecibes.Location = new System.Drawing.Point(80, 102);
            this.txtBoxRecibes.Name = "txtBoxRecibes";
            this.txtBoxRecibes.ReadOnly = true;
            this.txtBoxRecibes.Size = new System.Drawing.Size(263, 20);
            this.txtBoxRecibes.TabIndex = 6;
            // 
            // lblMandas
            // 
            this.lblMandas.AutoSize = true;
            this.lblMandas.Location = new System.Drawing.Point(26, 138);
            this.lblMandas.Name = "lblMandas";
            this.lblMandas.Size = new System.Drawing.Size(48, 13);
            this.lblMandas.TabIndex = 3;
            this.lblMandas.Text = "Mandas:";
            // 
            // lblRecibes
            // 
            this.lblRecibes.AutoSize = true;
            this.lblRecibes.Location = new System.Drawing.Point(25, 105);
            this.lblRecibes.Name = "lblRecibes";
            this.lblRecibes.Size = new System.Drawing.Size(49, 13);
            this.lblRecibes.TabIndex = 2;
            this.lblRecibes.Text = "Recibes:";
            // 
            // lblClientStatus
            // 
            this.lblClientStatus.AutoSize = true;
            this.lblClientStatus.Location = new System.Drawing.Point(25, 60);
            this.lblClientStatus.Name = "lblClientStatus";
            this.lblClientStatus.Size = new System.Drawing.Size(66, 13);
            this.lblClientStatus.TabIndex = 1;
            this.lblClientStatus.Text = "Client Status";
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.Location = new System.Drawing.Point(20, 29);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(71, 13);
            this.lblServerStatus.TabIndex = 0;
            this.lblServerStatus.Text = "Server Status";
            // 
            // btnApagar
            // 
            this.btnApagar.Location = new System.Drawing.Point(280, 168);
            this.btnApagar.Name = "btnApagar";
            this.btnApagar.Size = new System.Drawing.Size(97, 23);
            this.btnApagar.TabIndex = 8;
            this.btnApagar.Text = "Apagar Server";
            this.btnApagar.UseVisualStyleBackColor = true;
            //this.btnApagar.Click += new System.EventHandler(this.btnApagar_Click);
            // 
            // frmServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpBoxServer);
            this.Name = "frmServer";
            this.Text = "frmServer";
            this.Load += new System.EventHandler(this.frmServer_Load);
            this.grpBoxServer.ResumeLayout(false);
            this.grpBoxServer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxServer;
        private System.Windows.Forms.TextBox txtBoxMandas;
        private System.Windows.Forms.TextBox txtBoxRecibes;
        private System.Windows.Forms.Label lblMandas;
        private System.Windows.Forms.Label lblRecibes;
        private System.Windows.Forms.Label lblClientStatus;
        private System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.Button btnApagar;
    }
}

