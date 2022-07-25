using System;
using System.Linq;
using System.Collections.Generic;

namespace Utils {
    public static class CollectionUtils {
        private static readonly Random rnd = new Random();
        
        public static int? BinarySearch(int[] array, int targetNumber) {   // Useless
            int mid = (array.Length + 1) / 2;
            int[] first = array.Take(mid).ToArray();
            int[] second = array.Skip(mid).ToArray();

            if (mid > targetNumber) {
                foreach (int firstAr in first) {
                    return Array.IndexOf(first, targetNumber);
                }
            }
            else if(mid < targetNumber) {
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
            foreach (int x in array) {
                foreach (int y in array) {
                    if (x + y == targetNumber) {
                        yield return (x, y);
                    }
                }
            }
            yield return (0,0);
        }
        public static IEnumerable<(int firstNumber, int secondNumber, int thirdNumber)?> GetSumTripletPairs(int[] array, int targetNumber) {
            foreach (int x in array) {
                foreach (int y in array) {
                    foreach (int z in array) {
                        if (x + y + z == targetNumber) {
                            yield return (x, y, z);
                        }   
                    }
                }
            }
            yield return (0,0,0);
        }
        public static int MultiplyAllInList(this IEnumerable<int> arr) => arr.Aggregate((current, i) => current * i);
        
        public static float MultiplyAllInList(this float[] arr) {
            float val = 1;
            foreach (float i in arr) {
                val *= i;
            }
            return val;
        }
        public static unsafe IntPtr GetAddressOfIntArray(int[] array) {
            fixed (int* ptr = array) {
                return new IntPtr(&ptr);
            }
        }
        public static List<T> RemoveDuplicates<T>(this List<T> list) => new HashSet<T>(list).ToList();
        
        public static T[] RemoveDuplicates<T>(this T[] array) => new HashSet<T>(array).ToArray();
        
        public static List<T> ListWithRandomValues<T>(int length) { 
            if (typeof(T) == typeof(string)) {
                string[] list = new string[length];
                for (int i = 0; i < length; i++) {
                    list[i] = RandomUtils.RandomString(5);
                }
                return list.ToList() as List<T>;
            }
            
            if (typeof(T) == typeof(int)) {
                int[] list = new int[length];
                for (int i = 0; i < length; i++) {
                    list[i] = rnd.Next(500);
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
            int count = list.Count - 1;
            for (int i = count; i >= 0; i--) {
                list.SwapElements(rnd.Next(0,count), i);
                count -= 1;
            }
        }

        public static void SelectionSort(this List<int> list) {
            for (int x = 0, min = 0; x < list.Count - 1; x++, min = x) {
                for (int y = x + 1; y < list.Count; y++) {
                    min = (list[y] < list[min]) ? y : min;
                }
                //min = (from y in Enumerable.Range(x + 1, list.Count) select y).Aggregate((u, i) => min = list[x + 1] < list[min] ? x + 1 : min);
                list.SwapElements(x, min);
            }
        }
    }
}