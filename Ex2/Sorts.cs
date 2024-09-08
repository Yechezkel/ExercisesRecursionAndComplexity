using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    public class Sorts
    {
        public static void insretionSort(int[] array)
        {
            int temp;
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        break;
                    }
                    else
                    {
                        temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }


        public static void selectionSort(int[] array)
        {
            int minValue;
            int minIndex;
            for (int i = 0; i < array.Length; i++)
            {
                minValue = array[i];
                minIndex = i;
                for (int j = i+1; j < array.Length; j++)
                {
                    if (array[j] > minValue)
                    {
                        minValue = array[j];
                        minIndex = i;
                    }  
                }
                array[minIndex] = array[i];
                array[i]= minValue;
            }
        }


        public static void SortByBubbleSort(int[] array)
        {
            int temp;
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }

                }
            }
        }

    }
}
