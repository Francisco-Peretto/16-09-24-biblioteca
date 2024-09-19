using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_09_24_biblioteca
{
    internal class Genero
    {
        private int _id_Genero;
        private string _nombreGenero;

        public Genero(int _id_Genero, string _genero)
        {
            this._id_Genero = _id_Genero;
            this._nombreGenero = _genero;
        }

        public int Id_Genero
        {
            get { return this._id_Genero; }
            set { this._id_Genero = value; }
        }

        public string NombreGenero
        {
            get { return this._nombreGenero; }
            set { this._nombreGenero = value; }
        }

        public void MostrarDatosGenero()
        {
            Console.WriteLine($"Id: {this.Id_Genero} | Genero: {this.NombreGenero}");
        }
    }
}
