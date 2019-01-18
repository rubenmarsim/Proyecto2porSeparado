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
        const string _IP = "172.17.20.106";
        TcpClient _Client;
        NetworkStream _nStream;
        const Int32 _Port = 5000;
        bool _CanSend;
        string _ClientMessage = string.Empty;
        string _Resposta = string.Empty;
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
            _ClientMessage = txtBoxMessage.Text;
            txtBoxMandas.Text = txtBoxMessage.Text;
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
            Connect();
        }
        /// <summary>
        /// Evento que se ejecuta cuando pulsamos el boton enviar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            Conversiones();
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
        private void Connect()
        {
            //Creamos el TCPClient asociado el server
            _Client = new TcpClient(_IP, _Port);
            //Instanciamos un NetworkStream para leer y escribir a partir de GetStream
            _nStream = _Client.GetStream();
        }
        /// <summary>
        /// Convertimos los datos y los mandamos y
        /// preparamos el socket para que escuche la respuesta del server
        /// </summary>
        private void Conversiones()
        {
            //Convertimos un mensaje a un array de bytes
            byte[] dades = Encoding.ASCII.GetBytes(_ClientMessage);

            //Enviamos el mensaje al server
            _nStream.Write(dades, 0, dades.Length);

            //byte[] dades2 = Encoding.ASCII.GetBytes(_UserMessage);
            //_NS.Write(dades2, 0, dades2.Length);

            ///Recivimos la respuesta
            var dadaResposta = new byte[256];
            Int32 bytes = _nStream.Read(dadaResposta, 0, dadaResposta.Length);
            _Resposta = Encoding.ASCII.GetString(dadaResposta, 0, bytes);
        }
        /// <summary>
        /// Cerramos todo
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
