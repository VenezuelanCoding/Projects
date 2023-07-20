// Joaquin Bonifacino - 243193 - Rafael Cadenas - 269150
package dominio;

import java.io.Serializable;

public class Cliente implements Serializable {

    private String nombre;
    private String direccion;
    private String telefono;

    public Cliente() {

    }

    public Cliente(String nombre) {
        this.nombre = nombre;
    }

    public Cliente(String unNombre, String unaDireccion, String unTelefono) {
        this.nombre = unNombre;
        this.direccion = unaDireccion;
        this.telefono = unTelefono;
    }

    @Override
    public String toString() {
        return nombre + " (" + direccion + " - " + telefono + ")";
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getDireccion() {
        return direccion;
    }

    public void setDireccion(String direccion) {
        this.direccion = direccion;
    }

    public String getTelefono() {
        return telefono;
    }

    public void setTelefono(String telefono) {
        this.telefono = telefono;
    }

 

}
