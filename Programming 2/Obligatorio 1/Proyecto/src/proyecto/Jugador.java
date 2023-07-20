// Joaquin Bonifacino - 243193 - Rafael Cadenas - 269150
 
package proyecto;


public class Jugador {

    private String nombre;
    private int edad;
    private String alias;

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public int getEdad() {
        return edad;
    }

    public void setEdad(int edad) {
        this.edad = edad;
    }

    public String getAlias() {
        return alias;
    }

    public void setAlias(String alias) {
        this.alias = alias;
    }
    //Contructor de jugador
    public Jugador(String nombre, int edad, String alias) {
        this.nombre = nombre;
        this.edad = edad;
        this.alias = alias;
    }
    
    @Override
    public String toString() {
        return "Nombre: " + nombre + " Edad=" + edad + " Alias=" + alias;
    }

}
