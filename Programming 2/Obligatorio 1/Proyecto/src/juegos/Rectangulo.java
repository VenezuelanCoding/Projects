// Joaquin Bonifacino - 243193 - Rafael Cadenas - 269150
package juegos;

import proyecto.*;
import java.util.Arrays;

public class Rectangulo extends Juego {

    private String[][] mat;
    //del 1 al 10 cada numero corresponde a un codigo de color diferente
    private int cantRectangulosInsertados = 0;
    private int ordenColor = 1;
    private int[] jugadaAnterior;

    public int[] getJugadaAnterior() {
        return jugadaAnterior;
    }

    public void setJugadaAnterior(int[] jugadaAnterior) {
        this.jugadaAnterior = jugadaAnterior;
    }

    public int getOrdenColor() {
        return ordenColor;
    }

    public void setOrdenColor(int UnordenColor) {
        this.ordenColor = UnordenColor;
    }

    public int getCantRectangulosInsertados() {
        return cantRectangulosInsertados;
    }

    public void setCantRectangulosInsertados(int cantRectangulosInsertados) {
        this.cantRectangulosInsertados = cantRectangulosInsertados;
    }

    @Override
    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    @Override
    public String getNombre() {
        return nombre;
    }

    //Contructor que recibe si es aletoria o predeterminada la carga de topes
    public Rectangulo(boolean tipo) {
        this.jugadaAnterior = new int[4];
        this.setNombre("Rectangulo");
        this.crearMatriz();
        this.cargarTopes(tipo);
        System.out.println(this);
    }

    //Parte del manejo del random sacado de:
    //https://developer.mozilla.org/es/docs/Web/JavaScript/Reference/Global_Objects/Math/random
    public int getRandomInt(int min, int max) {
        return (int) (Math.floor(Math.random() * (max - min)) + min);
    }

    public String[][] getMat() {
        return mat;
    }

    //Devuelve el valor de la posicion i j
    public String getValorMat(int i, int j) {
        return this.mat[i][j];
    }

    //Modifica el valor en la posicion i j
    public void setValorMat(String caracter, int i, int j) {
        this.mat[i][j] = caracter;
    }

    //Genera la matriz/tablero
    public void crearMatriz() {
        mat = new String[22][22];
        //Se recorre la matriz y se carga con -
        for (int i = 0; i < this.getMat().length - 1; i++) {
            for (int j = 0; j < this.getMat()[0].length - 1; j++) {
                if (j > 0) {
                    this.setValorMat("-", i, j);
                } else {
                    this.setValorMat(" ", i, j);
                }
            }

        }
    }

    //Carga los topes segun el tipo
    public void cargarTopes(boolean tipo) {
        //Chequea el tipo, si es true, es predeterminado
        if (tipo) {
            //Carga manual
            this.setValorMat("*", 1, 3);
            this.setValorMat("*", 3, 3);
            this.setValorMat("*", 4, 5);
            this.setValorMat("*", 6, 16);
            this.setValorMat("*", 9, 10);
            this.setValorMat("*", 9, 11);
            this.setValorMat("*", 12, 10);
            this.setValorMat("*", 12, 20);
            this.setValorMat("*", 13, 18);
            this.setValorMat("*", 14, 17);
            this.setValorMat("*", 15, 6);
            this.setValorMat("*", 15, 11);
            this.setValorMat("*", 15, 20);
            this.setValorMat("*", 16, 17);
            this.setValorMat("*", 17, 5);
            this.setValorMat("*", 18, 4);
            this.setValorMat("*", 18, 11);
            this.setValorMat("*", 19, 3);
            this.setValorMat("*", 19, 14);
            this.setValorMat("*", 20, 15);
        } else {

            int cantTopes = 0;
            //Itera hasta que se hayan cargado 20 topes
            while (cantTopes < 20) {
                //Se recorre la matriz
                for (int i = 1; i < this.getMat().length - 1 && cantTopes < 20; i++) {
                    for (int j = 1; j < this.getMat()[0].length - 1 && cantTopes < 20; j++) {
                        /*Chequea la tasa de probabilidad de que haya un tope (10% de que si)
                        y si ese lugar no tiene un tope, si cumple aumenta el contador de topes en 1*/
                        if (this.getRandomInt(1, 20) > 18 && this.getValorMat(i, j).equals("-")) {
                            this.setValorMat("*", i, j);
                            cantTopes++;
                        }

                    }
                }
            }
        }

    }

