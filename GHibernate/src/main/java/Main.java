import javax.persistence.*;
import java.util.Scanner;

public class Main {
    private static final EntityManagerFactory ENTITY_MANAGER_FACTORY = Persistence
            .createEntityManagerFactory("Ejemplo");

    public static void main(String[] args) {

        System.out.println("Bienvenido");
        System.out.println("Vamos a gestionar nuestros Pedidos");
        System.out.println("Que necesitas realizar:");
        System.out.println("1-Añadir");
        System.out.println("2-Modificar");
        System.out.println("3-Eliminar");

        Scanner tcl2 =new Scanner(System.in);
        int op2=tcl2.nextInt();

        switch (op2) {
            case 1:

                System.out.println("Vamos a Insertar");


                break;

            case 2:

                System.out.println("Vamos a Modificar");
                break;
            case 3:

                System.out.println("Vamos a Borrar");
                break;
        }
    }


    public static void nuevoPedido() {

    }
    public static void modificarPedido() {

    }
    public static void eliminarPedido() {

    }
}
