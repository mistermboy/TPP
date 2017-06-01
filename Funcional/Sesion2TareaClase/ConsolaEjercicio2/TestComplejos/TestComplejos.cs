using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestComplejos
{
    [TestClass]
    public class TestComplejos
    {
        [TestMethod]
        public void TestModulo()
        {
            Complejo unComplejo = new Complejo(1.0, 1.0);
            Assert.AreEqual(Math.Sqrt(2.0), unComplejo.Modulo());
        }
        //[TestMethod]
        //public void TestConjugado()
        //{
        //    Complejo unComplejo = new Complejo(1.0, 1.0),
        //             valorEsperado = new Complejo(1.0, -1.0),
        //             valorObtenido;
        //    valorObtenido = unComplejo.Conjugado();
        //    Assert.AreEqual(valorEsperado.R, unComplejo.Conjugado().R);
        //    Assert.AreEqual(valorEsperado.I, unComplejo.Conjugado().I);
        //}
        //[TestMethod]
        //public void TestOpSuma()
        //{
        //    Complejo unComplejo = new Complejo(1.0, 1.0),
        //             otroComplejo = new Complejo(2.0, 3.0),
        //             valorEsperado = new Complejo(3.0, 4.0),
        //             valorObtenido;
        //    valorObtenido = unComplejo + otroComplejo;
        //    Assert.AreEqual(valorEsperado.R, valorObtenido.R);
        //    Assert.AreEqual(valorEsperado.I, valorObtenido.I);
        //}
        //[TestMethod]
        //public void TestSuma()
        //{
        //    Complejo unComplejo = new Complejo(1.0, 1.0),
        //             otroComplejo = new Complejo(2.0, 3.0),
        //             valorEsperado = new Complejo(3.0, 4.0),
        //             valorObtenido;
        //    valorObtenido = unComplejo.Suma(otroComplejo);
        //    Assert.AreEqual(valorEsperado.R, valorObtenido.R);
        //    Assert.AreEqual(valorEsperado.I, valorObtenido.I);
        //}
        ////este lo he añadido para comprobar las propiedades
        //[TestMethod]
        //public void TestPropiedades()
        //{
        //    Complejo unComplejo = new Complejo(1.0, 2.0), otroComplejo = new Complejo();
        //    otroComplejo.R = 1.0;
        //    otroComplejo.I = 2.0;
        //    Assert.AreEqual(unComplejo.R, otroComplejo.R);
        //    Assert.AreEqual(unComplejo.I, otroComplejo.I);
        //}

        //COMENTAR CTR-K-C  
    }
    }
