using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerTcpIP
{
    public partial class frmServer : Form
    {
        #region Variables Globales
        TcpListener _Listener;
        TcpClient _Client;
        const Int32 _Port = 5000;
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
        /// <summary>
        /// Evento que se ejecuta cuando carga el Form del Server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmServer_Load(object sender, EventArgs e)
        {
            lblServerStatus.Text = "Server is Running...";
            _Listener = new TcpListener(IPAddress.Any, _Port);
        }
    }
}
