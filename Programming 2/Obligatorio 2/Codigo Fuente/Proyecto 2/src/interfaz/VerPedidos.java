// Joaquin Bonifacino - 243193 - Rafael Cadenas - 269150
package interfaz;

import dominio.Modelo;
import dominio.Pedido;
import java.util.Observable;
import java.util.Observer;
import javax.swing.JOptionPane;

public class VerPedidos extends javax.swing.JFrame implements Observer {

    private Modelo modelo;

    public VerPedidos() {
        initComponents();
    }

    public VerPedidos(Modelo modelo) {
        this.modelo = modelo;
        initComponents();
        jListPedidos.setListData(modelo.getListaPedidos().toArray());
        modelo.addObserver(this);
        this.update(null, null);

    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jLabelNombre1 = new javax.swing.JLabel();
        jScrollPane1 = new javax.swing.JScrollPane();
        jListPedidos = new javax.swing.JList();
        jLabelNombre2 = new javax.swing.JLabel();
        jTextFieldTotal = new javax.swing.JTextField();
        jLabelNombre3 = new javax.swing.JLabel();
        jLabelNombre = new javax.swing.JLabel();
        jScrollPane2 = new javax.swing.JScrollPane();
        jTextAreaObservaciones = new javax.swing.JTextArea();
        jLabelNombre4 = new javax.swing.JLabel();
        jScrollPane3 = new javax.swing.JScrollPane();
        jListProductos = new javax.swing.JList();
        jButton1 = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);
        setResizable(false);
        getContentPane().setLayout(null);

        jLabelNombre1.setFont(new java.awt.Font("Tahoma", 0, 24)); // NOI18N
        jLabelNombre1.setText("Productos:");
        getContentPane().add(jLabelNombre1);
        jLabelNombre1.setBounds(220, 200, 112, 29);

        jScrollPane1.setViewportView(jListPedidos);

        getContentPane().add(jScrollPane1);
        jScrollPane1.setBounds(20, 60, 170, 190);

        jLabelNombre2.setFont(new java.awt.Font("Tahoma", 0, 24)); // NOI18N
        jLabelNombre2.setText("Elegir Pedido");
        getContentPane().add(jLabelNombre2);
        jLabelNombre2.setBounds(30, 20, 136, 29);

        jTextFieldTotal.setEditable(false);
        getContentPane().add(jTextFieldTotal);
        jTextFieldTotal.setBounds(300, 58, 60, 20);

        jLabelNombre3.setFont(new java.awt.Font("Tahoma", 0, 24)); // NOI18N
        jLabelNombre3.setText("Total:");
        getContentPane().add(jLabelNombre3);
        jLabelNombre3.setBounds(220, 50, 61, 29);

        jLabelNombre.setFont(new java.awt.Font("Tahoma", 0, 24)); // NOI18N
        jLabelNombre.setText("$");
        getContentPane().add(jLabelNombre);
        jLabelNombre.setBounds(370, 50, 13, 29);

        jTextAreaObservaciones.setEditable(false);
        jTextAreaObservaciones.setColumns(20);
        jTextAreaObservaciones.setRows(5);
        jScrollPane2.setViewportView(jTextAreaObservaciones);

        getContentPane().add(jScrollPane2);
        jScrollPane2.setBounds(220, 120, 310, 70);

        jLabelNombre4.setFont(new java.awt.Font("Tahoma", 0, 24)); // NOI18N
        jLabelNombre4.setText("Observaciones:");
        getContentPane().add(jLabelNombre4);
        jLabelNombre4.setBounds(220, 90, 162, 29);

        jListProductos.setCursor(new java.awt.Cursor(java.awt.Cursor.DEFAULT_CURSOR));
        jListProductos.setEnabled(false);
        jScrollPane3.setViewportView(jListProductos);

        getContentPane().add(jScrollPane3);
        jScrollPane3.setBounds(220, 230, 310, 90);

        jButton1.setFont(new java.awt.Font("Tahoma", 0, 24)); // NOI18N
        jButton1.setText("Elegir");
        jButton1.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButton1ActionPerformed(evt);
            }
        });
        getContentPane().add(jButton1);
        jButton1.setBounds(40, 270, 130, 40);

        setSize(new java.awt.Dimension(564, 382));
        setLocationRelativeTo(null);
    }// </editor-fold>//GEN-END:initComponents

    private void jButton1ActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButton1ActionPerformed
        if (!jListPedidos.isSelectionEmpty()) {
            
            // Toma el objeto pedido seleccionado y muestra sus detalles
            Pedido pedidoAMostrar = (Pedido) jListPedidos.getSelectedValue();
            jTextFieldTotal.setText(String.valueOf(pedidoAMostrar.getPrecioTotal()));
            jTextAreaObservaciones.setText(pedidoAMostrar.getObservaciones());

            jListProductos.setListData(pedidoAMostrar.getListaProductos().toArray());
        } else {
            JOptionPane.showMessageDialog(this, "Error, no se selecciono ningun pedido de la lista", "ERROR", JOptionPane.ERROR_MESSAGE);
        }
    }//GEN-LAST:event_jButton1ActionPerformed


    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton jButton1;
    private javax.swing.JLabel jLabelNombre;
    private javax.swing.JLabel jLabelNombre1;
    private javax.swing.JLabel jLabelNombre2;
    private javax.swing.JLabel jLabelNombre3;
    private javax.swing.JLabel jLabelNombre4;
    private javax.swing.JList jListPedidos;
    private javax.swing.JList jListProductos;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JScrollPane jScrollPane2;
    private javax.swing.JScrollPane jScrollPane3;
    private javax.swing.JTextArea jTextAreaObservaciones;
    private javax.swing.JTextField jTextFieldTotal;
    // End of variables declaration//GEN-END:variables

    @Override
    public void update(Observable o, Object o1) {
        jListPedidos.setListData(modelo.getListaPedidos().toArray());
    }

}
