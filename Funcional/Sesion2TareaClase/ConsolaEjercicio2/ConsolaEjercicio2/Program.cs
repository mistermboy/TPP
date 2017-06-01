using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geometria;


namespace ConsolaEjercicio1
{
    public class calculosTrayectos
    {

        public static void IncrementardosDouble(ref double a, ref double b, double inc1, double inc2)
        {
            a = a + inc1;
            b = b + inc2;
        }


        public static Punto2d[] GeneraTrayecto(int longitud = 10, double xini = 0, double yini = 0, double dx = 1.0, double dy = 1.0)
        {

            Punto2d[] trayecto = new Punto2d[longitud];
            for (int i = 0; i < trayecto.Length; i++)
            {
                trayecto[i] = new Punto2d(xini, yini, Punto2d.Color.Transparente);
                IncrementardosDouble(ref xini, ref yini, dx, dy);
            }
            return trayecto;
        }


        public static void MuestraTrayecto(Punto2d[] trayecto, bool primerCuadrante = false)
        {
            string cadena = "[ ";
            if (!primerCuadrante)
            {
                cadena += trayecto[0].toStringSincolor();
                for (int i = 1; i < trayecto.Length; i++)
                {
                    cadena += "," + trayecto[i].toStringSincolor();
                }
                cadena += " ]";
            }
            else
            {
                if (trayecto[0].x >= 0 && trayecto[0].y >= 0)
                {
                    cadena += trayecto[0].toStringSincolor();
                }
                for (int i = 1; i < trayecto.Length; i++)
                {
                    if (trayecto[i].x >= 0 && trayecto[i].y >= 0)
                    {
                        cadena += "," + trayecto[i].toStringSincolor();
                    }

                }
                cadena += " ]";
            }
            Console.WriteLine(cadena);
        }


        public static double Longitud(Punto2d[] trayecto)
        {
            double distancia = 0.0;
            int ultimo = trayecto.Length - 1;
            for (int i = 0; i < trayecto.Length; i++)
            {
                if (i != ultimo)
                {
                    distancia += trayecto[i].calcularDistanciaEuclidea(trayecto[i + 1]);
                }

            }
            return distancia;
        }

        public static void longitudiniciofin(Punto2d[] t, out double longitud, out Punto2d inicio, out Punto2d fin)
        {
            longitud = Longitud(t);
            inicio = new Punto2d(t[0].x, t[0].y);
            fin = new Punto2d(t.Last().x, t.Last().y);
        }


        class Program
        {
            static void Main(string[] args)
            {
                double x = 1.0, y = 2.0, i1 = .1, i2 = .2;
                Console.WriteLine("x={0},y={1}", x, y);
                calculosTrayectos.IncrementardosDouble(ref x, ref y, i1, i2);
                Console.WriteLine("x={0},y={1}", x, y);

                Punto2d[] trayecto = calculosTrayectos.GeneraTrayecto();

                Punto2d[] trayecto2 = calculosTrayectos.GeneraTrayecto(15, -3, -4, 1, 1);

                calculosTrayectos.MuestraTrayecto(trayecto, true);
                calculosTrayectos.MuestraTrayecto(trayecto2, true);

                Console.WriteLine(calculosTrayectos.Longitud(trayecto));
                Console.WriteLine(calculosTrayectos.Longitud(trayecto2));

                Punto2d punto1 = new Punto2d(6.0, 9.0);
                Punto2d punto2 = new Punto2d(1.0, 2.0);
                double distancia = 10.0;

                Console.WriteLine(punto1.toStringSincolor());
                Console.WriteLine(punto2.toStringSincolor());

                calculosTrayectos.longitudiniciofin(trayecto, out distancia, out punto1, out punto2);

                Console.WriteLine(punto1.toStringSincolor());
                Console.WriteLine(punto2.toStringSincolor());
            }
        }
    }

}
