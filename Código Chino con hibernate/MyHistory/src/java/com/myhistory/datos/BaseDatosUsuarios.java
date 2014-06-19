/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.datos;

import com.myhistory.datos.tablas.Administrador;
import com.myhistory.datos.tablas.Cuenta;
import com.myhistory.ejetransversal.Constantes;
import com.myhistory.ejetransversal.ModeloAdministrador;
import com.myhistory.ejetransversal.ModeloUsuario;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;
import org.hibernate.HibernateException;
import org.hibernate.Transaction;
import org.hibernate.Session;

/**
 *
 * @author Ney Rojas
 */
public abstract class BaseDatosUsuarios {

    public boolean ExisteUsuario(String pNombreUsuario) {
        Session mSesion = com.myhistory.datos.HibernateUtil.getSessionFactory().getCurrentSession();
        mSesion.beginTransaction();
        return !mSesion.createQuery(Constantes.kQueryConsultarCuentNombreUsuario)
                .setParameter(Constantes.kQueryVariableNombreUsuario, pNombreUsuario)
                .list().isEmpty();
    }

    public int CrearUsuario(int pPKCuenta, String pNombre, String pApellido,
            Date pFechaNacimiento, String pCorreoElectronio) {
        int mResultado = 0;
        Session mSesion = com.myhistory.datos.HibernateUtil.getSessionFactory().getCurrentSession();
        try {
            if (mSesion.isOpen()) {
                Transaction mTransaccion = mSesion.beginTransaction();
                Cuenta mCuenta = (Cuenta) mSesion.createQuery(Constantes.kQueryConsultarCuentIdentificador)
                        .setParameter(Constantes.kQueryVariableIdentificador, pPKCuenta)
                        .uniqueResult();

                Administrador mNuevaUsuario = new Administrador(mCuenta, pNombre, pApellido, pCorreoElectronio, pFechaNacimiento);
                mNuevaUsuario.setPkFkCuenta(pPKCuenta);

                mSesion.save(mNuevaUsuario);
                mTransaccion.commit();
                mResultado = 1;
            }
        } catch (HibernateException ex) {
        } finally {
        }
        return mResultado;
    }

    public int CrearCuenta(String pNombreUsuario, String pContrasena, Date pFechaInscripcion) {
        int mResultado = 0;
        Session mSesion = com.myhistory.datos.HibernateUtil.getSessionFactory().getCurrentSession();
        try {
            if (mSesion.isOpen()) {
                Transaction mTransaccion = mSesion.beginTransaction();
                Cuenta mNuevaCuenta = new Cuenta(0, pNombreUsuario, pContrasena, pFechaInscripcion, true);

                mSesion.save(mNuevaCuenta);
                mTransaccion.commit();
                mResultado = mNuevaCuenta.getPkCuenta();
            }
        } catch (HibernateException ex) {
        } finally {
            //mSesion.close();
        }
        return mResultado;
    }

    public void CambiarEstadoUsuario(int cIdentificador, boolean cEstado) {
        Session mSesion = com.myhistory.datos.HibernateUtil.getSessionFactory().getCurrentSession();
        try {
            if (mSesion.isOpen()) {
                Transaction mTransaccion = mSesion.beginTransaction();
                Cuenta mCuenta = (Cuenta) mSesion.createQuery(Constantes.kQueryConsultarCuentIdentificador)
                        .setParameter(Constantes.kQueryVariableIdentificador, cIdentificador)
                        .uniqueResult();
                mCuenta.setEstado(cEstado);
                mSesion.update(mCuenta);
                mTransaccion.commit();
            }
        } catch (HibernateException ex) {
        } finally {
            //mSesion.close();
        }
    }

    public void ActualizarUsuario(int pIdentificador, String pNombre, String pApellido,
            Date pFechaNacimiento, String pCorreo) {
        Session mSesion = com.myhistory.datos.HibernateUtil.getSessionFactory().getCurrentSession();
        try {
            if (mSesion.isOpen()) {
                Transaction mTransaccion = mSesion.beginTransaction();
                Administrador mAdministrador = (Administrador) mSesion.createQuery(Constantes.kQueryConsultarAdministradorIdentificador)
                        .setParameter(Constantes.kQueryVariableIdentificador, pIdentificador)
                        .uniqueResult();
                mAdministrador.setApellido(pApellido);
                mAdministrador.setCorreo(pCorreo);
                mAdministrador.setNombre(pNombre);
                mAdministrador.setFechaNacimiento(pFechaNacimiento);
                mSesion.update(mAdministrador);
                mTransaccion.commit();
            }
        } catch (HibernateException ex) {
        } finally {
            //mSesion.close();
        }
    }

    public void ActualizarCuenta(int pPKUsuario, String pNombreUsuario, String pContrasena) {
        Session mSesion = com.myhistory.datos.HibernateUtil.getSessionFactory().getCurrentSession();
        try {
            if (mSesion.isOpen()) {
                Transaction mTransaccion = mSesion.beginTransaction();
                Cuenta mCuenta = (Cuenta) mSesion.createQuery(Constantes.kQueryConsultarCuentIdentificador)
                        .setParameter(Constantes.kQueryVariableIdentificador, pPKUsuario)
                        .uniqueResult();
                mCuenta.setNombreUsuario(pNombreUsuario);
                mCuenta.setContrasena(pContrasena);
                mSesion.update(mCuenta);
                mTransaccion.commit();
            }
        } catch (HibernateException ex) {
        } finally {
            //mSesion.close();
        }
    }

    public ModeloUsuario RecuperarDatosCuenta(String pNombreUsuario) {
        ModeloUsuario mResultado = new ModeloAdministrador();
        Session mSesion = com.myhistory.datos.HibernateUtil.getSessionFactory().getCurrentSession();
        try {
            if (mSesion.isOpen()) {
                mSesion.beginTransaction();
                Cuenta mCuenta = (Cuenta) mSesion.createQuery(Constantes.kQueryConsultarCuentNombreUsuario)
                        .setParameter(Constantes.kQueryVariableNombreUsuario, pNombreUsuario)
                        .uniqueResult();
                DateFormat mFormatoFecha = new SimpleDateFormat("dd/MM/yyyy");
                mResultado.setcFechaInscripcion(mFormatoFecha.format(mCuenta.getFechaInscripcion()));
                mResultado.setcNombreUsuario(mCuenta.getNombreUsuario());
                mResultado.setcContrasena(mCuenta.getContrasena());
                mResultado.setcEstado(mCuenta.isEstado());
                mResultado.setcIdentificador(mCuenta.getPkCuenta());
            }
        } catch (HibernateException e) {
            System.out.println("Error:" + e.getMessage());
        }
        return mResultado;
    }

    abstract public ModeloUsuario RecuperarDatosUsuario(String pNombreUsuario);

}
