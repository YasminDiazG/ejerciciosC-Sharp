using System;
using System.Collections.Generic;
using System.Transactions;

namespace ParcialNro1
{
    public class Alumno /* Clase Alumno con atributos Nombre, Apellido y FechaNac */
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNac { get; set; }
    }

    public class Cola /* Clase Cola con métodos Agregar, Eliminar, Primero
                      Llena, Vacia, Recorrer y PorApellido. Utiliza los
                      atributos de la clase Alumno y las operaciones de Queue*/
    {
        Queue<Alumno> Estudiante = new Queue<Alumno>();

        public void Agregar(int maximo)
        {   // Agrega datos de Alumno al final de la lista enlazada.
            // Necesita un argumento entero "maximo"
            // Si se llega al tope de alumnos, no se pueden ingresar mas datos
            Alumno estudiante = new Alumno();
            int salir_bucle = 0;
            DateTime fecha_out;

            if (Estudiante.Count < maximo) // Mientras no llegue al maximo, puedo agregar alumnos
            {
                Console.WriteLine("\nIngrese datos del alumno a continuación...");

                Console.Write("Nombre: ");
                estudiante.Nombre = Console.ReadLine(); // Guardo el nombre

                Console.Write("Apellido: ");
                estudiante.Apellido = Console.ReadLine(); // Guardo el apellido

                Console.Write("Fecha de nacimiento (dd/MM/yyyy): ");
                string fecha = Console.ReadLine();
                while (salir_bucle == 0) // Este bucle es para chequear el formato de Fecha de Nacimiento
                {
                    if (DateTime.TryParse(fecha, out fecha_out)) // Si parsea, guardo fecha en formato dd/MM/yyyy
                    {
                        String.Format("{0:dd/MM/yyyy}", fecha_out);
                        estudiante.FechaNac = fecha_out;
                        salir_bucle = 1;
                    }
                    else // Si no parsea, vuelvo a pedir
                    {
                        Console.Write("Formato invalido, vuelva a ingresar fecha: ");
                        fecha = Console.ReadLine();
                    }
                }
                Estudiante.Enqueue(estudiante); // Los atributos en el objeto estudiante, los encolo a la lista
            }
            else // Si llego al maximo de alumnos, no realizo esta operacion
                Console.WriteLine("\nTope de alumnos alcanzado. No se pueden ingresar más.");
        }

        public void Eliminar()
        {   // Elimino datos de Alumno (solo el primero de la lista enlazada)
            Alumno estudiante = new Alumno();

            if (Estudiante.Count != 0) // Si la lista no está vacía, sigo con la operación
            {
                estudiante = Estudiante.Dequeue(); // Guardo temporalmente los datos del primer alumno que elimino de la lista

                Console.WriteLine("\nBorrando datos del primer alumno en cola...\nSus datos eran:");
                Console.WriteLine("Nombre: {0}\nApellido: {1}\nFecha de nacimiento: {2}",
                                   estudiante.Nombre, estudiante.Apellido, estudiante.FechaNac.ToString("dd/MM/yyyy"));
            }
            else // Si la lista está vacía, no realizo esta operación
                Console.WriteLine("\nNo hay alumnos para eliminar!\n");
        }

        public void Primero()
        {   // Observo los datos de Alumno (solo el primero de la lista enlazada)
            Alumno estudiante = new Alumno();

            if (Estudiante.Count != 0) // Si la lista no está vacía, sigo con la operación
            {
                estudiante = Estudiante.Peek(); // Guardo temporalmente los datos del primer alumno de la lista

                Console.WriteLine("\nDatos del primer alumno en cola...");
                Console.WriteLine("Nombre: {0}\nApellido: {1}\nFecha de nacimiento: {2}",
                                   estudiante.Nombre, estudiante.Apellido, estudiante.FechaNac.ToString("dd/MM/yyyy"));
            }
            else // Si la lista está vacía, no realizo esta operación
                Console.WriteLine("\nNo hay alumnos en la cola!\n");
        }

        public void Llena(int maximo)
        {   // Chequeo si la lista enlazada llega a su tope definido por usuario
            // Necesita un argumento entero "maximo"
            Alumno estudiante = new Alumno();

            int check = Estudiante.Count; // Guardo la cantidad de alumnos en la lista enlazada
            if (check != maximo)
                Console.WriteLine("\nCola de alumnos no está llena");
            else
                Console.WriteLine("\nCola de alumnos está llena");
        }

        public void Vacia()
        {   // Chequeo si la lista enlazada está vacía
            Alumno estudiante = new Alumno();

            int check = Estudiante.Count; // Guardo la cantidad de alumnos en la lista enlazada
            if (check != 0)
                Console.WriteLine("\nCola de alumnos no está vacía");
            else
                Console.WriteLine("\nCola de alumnos está vacía");
        }

        public void Recorrer()
        {   // Realizo recorrido de la lista enlazada Alumno, mostrando su datos por consola
            if (Estudiante.Count != 0)
            {
                Console.WriteLine("\nLa cola actual es la siguiente: \n");
                Console.WriteLine("\t" + new string('-', 54)); // Primera linea de tabla
                Console.Write(String.Format("\t|{0,15}|{1,15}|{2,20}|\n", "Nombre", "Apellido", "Fecha de Nacimiento"));
                Console.WriteLine("\t" + new string('-', 54)); // Segunda linea de tabla
                foreach (Alumno dato in Estudiante) // Recorro con foreach para obtener cada dato de Estudiante (cada nodo de la lista enlazada)
                    Console.Write(String.Format("\t|{0,15}|{1,15}|{2,20}|\n", dato.Nombre, dato.Apellido, dato.FechaNac.ToString("dd/MM/yyyy")));
                Console.WriteLine("\t" + new string('-', 54)); // Tercera linea de tabla
            }
            else
                Console.WriteLine("\nCola de alumnos está vacía");
        }

        public void PorApellido()
        {   // Realizo recorrido de la lista enlazada Alumno hasta encontrar el primero que matchee con el
            //apellido que ingresa el usuario, y se muestran los datos por consola. Si no hay match, se
            //avisa que no existe en la lista enlazada.
            if (Estudiante.Count != 0) // Si hay alumnos en la lista, sigo con la operación
            {
                Console.Write("Ingrese apellido: ");
                string apellido = Console.ReadLine(); // Guardo el apellido

                foreach (Alumno dato in Estudiante) // Recorro con foreach para obtener cada dato de Estudiante (cada nodo de la lista enlazada)
                {
                    if (apellido == dato.Apellido) // Si son iguales, muestro los datos del alumno encontrado
                    {
                        Console.WriteLine("\nAlumno encontrado!");
                        Console.Write("Nombre: {0}\nApellido: {1}\nFecha de Nacimiento: {2}\n",
                                      dato.Nombre, dato.Apellido, dato.FechaNac.ToString("dd/MM/yyyy"));
                        return; // Salgo del método
                    }
                }

                Console.WriteLine("\nNo hay alumnos con apellido {0}\n", apellido); // Aviso si no se encontró el apellido solicitado
            }
            else
                Console.WriteLine("\nCola de alumnos está vacía\n"); // Si no hay alumnos, aviso
        }
    }


    class Parcial
    {
        /* Clase Parcial que contiene la función Main con sus respectivas operaciones principales */
        static void Main(string[] args)
        {
            Cola estudiante = new Cola();
            string opc; // Variable para acceder al menu

            Console.WriteLine("Bienvenido!\n");
            Console.Write("Ingrese máximo de alumnos en cola, por favor: ");
            int maxAlumnos = Convert.ToInt32(Console.ReadLine()); // Guardo máximo de alumnos que se pueden ingresar

            do
            {   // Entro al menu aunque sea una vez, salgo con 0
                Console.WriteLine("\nMenú (Solo seleccionar del 0 al 6):   \n" +
                                    "------------------------------------- \n" +
                                    "   1) Agregar alumno a la cola        \n" +
                                    "   2) Eliminar alumno a la cola       \n" +
                                    "   3) Ver 1er alumno a la cola        \n" +
                                    "   4) Chequear si la cola está llena  \n" +
                                    "   5) Chequear si la cola está vacia  \n" +
                                    "   6) Buscar alumno por apellido      \n" +
                                    "   0) Salir del menú                  \n");
                Console.Write("Elija una opción: ");
                opc = Console.ReadLine(); // Obtengo valor correspondiente al menú

                switch (opc)
                {
                    case "1": // Agrego alumno
                        estudiante.Agregar(maxAlumnos);
                        break;

                    case "2": // Elimino alumno
                        estudiante.Eliminar();
                        break;

                    case "3": // Primer alumno
                        estudiante.Primero();
                        break;

                    case "4": // Verifico si la cola está llena
                        estudiante.Llena(maxAlumnos);
                        break;

                    case "5": // Verifico si la cola está vacía
                        estudiante.Vacia();
                        break;

                    case "6": // Busqueda por apellido (el primero que encuentra)
                        estudiante.PorApellido();
                        break;

                    case "0": // Salir
                        Console.WriteLine("\nGracias! Vuelva prontos!\n");
                        break;

                    default: // Opcion inválida
                        Console.WriteLine("Opción inválida!");
                        break;
                }

                if (opc != "0") // Recorro lista y lo imprimo en consola
                {
                    estudiante.Recorrer(); // Recorro cola e imprimo en consola
                    Console.WriteLine("Aprete ENTER para continuar... ");
                    Console.ReadLine();
                    Console.Clear(); // Limpio consosola
                }
            } while (opc != "0");
        }
    }
}
