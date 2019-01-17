namespace ClienteTcpIP
{
    partial class frmCliente
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
            this.grpBoxCliente = new System.Windows.Forms.GroupBox();
            this.txtBoxMessage = new System.Windows.Forms.TextBox();
            this.txtBoxRecibes = new System.Windows.Forms.TextBox();
            this.txtBoxMandas = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblRecibes = new System.Windows.Forms.Label();
            this.lblMandas = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.grpBoxCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBoxCliente
            // 
            this.grpBoxCliente.Controls.Add(this.btnDisconnect);
            this.grpBoxCliente.Controls.Add(this.btnSend);
            this.grpBoxCliente.Controls.Add(this.btnConnect);
            this.grpBoxCliente.Controls.Add(this.txtBoxMessage);
            this.grpBoxCliente.Controls.Add(this.txtBoxRecibes);
            this.grpBoxCliente.Controls.Add(this.txtBoxMandas);
            this.grpBoxCliente.Controls.Add(this.lblMessage);
            this.grpBoxCliente.Controls.Add(this.lblRecibes);
            this.grpBoxCliente.Controls.Add(this.lblMandas);
            this.grpBoxCliente.Location = new System.Drawing.Point(12, 12);
            this.grpBoxCliente.Name = "grpBoxCliente";
            this.grpBoxCliente.Size = new System.Drawing.Size(412, 196);
            this.grpBoxCliente.TabIndex = 0;
            this.grpBoxCliente.TabStop = false;
            this.grpBoxCliente.Text = "Cliente";
            // 
            // txtBoxMessage
            // 
            this.txtBoxMessage.Location = new System.Drawing.Point(120, 109);
            this.txtBoxMessage.Name = "txtBoxMessage";
            this.txtBoxMessage.Size = new System.Drawing.Size(270, 20);
            this.txtBoxMessage.TabIndex = 5;
            this.txtBoxMessage.TextChanged += new System.EventHandler(this.txtBoxMessage_TextChanged);
            // 
            // txtBoxRecibes
            // 
            this.txtBoxRecibes.Location = new System.Drawing.Point(120, 71);
            this.txtBoxRecibes.Name = "txtBoxRecibes";
            this.txtBoxRecibes.ReadOnly = true;
            this.txtBoxRecibes.Size = new System.Drawing.Size(270, 20);
            this.txtBoxRecibes.TabIndex = 4;
            // 
            // txtBoxMandas
            // 
            this.txtBoxMandas.Location = new System.Drawing.Point(120, 40);
            this.txtBoxMandas.Name = "txtBoxMandas";
            this.txtBoxMandas.ReadOnly = true;
            this.txtBoxMandas.Size = new System.Drawing.Size(270, 20);
            this.txtBoxMandas.TabIndex = 3;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(37, 117);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(53, 13);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "Message:";
            // 
            // lblRecibes
            // 
            this.lblRecibes.AutoSize = true;
            this.lblRecibes.Location = new System.Drawing.Point(37, 71);
            this.lblRecibes.Name = "lblRecibes";
            this.lblRecibes.Size = new System.Drawing.Size(49, 13);
            this.lblRecibes.TabIndex = 1;
            this.lblRecibes.Text = "Recibes:";
            // 
            // lblMandas
            // 
            this.lblMandas.AutoSize = true;
            this.lblMandas.Location = new System.Drawing.Point(37, 40);
            this.lblMandas.Name = "lblMandas";
            this.lblMandas.Size = new System.Drawing.Size(48, 13);
            this.lblMandas.TabIndex = 0;
            this.lblMandas.Text = "Mandas:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(234, 152);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(315, 152);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(27, 152);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 8;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // frmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpBoxCliente);
            this.Name = "frmCliente";
            this.Text = "frmCliente";
            this.Load += new System.EventHandler(this.frmCliente_Load);
            this.grpBoxCliente.ResumeLayout(false);
            this.grpBoxCliente.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxCliente;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblRecibes;
        private System.Windows.Forms.Label lblMandas;
        private System.Windows.Forms.TextBox txtBoxMessage;
        private System.Windows.Forms.TextBox txtBoxRecibes;
        private System.Windows.Forms.TextBox txtBoxMandas;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnConnect;
    }
}

