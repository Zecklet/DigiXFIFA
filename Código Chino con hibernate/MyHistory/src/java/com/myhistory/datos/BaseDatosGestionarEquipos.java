/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.datos;

import com.myhistory.datos.tablas.Equipo;
import com.myhistory.datos.tablas.Pais;
import com.myhistory.ejetransversal.Constantes;
import org.hibernate.HibernateException;
import org.hibernate.Session;
import com.myhistory.datos.HibernateUtil;
import com.myhistory.ejetransversal.ModeloAgregarEquipo;
import com.myhistory.ejetransversal.ModeloPais;
import java.util.ArrayList;
import java.util.List;

/**
 *
 * @author Ney Rojas
 */
public class BaseDatosGestionarEquipos {

    //Entrada: pdatosEquipo= contiene toda la informacion del equipo que se agrego 
    //Salida: ninguna
    //Descripcion: toma la lista de paises de la base y los transforma en un lista de modelos de pais
    public void AgregarEquipos(ModeloAgregarEquipo pDatosEquipo) {
        Session mSesion = HibernateUtil.getSessionFactory().getCurrentSession(); //Se obtiene la session
        try {
            if (mSesion.isOpen()) { //si la conexion esta abierta procede con la insercion 
                mSesion.beginTransaction(); //comienza la transaccion 

                Pais mEntidadPais = GetPais(pDatosEquipo.getIdPais(), mSesion); //Consulta el nombre del pais que se desea agregar
                Equipo mNuevaFila = new Equipo(0, mEntidadPais, pDatosEquipo.getcNombreEquipo(), pDatosEquipo.iscEsSeleccion()); //crea el nuevo equipo

                mSesion.save(mNuevaFila); //guarda el nuevo equipo en memoria 
                mSesion.getTransaction().commit(); //Escribe el nuevo equipo en la base de datos 
            }
        } catch (HibernateException e) {
            System.out.println("Error:" + e.getMessage());
        }
        CerrarConexion(mSesion);// si la conexion con la base de datos no ha sido cerrada, la cierra
    }

    //Entrada: pdatosEquipo= contiene toda la informacion del equipo que se agrego 
    //Salida: ninguna
    //Descripcion: toma la lista de paises de la base y los transforma en un lista de modelos de pais
    public void ActualizarEquipos(ModeloAgregarEquipo pDatosEquipo) {
        Session mSesion = HibernateUtil.getSessionFactory().getCurrentSession(); //obtiene la sesion 
        try {
            if (mSesion.isOpen()) { //si la conexion esta abierta procede con la actualizacion 
                mSesion.beginTransaction(); //comienza la transaccion 

                Pais mEntidadPais = (Pais) GetPais(pDatosEquipo.getIdPais(), mSesion);//obtiene el pais de la base de datos
                Equipo mActulizarFila = ConsultarEquipo(pDatosEquipo.getId()); //Se obtiene el equipo que se quiere actualiar

                mActulizarFila.setDeSelecion(pDatosEquipo.iscEsSeleccion()); //se introducen los nuevos datos 
                mActulizarFila.setNombre(pDatosEquipo.getcNombreEquipo());//se introducen los nuevos datos
                mActulizarFila.setPais(mEntidadPais);//se introducen los nuevos datos

                mSesion.update(mActulizarFila); //se guarda temporalmente
                mSesion.getTransaction().commit(); //se actualiza permanentemente en a base de datos 
            }
        } catch (HibernateException e) {
            System.out.println("Error:" + e.getMessage());
        } finally {
            CerrarConexion(mSesion);// si la conexion con la base de datos no ha sido cerrada, la cierra
        }
    }

