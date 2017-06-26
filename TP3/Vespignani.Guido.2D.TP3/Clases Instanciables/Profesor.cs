using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;


namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region Campos

        private Queue<Universidad.EClases> _clasesDelDia;
        private static Random _random;

        #endregion

        #region Constructores

        static Profesor()
        {
            Profesor._random = new Random();
        }
        private Profesor()
            : base()
        {
           
        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        #endregion

        #region Metodos

        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                this._clasesDelDia.Enqueue((Universidad.EClases)Profesor._random.Next(0, 3));
            }
        }

        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();
            datos.Append(base.MostrarDatos());
            datos.AppendLine(this.ParticiparEnClase());
            return datos.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine("CLASES DEL DíA:");
            foreach (Universidad.EClases item in this._clasesDelDia)
            {
                s.AppendLine(item.ToString());
            }
            return s.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach (Universidad.EClases item in i._clasesDelDia)
            {
                if (item == clase)
                    return true;
            }
            return false;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion
    }
}
