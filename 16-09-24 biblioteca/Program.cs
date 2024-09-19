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
            Libro libro = new Libro(1, "Fundación", 1, 1, 1951, 23, 'P');
            libro.LlenarListaDeGeneros();
            libro.LlenarListaDeAutores();
            libro.MostrarLibro();
            libro.CambioDeEstado();
            Console.ReadKey();
        }
    }
}
