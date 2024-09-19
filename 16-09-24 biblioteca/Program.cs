using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_09_24_biblioteca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Libro libro = new Libro(1, "Fundación", 1, 1, 1951, 23, 'P');
            libro.LlenarListaDeGeneros();
            libro.LlenarListaDeAutores();
            libro.MostrarLibro();
            libro.CambioDeEstado();
            */

            Biblioteca biblio = new Biblioteca();
            biblio.llenarListaDeLibros();
            biblio.MostrarTodosLosLibros();

            
            string[] menuOpciones = { "Mostrar todos los libros", "Reporte de libros prestados", "Búsqueda de un libro", "Búsqueda de libros por autor", "Búsqueda de libros por género", "Salir" };
            int posicionActual = 0;
            Console.CursorVisible = false;
            bool bucle = false;

            while (!bucle)
            {
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("Seleccione una opción con las flechas ↑ y ↓");
                Console.WriteLine("-------------------------------------------");

                for (int i = 0; i < menuOpciones.Length; i++)
                {
                    if (posicionActual == i)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" " + (char)62 + " ");
                    }
                    Console.WriteLine(menuOpciones[i]);
                    Console.ResetColor();
                }

                ConsoleKeyInfo tecla = Console.ReadKey();
                switch (tecla.Key)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:
                        if (posicionActual == menuOpciones.Length - 1)
                        {
                            Console.WriteLine("\nSaliendo...");
                            bucle = true;
                        }

                        else if (posicionActual == 0)
                        {
                            biblio.MostrarTodosLosLibros();
                        }

                        else if (posicionActual == 1)
                        {
                            biblio.ReporteDeLibrosPrestados();
                        }

                        else if (posicionActual == 2)
                        {
                            biblio.BusquedaDeUnLibro();
                        }

                        else if (posicionActual == 3)
                        {
                            biblio.BusquedaDeUnAutor();
                        }

                        else if (posicionActual == 4)
                        {
                            biblio.BusquedasDeLosLibrosPorGenero();
                        }

                        Console.WriteLine("\nPresione una tecla para continuar.");
                        Console.ReadKey();
                        break;

                    case ConsoleKey.UpArrow:
                        posicionActual = Math.Max(0, posicionActual - 1);
                        break;

                    case ConsoleKey.DownArrow:
                        posicionActual = Math.Min(menuOpciones.Length - 1, posicionActual + 1);
                        break;

                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }

            Console.ReadKey();


        }
    }
}
