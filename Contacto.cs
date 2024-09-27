using System;
using System.Collections.Generic;

namespace ProyectoAgenda
{
    public class Contacto
    {
        public string Telefono { get; set; }
        public string Nombre { get; set; }

        public Contacto(string telefono, string nombre)
        {
            Telefono = telefono;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return $"Teléfono: {Telefono}, Nombre: {Nombre}";
        }
    }
}