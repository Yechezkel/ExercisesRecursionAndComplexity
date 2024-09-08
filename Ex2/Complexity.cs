using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    public class Complexity
    {
        //1
        //O(n)
        public static int CalculateOddSum(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 1)
                    sum += array[i];
            }
            return sum;
        }

        //2
        //O(n)
        public static int[] FindMaximumTwo(int[] array)
        {
            if (array == null || array.Length <= 2)
            {
                return array;
            }
            int[] result = { array[0], array[1] };
            int sum = array[0] + array[1];
            for (int i = 2; i < array.Length; i++)
            {
                if (array[i] + array[i - 1] > sum)
                {
                    result[0] = array[i - 1];
                    result[1] = array[i];
                    sum = array[i] + array[i - 1];
                }
            }
            return result;
        }

        //3
        //O(n)
        public static bool ContainsNumber(int[] array, int number)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == number)
                    return true;
            }
            return false;
        }

        ////לא קשור
        //public static int MaxTriplet(int[] array)
        //{
        //    if (array == null || array.Length < 3)
        //    {
        //        return int.MinValue;
        //    }
        //    int max1 = int.MinValue;
        //    int max2 = int.MinValue;
        //    int max3 = int.MinValue;
        //    for (int i = 0; i < array.Length; i++)
        //    {
        //        if (array[i] > max3)
        //        {
        //            if (array[i] > max1)
        //            {
        //                max3 = max2;
        //                max2 = max1;
        //                max1 = array[i];
        //            }
        //            else if (array[i] > max2)
        //            {
        //                max3 = max2;
        //                max2 = array[i];
        //            }
        //            else
        //            {
        //                max3 = array[i];
        //            }
        //        }
        //    }
        //    return max1 + max2 + max3;
        //}

        //4
        //O(n^3)
        public static int SumOfAllTriplets(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
                for (int j = i + 1; j < array.Length; j++)
                    for (int k = j + 1; k < array.Length; k++)
                        sum += array[i] * array[j] * array[k];
            return sum;
        }

        //5
        //O(n)
        public static int[] FindLastPairWithProduct(int[] array, int product)
        {
            for (int i = array.Length - 1; i > 0; i--)
            {
                if (array[i] * array[i - 1] == product)
                    return new int[] { array[i - 1], array[i] };
            }
            return new int[] { 0, 0 };
        }


        //6
        //O(n)
        public static int CountEvenNumbers(int[] array)
        {
            int sumEven = 0;
            for(int i = 0;i < array.Length;i++)
                if (array[i]%2 == 0)
                    sumEven += array[i];
            return sumEven;
        }

        //7
        //O(n)
        public static int[] MergeSortedArraysUnique(int[] array1, int[] array2)
        {
            int[] temp = new int[array1.Length+ array2.Length];
            int a = 0;
            int b = 0;
            int t;
            for (t = 0; t < temp.Length && a < array1.Length && b < array2.Length; t++)
            {
                if (array1[a] == array2[b])
                {
                    temp[t] = array1[a];
                    a++;
                    b++;
                }
                else if (array1[a] < array2[b])
                {
                    temp[t] = array1[a];
                    a++;
                }
                else
                {
                    temp[t] = array1[b];
                    b++;
                }
            }
            int[] array3 = (a < array1.Length) ? array1 : array2;
            int c        = (a < array1.Length) ? a      : b     ;
            for (; c < array3.Length; t++, c++) 
                temp[t] = array3[c];
            int[]result = new int[t];
            for (int i = 0;i< result.Length; i++)
                result[i] = array3[i];
            return result;
        }

        //8
        //O(n^2)
        public static void FindPairsWithSum(int[] array, int sum)
        {
            for (int i = 0; i < array.Length; i++)
                for (int j = i + 1; j < array.Length; j++)
                    if (array[j] + array[j] == sum)
                        Console.WriteLine($"({array[i]},{array[j]})");
        }

        //9
        //O(n)
        //assuming all the integers are not negative numbers
        public static int[] CountFrequency(int[] array)
        {
            int maxValue = array[0];
            for (int i = 1; i < array.Length; i++)
                if (array[i] > maxValue)
                    maxValue = array[i];
            int[] result = new int[maxValue];
            for (int i = 0; i < array.Length; i++)
                result[array[i]]++;
            return result;
        }


        //10
        //O(n^2)
        public static int FindMaxSubarraySum(int[] array)
        {
            int maxSum= int.MinValue;
            int Sum;
            for (int i = 0;i<array.Length ; i++)
            {
                Sum = 0;
                for (int j = i; j < array.Length; j++)
                {
                    Sum += array[j];
                    if (Sum > maxSum)
                        maxSum = Sum;
                }
            }
            return maxSum;  
        }

        //11
        //O(n)
        public static int FindFirstRepeating(int[] array)
        {
            int maxValue = array[0];
            for (int i = 1; i < array.Length; i++)
                if (array[i] > maxValue)
                    maxValue = array[i];
            bool[] temp = new bool[maxValue];
            for (int i = 0; i < array.Length; i++)
            {
                if (temp[array[i]])
                    return array[i];
                temp[array[i]] = true;
            }
            return -1;
        }


        //12
        //O(logn)
        public static int FindMissingNumber(int[] array)
        {

            int low = 0;
            int high = array.Length - 1;
            int mid;
            if (array[high] == high + 1)//no missing number
                return -1;
            while (low + 1 < high)
            {
                mid = (low + high) / 2;
                if (array[mid] == mid + 1 && array[mid + 1] == mid + 3)
                    return mid + 2;
                if (array[mid] == mid + 1)
                {
                    low = mid + 1;
                }
                else if (array[mid] == mid + 2)
                {
                    high = mid;
                }
                else//אם המערך לא ממויין או משהו לא צפוי
                    return -2;
            }
            if (array[low] == low + 1 && array[low + 1] == low + 3)
                return low + 2;
            if (array[high] == high + 1 && array[high + 1] == high + 3)
                return high + 2;
            return 1;
        }

        //13
        //O(n)
        public static int FindMissingNumberUnsoerted(int[] array)
        {
            bool[] temp = new bool[array.Length + 2];
            for (int i = 0; i < array.Length; i++)
                temp[array[i]] = true;
            for (int i = 1; i < temp.Length; i++)
                if (!temp[i])
                    return i;
            return -1;
        }

    }       
}
