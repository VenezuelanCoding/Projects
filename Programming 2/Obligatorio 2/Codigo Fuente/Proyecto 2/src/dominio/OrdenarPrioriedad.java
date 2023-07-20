// Joaquin Bonifacino - 243193 - Rafael Cadenas - 269150

package dominio;


import java.util.Comparator;
//Criterio de ordenacion por puntaje decreciente
public class OrdenarPrioriedad implements Comparator<Categoria> {

    @Override
    public int compare(Categoria p1, Categoria p2) {

        return p2.getPrioridad() - p1.getPrioridad();
    }

}