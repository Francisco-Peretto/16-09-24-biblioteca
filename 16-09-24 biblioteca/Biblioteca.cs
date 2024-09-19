using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_09_24_biblioteca
{
    internal class Biblioteca
    {
        private List<Libro> ListaDeLibros;

        public Biblioteca()
        {
            this.ListaDeLibros = new List<Libro>();
        }

        public void llenarListaDeLibros()
        {
            ListaDeLibros.Clear();
            FileStream Archivo;
            StreamReader leer;
            Archivo = new FileStream("libros.txt", FileMode.Open);
            leer = new StreamReader(Archivo);

            while (leer.EndOfStream == false)
            {
                string cadena = leer.ReadLine(); string[] datos = cadena.Split(';');
                Libro libro = new Libro(int.Parse(datos[0]), datos[1], int.Parse(datos[2]), int.Parse(datos[3]), int.Parse(datos[4]), int.Parse(datos[5]), char.Parse(datos[6]));
                ListaDeLibros.Add(libro);
            }
            leer.Close();
            Archivo.Close();
        }

        //
        public void MostrarTodosLosLibros()
        {
            Console.WriteLine("\nListado de todos los libros de la biblioteca:");
            foreach (Libro libro in this.ListaDeLibros)
            {
                libro.MostrarLibro("todos");
            }
        }

        //
        public void ReporteDeLibrosPrestados()
        {

            Console.WriteLine("\nListado de todos los libros prestados de la biblioteca:");
            foreach (Libro libro in this.ListaDeLibros)
            {
                if (libro.Estado == 'P')
                {
                    libro.MostrarLibro("prestados");
                }
            }
        }

        public void BusquedaDeUnLibro()
        {
            string aBuscar;
            bool encontrado = false;
            Console.Write("\nIngrese el título del libro a buscar: ");
            aBuscar = Console.ReadLine();
            foreach (Libro libro in this.ListaDeLibros)
            {
                if (libro.Titulo == aBuscar && libro.Estado == 'D')
                {
                    libro.MostrarLibro("titulos");
                    encontrado = true;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("El libro no se encontró o no encuentra disponible.");
            }
        }

        public void BusquedaDeUnAutor()
        {
            string aBuscar;
            bool encontrado = false;
            Console.Write("\nIngrese el autor a buscar: ");
            aBuscar = Console.ReadLine();
            foreach (Libro libro in this.ListaDeLibros)
            {
                if (libro.NombreAutor() == aBuscar)
                {
                    libro.MostrarLibro("autores");
                    encontrado = true;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("No se han encotrado libros del autor.");
            }
        }

        public void BusquedasDeLosLibrosPorGenero()
        {
            string aBuscar;
            bool encontrado = false;
            Console.Write("\nIngrese el género a buscar: ");
            aBuscar = Console.ReadLine();
            foreach (Libro libro in this.ListaDeLibros)
            {
                if (libro.NombreGenero() == aBuscar)
                {
                    libro.MostrarLibro("generos");
                    encontrado = true;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("No se han encotrado libros del género.");
            }
        }
    }
}