    public boolean esAdyacente(int[] coords) {
        boolean esAdyacente = false;
        if (!(coords == null)) {
            if (coords[0] + coords[2] == this.getJugadaAnterior()[0] && coords[1] + coords[3] >= this.getJugadaAnterior()[1] && coords[1] <= this.getJugadaAnterior()[1] + this.getJugadaAnterior()[3]) {
                esAdyacente = true;
            }

            if (coords[0] - 1 == this.getJugadaAnterior()[0] + this.getJugadaAnterior()[2] - 1 && coords[1] + coords[3] >= this.getJugadaAnterior()[1] && coords[1] <= this.getJugadaAnterior()[1] + this.getJugadaAnterior()[3]) {
                esAdyacente = true;
            }

            if (coords[1] - 1 == this.getJugadaAnterior()[1] + this.getJugadaAnterior()[3] - 1 && coords[0] + coords[2] >= this.getJugadaAnterior()[0] && coords[0] <= this.getJugadaAnterior()[0] + this.getJugadaAnterior()[2]) {
                esAdyacente = true;
            }
            if (coords[1] + coords[3] == this.getJugadaAnterior()[1] && coords[0] + coords[2] >= this.getJugadaAnterior()[0] && coords[0] <= this.getJugadaAnterior()[0] + this.getJugadaAnterior()[2]) {
                esAdyacente = true;
            }

            //Chequea si es el caso de que sea el primer rectangulo
            if (this.getCantRectangulosInsertados() < 1) {
                esAdyacente = true;
            }

        }
        return esAdyacente;
    }

    //Calcula el puntaje
    @Override
    public int puntaje() {
        int puntaje = 0;
        //Se recorre la matriz
        for (int i = 0; i < this.getMat().length - 1; i++) {
            for (int j = 0; j < this.getMat()[0].length - 1; j++) {
                //Chequea si encontro un # y suma 1 a puntaje
                if (this.getValorMat(i, j).contains("#")) {
                    puntaje++;
                }
            }
        }

        return puntaje;
    }

    //Realiza el  algoritmo para jugar
    @Override
    public void jugada(String rectangulo
    ) {
        //Se utiliza split para separar el ingreso en un array
        String[] partes = rectangulo.split(" ");
        //Validar errores de nulidad, de formato de numero y del indice de la matriz
        try {
            int[] coords = new int[4];
            //Se parsea los valores del array de String y se agregan a un array de int
            for (int i = 0; i < 4; i++) {
                coords[i] = Integer.parseInt(partes[i]);
            }
            //Valida si no hay topes o otro rectangulo dentro del rectangulo
            if (this.noTopesNiHashtag(coords)) {
                //Valida si es adyacente a otro rectangulo o si es el primer rectangulo
                if (this.esAdyacente(coords)) {
                    //Inserta el rectangulo a la matriz
                    this.crearRectangulo(coords);
                    //Se muestra la matriz con la insercion
                    System.out.println(this);
                } else {
                    System.out.println(this);
                    System.out.println("Su jugada no es adyacente al ultimo rectangulo ingresado");
                }
            } else {
                System.out.println(this);
                System.out.println("Su jugada pisa un tope o un #");
            }
        } catch (java.lang.ArrayIndexOutOfBoundsException | java.lang.NullPointerException e) {
            System.out.println(this);
            System.out.println("Por favor ingrese un rectangulo que pueda existir en el tablero");
        } catch (java.lang.NumberFormatException e) {
            System.out.println(this);
            System.out.println("Por favor ingrese un numero");
        }

    }
    //Chequea si no hay topes ni hashtags

    public boolean noTopesNiHashtag(int[] coords) {
        boolean encontreTopes = false;
        int alto = coords[0] + coords[2];
        int ancho = coords[1] + coords[3];
        //Se recorre la matriz 
        for (int i = coords[0]; i < alto; i++) {
            for (int j = coords[1]; j < ancho; j++) {
                //Valida si en la posicion se encuentra un top o un hashtag
                if (this.getValorMat(i, j).equals("*") || this.getValorMat(i, j).contains("#")) {
                    encontreTopes = true;
                }
            }
        }

        return !encontreTopes;
    }

