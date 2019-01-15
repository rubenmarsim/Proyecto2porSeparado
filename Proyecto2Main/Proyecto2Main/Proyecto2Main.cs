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

        #endregion

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Proyecto2Main()
        {
            InitializeComponent();
        }

        #region ZIP UNZIP

        #region Events
        /// <summary>
        /// Evento que se ejecuta cuando carga el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Proyecto2Main_Load(object sender, EventArgs e)
        {
            _FileInfo = new FileInfo(@"archivos\PruebaZIP.txt");
        }
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
                foreach (string fp in FilePath) File.Delete(fp);
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

        #region Messages

        #endregion

        #region Codes

        #endregion
    }
}
