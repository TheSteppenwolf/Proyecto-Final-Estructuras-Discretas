/*
  Todo código dentro de Main no debe ser removido a menos que haya sido desarrollado por usted, si lo desarrollo otro colaborador
  no puede removerlo sin su autorización.
*/
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

            // Sera el QUEUE.
            List<Vertices> QUEUE = new List<Vertices>();

            // Variables que permitirán operar fluidamente con el programa.
            int maxVertices = 0, counter = 1, index = 0, counterValidator = 0;
            string[] listaVerticesTemp = null;
            string dataVertice = null, dataVerticeTemp = null;
            bool validator = true, validator2 = true;

            // Variables para el analisis del resusltado.
            List<int> listaIndexers = new List<int>();            

            // Variables para el menú.
            string opcion1 = null, opcionAdv = null;

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

                        // Ingreso cantidad de vertices del grafo.
                        while(true)
                        {
                            try { Console.Write("Ingrese la cantidad de conecciones entre vertices del grafo: "); maxVertices = Convert.ToInt32(Console.ReadLine()); } 
                            catch { Advertencia(); Console.WriteLine("Error: El valor ingresado debe ser un numero entero."); Advertencia(); continue; }
                            if (maxVertices <= 0) { Advertencia(); Console.WriteLine("Error: Debe existir al menos un vertice."); Advertencia(); continue; }
                            break;
                        }
                        listaVerticesTemp = new string[maxVertices];

                        // Ingreso de vertice inicial.
                        Console.Write("Ingrese el vertice inicial: "); dataVertice = Console.ReadLine();                        
                        listaVertices.Add(new Vertices() { State = 1, PastV = null, Data = dataVertice });
                        listaVerticesTemp[index] = dataVertice;

                        // Ingreso de vertices.
                        while(counter < maxVertices)
                        {
                            validator2 = true;
                            counterValidator = 0;

                            foreach(var iter in listaVertices)
                            {
                                if (iter.Data == listaVerticesTemp[index]) counterValidator++;
                            }
                            if (counterValidator > 1)
                            {
                                IngresoVertices(listaVerticesTemp[index], ref dataVerticeTemp, listaVerticesTemp[index]);
                                if (counter == 1) listaVertices.Add(new Vertices() { State = 1, PastV = listaVerticesTemp[index], Data = dataVerticeTemp });
                                else listaVertices.Add(new Vertices() { State = 1, PastV = listaVerticesTemp[index], Data = dataVerticeTemp });
                                listaVerticesTemp[counter] = dataVerticeTemp;
                                counter++;
                                index++;
                            }
                            else
                            {
                                // Validación de ingreso en vertice. (Métolodia pregunta antes de actuar)
                                do
                                {
                                    Console.Write($"\nExisten mas vertices conectados al vertice {listaVerticesTemp[index]}? (S:si/N:no): "); opcionAdv = Console.ReadLine().ToUpper().Trim();
                                    if (opcionAdv != "S" & opcionAdv != "N") { Advertencia(); Console.WriteLine("Error: Opcion ingresada no valida."); Advertencia(); }
                                } while (opcionAdv != "S" & opcionAdv != "N");

                                // Ingreso oficial del vertice.
                                if (opcionAdv == "S")
                                {
                                    Console.WriteLine();
                                    IngresoVertices(listaVerticesTemp[index], ref dataVerticeTemp);
                                    if (counter == 1) listaVertices.Add(new Vertices() { State = 1, PastV = listaVerticesTemp[index], Data = dataVerticeTemp });
                                    else listaVertices.Add(new Vertices() { State = 1, PastV = listaVerticesTemp[index], Data = dataVerticeTemp });
                                    listaVerticesTemp[counter] = dataVerticeTemp;
                                    counter++;
                                }

                                // Para validar ingreso de vertices.
                                if (opcionAdv == "N")
                                {
                                    index++;
                                }
                            }
                        }


                        Console.Clear();
                        Console.WriteLine("Procesando información..."); Procesando();
                        Console.WriteLine("\n\nLos datos han sido guardados exitosamente...");
                        Console.WriteLine("Presione cualquier tecla para regresar..."); Console.ReadKey(); Console.Clear();

                        break;

                    #endregion

                    #region Resultados de busqueda por BFS

                    case "2":
                        // Paso 1: Todos los vertices ya se encuentran inicializados en el estado ready o STATUS = 1.
                        // Paso 2: El vertice inicial se cambia de estado al waiting o STATUS = 2.
                        foreach(var iter in listaVertices)
                        {
                            if(iter.Data == listaVerticesTemp[0])
                            {
                                dataVertice = iter.Data;
                                dataVerticeTemp = iter.PastV;
                                counter = listaVertices.IndexOf(iter);
                            }
                        }
                        QUEUE.Add(new Vertices { State = 2, PastV = dataVerticeTemp, Data = dataVertice });
                        listaVertices.RemoveAt(counter);


                        // Paso 3: Repetir los pasos 4 y 5 hasta obtener todos los valores.
                        while(validator)
                        {
                            counter = 0;
                            validator2 = true;
                            listaVerticesTemp = new string[maxVertices];
                            listaIndexers = new List<int>();

                            // Paso 4: Sacar el primer vertice N para ser procesado cambiando su estado a processed o STATUS = 3.
                            foreach (var iter in listaVertices)
                            {
                                if (iter.PastV == dataVertice)
                                {
                                    listaVerticesTemp[counter] = iter.Data; 
                                    listaIndexers.Add(listaVertices.IndexOf(iter));
                                    counter++;
                                }
                            }

                            // Elimina los vertices de la anterior lista.
                            int temp = 0;
                            foreach (var iter in listaIndexers)
                            {                                
                                listaVertices.RemoveAt(iter - temp);
                                temp++;
                            }

                            // Ordena de manera ascendente desde el primer valor hasta el ultimo valor el array.
                            for(int i = 0; i < counter; i++)
                                for(int j = 0; j < counter - 1; j++)
                                {
                                    if(listaVerticesTemp[j].CompareTo(listaVerticesTemp[j + 1]) > 0)
                                    {
                                        dataVerticeTemp = listaVerticesTemp[j];
                                        listaVerticesTemp[j] = listaVerticesTemp[j + 1];
                                        listaVerticesTemp[j + 1] = dataVerticeTemp;
                                    }
                                }

                            // Se ingresa en el orden dentro de la lista QUEUE.
                            foreach(var iter in listaVerticesTemp)
                            {
                                if(iter != null) QUEUE.Add(new Vertices { State = 1, PastV = dataVertice, Data = iter });
                            }

                            // Se inicializa dataVertice con un nuevo vertice por evaluar.
                            // Paso 5: Se declaran variables para examinar los vecinos de cada vertice.
                            foreach(var iter in QUEUE)
                            {
                                if (iter.State == 1)
                                {
                                    dataVertice = iter.Data;
                                    dataVerticeTemp = iter.PastV;
                                    counter = QUEUE.IndexOf(iter);
                                    validator = true;
                                    break;
                                }
                                else validator = false;
                            }

                            // Se establece STATUS = 3 o estado processed.
                            if (validator)
                            {
                                QUEUE.RemoveAt(counter);
                                foreach(var iter in QUEUE)
                                {
                                    if (iter.Data == dataVertice) validator2 = false;                                    
                                }
                                if(validator2) QUEUE.Add(new Vertices { State = 3, PastV = dataVerticeTemp, Data = dataVertice });                                
                            }
                        }

                        // Salida de información.
                        Console.Write("El resultado de la busqueda es: ");
                        foreach (var iter in QUEUE) Console.Write(iter.Data);
                        Console.WriteLine("\n\nPresione cualquier tecla para regresar..."); Console.ReadKey(); Console.Clear();

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

                    #region Salida del programa y opciones inválidas

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

                    #endregion
                }
            }

            #endregion
        }

        #region Métodos

        #region Ingreso de datos

        static void IngresoVertices(string p_dataVertice, ref string p_dataVerticeTemp)
        {
            Console.Write($"Ingrese el vertice conectado al vertice {p_dataVertice}: "); p_dataVerticeTemp = Console.ReadLine();
        }
        static void IngresoVertices(string p_dataVertice, ref string p_dataVerticeTemp, string data)
        {
            p_dataVerticeTemp = data;
        }

        #endregion

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
