using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Archivos;
using Excepciones;
using EntidadesAbstractas;
using EntidadesInstanciables;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        ///  Test DniInvalidoException dni menor a 1.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDniMenor()
        {
            Profesor profesor = new Profesor(5, "Marcelo", "Gallardo", "-4", Persona.ENacionalidad.Argentino);
        }

        /// <summary>
        ///  Test DniInvalidoException dni letras.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestDniLetras()
        {
            Profesor profesor = new Profesor(5, "Marcelo", "Gallardo", "sarasa", Persona.ENacionalidad.Argentino);
        }

        /// <summary>
        ///  Test NacionalidadInvalidaException dni argentino mayor a 89.999.999
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void ArgentinoInvalido()
        {
            Profesor profesor = new Profesor(4, "Lionel", "Messi", "105309284", Persona.ENacionalidad.Argentino);
        }

        /// <summary>
        ///  Test NacionalidadInvalidaException dni extranjero menor a 89.999.999
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void ExtranjeroInvalido()
        {
            Profesor profesor = new Profesor(4, "Lionel", "Messi", "23456980", Persona.ENacionalidad.Extranjero);
        }

        /// <summary>
        ///  Test SinProfesorException Universidad no tiene profesor para dar la clase
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void SinProfesor()
        {
            Universidad g = new Universidad();
            g += Universidad.EClases.Programacion;
        }

        /// <summary>
        ///  Test AlumnoRepetido Universidad ya tiene un alumno igual.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void AlumnoRepetido()
        {
            Universidad g = new Universidad();
            Alumno a = new Alumno(2, "Ariel", "Ortega", "30334921", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Alumno b = new Alumno(2, "Ariel", "Ortega", "30334921", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            g += a;
            g += b;
        }

        /// <summary>
        ///  Test Universidad Los valores de las propiedades no sean null.
        /// </summary>
        [TestMethod]
        public void TestUniversidad()
        {
            Universidad universidad = new Universidad();
            if (universidad.Alumnos == null || universidad.Instructores == null || universidad.Jornadas == null)
                Assert.Fail();
            
        }

    }
}
