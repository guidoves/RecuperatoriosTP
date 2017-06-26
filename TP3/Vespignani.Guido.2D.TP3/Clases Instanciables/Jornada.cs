using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        #region Campos

        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        #endregion

        #region Propiedades

        public List<Alumno> Alumnos
        {
            get { return this._alumnos; }
            set { this._alumnos = value; }
        }
        public Universidad.EClases Clase
        {
            get { return this._clase; }
            set { this._clase = value; } 
        }
        public Profesor Instructor
        {
            get { return this._instructor; }
            set { this._instructor = value; } 
        }

        #endregion

        #region Constructores

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases clase, Profesor instructor):this()
        {
            Clase = clase;
            Instructor = instructor;
        }

        #endregion

        #region Metodos

        public static string Leer()
        {
            try
            {
                string retorno;
                Texto texto = new Texto();
                texto.leer(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt",out retorno);
                return retorno;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
                return "";
            }
        }

        public static  bool Guardar(Jornada jornada)
        {
            try
            {
                Texto texto = new Texto();
                texto.guardar(AppDomain.CurrentDomain.BaseDirectory + "Jornada.txt", jornada.ToString());
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
                return false;
            }
            
            
        }
        public override string ToString()
        {
            StringBuilder jornada = new StringBuilder();
            jornada.Append("CLASE DE " + this._clase.ToString() + " POR " + this._instructor.ToString());
            jornada.AppendLine("ALUMNOS:");
            foreach (Alumno item in this._alumnos)
            {
                jornada.AppendLine(item.ToString());
            }
            return jornada.ToString();
        }
        
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno item in j._alumnos)
            {
                if (item == a)
                    return true;
            }
            return false;
        }
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
                j._alumnos.Add(a);
            return j;
        }

        #endregion
    }
}
