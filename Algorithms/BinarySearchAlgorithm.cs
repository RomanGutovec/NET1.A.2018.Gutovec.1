using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    /// <summary>
    /// Represents binary search index of element in array
    /// </summary>
    /// <typeparam name="T">the type of the object to find index of element</typeparam>
    public static class BinarySearchAlgorithm<T>
    {
        /// <summary>
        /// binary search element in array
        /// </summary>
        /// <exception cref="ArgumentNullException">thrown when source array is empty</exception>
        /// <exception cref="ArgumentException">thrown when source array doesn't sorted</exception>
        /// <param name="sourceArray">sorted ascending array to find element</param>
        /// <param name="key">element to find</param>
        /// <param name="comparer">method whitch compare two objects of the
        //same type and returns a value indicating whether one object is less than, equal
        //to, or greater than the other. </param>
        /// <returns>index of element or null if file doesn't exist</returns>
        public static int? BinarySearch(T[] sourceArray, T key, Comparison<T> comparer)
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
        /// <param name="comparer">method whitch compare two objects of the
        //same type and returns a value indicating whether one object is less than, equal
        //to, or greater than the other. </param>
        /// <returns>index of element or null if file doesn't exist</returns>
        public static int? BinarySearch(T[] sourceArray, T key, IComparer<T> comparer)
        {
            if (ReferenceEquals(sourceArray, null) || sourceArray.Length == 0)
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
        public static int? BinarySearch(T[] sourceArray, T key)
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

        private static bool IsSortedArray(T[] array, Comparison<T> comparer)
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
    }
}
