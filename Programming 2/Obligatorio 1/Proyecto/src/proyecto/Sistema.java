// Joaquin Bonifacino - 243193 - Rafael Cadenas - 269150
package proyecto;

import java.util.Iterator;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Formatter;

public class Sistema {

    private ArrayList<Jugador> listaJugadores;
    private ArrayList<Partida> bitacora;
    //Contructor de sistema
    public Sistema() {
        listaJugadores = new ArrayList<>();
        bitacora = new ArrayList<>();

    }
    //Metodo que crea la partida a traves del contructor de la misma
    public Partida crearPartida(Juego j, int lugarJugador) {
        Formatter horario = new Formatter();
        Calendar cal = Calendar.getInstance();
        horario.format("%tH:%tM", cal, cal);
        Partida p;
        p = new Partida(j, this.getJugadorLista(lugarJugador), horario, 0);
        return p;
    }

    public void setPartidaEnBitacora(Partida unaPartida) {
        this.bitacora.add(unaPartida);
    }

    public ArrayList<Jugador> getListaJugadores() {
        return listaJugadores;
    }

    public ArrayList<Partida> getBitacora() {
        return bitacora;
    }

    //Traer jugadore de la lista de jugadores
    public Jugador getJugadorLista(int lugar) {
        return listaJugadores.get(lugar);
    }
    //Setear jugador a la lista de jugadores
    public void setJugadorLista(Jugador J) {
        listaJugadores.add(J);
    }

    public boolean aliasRepetido(String alias) {
        Iterator<Jugador> iter = listaJugadores.iterator();
        boolean repetido = false;

        while (iter.hasNext()) {
            Jugador j = iter.next();
            if (j.getAlias().equals(alias)) {
                repetido = true;
            }

        }

        return repetido;
    }

    //Chequear si hay algun jugador registrado
    public boolean hayJugadorRegistrado() {
        boolean existe = false;

        if (this.getListaJugadores().size() > 0) {
            existe = true;
        }

        return existe;
    }

    //Para chequear si el input ingresado es numerico
    public boolean esNumero(String palabra) {
        boolean esNumerico = true;
        try {
            double d = Double.parseDouble(palabra);
        } catch (NumberFormatException nfe) {
            esNumerico = false;
        }
        return esNumerico;
    }

}
