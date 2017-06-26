using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    
    public class Universidad
    {
        #region Enumerado

        public enum EClases
        {
            Laboratorio,
            Programacion,
            Legislacion,
            SPD
        }

        #endregion

        #region Campos

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        
        #endregion

        #region Propiedades

        public List<Alumno> Alumnos 
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }
        public List<Jornada> Jornadas 
        {
            get { return this.jornada; }
            set{ this.jornada = value; }
        }
        public Jornada this[int i] 
        {
            get
            {
                if (i >= this.jornada.Count || i < 0)
                    return null;
                else
                    return this.jornada[i];
            }
            set
            {
                if (i >= 0)
                {
                    if (i < this.jornada.Count)
                        this.jornada[i] = value;
                    else
                        this.jornada.Add(value);
                }
                else
                {
                    Console.WriteLine("Index inválido.");
                }
            }
        }

        #endregion

        #region Constructores

        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.jornada = new List<Jornada>();
            this.profesores = new List<Profesor>();
        }

        #endregion

        #region Metodos

        public static bool Guardar(Universidad gim)
        {
            Xml<Universidad> x = new Xml<Universidad>();
            return x.guardar(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", gim);
        }

        public static Universidad Leer(Universidad gim)
        {
            Universidad retorno;
            Xml<Universidad> x = new Xml<Universidad>();
            x.leer(AppDomain.CurrentDomain.BaseDirectory + "Universidad.xml", out retorno);
            return retorno;
        }

        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder universidad = new StringBuilder();
            universidad.AppendLine("JORNADA:");
            foreach (Jornada item in gim.Jornadas)
            {
                universidad.Append(item.ToString());
                universidad.AppendLine("<---------------------------------------------------------------->");
                universidad.AppendLine();
            }
            return universidad.ToString();
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno item in g.alumnos)
            {
                if (item == a)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor item in g.profesores)
            {
                if (item == i)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Profesor operator ==(Universidad g, EClases clase)
        {
            if (!(object.ReferenceEquals(g, null) || object.ReferenceEquals(clase, null)))
            {
                foreach (Profesor item in g.Instructores)
                {
                    if (item == clase)
                        return item;
                }
                throw new SinProfesorException();
            }
            throw new SinProfesorException();
        }

        public static Profesor operator !=(Universidad g, EClases clase)
        {
            if (!(object.ReferenceEquals(g, null) || object.ReferenceEquals(clase, null)))
            {
                foreach (Profesor item in g.Instructores)
                {
                    if (item != clase)
                        return item;
                }
                throw new SinProfesorException();
            }
            throw new SinProfesorException();
        }

        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (!(object.ReferenceEquals(g, null) || object.ReferenceEquals(a, null)))
            {
                foreach (Alumno item in g.Alumnos)
                {
                    if (item == a)
                        throw new AlumnoRepetidoException();
                }
                g.Alumnos.Add(a);
                return g;
            }
            return g;
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada = new Jornada(clase, g == clase);

            foreach (Alumno item in g.Alumnos)
            {
                if (item == clase)
                    jornada.Alumnos.Add(item);
            }
            g.Jornadas.Add(jornada);

            return g;
        }

        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (!(object.ReferenceEquals(g, null) || object.ReferenceEquals(i, null)))
            {
                foreach (Profesor item in g.Instructores)
                {
                    if (item == i)
                        return g;
                }
                g.Instructores.Add(i);
                return g;
            }
            return g;
        }

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        #endregion
    }
   
}
