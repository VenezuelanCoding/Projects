// Joaquin Bonifacino - 243193 - Rafael Cadenas - 269150
package interfaz;

import dominio.*;
import dominio.Producto;
import java.awt.Color;
import java.awt.Insets;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Iterator;
import java.util.Observable;
import java.util.Observer;
import javax.swing.DefaultComboBoxModel;
import javax.swing.JButton;
import javax.swing.JOptionPane;

public class MenuPrincipal extends javax.swing.JFrame implements Observer {

    private Modelo modelo;

    public MenuPrincipal() {
        initComponents();
    }

    public MenuPrincipal(Modelo modelo) {
        this.modelo = modelo;
        initComponents();
        jLabelPedido.setText("Pedido " + modelo.getNumeroDePedidoSeleccionado() + " $" + modelo.calcularTotalPedido(modelo.getProductosDePedidoSeleccionado()));
        modelo.addObserver(this);
        this.update(null, null);

    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        buttonGroupOrden = new javax.swing.ButtonGroup();
        jPanelCliente = new javax.swing.JPanel();
        jButtonElegirCliente = new javax.swing.JButton();
        jLabelInfoCliente = new javax.swing.JLabel();
        jLabelObservaciones = new javax.swing.JLabel();
        jTextFieldObservaciones = new javax.swing.JTextField();
        jRadioButtonAlfabetico = new javax.swing.JRadioButton();
        jRadioButtonPrioridad = new javax.swing.JRadioButton();
        jPanelSubMenu = new javax.swing.JPanel();
        jButtonClientes = new javax.swing.JButton();
        jButtonCategorias = new javax.swing.JButton();
        jButtonProductos = new javax.swing.JButton();
        jButtonVerPedidos = new javax.swing.JButton();
        jPanelCombo = new javax.swing.JPanel();
        jComboBox = new javax.swing.JComboBox();
        jPanelInfoPedido = new javax.swing.JPanel();
        jButtonReiniciarPedido = new javax.swing.JButton();
        jLabelPedido = new javax.swing.JLabel();
        jPanelComidas = new javax.swing.JPanel();
        jPanelMenuPedido = new javax.swing.JPanel();
        jScrollPane1 = new javax.swing.JScrollPane();
        jListPedido = new javax.swing.JList();
        jButtonEliminarPedido = new javax.swing.JButton();
        jButtonGrabarPedido = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);
        setLocation(new java.awt.Point(0, 0));
        addWindowListener(new java.awt.event.WindowAdapter() {
            public void windowClosing(java.awt.event.WindowEvent evt) {
                formWindowClosing(evt);
            }
        });
        getContentPane().setLayout(new java.awt.GridLayout(3, 2));

        jPanelCliente.setLayout(new java.awt.GridLayout(3, 2));

