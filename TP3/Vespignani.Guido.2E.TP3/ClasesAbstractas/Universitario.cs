using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Campos

        private int legajo;

        #endregion

        #region Constructores

        public Universitario():base()
        {
        }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region Metodos

        protected abstract string ParticiparEnClase();

        protected virtual string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine(base.ToString());
            datos.AppendLine("LEGAJO NúMERO: "+ this.legajo.ToString());
            return datos.ToString();
        }

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if ((pg1.GetType() == pg2.GetType()) && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI))
                return true;
            return false;
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        public override bool Equals(object obj)
        {
            if (obj is Universitario)
                return this == ((Universitario)obj);
            return false;
        }

        #endregion

    }
}
