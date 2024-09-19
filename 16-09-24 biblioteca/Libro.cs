using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_09_24_biblioteca
{
    internal class Libro
    {
        private int _id_libro;
        private string _titulo;
        private int _id_genero;
        private int _id_autor;
        private int _anio;
        private string _ubicacion;
        private char _estado;
        private List<Autor> ListaAutores;
        private string _nombreAutor;


        public Libro(int _id_libro, string _titulo, int _id_genero, int _id_autor, int _anio, string _ubicacion, char _estado)
        {
            this._id_libro = _id_libro;
            this._titulo = _titulo;
            this._id_genero = _id_genero;
            this._id_autor = _id_autor;
            this._anio = _anio;
            this._ubicacion = _ubicacion;
            this._estado = _estado;
            this.ListaAutores = new List<Autor>();
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

        public string Ubicacion
        {
            get { return this._ubicacion; }
            set { this._ubicacion = value; }
        }

        public char Estado
        {
            get { return this._estado; }
            set { this._estado = value; }
        }

        public void CambioDeEstado(char estado)
        {
            this.Estado = estado;
        }

        public void llenarListaDeAutores()
        {
            ListaAutores.Clear();
            FileStream Archivo;
            StreamReader leer;
            Archivo = new FileStream("autores.txt", FileMode.Open);
            leer = new StreamReader(Archivo);

            while (leer.EndOfStream == false)
            {// Falta cambiar id autor y genero a strings
                string cadena = leer.ReadLine(); string[] datos = cadena.Split(';');
                Autor autor = new Autor(int.Parse(datos[0]), datos[1], datos[2]);
                ListaAutores.Add(autor);
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

    //Falta llamar a genero y autor, llenar listas y cambiar la muestra en MostrarLibro
    public void MostrarLibro()
        {
            Console.WriteLine($"Id: {this.Id_libro} | Titulo: {this.Titulo} | Id del género: {this.Id_genero} | Autor: {this.NombreAutor()} | Año de publicación: {this._id_autor} | Ubicacion: {this.Ubicacion} | Estado: {this.Estado}");
        }
    }
}