    //Entrada: ninguno
    //Salida: Lista con modelos de con la info de todos los equipos 
    //Descripcion: toma la lista de equipos de la base y los transforma en un lista de modelos de equipos
    public List<ModeloAgregarEquipo> GetTodosEquipos() {
        List<Equipo> mResultadoConsultado = new ArrayList<Equipo>(); //se crea un lista por si la consulta es null 
        List<ModeloAgregarEquipo> mResultado = new ArrayList<ModeloAgregarEquipo>();//se cre una nueva lista que contendra los modelos 
        Session mSesion = HibernateUtil.getSessionFactory().getCurrentSession(); //Se obtine la session 
        try {
            if (mSesion.isOpen()) { //si esta abierta la conexion procede con el procedimiento 
                mSesion.beginTransaction(); //comienza la transaccion 

                mResultadoConsultado = mSesion.createQuery("from Equipo").list(); //covierte el resultado de todos los equiopos en una lista
            }
        } catch (HibernateException e) {
            System.out.println("Error:" + e.getMessage());
        } finally {
            CerrarConexion(mSesion);// si la conexion con la base de datos no ha sido cerrada, la cierra
        }
        for (Equipo mEquipo : mResultadoConsultado) {
            mResultado.add(CrearModeloAgregarEquipo(mEquipo));
        }

        return mResultado;
    }

    //Entrada: identificador en equipo
    //Salida: Equipo: informacion del equipo que contiene la tabla 
    //Descripcion: Es un metodo privado que obtiene un equipo de la tabla de equipos
    private Equipo ConsultarEquipo(int pIdentificador) {
        Equipo mResultadoConsulta = null; //Resultado de la consulta 
        Session mSesion = HibernateUtil.getSessionFactory().getCurrentSession(); //Se obtiene la session para entrar en la base
        try {
            if (mSesion.isOpen()) { //si esta abierta la conexion procese con la consulta 
                mSesion.beginTransaction(); //comienza la transaccion

                mResultadoConsulta = (Equipo) mSesion.createQuery("from Equipo p where p.pkEquipo = :Identificador") //Se coloca la conuslta
                        .setParameter(Constantes.kQueryVariableIdentificador, pIdentificador) //Se colocan los parametros
                        .uniqueResult(); //se solicita un unico resultado 
            }
        } catch (HibernateException e) { //Exepcion 
            System.out.println("Error:" + e.getMessage());
        } finally {
            CerrarConexion(mSesion);// si la conexion con la base de datos no ha sido cerrada, la cierra
        }
        return mResultadoConsulta;
    }

    //Entrada: ninguno
    //Salida: Lista con modelos de paises 
    //Descripcion: toma la lista de paises de la base y los transforma en un lista de modelos de pais
    public List<ModeloPais> GetListaPaises() {
        List<Pais> mResultadoConsultado = new ArrayList<Pais>(); //variable que continee los paises de la base
        List<ModeloPais> mResultado = new ArrayList<ModeloPais>(); //variable resultante de la consulta 
        Session mSesion = HibernateUtil.getSessionFactory().getCurrentSession(); //se obtiene la sesion para conectarse a la base de datos 
        try {
            if (mSesion.isOpen()) { // si la conexion esta abierta procesede con el procedimiento 
                mSesion.beginTransaction(); //comienza la transaccion

                mResultadoConsultado = mSesion.createQuery("from Pais").list(); //lista todos los paises de la base de datos 
            }
        } catch (HibernateException e) {
            System.out.println("Error:" + e.getMessage());
        } finally {
            CerrarConexion(mSesion);// si la conexion con la base de datos no ha sido cerrada, la cierra
        }
        for (Pais mPais : mResultadoConsultado) { //se recorren todos los paises 
            //Se agregan los sequipos uno por uno a la lista resultante 
            mResultado.add(new ModeloPais(mPais.getPkPais(), mPais.getNombre()));
        }
        return mResultado;
    }

    //Entrada: identificador del equipos 
    //Salida: ModeloAgregarEquipo con la informacion de un equipo 
    //Descripcion: toma la informacion del equipo de la base de datos y lo transforma en un ModeloAgregarEquipo
    public ModeloAgregarEquipo GetInformacionEquipo(int pIdentificador) {
        ModeloAgregarEquipo mResultado = null; //vaarible que contiene el resultao 
        Equipo mResultadoConsulta = ConsultarEquipo(pIdentificador); //obtiene el equipo con el mismo identificador enviado
        if (mResultadoConsulta != null) { //si equipo consultado existe
            mResultado = CrearModeloAgregarEquipo(mResultadoConsulta); //crea un modelo apartir del equipo consultado
        }
        return mResultado;
    }

