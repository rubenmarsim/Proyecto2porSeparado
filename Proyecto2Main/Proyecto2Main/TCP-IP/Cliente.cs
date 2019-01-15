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

namespace Proyecto2Main.TCP_IP
{
    public partial class Cliente : Form
    {
        #region Variables Globales
        const string _IP = "127.0.0.1";
        TcpClient _Client;
        const Int32 _Port = 5000;
        #endregion
        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Cliente()
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
        private void Cliente_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Evento que se ejecuta cuando pulsamos el boton enviar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            txtBoxMandas.Text = txtBoxMessage.Text;
        }
        /// <summary>
        /// Evento que se ejecuta cuando pulsamos el boton conectar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConectar_Click(object sender, EventArgs e)
        {
            Connect(_IP);
        }
        #endregion
        #region Methods
        /// <summary>
        /// Nos conecta con el server
        /// Nota: para que este cliente funcione necesitamos tener un TCPServer
        /// conectado a la misma ip especificada por el server, y la misma combinacion
        /// de puertos
        /// </summary>
        /// <param name="server">ip del server al que nos vamos a conectar</param>
        private void Connect(string server)
        {
            try
            {
                ///Creamos un TCPClient
                _Client = new TcpClient(server, _Port);
                ///Cerramos el cliente
                _Client.Close();
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }
        #endregion
    }
}
