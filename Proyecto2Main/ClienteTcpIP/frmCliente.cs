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
using System.Net;
using System.IO;

namespace ClienteTcpIP
{
    public partial class frmCliente : Form
    {        
        #region Variables Globales
        /// <summary>
        /// Declaramos la ip del server al cual nos vamos a conectar
        /// </summary>
        const string _IP = "127.0.0.1";
        /// <summary>
        /// Declaramos el TcpClient, este actua como cliente
        /// </summary>
        TcpClient _Client;
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
        /// declaramos un boolean para verificar si podemos pulsar el botn send o no
        /// </summary>
        bool _CanSend;
        /// <summary>
        /// Espacio de memoria
        /// </summary>
        const int _BufferSize = 1024;
        /// <summary>
        /// Path donde se encuentra el erchivo con los codigos
        /// </summary>
        const string _PathCodigos = @"archivos/codigos.txt";
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
            ///le damos valor false al bool cansend
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
            ///Llamamor al metodo ConnectandSend que conecta con el server y le envia datos
            //ConnectandSend(_IP, txtBoxMessage.Text);
            SendFiles(_PathCodigos, _IP, _Port);
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
                ///Instanciamos el TcpClient y le pasamos los parametros, que son
                ///la ip a donde se tiene que conectar y el puerto
                _Client = new TcpClient(server, _Port);
                ///pasamos el mensaje a bytes
                Byte[] data = Encoding.ASCII.GetBytes(message);
                ///Le decimos al networkstream que use el TcpClient
                _nStream = _Client.GetStream();
                ///Le decimos al networkstream que escriba el data que 
                ///hemos creado previamente
                _nStream.Write(data, 0, data.Length);
                ///indica si se debe llamar a un metodo de invocacion
                if (txtBoxMandas.InvokeRequired)
                {
                    txtBoxMandas.Invoke((MethodInvoker)delegate { txtBoxMandas.Text = txtBoxMessage.Text; });
                }
                else
                {
                    txtBoxMandas.Text = txtBoxMessage.Text;
                }
                ///instanciamos data como buffer
                data = new byte[1024];
                ///declaramos un string que nos va a servir para coger
                ///la respuesta del server
                string responseData = string.Empty;
                ///llenamos bytes con el buffer
                Int32 bytes = _nStream.Read(data, 0, data.Length);
                ///pasamos la respuesta obtenida en bytes a string
                responseData = Encoding.ASCII.GetString(data, 0, bytes);
                ///indica si se debe llamar a un metodo de invocacion
                if (txtBoxRecibes.InvokeRequired)
                {
                    txtBoxRecibes.Invoke((MethodInvoker)delegate { txtBoxRecibes.Text = responseData; });
                }
                else
                {
                    txtBoxRecibes.Text = responseData;
                }
                //_Client.SendFile();
                ///Cerramos el networkstream
                _nStream.Close();
                ///Cerramos el TcpClient
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
        /// <summary>
        /// Mandamos el archivo
        /// </summary>
        /// <param name="M">Path de los codigos</param>
        /// <param name="IPA">IP del server</param>
        /// <param name="PortN">puerto el cual usamos</param>
        public void SendFiles(string M, string IPA, Int32 PortN)
        {
            byte[] SendingBuffer = null;
            //TcpClient client = null;
            txtBoxMandas.Text = "";
            //NetworkStream netstream = null;
            try
            {
                ///Instanciamos el TcpClient y le pasamos los parametros, que son
                ///la ip a donde se tiene que conectar y el puerto
                _Client = new TcpClient(IPA, PortN);
                txtBoxMandas.Text = "Connected to the Server...\n";
                ///Le decimos al networkstream que use el TcpClient
                _nStream = _Client.GetStream();
                ///Instanciamos un filestream y le pasamos el fichero que tiene que abrir, y le indicamos que lo abra y lo lea
                FileStream Fs = new FileStream(M, FileMode.Open, FileAccess.Read);
                ///Hacemos los procesos para que funcione la progress bar
                int NoOfPackets = Convert.ToInt32
                    (Math.Ceiling(Convert.ToDouble(Fs.Length) / Convert.ToDouble(_BufferSize)));
                progressBar1.Maximum = NoOfPackets;
                int TotalLength = (int)Fs.Length, CurrentPacketLength, counter = 0;
                for (int i = 0; i < NoOfPackets; i++)
                {
                    if (TotalLength > _BufferSize)
                    {
                        CurrentPacketLength = _BufferSize;
                        TotalLength = TotalLength - CurrentPacketLength;
                    }
                    else
                        CurrentPacketLength = TotalLength;

                    SendingBuffer = new byte[CurrentPacketLength];
                    Fs.Read(SendingBuffer, 0, CurrentPacketLength);
                    _nStream.Write(SendingBuffer, 0, (int)SendingBuffer.Length);
                    if (progressBar1.Value >= progressBar1.Maximum)
                        progressBar1.Value = progressBar1.Minimum;

                    progressBar1.PerformStep();
                }
                ///Printamos lo que mandamos
                txtBoxMandas.Text = txtBoxMandas.Text + "Sent " + Fs.Length.ToString() + " bytes to the server";
                ///cerramos el filestream
                Fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ///cerramos todo
            finally
            {
                _nStream.Close();
                _Client.Close();
            }
        }
        #endregion


    }
}
