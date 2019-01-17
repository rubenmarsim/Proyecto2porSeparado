using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteTcpIP
{
    public partial class frmCliente : Form
    {
        #region Variables Globales
        const string _IP = "127.0.0.1";
        TcpClient _Client;
        NetworkStream _Stream;
        const Int32 _Port = 5000;
        bool _CanSend;
        #endregion
        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public frmCliente()
        {
            InitializeComponent();
        }
        #endregion
        #region Events
        /// <summary>
        /// Evento que se ejecuta cuando carga el Form del cliente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCliente_Load(object sender, EventArgs e)
        {
            _CanSend = false;
        }
        /// <summary>
        /// Evento que se ejecuta cuando pulsamos el boton conectar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;            
            btnDisconnect.Enabled = true;
            _CanSend = true;
            VerificarSendButton();
        }
        /// <summary>
        /// Evento que se ejecuta cuando pulsamos el boton enviar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Evento que se ejecuta cuando pulsamos el boton desconectar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            btnConnect.Enabled = true;                        
            btnDisconnect.Enabled = false;
            _CanSend = false;
            VerificarSendButton();
            Disconnect();            
        }
        /// <summary>
        /// Evento que se ejecuta cuando cambia el textbox del message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxMessage_TextChanged(object sender, EventArgs e)
        {
            VerificarSendButton();
        }
        #endregion
        #region Methods
        private void Disconnect()
        {
            try
            {
                _Stream.Close();
                _Client.Close();
            }
            ///Ponemos el catch por si pulsan el boton desconectar antes que el de conectar
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }            
        }
        /// <summary>
        /// Verifica si se puede usar el boton de enviar o no
        /// </summary>
        private void VerificarSendButton()
        {
            if (txtBoxMessage.Text.Equals(string.Empty) || !_CanSend)
            {
                btnSend.Enabled = false;
            }
            else
            {
                btnSend.Enabled = true;
            }
        }
        #endregion

        
    }
}
