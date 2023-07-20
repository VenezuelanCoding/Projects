// Joaquin Bonifacino - 243193 - Rafael Cadenas - 269150
package dominio;

import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectOutputStream;
import java.io.Serializable;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.Observable;

public class Modelo extends Observable implements Serializable {

    private ArrayList<Producto> listaProductos;
    private ArrayList<Cliente> listaClientes;
    private ArrayList<Categoria> listaCategorias;
    private ArrayList<Pedido> listaPedidos;
    private Cliente clienteSeleccionado;
    private Pedido pedidoSeleccionado;
    private ArrayList<Producto> productosDePedidoSeleccionado;
    private int numeroDePedidoSeleccionado = 1;

    public Modelo() {
        listaClientes = new ArrayList<>();
        listaPedidos = new ArrayList<>();
        listaCategorias = new ArrayList<>();
        listaProductos = new ArrayList<>();
        productosDePedidoSeleccionado = new ArrayList<>();

    }

    public int getNumeroDePedidoSeleccionado() {
        return numeroDePedidoSeleccionado;
    }

    public void setNumeroDePedidoSeleccionado(int numeroDePedidoSeleccionado) {
        this.numeroDePedidoSeleccionado = numeroDePedidoSeleccionado;
    }

    public ArrayList<Producto> getProductosDePedidoSeleccionado() {
        return productosDePedidoSeleccionado;
    }

    public void setProductosDePedidoSeleccionado(ArrayList<Producto> productosDePedidoSeleccionado) {
        this.productosDePedidoSeleccionado = productosDePedidoSeleccionado;
    }

    public ArrayList<Producto> getListaProductos() {
        return listaProductos;
    }

    public void setListaProductos(ArrayList<Producto> listaProductos) {
        this.listaProductos = listaProductos;
    }

    public ArrayList<Cliente> getListaClientes() {
        return listaClientes;
    }

    public void setListaClientes(ArrayList<Cliente> listaClientes) {
        this.listaClientes = listaClientes;
    }

    public ArrayList<Categoria> getListaCategorias() {
        return listaCategorias;
    }

    public void setListaCategorias(ArrayList<Categoria> listaCategorias) {
        this.listaCategorias = listaCategorias;
    }

    public ArrayList<Pedido> getListaPedidos() {
        return listaPedidos;
    }

    public void setListaPedidos(ArrayList<Pedido> listaPedidos) {
        this.listaPedidos = listaPedidos;
    }

    public void setClienteLista(Cliente c) {
        this.getListaClientes().add(c);
        setChanged();
        notifyObservers();
    }

    public Cliente getClienteSeleccionado() {
        return clienteSeleccionado;
    }

    public void setClienteSeleccionado(Cliente clienteSeleccionado) {
        this.clienteSeleccionado = clienteSeleccionado;
        setChanged();
        notifyObservers();
    }

    public Pedido getPedidoSeleccionado() {
        return pedidoSeleccionado;
    }

    public void setPedidoSeleccionado(Pedido pedidoSeleccionado) {
        this.pedidoSeleccionado = pedidoSeleccionado;
        setChanged();
        notifyObservers();
    }

    public void setCategoriaList(Categoria cat) {
        this.listaCategorias.add(cat);
        setChanged();
        notifyObservers();

    }

    public void setProductoList(Producto p) {
        this.listaProductos.add(p);
        setChanged();
        notifyObservers();
    }

    //Final de getters y setters
    //Verifica si el cliente ya existe en la lista
    public boolean clienteExiste(Cliente c) {
        boolean existe = false;
        Iterator<Cliente> it = this.getListaClientes().iterator();
        while (it.hasNext() && !existe) {
            Cliente cd = it.next();
            if (c.getNombre().equalsIgnoreCase(cd.getNombre())) {
                existe = true;
            }

        }

        return existe;

    }

    //Verifica si la categoria ya existe en la lista
    public boolean existeCategoria(Categoria cat) {
        boolean existe = false;

        Iterator<Categoria> it = this.getListaCategorias().iterator();
        while (it.hasNext() && !existe) {
            Categoria catIt = it.next();
            if (catIt.getDescripcion().equalsIgnoreCase(cat.getDescripcion())) {
                existe = true;
            }
        }

        return existe;
    }

    //Verifica si el producto ya existe en la lista
    public boolean existeProducto(Producto p) {

        boolean existe = false;
        Iterator<Producto> it = this.getListaProductos().iterator();
        while (it.hasNext() && !existe) {
            Producto pIt = it.next();
            if (pIt.getNombre().equalsIgnoreCase(p.getNombre())) {
                existe = true;
            }
        }
        return existe;
    }

    //Se utiliza para saber si la categoria de un producto corresponde a la categoria seleccionada
    public boolean categoriaDentroDeListaDeCategorias(Categoria c, ArrayList<Categoria> lista) {
        boolean esta = false;
        Iterator<Categoria> it = lista.iterator();
        while (it.hasNext()) {
            Categoria nextElement = it.next();
            if (c.equals(nextElement)) {
                esta = true;
            }
        }
        return esta;
    }

    //Recibe el String del boton y devuelve el objeto Producto en el 
    //arrayList de productos que corresponde a ese String
    public Producto toStringBotonAObjeto(String texto) {
        Producto objeto = null;

        for (int i = 0; i < this.getListaProductos().size(); i++) {

            if (this.getListaProductos().get(i).toString().equals(texto)) {
                objeto = this.getListaProductos().get(i);
            }

        }

        return objeto;
    }

    //Calcula el total del precio de cierto pedido
    public int calcularTotalPedido(ArrayList<Producto> lista) {

        int total = 0;
        Iterator<Producto> it = this.getProductosDePedidoSeleccionado().iterator();
        while (it.hasNext()) {
            Producto nuevo = it.next();

            total += nuevo.getPrecio();

        }
        return total;
    }

    
    //Agrega el pedido a la lista de pedidos
    public void cargarListaPedidoALista(Pedido pedido) {

        this.getListaPedidos().add(pedido);
        setChanged();
        notifyObservers();

    }

    //Serializa y graba el objeto Modelo
    public void guardarSistema() {
        try {
            FileOutputStream archivo = new FileOutputStream("Datos");
            ObjectOutputStream datos = new ObjectOutputStream(archivo);
            datos.writeObject(this);

            datos.close();
        } catch (IOException e) {
            System.out.println("No se pudo guardar");
        }

    }

    //Devuelve la lista de clientes que incluyan el String
    public ArrayList<Cliente> buscadorClientes(String texto) {
        ArrayList<Cliente> array = new ArrayList<>();
        Iterator<Cliente> it = this.getListaClientes().iterator();
        while (it.hasNext()) {

            Cliente cliente = it.next();
            if (cliente.getNombre().toLowerCase().contains(texto.toLowerCase())) {
                array.add(cliente);
            }

        }

        return array;

    }

    //A partir del nombre de la categoria devuelve el objeto Categoria
    public Categoria buscadorCategoria(String nombre) {
        Categoria c = null;
        boolean existe = false;

        Iterator<Categoria> it = this.getListaCategorias().iterator();
        while (it.hasNext() && !existe) {
            Categoria catIt = it.next();
            if (catIt.getNombre().equals(nombre)) {
                existe = true;
                c = catIt;
            }
        }

        return c;

    }

}
