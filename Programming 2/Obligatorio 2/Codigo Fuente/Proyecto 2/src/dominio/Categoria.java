// Joaquin Bonifacino - 243193 - Rafael Cadenas - 269150
package dominio;

import java.io.Serializable;

public class Categoria implements Serializable {

    private String descripcion;
    private int prioriedad;
    private String nombre;

    public Categoria(String descripcion, int prioridad, String nombre) {
        this.descripcion = descripcion;
        this.prioriedad = prioridad;
        this.nombre = nombre;
    }

    public Categoria() {

    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public int getPrioridad() {
        return prioriedad;
    }

    public void setPrioridad(int prioridad) {
        this.prioriedad = prioridad;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    @Override
    public String toString() {
        return nombre;
    }

}
