using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickSortMergeSortLib
{
    /// <summary>
    /// Sorting array by merging of 
    /// consisting parts
    /// </summary>
    public static class MergeSort
    {
        /// <summary>
        /// Divides source array into simple parts and sort 
        /// these parts by method Merge
        /// </summary>
        /// <param name="arr">source array which must be sorted</param>
        /// <returns>sorted source array</returns>
        public static int[] MergeSorting(int[] arr)
        {
            if (arr == null)
            {
                throw new ArgumentNullException();
            }

            if (arr.Length == 1)
            {
                return arr;
            }

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 > 0)
                {
                    left.Add(arr[i]);
                    Console.WriteLine("Left added {0}", arr[i]);
                }
                else
                {
                    right.Add(arr[i]);
                    Console.WriteLine("Right added {0}", arr[i]);
                }
            }

            left = MergeSorting(left.ToArray()).ToList();
            right = MergeSorting(right.ToArray()).ToList();
            return Merge(left, right);
        }

        /// <summary>
        /// Method sorts two arrays and writes result 
        /// in the returned already sorted array
        /// </summary>
        /// <param name="left" >left part of array</param>
        /// <param name="right" >right part of array</param>
        /// <returns>sorted array</returns>
        private static int[] Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();
            while (left.Count > 0 && right.Count > 0)
            {
                if (left.First() <= right.First())
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
    }
}
