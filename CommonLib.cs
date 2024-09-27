using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAgenda
{
    public class CommonLib
    {
        public bool ValidarNumero(string numero)
        {
            string telStr = numero;
            if (telStr.All(char.IsDigit) && (telStr.Length == 10 || telStr.Length == 11))
            {
                return true;
            }
            else
            {
                string msg = "El número debe tener una longitud de 10 o 11 caracteres numéricos";
                return false;
            }
        }
        public bool ValidarId(string value, out int numero)
        {
            bool exito = Int32.TryParse(value, out numero);
                return exito;
        }
        public int ObtenerNuevoId(Dictionary<int, Contacto> contactos)
        {
            return contactos.Keys.Count > 0 ? contactos.Keys.Max() + 1 : 1; // Retorna el siguiente ID
        }
    }
}
