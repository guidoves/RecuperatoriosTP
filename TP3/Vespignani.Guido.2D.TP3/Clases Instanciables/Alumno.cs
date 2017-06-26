using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;


namespace EntidadesInstanciables
{
    public sealed class Alumno : Universitario
    {

        #region Enumerado
        
        public enum EEstadoCuenta
        {
            Becado,
            Deudor,
            AlDia
        }

        #endregion

        #region Campos

        private Universidad.EClases _clasesQueToma;
        private EEstadoCuenta _estadoCuenta;

        #endregion

        #region Constructores

        public Alumno():base()
        {
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesQueToma = clasesQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases clasesQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, clasesQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Metodos

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (a._clasesQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
                return true;
            return false;
        }
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if (a._clasesQueToma != clase)
                return true;
            return false;
        }

        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();
            datos.AppendLine(base.MostrarDatos());
            if (this._estadoCuenta == EEstadoCuenta.AlDia)
            {
                datos.AppendLine("ESTADO DE CUENTA: " + "Cuota al día");
            }
            else if (this._estadoCuenta == EEstadoCuenta.Deudor)
            {
                datos.AppendLine("ESTADO DE CUENTA: " + "Cuota pendiente");
            }
            else
            {
                datos.AppendLine("ESTADO DE CUENTA: " + this._estadoCuenta);
            }
            datos.Append(this.ParticiparEnClase());
            return datos.ToString();
        }
        
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this._clasesQueToma.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        #endregion
    }
}
