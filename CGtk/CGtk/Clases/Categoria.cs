using System;
namespace CGtk
{
    public class Categoria
    {
        public Categoria(ulong id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        private ulong id;
        private string nombre;

        public ulong Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}