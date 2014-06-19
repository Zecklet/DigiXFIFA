/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.datos;

import com.myhistory.ejetransversal.ModeloUsuario;
import com.myhistory.datos.BaseDatosUsuarios;
import com.myhistory.datos.tablas.Administrador;
import com.myhistory.datos.tablas.Cuenta;
import com.myhistory.ejetransversal.ModeloAdministrador;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import org.hibernate.HibernateException;
import org.hibernate.Session;
import org.hibernate.Transaction;

/**
 *
 * @author Ney Rojas
 */
public class BaseDatosAdministrador extends BaseDatosUsuarios {

    @Override
    public ModeloUsuario RecuperarDatosUsuario(String pNombreUsuario) {
        ModeloAdministrador mResultado = null;
        Session mSesion = com.myhistory.datos.HibernateUtil.getSessionFactory().getCurrentSession();
        try {
            if (mSesion.isOpen()) {
                mResultado = (ModeloAdministrador) RecuperarDatosCuenta(pNombreUsuario);
                mSesion.beginTransaction();
                Administrador mAdministrador = (Administrador) mSesion.createQuery("from Administrador s where s.pkFkCuenta = :Identificador")
                        .setParameter("Identificador", mResultado.getcIdentificador())
                        .uniqueResult();
                mResultado.setcApellido(mAdministrador.getApellido());
                mResultado.setcNombre(mAdministrador.getNombre());
                DateFormat mFormatoFecha = new SimpleDateFormat("dd/MM/yyyy");
                mResultado.setcFechaNacimiento(mFormatoFecha.format(mAdministrador.getFechaNacimiento()));
                mResultado.setcCorreoElectronico(mAdministrador.getCorreo());
                mResultado.setcIdentificador(mAdministrador.getPkFkCuenta());
            }
        } catch (HibernateException e) {
            System.out.println("Error:" + e.getMessage());
        }
        return mResultado;
    }

    public void CrearUsuarioEspecifico(int pPKIdentificador, String pNombreUsuario) {

    }
}
