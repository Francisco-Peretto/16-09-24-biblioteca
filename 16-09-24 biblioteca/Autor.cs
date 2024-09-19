using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_09_24_biblioteca
{
    internal class Autor
    {
        private int _id_autor;
        private string _nombre;
        private string _apellido;

        public Autor(int _id_autor, string _nombre, string _apellido)
        {
            this._id_autor = _id_autor;
            this._nombre = _nombre;
            this._apellido = _apellido;
        }

        public int Id_autor
        {
            get { return this._id_autor; }
            set { this._id_autor = value; }
        }

        public string Apellido
        {
            get { return this._apellido; }
            set { this._apellido = value; }
        }

        public string Nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }

        public void MostrarDatosAutor()
        {
            Console.WriteLine($"Id: {this.Id_autor} | Nombre: {this.Nombre} | Apellido: {this.Apellido}");
        }
    }
}
