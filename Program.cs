using System;
using System.IO;
using System.Threading;

namespace AutomatizarPruebasUnitarias {
    class Program {
        static void Main(string[] args) {
            string[] lineas = File.ReadAllLines("CasosPrueba.txt");
            string[,] casos = new string[lineas.Length, 4]; 
            for (int i = 0; i < lineas.Length; i++) {
                tools.resolverVector(lineas,i,casos);
            }
            tools.crearArchivo(tools.data);
        }        
    }
}
