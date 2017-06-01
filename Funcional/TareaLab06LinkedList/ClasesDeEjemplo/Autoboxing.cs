using System;

namespace TPP.Practicas.OrientacionObjetos.Practica2 {

    class DemostraciónAutoboxingIsAs {

		private static int Autoboxing(Int32 objeto) {
			return objeto;
		}

		private static void DemoAutoboxing() {
			int i=3;
			Int32 oi=i;
			Object o=i;
            Autoboxing(3);
			Console.WriteLine(o);

            i=oi;
			Console.WriteLine(i);
            i = (int)o;
            int unbox = Autoboxing(3); 
            Console.WriteLine(i);
		}

        private static void DemoIsAs() {
            object cadena = "de caracteres";

            if (cadena is String) {
                Console.WriteLine("Longitud: {0}.", ((string)cadena).Length);
                Console.WriteLine("En mayúsculas: {0}.", ((string)cadena).ToUpper());
            }

            string comoString = cadena as string;
            if (comoString != null) {
                Console.WriteLine("Longitud: {0}.", comoString.Length);
                Console.WriteLine("En mayúsculas: {0}.", comoString.ToUpper());
            }
        }

        static void Main() {
            DemoAutoboxing();
            DemoIsAs();
        }

	}
}
