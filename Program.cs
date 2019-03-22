using System;
using System.IO;

namespace AutomatizarPruebasUnitarias {

    class Program {
        static void Main(string[] args) {
            string[] lineas = File.ReadAllLines("CasosPrueba.txt");
            string[,] casos = new string[lineas.Length, 4];
            for (int i = 0; i < lineas.Length; i++) {
                string[] linea = lineas[i].Split(':');
                for (int j = 0; j < linea.Length; j++) {
                    casos[i, j] = linea[j];
                    System.Console.WriteLine(casos[i, j]);
                }
                Console.WriteLine(linea[1]);
                int cresco = 0;
                double resultadoViejo = Convert.ToDouble(linea[3]);
                string[] lineaNumeros = linea[2].Split(' ');
                int[] numeros = new int[lineaNumeros.Length];
                switch (linea[1]) {
                    case "mediaAritmetica":
                        foreach (var item in lineaNumeros) {
                            numeros[cresco] = Convert.ToInt32(item);
                            cresco++;
                        }
                        Console.WriteLine("Es mediaAritmetica");
                        break;
                    case "mediaGeometrica":
                        Console.WriteLine("Es mediaAritmetica");
                        break;
                    case "mediaArmonica":
                        Console.WriteLine("Es mediaAritmetica");
                        break;
                    case "mediaNoExiste":
                        Console.WriteLine("Es mediaAritmetica");
                        break;
                }
            }
        }
    }
}
