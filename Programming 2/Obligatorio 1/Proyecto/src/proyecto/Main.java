// Joaquin Bonifacino - 243193 - Rafael Cadenas - 269150
package proyecto;

import java.util.ArrayList;
import java.util.Collections;
import juegos.*;
import java.util.Iterator;
import java.util.Scanner;

public class Main {

    public static Scanner input = new Scanner(System.in);

    public static void main(String[] args) {
        int opcion;
        Sistema sistema = new Sistema();
        do {

            System.out.println("        MENU");
            System.out.println("---------------------");
            System.out.println("1) Registrar jugador");
            System.out.println("2) Jugar a Saltar");
            System.out.println("3) Jugar a Rectangulo");
            System.out.println("4) Bitacora");
            System.out.println("5) Salir");
            opcion = ingresoINT("Ingrese una opcion");
            //Chequeamos la opcion del usuario
            switch (opcion) {
                case 1:
                    creacionJugador(sistema);
                    break;
                case 2:
                    if (sistema.hayJugadorRegistrado()) {

                        //Pedido y carga si quiere cargar las fichas de forma random o predeterminada
                        boolean tipo = seleccionarTipo();

                        //Pedido de seleccion de jugador a jugar
                        int lugarJugador = seleccionarJugador(sistema);

                        //Creo el objeto pasandole el tipo de carga
                        Juego s = new Saltar(tipo);

                        //Creacion del objeto partida
                        Partida p = sistema.crearPartida(s, lugarJugador);

                        int puntaje = jugarSaltar((Saltar) s, sistema);

                        p.setPuntaje(puntaje);

                        sistema.setPartidaEnBitacora(p);

                    } else {
                        System.out.println("\n Por favor registre un jugador antes de jugar");
                    }

                    break;
                case 3:
                    if (sistema.hayJugadorRegistrado()) {
                        //Pedido y carga si quiere cargar las fichas de forma random o predeterminada
                        boolean tipo = seleccionarTipo();

                        //Pedido de seleccion de jugador a jugar
                        int lugarJugador = seleccionarJugador(sistema);

                        Juego r = new Rectangulo(tipo);

                        //Creacion del objeto partida
                        Partida p = sistema.crearPartida(r, lugarJugador);

                        int puntaje = jugarRectangulo((Rectangulo) r, sistema);
                        p.setPuntaje(puntaje);
                        //Agregar partida a la bitacora
                        sistema.setPartidaEnBitacora(p);
                    } else {
                        System.out.println("\n Por favor registre un jugador antes de jugar");
                    }
                    break;
                case 4:

                    ordenar(sistema);
                    mostrarBitacora(sistema);

                    break;
                case 5:

                    break;
                default:
                    System.err.println("Por favor ingrese una opcion valida");

            }
        } while (opcion != 5);

    }

    //Chequea el si el jugador desea cargar fichas de manera aleatoria o predeterminada
    public static boolean seleccionarTipo() {
        //Booleano que se usa para validar la opcion
        boolean opcionCargaCorrecta = false;
        //Int para almacenar opcion 1 o 2
        int random;
        do {
            System.out.println("1) Cargar fichas de manera aleatoria");
            System.out.println("2) Cargar fichas de manera predeterminada");
            random = ingresoINT("Ingrese su opcion: ");
            if (random == 1 || random == 2) {
                opcionCargaCorrecta = true;
            } else {
                System.out.println("Por favor ingrese una opcion valida");
            }
        } while (!opcionCargaCorrecta);
        //Booleano para chequear random para definir si es false o true
        boolean carga;
        carga = random != 1;
        return carga;
    }

    //Chequea que el ingreso de un int sea valido
    public static int ingresoINT(String texto) {
        //Texto es el mensaje de pedido de datos 
        int numero = 0;
        boolean correcto = false;
        do {
            try {
                System.out.println(texto);
                numero = input.nextInt();
                //Se chequea que no sea negativo ni pase de 100
                if (numero >= 0 && numero < 100) {
                    correcto = true;
                } else {
                    System.out.println("Error, no se ingreso un numero valido");
                    input.nextLine();// limpiar el buffer del teclado
                    System.out.print("");// renglon en blanco
                }
                //Se enviara un mensaje de error en caso de que el ingreso no sea un numero
            } catch (java.util.InputMismatchException e) {
                System.out.println("Error, no se ingreso un numero");
                input.nextLine();// limpiar el buffer del teclado

            } // fin del catch

        } while (!correcto);
        input.nextLine();// limpiar el buffer del teclado
        return numero;
    }// fin del metodo

    //Metodos de validacion de datos de entrada
    public static String ingresoString(String texto) {
        String muchaspalabras;
        System.out.println(texto);
        muchaspalabras = input.nextLine();
        return muchaspalabras;
    }

    //Metodo que permite seleccionar un jugador de la lista de jugadores
    public static int seleccionarJugador(Sistema sistema) {
        int lugarJugador;
        boolean jugadorValido = false;
        do {
            mostrarJugadores(sistema);
            System.out.println("------------------------------------");
            lugarJugador = ingresoINT("Ingrese el numero de jugador que desea elegir");
            //Se chequea si el jugador existe
            if (lugarJugador >= 0 && lugarJugador < sistema.getListaJugadores().size()) {
                jugadorValido = true;
            } else {
                System.out.println("Por favor ingrese un jugador que exista");
            }
        } while (!jugadorValido);
        return lugarJugador;
    }

