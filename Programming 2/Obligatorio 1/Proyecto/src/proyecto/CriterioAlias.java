// Joaquin Bonifacino - 243193 - Rafael Cadenas - 269150
package proyecto;

import java.util.Comparator;
//Criterio de ordenacion alfabetica por alias
public class CriterioAlias implements Comparator<Partida> {

    public int compare(Partida p1, Partida p2) {
        return p1.getJugador().getAlias().compareTo(p2.getJugador().getAlias());

    }

}
