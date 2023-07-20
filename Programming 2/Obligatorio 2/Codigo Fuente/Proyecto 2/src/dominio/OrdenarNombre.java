// Joaquin Bonifacino - 243193 - Rafael Cadenas - 269150

package dominio;

import java.util.Comparator;
//Criterio de ordenacion alfabetica por alias

public class OrdenarNombre implements Comparator<Categoria> {

    @Override
    public int compare(Categoria p1, Categoria p2) {
        return p1.getNombre().compareTo(p2.getNombre());

    }

}
