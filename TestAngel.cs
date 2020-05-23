
using System;

namespace Arbol_menu
{
    class Program
    {
        static void Main(string[] args)
        {
            int r,f1, opcion,n1;
            int [] r1;
            int [] r2;
            

            Console.WriteLine("¡¡¡Bienvenido a nuestro programa!!!\n"); //Ingreso de datos por Andy Cajamarca y Angel

            Console.WriteLine("1. Ingreso de datos ");
            Console.WriteLine("2. Visualizacion del arbol ");
            Console.WriteLine("3. Busqueda del nodo\n ");
            Console.Write("Elija una opción...");

            opcion = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (opcion)
            {
                case 1:
                  
                    Console.Write("Ingrese la raiz... ");
                    r = Int32.Parse(Console.ReadLine());
                    Console.Write("Ingreso el numero de filas... "); 
                    f1 = Int32.Parse(Console.ReadLine());
              
                    Console.Write("Ingrese la cantidad de nodos... ");
                    n1 = Int32.Parse(Console.ReadLine());
                    r2 = new int[n1];
                    for (int j = 0; j < n1; j++)
                    {
                        Console.Write("Nodo n°{0}: ", j + 1);
                        r2[j] = Int32.Parse(Console.ReadLine());
                      
                    }


                    break;  //fin de ingreso de datos

                case 2:
                    Console.WriteLine("Visualizacion del arbol ");
                    break;

                case 3:
                    Console.WriteLine("Busqueda del nodo ");

                    break;

                default:
                    break;
            }

          

        }
    }
}
