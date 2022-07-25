using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Utils {
    public class AiUtils {
        public static class SigmoidFunction {
            public static double LogisticFunction(double x) => 1 / (1 + Math.Pow(Math.E, -x));
        }

        public static class LinRegression {
            [Description("I am still working on it!")]
            public static double LinearRegressionEquation(float[,] dataset, double x = 1) => A(dataset) + B(dataset) * x;

            public static float[] XorY(float[,] dataset, int collum, bool times = false) {
                float[] x = new float[dataset.GetLength(0)];
                
                if (collum > 1 || collum < 0) {
                    x[0] = 0;
                    return x;
                }
                for (int i = 0; i < dataset.GetLength(0); i++) {
                    if(!times) x[i] = dataset[i, collum];
                    if(times) x[i] = (float)Math.Pow(dataset[i, collum], 2);
                }
                return x;
            }

            public static float[] ValueMultiplier(float[,] dataset) {
                IList<float> xy = new List<float>();
                for (int i = 0; i < dataset.GetLength(0); i++) {
                    for (int j = 0; j < dataset.GetLength(1); j++) {
                        for (int k = j + 1 ; k < dataset.GetLength(1); k++) {
                            xy.Add(dataset[i,j] * dataset[i,k]);   
                        }
                    }
                }
                return xy.ToArray();
            }
            public static float[] XY_Values (float[,] dataset) {
                IList<float> xy = new List<float>();
                for (int i = 0; i < dataset.GetLength(0); i++) {
                    xy.Add(dataset[i,0] * dataset[i,1]);
                }
                return xy.ToArray();
            }

            // y intercept
            private static float A(float[,] dataset) => (float)((XorY(dataset, 1).Sum() * XorY(dataset, 0, true).Sum() - XorY(dataset, 0).Sum() * ValueMultiplier(dataset).Sum()) / (dataset.GetLength(0) * XorY(dataset, 0, true).Sum() - Math.Pow(XorY(dataset, 0).Sum(), 2)));
            private static float B(float[,] dataset) => B1(dataset) / B2(dataset); // Slope
            private static float B1(float[,] dataset) => (float)(dataset.GetLength(0) * ValueMultiplier(dataset).Sum() - XorY(dataset, 0).Sum() * XorY(dataset, 1).Sum());
            private static float B2(float[,] dataset) => (float)(dataset.GetLength(0) * XorY(dataset, 0, true).Sum() - Math.Pow(XorY(dataset, 0).Sum(), 2));
        }
    }
}