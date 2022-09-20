using System;
using System.Linq;
using System.Collections.Generic;

namespace Utils {
    public static class CollectionUtils {
        private static readonly Random rnd = new Random();

        public static int? BinarySearch(int[] array, int targetNumber) {
            // Useless
            int mid = (array.Length + 1) / 2;
            int[] first = array.Take(mid).ToArray();
            int[] second = array.Skip(mid).ToArray();

            if (mid > targetNumber) {
                foreach (int firstAr in first) {
                    return Array.IndexOf(first, targetNumber);
                }
            }
            else if (mid < targetNumber) {
                foreach (int secondAr in second) {
                    return Array.IndexOf(second, targetNumber);
                }
            }

            return null;
        }

        public static int? LinearSearchAlgo(IEnumerable<int> arrayOfNumbers, int targetNumber) {
            foreach (int numba in arrayOfNumbers) {
                if (numba == targetNumber) {
                    return numba;
                }
            }

            return null;
        }

        public static IEnumerable<(int firstNumber, int secondNumber)?> GetSumPairs(int[] array, int targetNumber) {
            return (from x in array from y in array where x + y == targetNumber select (x, y)).Select(_ =>
                ((int firstNumber, int secondNumber)?) _);
        }

        public static IEnumerable<(int firstNumber, int secondNumber, int thirdNumber)?> GetSumTripletPairs(int[] array,
            int targetNumber) {
            return (from x in array from y in array from z in array where x + y + z == targetNumber select (x, y, z))
                .Select(_ => ((int firstNumber, int secondNumber, int thirdNumber)?) _);
        }

        public static int MultiplyAllInList(this IEnumerable<int> arr) => arr.Aggregate((current, i) => current * i);

        public static float MultiplyAllInArray(this float[] arr) =>
            arr.Aggregate<float, float>(1, (current, i) => current * i);

        public static unsafe IntPtr GetAddressOfIntArray(int[] array) {
            fixed (int* ptr = array) {
                return new IntPtr(&ptr);
            }
        }

        public static List<T> RemoveDuplicates<T>(this List<T> list) => new HashSet<T>(list).ToList();

        public static T[] RemoveDuplicates<T>(this T[] array) => new HashSet<T>(array).ToArray();

        public static List<T>? ListWithRandomValues<T>(int length,int maxInt = 100 ,int strLength = 5) {
            if (typeof(T) == typeof(string)) {
                string[] list = new string[length];
                for (int i = 0; i < length; i++) {
                    list[i] = RandomUtils.RandomString(strLength);
                }

                return list.ToList() as List<T>;
            }

            if (typeof(T) == typeof(int)) {
                int[] list = new int[length];
                for (int i = 0; i < length; i++) {
                    list[i] = rnd.Next(maxInt);
                }

                return list.ToList() as List<T>;
            }

            return null;
        }

        public static void SwapElements<T>(this List<T> list, int indexOne, int indexTwo) {
            (list[indexOne], list[indexTwo]) = (list[indexTwo], list[indexOne]);
        }

        public static void SwapElements<T>(this T[] arr, int indexOne, int indexTwo) {
            (arr[indexOne], arr[indexTwo]) = (arr[indexTwo], arr[indexOne]);
        }

        public static void FisherYatesShuffleNew<T>(this List<T> list) {
            if (list.Count == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(list));
            
            int count = list.Count - 1;
            for (int i = count; i >= 0; i--) {
                list.SwapElements(rnd.Next(0, count), i);
                count -= 1;
            }
        }
        
        public static void FisherYatesShuffleNew<T>(this T[] list) {
            if (list.Length == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(list));
            
            int count = list.Length - 1;
            for (int i = count; i >= 0; i--) {
                list.SwapElements(rnd.Next(0, count), i);
                count -= 1;
            }
        }

        public static void SelectionSort(this List<int> list) {
            if (list.Count == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(list));
            
            for (int x = 0, min = 0; x < list.Count - 1; x++, min = x) {
                for (int y = x + 1; y < list.Count; y++) {
                    min = (list[y] < list[min]) ? y : min;
                }

                //min = (from y in Enumerable.Range(x + 1, list.Count) select y).Aggregate((u, i) => min = list[x + 1] < list[min] ? x + 1 : min);
                list.SwapElements(x, min);
            }
        }

        public static void SelectionSort(this int[] list) {
            if (list.Length == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(list));
            
            for (int x = 0, min = 0; x < list.Length - 1; x++, min = x) {
                for (int y = x + 1; y < list.Length; y++) {
                    min = (list[y] < list[min]) ? y : min;
                }

                list.SwapElements(x, min);
            }
        }

        public static void BubbleSort(this List<int> list) {
            if (list.Count == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(list));
            
            for (int i = 0; i < list.Count - 1; i++) {
                for (int j = i + 1; j < list.Count; j++) {
                    if (list[i] > list[j]) {
                        list.SwapElements(i, j);
                    }
                }
            }
        }

        public static void BubbleSort(this int[] list) {
            if (list.Length == 0) throw new ArgumentException("Value cannot be an empty collection.", nameof(list));
            
            for (int i = 0; i < list.Length - 1; i++) {
                for (int j = i + 1; j < list.Length; j++) {
                    if (list[i] > list[j]) {
                        list.SwapElements(i, j);
                    }
                }
            }
        }

        public static List<T> ShuffleRandomly<T>(this List<T> arr) => arr.OrderBy(a => rnd.Next()).ToList();
        public static T[] ShuffleRandomly<T>(this T[] arr) => arr.OrderBy(a => rnd.Next()).ToArray();

        public static int[,] ArrayWithRandomValues(int lenA, int lenB, int minNumber = 0, int maxNumber = 100) {
            if (maxNumber < minNumber) throw new ArgumentOutOfRangeException(nameof(maxNumber),"maxNumber is smaller than minNumber");
            if (minNumber > maxNumber) throw new ArgumentOutOfRangeException(nameof(maxNumber),"minNumber is bigger than maxNumber");
            
            int[,] arr = new int[lenA, lenB];
            for (int i = 0; i < arr.GetUpperBound(0); i++) {
                for (int j = 0; j < arr.GetUpperBound(1); j++) {
                    if (arr[i,j] == 0) arr[i, j] = rnd.Next(minNumber, maxNumber);
                    
                }
            }

            return arr;
        }

        public static int[] ArrayWithRandomValues(int lenA, int minNumber = 0, int maxNumber = 100) {
            if (maxNumber < minNumber) throw new ArgumentOutOfRangeException(nameof(maxNumber),"maxNumber is smaller than minNumber");
            if (minNumber > maxNumber) throw new ArgumentOutOfRangeException(nameof(maxNumber),"minNumber is bigger than maxNumber");

            int[] arr = new int[lenA];
            for (int j = 0; j < arr.Length; j++) {
                if (arr[j] == 0) arr[j] = rnd.Next(minNumber, maxNumber);
            }
            return arr;
        }

        public static int Array2D_To_Array1D_Index(int x, int y, int arrayWidth) => x * arrayWidth + y;
    }
}