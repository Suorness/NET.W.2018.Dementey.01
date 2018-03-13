﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2018.Dementey._01
{
    public static class Sorter
    {
        public static int[] QuickSort(int[] array)
        {
            CheckInputParam(array);

            var cloneArray = new int[array.Length];
            Array.Copy(array,cloneArray, array.Length);

            QuickSorting(cloneArray, 0, cloneArray.Length - 1);

            return cloneArray;
        }

        public static int[] MergeSort(int[] array)
        {
            CheckInputParam(array);

            var cloneArray = new int[array.Length];
            Array.Copy(array, cloneArray, cloneArray.Length);

            Merge(cloneArray);

            return cloneArray;
        }

        private static void Merge(int[] array)
        {
            if (array.Length <= 1)
            {
                return;
            }

            int leftArraySize = array.Length / 2;
            int rightArraySize = array.Length - leftArraySize;

            int[] leftArray = new int[leftArraySize];
            int[] rightArray = new int[rightArraySize];

            Array.Copy(array, 0, leftArray, 0, leftArraySize);
            Array.Copy(array, leftArraySize, rightArray, 0, rightArraySize);

            Merge(leftArray);
            Merge(rightArray);

            MergeSorting(array, leftArray, rightArray);
        }

        private static void QuickSorting(int[] array, int firsttItem, int lastItem)
        {
            int indexBasicElement = GetBasicElement(firsttItem, lastItem);
            int basicElement = array[indexBasicElement];

            int i = firsttItem;
            int j = lastItem;

            while (i <= j)
            {
                while ((array[i] < basicElement) && (i <= lastItem))
                {
                    i++;
                }

                while ((array[j] > basicElement) && (j >= firsttItem))
                {
                    j--;
                }

                if (i <= j)
                {
                    Swap(array, i, j);
                    i++;
                    j--;
                }
            }

            if (j > firsttItem)
            {
                QuickSorting(array, firsttItem, j);
            }

            if (i < lastItem)
            {
                QuickSorting(array, i, lastItem);
            }

        }

        private static void MergeSorting(int[] array, int[] leftArray, int[] rightArray)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int index = 0;
            int countRemainingElements = leftArray.Length + rightArray.Length;

            while (countRemainingElements > 0)
            {
                if (leftIndex >= leftArray.Length)
                {
                    array[index] = rightArray[rightIndex];
                    rightIndex++;
                }
                else if (rightIndex >= rightArray.Length)
                {
                    array[index] = leftArray[leftIndex];
                    leftIndex++;
                }
                else if (leftArray[leftIndex] < rightArray[rightIndex])
                {
                    array[index] = leftArray[leftIndex];
                    leftIndex++;
                }
                else
                {
                    array[index] = rightArray[rightIndex];
                    rightIndex++;
                }

                index++;
                countRemainingElements--;
            }
        }

        private static int GetBasicElement(int firsttItem, int lastItem)
        {
            return firsttItem + (lastItem - firsttItem) / 2;
        }

        private static void CheckInputParam(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
            else if (array.Length == 0)
            {
                throw new ArgumentException("Array is empty.");
            }
        }

        private static void Swap(int[] array, int indexItem1, int indexItem2)
        {
            int temp = array[indexItem1];
            array[indexItem1] = array[indexItem2];
            array[indexItem2] = temp;
        }


    }
}
