// Joaquin Bonifacino - 243193 - Rafael Cadenas - 269150
package dominio;

import java.io.Serializable;
import java.util.ArrayList;

public class Producto implements Serializable {

    private ArrayList<Categoria> listaCategoria;
    private String nombre;
    private int precio;

    public Producto(ArrayList<Categoria> listaCategoria, String nombre, int precio) {
        this.listaCategoria = listaCategoria;
        this.nombre = nombre;
        this.precio = precio;
    }

    public Producto() {

    }

    public ArrayList<Categoria> getListaCategoria() {
        return listaCategoria;
    }

    public void setListaCategoria(ArrayList<Categoria> listaCategoria) {
        this.listaCategoria = listaCategoria;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public int getPrecio() {
        return precio;
    }

    public void setPrecio(int precio) {
        this.precio = precio;
    }

    @Override
    public String toString() {
        return nombre + " " + precio + "$";
    }

}
