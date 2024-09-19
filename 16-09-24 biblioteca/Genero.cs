using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_09_24_biblioteca
{
    internal class Genero
    {
        private int _id_genero;
        private string _nombreGenero;

        public Genero(int _id_genero, string _genero)
        {
            this._id_genero = _id_genero;
            this._nombreGenero = _genero;
        }

        public int Id_genero
        {
            get { return this._id_genero; }
            set { this._id_genero = value; }
        }

        public string NombreGenero
        {
            get { return this._nombreGenero; }
            set { this._nombreGenero = value; }
        }

        public void MostrarDatosGenero()
        {
            Console.WriteLine($"Id: {this.Id_genero} | Genero: {this.NombreGenero}");
        }
    }
}
