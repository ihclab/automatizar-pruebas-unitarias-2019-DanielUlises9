using System;
using System.IO;
using System.Threading;

namespace AutomatizarPruebasUnitarias {
    class Program {
        static string data;
        static string myPath =Directory.GetCurrentDirectory();
        static double truncate(double d, int decimals) {
            return (Math.Truncate(d * Math.Pow(10, decimals)) / Math.Pow(10, decimals));
        }
        static void elTruncador(double nuevo, double viejo) {
            nuevo = truncate(nuevo, 4);
            viejo = truncate(viejo, 4);
            exitoOfalla(nuevo, viejo);
        }
        static void milisecondsP(long reb) {
            Console.WriteLine("Milisegundos: " + Convert.ToDouble(reb) / 10000d);
        }
        static int[] ConvertirNumeros(string[] vec, int size) {
            int[] numeros = new int[size];
            int cresco = 0;
            foreach (var item in vec) {
                numeros[cresco] = Convert.ToInt32(item);
                cresco++;
            }
            return numeros;
        }
        static void exitoOfalla(double nuevo, double viejo) {
            if (nuevo == viejo) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Exito \n\r" + "Resultado viejo: " + viejo + "\n\r VS \n\r"
        + "Resultado Nuevo: " + nuevo);
                Console.ResetColor();
                data+="Exito \n\r" + "Resultado viejo: " + viejo + "\n\r VS \n\r"
        + "Resultado Nuevo: " + nuevo + "\n\r";
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fallo \n\r" + "Resultado viejo: " + viejo + "\n\r VS \n\r"
                + "Resultado Nuevo: " + nuevo);
                Console.ResetColor();
                data+="Fallo \n\r" + "Resultado viejo: " + viejo + "\n\r VS \n\r"
                + "Resultado Nuevo: " + nuevo + "\n\r";
            }
        }
        static void crearArchivo(string datos){
            System.IO.File.WriteAllText(myPath + "'\\'ResultadosDePruebas.txt",datos);
        }

        static void Main(string[] args) {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            watch.Stop();
            watch.Reset();
            Medias mediasObj = new Medias();
            string[] lineas = File.ReadAllLines("CasosPrueba.txt");
            string[,] casos = new string[lineas.Length, 4];
            for (int i = 0; i < lineas.Length; i++) {
                string[] linea = lineas[i].Split(':');
                for (int j = 0; j < linea.Length; j++) {
                    casos[i, j] = linea[j];
                    System.Console.WriteLine(casos[i, j]);
                    data += casos[i,j] + ":";
                }
                try {
                    if (linea[2] != "NULL") {
                        //double prueba = 2.222222222d;
                        double resultadoViejo = Convert.ToDouble(linea[3]);
                        string[] lineaNumeros = linea[2].Split(' ');
                        switch (linea[1]) {
                            case "mediaAritmetica":
                                watch.Start();
                                elTruncador(Medias.mediaAritmetica(ConvertirNumeros(lineaNumeros, lineaNumeros.Length)), resultadoViejo);
                                //resultadoNuevo = Math.Round(resultadoNuevo, 4);
                                watch.Stop();
                                milisecondsP(watch.ElapsedTicks);
                                watch.Reset();
                                Console.WriteLine("------------------");
                                break;
                            case "mediaGeometrica":
                                watch.Start();
                                elTruncador(mediasObj.mediaGeometrica(ConvertirNumeros(lineaNumeros, lineaNumeros.Length)), resultadoViejo);
                                watch.Stop();
                                milisecondsP(watch.ElapsedTicks);
                                watch.Reset();
                                Console.WriteLine("------------------");
                                break;
                            case "mediaArmonica":
                                watch.Start();
                                elTruncador(Medias.mediaArmonica(ConvertirNumeros(lineaNumeros, lineaNumeros.Length)), resultadoViejo);
                                watch.Stop();
                                milisecondsP(watch.ElapsedTicks);
                                watch.Reset();
                                Console.WriteLine("------------------");
                                break;
                            case "mediaNoExiste":
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("La media no existe");
                                Console.ResetColor();
                                Console.WriteLine("------------------");
                                break;
                        }
                    } else {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("No hay valores , NULL");
                        Console.ResetColor();
                    }
                } catch (Exception ex) {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(ex);
                    Console.ResetColor();
                }
            }
            crearArchivo(data);
        }        
    }
}
