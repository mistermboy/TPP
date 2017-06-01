using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Clases.List linkedList = new Clases.List();
            Console.WriteLine(linkedList.ToString());

            //ADD

            //Insertar en una lista vacía
            linkedList.AddFinal(8);
            Console.WriteLine(linkedList.ToString());
            //Insertar a continuación
            linkedList.AddFinal(9);
            Console.WriteLine(linkedList.ToString());
            linkedList.AddFinal(1);
            Console.WriteLine(linkedList.ToString());
            linkedList.AddFinal(3);
            Console.WriteLine(linkedList.ToString());
            linkedList.AddFinal(5);
            Console.WriteLine(linkedList.ToString());
            linkedList.AddFinal(7);
            Console.WriteLine(linkedList.ToString());

            Console.WriteLine("*");
            Console.WriteLine(linkedList.Contiene(7));
            Console.WriteLine("*");

            //Insertar negativos
            linkedList.AddFinal(-7);
            Console.WriteLine(linkedList.ToString());
            linkedList.AddFinal(-4);
            Console.WriteLine(linkedList.ToString());


            //Añadir en una posición
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Clases.List list = new Clases.List();
            list.AddFinal(55);
            list.AddFinal(32);
            list.AddFinal(69);
            list.AddFinal(97);
            list.AddFinal(37);
            list.AddFinal(11);
            list.AddFinal(6);

            Console.WriteLine(list.ToString());

            list.AddPosicion(0, 0);
            Console.WriteLine(list.ToString());
            list.AddPosicion(1, 1);
            list.AddPosicion(2, 2);
            list.AddPosicion(3, 3);
            list.AddPosicion(4, 4);
            list.AddPosicion(5, 5);
            list.AddPosicion(6, 6);

            Console.WriteLine(list.ToString());

            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");

            //LINKED OBJECT

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("------------------------------------------");

            Clases.List linkedObject = new Clases.List();

            Console.WriteLine(linkedObject.ToString());
            linkedObject.AddFinal("Hola Mundo");
            linkedObject.AddFinal(6.9);
            Clases.Persona pablo = new Clases.Persona("Pablo", "Menéndez", "Suárez", "71899158P");
            linkedObject.AddFinal(pablo);

            Console.WriteLine(linkedObject.ToString());
            linkedObject.Remove("Hola Mundo");
            linkedObject.Remove(pablo);
            Console.WriteLine(linkedObject.ToString());

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("------------------------------------------");



            //GET

            //Devolver el primer elemento de la lista
            Console.WriteLine(linkedList.GetElemento(0));
            //Devolver el último elemento de la lista
            Console.WriteLine(linkedList.GetElemento(7));
            //Devolver cualquier elemento de la lista
            Console.WriteLine(linkedList.GetElemento(3));

            //Introducir un índice inválido
            try
            {
                linkedList.GetElemento(-3);
            }
            catch (ArgumentException a)
            {
                Console.WriteLine("Parámetro incorrecto", a);
            }

            try
            {
                linkedList.GetElemento(333);
            }
            catch (ArgumentException a)
            {
                Console.WriteLine("Parámetro incorrecto", a);
            }


            //REMOVE

            //Borrar el primero de la lista
            linkedList.Remove(8);
            Console.WriteLine(linkedList.ToString());
            // Console.WriteLine(linkedList.ToString());
            //Borrar el último de la lista
            linkedList.Remove(7);
            Console.WriteLine(linkedList.ToString());
            //Borrar cualquiera de la lista
            linkedList.Remove(3);
            Console.WriteLine(linkedList.ToString());
            linkedList.Remove(1);
            Console.WriteLine(linkedList.ToString());
            linkedList.Remove(9);
            Console.WriteLine(linkedList.ToString());
            linkedList.Remove(5);
            Console.WriteLine(linkedList.ToString());
            //Dejar la lista vacía
            Console.WriteLine(linkedList.ToString());
            linkedList.Remove(-7);
            Console.WriteLine(linkedList.ToString());
            linkedList.Remove(-4);
            Console.WriteLine(linkedList.ToString());

            Console.WriteLine("*");
            Console.WriteLine(linkedList.Contiene(-4));
            Console.WriteLine("*");

            //Borrar un elemento inexistente
            try
            {
                linkedList.Remove(-69);
                Console.WriteLine(linkedList.ToString());
            }
            catch (ArgumentException a)
            {
                Console.WriteLine("Elemento inexistente", a);
            }

            Console.WriteLine("Última ejecución");


            //ADD INICIO

            Clases.List list2 = new Clases.List();

            list2.AddFinal(1);
            list2.AddFinal(2);
            list2.AddFinal(3);
            list2.AddFinal(4);
            list2.AddFinal(5);

            Console.WriteLine(list2.ToString());

            list2.AddPrincipio(0);

            Console.WriteLine(list2.ToString());

            list2.AddPrincipio(-1);

            Console.WriteLine(list2.ToString());

            list2.AddPrincipio(-2);

            Console.WriteLine(list2.ToString());
        }
    }
}
