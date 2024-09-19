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
    }
}
