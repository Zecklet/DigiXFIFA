using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySoccer.Datos;

namespace MySoccer.PruebaUnitaria
{
    /// <summary>
    /// Descripción resumida de AdministradorBaseDatosTest
    /// </summary>
    [TestClass]
    public class AdministradorBaseDatosTest
    {
        public AdministradorBaseDatosTest()
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
        public void TestAgregarUsuario()
        {
            String pNombreUsuario = "ney12rojas";
            datAdministradorBaseDatos mConexion = new datAdministradorBaseDatos();

            int pId = mConexion.AgregarUsuario("Ney", "Rojas", new DateTime());
            mConexion.AgregarCuenta(pId, pNombreUsuario, "ney", new DateTime(), true);
            mConexion.AgregarAdministrador(pId, "bhjksajkk");
            Assert.AreEqual(pNombreUsuario, mConexion.ObtenerCuenta("ney2rojas").Nombre_Usuario, "Error agregando un nuevo usuario");

        }

        [TestMethod]
        public void TestActualizarUsuario()
        {
            String pNombreUsuario = "ney12rojas";
            datAdministradorBaseDatos mConexion = new datAdministradorBaseDatos();
            int pId = mConexion.ObtenerCuenta(pNombreUsuario).PK_FK_Cuenta;
            mConexion.ActualizarCuenta(pId, pNombreUsuario, "Rojas");
            mConexion.ActualizarUsuario(pId, pNombreUsuario, "ney", new DateTime());
            mConexion.ActualizarDatosAdministrador(pId, "bhjksajkk");
            Assert.AreEqual(pNombreUsuario, mConexion.ObtenerCuenta(pNombreUsuario).Nombre_Usuario, "Error agregando un nuevo usuario");

        }
    }
}