    //Entrada: identificador den equipo
    //Salida: modelo con la informacion del equipo solicitado 
    //Descripcion: obtiene la informacion de un equipo asociado a un pais
    public ModeloAgregarEquipo GetInformacionEquipoPais(int pIdentificadorPais) {
        Equipo mResultadoConsulta = null; //variable resultado 
        Session mSesion = HibernateUtil.getSessionFactory().getCurrentSession(); //se obtiene la session 
        try {
            if (mSesion.isOpen()) { //si la conexion a la base de datos esta abierta, procesede con le procesimiento
                mSesion.beginTransaction(); // comienza la transccion 

                mResultadoConsulta = (Equipo) mSesion.createQuery("from Equipo p where p.pais.pkPais = :Identificador") //Se ejecuta el query de la consulta 
                        .setParameter(Constantes.kQueryVariableIdentificador, GetPais(pIdentificadorPais, mSesion).getPkPais())//se colocan los parametros de la consulta 
                        .uniqueResult(); //se solicita un unico resultado 
            }
        } catch (HibernateException e) {
            System.out.println("Error:" + e.getMessage());
        } finally {
            CerrarConexion(mSesion);// si la conexion con la base de datos no ha sido cerrada, la cierra
        }
        return CrearModeloAgregarEquipo(mResultadoConsulta); //retorna le modelo con la informacion del equipos 
    }

    //Entrada: pIdentificadorPais= identificador del pais
    //pSesion= es la sesion que se utiliza par aconsulta la base de datos
    //Salida: la informacion del pais consultado 
    //Descripcion: consulta una fila a la base de datos
    private Pais GetPais(int pIdentificadorPais, Session pSesion) {
        if (pSesion.isOpen()) {
            return (Pais) pSesion.createQuery("from Pais p where p.pkPais = :Identificador") //obtine la entidad del pais 
                    .setParameter(Constantes.kQueryVariableIdentificador, pIdentificadorPais) //ingresa los datos de la consulta 
                    .uniqueResult(); //solicita una unico resultado 
        }
        return null;
    }

    //con el fin de no tener que repetir procedimiento de transpaso de tabla a modelo, y tambien para 
    //evitar utilizar la clase de la tabla pues es algo que puede cambiar con el tiempo
    private ModeloAgregarEquipo CrearModeloAgregarEquipo(Equipo pEquipo) {
        ModeloAgregarEquipo mResultado = new ModeloAgregarEquipo();//variable que contiene el resultado de la funcion  
        if (pEquipo != null) { //si el equipo no existe crea un modelo vacio
            mResultado = new ModeloAgregarEquipo(pEquipo.getPkEquipo(), pEquipo.getNombre(), //crea la instancia de retorno
                    pEquipo.isDeSelecion(), pEquipo.getPais().getPkPais()); //devuelve un modelo vacio
            mResultado.setcNombrePais(pEquipo.getPais().getNombre()); //coloca el nombre del pais 
        }
        mResultado.setcListaPaises(GetListaPaises()); //le coloca la lista de paises al modelo
        return mResultado;
    }

    //Entrada: ninguna 
    //Salida: modelo con la informacion del equipo solicitado 
    //Descripcion: obtiene la informacion de un equipo asociado a al primer pais de la base 
    public ModeloAgregarEquipo GetModeloAgregarEquipoPaisPrimero() {
        return GetInformacionEquipoPais(GetListaPaises().get(0).getIdPais()); //crea el modelo de agregar equipo para el primer pais 
    }

    
    //Entrada: sesion para la conexion con la base de datis 
    //Salida: ninguna 
    //Descripcion: cerrar la conexion con la base de datos en caso de que quede abierta 
    private void CerrarConexion(Session pSesion) {
        if (!pSesion.isOpen()) {
            //pSesion.close();
        }
    }

}
