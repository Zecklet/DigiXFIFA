using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySoccer.Datos.GestionarCalendario;

namespace MySoccer.PruebaUnitaria
{
    /// <summary>
    /// Descripción resumida de SedeBaseDatosTest
    /// </summary>
    [TestClass]
    public class SedeBaseDatosTest
    {
        public SedeBaseDatosTest()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de las pruebas que proporciona
        ///información y funcionalidad para la serie de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de prueba adicionales
        //
        // Puede usar los siguientes atributos adicionales conforme escribe las pruebas:
        //
        // Use ClassInitialize para ejecutar el código antes de ejecutar la primera prueba en la clase
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup para ejecutar el código una vez ejecutadas todas las pruebas en una clase
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Usar TestInitialize para ejecutar el código antes de ejecutar cada prueba 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup para ejecutar el código una vez ejecutadas todas las pruebas
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestAgregarSede()
        {
            datSedeBaseDatos mPruebaSede = new datSedeBaseDatos();
            mPruebaSede.AgregarSede("Francia");
            mPruebaSede.AgregarSede("Brasil");
            mPruebaSede.AgregarSede("Costa Rica");
            mPruebaSede.AgregarSede("México");
            mPruebaSede.GetSedes();
        }

        [TestMethod]
        public void TestGetSedes()
        {
            datSedeBaseDatos mConexion = new datSedeBaseDatos();
            var mResultado = mConexion.GetSedes();
            foreach (var mSede in mResultado)
            {
                Console.WriteLine(mSede.Value + " - " + mSede.Key);
            }
        }
    }
}
