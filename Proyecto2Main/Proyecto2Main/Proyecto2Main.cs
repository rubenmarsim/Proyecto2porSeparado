using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;

namespace Proyecto2Main
{
    public partial class Proyecto2Main : Form
    {
        #region Variables e instancias Globales
        #region ZIP y UNZIP
        const string _PathToCompress = @"archivos/compress";
        const string _PathCompressedArchive = @"archivos/ArchivosZIP.zip";
        const string _PathToDecompress = @"archivos\extract";
        FileInfo _FileInfo;
        #endregion
        #region Codes
        public string[] _oArrayAbecedario;
        string[] _letrasRandom;
        #endregion
        #endregion

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Proyecto2Main()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Evento que se ejecuta cuando carga el Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Proyecto2Main_Load(object sender, EventArgs e)
        {
            #region ZIP y UNZIP
            ///instanciamos el FileInfo con el parametro filename, en el cual
            ///pasamos el path y el nombre del archivo
            _FileInfo = new FileInfo(@"archivos\PruebaZIP.txt");
            #endregion

            #region Codes
            ///llenamos el array con las letras del abecedario
            _oArrayAbecedario = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            #endregion
        }

        #region ZIP UNZIP

        #region Events        
        /// <summary>
        /// Evento que se ejecuta cuando pulsamos el boton de comprimir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZIP_Click(object sender, EventArgs e)
        {       
            Comprimir();
        }
        /// <summary>
        /// Evento que se ejecuta al pulsar el boton de descomprimir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUNZIP_Click(object sender, EventArgs e)
        {
            Descomprimir();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Metodo para comprimir todo lo que hay en la carpeta compress
        /// </summary>
        private void Comprimir()
        {
            try
            {
                if (!Directory.Exists(_PathToCompress)) Directory.CreateDirectory(_PathToCompress);
                ZipFile.CreateFromDirectory(_PathToCompress, _PathCompressedArchive);
            }
            catch (IOException)
            {
                File.Delete(_PathCompressedArchive);
                ZipFile.CreateFromDirectory(_PathToCompress, _PathCompressedArchive);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("No tienes acceso a ese directorio");
            }
        }
        /// <summary>
        /// Metodo para descomprimir todo lo que hay en el archivo ArchivosZIP.zip
        /// </summary>
        private void Descomprimir()
        {
            try
            {
                ZipFile.ExtractToDirectory(_PathCompressedArchive, _PathToDecompress);
            }
            catch (IOException)
            {
                string[] FilePath = Directory.GetFiles(_PathToDecompress);
                string[] carpetas = Directory.GetDirectories(_PathToDecompress);
                foreach (string fp in FilePath) File.Delete(fp);
                foreach (string cp in carpetas) Directory.Delete(cp);
                ZipFile.ExtractToDirectory(_PathCompressedArchive, _PathToDecompress);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("No tienes acceso a ese directorio");
            }
            
        }

        #region Metodo Chungo
        /// <summary>
        /// Este metodo coge el fichero lo comprime y 
        /// lo copia en el lugar que indiquemos
        /// </summary>
        /// <param name="fi">Objeto del archivo que vamos a comprimir</param>
        private void Compress(FileInfo fi)
        {
            using (FileStream inFile = fi.OpenRead())
            {
                //Este if evita comprimir archivos ocultos y ya comprimidos.
                if ((File.GetAttributes(fi.FullName) & FileAttributes.Hidden)!= FileAttributes.Hidden & fi.Extension != ".zip")
                {
                    //Crea el archivo comprimido.
                    using (FileStream outFile = File.Create(fi.FullName + ".zip"))
                    {
                        //Copia el archivo fuente en el compression stream
                        using (GZipStream Compress = new GZipStream(outFile, CompressionMode.Compress))
                        {
                            inFile.CopyTo(Compress);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fi">Objeto del archivo que vamos a descomprimir</param>
        public static void Decompress(FileInfo fi)
        {
            using (FileStream originalFileStream = fi.OpenRead())
            {
                string currentFileName = fi.FullName;
                string newFileName = currentFileName.Remove(currentFileName.Length - fi.Extension.Length);

                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                    }
                }
            }
        }
        #endregion

        #endregion

        #endregion

        #region TCP-IP
        #region Events
        private void btnTCPIP_Click(object sender, EventArgs e)
        {
            try
            {
                ServerTcpIP.frmServer frmServer = new ServerTcpIP.frmServer();
                ClienteTcpIP.frmCliente frmCliente = new ClienteTcpIP.frmCliente();
                frmServer.Show();
                frmCliente.Show();
            }
            catch (ObjectDisposedException)
            {
                //MessageBox.Show("Reinicia el programa para acceder a esta opcion de nuevo");
                DialogResult dialogResult = MessageBox.Show("Reinicia el programa para acceder a esta opcion de nuevo", "Reiniciar?!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }
        #endregion
        #endregion

        #region Codes
        #region Events
        /// <summary>
        /// Evento que se ejecuta cuando pulsamos el boton de generar archivos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerateArchieves_Click(object sender, EventArgs e)
        {
            EncriptarTXT();
        }
        /// <summary>
        /// Evento que se ejecuta cuando pulsamos el boton descomprimir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDescifrar_Click(object sender, EventArgs e)
        {
            DesencriptarTXT();
        }
        #endregion
        #region Methods
        /// <summary>
        /// Metodo para encriptar archivos TXT
        /// </summary>
        public void EncriptarTXT()
        {
            crearFicheros();
        }
        /// <summary>
        /// Metodo para desencriptar archivos TXT
        /// </summary>
        public void DesencriptarTXT()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numeroFitxer">numero de fichero que estamos creando</param>
        /// <returns></returns>
        public string [] crearLetras(int numeroFitxer)
        {
            ///array de string en el cual guardamos el millon de letras random que generamos
            _letrasRandom = new string[1000000];
            ///clase que genera numeros aleatorios
            Random oRandom = new Random();
            ///path y nombre con el cual vamos a guardar el fichero
            String rutaFi = "archivos/encriptacion/lletres" + numeroFitxer + ".txt";
            ///declaramos codi
            string codi = string.Empty;
            ///Instanciamos un StreamWriter con los parametros rutaFi que es donde se va a 
            ///escribir y con true para decirle que queremos codificar
            StreamWriter file = new StreamWriter(rutaFi, true);
            ///Se ejecuta el bucle un millon de veces ya que el array es de 1000000
            for(int i = 0; i < _letrasRandom.Length; i++)
            {
                ///Cogemos un numero random con la clase oRandom, y le decimos que 
                ///el valor minimo sea 0 y el maximo 25
                int numRandom = oRandom.Next(0, 25);
                ///Cogemos una letra del array del abecedario segun el numero random que nos ha tocado
                codi = _oArrayAbecedario[numRandom];
                ///escribimos la letra que hemos cogido en el archivo
                file.Write(codi);
                ///guardamos la letra random en un array
                _letrasRandom[i] = codi;
            }
            ///cerramos el archivo
            file.Close();
            ///devolvemos el array
            return _letrasRandom;
        }
        /// <summary>
        /// call me spaceman
        /// </summary>
        private void XifrarLetraNum()
        {

        }
        /// <summary>
        /// Metodo para crear ficheros con letras generadas aleatoriamente,
        /// para ello declaramos un array donde vamos a guardar las letras, y 
        /// luego hacemos un for en el cual indicamos que se haga 5 veces y 
        /// llamamos al metodo para crear el fichero, de esta forma se nos van 
        /// a crear 5 ficheros con 1000000 de letras cada uno
        /// </summary>
        private void crearFicheros()
        {
            _letrasRandom = new string[16000000];
            for (int i=1; i<5; i++)
            {
                _letrasRandom = crearLetras(i);
            }
        }
        #endregion
        #endregion
    }
}
