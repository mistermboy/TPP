using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class ListTest
    {
        /*
          * Pruebas para el método AddFinal de la clase List
         */
        [TestMethod]
        public void TestAddPrincipo()
        {
            Clases.List linkedList = new Clases.List();

            Assert.AreEqual(0, linkedList.numberOfElements);

            linkedList.AddFinal(55);
            linkedList.AddFinal(32);
            linkedList.AddFinal(69);
            linkedList.AddFinal(97);
            linkedList.AddFinal(37);
            linkedList.AddFinal(11);
            linkedList.AddFinal(13);

            Assert.AreEqual(7, linkedList.numberOfElements);

            linkedList.AddPrincipio(5);
            Assert.AreEqual(8, linkedList.numberOfElements);
            Assert.AreEqual(5, linkedList.GetElemento(0));

            linkedList.AddPrincipio(4);
            Assert.AreEqual(9, linkedList.numberOfElements);
            Assert.AreEqual(4, linkedList.GetElemento(0));
            Assert.AreEqual(5, linkedList.GetElemento(1));

            linkedList.AddPrincipio(3);
            Assert.AreEqual(10, linkedList.numberOfElements);
            Assert.AreEqual(3, linkedList.GetElemento(0));
            Assert.AreEqual(5, linkedList.GetElemento(2));
            Assert.AreEqual(4, linkedList.GetElemento(1));

            linkedList.AddPrincipio(2);
            Assert.AreEqual(11, linkedList.numberOfElements);
            Assert.AreEqual(2, linkedList.GetElemento(0));
            Assert.AreEqual(5, linkedList.GetElemento(3));
            Assert.AreEqual(4, linkedList.GetElemento(2));
            Assert.AreEqual(3, linkedList.GetElemento(1));

            linkedList.AddPrincipio(1);
            Assert.AreEqual(12, linkedList.numberOfElements);
            Assert.AreEqual(1, linkedList.GetElemento(0));
            Assert.AreEqual(5, linkedList.GetElemento(4));
            Assert.AreEqual(4, linkedList.GetElemento(3));
            Assert.AreEqual(3, linkedList.GetElemento(2));
            Assert.AreEqual(2, linkedList.GetElemento(1));

            linkedList.AddPrincipio(0);
            Assert.AreEqual(13, linkedList.numberOfElements);
            Assert.AreEqual(0, linkedList.GetElemento(0));
            Assert.AreEqual(5, linkedList.GetElemento(5));
            Assert.AreEqual(4, linkedList.GetElemento(4));
            Assert.AreEqual(3, linkedList.GetElemento(3));
            Assert.AreEqual(2, linkedList.GetElemento(2));
            Assert.AreEqual(1, linkedList.GetElemento(1));

        }


        /*
          * Pruebas para el método AddFinal de la clase LinkedList
         */
        [TestMethod]
        public void TestAddFinal()
        {
            Clases.List linkedList = new Clases.List();

            //PRUEBAS POSITIVAS

            //Añadir un elemento en una lista vacía
            linkedList.AddFinal(6);
            Assert.AreEqual(6, linkedList.GetElemento(0));

            //Añadir un elemento al final de una lista
            Clases.Persona pablo = new Clases.Persona("Pablo", "Menéndez", "Suárez", "71899158P");
            linkedList.AddFinal(pablo);
            Assert.AreEqual(pablo, linkedList.GetElemento(1));

            double d = 6.9;
            linkedList.AddFinal(d);
            Assert.AreEqual(d, linkedList.GetElemento(2));

            //PRUEBAS NEGATIVAS

            Assert.AreNotEqual(pablo, linkedList.GetElemento(2));
            Assert.AreNotEqual(d, linkedList.GetElemento(0));
            Assert.AreNotEqual(6, linkedList.GetElemento(1));

        }

        /*
         * Pruebas para el método AddPosicion de la clase LinkedList
        */
        [TestMethod]
        public void TestAddPosicion()
        {
            Clases.List list = new Clases.List();

            //PRUEBAS POSITIVAS


            list.AddFinal(55);
            list.AddFinal(32);
            list.AddFinal(69);
            list.AddFinal(97);
            list.AddFinal(37);
            list.AddFinal(11);
            list.AddFinal(13);

            //Añadir un elemento en una posición cualquiera
            Assert.AreEqual(55, list.GetElemento(0));

            list.AddPosicion(0, 0);
            list.AddPosicion(1, 1);
            list.AddPosicion(2, 2);
            list.AddPosicion(3, 3);
            list.AddPosicion(4, 4);
            list.AddPosicion(5, 5);
            list.AddPosicion(6, 6);

            Assert.AreEqual(0, list.GetElemento(0));
            Assert.AreEqual(1, list.GetElemento(1));
            Assert.AreEqual(2, list.GetElemento(2));
            Assert.AreEqual(3, list.GetElemento(3));
            Assert.AreEqual(4, list.GetElemento(4));
            Assert.AreEqual(5, list.GetElemento(5));
            Assert.AreEqual(6, list.GetElemento(6));

            Assert.AreEqual(55, list.GetElemento(7));
            Assert.AreEqual(32, list.GetElemento(8));
            Assert.AreEqual(69, list.GetElemento(9));
            Assert.AreEqual(97, list.GetElemento(10));
            Assert.AreEqual(37, list.GetElemento(11));
            Assert.AreEqual(11, list.GetElemento(12));
            Assert.AreEqual(13, list.GetElemento(13));


            Clases.List list1 = new Clases.List();

            list1.AddFinal(55);
            list1.AddFinal(32);
            list1.AddFinal(69);
            list1.AddFinal(97);
            list1.AddFinal(37);
            list1.AddFinal(11);
            list1.AddFinal(13);

            list1.AddPosicion(3, 66);

            Assert.AreEqual(55, list1.GetElemento(0));
            Assert.AreEqual(32, list1.GetElemento(1));
            Assert.AreEqual(69, list1.GetElemento(2));
            Assert.AreEqual(66, list1.GetElemento(3));
            Assert.AreEqual(97, list1.GetElemento(4));
            Assert.AreEqual(37, list1.GetElemento(5));
            Assert.AreEqual(11, list1.GetElemento(6));
            Assert.AreEqual(13, list1.GetElemento(7));


        }


        /*
        * Pruebas para el método remove de la clase LinkedList
       */
        [TestMethod]
        public void TestRemove()
        {
            Clases.List linkedList = new Clases.List();


            //Borrar el único elemento de la lista
            linkedList.AddFinal(6);
            Assert.IsFalse(linkedList.IsEmpty());
            Assert.AreEqual(6, linkedList.Remove(6));
            Assert.IsTrue(linkedList.IsEmpty());

            //Borrar elementos de la lista
            linkedList.AddFinal(6);
            linkedList.AddFinal(7);
            linkedList.AddFinal(8);
            linkedList.AddFinal(9);
            linkedList.AddFinal(10);


            Assert.AreEqual(6, linkedList.GetElemento(0));
            Assert.AreEqual(7, linkedList.GetElemento(1));
            Assert.AreEqual(8, linkedList.GetElemento(2));
            Assert.AreEqual(9, linkedList.GetElemento(3));
            Assert.AreEqual(10, linkedList.GetElemento(4));

            Assert.AreEqual(9, linkedList.Remove(9));

            Assert.AreEqual(6, linkedList.GetElemento(0));
            Assert.AreEqual(7, linkedList.GetElemento(1));
            Assert.AreEqual(8, linkedList.GetElemento(2));
            Assert.AreEqual(10, linkedList.GetElemento(3));

            //Borrar el último elemento de la lista

            Assert.AreEqual(10, linkedList.Remove(10));

            Assert.AreEqual(6, linkedList.GetElemento(0));
            Assert.AreEqual(7, linkedList.GetElemento(1));
            Assert.AreEqual(8, linkedList.GetElemento(2));

        }

        /*
         * Pruebas para el método contiene de la clase LinkedList
        */
        [TestMethod]
        public void TestContiene()
        {
            Clases.List linkedList = new Clases.List();

            linkedList.AddFinal(6);
            linkedList.AddFinal(7);
            linkedList.AddFinal(8);
            linkedList.AddFinal(9);
            linkedList.AddFinal(10);

            //Comprobar que los objetos se encuentran en la lista
            Assert.IsTrue(linkedList.Contiene(6));
            Assert.IsTrue(linkedList.Contiene(7));
            Assert.IsTrue(linkedList.Contiene(8));
            Assert.IsTrue(linkedList.Contiene(9));
            Assert.IsTrue(linkedList.Contiene(10));

            //Comprobar que los objetos no se encuentran en la lista
            Assert.IsFalse(linkedList.Contiene(1));
            Assert.IsFalse(linkedList.Contiene(2));
            Assert.IsFalse(linkedList.Contiene(3));
            Assert.IsFalse(linkedList.Contiene(4));
            Assert.IsFalse(linkedList.Contiene(5));
        }
    }
    }
