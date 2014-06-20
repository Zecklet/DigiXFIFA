using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySoccer.Datos;

namespace MySoccer.PruebaUnitaria
{
    /// <summary>
    /// Descripción resumida de FanaticoBaseDatos
    /// </summary>
    [TestClass]
    public class FanaticoBaseDatos
    {
        public FanaticoBaseDatos()
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
        public void TestAgregarFanatico()
        {
            String pNombreUsuario = "ney18rojas";
            datFanaticoBaseDatos mConexion = new datFanaticoBaseDatos();
            Console.WriteLine("-------------");
            int pId = mConexion.AgregarUsuario("Ney", "Rojas", new DateTime());
            mConexion.AgregarCuenta(pId, pNombreUsuario, "ney", new DateTime(), true);
            mConexion.AgregarFanatico(pId, "bhjksajkk",1,1,"d","",1);
            Assert.AreEqual(pNombreUsuario, mConexion.ObtenerCuenta(pNombreUsuario).Nombre_Usuario, "Error agregando un nuevo usuario");
            Console.WriteLine("-------------");
        }

        [TestMethod]
        public void TestActualizarFanatico()
        {
            String pNombreUsuario = "ney18rojas";
            datFanaticoBaseDatos mConexion = new datFanaticoBaseDatos();
            int pId = mConexion.ObtenerCuenta(pNombreUsuario).PK_FK_Cuenta;
            Console.WriteLine("-----------" + pId);
            mConexion.ActualizarCuenta(pId, pNombreUsuario, "Rojas");
            mConexion.ActualizarUsuario(pId, pNombreUsuario, "ney", new DateTime());
            mConexion.ActualizarDatosFanatico(pId, "--------", "correo", "", 1,1, 1 );
            Assert.AreEqual(pNombreUsuario, mConexion.ObtenerCuenta(pNombreUsuario).Nombre_Usuario, "Error agregando un nuevo usuario");

        }
    }
}
