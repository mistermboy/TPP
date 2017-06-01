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
            Clases.LinkedList<Object> linkedList = new Clases.LinkedList<Object>();
            Console.WriteLine(linkedList.toString());

            //ADD

            //Insertar en una lista vacía
            linkedList.addFinal(8);
            Console.WriteLine(linkedList.toString());
            //Insertar a continuación
            linkedList.addFinal(9);
            Console.WriteLine(linkedList.toString());
            linkedList.addFinal(1);
            Console.WriteLine(linkedList.toString());
            linkedList.addFinal(3);
            Console.WriteLine(linkedList.toString());
            linkedList.addFinal(5);
            Console.WriteLine(linkedList.toString());
            linkedList.addFinal(7);
            Console.WriteLine(linkedList.toString());

            Console.WriteLine("*");
            Console.WriteLine(linkedList.Contiene(7));
            Console.WriteLine("*");

            //Insertar negativos
            linkedList.addFinal(-7);
            Console.WriteLine(linkedList.toString());
            linkedList.addFinal(-4);
            Console.WriteLine(linkedList.toString());


            //Añadir en una posición
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Clases.LinkedList<Object> list = new Clases.LinkedList<Object>();
            list.addFinal(55);
            list.addFinal(32);
            list.addFinal(69);
            list.addFinal(97);
            list.addFinal(37);
            list.addFinal(11);
            list.addFinal(6);

            Console.WriteLine(list.toString());

            list.addPosicion(0, 0);
            Console.WriteLine(list.toString());
            list.addPosicion(1, 1);
            list.addPosicion(2, 2);
            list.addPosicion(3, 3);
            list.addPosicion(4, 4);
            list.addPosicion(5, 5);
            list.addPosicion(6, 6);

            Console.WriteLine(list.toString());

            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");

            //LINKED OBJECT

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("------------------------------------------");

            Clases.LinkedList<Object> linkedObject = new Clases.LinkedList<Object>();

            Console.WriteLine(linkedObject.toString());
            linkedObject.addFinal("Hola Mundo");
            linkedObject.addFinal(6.9);
            Clases.Persona pablo = new Clases.Persona("Pablo", "Menéndez", "Suárez", "71899158P");
            linkedObject.addFinal(pablo);

            Console.WriteLine(linkedObject.toString());
            linkedObject.remove("Hola Mundo");
            linkedObject.remove(pablo);
            Console.WriteLine(linkedObject.toString());

            Console.WriteLine("------------------------------------------");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("------------------------------------------");



            //GET

            //Devolver el primer elemento de la lista
            Console.WriteLine(linkedList.getElemento(0));
            //Devolver el último elemento de la lista
            Console.WriteLine(linkedList.getElemento(7));
            //Devolver cualquier elemento de la lista
            Console.WriteLine(linkedList.getElemento(3));

            //Introducir un índice inválido
            try
            {
                linkedList.getElemento(-3);
            }
            catch (ArgumentException a)
            {
                Console.WriteLine("Parámetro incorrecto", a);
            }

            try
            {
                linkedList.getElemento(333);
            }
            catch (ArgumentException a)
            {
                Console.WriteLine("Parámetro incorrecto", a);
            }


            //REMOVE

            //Borrar el primero de la lista
            linkedList.remove(8);
            Console.WriteLine(linkedList.toString());
            // Console.WriteLine(linkedList.toString());
            //Borrar el último de la lista
            linkedList.remove(7);
            Console.WriteLine(linkedList.toString());
            //Borrar cualquiera de la lista
            linkedList.remove(3);
            Console.WriteLine(linkedList.toString());
            linkedList.remove(1);
            Console.WriteLine(linkedList.toString());
            linkedList.remove(9);
            Console.WriteLine(linkedList.toString());
            linkedList.remove(5);
            Console.WriteLine(linkedList.toString());
            //Dejar la lista vacía
            Console.WriteLine(linkedList.toString());
            linkedList.remove(-7);
            Console.WriteLine(linkedList.toString());
            linkedList.remove(-4);
            Console.WriteLine(linkedList.toString());

            Console.WriteLine("*");
            Console.WriteLine(linkedList.Contiene(-4));
            Console.WriteLine("*");

            //Borrar un elemento inexistente
            try
            {
                linkedList.remove(-69);
                Console.WriteLine(linkedList.toString());
            }
            catch (ArgumentException a)
            {
                Console.WriteLine("Elemento inexistente", a);
            }

            Console.WriteLine("Última ejecución");
        }
    }
}
