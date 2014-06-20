/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.datos;

import com.myhistory.ejetransversal.ModeloUsuario;
import com.myhistory.datos.tablas.Administrador;
import com.myhistory.ejetransversal.ModeloAdministrador;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import org.hibernate.HibernateException;
import org.hibernate.Session;

/**
 *
 * @author Ney Rojas
 */
public class BaseDatosAdministrador extends BaseDatosUsuarios {

    
    //Entrada: el nombre de usuario del que quiere iniciar sesion
    //Salida: Modelo usuario con todos los datos del usuario
    //Descripcion: lo que hace es sacar la información de un usuario de la base de datos 
    @Override
    public ModeloUsuario RecuperarDatosUsuario(String pNombreUsuario) {
        ModeloAdministrador mResultado = null; //resultado de la busqueda 
        Session mSesion = com.myhistory.datos.HibernateUtil.getSessionFactory().getCurrentSession(); //session encargada de realizar la conexon con la base de datos 
        try {
            if (mSesion.isOpen()) { //se corrobora que la conexion esta abierta
                mResultado = (ModeloAdministrador) RecuperarDatosCuenta(pNombreUsuario); //Recupera los datos del modelo
                mSesion.beginTransaction(); //comienza la transaccion 
                Administrador mAdministrador = (Administrador) mSesion.createQuery("from Administrador s where s.pkFkCuenta = :Identificador")//se encarga de recuperar los datos del 
                        .setParameter("Identificador", mResultado.getcIdentificador()) //se colocan los parametros del query
                        .uniqueResult(); //solicita un unico resultado
                mResultado.setcApellido(mAdministrador.getApellido()); //Se coloca el primer apellido
                mResultado.setcNombre(mAdministrador.getNombre()); //se coloca el nuevo nombre
                DateFormat mFormatoFecha = new SimpleDateFormat("dd/MM/yyyy"); //obtiene la fecha de nacimiento del usuario
                mResultado.setcFechaNacimiento(mFormatoFecha.format(mAdministrador.getFechaNacimiento())); //obtiene la fecha de nacimiento del usuario
                mResultado.setcCorreoElectronico(mAdministrador.getCorreo());//se setea el valor del correo 
                mResultado.setcIdentificador(mAdministrador.getPkFkCuenta());//SE SETEA EL ID del administrador
            }
        } catch (HibernateException e) {
            System.out.println("Error:" + e.getMessage()); //mensaje en caso de error
        }
        return mResultado;
    }

}
