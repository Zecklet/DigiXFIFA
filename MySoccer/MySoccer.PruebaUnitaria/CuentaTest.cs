using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySoccer.Dominio.GestionarUsuarios;
using MySoccer.EjeTransversal;

namespace MySoccer.PruebaUnitaria
{
    /// <summary>
    /// Consta en la comprobacion de dos pruebas,
    /// 1ra => cuando se crea un cuenta, el nombre de usuario es la misma
    /// 2do => cuando se crea una cuenta, al comparar la misma contrasena tiene que se la misma
    /// </summary>
    [TestClass]
    public class CuentaTest
    {
        public CuentaTest()
        {
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
        public void TestCompararContrasena()
        {
            ConstantesGestionarUsuarios.kUbicacionLLavePrivada = "C:\\Users\\Ney Rojas\\Documents\\GitHub\\DigiXFIFA\\MySoccer\\MySoccer.Dominio\\Llaves\\privateKeyMS.xml";
            ConstantesGestionarUsuarios.kUbicacionLLavePublica = "C:\\Users\\Ney Rojas\\Documents\\GitHub\\DigiXFIFA\\MySoccer\\MySoccer.Dominio\\Llaves\\publicKeyMS.xml";
            String mNombreUsuario = "jorge";
            String mConstrasena = "jorge";
            Cuenta mCuenta = new Cuenta(mNombreUsuario, mConstrasena);
            Assert.AreEqual(true, mCuenta.CompararContrasena(mConstrasena), "las constraseñas no son las mismas");
        }

        [TestMethod]
        public void TestGetNombreUsuario()
        {
            String mNombreUsuario = "jorge";
            String mConstrasena = "jorge";
            Cuenta mCuenta = new Cuenta(mNombreUsuario, mConstrasena);
            Assert.AreEqual(mNombreUsuario, mCuenta.GetNombreUsuario(), "Los nombres de usuario no son los mismos");
        }
    }
}
