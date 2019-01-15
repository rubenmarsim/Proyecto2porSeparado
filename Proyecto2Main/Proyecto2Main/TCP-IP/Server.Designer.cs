namespace Proyecto2Main.TCP_IP
{
    partial class Server
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
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.lblClientStatus = new System.Windows.Forms.Label();
            this.grpBoxServer = new System.Windows.Forms.GroupBox();
            this.lblRecibes = new System.Windows.Forms.Label();
            this.lblMandas = new System.Windows.Forms.Label();
            this.txtBoxRecibes = new System.Windows.Forms.TextBox();
            this.txtBoxMandas = new System.Windows.Forms.TextBox();
            this.grpBoxServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.Location = new System.Drawing.Point(27, 33);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(69, 13);
            this.lblServerStatus.TabIndex = 0;
            this.lblServerStatus.Text = "Server status";
            // 
            // lblClientStatus
            // 
            this.lblClientStatus.AutoSize = true;
            this.lblClientStatus.Location = new System.Drawing.Point(27, 62);
            this.lblClientStatus.Name = "lblClientStatus";
            this.lblClientStatus.Size = new System.Drawing.Size(66, 13);
            this.lblClientStatus.TabIndex = 1;
            this.lblClientStatus.Text = "Client Status";
            // 
            // grpBoxServer
            // 
            this.grpBoxServer.Controls.Add(this.txtBoxMandas);
            this.grpBoxServer.Controls.Add(this.txtBoxRecibes);
            this.grpBoxServer.Controls.Add(this.lblMandas);
            this.grpBoxServer.Controls.Add(this.lblRecibes);
            this.grpBoxServer.Controls.Add(this.lblClientStatus);
            this.grpBoxServer.Controls.Add(this.lblServerStatus);
            this.grpBoxServer.Location = new System.Drawing.Point(44, 35);
            this.grpBoxServer.Name = "grpBoxServer";
            this.grpBoxServer.Size = new System.Drawing.Size(574, 299);
            this.grpBoxServer.TabIndex = 2;
            this.grpBoxServer.TabStop = false;
            this.grpBoxServer.Text = "Servidor";
            // 
            // lblRecibes
            // 
            this.lblRecibes.AutoSize = true;
            this.lblRecibes.Location = new System.Drawing.Point(27, 115);
            this.lblRecibes.Name = "lblRecibes";
            this.lblRecibes.Size = new System.Drawing.Size(49, 13);
            this.lblRecibes.TabIndex = 2;
            this.lblRecibes.Text = "Recibes:";
            // 
            // lblMandas
            // 
            this.lblMandas.AutoSize = true;
            this.lblMandas.Location = new System.Drawing.Point(27, 150);
            this.lblMandas.Name = "lblMandas";
            this.lblMandas.Size = new System.Drawing.Size(48, 13);
            this.lblMandas.TabIndex = 3;
            this.lblMandas.Text = "Mandas:";
            // 
            // txtBoxRecibes
            // 
            this.txtBoxRecibes.Location = new System.Drawing.Point(105, 115);
            this.txtBoxRecibes.Name = "txtBoxRecibes";
            this.txtBoxRecibes.ReadOnly = true;
            this.txtBoxRecibes.Size = new System.Drawing.Size(420, 20);
            this.txtBoxRecibes.TabIndex = 4;
            // 
            // txtBoxMandas
            // 
            this.txtBoxMandas.Location = new System.Drawing.Point(105, 147);
            this.txtBoxMandas.Name = "txtBoxMandas";
            this.txtBoxMandas.ReadOnly = true;
            this.txtBoxMandas.Size = new System.Drawing.Size(420, 20);
            this.txtBoxMandas.TabIndex = 5;
            this.txtBoxMandas.Text = "Por la alianza!";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpBoxServer);
            this.Name = "Server";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Server_Load);
            this.grpBoxServer.ResumeLayout(false);
            this.grpBoxServer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.Label lblClientStatus;
        private System.Windows.Forms.GroupBox grpBoxServer;
        private System.Windows.Forms.TextBox txtBoxMandas;
        private System.Windows.Forms.TextBox txtBoxRecibes;
        private System.Windows.Forms.Label lblMandas;
        private System.Windows.Forms.Label lblRecibes;
    }
}