// Joaquin Bonifacino - 243193 - Rafael Cadenas - 269150
package proyecto;

import java.util.Comparator;
//Criterio de ordenacion por puntaje decreciente
public class CriterioPuntaje implements Comparator<Partida> {

    public int compare(Partida p1, Partida p2) {

        return p2.getPuntaje() - p1.getPuntaje();
    }

}
