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

    //Entrada: nombre de usuario
    //Salida: true=> existe usuario false => no existe
    //Descripcion:Realiza una consulta a la base de datos para saber si el usuario ingresdao existe
    public boolean ExisteUsuario(String pNombreUsuario) {
        Session mSesion = com.myhistory.datos.HibernateUtil.getSessionFactory().getCurrentSession();
        mSesion.beginTransaction();
        return !mSesion.createQuery(Constantes.kQueryConsultarCuentNombreUsuario)
                .setParameter(Constantes.kQueryVariableNombreUsuario, pNombreUsuario)
                .list().isEmpty();
    }

    //Entrada: informacion de un usuario, pPKCuenta es el identificador de la cuenta asociada
    //Salida: int 0 => no inserto, 1=> inserto
    //Descripcion:Crea un nuevo usuario de tipo administrador en la base de datos
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

    //Entrada: informacion para la creacion de una nueva cuenta 
    //Salida: int 0 => no inserto, 1=> inserto
    //Descripcion:Crea en la base de datos una nueva cuenta usuado los datos de entrada y hibernate
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
        }
        return mResultado;
    }

    //Entrada: cIdentificador => identificador de la cuenta, cEstado => estado al cual va a cambiar la cuenta 
    //Salida: ninguna
    //Descripcion:Cambia el esta de una cuenta en la base de datos, dependiendo de la entrada de la funcion
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
        }
    }

    //Entrada: informacion para actualizar un usuario administrador 
    //Salida: ninguna
    //Descripcion:Crea en la base de datos una nueva cuenta usuado los datos de entrada y hibernate
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

    //Entrada: informacion para la actualizacion de una nueva cuenta 
    //Salida: ninguna
    //Descripcion:actualiza en la base de datos una cuenta usuado los datos de entrada y hibernate
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
    
    //Entrada: nombre de usuario
    //Salida: modelo de usuario con la informacion del usuario consultado
    //Descripcion:Recupera los datos de la cuenta de la base de datos usando el nombre de usuario de la entrada
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

    //funcion que implementan las clases hijas para recuperar los datos especificos de cada usuario
    abstract public ModeloUsuario RecuperarDatosUsuario(String pNombreUsuario);

}