    //Crea e inserta el rectangulo a la matriz
    public void crearRectangulo(int[] coords) {
        int alto = coords[0] + coords[2];
        int ancho = coords[1] + coords[3];
        String caracter = null;
        /* Chequea la cantida de rectangulos para usar el codigo de color correspondiente a orden color,
        el cual es un numero que modifica el codigo de color para que este sea unico
         */
        if (this.getCantRectangulosInsertados() < 8) {
            caracter = "\u001B[3" + this.getOrdenColor() + "m#\u001B[0m";
            this.setOrdenColor(this.getOrdenColor() + 1);

        }
        //Reinicia el orden en 0 para continuar con los otros codigos de color
        if (this.getCantRectangulosInsertados() == 7) {
            this.setOrdenColor(0);
        }
        /* Chequea la cantida de rectangulos para usar el codigo de color correspondiente a orden color,
        el cual es un numero que modifica el codigo de color para que este sea unico
         */
        if (this.getCantRectangulosInsertados() >= 7) {
            caracter = "\u001b[3" + this.getOrdenColor() + ";1m" + "#\u001b[0m";
            this.setOrdenColor(this.getOrdenColor() + 1);
        }
        //Insercecion del rectangulo
        for (int i = coords[0]; i < alto; i++) {
            for (int j = coords[1]; j < ancho; j++) {
                this.setValorMat(caracter, i, j);
            }
        }
        //Aumenta la cantidad de rectangulos ingresados en 1
        this.setCantRectangulosInsertados(this.getCantRectangulosInsertados() + 1);

        //Guardo la jugada
        this.setJugadaAnterior(coords);

    }

    //Chequea si el juego finalizo
    @Override
    public boolean finalizacion() {
        boolean terminar = false;
        //Chequea si se ingresaron 10 rectangulos, si es asi, se termina la partida
        if (this.getCantRectangulosInsertados() == 10) {
            terminar = true;
        }
        if (this.getCantRectangulosInsertados() > 1 && !terminar) {
            //Se almacenan las coordenadas 1
            int filaInicio = this.getJugadaAnterior()[0];
            int columnaInicio = this.getJugadaAnterior()[1];
            int filaFinal = this.getJugadaAnterior()[0] + this.getJugadaAnterior()[2];
            int columnaFinal = this.getJugadaAnterior()[1] + this.getJugadaAnterior()[3];
            //Contador de espacios adyacentes a la ultima jugada disponibles
            int cont = 0;
            //Se chequea si es adyacente por la izquierda
            for (int i = filaInicio; i < filaFinal && columnaInicio != 1; i++) {
                if (this.getValorMat(i, columnaInicio - 1).contains("-")) {
                    cont++;
                }
            }
            //Se chequea si es adyacente por arriba
            for (int i = columnaInicio; i < columnaFinal && filaInicio != 1; i++) {
                if (this.getValorMat(filaInicio - 1, i).contains("-")) {
                    cont++;
                }
            }
            //Se chequea si es adyacente por la derecha
            for (int i = filaInicio; i < filaFinal && columnaFinal <= 20; i++) {
                if (this.getValorMat(i, columnaFinal).contains("-")) {
                    cont++;
                }
            }
            //Se chequea si es adyacente por abajo
            for (int i = columnaInicio; i < columnaFinal && !terminar && filaFinal <= 20; i++) {
                if (this.getValorMat(filaFinal, i).contains("-")) {
                    cont++;
                }
            }
            if(cont == 0){
                terminar = true;
            }
        }
           

        return terminar;
    }

    //Muestra la matriz
    @Override
    public String toString() {
        String muestreo = "";
        muestreo += "     1 2 3 4 5 6 7 8 9 1 1 1 1 1 1 1 1 1 1 2";
        muestreo += "\n                       0 1 2 3 4 5 6 7 8 9 0";
        for (int i = 1; i < mat.length - 1; i++) {
            muestreo += "\n";
            if (i < 10) {
                muestreo += "0" + i;
            } else {
                muestreo += i;
            }

            for (int j = 0; j < mat[0].length - 1; j++) {

                muestreo += " " + this.getValorMat(i, j);
            }

        }

        return muestreo;
    }

}
