// Joaquin Bonifacino - 243193 - Rafael Cadenas - 269150

package dominio;

import java.io.IOException;
import java.nio.file.Paths;
import java.util.Scanner;

public class ArchivoLectura {
    private Scanner in;
    private String linea;
    public ArchivoLectura(String unNombre){
        try{
            in= new Scanner(Paths.get(unNombre));
            
        }catch(IOException e){
            System.out.println("Error de lectura");
            System.exit(1);
        }
    }
    public boolean hayMasLineas(){
        boolean hay = false;
        linea = null;
        if (in.hasNext()){
            linea = in.nextLine();
            hay = true;
        }
        return hay;
    }
    public String linea(){
        return linea;
    }
    public void cerrar(){
        in.close();
    }
}
