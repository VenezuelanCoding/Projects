// Joaquin Bonifacino - 243193 - Rafael Cadenas - 269150
package interfaz;

import dominio.Cliente;
import dominio.Modelo;
import java.util.Observable;
import java.util.Observer;
import javax.swing.JOptionPane;

public class VerClientes extends javax.swing.JFrame implements Observer {

    private Modelo modelo;

    public VerClientes() {
        initComponents();
    }

    public VerClientes(Modelo modelo) {
        this.modelo = modelo;
        initComponents();
        jListaClientes.setListData(modelo.getListaClientes().toArray());
        modelo.addObserver(this);
        this.update(null, null);
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jLabelNombre = new javax.swing.JLabel();
        jScrollPane1 = new javax.swing.JScrollPane();
        jListaClientes = new javax.swing.JList();
        jButtonBuscar = new javax.swing.JButton();
        jButtonEscoger = new javax.swing.JButton();
        jTextFieldBuscador = new javax.swing.JTextField();
        jLabel1 = new javax.swing.JLabel();
        jButtonReset = new javax.swing.JButton();

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);
        setResizable(false);
        getContentPane().setLayout(null);

        jLabelNombre.setFont(new java.awt.Font("Tahoma", 0, 24)); // NOI18N
        jLabelNombre.setText("Clientes");
        getContentPane().add(jLabelNombre);
        jLabelNombre.setBounds(140, 20, 90, 29);

        jScrollPane1.setViewportView(jListaClientes);

        getContentPane().add(jScrollPane1);
        jScrollPane1.setBounds(20, 60, 160, 210);

        jButtonBuscar.setText("Buscar");
        jButtonBuscar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButtonBuscarActionPerformed(evt);
            }
        });
        getContentPane().add(jButtonBuscar);
        jButtonBuscar.setBounds(190, 170, 90, 40);

        jButtonEscoger.setText("Escoger");
        jButtonEscoger.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButtonEscogerActionPerformed(evt);
            }
        });
        getContentPane().add(jButtonEscoger);
        jButtonEscoger.setBounds(40, 280, 100, 40);
        getContentPane().add(jTextFieldBuscador);
        jTextFieldBuscador.setBounds(250, 140, 80, 20);

        jLabel1.setFont(new java.awt.Font("Tahoma", 0, 18)); // NOI18N
        jLabel1.setText("Buscador de Clientes");
        getContentPane().add(jLabel1);
        jLabel1.setBounds(210, 110, 170, 14);

        jButtonReset.setText("Reset");
        jButtonReset.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButtonResetActionPerformed(evt);
            }
        });
        getContentPane().add(jButtonReset);
        jButtonReset.setBounds(290, 170, 90, 40);

        setSize(new java.awt.Dimension(410, 387));
        setLocationRelativeTo(null);
    }// </editor-fold>//GEN-END:initComponents

    private void jButtonBuscarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButtonBuscarActionPerformed
        if (jTextFieldBuscador.getText().equalsIgnoreCase("")) {
            JOptionPane.showMessageDialog(this, "Error, por favor ingrese un cliente a buscar", "ERROR", JOptionPane.ERROR_MESSAGE);

        } else {

            jListaClientes.setListData(modelo.buscadorClientes(jTextFieldBuscador.getText()).toArray());

        }


    }//GEN-LAST:event_jButtonBuscarActionPerformed

    private void jButtonEscogerActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButtonEscogerActionPerformed
        if (jListaClientes.isSelectionEmpty()) {
            JOptionPane.showMessageDialog(this, "Error, no se selecciono ningun cliente de la lista", "ERROR", JOptionPane.ERROR_MESSAGE);
        } else {
            modelo.setClienteSeleccionado((Cliente) jListaClientes.getSelectedValue());
            this.dispose();
        }
    }//GEN-LAST:event_jButtonEscogerActionPerformed

    private void jButtonResetActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButtonResetActionPerformed
        jListaClientes.setListData(modelo.getListaClientes().toArray());
        jTextFieldBuscador.setText("");
    }//GEN-LAST:event_jButtonResetActionPerformed


    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton jButtonBuscar;
    private javax.swing.JButton jButtonEscoger;
    private javax.swing.JButton jButtonReset;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JLabel jLabelNombre;
    private javax.swing.JList jListaClientes;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JTextField jTextFieldBuscador;
    // End of variables declaration//GEN-END:variables

    @Override
    public void update(Observable o, Object o1) {
        jListaClientes.setListData(modelo.getListaClientes().toArray());

    }
}
