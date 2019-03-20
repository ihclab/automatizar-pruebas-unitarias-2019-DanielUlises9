using System;
using System.IO;

namespace AutomatizarPruebasUnitarias
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lineas = File.ReadAllLines("CasosPrueba.txt");
            string[,] casos = new string[lineas.Length, 4];
            for (int i = 0; i < lineas.Length; i++)
            {
                string[] linea = lineas[i].Split(':');
                for (int j = 0; j < linea.Length; j++)
                {
                    casos[i,j] = linea[j];
                    System.Console.WriteLine(casos[i,j]);
                }
            }
        }
    }
}