        jButtonElegirCliente.setText("Elegir Cliente");
        jButtonElegirCliente.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButtonElegirClienteActionPerformed(evt);
            }
        });
        jPanelCliente.add(jButtonElegirCliente);

        jLabelInfoCliente.setBackground(new java.awt.Color(204, 255, 204));
        jLabelInfoCliente.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        jLabelInfoCliente.setText("Seleccione un cliente");
        jLabelInfoCliente.setOpaque(true);
        jPanelCliente.add(jLabelInfoCliente);

        jLabelObservaciones.setBackground(new java.awt.Color(204, 255, 204));
        jLabelObservaciones.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        jLabelObservaciones.setText("Observaciones:");
        jLabelObservaciones.setOpaque(true);
        jPanelCliente.add(jLabelObservaciones);
        jPanelCliente.add(jTextFieldObservaciones);

        buttonGroupOrden.add(jRadioButtonAlfabetico);
        jRadioButtonAlfabetico.setSelected(true);
        jRadioButtonAlfabetico.setText("Categorías por orden Alfabético");
        jRadioButtonAlfabetico.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jRadioButtonAlfabeticoActionPerformed(evt);
            }
        });
        jPanelCliente.add(jRadioButtonAlfabetico);

        buttonGroupOrden.add(jRadioButtonPrioridad);
        jRadioButtonPrioridad.setText("Categorías por orden Prioridad");
        jRadioButtonPrioridad.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jRadioButtonPrioridadActionPerformed(evt);
            }
        });
        jPanelCliente.add(jRadioButtonPrioridad);

        getContentPane().add(jPanelCliente);

        jPanelSubMenu.setLayout(new java.awt.GridLayout(1, 0));

        jButtonClientes.setText("Clientes");
        jButtonClientes.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButtonClientesActionPerformed(evt);
            }
        });
        jPanelSubMenu.add(jButtonClientes);

        jButtonCategorias.setText("Categorías");
        jButtonCategorias.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButtonCategoriasActionPerformed(evt);
            }
        });
        jPanelSubMenu.add(jButtonCategorias);

        jButtonProductos.setText("Productos");
        jButtonProductos.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButtonProductosActionPerformed(evt);
            }
        });
        jPanelSubMenu.add(jButtonProductos);

        jButtonVerPedidos.setText("Ver Pedidos");
        jButtonVerPedidos.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButtonVerPedidosActionPerformed(evt);
            }
        });
        jPanelSubMenu.add(jButtonVerPedidos);

        getContentPane().add(jPanelSubMenu);

        jPanelCombo.setLayout(new java.awt.GridLayout(1, 0));

        jComboBox.setModel(new javax.swing.DefaultComboBoxModel(new String[] { "Item 1", "Item 2", "Item 3", "Item 4" }));
        jComboBox.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jComboBoxActionPerformed(evt);
            }
        });
        jPanelCombo.add(jComboBox);

        getContentPane().add(jPanelCombo);

        jPanelInfoPedido.setLayout(new java.awt.GridLayout(2, 0));

        jButtonReiniciarPedido.setText("Reiniciar Pedido");
        jButtonReiniciarPedido.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButtonReiniciarPedidoActionPerformed(evt);
            }
        });
        jPanelInfoPedido.add(jButtonReiniciarPedido);

        jLabelPedido.setBackground(new java.awt.Color(204, 255, 204));
        jLabelPedido.setFont(new java.awt.Font("Tahoma", 0, 24)); // NOI18N
        jLabelPedido.setHorizontalAlignment(javax.swing.SwingConstants.CENTER);
        jLabelPedido.setOpaque(true);
        jPanelInfoPedido.add(jLabelPedido);

        getContentPane().add(jPanelInfoPedido);

        jPanelComidas.setLayout(new java.awt.GridLayout(3, 0));
        getContentPane().add(jPanelComidas);

        jPanelMenuPedido.setLayout(new java.awt.GridLayout(1, 0));

        jScrollPane1.setViewportView(jListPedido);

        jPanelMenuPedido.add(jScrollPane1);

        jButtonEliminarPedido.setText("Eliminar Item");
        jButtonEliminarPedido.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButtonEliminarPedidoActionPerformed(evt);
            }
        });
        jPanelMenuPedido.add(jButtonEliminarPedido);

        jButtonGrabarPedido.setText("Grabar Pedido");
        jButtonGrabarPedido.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButtonGrabarPedidoActionPerformed(evt);
            }
        });
        jPanelMenuPedido.add(jButtonGrabarPedido);

        getContentPane().add(jPanelMenuPedido);

        setSize(new java.awt.Dimension(1052, 501));
        setLocationRelativeTo(null);
    }// </editor-fold>//GEN-END:initComponents

    private void jButtonClientesActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButtonClientesActionPerformed
        MenuCliente menuCliente = new MenuCliente(modelo);
        menuCliente.setVisible(true);
    }//GEN-LAST:event_jButtonClientesActionPerformed

    private void jButtonCategoriasActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButtonCategoriasActionPerformed
        MenuCategoria menuCategoria = new MenuCategoria(modelo);
        menuCategoria.setVisible(true);
    }//GEN-LAST:event_jButtonCategoriasActionPerformed

    private void jButtonProductosActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButtonProductosActionPerformed
        MenuProducto menuProducto = new MenuProducto(modelo);
        menuProducto.setVisible(true);
    }//GEN-LAST:event_jButtonProductosActionPerformed

    private void jButtonVerPedidosActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButtonVerPedidosActionPerformed
        VerPedidos verPedidos = new VerPedidos(modelo);
        verPedidos.setVisible(true);
    }//GEN-LAST:event_jButtonVerPedidosActionPerformed

    private void jButtonElegirClienteActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButtonElegirClienteActionPerformed
        VerClientes verClientes = new VerClientes(modelo);
        verClientes.setVisible(true);
    }//GEN-LAST:event_jButtonElegirClienteActionPerformed

    private void jRadioButtonAlfabeticoActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jRadioButtonAlfabeticoActionPerformed
        if (jRadioButtonAlfabetico.isSelected()) {
            //Le pasa el criterio segun el combo seleccionado
            Collections.sort(modelo.getListaCategorias(), new OrdenarNombre());
        }
        this.update(null, null);


    }//GEN-LAST:event_jRadioButtonAlfabeticoActionPerformed

    private void jRadioButtonPrioridadActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jRadioButtonPrioridadActionPerformed

        if (jRadioButtonPrioridad.isSelected()) {
            //Le pasa el criterio segun el combo seleccionado
            Collections.sort(modelo.getListaCategorias(), new OrdenarPrioriedad());

        }
        this.update(null, null);


    }//GEN-LAST:event_jRadioButtonPrioridadActionPerformed

    private void jButtonGrabarPedidoActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButtonGrabarPedidoActionPerformed
        if (!jLabelInfoCliente.getText().equals("Seleccione un cliente")) {
            if (modelo.getProductosDePedidoSeleccionado().size() > 0) {

                //Genero el objeto pedido con sus productos, lo agrego a la lista de pedidos y finalmente
                // subo en 1 el numero de pedido
                ArrayList<Producto> listaProducto = new ArrayList<>();
                Iterator<Producto> it = modelo.getProductosDePedidoSeleccionado().iterator();
                while (it.hasNext()) {
                    listaProducto.add(it.next());

                }

                Pedido pedido = new Pedido(modelo.getClienteSeleccionado(), jTextFieldObservaciones.getText(), listaProducto, modelo.calcularTotalPedido(modelo.getProductosDePedidoSeleccionado()));
                modelo.cargarListaPedidoALista(pedido);
                modelo.setNumeroDePedidoSeleccionado(modelo.getNumeroDePedidoSeleccionado() + 1);

                reset();

            } else {
                JOptionPane.showMessageDialog(this, "Error, no se agrego ningun producto al pedido", "ERROR", JOptionPane.ERROR_MESSAGE);

            }
        } else {
            JOptionPane.showMessageDialog(this, "Error, no se selecciono ningun cliente para el pedido actual", "ERROR", JOptionPane.ERROR_MESSAGE);
        }

    }//GEN-LAST:event_jButtonGrabarPedidoActionPerformed

    private void jButtonEliminarPedidoActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButtonEliminarPedidoActionPerformed
        if (jListPedido.isSelectionEmpty()) {
            JOptionPane.showMessageDialog(this, "Error, no se selecciono ningun item de la lista", "ERROR", JOptionPane.ERROR_MESSAGE);
        } else {

            //Utilizo los valores seleccionados del JList para remover el o los objetos de la lista y recalcular el costo total del pedido
            ArrayList<Producto> lista = (ArrayList<Producto>) jListPedido.getSelectedValuesList();

            Iterator<Producto> it = lista.iterator();
            while (it.hasNext()) {
                modelo.getProductosDePedidoSeleccionado().remove(it.next());
            }

            jListPedido.setListData(modelo.getProductosDePedidoSeleccionado().toArray());
            jLabelPedido.setText("Pedido " + modelo.getNumeroDePedidoSeleccionado() + " $" + modelo.calcularTotalPedido(modelo.getProductosDePedidoSeleccionado()));

        }
    }//GEN-LAST:event_jButtonEliminarPedidoActionPerformed

    private void jButtonReiniciarPedidoActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButtonReiniciarPedidoActionPerformed
        reset();
    }//GEN-LAST:event_jButtonReiniciarPedidoActionPerformed

    private void jComboBoxActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jComboBoxActionPerformed
        jPanelComidas.removeAll();
        jPanelComidas.repaint();

        //Creador dinamico de botones para mostrar productos de las categorias
        Iterator<Producto> it = modelo.getListaProductos().iterator();
        while (it.hasNext()) {

            Producto pd = it.next();

            if (modelo.categoriaDentroDeListaDeCategorias((Categoria) jComboBox.getSelectedItem(), pd.getListaCategoria())) {
                JButton nuevo = new JButton(" ");
                nuevo.setMargin(new Insets(-5, -5, -5, -5));
                nuevo.setBackground(Color.BLACK);
                nuevo.setForeground(Color.WHITE);
                nuevo.setText(pd.toString());

                nuevo.addActionListener(new ProductoListener());
                jPanelComidas.add(nuevo);
            }
        }

        jPanelComidas.revalidate();
        jPanelComidas.repaint();


    }//GEN-LAST:event_jComboBoxActionPerformed

    private void formWindowClosing(java.awt.event.WindowEvent evt) {//GEN-FIRST:event_formWindowClosing
        reset();
        modelo.guardarSistema();

    }//GEN-LAST:event_formWindowClosing
    private class ProductoListener implements ActionListener {

        @Override
        public void actionPerformed(ActionEvent e) {

            JButton cual = ((JButton) e.getSource());

            Producto pAgregado = modelo.toStringBotonAObjeto(cual.getText());

            modelo.getProductosDePedidoSeleccionado().add(pAgregado);

            jListPedido.setListData(modelo.getProductosDePedidoSeleccionado().toArray());

            jLabelPedido.setText("Pedido " + modelo.getNumeroDePedidoSeleccionado() + " $" + modelo.calcularTotalPedido(modelo.getProductosDePedidoSeleccionado()));

        }

    }

    public void reset() {
        //Funcion de reset para los campos necesarios
        modelo.setClienteSeleccionado(null);
        jLabelInfoCliente.setText("Seleccione un cliente");
        modelo.getProductosDePedidoSeleccionado().clear();
        jListPedido.setListData(modelo.getProductosDePedidoSeleccionado().toArray());
        jTextFieldObservaciones.setText("");
        jLabelPedido.setText("Pedido " + modelo.getNumeroDePedidoSeleccionado() + " $" + modelo.calcularTotalPedido(modelo.getProductosDePedidoSeleccionado()));
    }


    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.ButtonGroup buttonGroupOrden;
    private javax.swing.JButton jButtonCategorias;
    private javax.swing.JButton jButtonClientes;
    private javax.swing.JButton jButtonElegirCliente;
    private javax.swing.JButton jButtonEliminarPedido;
    private javax.swing.JButton jButtonGrabarPedido;
    private javax.swing.JButton jButtonProductos;
    private javax.swing.JButton jButtonReiniciarPedido;
    private javax.swing.JButton jButtonVerPedidos;
    private javax.swing.JComboBox jComboBox;
    private javax.swing.JLabel jLabelInfoCliente;
    private javax.swing.JLabel jLabelObservaciones;
    private javax.swing.JLabel jLabelPedido;
    private javax.swing.JList jListPedido;
    private javax.swing.JPanel jPanelCliente;
    private javax.swing.JPanel jPanelCombo;
    private javax.swing.JPanel jPanelComidas;
    private javax.swing.JPanel jPanelInfoPedido;
    private javax.swing.JPanel jPanelMenuPedido;
    private javax.swing.JPanel jPanelSubMenu;
    private javax.swing.JRadioButton jRadioButtonAlfabetico;
    private javax.swing.JRadioButton jRadioButtonPrioridad;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JTextField jTextFieldObservaciones;
    // End of variables declaration//GEN-END:variables

    @Override
    public void update(Observable o, Object o1) {

        if (modelo.getClienteSeleccionado() != null) {
            jLabelInfoCliente.setText(modelo.getClienteSeleccionado().toString());
        }

        int indice = jComboBox.getSelectedIndex();

        if (modelo.getListaCategorias() != null) {
            jComboBox.setModel(new DefaultComboBoxModel<>(modelo.getListaCategorias().toArray()));
        }

        if (indice != 0) {
            jComboBox.setSelectedIndex(indice);
        }
        jPanelComidas.removeAll();
        jPanelComidas.repaint();

        Iterator<Producto> it = modelo.getListaProductos().iterator();
        while (it.hasNext()) {

            Producto pd = it.next();

            if (modelo.categoriaDentroDeListaDeCategorias((Categoria) jComboBox.getSelectedItem(), pd.getListaCategoria())) {

                JButton nuevo = new JButton(" ");
                nuevo.setMargin(new Insets(-5, -5, -5, -5));
                nuevo.setBackground(Color.BLACK);
                nuevo.setForeground(Color.WHITE);
                nuevo.setText(pd.toString());

                nuevo.addActionListener(new ProductoListener());
                jPanelComidas.add(nuevo);
            }

        }
    }

}
