using System;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace MySoccer.Dominio.GestionarUsuarios
{
    public class Encriptacion
    {
        //COLOCAR EN CONSTANTES
        private const int kTamanoLlave = 1024;

        private static bool cOptimalAsymmetricEncryptionPadding = false;

        private void GenerarLlaves(int pTamanoLlave, string pDireccionLlavePublica, string pDireccionLlavePublicaPriva)
        {
            using (var mRSAProvider = new RSACryptoServiceProvider(pTamanoLlave))
            {
                string mLlavePublica = mRSAProvider.ToXmlString(false);
                string mLlavePublicaPriva = mRSAProvider.ToXmlString(true);
                File.WriteAllText(pDireccionLlavePublicaPriva, mLlavePublicaPriva);  
                File.WriteAllText(pDireccionLlavePublica, mLlavePublica);  

            }
        }

        private string EncriptarTexto(string pTexto, int pTamanoLlave, string pLlavePublicaXml)
        {
            var encrypted = Encriptar(Encoding.UTF8.GetBytes(pTexto), pTamanoLlave, pLlavePublicaXml);
            return Convert.ToBase64String(encrypted);
        }

        private byte[] Encriptar(byte[] pDatos, int pTamanoLlave, string pLlavePublicaXml)
        {
            if (pDatos == null || pDatos.Length == 0) throw new ArgumentException("Los datos están vacios", "pDatos");
            int mTamanoMaximo = ObtenerTamanoMaximo(pTamanoLlave);
            if (pDatos.Length > mTamanoMaximo) throw new ArgumentException(String.Format("El tamano maximo de los datos es {0}", mTamanoMaximo), "pDatos");
            if (!IsTamanoValido(pTamanoLlave)) throw new ArgumentException("El tamano de la llave no es válida", "pTamanoLlave");
            if (String.IsNullOrEmpty(pLlavePublicaXml)) throw new ArgumentException("La llave es nula o está vacia", "pLlavePublicaXml");

            using (var provider = new RSACryptoServiceProvider(pTamanoLlave))
            {
                provider.FromXmlString(pLlavePublicaXml);
                return provider.Encrypt(pDatos, cOptimalAsymmetricEncryptionPadding);
            }
        }

        private string DesencriptarTexto(string pTexto, int pTamanoLlave, string pLlavePublicaPrivadaXml)
        {
            var decrypted = Desencriptar(Convert.FromBase64String(pTexto), pTamanoLlave, pLlavePublicaPrivadaXml);
            return Encoding.UTF8.GetString(decrypted);
        }

        private byte[] Desencriptar(byte[] pDatos, int pTamanoLlave, string pLlavePublicaPrivadaXml)
        {
            if (pDatos == null || pDatos.Length == 0) throw new ArgumentException("Los datos están vacios", "pDatos");
            if (!IsTamanoValido(pTamanoLlave)) throw new ArgumentException("El tamaño de la llave no es valida", "pTamanoLlave");
            if (String.IsNullOrEmpty(pLlavePublicaPrivadaXml)) throw new ArgumentException("La llave es nula o está vacia", "pLlavePublicaPrivadaXml");

            using (var provider = new RSACryptoServiceProvider(pTamanoLlave))
            {
                provider.FromXmlString(pLlavePublicaPrivadaXml);
                return provider.Decrypt(pDatos, cOptimalAsymmetricEncryptionPadding);
            }
        }

        private int ObtenerTamanoMaximo(int pTamanoLlave)
        {
            if (cOptimalAsymmetricEncryptionPadding)
            {
                return ((pTamanoLlave - 384) / 8) + 7;
            }
            return ((pTamanoLlave - 384) / 8) + 37;
        }

       private bool IsTamanoValido(int pTamanoLlave)
        {
            return pTamanoLlave >= 384 &&
                    pTamanoLlave <= 16384 &&
                    pTamanoLlave % 8 == 0;
        }

       public string Encriptar(string pUbicacionPrivada, string pTexto)
       {
           string mLlavePublicaPrivada = File.ReadAllText(pUbicacionPrivada); ;
           return EncriptarTexto(pTexto, kTamanoLlave, mLlavePublicaPrivada);

       }

       public string Desencriptar(string pUbicacionPrivada, string pTexto)
       {
           string mLlavePublicaPrivada = File.ReadAllText(pUbicacionPrivada);
           return DesencriptarTexto(pTexto, kTamanoLlave, mLlavePublicaPrivada);
       }

       public void GenerarLlaves(string pDireccionLlavePublica, string pDireccionLlavePublicaPrivado)
       {
           GenerarLlaves(kTamanoLlave, pDireccionLlavePublica, pDireccionLlavePublicaPrivado);
       }


    }
}
