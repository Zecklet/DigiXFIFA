using MySoccer.Dominio.GestionarUsuarios;
using MySoccer.EjeTransversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySoccer.Dominio.GestionarUsuarios
{
    public class Cuenta
    {
        public Boolean cEstado { get; set; }
        public String cNombreUsuario { get; set; }
        public String cContrasena { get; set; }
        public DateTime cFechaInscripcion { get; set; }
        private Encriptacion cEncriptador { get; set; }

        public Cuenta(String pNombreUsuario, String pContrasena)
        {
            this.cEncriptador = new Encriptacion();
            this.cEstado = false;
            this.cFechaInscripcion = DateTime.Now;
            this.cNombreUsuario = pNombreUsuario;
            this.cContrasena = this.cEncriptador.Encriptar(ConstantesGestionarUsuarios.kUbicacionLLavePrivada, pContrasena);
        }

        public Cuenta(String pNombreUsuario, String pContrasena, Boolean pEstado, DateTime pFechaInscripcion)
        {
            this.cEncriptador = new Encriptacion();
            this.cEstado = pEstado;
            this.cFechaInscripcion = pFechaInscripcion;
            this.cNombreUsuario = pNombreUsuario.ToLower();
            this.cContrasena = pContrasena;
        }

        public String GetNombreUsuario()
        {
            return this.cNombreUsuario;
        }

        public String GetContrasena()
        {
            return this.cContrasena;
        }

        public Boolean CompararContrasena(String pContrasena)
        {
            return (pContrasena == this.cEncriptador.Desencriptar(ConstantesGestionarUsuarios.kUbicacionLLavePrivada, this.cContrasena));
        }

        public void CambiarUsuario(String pNuevoNombreUsuario)
        {
            this.cNombreUsuario = pNuevoNombreUsuario;
        }

        public void CambiarContrasena(String pNuevaContrasena)
        {
            this.cContrasena = this.cEncriptador.Encriptar(ConstantesGestionarUsuarios.kUbicacionLLavePrivada, pNuevaContrasena);
        }
    }
}
