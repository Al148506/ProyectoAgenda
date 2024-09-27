using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
namespace ProyectoAgenda
{
    public class Agenda
    {
        public Agenda()
        {
            Console.Clear();
            Dictionary<int, Contacto> DContacts = new Dictionary<int, Contacto> {
        { 1, new Contacto("4495865567", "Juan Pérez") },
        { 2, new Contacto("5551234567", "María López") },
        { 3, new Contacto("1234567890", "Carlos García") }
        };

            do
            {
                Console.WriteLine("Hola, oprime el número de la opción que quieras ejecutar");
                Console.WriteLine("Opción 1 para crear un nuevo contacto");
                Console.WriteLine("Opción 2 para editar un contacto");
                Console.WriteLine("Opción 3 para eliminar un contacto");
                Console.WriteLine("Opción 4 para buscar un contacto");
                Console.WriteLine("Opción 5 para salir del programa");
                int opcion;
                int id;
                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    if (opcion > 0 && opcion <= 5)
                    {
                        if (opcion == 1)
                        {
                            Console.WriteLine("Escriba el número del contacto (10 o 11 dígitos):");
                            string telStr = Console.ReadLine();
                            CommonLib commonLib = new CommonLib();
                            bool validacion = commonLib.ValidarNumero(telStr);
                            
                            // Verificar que todos los caracteres sean numéricos
                            if (validacion == true)
                                {
                                    Console.WriteLine("Escriba el nombre del contacto:");
                                    string name = Console.ReadLine();
                                    Contacto nuevoContacto = new Contacto(telStr, name);
                                    int idNuevo = commonLib.ObtenerNuevoId(DContacts);
                                    DContacts.Add(idNuevo, nuevoContacto);
                                    Console.WriteLine("Contacto añadido.");
                                   
                            }
                             
                            else
                                {
                                    Console.WriteLine("El número debe tener una longitud de 10 o 11 caracteres numéricos.");
                                }
                           
                            
                            
                        }

                        if (opcion == 2)
                        {
                            do
                            {

                                if (DContacts.Count < 1)
                                {
                                    Console.WriteLine("No hay contactos existentes");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Escribe el id del contacto a editar");
                                    Console.WriteLine("Oprima la tecla 0 para salir al menu principal");

                                    foreach (KeyValuePair<int, Contacto> par in DContacts)
                                    {

                                        Console.WriteLine($" Id: {par.Key} Teléfono: {par.Value.Telefono}, Nombre: {par.Value.Nombre}");

                                    }

                                    string value = Console.ReadLine();
                                    if (value == "0") break;
                                    CommonLib commonLib = new CommonLib();
                                    bool esValido = commonLib.ValidarId(value, out id);

                                    if (esValido)
                                    {
                                        if (DContacts.ContainsKey(id))
                                        {
                                            Console.WriteLine($"ID válido: {id}");
                                            Console.WriteLine("Oprime 1 si quieres cambiar el nombre, oprime 2 si quieres cambiar el telefono, oprime cualquier otra tecla para salir al menu principal");
                                            string Opc = Console.ReadLine();
                                            if (Opc == "1")
                                            {
                                                Console.WriteLine("Escribe el nuevo nombre");
                                                string nombre = Console.ReadLine();
                                                DContacts[id].Nombre = nombre;
                                                Console.WriteLine($"El contacto con id {id} se ha actualizado con los siguientes datos {DContacts[id]}");
                                                Console.WriteLine("Si desea seguir editando contactos presione 1, si quiere volver al menu principal presione cualquier tecla");
                                                string salida = Console.ReadLine();
                                                if (salida != "1")
                                                {
                                                    break;
                                                };
                                            }
                                            if (Opc == "2")
                                            {
                                                Console.WriteLine("Escribe el nuevo número");
                                                string telefono = Console.ReadLine();
                                                bool validacion = commonLib.ValidarNumero(telefono);
                                                if (validacion == true)
                                                {
                                                    DContacts[id].Telefono = telefono;
                                                    Console.WriteLine($"El contacto con id {id} se ha actualizado con los siguientes datos {DContacts[id]}");
                                                    Console.WriteLine("Si desea seguir editando contactos presione 1, si quiere volver al menu principal presione cualquier tecla");
                                                    string salida = Console.ReadLine();
                                                    if (salida != "1")
                                                    {
                                                        break;
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("El número debe tener una longitud de 10 o 11 caracteres numéricos.");
                                                    
                                                }

                                            }

                                        }
                                        else
                                        {
                                            Console.WriteLine("El ID no se encuentra en los contactos.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("El ID no es válido.");
                                    }


                                }
                            } while (true);
                        }
                        if (opcion == 3)
                        {
                            do
                            {
                                if (DContacts.Count < 1)
                            {
                                Console.WriteLine("No hay contactos existentes");
                            }
                            else
                            {
                                Console.WriteLine("Escribe el id del contacto a eliminar");
                                Console.WriteLine("Oprima la tecla 0 para salir al menu principal");
                                foreach (KeyValuePair<int, Contacto> par in DContacts)
                                {
                                    Console.WriteLine($" Id: {par.Key} Teléfono: {par.Value.Telefono}, Nombre: {par.Value.Nombre}");
                                }
                                string value = Console.ReadLine();
                                if (value == "0") break;
                                CommonLib commonLib = new CommonLib();
                                bool esValido = commonLib.ValidarId(value, out id);
                                if (esValido)
                                {
                                    if (DContacts.ContainsKey(id))
                                    {
                                        DContacts.Remove(id);
                                        Console.WriteLine($"El contacto con id {id} se ha eliminado exitosamente");
                                        Console.WriteLine("Si desea seguir eliminando contactos presione 1, si quiere volver al menu principal presione cualquier tecla");
                                        string salida = Console.ReadLine();
                                            if (salida != "1")
                                            {
                                                break;
                                            }
                                        }
                                    else
                                    {
                                        Console.WriteLine("El id no se encuentra en los contactos existentes");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("El id no es valido");
                                }
                            }
                            } while (true);
                        }
                        if (opcion == 4)
                        {
                            do
                            {
                                if (DContacts.Count < 1)
                                {
                                    Console.WriteLine("No hay contactos existentes");
                                }
                                else
                                {
                                    Console.WriteLine("Oprima 1 para ver la lista de contactos existentes, oprima 2 para buscar por nombre y 3 para buscar por telefono");
                                    Console.WriteLine("Oprima 0 para volver al menu principal");
                                    string value = Console.ReadLine();
                                    if (value == "0") break;
                                    CommonLib commonLib = new CommonLib();
                                    if (value == "1")
                                    {
                                        foreach (KeyValuePair<int, Contacto> par in DContacts)
                                        {

                                            Console.WriteLine($" Id: {par.Key} Teléfono: {par.Value.Telefono}, Nombre: {par.Value.Nombre}");

                                        }
                                    }
                                    if (value == "2")
                                    {
                                        Console.WriteLine("Introduzca el nombre del contacto");
                                        string nombre = Console.ReadLine();
                                        bool bandera = false;
                                        foreach (var contacto in DContacts.Values)  // Recorrer solo los valores del diccionario
                                        {
                                            if (contacto.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                                            {
                                                Console.WriteLine($"El telefono del contacto con nombre {nombre} es {contacto.Telefono}");
                                                bandera = true;
                                            }

                                        }
                                        if (bandera == false)
                                            Console.WriteLine($"No se encontro ningún contacto con nombre {nombre} ");
                                            Console.WriteLine("Si desea seguir buscando contactos presione 1, si quiere volver al menu principal presione cualquier tecla");
                                            string salida = Console.ReadLine();
                                            if (salida != "1")
                                            {
                                                break;
                                            }
                                    }
                                    if (value == "3")
                                    {
                                        Console.WriteLine("Introduzca el telefono del contacto");
                                        string telefono = Console.ReadLine();
                                        bool bandera = false;
                                        foreach (var contacto in DContacts.Values)  // Recorrer solo los valores del diccionario
                                        {
                                            if (contacto.Telefono.Equals(telefono))
                                            {
                                                Console.WriteLine($"El nombre del contacto con telefono {telefono} es {contacto.Nombre}");
                                                bandera = true;
                                            }
                                        }
                                        if (bandera == false)
                                            Console.WriteLine($"No se encontro ningún contacto con nombre {telefono} ");
                                            Console.WriteLine("Si desea seguir buscando contactos presione 1, si quiere volver al menu principal presione cualquier tecla");
                                            string salida = Console.ReadLine();
                                            if (salida != "1")
                                            {
                                                break;
                                            }
                                    }


                                }
                            } while (true);
                        }
                        
                            if (opcion == 5)
                            {
                                Environment.Exit(0);
                            }

                        }else
                        {
                            Console.WriteLine("La opción debe estar entre 1 y 5.");
                        }

                    }
             else{
                        Console.WriteLine("El valor ingresado no es un número válido.");
                    }

                
            }while (true);
           

        }
    }
}
