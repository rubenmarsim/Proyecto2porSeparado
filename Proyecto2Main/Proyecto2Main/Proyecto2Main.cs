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
        const string _PathArchivos = @"archivos\";
        const string _NameArchive = @"PruebaZIP.txt";      
        const string _PathExtract = @"archivos\extract";
        const string _Extension = ".zip";
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

        private void Proyecto2Main_Load(object sender, EventArgs e)
        {
            _FileInfo = new FileInfo(_PathArchivos+_NameArchive);
        }


        #region ZIP UNZIP

        #region Events
        private void btnZIP_Click(object sender, EventArgs e)
        {
            Compress(_FileInfo);
        }

        private void btnUNZIP_Click(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region Methods
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
                if ((File.GetAttributes(fi.FullName) & FileAttributes.Hidden)!= FileAttributes.Hidden & fi.Extension != _Extension)
                {
                    //Crea el archivo comprimido.
                    using (FileStream outFile = File.Create(fi.FullName + _Extension))
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
        #endregion

        #endregion

        #region Messages

        #endregion

        #region Codes

        #endregion
    }
}
