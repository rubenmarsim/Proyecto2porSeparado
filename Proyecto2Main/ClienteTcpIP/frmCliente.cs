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
        NetworkStream _nStream;
        const Int32 _Port = 1013;
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
            ConnectandSend(_IP, txtBoxMessage.Text);
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
        /// <summary>
        /// Nos conectamos al server y le mandamos un mensaje
        /// </summary>
        /// <param name="server">IP del server al que nos vamos a conectar</param>
        /// <param name="message">mensaje que vamos a enviar</param>
        private void ConnectandSend(string server, string message)
        {
            try
            {
                _Client = new TcpClient(server, _Port);
                Byte[] data = Encoding.ASCII.GetBytes(message);

                _nStream = _Client.GetStream();
                _nStream.Write(data, 0, data.Length);
                if (txtBoxMandas.InvokeRequired)
                {
                    txtBoxMandas.Invoke((MethodInvoker)delegate { txtBoxMandas.Text = txtBoxMessage.Text; });
                }
                else
                {
                    txtBoxMandas.Text = txtBoxMessage.Text;
                }
                data = new byte[1024];
                string responseData = string.Empty;
                Int32 bytes = _nStream.Read(data, 0, data.Length);
                if (txtBoxRecibes.InvokeRequired)
                {
                    txtBoxRecibes.Invoke((MethodInvoker)delegate { txtBoxRecibes.Text = responseData; });
                }
                else
                {
                    txtBoxRecibes.Text = responseData;
                }
                _nStream.Close();
                _Client.Close();
            }catch(SocketException e)
            {
                MessageBox.Show(e.Message);
            }        
        }
        /// <summary>
        /// Parar todo
        /// </summary>
        private void Disconnect()
        {
            try
            {
                _nStream.Close();
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
            _CanSend = true;
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
