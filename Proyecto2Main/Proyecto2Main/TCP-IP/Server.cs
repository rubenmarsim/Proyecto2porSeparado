using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto2Main.TCP_IP
{
    public partial class Server : Form
    {
        #region Variables Globales
        TcpListener _Listener = null;
        TcpClient _Client = null;
        const Int32 _Port = 5000;
        const string _IP = "127.0.0.1";
        #endregion
        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Server()
        {
            InitializeComponent();
        }
        #endregion
        #region Events
        /// <summary>
        /// Evento que se ejecuta cuando carga el Form del Server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Server_Load(object sender, EventArgs e)
        {
            ///Camciamos el texto del label para indicar que el server 
            ///esta activo
            lblServerStatus.Text = "Server is Running...";
            ///Creamos el hilo principal que vamos a usar en el server
            Thread serverThread = new Thread(ServerOn);
            ///Indicamos que va a ser un subproceso unico
            serverThread.SetApartmentState(ApartmentState.STA);
            ///Iniciamos el hilo
            serverThread.Start();
        }
        #endregion
        #region Methods
        /// <summary>
        /// Hace todos los procesos para que el server se inicie
        /// </summary>
        private void ServerOn()
        {
            try
            {                
                IPAddress localAddr = IPAddress.Parse(_IP);
                _Listener = new TcpListener(localAddr, _Port);
                ///Iniciamos el listener
                _Listener.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            while (true)
            {                
                try
                {
                    if (_Listener.Pending())
                    {
                        ///Indicamos al Listener que acepte las solicitudes de
                        ///conexion pendiente de el TCPClient
                        _Client = _Listener.AcceptTcpClient();

                        if (lblClientStatus.InvokeRequired)
                        {
                            lblClientStatus.Invoke((MethodInvoker)delegate { lblClientStatus.Text = "Connected client\n"; });
                        }
                        else
                        {
                            lblClientStatus.Text = "Connected client\n";
                        }                   
                        ///Cerramos el cliente
                        _Client.Close();
                    }
                }
                catch (SocketException e)
                {
                    Console.WriteLine("SocketException: {0}", e);
                }
            }
        }
        #endregion
    }
}
