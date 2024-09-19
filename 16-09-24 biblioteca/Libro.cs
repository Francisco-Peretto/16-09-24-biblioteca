using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace _16_09_24_biblioteca
{
    internal class Libro
    {
        private int _id_libro;
        private string _titulo;
        private int _id_genero;
        private int _id_autor;
        private int _anio;
        private int _ubicacion;
        private char _estado;
        private List<Autor> ListaAutores;
        private List<Genero> ListaGeneros;


        public Libro(int _id_libro, string _titulo, int _id_genero, int _id_autor, int _anio, int _ubicacion, char _estado)
        {
            this._id_libro = _id_libro;
            this._titulo = _titulo;
            this._id_genero = _id_genero;
            this._id_autor = _id_autor;
            this._anio = _anio;
            this._ubicacion = _ubicacion;
            this._estado = _estado;
            this.ListaAutores = new List<Autor>();
            this.ListaGeneros = new List<Genero>();
        }

        public int Id_libro
        {
            get { return this._id_libro; }
            set { this._id_libro = value; }
        }

        public string Titulo
        {
            get { return this._titulo; }
            set { this._titulo = value; }
        }

        public int Id_genero
        {
            get { return this._id_libro; }
            set { this._id_libro = value; }
        }

        public int Id_autor
        {
            get { return this._id_autor; }
            set { this._id_autor = value; }
        }

        public int Anio
        {
            get { return this._anio; }
            set { this._anio = value; }
        }

        public int Ubicacion
        {
            get { return this._ubicacion; }
            set { this._ubicacion = value; }
        }

        public char Estado
        {
            get { return this._estado; }
            set { this._estado = value; }
        }

        public void CambioDeEstado()
        {
            char opcion;
            Console.Write($"El estado actual del libro es {this.Estado}, ¿Desea cambiarlo? s/n: ");
            while(!(char.TryParse(Console.ReadLine().ToLower(), out opcion) && (opcion == 's' || opcion == 'n')))
            {
                Console.WriteLine("Error en la elección. Inténtelo nuevamente\n");
                Console.Write($"El estado actual del libro es {this.Estado}, ¿Desea cambiarlo? s/n: ");
            }
            switch (opcion)
            {
                case 's':
                    if (this.Estado == 'P')
                    {
                        this.Estado = 'D';
                    }
                    else
                    {
                        this.Estado = 'P';
                    }
                    Console.WriteLine("Estado del libro cambiado a " + this.Estado);
                    break;
                case 'n':
                    Console.WriteLine("El estado del libro permanece como " + this.Estado);
                    break;
            }   
        }

        public void LlenarListaDeAutores()
        {
            ListaAutores.Clear();
            FileStream Archivo;
            StreamReader leer;
            Archivo = new FileStream("autores.txt", FileMode.Open);
            leer = new StreamReader(Archivo);

            while (leer.EndOfStream == false)
            {
                string cadena = leer.ReadLine(); string[] datos = cadena.Split(';');
                Autor autor = new Autor(int.Parse(datos[0]), datos[1], datos[2]);
                ListaAutores.Add(autor);
            }
            leer.Close();
            Archivo.Close();
        }

        public void LlenarListaDeGeneros()
        {
            ListaGeneros.Clear();
            FileStream Archivo;
            StreamReader leer;
            Archivo = new FileStream("generos.txt", FileMode.Open);
            leer = new StreamReader(Archivo);

            while (leer.EndOfStream == false)
            {
                string cadena = leer.ReadLine(); string[] datos = cadena.Split(';');
                Genero genero = new Genero(int.Parse(datos[0]), datos[1]);
                ListaGeneros.Add(genero);
            }
            leer.Close();
            Archivo.Close();
        }

        public string NombreAutor()
        {
            foreach (Autor autor in ListaAutores)
            {
                if (autor.Id_autor == this.Id_autor)
                {
                    return $"{autor.Nombre} {autor.Apellido}";
                }
            }
            return "";
        }

        public string NombreGenero()
        {
            foreach (Genero genero in ListaGeneros)
            {
                if (genero.Id_Genero == this.Id_autor)
                {
                    return $"{genero.NombreGenero}";
                }
            }
            return "";
        }

        public void MostrarLibro(string caso)
        {
            this.LlenarListaDeAutores();
            this.LlenarListaDeGeneros();
            this.NombreAutor();
            this.NombreGenero();

            switch (caso)
            {
                case "todos":
                    Console.WriteLine($"Id: {this.Id_libro} | Titulo: {this.Titulo} | Género: {this.NombreGenero()} | Autor: {this.NombreAutor()} | Año de publicación: {this.Anio} | Ubicacion: {this.Ubicacion} | Estado: {this.Estado}");
                    break;

                case "prestados":
                    Console.WriteLine($"Id: {this.Id_libro} | Titulo: {this.Titulo} | Género: {this.NombreGenero()} | Autor: {this.NombreAutor()} | Año de publicación: {this.Anio}");
                    break;

                case "titulos":
                    Console.WriteLine($"El libro {this.Titulo} se encuentra disponible en: {this.Ubicacion}");
                    break;

                case "autores":
                    Console.WriteLine($"El libro {this.Titulo}, Género: {this.NombreGenero()}, autor: {this.NombreAutor()}, Año de publicación: {this.Anio}, Estado: {this.Estado}, se encuentra en: {this.Ubicacion} ");
                    break;

                case "generos":
                    Console.WriteLine($"El libro {this.Titulo}, autor: {this.NombreAutor()}, Año de publicación: {this.Anio}, Estado: {this.Estado}, se encuentra en: {this.Ubicacion} ");
                    break;
            }
        }
    }
}
