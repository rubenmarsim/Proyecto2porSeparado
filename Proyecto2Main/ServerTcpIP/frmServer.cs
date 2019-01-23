using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        /// <summary>
        /// Declaramos el TcpListener, este actua como server
        /// </summary>
        TcpListener _Listener = null;
        /// <summary>
        /// Declaramos el TcpClient, este actua como cliente
        /// </summary>
        TcpClient _Client = null;
        /// <summary>
        /// Declaramos el NetworkStream, que sirve para enviar 
        /// y recibir datos del host remoto
        /// </summary>
        NetworkStream _nStream;
        /// <summary>
        /// Declaramos el puerto el cual vamos a usar
        /// </summary>
        const Int32 _Port = 1013;
        /// <summary>
        /// Declaramos la ip del server al cual nos vamos a conectar
        /// </summary>
        const string _IP = "127.0.0.1";
        /// <summary>
        /// Declarmos el stream reader, para poder leer los ficheros
        /// </summary>
        StreamReader _strRFile;
        /// <summary>
        /// Declaramos una constante con el path del fichero que vamos a leer
        /// </summary>
        const string _PathCodigos = @"archivos/codigos.txt";
        const int _BufferSize = 1500;
        string _Status;
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
            ///y le asociamos el metodo ServerOn
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
                ///Convertimos la ip que tenemos guardada en un string
                ///a una ip hecha objeto
                IPAddress localAddr = IPAddress.Parse(_IP);
                ///Instanciamos el listener con la ip onjeto que acabamos de crear
                ///y el puerto como parametros
                _Listener = new TcpListener(localAddr, _Port);
                ///Iniciamos el listener
                _Listener.Start();
                ///Declaramos e instanciamos un array de bytes
                Byte[] bytes = new Byte[1024];
                ///declaramos un string en el cual vamos a guardar el mensaje
                String data = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ///iniciamos un bucle infinito, con el objetivo de que el server
            ///este escuchando constantemente
            while (true)
            {
                try
                {
                    ///si hay solicitudes de conexion pendientes hace todo esto,
                    ///sino simplemente sigue escuchando
                    if (_Listener.Pending())
                    {
                        ///Indicamos al Listener que acepte las solicitudes de
                        ///conexion pendiente de el TCPClient
                        _Client = _Listener.AcceptTcpClient();
                        ///indica si se debe llamar a un metodo de invocacion
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
                        ///declaramos un string llamado data, que vamos a usar despues
                        ///para obtener la respuesta
                        String data = null;

                        // Get a stream object for reading and writing
                        _nStream = _Client.GetStream();

                        int i;
                        
                        ///Iniciamos un bucle para recibir toda la info enviada por
                        ///el cliente constantemente
                        while ((i = _nStream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            ///pasamos los bytes a ASCII string
                            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                            ///indica si se debe llamar a un metodo de invocacion
                            if (txtBoxRecibes.InvokeRequired)
                            {
                                txtBoxRecibes.Invoke((MethodInvoker)delegate { txtBoxRecibes.Text = data; });
                            }
                            else
                            {
                                txtBoxRecibes.Text = data;
                            }
                            ///Una vez usada la variable data para recibir la respuesta
                            ///del cliente, la reutilizamos para poner el mensaje que
                            ///le vamos a mandar al server
                            data = "Por la alianza!!";
                            ///la pasamos de string a bytes
                            byte[] msg = System.Text.Encoding.ASCII.GetBytes(leerArchivos());
                            ///y se la enviamos al server
                            _nStream.Write(msg, 0, msg.Length);
                            ///indica si se debe llamar a un metodo de invocacion
                            if (txtBoxMandas.InvokeRequired)
                            {
                                txtBoxMandas.Invoke((MethodInvoker)delegate { txtBoxMandas.Text = leerArchivos(); });
                            }
                            else
                            {
                                txtBoxMandas.Text = leerArchivos() ;
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
        /// <summary>
        /// Leemos todo el fichero linea por line y lo vamos concatenando al total
        /// </summary>
        /// <returns>Devuelve todo lo que hay escrito en el fichero que hemos leido</returns>
        private string leerArchivos()
        {
            string line;
            string total = null;
            // Read the file and display it line by line.  
            _strRFile = new StreamReader(_PathCodigos);
            ///mientras que la linea sea diferende de null
            while ((line = _strRFile.ReadLine()) != null)
            {
                total = total + "\n" + line;

            }
            ///cerramos el streamreader
            _strRFile.Close();
            ///devolvemos el valor total del archivo leido
            return total;
        }
        public void ReceiveFiles(int portN)
        {
            TcpListener Listener = null;
            try
            {
                Listener = new TcpListener(IPAddress.Any, portN);
                Listener.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            byte[] RecData = new byte[_BufferSize];
            int RecBytes;

            for (; ; )
            {
                TcpClient client = null;
                NetworkStream netstream = null;
                _Status = string.Empty;
                try
                {
                    string message = "Accept the Incoming File ";
                    string caption = "Incoming Connection";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result;

                    if (Listener.Pending())
                    {
                        client = Listener.AcceptTcpClient();
                        netstream = client.GetStream();
                        _Status = "Connected to a client\n";
                        result = MessageBox.Show(message, caption, buttons);

                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            string SaveFileName = string.Empty;
                            SaveFileDialog DialogSave = new SaveFileDialog();
                            DialogSave.Filter = "All files (*.*)|*.*";
                            DialogSave.RestoreDirectory = true;
                            DialogSave.Title = "Where do you want to save the file?";
                            DialogSave.InitialDirectory = @"C:/";
                            if (DialogSave.ShowDialog() == DialogResult.OK)
                                SaveFileName = DialogSave.FileName;
                            if (SaveFileName != string.Empty)
                            {
                                int totalrecbytes = 0;
                                FileStream Fs = new FileStream
                 (SaveFileName, FileMode.OpenOrCreate, FileAccess.Write);
                                while ((RecBytes = netstream.Read
                     (RecData, 0, RecData.Length)) > 0)
                                {
                                    Fs.Write(RecData, 0, RecBytes);
                                    totalrecbytes += RecBytes;
                                }
                                Fs.Close();
                            }
                            netstream.Close();
                            client.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //netstream.Close();
                }
            }
        }
        #endregion
    }
}
