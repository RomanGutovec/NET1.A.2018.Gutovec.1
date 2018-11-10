using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    /// <summary>
    /// Sorting array by methods Quick and Merging
    /// </summary>
    public static class SortQuickAndMerge<T> where T : IComparable<T>
    {
        /// <summary>
        /// Sorts source array by method 
        /// which called "Quick sorting"
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when array have null value</exception>
        /// <param name="array">source array which must be sorted</param>
        public static void QuickSort(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} haves null value");
            }

            if (array.Length <= 1)
            {
                throw new ArgumentException($"{nameof(array)} is empty");
            }
            
                SortPartsArrays(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Divides source array into simple parts and sort 
        /// these parts by method Merge
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when array have null value</exception>
        /// <param name="arr">source array which must be sorted</param>
        /// <returns>sorted source array</returns>
        public static T[] MergeSort(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} haves null value");
            }

            if (array.Length == 1)
            {
                return array;
            }

            List<T> left = new List<T>();
            List<T> right = new List<T>();

            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 > 0)
                {
                    left.Add(array[i]);
                }
                else
                {
                    right.Add(array[i]);
                }
            }

            left = MergeSort(left.ToArray()).ToList();
            right = MergeSort(right.ToArray()).ToList();
            return Merge(left, right);
        }

        /// <summary>
        /// Sorts source array before and after pivot element
        /// </summary>
        /// <param name="array">source array</param>
        /// <param name="left">index of start</param>
        /// <param name="right">index of end</param>
        private static void SortPartsArrays(T[] array, int left, int right)
        {
            if (left == right)
            {
                return;
            }

            int first = left + 1;
            int second = right;
            T pivot = array[left];
            while (first < second)
            {
                if (array[first].CompareTo(pivot) <= 0)
                {
                    first++;
                }
                else if (array[second].CompareTo(pivot) > 0)
                {
                    second--;
                }
                else
                {
                    Swap(ref array[first], ref array[second]);
                }
            }

            if (array[second].CompareTo(pivot) <= 0)
            {
                Swap(ref array[left], ref array[right]);
                SortPartsArrays(array, left, right - 1);
            }
            else
            {
                SortPartsArrays(array, left, first - 1);
                SortPartsArrays(array, first, right);
            }
        }

        /// <summary>
        /// Method sorts two arrays and writes result 
        /// in the returned already sorted array
        /// </summary>
        /// <param name="left" >left part of array</param>
        /// <param name="right" >right part of array</param>
        /// <returns>sorted array</returns>
        private static T[] Merge(List<T> left, List<T> right)
        {
            List<T> result = new List<T>();
            while (left.Count > 0 && right.Count > 0)
            {
                if (left.First().CompareTo(right.First()) <= 0)
                {
                    result.Add(left.First());
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right.First());
                    right.RemoveAt(0);
                }
            }

            while (left.Count > 0)
            {
                result.Add(left.First());
                left.RemoveAt(0);
            }

            while (right.Count > 0)
            {
                result.Add(right.First());
                right.RemoveAt(0);
            }

            return result.ToArray();
        }

        private static void Swap(ref T first, ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }
    }
}
