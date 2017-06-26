using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {

        public bool guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                XmlTextWriter wri = new XmlTextWriter(archivo, Encoding.UTF8);
                ser.Serialize(wri, datos);
                wri.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            
        }

        public bool leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                XmlTextReader red = new XmlTextReader(archivo);
                datos = (T)ser.Deserialize(red);
                red.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

    }
}
