// Joaquin Bonifacino - 243193 - Rafael Cadenas - 269150
package dominio;

import java.io.Serializable;
import java.util.ArrayList;

public class Pedido implements Serializable {

    private int numero;
    private Cliente cliente;
    private String observaciones;
    private ArrayList<Producto> listaProductos;
    private int precioTotal;
    private static int proximoNumero = 0;

    public Pedido(Cliente cliente, String observaciones, ArrayList<Producto> listaProductos, int precioTotal) {
        this.cliente = cliente;
        this.observaciones = observaciones;
        this.listaProductos = listaProductos;
        this.precioTotal = precioTotal;

        Pedido.setproximoNumero(Pedido.getproximoNumero() + 1);
        this.setNumero(Pedido.getproximoNumero());
    }

    public Pedido() {

    }

    public static int getproximoNumero() {
        return proximoNumero;
    }

    public static void setproximoNumero(int proximoNumero) {
        Pedido.proximoNumero = proximoNumero;
    }

    public int getNumero() {
        return numero;
    }

    public void setNumero(int numero) {
        this.numero = numero;
    }

    public Cliente getCliente() {
        return cliente;
    }

    public void setCliente(Cliente cliente) {
        this.cliente = cliente;
    }

    public String getObservaciones() {
        return observaciones;
    }

    public void setObservaciones(String observaciones) {
        this.observaciones = observaciones;
    }

    public ArrayList<Producto> getListaProductos() {
        return listaProductos;
    }

    public void setListaProductos(ArrayList<Producto> listaProductos) {
        this.listaProductos = listaProductos;
    }

    public int getPrecioTotal() {
        return precioTotal;
    }

    public void setPrecioTotal(int precioTotal) {
        this.precioTotal = precioTotal;
    }

    @Override
    public String toString() {
        return numero + " " + cliente.getNombre();
    }

}
