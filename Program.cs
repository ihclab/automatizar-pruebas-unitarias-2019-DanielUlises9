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

        }
    }
}
