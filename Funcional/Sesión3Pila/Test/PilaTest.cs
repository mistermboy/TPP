using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{

    [TestClass]
    public class PilaTest
    {
        [TestMethod]
        public void testPila()
        {
            //Creamos una pila corriente
            Clases.Pila pila = new Clases.Pila(10);

            //Intentamos crear una pila con un número máximo de elementos negativo
            try
            {
                Clases.Pila pila2 = new Clases.Pila(-69);
            }
            catch (ArgumentException) { }
        }


        [TestMethod]
        public void testPush()
        {
            Clases.Pila pila = new Clases.Pila(10);

            //Comprobamos que la pilla está vacía y no está llena
            Assert.IsTrue(pila.Vacia());
            Assert.IsFalse(pila.Llena());
            //Añadimos elementos hasta llenar la pila y comprobamos que no está vacía y que está llena
            for (int i=0;i<10;i++)
            {
                pila.Push(i);
            }

            Assert.IsTrue(pila.Llena());
            Assert.IsFalse(pila.Vacia());

            //Intentamos añadir un objeto null en la pila
            try
            {
                pila.Push(null);
            }
            catch (ArgumentException) { }

            //Intentamos aññadir un elemento más cuando la pila ya está llena
            try
            {
                pila.Push(16);
            }
            catch (InvalidOperationException) { }

        }

        [TestMethod]
        public void testPop()
        {
            Clases.Pila pila = new Clases.Pila(10);

            //Comprobamos que no podemos sacar un elemento cuando la pila está vacía
            Assert.IsTrue(pila.Vacia());
            Assert.IsFalse(pila.Llena());

            try
            {
                pila.Pop();
            }
            catch (InvalidOperationException) { }

            //LLenamos la pila y luego vamos sacando los elementos de uno en uno
            for (int i = 0; i < 10; i++)
            {
                pila.Push(i);
            }
            Assert.IsFalse(pila.Vacia());
            Assert.IsTrue(pila.Llena());

            Assert.AreEqual(9, pila.Pop());
            Assert.AreEqual(8, pila.Pop());
            Assert.AreEqual(7, pila.Pop());
            Assert.AreEqual(6, pila.Pop());
            Assert.AreEqual(5, pila.Pop());
            Assert.AreEqual(4, pila.Pop());
            Assert.AreEqual(3, pila.Pop());
            Assert.AreEqual(2, pila.Pop());
            Assert.AreEqual(1, pila.Pop());
            Assert.AreEqual(0, pila.Pop());

            Assert.IsTrue(pila.Vacia());
            Assert.IsFalse(pila.Llena());
        }
    }
}
