// Joaquin Bonifacino - 243193 - Rafael Cadenas - 269150
package juegos;

import java.util.ArrayList;
import java.util.Collections;
import proyecto.Juego;

public class Saltar extends Juego {

    private String[][] mat;
    private String ordenColor = "R";
    //(R=Rojo, A= Azul, V= Verde, M= Amarillo)

    public String getNombre() {
        return nombre;
    }

    public String[][] getMat() {
        return mat;
    }

    public void setMat(String[][] mat) {
        this.mat = mat;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public Saltar(boolean tipo) {
        this.setNombre("Saltar");
        this.crearMatriz();
        this.cargarFichas(tipo);
        System.out.println(this);

    }

    public String getOrdenColor() {
        return ordenColor;
    }

    //Metodo que pasa al siguiente color en la lista
    public void nextOrdenColor() {
        String nuevo = "";
        if (this.getOrdenColor().equals("R")) {
            nuevo = "A";
        } else {
            if (this.getOrdenColor().equals("A")) {
                nuevo = "V";
            } else {
                if (this.getOrdenColor().equals("V")) {
                    nuevo = "M";
                } else {
                    if (this.getOrdenColor().equals("M")) {
                        nuevo = "R";
                    }
                }
            }
        }
        this.ordenColor = nuevo;
    }

    //Recibe las 2 posiciones del lugar y devuelve el contenido de la matriz en ese lugar
    public String getValorMat(int fila, int columna) {

        String lugar;

        lugar = mat[fila][columna];

        return lugar;
    }

    //Recibe el valor a insertar, la columna y la fila, y inserta el valor en esa coordenada
    public void setValorMat(String valor, int fila, int columna) {
        mat[fila][columna] = valor;

    }

    @Override
    public String toString() {
        String muestreo = "";

        for (int i = 0; i < mat.length; i++) {
            muestreo += "\n";
            if (i == 1) {
                muestreo += "60";
            } else {
                if (i == 3) {
                    muestreo += "40";
                } else {
                    if (i == 5) {
                        muestreo += "30";
                    } else {
                        if (i == 7) {
                            muestreo += "20";
                        } else {
                            if (i == 9) {
                                muestreo += "10";
                            } else {
                                muestreo += "  ";
                            }
                        }
                    }
                }
            }

            for (int j = 0; j < mat[0].length; j++) {
                if (j == 0) {
                    muestreo += "  ";
                }
                muestreo += "" + this.getValorMat(i, j);
            }
        }
        muestreo += "\n";
        muestreo += "     1 2 3 4";

        return muestreo;
    }
//Crea la matriz con el formato requerido

    public void crearMatriz() {

        mat = new String[23][9];
        for (int i = 0; i < mat.length; i++) {
            for (int j = 0; j < mat[0].length; j++) {
                if (i % 2 == 0) {
                    if (j % 2 == 0) {
                        this.setValorMat("+", i, j);

                    } else {
                        this.setValorMat("-", i, j);

                    }

                } else {
                    if (j % 2 == 0) {
                        this.setValorMat("|", i, j);

                    } else {
                        this.setValorMat(" ", i, j);

                    }
                }

            }
        }

    }

    //Carga las fichas recibiendo por parametro si deben de ser cargadas
    //de forma random o predeterminada
    public void cargarFichas(boolean tipo) {
        //Sacado del estandar de codigo ANSI
        String astRojo = "\u001B[31m#\u001B[0m";
        String astVerde = "\u001b[32m#\u001B[0m";
        String astAzul = "\u001b[34m#\u001B[0m";
        String astAmarillo = "\u001B[33m#\u001B[0m";
        if (tipo) {

            this.setValorMat(astRojo, 15, 1);
            this.setValorMat(astAzul, 15, 3);
            this.setValorMat(astVerde, 15, 5);
            this.setValorMat(astAmarillo, 15, 7);

            this.setValorMat(astAzul, 17, 1);
            this.setValorMat(astRojo, 17, 3);
            this.setValorMat(astAmarillo, 17, 5);
            this.setValorMat(astVerde, 17, 7);

            this.setValorMat(astVerde, 19, 1);
            this.setValorMat(astAmarillo, 19, 3);
            this.setValorMat(astAzul, 19, 5);
            this.setValorMat(astRojo, 19, 7);

            this.setValorMat(astAmarillo, 21, 1);
            this.setValorMat(astVerde, 21, 3);
            this.setValorMat(astRojo, 21, 5);
            this.setValorMat(astAzul, 21, 7);

        } else {

            /*Creo un arraylist, luego le pido un shuffle de la clase collections
            Y chequeamos si existe un # del mismo color en la misma columna, 
            si existe lo pasamos por shuffle hasta que devuelva falso.
            Cuando devuelve falso se inserta en la matriz.
             */
            ArrayList<String> lista = new ArrayList<>();

            lista.add(astRojo);
            lista.add(astAzul);
            lista.add(astVerde);
            lista.add(astAmarillo);

            boolean existe = true;

            for (int i = 15; i <= 21; i += 2) {
                while (existe) {
                    Collections.shuffle(lista);

                    existe = existeFilaIgual(lista);
                }
                existe = true;
                int k = 0;

                for (int j = 1; j < 9; j += 2) {

                    this.setValorMat(lista.get(k), i, j);
                    k++;
                }

            }

        }

    }

    /*Chequea si existe un # del mismo color en la misma columna,
        retorna falso si no hay ningun # de ese color
     */
    public boolean existeFilaIgual(ArrayList<String> lista) {

        boolean existe = false;
        int i = 1;
        for (int k = 0; k < 4 && !existe; k++) {

            for (int j = 15; j < 23 && !existe; j += 2) {

                if (this.getValorMat(j, i).equals(lista.get(k))) {
                    existe = true;
                }

            }
            i += 2;

        }
        return existe;
    }

    //Modulo para la jugada
    @Override
    public void jugada(String columnaS) {
        //La "columnaS" es la posicion a la que se debe mover
        //viene del metodo "calculoAvance"

        int columna = Integer.valueOf(columnaS);
        columna = columna + (columna - 1);
        int fila = this.filaFicha(columna, this.convColor());
        //En el caso de que se pueda mover el seleccionado pedimos la coordenada nueva, sino avanza
        //al siguiente color

        boolean jugadaValida = true;

        //Validacion de la coordenada actual
        if (!this.colorAdelantadoYSolo(columna)) {

            int[] coordenadaNueva = this.calculoAvance(columna);

            //Validacion de la coordenada de llegada
            if (coordenadaNueva[0] > 0 && !ocupacion(coordenadaNueva) && !colorLinea(coordenadaNueva[0])) {
                //Una vez pasadas todas las validaciones insertamos el simbolo # en la coordenada nueva
                this.setValorMat(this.convColor(), coordenadaNueva[0], coordenadaNueva[1]);
                this.setValorMat(" ", fila, columna);

                //Pasamos al siguiente color
                this.nextOrdenColor();

            } else {
                jugadaValida = false;
            }

            //En el caso de que no encuentre ninguna jugada para los 4 colores sale del juego.
            int cantidadDeReinicios = 0;
            System.out.println(this);

            do {
                if (!this.jugadaPosibleUnColor()) {
                    System.out.println("Se saltea el color " + this.getOrdenColor() + " por que no hay combinacion posible");
                    this.nextOrdenColor();

                }

                cantidadDeReinicios++;

            } while (cantidadDeReinicios < 4 && !this.jugadaPosibleUnColor());
            
            
            if(cantidadDeReinicios==4){
                System.out.println("La partida ha terminado por que no hay mas jugadas posibles");
            }

        } else {
            jugadaValida = false;
        }

        if (!jugadaValida) {
            System.out.println(this);
            System.out.println("Jugada no valida, por favor re intente");
        }

    }

    public boolean ocupacion(int[] coordenada) {
        //Recibe una coordenada y chequea si esta vacia
        //VALIDACION DE LLEGADA
        boolean ocupado = true;
        if (this.getValorMat(coordenada[0], coordenada[1]).equals(" ")) {
            ocupado = false;
        }
        return ocupado;
    }

    public String convColor() {
        //Convertimos la variable de clase color a su codigo de color respectivo
        String color = "";
        if (this.getOrdenColor().equals("R")) {
            color = "\u001B[31m#\u001B[0m";
        } else {
            if (this.getOrdenColor().equals("A")) {
                color = "\u001b[34m#\u001B[0m";
            } else {
                if (this.getOrdenColor().equals("V")) {
                    color = "\u001b[32m#\u001B[0m";
                } else {
                    if (this.getOrdenColor().equals("M")) {
                        color = "\u001B[33m#\u001B[0m";
                    }
                }
            }
        }
        return color;
    }

    //si hay otro color igual en la fila y es en la zona base devuelve (si=1,no=0)
    public boolean colorLinea(int fila) {

        boolean invalido = false;
        String color;
        color = this.convColor();
        for (int j = 1; j < mat[0].length; j += 2) {
            if (this.getValorMat(fila, j).equals(color)) {
                invalido = true;
            }

        }
        if (fila <= 9) {
            invalido = false;
        }

        return invalido;
    }

    /*Este metodo existe por que cuando el usuario
        ingresa una columna yo debo de manejar la coordenada nueva para las validaciones
        por lo tanto este metodo cuenta cuantos lugares se debera mover 
        y devuelve la coordenada nueva para que todos los demas metodos
        chequeen sobre esa nueva coordenada
     */
    public int[] calculoAvance(int columna) {
        int fila = 0;

        String comparador = this.convColor();

        fila = this.filaFicha(columna, comparador);

        int cantidadAAvanzar = this.contFila(fila);

        //Calculo nueva fila
        fila = fila - (cantidadAAvanzar * 2);
        int[] coordenada = new int[2];
        coordenada[0] = fila;
        coordenada[1] = columna;

        return coordenada;
    }

    //Devuelve la fila en la que se encontro la ficha a mover
    public int filaFicha(int columna, String comparador) {

        int fila = 0;
        boolean encontro = false;
        for (int i = 1; i < 23 && encontro == false; i += 2) {

            if (this.getValorMat(i, columna).contains(comparador)) {
                fila = i;
                encontro = true;

            }

        }
        return fila;
    }

    //Calcula la cantidad de lugares se debe mover una ficha
    public int contFila(int fila) {
        //Meto toda la fila en un string y cuento la cantidad de # que hay para saber cuantos lugares debere moverlo
        String filaComp = "";

        for (int i = 0; i < 9; i++) {
            filaComp += this.getValorMat(fila, i);
        }
        int cantidadAAvanzar = 0;
        for (int i = 0; i < filaComp.length(); i++) {

            if (filaComp.charAt(i) == '#') {
                cantidadAAvanzar++;
            }

        }
        return cantidadAAvanzar;
    }

    //Chequea si la ficha de ese color es la mas adelantada
    public boolean colorAdelantadoYSolo(int columna) {

        boolean esAdelantado = false;
        int fila = this.filaFicha(columna, this.convColor());

        int simbolosEnFila = this.contFila(fila);
        int columna2 = 0;
        int fila2 = 0;
        for (int i = 1; i < this.getMat().length && fila2 == 0; i += 2) {
            for (int j = 1; j < this.getMat()[0].length && fila2 == 0; j += 2) {

                if (this.convColor().equals(this.getValorMat(i, j))) {
                    fila2 = i;
                    columna2 = j;
                }

            }
        }

        if (simbolosEnFila == 1 && fila == fila2 && columna == columna2) {
            esAdelantado = true;
        }

        return esAdelantado;
    }

    //Chequea si la partida termino en cada turno(si=1,no=0)
    public boolean jugadaPosibleUnColor() {

        //Simula jugar para cada una de las columnas, en el caso de que
        //no encuentre una jugada posible con el color actual devuelve falso
        boolean siguiente = false;
        for (int j = 1; j < 8 && !siguiente; j += 2) {

            if (!this.colorAdelantadoYSolo(j)) {

                int[] coordenadaNueva = this.calculoAvance(j);

                siguiente = coordenadaNueva[0] > 0 && !ocupacion(coordenadaNueva) && !colorLinea(coordenadaNueva[0]);

            }
        }

        return siguiente;

    }

    //Chequea si la partida termino en cada turno chequeando si algun color
    //tiene alguna jugada posible para las 4 columnas
    @Override
    public boolean finalizacion() {

        boolean HayMasColor = false;
        int cantRep = 0;
        do {
            if (!this.jugadaPosibleUnColor()) {
                this.nextOrdenColor();
                cantRep++;
            } else {
                HayMasColor = true;
            }

        } while (!HayMasColor && cantRep < 4);

        int cantidad = 0;
        for (int i = 11; i < 23; i += 2) {
            cantidad += this.contFila(i);

        }

        if (HayMasColor && cantidad <= 2) {
            HayMasColor = false;
        }
        return !HayMasColor;
    }

    //Cuenta la cantidad de # que hay en la zona de puntaje haciendo los
    //calculos necesarios para devolver el puntaje de la partida
    @Override
    public int puntaje() {

        return (this.contFila(1) * 60) + (this.contFila(3) * 40) + (this.contFila(5) * 30 + (this.contFila(7) * 20 + this.contFila(9) * 10));
    }

    //Intenta jugar cada columna con el color actual, cuando encuentra una jugada posible
    //devuelve la columna en la cual esa juagda es posible
    public int ayuda() {
        int columna = 0;

        boolean siguiente = false;
        for (int j = 1; j < 8 && !siguiente; j += 2) {

            if (!this.colorAdelantadoYSolo(j)) {

                int[] coordenadaNueva = this.calculoAvance(j);

                siguiente = coordenadaNueva[0] > 0 && !ocupacion(coordenadaNueva) && !colorLinea(coordenadaNueva[0]);

            }

            if (siguiente) {
                columna = j;
            }
        }

        if (columna == 3) {
            columna = 2;
        }
        if (columna == 5) {
            columna = 3;
        }
        if (columna == 7) {
            columna = 4;
        }

        return columna;
    }

}
