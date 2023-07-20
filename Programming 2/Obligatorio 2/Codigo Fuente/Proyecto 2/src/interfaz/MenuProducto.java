// Joaquin Bonifacino - 243193 - Rafael Cadenas - 269150
package interfaz;

import java.awt.event.KeyEvent;
import dominio.*;
import java.util.ArrayList;
import java.util.Observable;
import java.util.Observer;
import javax.swing.JOptionPane;

public class MenuProducto extends javax.swing.JFrame implements Observer {

    private Modelo modelo;

    public MenuProducto() {
        initComponents();
    }

    public MenuProducto(Modelo modelo) {
        this.modelo = modelo;
        initComponents();

        modelo.addObserver(this);
        this.update(null, null);
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jLabelNombre = new javax.swing.JLabel();
        jButtonReset = new javax.swing.JButton();
        jButtonGuardar = new javax.swing.JButton();
        jScrollPane1 = new javax.swing.JScrollPane();
        jListCategorias = new javax.swing.JList();
        jLabelNombre1 = new javax.swing.JLabel();
        jLabelNombre2 = new javax.swing.JLabel();
        jTextFieldNombre = new javax.swing.JTextField();
        jTextFieldPrecio = new javax.swing.JTextField();
        jLabelNombre3 = new javax.swing.JLabel();

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);
        setResizable(false);
        getContentPane().setLayout(null);

        jLabelNombre.setFont(new java.awt.Font("Tahoma", 0, 24)); // NOI18N
        jLabelNombre.setText("$");
        getContentPane().add(jLabelNombre);
        jLabelNombre.setBounds(510, 172, 13, 29);

        jButtonReset.setText("Reset");
        jButtonReset.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButtonResetActionPerformed(evt);
            }
        });
        getContentPane().add(jButtonReset);
        jButtonReset.setBounds(280, 300, 110, 40);

        jButtonGuardar.setText("Guardar");
        jButtonGuardar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButtonGuardarActionPerformed(evt);
            }
        });
        getContentPane().add(jButtonGuardar);
        jButtonGuardar.setBounds(140, 300, 120, 40);

        jScrollPane1.setViewportView(jListCategorias);

        getContentPane().add(jScrollPane1);
        jScrollPane1.setBounds(30, 80, 170, 180);

        jLabelNombre1.setFont(new java.awt.Font("Tahoma", 0, 24)); // NOI18N
        jLabelNombre1.setText("Elegir Categoría");
        getContentPane().add(jLabelNombre1);
        jLabelNombre1.setBounds(30, 40, 167, 29);

        jLabelNombre2.setFont(new java.awt.Font("Tahoma", 0, 24)); // NOI18N
        jLabelNombre2.setText("Nombre");
        getContentPane().add(jLabelNombre2);
        jLabelNombre2.setBounds(230, 120, 84, 29);
        getContentPane().add(jTextFieldNombre);
        jTextFieldNombre.setBounds(340, 130, 160, 20);

        jTextFieldPrecio.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyTyped(java.awt.event.KeyEvent evt) {
                jTextFieldPrecioKeyTyped(evt);
            }
        });
        getContentPane().add(jTextFieldPrecio);
        jTextFieldPrecio.setBounds(440, 180, 60, 20);

        jLabelNombre3.setFont(new java.awt.Font("Tahoma", 0, 24)); // NOI18N
        jLabelNombre3.setText("Precio");
        getContentPane().add(jLabelNombre3);
        jLabelNombre3.setBounds(230, 170, 64, 30);

        setSize(new java.awt.Dimension(564, 392));
        setLocationRelativeTo(null);
    }// </editor-fold>//GEN-END:initComponents

    private void jButtonResetActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButtonResetActionPerformed
        jTextFieldNombre.setText("");
        jTextFieldPrecio.setText("");
        jListCategorias.clearSelection();
    }//GEN-LAST:event_jButtonResetActionPerformed

    private void jTextFieldPrecioKeyTyped(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_jTextFieldPrecioKeyTyped
        //Filtro para aceptar solo numeros, delete y backspace, en el caso de que no
        //sea ninguno de estos caracteres lo consume
        char tecla = evt.getKeyChar();
        if (!((tecla >= '0') && (tecla <= '9')
                || (tecla == KeyEvent.VK_BACK_SPACE)
                || (tecla == KeyEvent.VK_DELETE))) {

            evt.consume();
        }
    }//GEN-LAST:event_jTextFieldPrecioKeyTyped

    private void jButtonGuardarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButtonGuardarActionPerformed
        if (jTextFieldNombre.getText().equalsIgnoreCase("") || jTextFieldPrecio.getText().equalsIgnoreCase("")) {
            JOptionPane.showMessageDialog(this, "Error, por favor complete todos los campos del formulario", "ERROR", JOptionPane.ERROR_MESSAGE);
        } else {
            try {

                Producto p = new Producto((ArrayList<Categoria>) jListCategorias.getSelectedValuesList(), jTextFieldNombre.getText(), Integer.parseInt(jTextFieldPrecio.getText()));
                if (modelo.existeProducto(p)) {
                    JOptionPane.showMessageDialog(this, "Error, se ha ingresado un Producto con un nombre ya existente", "ERROR", JOptionPane.ERROR_MESSAGE);

                } else {

                    modelo.setProductoList(p);

                    JOptionPane.showMessageDialog(this, "Producto registrado correctamente", "Producto registrado", JOptionPane.INFORMATION_MESSAGE);
                    this.reset();

                }

            } catch (java.lang.ClassCastException e) {
                JOptionPane.showMessageDialog(this, "Error, por favor seleccione una de las categorias", "ERROR", JOptionPane.ERROR_MESSAGE);
            }
        }


    }//GEN-LAST:event_jButtonGuardarActionPerformed

    private void reset() {
        jTextFieldNombre.setText("");
        jListCategorias.setSelectedIndex(0);
        jTextFieldPrecio.setText("");
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton jButtonGuardar;
    private javax.swing.JButton jButtonReset;
    private javax.swing.JLabel jLabelNombre;
    private javax.swing.JLabel jLabelNombre1;
    private javax.swing.JLabel jLabelNombre2;
    private javax.swing.JLabel jLabelNombre3;
    private javax.swing.JList jListCategorias;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JTextField jTextFieldNombre;
    private javax.swing.JTextField jTextFieldPrecio;
    // End of variables declaration//GEN-END:variables

    @Override
    public void update(Observable o, Object o1) {
        jListCategorias.setListData(modelo.getListaCategorias().toArray());

    }
}
