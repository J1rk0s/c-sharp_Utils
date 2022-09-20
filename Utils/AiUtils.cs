using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Utils {
    public static class AiUtils {
        public static class SigmoidFunction {
            public static double LogisticFunction(double x) => 1 / (1 + Math.Pow(Math.E, -x));

            public static double HyperbolicTangent(double x) => (Math.Pow(Math.E, x) -
                Math.Pow(Math.E, -x)) / (Math.Pow(Math.E, x) + Math.Pow(Math.E, -x));
        }
        
        public static class UsefullFunctions {
            public static float Variance(int[] arr) {
                float step1 = arr.Sum() / arr.Length;
                List<float> step2 = arr.Select(item => item - step1).ToList();
                List<float> step3 = step2.Select(item => (float) Math.Pow(item, 2)).ToList();
                return step3.Sum() / arr.Length;
            }

            public static float StandardDeviation(int[] arr) => (float)Math.Sqrt(Variance(arr));
        }
        public static class Regression {
            public static float RegressionCostFunction(float input, float predictedOutput) => input - predictedOutput;
            public static double LinearRegression(double[] x, double[] y, double n) => YIntercept(x, y) + Slope(x, y) * n;

            public static double PCC(double[] x, double[] y) {
                // Paerson correlation coefficient
                double[] xMean = new double[x.Length], yMean = new double[x.Length], xYMean = new double[x.Length], x2Mean = new double[x.Length], y2Mean = new double[x.Length];
                for (int i = 0; i <= x.Length - 1; i++) {
                    xMean[i] = x[i] - x.Average();
                    yMean[i] = y[i] - y.Average();
                    xYMean[i] = xMean[i] * yMean[i];
                    x2Mean[i] = Math.Pow(xMean[i], 2);
                    y2Mean[i] = Math.Pow(yMean[i], 2);
                }
                return xYMean.Sum() / Math.Sqrt(x2Mean.Sum() * y2Mean.Sum());
            }

            public static double YIntercept(double[] x, double[] y) => y.Average() - (Slope(x, y) * x.Average());
            public static double Slope(double[] x, double[] y) => PCC(x, y) * (Sy(y) / Sx(x));
            public static double Sx(double[] x) {
                double[] x2Mean = new double[x.Length], xMean = new double[x.Length];
                for (int i = 0; i <= x.Length - 1; i++) {
                    xMean[i] = x[i] - x.Average();
                    x2Mean[i] = Math.Pow(xMean[i], 2);
                }
                return Math.Sqrt(x2Mean.Sum() / x.Length);
            }

            public static double Sy(double[] y) {
                double[] y2Mean = new double[y.Length], yMean = new double[y.Length];
                for (int i = 0; i <= y.Length - 1; i++) {
                    yMean[i] = y[i] - y.Average();
                    y2Mean[i] = Math.Pow(yMean[i], 2);
                }
                return Math.Sqrt(y2Mean.Sum() / y.Length);
            }
        }
    }
}