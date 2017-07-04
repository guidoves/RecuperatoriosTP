using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string archivo;

        public Texto(string archivo)
        {
            this.archivo = archivo;
        }

        public bool guardar(string datos)
        {
            try
            {
                StreamWriter s = new StreamWriter(this.archivo,true);
                s.WriteLine(datos);
                s.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool leer(out List<string> datos)
        {
            datos = new List<string>();
            try
            {
                StreamReader r = new StreamReader(this.archivo);
  
                
                while (!r.EndOfStream)
                {
                    datos.Add(r.ReadLine());
                }

                r.Close();
                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }
    }
}
