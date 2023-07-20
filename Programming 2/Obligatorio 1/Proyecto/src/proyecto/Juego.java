// Joaquin Bonifacino - 243193 - Rafael Cadenas - 269150
package proyecto;

public abstract class Juego {

    protected String nombre;
    
    public abstract String getNombre();

    public abstract void setNombre(String nombre);
    //Genera requerimiento del metodo "finalizacion" a las clases hijas
    public abstract boolean finalizacion();
    //Genera requerimiento del metodo "jugada" a las clases hijas
    public abstract void jugada(String mov);
    //Genera requerimiento del metodo "puntaje" a las clases hijas
    public abstract int puntaje();

}
