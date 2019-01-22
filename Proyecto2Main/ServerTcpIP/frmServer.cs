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

namespace ServerTcpIP
{
    public partial class frmServer : Form
    {
        #region Variables Globales
        TcpListener _Listener = null;
        TcpClient _Client = null;
        const Int32 _Port = 1013;
        const string _IP = "127.0.0.1";
        #endregion
        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public frmServer()
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
        private void frmServer_Load(object sender, EventArgs e)
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
                Byte[] bytes = new Byte[1024];
                String data = null;
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

                        // Buffer for reading data
                        Byte[] bytes = new Byte[256];
                        String data = null;

                        // Enter the listening loop.

                        data = null;

                        // Get a stream object for reading and writing
                        NetworkStream stream = _Client.GetStream();

                        int i;

                        // Loop to receive all the data sent by the client.
                        while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            // Translate data bytes to a ASCII string.
                            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                            if (txtBoxRecibes.InvokeRequired)
                            {
                                txtBoxRecibes.Invoke((MethodInvoker)delegate { txtBoxRecibes.Text = data; });
                            }
                            else
                            {
                                txtBoxRecibes.Text = data;
                            }


                            // Process the data sent by the client.
                            data = "Por la alianza!!";

                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                            // Send back a response.
                            stream.Write(msg, 0, msg.Length);
                            if (txtBoxMandas.InvokeRequired)
                            {
                                txtBoxMandas.Invoke((MethodInvoker)delegate { txtBoxMandas.Text = data; });
                            }
                            else
                            {
                                txtBoxMandas.Text = data;
                            }
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
