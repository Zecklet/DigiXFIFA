/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.datos;

import com.myhistory.datos.tablas.Torneo;
import com.myhistory.ejetransversal.Constantes;
import com.myhistory.ejetransversal.ModeloAgregarTorneo;
import java.util.ArrayList;
import java.util.List;
import org.hibernate.HibernateException;
import org.hibernate.Session;

/**
 *
 * @author Ney Rojas
 */
public class BaseDatosGestionarTorneo {

    //Entrada: Recibe los datos de un torneo
    //Salida: true=> inserto, false => no inserto
    //Descripcion:Esta funcion no lo ue hace tomar los datos de un partido de entrada y los guarda en la bas de datos
    public boolean AgregarTorneo(String pNombreTorneo, String pNombreSede, int pCantidad, boolean pEsSeleccion,
            boolean pEsCopa) {
        boolean mResultado = false;
        Session mSesion = com.myhistory.datos.HibernateUtil.getSessionFactory().getCurrentSession(); //se obtiene la session para tener acceso a la base d datos
        try {
            if (mSesion.isOpen()) { //si la sesion esta abierta comienza con el proceso
                mSesion.beginTransaction(); //comienza una nueva transacccion
                Torneo mNuevoTorneo = new Torneo(0, pNombreTorneo, pNombreSede, pCantidad, pEsSeleccion, pEsCopa); //Crea un nuevo torneo en memoria
                mSesion.save(mNuevoTorneo); //Agregar  el torneo a la base 
                mSesion.getTransaction().commit();//escribe el torno en la base d¿e datos
                mResultado = true;
            }
        } catch (HibernateException e) {
            System.out.println("Error:" + e.getMessage());
        }
        return mResultado;
    }

    //Entrada: los datos necesarios para actualizar un torneo
    //Salida: true=> inserto, false => no inserto
    //Descripcion: Toma los datos de entrada y los actualiza en la base de datos
    public boolean ActualizarTorneo(int pIdentificador, String pNombreTorneo, String pNombreSede,
            int pCantidad, boolean pEsSeleccion, boolean pEsCopa) {
        boolean mResultado = false;
        Session mSesion = com.myhistory.datos.HibernateUtil.getSessionFactory().getCurrentSession(); //inici una nueva sesion
        try {
            if (mSesion.isOpen()) { //si la sesion esta abierta comienza la transaccion
                mSesion.beginTransaction(); //Comeinza una nueva transccion
                Torneo mTorneo = GetTorneo(pIdentificador); //saca el torneo de la bae de datos 

                mTorneo.setCantidadJugadores(pCantidad); //actualiza la cantidad de jugadores
                mTorneo.setDeCopa(pEsCopa); //actualiza si el torneo es de copa 
                mTorneo.setNombreSede(pNombreSede); //Actualiza si el torneo es de selecion
                mTorneo.setNombre(pNombreTorneo); //Actualiza el nombre del torneo
                mTorneo.setDeSeleccion(pEsSeleccion); //actualiza si el torneo es de seleccion 

                mSesion.update(mTorneo); ///actualiza la tabla de la base de datos
                mSesion.getTransaction().commit(); //realiza la escritura en la base de datos
                mResultado = true;
            }
        } catch (HibernateException e) {
            System.out.println("Error:" + e.getMessage());
        }
        return mResultado;
    }

    //Entrada: ninguna
    //Salida: retorna la informacion de todos los torneos
    //Descripcion: toma la informacion de la base de datos de los torneos y los introduce en una lita
    //como modelo de agregar partido
    public List<ModeloAgregarTorneo> GetTorneos() {
        List<Torneo> mResultado; //variable donde se almacena la consulta
        List<ModeloAgregarTorneo> mListaModelos = new ArrayList<ModeloAgregarTorneo>(); //variable donde se almacena el resultado de la funcion
        ModeloAgregarTorneo mModelo; ///Modelo temporal que es agregado a la ista de torneos
        Session mSesion = com.myhistory.datos.HibernateUtil.getSessionFactory().getCurrentSession(); //obtiene la session de hibernate para la conexion
        try {
            if (mSesion.isOpen()) { //si esta abbierta comienza el proceso
                mSesion.beginTransaction(); //comienza la transaccion
                mResultado = (List<Torneo>) mSesion.createQuery("from Torneo").list(); //realiza la consulta

                for (int i = 0; i < mResultado.size(); i++) {//paa los datos de la tabla a modelos con su informacion
                    Torneo mTemporal = mResultado.get(i); //toma un elemento de la lista 
                    mModelo = CrearModeloTorneo(mTemporal); //crea su modelo correspondiente
                    mListaModelos.add(mModelo); //lo agrega a la lista de modelos
                }
            }

        } catch (HibernateException e) {
            System.out.println("Error:" + e.getMessage());
        }

        return mListaModelos;//retorna la lista de modelos
    }

    //Entrada:pIdentificador=identificador de un torneo
    //Salida: objecto torneo con la informacion del torneo seleccionado 
    //Descripcion: Obtiene un torneo de la base de datos, apartir de su identificador
    private Torneo GetTorneo(int pIdentificador) {
        Torneo mResultado = null; //resultado de la funcion
        Session mSesion = com.myhistory.datos.HibernateUtil.getSessionFactory().getCurrentSession(); //Obtiene la session para la onexion con la base
        try {
            if (mSesion.isOpen()) { //si esta abierta inicia la transaccion
                mSesion.beginTransaction(); //comienza la transaccion
                mResultado = (Torneo) mSesion.createQuery("from Torneo s where s.pkTorneo=:Identificador")//realiza la consulta del torneo
                        .setParameter(Constantes.kQueryVariableIdentificador, pIdentificador) //colca los datos por parametro
                        .uniqueResult(); //solicita un unico resultado 
            }
        } catch (HibernateException e) {
            System.out.println("Error:" + e.getMessage()); //en caso de algun error, imprime cual fue
        }
        return mResultado; //retorna el valor
    }

    //Entrada: pTorneo = identificador de un torneo
    //salida: Informacion de un torneo en forma de modelo
    //Descripcion: convierte la informacion de una tabla de torneo en un modelo de torneo
    public ModeloAgregarTorneo GetInformacionTorneo(int pIdTorneo) {
        Torneo mResultado = GetTorneo(pIdTorneo); //Obtiene la tabla de torneo 
        ModeloAgregarTorneo mSalida = null; //resultado de la salida 
        if (mResultado != null) {
            mSalida = CrearModeloTorneo(mResultado);//realiza la creacion del modelo de torneo
        }
        return mSalida;
    }

    //Entrada: le entra una tabla del torneo 
    //Salida: un modelo con la informacion del torneo
    //Descripcion:Funcion que se encarga de crear un modelo con los datos de una torneo apartir de sus datos en la tabla de la base de datos
    private ModeloAgregarTorneo CrearModeloTorneo(Torneo pTablaTorneo) {
        return new ModeloAgregarTorneo(pTablaTorneo.getNombre(),
                pTablaTorneo.getNombreSede(), "" + pTablaTorneo.getCantidadJugadores(),
                pTablaTorneo.isDeSeleccion(), pTablaTorneo.isDeCopa(), pTablaTorneo.getPkTorneo() + "");
    }
}
