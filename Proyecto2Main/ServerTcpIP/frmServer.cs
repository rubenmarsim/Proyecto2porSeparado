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
        //TcpListener _Listener;
        //TcpClient _Client;
        //NetworkStream _nStream;
        const Int32 _Port = 5000;
        const string _IP = "172.17.20.106";
        string _ServerMessage = string.Empty;
        string _Resposta = string.Empty;
        //string _RespostaUser = string.Empty;
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
            Thread serverThread = new Thread(IniciarServer);
            ///Indicamos que va a ser un subproceso unico
            serverThread.SetApartmentState(ApartmentState.STA);
            ///Iniciamos el hilo
            serverThread.Start();

            IniciarServer();
            //Conversiones();
            //ApagarServer();
        }
        /// <summary>
        /// Evento que se ejecuta cuando pulsamos el boton apagar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void btnApagar_Click(object sender, EventArgs e)
        //{
        //    ApagarServer();
        //}
        #endregion
        #region Methods
        /// <summary>
        /// Iniciamos e instanciamos el server y demas componenetes necesarios,
        /// y los preparamos para que esten activados y a la escucha en el caso
        /// del server
        /// </summary>
        private void IniciarServer()
        {
            TcpListener Listener = null;
            try
            {
                Int32 port = 5000;
                IPAddress localAddr = IPAddress.Parse(_IP);
                Listener = new TcpListener(localAddr, port);
                Listener.Start();
                Byte[] bytes = new Byte[1024];
                String data = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            _ServerMessage = txtBoxMandas.Text;
            lblServerStatus.Text = "Server is Running...";
            try
            {
                TcpClient client = null;

                while (true)
                {
                    if (Listener.Pending())
                    {
                        client = Listener.AcceptTcpClient();
                        //_nStream = client.GetStream();
                        //byte[] buffer = new byte[1024];

                        //Conversiones();
                    }
                }
                
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
        }
        //private void Conversiones()
        //{
        //    ///Creamos un nuevo buffer, el cual usaremos para enviar datos,
        //    ///y lo llenamos con el mensaje creado previamente, ademas pasamos
        //    ///el mensaje a bytes
        //    byte[] nouBuffer = Encoding.ASCII.GetBytes(_ServerMessage);

        //    ///le decimos al NetworkStream que envie lo del nuevo buffer, y le pasamos
        //    ///los demas parametros que necesita
        //    _nStream.Write(nouBuffer, 0, nouBuffer.Length);

        //    ///Recivimos las respuestas
        //    var dadaResposta = new byte[256];
        //    Int32 bytes = _nStream.Read(dadaResposta, 0, dadaResposta.Length);
        //    _Resposta = Encoding.ASCII.GetString(dadaResposta, 0, bytes);
        //    txtBoxRecibes.Text = _Resposta;

        //    //var dadaResposta2 = new byte[256];
        //    //Int32 bytes2 = _nStream.Read(dadaResposta2, 0, dadaResposta2.Length);
        //    //_RespostaUser = Encoding.ASCII.GetString(dadaResposta2, 0, bytes2);
        //}
        ///// <summary>
        ///// Paramos todos los servicios del server
        ///// </summary>
        //private void ApagarServer()
        //{
        //    try
        //    {
        //        ///Cerramos el NetworkStream
        //        _nStream.Close();
        //        ///Cerramos el TCPClient
        //        _Client.Close();
        //        ///Paramos el TCPListener
        //        //_Listener.Stop();
        //    }
        //    catch(Exception e)
        //    {
        //        MessageBox.Show(e.Message);
        //    }            
        //}
        #endregion        
    }
}
