/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.myhistory.datos;

import com.myhistory.datos.tablas.Torneo;
import com.myhistory.ejetransversal.Constantes;
import java.util.List;
import org.hibernate.HibernateException;
import org.hibernate.Session;

/**
 *
 * @author Ney Rojas
 */
public class BaseDatosGestionarTorneo {

    public void AgregarTorneo(String pNombreTorneo, String pNombreSede, int pCantidad, boolean pEsSeleccion,
            boolean pEsCopa) {
        Session mSesion = com.myhistory.datos.HibernateUtil.getSessionFactory().getCurrentSession();
        try {
            if (mSesion.isOpen()) {
                mSesion.beginTransaction();
                Torneo mNuevoTorneo = new Torneo(0, pNombreTorneo, pNombreSede, pCantidad, pEsSeleccion, pEsCopa);
                mSesion.save(mNuevoTorneo);
                mSesion.getTransaction().commit();
            }
        } catch (HibernateException e) {
            System.out.println("Error:" + e.getMessage());
        }
    }
    public void ActualizarTorneo(int pIdentificador, String pNombreTorneo, String pNombreSede,
            int pCantidad, boolean pEsSeleccion, boolean pEsCopa) {
        Session mSesion = com.myhistory.datos.HibernateUtil.getSessionFactory().getCurrentSession();
        try {
            if (mSesion.isOpen()) {
                mSesion.beginTransaction();
                Torneo mTorneo = GetTorneo(pIdentificador);
                
                mTorneo.setCantidadJugadores(pCantidad);
                mTorneo.setDeCopa(pEsCopa);
                mTorneo.setNombreSede(pNombreSede);
                mTorneo.setNombre(pNombreTorneo);
                mTorneo.setDeSeleccion(pEsSeleccion);
                
                mSesion.update(mTorneo);
                mSesion.getTransaction().commit();
            }
        } catch (HibernateException e) {
            System.out.println("Error:" + e.getMessage());
        }
    }

    public List<Torneo> GetTorneos() {
        List<Torneo> mResultado = null;
        Session mSesion = com.myhistory.datos.HibernateUtil.getSessionFactory().getCurrentSession();
        try {
            if (mSesion.isOpen()) {
                mSesion.beginTransaction();
                mResultado = (List<Torneo>) mSesion.createQuery("from Torneo").list();
            }
        } catch (HibernateException e) {
            System.out.println("Error:" + e.getMessage());
        }
        return mResultado;
    }

    public Torneo GetTorneo(int pIdentificador) {
        Torneo mResultado = null;
        Session mSesion = com.myhistory.datos.HibernateUtil.getSessionFactory().getCurrentSession();
        try {
            if (mSesion.isOpen()) {
                mSesion.beginTransaction();
                mResultado = (Torneo) mSesion.createQuery("from Torneo s where s.pkTorneo=:Identificador")
                        .setParameter(Constantes.kQueryVariableIdentificador, pIdentificador)
                        .uniqueResult();
            }
        } catch (HibernateException e) {
            System.out.println("Error:" + e.getMessage());
        }
        return mResultado;
    }
}
