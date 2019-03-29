using System;
using System.IO;
using System.Threading;

namespace AutomatizarPruebasUnitarias {

    class tools {

         public static string data;
        public static string myPath =Directory.GetCurrentDirectory();
        public static double truncate(double d, int decimals) {
            return (Math.Truncate(d * Math.Pow(10, decimals)) / Math.Pow(10, decimals));
        }
        public static void elTruncador(double nuevo, double viejo) {
            nuevo = truncate(nuevo, 4);
            viejo = truncate(viejo, 4);
            exitoOfalla(nuevo, viejo);
        }
        public static void milisecondsP(long reb) {
            Console.WriteLine("Milisegundos: " + Convert.ToDouble(reb) / 10000d);
        }
        public static int[] ConvertirNumeros(string[] vec, int size) {
            int[] numeros = new int[size];
            int cresco = 0;
            foreach (var item in vec) {
                numeros[cresco] = Convert.ToInt32(item);
                cresco++;
            }
            return numeros;
        }
        public static void exitoOfalla(double nuevo, double viejo) {
            if (nuevo == viejo) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Exito \r\n" + "Resultado viejo: " + viejo + "\r\n VS \r\n"
        + "Resultado Nuevo: " + nuevo);
                Console.ResetColor();
                data+="Exito \r\n" + "Resultado viejo: " + viejo + "\r\n VS \r\n"
        + "Resultado Nuevo: " + nuevo + "\r\n";
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Fallo \r\n" + "Resultado viejo: " + viejo + "\r\n VS \r\n"
                + "Resultado Nuevo: " + nuevo);
                Console.ResetColor();
                data+="Fallo \r\n" + "Resultado viejo: " + viejo + "\r\n VS \r\n"
                + "Resultado Nuevo: " + nuevo + "\r\n";
            }
        }
        public static void crearArchivo(string datos){
            System.IO.File.WriteAllText("ResultadosDePruebas.txt",datos);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Archivo Creado Exitosamente");
            Console.ResetColor();
        }

        public static void escojerCual(string [] vector){
            var watch = System.Diagnostics.Stopwatch.StartNew();
            watch.Stop();
            watch.Reset();
            Medias mediasObj = new Medias();

             try {
                    if (vector[2] != "NULL") {
                        //double prueba = 2.222222222d;
                        double resultadoViejo = Convert.ToDouble(vector[3]);
                        string[] lineaNumeros = vector[2].Split(' ');
                        switch (vector[1]) {
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
                        data += "No hay valores, NULL\r\n";
                    }
                } catch (Exception ex) {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(ex);
                    Console.ResetColor();
                    data+="\r\n" + ex + "\r\n";
                }
                
            }
        public static void resolverVector(string [] vector,int i,string [,] casos){
                string[] linea = vector[i].Split(':');
                for (int j = 0; j < linea.Length; j++) {
                    casos[i, j] = linea[j];
                    System.Console.WriteLine(casos[i, j]);
                    data += casos[i,j] + ":";
                }
                tools.escojerCual(linea);
        }
    }

}