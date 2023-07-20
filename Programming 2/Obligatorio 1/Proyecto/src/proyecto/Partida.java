// Joaquin Bonifacino - 243193 - Rafael Cadenas - 269150
package proyecto;

import java.util.Formatter;

class Partida {

    private Juego juego;
    private Jugador jugador;
    private Formatter horaComienzo;
    private int puntaje;
    private static int proximoNumero = 0;
    private int numero = 0;

    public Partida(Juego juego, Jugador jugador, Formatter horaComienzo, int puntaje) {
        this.juego = juego;
        this.jugador = jugador;
        this.horaComienzo = horaComienzo;
        this.puntaje = puntaje;
        Partida.setProximoNumero(Partida.getProximoNumero() + 1);
        this.setNumero(Partida.getProximoNumero());

    }

    public int getNumero() {
        return numero;
    }

    public void setNumero(int numero) {
        this.numero = numero;
    }

    public Juego getJuego() {
        return juego;
    }

    public void setJuego(Juego juego) {
        this.juego = juego;
    }

    public Jugador getJugador() {
        return jugador;
    }

    public void setJugador(Jugador jugador) {
        this.jugador = jugador;
    }

    public Formatter getHoraComienzo() {
        return horaComienzo;
    }

    public void setHoraComienzo(Formatter horaComienzo) {
        this.horaComienzo = horaComienzo;
    }

    public int getPuntaje() {
        return puntaje;
    }

    public void setPuntaje(int puntaje) {
        this.puntaje = puntaje;
    }

    public static int getProximoNumero() {
        return proximoNumero;
    }

    public static void setProximoNumero(int unProximoNumero) {
        proximoNumero = unProximoNumero;
    }

    @Override
    public String toString() {
        return this.getNumero() + ")" + "Juego:" + this.getJuego().getNombre() + "\nJugador:" + this.getJugador() + "\nHoraComienzo=" + this.getHoraComienzo() + "\nPuntaje=" + this.getPuntaje() + "\n";
    }

}
