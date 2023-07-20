// Joaquin Bonifacino - 243193 - Rafael Cadenas - 269150
package main;

import dominio.*;
import interfaz.MenuPrincipal;
import java.io.File;
import java.io.FileInputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.util.ArrayList;
import javax.swing.JFileChooser;
import javax.swing.JOptionPane;
import javax.swing.filechooser.FileNameExtensionFilter;

public class main {

    public static void main(String[] args) {

        String[] opciones = new String[]{"Cargar Sesion Anterior", "Cargar Sesion Nueva", "Cargar archivo de sesion"};
        int respuesta = JOptionPane.showOptionDialog(null, "Que desea hacer?", "Bienvenido",
                JOptionPane.DEFAULT_OPTION, JOptionPane.PLAIN_MESSAGE,
                null, opciones, opciones[0]);

        String path = "";
        Modelo m = null;
        if (respuesta == 0) {
            m = cargarSistema();
        } else {
            if (respuesta == 2) {
                path = elegirArchivo();
                if (!path.equals("null")) {
                    m = cargadorCSV(path);
                }
            } else {
                if (respuesta == -1) {
                    JOptionPane.showMessageDialog(null, "No se eligio ninguna opcion, se procedera a cargar el sistema vacio", "ATENCION", JOptionPane.ERROR_MESSAGE);

                }
            }

        }

        if (m == null) {
            m = new Modelo();
        }
        MenuPrincipal menu = new MenuPrincipal(m);
        menu.setVisible(true);

    }

    public static Modelo cargarSistema() {
        Modelo m = null;
        ObjectInputStream datos = null;
        try {
            FileInputStream archivo = new FileInputStream("Datos");
            datos = new ObjectInputStream(archivo);

            m = (Modelo) datos.readObject();
            datos.close();

        } catch (ClassNotFoundException | IOException | java.lang.IllegalStateException ex) {

            JOptionPane.showMessageDialog(null, "No se pudo cargar la sesion anterior correctamente, se procedera a cargar el sistema vacio", "ATENCION", JOptionPane.ERROR_MESSAGE);

        }
        return m;

    }

    public static String elegirArchivo() {
        String path = "";
        final JFileChooser fc = new JFileChooser();
        FileNameExtensionFilter filter = new FileNameExtensionFilter("CSV FILES", "csv", "csv");
        fc.setFileFilter(filter);
        File file = null;

        boolean eligio = false;

        try {
            fc.showOpenDialog(null);
            file = fc.getSelectedFile();
            if (String.valueOf(file).equals("null")) {
                JOptionPane.showMessageDialog(null, "No se eligio ninguna archivo, se procedera a cargar el sistema vacio", "ATENCION", JOptionPane.ERROR_MESSAGE);
            } else {
                eligio = true;
            }
            path = String.valueOf(file);

        } catch (java.lang.NullPointerException j) {

            System.out.println("El file devuelto por el explorer esta vacio");
        }

        return path;
    }

    public static Modelo cargadorCSV(String path) {
        Modelo m;
        m = new Modelo();

        ArchivoLectura arch = new ArchivoLectura(path);
        arch.hayMasLineas();
        String linea = arch.linea();

        linea = linea.replaceAll(";", "");
        int cant;
        cant = Integer.parseInt(linea);
        arch.hayMasLineas();
        try {
            for (int i = 0; i < cant; i++) {
                String[] lineaActual = arch.linea().split(";");
                Cliente c = new Cliente(lineaActual[0], lineaActual[1], lineaActual[2]);
                m.setClienteLista(c);
                arch.hayMasLineas();
            }

            linea = arch.linea();
            linea = linea.replaceAll(";", "");
            cant = Integer.parseInt(linea);

            for (int i = 0; i < cant; i++) {
                arch.hayMasLineas();
                String[] lineaActual = arch.linea().split(";");

                Categoria c = new Categoria(lineaActual[1], Integer.parseInt(lineaActual[2]), lineaActual[0]);
                m.setCategoriaList(c);

            }

            arch.hayMasLineas();
            linea = arch.linea();
            linea = linea.replaceAll(";", "");
            cant = Integer.parseInt(linea);

            for (int i = 0; i < cant; i++) {
                arch.hayMasLineas();
                String[] lineaActual = arch.linea().split(";");
                ArrayList<Categoria> array = new ArrayList<>();

                for (int j = 2; j < lineaActual.length; j++) {
                    array.add(m.buscadorCategoria(lineaActual[j]));
                }

                Producto p = new Producto(array, lineaActual[0], Integer.parseInt(lineaActual[1]));
                m.setProductoList(p);

            }
        } catch (java.lang.ArrayIndexOutOfBoundsException | java.lang.NumberFormatException e) {
            JOptionPane.showMessageDialog(null, "El archivo ingresado no tiene el formato adecuado, se cargar la sesion vacia", "ATENCION", JOptionPane.ERROR_MESSAGE);
        }

        arch.cerrar();

        return m;
    }
}