    //Muestra la lista de jugadores
    public static void mostrarJugadores(Sistema sistema) {

        for (int i = 0; i < sistema.getListaJugadores().size(); i++) {
            System.out.println(i + ") " + sistema.getJugadorLista(i));

        }

    }

    //Perimite la creacion de un jugador y lo agrega a la lista
    public static void creacionJugador(Sistema sistema) {
        String nombre = ingresoString("Ingrese el nombre del Jugador: ");
        String alias = "";
        boolean repetido = true;
        while (repetido) {
            alias = ingresoString("Ingrese el alias del Jugador:");
            repetido = sistema.aliasRepetido(alias);
            if (repetido) {
                System.out.println("Este alias ya esta egistrado.");
            }
        }
        int edad;

        edad = ingresoINT("Ingrese la edad del jugador: ");
        //Chequeamos si la edad es positiva
        if (edad == 0) {
            System.out.println("Edad ingresada no valida");
        }

        Jugador J = new Jugador(nombre, edad, alias);
        sistema.setJugadorLista(J);

        System.out.println("\nJugador creado Correctamente");
    }

    //Ejecuta el algoritmo del juego saltar
    public static int jugarSaltar(Saltar s, Sistema sistema) {

        boolean salir;
        String mov;
        int aux;
        boolean terminar;
        boolean colValida = false;
        salir = false;

        /* El do while funciona para pedir la jugada de vuelta mientras que lo ingresado no sea "x"
           o el juego no haya terminado
         */
        do {
            System.out.println("Toca el color: " + s.getOrdenColor());
            do {
                mov = ingresoString("¿Que columna desea ingresar? (Ingrese X para salir)");
                //Cheque si el jugador quiere salir o no
                if (!mov.equalsIgnoreCase("x")) {
                    //Chequea si el jugador quiere ayuda
                    if (!mov.equalsIgnoreCase("ayuda")) {
                        //Itera hasta que la columna ingresada sea valida

                        //Chequea si el movimiento es numerico
                        if (sistema.esNumero(mov)) {
                            //Se usa aux para guardar el mov (String) como int
                            aux = Integer.valueOf(mov);
                            //Chequea si aux es valido dentro de la matriz de saltar, si lo es, mov es valido
                            if (aux < 1 || aux > 4) {
                                System.out.println("Ingrese un numero de columna validad");
                            } else {
                                colValida = true;
                                s.jugada(mov);
                            }

                        } else {
                            System.out.println("Ingrese una columna que sea numerica");
                        }

                    } else {
                        int columna = s.ayuda();
                        System.out.println("Una columna posible a usar es: " + columna);

                    }
                } else {
                    salir = true;

                }

            } while (!colValida);

            terminar = s.finalizacion();
            terminar = true;

        } while (!(salir || terminar));

        int puntaje = s.puntaje();
        System.out.println("Su puntaje final es: " + puntaje);

        return puntaje;

    }

    //Itera la bitacora y la muestra
    public static void mostrarBitacora(Sistema sistema) {

        Iterator<Partida> iter = sistema.getBitacora().iterator();
        if (!sistema.getBitacora().isEmpty()) {
            while (iter.hasNext()) {
                System.out.println(iter.next());
            }
        } else {
            System.out.println("La bitacora esta vacia");

        }
    }

    //Ordena la lista de partidas
    public static ArrayList<Partida> ordenar(Sistema sistema) {
        int opcion;
        boolean correcto = false;
        //Validacion de la opcion
        do {
            System.out.println("1) Ordenar por Alias de forma alfabetica");
            System.out.println("2) Ordenar por Puntaje de forma descendente");
            System.out.println("--------------------------------------------");

            opcion = ingresoINT("Ingrese la forma en la que se desea ordenar: ");
            //Le pasa el criterio segun a opcion
            switch (opcion) {
                case 1:
                    Collections.sort(sistema.getBitacora(), new CriterioAlias());
                    correcto = true;
                    break;
                case 2:
                    Collections.sort(sistema.getBitacora(), new CriterioPuntaje());
                    correcto = true;
                    break;
                default:
                    System.out.println("Por favor ingrse una opcion valida");
                    break;
            }

        } while (!correcto);
        return sistema.getBitacora();
    }

    //Ejecuta el algoritmo del juego rectangulo
    public static int jugarRectangulo(Rectangulo r, Sistema sistema) {

        boolean salir;
        String mov;
        boolean terminar;
        /* El primer do while funciona para pedir la jugada de vuelta mientras que lo ingresado no sea "x"
           o finalice el juego
         */

        salir = false;

        do {

            mov = ingresoString("Ingrese la jugada(Ingrese X para salir): ");
            //Chequea si el jugador desea salir del juego
            if (!mov.equalsIgnoreCase("x")) {
                r.jugada(mov);

            } else {
                salir = true;

            }
            terminar = r.finalizacion();

        } while (!(salir || terminar));

        int puntaje = r.puntaje();
        System.out.println("Su puntaje final es: " + puntaje);

        return puntaje;

    }

}
