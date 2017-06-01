using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TPP.Practicas.OrientacionObjetos.Practica2 {
    
    
    /// <summary>
    /// Clase que prueba la clase Vector
    ///</summary>
    [TestClass]
    public class VectorTest {

        /// <summary>
        /// Instancia que se utilizará en la mayoría de los tests
        /// </summary>
        private Vector vector;

        /********************** Métodos con semántica especial *********************************/

        
        /// <summary>
        /// Este método de clase (static) se llama sólo una vez antes de lanzar ningún test (una sola vez).
        /// Se utiliza para inicializar los recursos compartidos por todos los tests.
        /// Lo importante es el atributo ClassInitialize (y el parámetro). El nombre del método se puede cambiar.
        /// No es necesario declararlo si no se va a utilizar.
        /// </summary>
        [ClassInitialize]
        public static void InicializarTodosLosTests(TestContext testContext) {
        }

        /// <summary>
        /// Método que se ejecuta al comienzo de cada tests.
        /// Se utiliza para inicializar los tests (refactorizar el código repetido en todos los tests)
        /// Lo importante es el atributo TestInitialize. El nombre del método se puede cambiar.
        /// </summary>
        [TestInitialize]
        public void InicializarTests() {
            // * Creamos un vector vacío
            this.vector = new Vector();
        }

        /// <summary>
        /// Método que se llama después de la ejecución de cada test. 
        /// Se suele utilizar para liberar los recursos que hayan utilizado cada test.
        /// Lo importante es el atributo TestCleanUp. El nombre del método se puede cambiar.
        /// No es necesario declararlo si no se va a utilizar.
        /// </summary>
        [TestCleanup]
        public void LimpiarTests() {
        }

        /// <summary>
        /// Método que se llama después de la ejecución de todos los test (una sola vez). 
        /// Se suele utilizar para liberar los recursos que hayan utilizado todos los tests en conjunto.
        /// Lo importante es el atributo ClassCleanUp. El nombre del método se puede cambiar.
        /// No es necesario declararlo si no se va a utilizar.
        /// </summary>
        [ClassCleanup]
        public static void LimpiarTodosLosTests() {
        }

        /********************** Métodos de prueba *********************************/

        /// <summary>
        /// Los métodos públicos con atributo TestMethod se ejecutarán como tests unitarios
        /// </summary>
        [TestMethod]
        public void ConstructorVectorTest() {
            // * El vector ya existe porque se construye en el método InicializarTests
            // * Utilizamos los métodos de clase (static) de Assert para aseverar condiciones que
            //   deben cumplirse si el código es correcto
            Assert.AreEqual(0, this.vector.Tamaño);  // 1º Valor esperado, 2º valor real
        }

        /// <summary>
        /// Prueba el método Insertar y GetElemento
        /// </summary>
        [TestMethod]
        public void InsertarTest() {
            const int primerValor = 3, segundoValor = -8;
            this.vector.Insertar(primerValor);
            Assert.AreEqual(1, this.vector.Tamaño); 
            Assert.AreEqual(primerValor, this.vector.GetElemento(0));
            this.vector.Insertar(segundoValor);
            Assert.AreEqual(2, this.vector.Tamaño);
            Assert.AreEqual(segundoValor, this.vector.GetElemento(1));
        }

        /// <summary>
        /// Prueba el método Insertar y SetElemento
        /// </summary>
        [TestMethod]
        public void SetElementoTest() {
            this.vector.Insertar(0);
            this.vector.Insertar(2);
            const int primerValor = 3, segundoValor = -8;
            this.vector.SetElemento(0, primerValor);
            this.vector.SetElemento(1, segundoValor);
            Assert.AreEqual(primerValor, this.vector.GetElemento(0));
            Assert.AreEqual(segundoValor, this.vector.GetElemento(1));
        }

        /// <summary>
        /// Prueba de que el método GetElemento controla que accedamos fuera de rango.
        /// Nótese cómo el atributo ExpectedException obliga a que se tenga que lanzar la
        /// excepción ArgumentException para interpretar que el test sea correcto.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetElementoFueraRangoTest() {
            this.vector.GetElemento(0);
        }

        /// <summary>
        /// Prueba de que el método SetElemento controla que accedamos fuera de rango.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetElementoFueraRangoTest() {
            this.vector.Insertar(0);
            this.vector.SetElemento(1, 0);
        }

    }
}
