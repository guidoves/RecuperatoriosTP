using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        private string html;
        private Uri direccion;

        public delegate void ProgresoCarga(int progreso);
        public delegate void Descarga(string descarga);

        public event ProgresoCarga pCarga;
        public event Descarga descarga;

        public Descargador(Uri direccion)
        {
            this.html = "";
            this.direccion = direccion;
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged ;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted ;
                cliente.DownloadStringAsync(this.direccion);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);  
            }
        }

        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.pCarga(e.ProgressPercentage);
        }
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                this.html = e.Result;
                this.descarga(this.html);
            }
            catch (Exception ex)
            {
                this.descarga(ex.InnerException.Message);
            }
        }
    }
}
