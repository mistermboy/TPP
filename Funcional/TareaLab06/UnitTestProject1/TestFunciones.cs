using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Clases;
using System.Collections;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class TestFunciones
    {
        [TestMethod]
        public void TestBuscar()
        {
            var person = new Persona("María", "Díaz", "Rodríguez", "9876384A");
            var person1 = new Persona("Ana", "Díaz", "Rodríguez", "9876384A");
            var person2 = new Persona("Melisa", "Díaz", "Rodríguez", "9876384A");
            var person3 = new Persona("Julia", "Díaz", "Rodríguez", "9876384A");
            var person4 = new Persona("Isabel", "Díaz", "Rodríguez", "9876384A");
            var person5 = new Persona("Carmen", "Díaz", "Rodríguez", "9876384A");
            var person6 = new Persona("Inés", "Díaz", "Rodríguez", "9876384A");
            var person7 = new Persona("Niki", "Díaz", "Rodríguez", "9876384A");

            Persona[] personas = new Persona[] { person, person1, person2, person3, person4, person5, person6, person7 };

            //Pruebas para buscar a la primera persona que su nombre acabe por una determinada letra

            Assert.AreEqual(person, personas.Buscar(n => n.Nombre.Last() == 'a'));
            Assert.AreEqual(person5, personas.Buscar(n => n.Nombre.Last() == 'n'));
            Assert.AreEqual(person7, personas.Buscar(n => n.Nombre.Last() == 'i'));


            var ang = new Angulo((float)90);
            var ang1 = new Angulo((float)30);
            var ang2 = new Angulo((float)60);
            var ang3 = new Angulo((float)40);
            var ang4 = new Angulo((float)180);

            var angulos = new Angulo[] { ang, ang1, ang2, ang3, ang4 };

            //Pruebas para buscar el primer ángulo recto
            Assert.AreEqual(ang, angulos.Buscar(n => n.Grados == 90));
            //Preubas para buscar el primer ángulo dentro de un cuadrante concreto
            Assert.AreEqual(ang, angulos.Buscar(n => n.Grados >= 0 && n.Grados <= 90));
            Assert.AreEqual(ang4, angulos.Buscar(n => n.Grados > 90 && n.Grados <= 180));
        }

        [TestMethod]
        public void TestFiltrar()
        {          
            var person = new Persona("María", "Díaz", "Rodríguez", "9876384A");
            var person1 = new Persona("Ana", "Díaz", "Rodríguez", "9876384A");
            var person2 = new Persona("Melisa", "Díaz", "Rodríguez", "9876384A");
            var person3 = new Persona("Julia", "Díaz", "Rodríguez", "9876384A");
            var person4 = new Persona("Isabel", "Díaz", "Rodríguez", "9876384A");
            var person5 = new Persona("Carmen", "Díaz", "Rodríguez", "9876384A");
            var person6 = new Persona("Inés", "Díaz", "Rodríguez", "9876384A");
            var person7 = new Persona("Niki", "Díaz", "Rodríguez", "9876384A");

            Persona[] personas = new Persona[] { person, person1, person2, person3, person4, person5, person6, person7 };

            //Pruebas para filtrar las personas que se llamen Julia

            var m = personas.Filtrar(n => n.Nombre == "Julia");

            Assert.IsTrue(m.Contains(person3));
            Assert.IsFalse(m.Contains(person1));
            Assert.IsFalse(m.Contains(person2));
            Assert.IsFalse(m.Contains(person4));
            Assert.IsFalse(m.Contains(person5));
            Assert.IsFalse(m.Contains(person6));
            Assert.IsFalse(m.Contains(person7));
            Assert.IsFalse(m.Contains(person));

            Assert.IsTrue(m.Count() == 1);

            //Pruebas para filtrar las personas que su nombre acabe por 'a'

            var l = personas.Filtrar(n => n.Nombre.Last() == 'a');

            Assert.IsTrue(l.Contains(person3));
            Assert.IsTrue(l.Contains(person));
            Assert.IsTrue(l.Contains(person1));
            Assert.IsTrue(l.Contains(person2));
            Assert.IsFalse(l.Contains(person4));
            Assert.IsFalse(l.Contains(person5));
            Assert.IsFalse(l.Contains(person6));
            Assert.IsFalse(l.Contains(person7));
            
            Assert.IsTrue(l.Count() == 4);


            var ang = new Angulo((float)90);
            var ang1 = new Angulo((float)30);
            var ang2= new Angulo((float)60);
            var ang3 = new Angulo((float)40);
            var ang4 = new Angulo((float)180);

            var angulos = new Angulo[] { ang, ang1, ang2, ang3, ang4 };

            //Pruebas para filtrar ángulos rectos

            var x = angulos.Filtrar(n => n.Grados == 90);

            Assert.IsTrue(x.Contains(ang));
            Assert.IsFalse(x.Contains(ang1));
            Assert.IsFalse(x.Contains(ang2));
            Assert.IsFalse(x.Contains(ang4));
            Assert.IsFalse(x.Contains(ang3));

            Assert.IsTrue(x.Count() == 1);


            //Preubas para filtrar ángulos en el primer cuadrante

            var y = angulos.Filtrar(n => n.Grados >= 0 && n.Grados <= 90);

            Assert.IsTrue(y.Contains(ang));
            Assert.IsTrue(y.Contains(ang1));
            Assert.IsTrue(y.Contains(ang2));
            Assert.IsTrue(y.Contains(ang3));
            Assert.IsFalse(y.Contains(ang4));

            Assert.IsTrue(y.Count() == 4);
        }

        [TestMethod]
        public void TestReducir()
        {

            var ang = new Angulo((float)90);
            var ang1 = new Angulo((float)30);
            var ang2 = new Angulo((float)60);
            var ang3 = new Angulo((float)40);
            var ang4 = new Angulo((float)180);

            var angulos = new Angulo[] { ang, ang1, ang2, ang3, ang4 };

            //Pruebas para calcular la suma de todos los grados de los ángulos
            Assert.AreEqual(400, angulos.Sum(n => n.Grados));
            //Pruebas para calcular el seno máximo
            Assert.AreEqual(1, angulos.Max(n => n.Seno()));
            //Pruebas para conseguir el ángulo con más grados
            Assert.AreEqual(180, angulos.Max(n => n.Grados));

            var person = new Persona("María", "Díaz", "Rodríguez", "9876384A");
            var person1 = new Persona("Ana", "Díaz", "Rodríguez", "9876384A");
            var person2 = new Persona("Melisa", "Díaz", "Rodríguez", "9876384A");
            var person3 = new Persona("Julia", "Díaz", "Rodríguez", "9876384A");
            var person4 = new Persona("Isabel", "Díaz", "Rodríguez", "9876384A");
            var person5 = new Persona("Carmen", "Díaz", "Rodríguez", "9876384A");
            var person6 = new Persona("Inés", "Díaz", "Rodríguez", "9876384A");
            var person7 = new Persona("Niki", "Díaz", "Rodríguez", "9876384A");

            Persona[] personas = new Persona[] { person, person1, person2, person3, person4, person5, person6, person7 };

            //Pruebas para saber el número de personas que se llaman 'Ana'
            Assert.AreEqual(1, personas.Aggregate<Persona, int>(0, (sum, n) => { if (n.Nombre == "Ana") sum++; return sum; }));

            //Pruebas para saber el número de personas que se apellidan 'Díaz'
            Assert.AreEqual(8, personas.Aggregate<Persona, int>(0, (sum, n) => { if (n.Apellido1 == "Díaz") sum++; return sum; }));

        }


        [TestMethod]
        public void TestMap()
        {

            var person = new Persona("María", "Díaz", "Rodríguez", "9876384A");
            var person1 = new Persona("Ana", "Díaz", "Rodríguez", "9876384A");
            var person2 = new Persona("Melisa", "Díaz", "Rodríguez", "9876384A");

            Persona[] personas = new Persona[] { person, person1, person2};

            string str = "MaríaDíaz";
            string str1 = "AnaDíaz";
            string str2 = "MelisaDíaz";

            var x = personas.Map(n => n.Nombre + n.Apellido1);

            //Pruebas para obtener los "apellidos, nombre" (como un único string) de cada una de las personas de la lista
            Assert.IsTrue(x.Contains(str));
            Assert.IsTrue(x.Contains(str1));
            Assert.IsTrue(x.Contains(str2));


            var ang = new Angulo((float)90);
            var ang1 = new Angulo((float)30);
            var ang2 = new Angulo((float)60);
            var ang3 = new Angulo((float)40);
            var ang4 = new Angulo((float)180);

            var angulos = new Angulo[] { ang, ang1, ang2, ang3, ang4 };

            var y = angulos.Map((n) => {
                if (n.Grados >= 0 && n.Grados <= 90) return "Primer Cuadrante";
                if (n.Grados > 90 && n.Grados <= 180) return "Segundo Cuadrante";
                if (n.Grados > 180 && n.Grados <= 270) return "Tercer Cuadrante";
                if (n.Grados > 270 && n.Grados <= 360) return "Cuarto Cuadrante";
                return "";
            });

            Assert.IsTrue(y.Contains("Primer Cuadrante"));
            Assert.IsTrue(y.Contains("Segundo Cuadrante"));
            Assert.IsFalse(y.Contains("Tercer Cuadrante"));
            Assert.IsFalse(y.Contains("Cuarto Cuadrante"));

        }
    }
}
