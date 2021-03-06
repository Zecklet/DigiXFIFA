package com.myhistory.datos.tablas;
// Generated 11/06/2014 09:46:48 PM by Hibernate Tools 3.6.0


import java.util.HashSet;
import java.util.Set;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.OneToMany;
import javax.persistence.Table;

/**
 * Equipo generated by hbm2java
 */
@Entity
@Table(name="EQUIPO"
    ,schema="dbo"
    ,catalog="MY_HISTORY"
)
public class Equipo  implements java.io.Serializable {


     private int pkEquipo;
     private Pais pais;
     private String nombre;
     private boolean deSelecion;
     private Set<PerfilEstadistico> perfilEstadisticos = new HashSet<PerfilEstadistico>(0);
     private Set<Jugador> jugadors = new HashSet<Jugador>(0);

    public Equipo() {
    }

	
    public Equipo(int pkEquipo, Pais pais, String nombre, boolean deSelecion) {
        this.pkEquipo = pkEquipo;
        this.pais = pais;
        this.nombre = nombre;
        this.deSelecion = deSelecion;
    }
    public Equipo(int pkEquipo, Pais pais, String nombre, boolean deSelecion, Set<PerfilEstadistico> perfilEstadisticos, Set<Jugador> jugadors) {
       this.pkEquipo = pkEquipo;
       this.pais = pais;
       this.nombre = nombre;
       this.deSelecion = deSelecion;
       this.perfilEstadisticos = perfilEstadisticos;
       this.jugadors = jugadors;
    }
   
     @Id 

    
    @Column(name="PK_Equipo", unique=true, nullable=false)
    public int getPkEquipo() {
        return this.pkEquipo;
    }
    
    public void setPkEquipo(int pkEquipo) {
        this.pkEquipo = pkEquipo;
    }

@ManyToOne(fetch=FetchType.LAZY)
    @JoinColumn(name="FK_Pais", nullable=false)
    public Pais getPais() {
        return this.pais;
    }
    
    public void setPais(Pais pais) {
        this.pais = pais;
    }

    
    @Column(name="Nombre", nullable=false, length=30)
    public String getNombre() {
        return this.nombre;
    }
    
    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    
    @Column(name="De_Selecion", nullable=false)
    public boolean isDeSelecion() {
        return this.deSelecion;
    }
    
    public void setDeSelecion(boolean deSelecion) {
        this.deSelecion = deSelecion;
    }

@OneToMany(fetch=FetchType.LAZY, mappedBy="equipo")
    public Set<PerfilEstadistico> getPerfilEstadisticos() {
        return this.perfilEstadisticos;
    }
    
    public void setPerfilEstadisticos(Set<PerfilEstadistico> perfilEstadisticos) {
        this.perfilEstadisticos = perfilEstadisticos;
    }

@OneToMany(fetch=FetchType.LAZY, mappedBy="equipo")
    public Set<Jugador> getJugadors() {
        return this.jugadors;
    }
    
    public void setJugadors(Set<Jugador> jugadors) {
        this.jugadors = jugadors;
    }




}


