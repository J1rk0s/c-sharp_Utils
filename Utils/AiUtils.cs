using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils {
    public static class AiUtils {
        public static class UsefullFunctions {
            public static float Variance(int[] arr) {
                float step1 = arr.Sum() / arr.Length;
                List<float> step2 = arr.Select(item => item - step1).ToList();
                List<float> step3 = step2.Select(item => (float) Math.Pow(item, 2)).ToList();
                return step3.Sum() / arr.Length;
            }
            public static double LogisticFunction(double x) => 1 / (1 + Math.Pow(Math.E, -x));

            public static double HyperbolicTangent(double x) => (Math.Pow(Math.E, x) - Math.Pow(Math.E, -x)) / (Math.Pow(Math.E, x) + Math.Pow(Math.E, -x));

            public static float StandardDeviation(int[] arr) => (float)Math.Sqrt(Variance(arr));

            public static float RELU_Function(float x) => 0 > x ? 0 : x;
            public static float RELU_Prime_Function(float x) => x <= 0 ? 0 : 1;

            public static float ELU_Function(float x, float alpha) => (float)(x <= 0 ? alpha * (Math.Pow(Math.E, x) - 1) : x);
            public static float ELU_Prime_Function(float x, float alpha) => (float)(x <= 0 ? alpha * (Math.Pow(Math.E, x) - 1) : 1);

            public static float Cost_Function(float[] y) => (float)(0.5 * Math.Pow(y.Average() - y.Sum(), 2));
            public static float CostPrime_Function(float yMean, float y) => yMean - y;

            public static float Weight_Function(float W, float X) => X * W;

            public static float Linear_Function(float z, float m) => z * m;

            public static float LeakyRELU_Function(float z, float alpha) => alpha * z > z ? alpha * z : z;
            public static float LeakyRELU_Prime_Function(float z, float alpha) => z > 0 ? 1 : alpha;

            public static float Median(int n, int nth) => (float) (n % 2 != 0
                ? Math.Pow((n + 1) / 2, nth)
                : (Math.Pow(n / 2, nth) + Math.Pow(n / 2 + 1, nth)) / 2);

            public static (float xM, float yM) Midpoint(int x1, int x2, int y1, int y2) =>
                ((x1 + x2) / 2, (y1 + y2) / 2);
        }
        public static class Regression {
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