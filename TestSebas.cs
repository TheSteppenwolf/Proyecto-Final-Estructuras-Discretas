using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Final_Estructuras_Discretas
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Variables

            // Almacena el orden de todos los vertices ingresados.
            List<Vertices> listaVertices = new List<Vertices>();

            // Variables para el menú.
            string opcion1 = null;

            #endregion

            #region Menu de opciones

            while (opcion1 != "4")
            {
                Console.WriteLine("ASAAT ---- Breath First Search | Metodo de busqueda por anchura\nQue deseas hacer?");
                Console.Write("\t1.Ingreso de datos.\n\t2.Resultado de busqueda por BFS.\n\t3.Creditos.\n\t4.Salir.\nOpcion: ");
                opcion1 = Console.ReadLine();
                Console.Clear();
                switch(opcion1)
                {
                    #region Ingreso de datos

                    case "1":
                        break;

                    #endregion

                    #region Resultados de bsuqueda por BFS

                    case "2":
                        break;

                    #endregion

                    #region Creditos

                    case "3":
                        Console.WriteLine("ASAAT ---- Breath First Search | Metodo de busqueda por anchura");
                        Console.WriteLine("Fue desarrollado por:\n\t-Andres Cajamarca.\n\t-Andres Orozco.\n\t-Angel Seraquive\n\t-Sebastian Tamayo");
                        Console.WriteLine("\nMateria: Estructuras Discretas.\nProfesor: Juan Carlos Osorio Lopez.\n");
                        Console.WriteLine("\nDetalles del programa: El programa fue realizado en el lenguaje de programación C# utilizando las bibliotecas de .NET framework 4.7.2" +
                            " ambientado a consola.");
                        Console.WriteLine("\n\nPresione cualquier tecla para regresar..."); Console.ReadKey(); Console.Clear();
                        break;

                    #endregion

                    // Salida del programa.
                    case "4":
                        Console.WriteLine("Saliendo del programa...");
                        Procesando();
                        Console.WriteLine("Gracias por utilizar ASAAT!");
                        Console.WriteLine("Presione cualquier tecla para salir..."); Console.ReadKey(); Console.Clear();
                        break;

                    // En caso de ingreso de opciones inválidas.
                    default:
                        Advertencia();
                        Console.WriteLine("Error: Opcion ingresada no valida.");
                        Advertencia();
                        Console.WriteLine("Presione cualquier tecla para continuar..."); Console.ReadKey(); Console.Clear();
                        break;
                }
            }

            #endregion
        }

        #region Métodos

        #region Ambiente amigable

        static void Advertencia()
        {
            Console.WriteLine("\n"); for (int i = 0; i < 100; i++) Console.Write("*"); Console.WriteLine("\n");            
        }

        static void Procesando()
        {
            for (int i = 0; i < 5; i++) { for (int j = 0; j < i + 1; j++) Console.Write("."); Console.WriteLine(); }
        }

        #endregion

        #endregion

    }
}

