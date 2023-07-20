// Joaquin Bonifacino - 243193 - Rafael Cadenas - 269150
package interfaz;

import dominio.Categoria;
import dominio.Modelo;
import javax.swing.JOptionPane;

public class MenuCategoria extends javax.swing.JFrame {

    private Modelo modelo;

    public MenuCategoria() {
        initComponents();
    }

    public MenuCategoria(Modelo modelo) {
        this.modelo = modelo;
        initComponents();
    }

    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jLabelPrioridad = new javax.swing.JLabel();
        jButtonReset = new javax.swing.JButton();
        jButtonGuardar = new javax.swing.JButton();
        jScrollPane1 = new javax.swing.JScrollPane();
        jTextAreaDescripcion = new javax.swing.JTextArea();
        jLabelDescripcion = new javax.swing.JLabel();
        jComboBoxPrioriedad = new javax.swing.JComboBox<>();
        jLabelNombreCat = new javax.swing.JLabel();
        jTextFieldNombreCat = new javax.swing.JTextField();

        setDefaultCloseOperation(javax.swing.WindowConstants.DISPOSE_ON_CLOSE);
        setResizable(false);
        getContentPane().setLayout(null);

        jLabelPrioridad.setFont(new java.awt.Font("Tahoma", 0, 24)); // NOI18N
        jLabelPrioridad.setText("Prioridad:");
        getContentPane().add(jLabelPrioridad);
        jLabelPrioridad.setBounds(70, 100, 101, 29);

        jButtonReset.setText("Reset");
        jButtonReset.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButtonResetActionPerformed(evt);
            }
        });
        getContentPane().add(jButtonReset);
        jButtonReset.setBounds(300, 250, 110, 40);

        jButtonGuardar.setText("Guardar");
        jButtonGuardar.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                jButtonGuardarActionPerformed(evt);
            }
        });
        getContentPane().add(jButtonGuardar);
        jButtonGuardar.setBounds(160, 250, 120, 40);

        jTextAreaDescripcion.setColumns(20);
        jTextAreaDescripcion.setRows(5);
        jScrollPane1.setViewportView(jTextAreaDescripcion);

        getContentPane().add(jScrollPane1);
        jScrollPane1.setBounds(230, 20, 166, 96);

        jLabelDescripcion.setFont(new java.awt.Font("Tahoma", 0, 24)); // NOI18N
        jLabelDescripcion.setText("Descripción:");
        getContentPane().add(jLabelDescripcion);
        jLabelDescripcion.setBounds(70, 20, 128, 29);

        jComboBoxPrioriedad.setModel(new javax.swing.DefaultComboBoxModel<>(new String[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" }));
        getContentPane().add(jComboBoxPrioriedad);
        jComboBoxPrioriedad.setBounds(230, 110, 140, 30);

        jLabelNombreCat.setFont(new java.awt.Font("Tahoma", 0, 24)); // NOI18N
        jLabelNombreCat.setText("Nombre:");
        getContentPane().add(jLabelNombreCat);
        jLabelNombreCat.setBounds(70, 150, 110, 40);
        getContentPane().add(jTextFieldNombreCat);
        jTextFieldNombreCat.setBounds(230, 160, 170, 20);

        setSize(new java.awt.Dimension(578, 363));
        setLocationRelativeTo(null);
    }// </editor-fold>//GEN-END:initComponents

    private void jButtonResetActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButtonResetActionPerformed
        reset();
    }//GEN-LAST:event_jButtonResetActionPerformed

    private void jButtonGuardarActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_jButtonGuardarActionPerformed
        if (jTextFieldNombreCat.getText().equalsIgnoreCase("") || jTextAreaDescripcion.getText().equalsIgnoreCase("")) {
            JOptionPane.showMessageDialog(this, "Error, por favor complete todos los campos del formulario", "ERROR", JOptionPane.ERROR_MESSAGE);
        } else {
            //Creo el objeto y compruebo si existe o no ya en la lista de categorias
            //en el caso de que no, se agrega y se resetean los campos necesarios
            Categoria c = new Categoria(jTextAreaDescripcion.getText(), Integer.parseInt(jComboBoxPrioriedad.getSelectedItem().toString()), jTextFieldNombreCat.getText());
            if (modelo.existeCategoria(c)) {
                JOptionPane.showMessageDialog(this, "Error, se ha ingresado una Categoria con una descripcion ya existente", "ERROR", JOptionPane.ERROR_MESSAGE);

            } else {
                modelo.setCategoriaList(c);
                JOptionPane.showMessageDialog(this, "Categoria registrada correctamente", "Categoria registrada", JOptionPane.INFORMATION_MESSAGE);
                this.reset();
            }
        }
    }//GEN-LAST:event_jButtonGuardarActionPerformed
    private void reset() {
        jTextAreaDescripcion.setText("");
        jComboBoxPrioriedad.setSelectedIndex(0);
        jTextFieldNombreCat.setText("");
    }

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JButton jButtonGuardar;
    private javax.swing.JButton jButtonReset;
    private javax.swing.JComboBox<String> jComboBoxPrioriedad;
    private javax.swing.JLabel jLabelDescripcion;
    private javax.swing.JLabel jLabelNombreCat;
    private javax.swing.JLabel jLabelPrioridad;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JTextArea jTextAreaDescripcion;
    private javax.swing.JTextField jTextFieldNombreCat;
    // End of variables declaration//GEN-END:variables
}
