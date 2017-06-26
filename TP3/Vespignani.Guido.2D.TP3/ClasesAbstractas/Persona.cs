using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{
   
    public abstract class Persona
    {
        #region Enumerado

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #endregion

        #region Campos

        private string _apellido;
        private int _dni;
        private string _nombre;
        private ENacionalidad _nacionalidad;

        #endregion

        #region Propiedades

        public ENacionalidad Nacionalidad
        {
            get { return this._nacionalidad; }
            set { this._nacionalidad = value; }
        }
        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = ValidarNombreApellido(value); }
        }
        public int DNI
        {
            get { return this._dni; }
            set { this._dni = ValidarDni(this.Nacionalidad, value); }
        }
        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = ValidarNombreApellido(value); }
        }
        public string StringToDNI 
        { 
            set {this._dni = ValidarDni(this.Nacionalidad,value); } 
        }

        #endregion

        #region Constructores

        public Persona()
        {
        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
        }

        #endregion

        #region Metodos
        
        /// <summary>
        /// Hace publicos los datos de la persona. 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder persona = new StringBuilder();
            persona.AppendLine("NOMBRE COMPLETO: " + this._apellido + ", " + this._nombre);
            persona.AppendLine("NACIONALIDAD: " + this._nacionalidad.ToString());
            return persona.ToString();
        }

        /// <summary>
        /// Dato valido Mayor a 0.
        /// Argentino valido menor a 90.000.000
        /// Extranjero valido mayor a 89.999.999
        /// </summary>
        /// <param name="nacionalidad"></param> Determina la nacionalidad
        /// <param name="dato"></param> dni a validar
        /// <returns></returns> Retorna un dni con valores correctos.
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (dato <= 0)
            {
                throw new DniInvalidoException();
            }
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato > 89999999)
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 90000000)
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
            }
            return dato;
        }

        /// <summary>
        /// Verifica que el dato sea un numero y luego invoca a Validardni(int)
        /// </summary>
        /// <param name="nacionalidad"></param> Determina la nacionalidad
        /// <param name="dato"></param> dni a validar
        /// <returns></returns> Retorna un dni correcto.
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int aux;
            if (!(int.TryParse(dato, out aux)))
            {
                throw new DniInvalidoException();
            }
            return this.ValidarDni(nacionalidad, aux);
        }

        /// <summary>
        /// Valida que el nombre o apellido sean solo letras y tenga un tamaño correcto
        /// </summary>
        /// <param name="dato"></param> apellido o nombre a validar
        /// <returns></returns> devuelve un nombre o apellido correcto.
        private string ValidarNombreApellido(string dato)
        {
            if(Regex.IsMatch(dato,"[a-zA-z]{2,50}"))
                return dato;
            else
                return "";
        }
        #endregion
    }
}
