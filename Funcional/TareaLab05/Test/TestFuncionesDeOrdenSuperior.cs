using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases;
using System.Linq;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class TestFuncionesDeOrdenSuperior
    {
        [TestMethod]
        public void TestBuscar()
        {
            Factoria fac = new Factoria();
            Persona[] personas = fac.CrearPersonas();
            Persona[] persons= new Persona[1];
            Angulo[] angulos = fac.CrearAngulos();

   

            Persona persona = new Persona("María", "Díaz", "Rodríguez", "9876384A");
            Angulo angulo = new Angulo((float)90);
            Angulo angulo2 = new Angulo((float)150);


            Predicate<Persona> predicate =  (p) => p.Nombre == "María";
            Predicate<Persona> predNif = (p) => p.Nif.Last() == 'A';
            Predicate<Angulo> pred = (a) => a.Grados == 90;
            Predicate<Angulo> pred2 = (a) => a.Grados == 150;

            Assert.AreEqual(persona.Nombre, personas.Buscar<Persona>(predicate).Nombre);
            Assert.AreEqual(persona.Nif, personas.Buscar<Persona>(predNif).Nif);
            Assert.AreEqual(angulo.Grados, angulos.Buscar<Angulo>(pred).Grados);
            Assert.AreEqual(angulo2.Grados, angulos.Buscar<Angulo>(pred2).Grados);


        }

        [TestMethod]
        public void TestFiltrar()
        {
            Factoria fac = new Factoria();
            Persona[] personas = fac.CrearPersonas();
            Angulo[] angulos = fac.CrearAngulos();

            Persona persona1 = new Persona("María", "Díaz", "Rodríguez", "9876384A");
            Persona persona2 = new Persona("María", "Díaz", "Hevia", "87666354D");
            Angulo angulo = new Angulo((float)90);
            Angulo angulo2 = new Angulo((float)150);

            Predicate<Persona> predicate = (p) => p.Nombre == "María";
            Predicate<Angulo> pred = (a) => a.Grados == 90;
            Predicate<Angulo> pred2 = (a) => a.Grados == 150;

            var listPer = personas.Filtrar<Persona>(predicate).ToArray();
            var listAng1 = angulos.Filtrar<Angulo>(pred).ToArray();
            var listAng2 = angulos.Filtrar<Angulo>(pred2).ToArray();

            Assert.IsTrue(listPer[0].Nombre.Equals(persona1.Nombre));
            Assert.IsTrue(listPer[1].Nombre.Equals(persona2.Nombre));

            Assert.IsTrue(listAng1[0].Grados.Equals(angulo.Grados));
            Assert.IsTrue(listAng2[0].Grados.Equals(angulo2.Grados));



        }

        [TestMethod]
        public void TestReducir()
        {
            FuncionesDeOrdenSuperior f = new FuncionesDeOrdenSuperior();
            Factoria fac = new Factoria();
            Persona[] personas = fac.CrearPersonas();
            Angulo[] angulos = fac.CrearAngulos();



            Assert.AreEqual(64980, angulos.Sum(currentElement => currentElement.Grados));


            Dictionary<string, int> dictOfNameFrecuency = personas.Aggregate(new Dictionary<string, int>(), (dictSoFar, currentClient) => {
                if (dictSoFar.ContainsKey(currentClient.Nombre))
                    dictSoFar[currentClient.Nombre]++;
                else dictSoFar[currentClient.Nombre] = 1;
                return dictSoFar;
            });


        }
    }
}
