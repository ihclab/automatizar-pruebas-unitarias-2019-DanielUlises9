﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizarPruebasUnitarias {

    class Medias {

        /**
         * Calcula y regresa la media artimética
         */
        public static double mediaAritmetica(params int[] vals) {
            int sum = 0;
            for (int i = 0; i < vals.Length; i++) {
                sum += vals[i];
            }
            return (double)sum / vals.Length;
        }

        /**
         * Calcula y regresa la raíz enésima = x^(1/n)
         */
        private static double raizEnesima(double x, int n) {
            return Math.Pow(x, 1 / Convert.ToDouble(n));
        }

        /**
         *  Usa raizEnesima para calcular y regresar la media geométrica
         */
        public double mediaGeometrica(params int[] vals) {
            int mult = 1;
            for (int i = 0; i < vals.Length; i++) {
                mult *= vals[i];
            }
            return (double)raizEnesima(mult, vals.Length);
        }

        /**
         * Este método no está implementado.
         */
        public static double mediaArmonica(params int[] vals) {
            double sum = 0;
            for (int i = 0; i < vals.Length; i++) {
                sum = sum + (1d / Convert.ToDouble(vals[i]));
            }
            double hola = vals.Length / sum;
            return vals.Length / sum;
        }
    }
}