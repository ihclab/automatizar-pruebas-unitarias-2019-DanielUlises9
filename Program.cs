using System;
using System.IO;

namespace AutomatizarPruebasUnitarias {

    class Program {
        static void Main(string[] args) {
            Medias mediasObj = new Medias();
            string[] lineas = File.ReadAllLines("CasosPrueba.txt");
            string[,] casos = new string[lineas.Length, 4];
            for (int i = 0; i < lineas.Length; i++) {
                string[] linea = lineas[i].Split(':');
                for (int j = 0; j < linea.Length; j++) {
                    casos[i, j] = linea[j];
                    System.Console.WriteLine(casos[i, j]);
                }
                try {
                    if (linea[2] != "NULL") {
                        int cresco = 0;
                        //double prueba = 2.222222222d;
                        double resultadoNuevo;
                        double resultadoViejo = Convert.ToDouble(linea[3]);
                        string[] lineaNumeros = linea[2].Split(' ');
                        int[] numeros = new int[lineaNumeros.Length];
                        switch (linea[1]) {
                            case "mediaAritmetica":
                                foreach (var item in lineaNumeros) {
                                    numeros[cresco] = Convert.ToInt32(item);
                                    cresco++;
                                }
                                resultadoNuevo = Medias.mediaAritmetica(numeros);
                                resultadoNuevo = Math.Round(resultadoNuevo, 4);
                                if (resultadoNuevo == resultadoViejo) {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Exito \n\r" + "Resultado viejo: " + resultadoViejo + "\n\r VS \n\r"
                            + "Resultado Nuevo: " + resultadoNuevo);
                                    Console.ResetColor();
                                } else {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Fallo \n\r" + "Resultado viejo: " + resultadoViejo + "\n\r VS \n\r"
                                    + "Resultado Nuevo: " + resultadoNuevo);
                                    Console.ResetColor();
                                }
                                break;
                            case "mediaGeometrica":
                                foreach (var item in lineaNumeros) {
                                    numeros[cresco] = Convert.ToInt32(item);
                                    cresco++;
                                }
                                resultadoNuevo = mediasObj.mediaGeometrica(numeros);
                                resultadoNuevo = Math.Round(resultadoNuevo, 4);
                                if (resultadoNuevo == resultadoViejo) {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Exito \n\r" + "Resultado viejo: " + resultadoViejo + "\n\r VS \n\r"
                            + "Resultado Nuevo: " + resultadoNuevo);
                                    Console.ResetColor();
                                } else {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Fallo \n\r" + "Resultado viejo: " + resultadoViejo + "\n\r VS \n\r"
                                    + "Resultado Nuevo: " + resultadoNuevo);
                                    Console.ResetColor();
                                }
                                break;
                            case "mediaArmonica":
                                foreach (var item in lineaNumeros) {
                                    numeros[cresco] = Convert.ToInt32(item);
                                    cresco++;
                                }
                                resultadoNuevo = Medias.mediaArmonica(numeros);
                                resultadoNuevo = Math.Round(resultadoNuevo, 4);
                                if (resultadoNuevo == resultadoViejo) {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Exito \n\r" + "Resultado viejo: " + resultadoViejo + "\n\r VS \n\r"
                            + "Resultado Nuevo: " + resultadoNuevo);
                                    Console.ResetColor();
                                } else {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Fallo \n\r" + "Resultado viejo: " + resultadoViejo + "\n\r VS \n\r"
                                    + "Resultado Nuevo: " + resultadoNuevo);
                                    Console.ResetColor();
                                }
                                break;
                            case "mediaNoExiste":
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
        }
    }
}
