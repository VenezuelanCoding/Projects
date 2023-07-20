// Joaquin Bonifacino - 243193 - Rafael Cadenas - 269150
package interfaz;

import dominio.Cliente;
import dominio.Modelo;
import java.awt.event.KeyEvent;
import java.util.ArrayList;
import javax.swing.JOptionPane;

public class MenuCliente extends javax.swing.JFrame {

    private Modelo modelo;

    public MenuCliente() {
        initComponents();
    }

    public MenuCliente(Modelo modelo) {
        this.modelo = modelo;
        initComponents();

    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jLabelTelefono = new javax.swing.JLabel();
        jLabelDireccion = new javax.swing.JLabel();
        jLabelNombre = new javax.swing.JLabel();
        jButtonReset = new javax.swing.JButton();
        jButtonGuardar = new javax.swing.JButton();
        jTextFieldTelefono = new javax.swing.JTextField();
        jTextFieldNombre = new javax.swing.JTextField();
        jTextFieldDireccion = new javax.swing.JTextField();

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);
        setResizable(false);
        getContentPane().setLayout(null);

        jLabelTelefono.setFont(new java.awt.Font("Tahoma", 0, 24)); // NOI18N
        jLabelTelefono.setText("Teléfono");
        getContentPane().add(jLabelTelefono);
        jLabelTelefono.setBounds(50, 110, 100, 29);

        jLabelDireccion.setFont(new java.awt.Font("Tahoma", 0, 24)); // NOI18N
        jLabelDireccion.setText("Dirección");
        getContentPane().add(jLabelDireccion);
        jLabelDireccion.setBounds(50, 70, 110, 29);

        jLabelNombre.setFont(new java.awt.Font("Tahoma", 0, 24)); // NOI18N
        jLabelNombre.setText("Nombre");
        getContentPane().add(jLabelNombre);
        jLabelNombre.setBounds(50, 30, 84, 29);

        jButtonReset.setText("Reset");
        jButtonReset.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButtonResetActionPerformed(evt);
            }
        });
        getContentPane().add(jButtonReset);
        jButtonReset.setBounds(230, 180, 110, 40);

        jButtonGuardar.setText("Guardar");
        jButtonGuardar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButtonGuardarActionPerformed(evt);
            }
        });
        getContentPane().add(jButtonGuardar);
        jButtonGuardar.setBounds(90, 180, 120, 40);

        jTextFieldTelefono.addKeyListener(new java.awt.event.KeyAdapter() {
            public void keyTyped(java.awt.event.KeyEvent evt) {
                jTextFieldTelefonoKeyTyped(evt);
            }
        });
        getContentPane().add(jTextFieldTelefono);
        jTextFieldTelefono.setBounds(170, 120, 190, 20);
        getContentPane().add(jTextFieldNombre);
        jTextFieldNombre.setBounds(170, 40, 190, 20);
        getContentPane().add(jTextFieldDireccion);
        jTextFieldDireccion.setBounds(170, 80, 190, 20);

        setSize(new java.awt.Dimension(442, 296));
        setLocationRelativeTo(null);
    }// </editor-fold>//GEN-END:initComponents

    private void jButtonResetActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButtonResetActionPerformed
        reset();
    }//GEN-LAST:event_jButtonResetActionPerformed

    private void reset() {

        jTextFieldNombre.setText("");
        jTextFieldDireccion.setText("");
        jTextFieldTelefono.setText("");
    }

    //Filtro para aceptar solo numeros, delete y backspace, en el caso de que no
    //sea ninguno de estos caracteres lo consume
    private void jTextFieldTelefonoKeyTyped(java.awt.event.KeyEvent evt) {//GEN-FIRST:event_jTextFieldTelefonoKeyTyped
        char tecla = evt.getKeyChar();
        if (!((tecla >= '0') && (tecla <= '9')
                || (tecla == KeyEvent.VK_BACK_SPACE)
                || (tecla == KeyEvent.VK_DELETE))) {

            evt.consume();
        }
    }//GEN-LAST:event_jTextFieldTelefonoKeyTyped

    private void jButtonGuardarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButtonGuardarActionPerformed
        if (jTextFieldNombre.getText().equalsIgnoreCase("") || jTextFieldDireccion.getText().equalsIgnoreCase("") || jTextFieldTelefono.getText().equalsIgnoreCase("")) {
            JOptionPane.showMessageDialog(this, "Error, por favor complete todos los campos del formulario", "ERROR", JOptionPane.ERROR_MESSAGE);

        } else {
            //Creo el objeto y compruebo si existe o no ya en la lista de clientes
            //en el caso de que no, se agrega y se resetean los campos necesarios
            Cliente c = new Cliente(jTextFieldNombre.getText(), jTextFieldDireccion.getText(), jTextFieldTelefono.getText());
            if (modelo.clienteExiste(c)) {
                JOptionPane.showMessageDialog(this, "Error, se ha ingresado un cliente con un nombre ya existente", "ERROR", JOptionPane.ERROR_MESSAGE);
            } else {
                modelo.setClienteLista(c);
                JOptionPane.showMessageDialog(this, "Cliente registrado correctamente", "Cliente registrado", JOptionPane.INFORMATION_MESSAGE);
                this.reset();
            }
        }
    }//GEN-LAST:event_jButtonGuardarActionPerformed


    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton jButtonGuardar;
    private javax.swing.JButton jButtonReset;
    private javax.swing.JLabel jLabelDireccion;
    private javax.swing.JLabel jLabelNombre;
    private javax.swing.JLabel jLabelTelefono;
    private javax.swing.JTextField jTextFieldDireccion;
    private javax.swing.JTextField jTextFieldNombre;
    private javax.swing.JTextField jTextFieldTelefono;
    // End of variables declaration//GEN-END:variables

}
