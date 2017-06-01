using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Diagnostics;


namespace TPP.Practicas.Concurrente.Practica3 {

    class Program {

        static void Main() {
            Stopwatch crono = new Stopwatch();
            crono.Start();
            string[] ficheros = Directory.GetFiles(@"..\..\..\pics", "*.jpg");
            string nuevoDirectorio = @"..\..\..\pics\rotadas";
            Directory.CreateDirectory(nuevoDirectorio);
            foreach (string fichero in ficheros) {
                string nombreFichero = Path.GetFileName(fichero);
                using (Bitmap bitmap = new Bitmap(fichero)) {
                    Console.WriteLine("Procesando el fichero {0}.", nombreFichero);
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(Path.Combine(nuevoDirectorio, nombreFichero));
                }
            }
            crono.Stop();
            Console.WriteLine("Ejecutado en {0:N} milisegundos.", crono.ElapsedMilliseconds);
        }
    }

}
