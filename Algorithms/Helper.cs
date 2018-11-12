using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms
{
    /// <summary>
    /// Represents opportunity to sort array by method Quick sorting and Merge sort
    /// also executes binary finding
    /// </summary>
    public static class Helper
    {
        #region Quick sort

        /// <summary>
        /// Sorts source array by method 
        /// which called "Quick sorting"
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when array have null value</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty</exception>
        /// <param name="array">source array which must be sorted</param>
        /// <param name="comparison">method which compare two objects of the
        /// same type and returns a value indicating whether one object is less than, equal
        /// to, or greater than the other</param>
        public static void QuickSort<T>(T[] array, Comparison<T> comparison)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} haves null value");
            }

            if (array.Length < 1)
            {
                throw new ArgumentException($"{nameof(array)} is empty");
            }

            SortPartsArrays(array, 0, array.Length - 1, comparison);
        }

        /// <summary>
        /// Sorts source array by method 
        /// which called "Quick sorting"
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when array have null value</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty</exception>
        /// <param name="array">source array which must be sorted</param>
        /// <param name="comparison">method which compare two objects of the
        /// same type and returns a value indicating whether one object is less than, equal
        /// to, or greater than the other</param>
        public static void QuickSort<T>(T[] array, Comparer<T> comparison)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} haves null value");
            }

            if (array.Length < 1)
            {
                throw new ArgumentException($"{nameof(array)} is empty");
            }

            QuickSort(array, comparison.Compare);
        }

        /// <summary>
        /// Sorts source array by method 
        /// which called "Quick sorting"
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when array have null value</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty</exception>
        /// <param name="array">source array which must be sorted</param>
        /// <param name="comparison">method which compare two objects of the
        /// same type and returns a value indicating whether one object is less than, equal
        /// to, or greater than the other</param>
        public static void QuickSort<T>(T[] array, IComparer<T> comparison)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} haves null value");
            }

            if (array.Length < 1)
            {
                throw new ArgumentException($"{nameof(array)} is empty");
            }

            QuickSort(array, comparison.Compare);
        }

        /// <summary>
        /// Sorts source array by method 
        /// which called "Quick sorting"
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when array have null value</exception>
        /// <exception cref="ArgumentException">Thrown when array is empty</exception>
        /// <param name="array">source array which must be sorted</param>
        /// <param name="comparison">method which compare two objects of the
        /// same type and returns a value indicating whether one object is less than, equal
        /// to, or greater than the other</param>
        public static void QuickSort<T>(T[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException($"{nameof(array)} haves null value");
            }

            if (array.Length <= 1)
            {
                throw new ArgumentException($"{nameof(array)} is empty");
            }

            QuickSort(array, Comparer<T>.Default);
        }
        #endregion

        #region Merge sort
        /// <summary>
        /// Sorts array by merging
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when array have null value</exception>
        /// <param name="arr">source array which must be sorted</param>
        /// <returns>sorted source array</returns>
        public static T[] MergeSort<T>(T[] array, Comparison<T> comparison)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentNullException($"{nameof(array)} is empty");
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

            left = MergeSort(left.ToArray(), comparison).ToList();
            right = MergeSort(right.ToArray(), comparison).ToList();
            return Merge(left, right, comparison);
        }

        /// <summary>
        /// Sorts array by merging
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when array have null value</exception>
        /// <param name="arr">source array which must be sorted</param>
        /// <param name="comparer">method which compare two objects of the
        /// same type and returns a value indicating whether one object is less than, equal
        /// to, or greater than the other</param>
        /// <returns>sorted source array</returns>
        public static T[] MergeSort<T>(T[] array, Comparer<T> comparer)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentNullException($"{nameof(array)} is empty");
            }

            return MergeSort(array, comparer.Compare);
        }

        /// <summary>
        /// Sorts array by merging
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when array have null value</exception>
        /// <param name="arr">source array which must be sorted</param>
        /// <param name="comparer">method which compare two objects of the
        /// same type and returns a value indicating whether one object is less than, equal
        /// to, or greater than the other</param>
        /// <returns>sorted source array</returns>
        public static T[] MergeSort<T>(T[] array, IComparer<T> comparer)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentNullException($"{nameof(array)} is empty");
            }

            return MergeSort(array, comparer.Compare);
        }

        /// <summary>
        /// Divides source array into simple parts and sort 
        /// these parts by method Merge
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when array have null value</exception>
        /// <param name="arr">source array which must be sorted</param>
        /// <returns>sorted source array</returns>
        public static T[] MergeSort<T>(T[] array)
        {
            return MergeSort(array, Comparer<T>.Default);
        }
        #endregion

        #region Binary search
        /// <summary>
        /// binary search element in array
        /// </summary>
        /// <exception cref="ArgumentNullException">thrown when source array is empty</exception>
        /// <exception cref="ArgumentException">thrown when source array doesn't sorted</exception>
        /// <param name="sourceArray">sorted ascending array to find element</param>
        /// <param name="key">element to find</param>
        /// <param name="comparer">method which compare two objects of the
        /// same type and returns a value indicating whether one object is less than, equal
        /// to, or greater than the other. </param>
        /// <returns>index of element or null if file doesn't exist</returns>
        public static int? BinarySearch<T>(T[] sourceArray, T key, Comparison<T> comparer)
        {
            if (ReferenceEquals(sourceArray, null) || sourceArray.Length == 0)
            {
                throw new ArgumentNullException($"Array {sourceArray} is empty");
            }

            if (!IsSortedArray(sourceArray, comparer))
            {
                throw new ArgumentException($"Array {nameof(sourceArray)} must be sorted");
            }

            int middle, first = 0, last = sourceArray.Length - 1;

            while (first < last)
            {
                middle = first + ((last - first) / 2);

                if (comparer(key, sourceArray[middle]) <= 0)
                {
                    last = middle;
                }
                else
                {
                    first = middle + 1;
                }
            }

            if (comparer(sourceArray[last], key) == 0)
            {
                return last;
            }

            return null;
        }

        /// <summary>
        /// binary search element in array
        /// </summary>
        /// <exception cref="ArgumentNullException">thrown when source array is empty</exception>
        /// <exception cref="ArgumentException">thrown when source array doesn't sorted</exception>
        /// <param name="sourceArray">sorted ascending array to find element</param>
        /// <param name="key">element to find</param>
        /// <param name="comparer">method which compare two objects of the
        /// same type and returns a value indicating whether one object is less than, equal
        /// to, or greater than the other. </param>
        /// <returns>index of element or null if file doesn't exist</returns>
        public static int? BinarySearch<T>(T[] sourceArray, T key, IComparer<T> comparer)
        {
            if (sourceArray == null || sourceArray.Length == 0)
            {
                throw new ArgumentNullException($"Array {sourceArray} is empty");
            }

            if (!IsSortedArray(sourceArray, comparer.Compare))
            {
                throw new ArgumentException($"Array {nameof(sourceArray)} must be sorted");
            }

            return BinarySearch(sourceArray, key, comparer.Compare);
        }

        /// <summary>
        /// binary search element in array
        /// </summary>
        /// <exception cref="ArgumentNullException">thrown when source array is empty</exception>
        /// <exception cref="ArgumentException">thrown when source array doesn't sorted</exception>
        /// <param name="sourceArray">sorted ascending array to find element</param>
        /// <param name="key">element to find</param>
        /// <returns>index of element or null if file doesn't exist</returns>
        public static int? BinarySearch<T>(T[] sourceArray, T key)
        {
            if (ReferenceEquals(sourceArray, null) || sourceArray.Length == 0)
            {
                throw new ArgumentNullException($"Array {sourceArray} is empty");
            }

            if (!IsSortedArray(sourceArray, Comparer<T>.Default.Compare))
            {
                throw new ArgumentException($"Array {nameof(sourceArray)} must be sorted");
            }

            return BinarySearch(sourceArray, key, Comparer<T>.Default.Compare);
        }

        private static bool IsSortedArray<T>(T[] array, Comparison<T> comparer)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (comparer(array[i], array[i + 1]) > 0)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region private methods
        /// <summary>
        /// Sorts source array before and after pivot element
        /// </summary>
        /// <param name="array">source array</param>
        /// <param name="left">index of start</param>
        /// <param name="right">index of end</param>
        private static void SortPartsArrays<T>(T[] array, int left, int right, Comparison<T> comparison)
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
                if (comparison(array[first], pivot) <= 0)
                {
                    first++;
                }
                else if (comparison(array[second], pivot) > 0)
                {
                    second--;
                }
                else
                {
                    Swap(ref array[first], ref array[second]);
                }
            }

            if (comparison(array[second], pivot) <= 0)
            {
                Swap(ref array[left], ref array[right]);
                SortPartsArrays(array, left, right - 1, comparison);
            }
            else
            {
                SortPartsArrays(array, left, first - 1, comparison);
                SortPartsArrays(array, first, right, comparison);
            }
        }

        /// <summary>
        /// Method sorts two arrays and writes result 
        /// in the returned already sorted array
        /// </summary>
        /// <param name="left" >left part of array</param>
        /// <param name="right" >right part of array</param>
        /// <returns>sorted array</returns>
        private static T[] Merge<T>(List<T> left, List<T> right, Comparison<T> comparison)
        {
            List<T> result = new List<T>();
            while (left.Count > 0 && right.Count > 0)
            {
                if (comparison(left.First(), right.First()) <= 0)
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

        private static void Swap<T>(ref T first, ref T second)
        {
            T temp = first;
            first = second;
            second = temp;
        }
        #endregion
    }
}
