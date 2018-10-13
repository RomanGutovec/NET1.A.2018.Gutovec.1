using System;

namespace QuickSortMergeSortLib
{
    /// <summary>
    /// Sorts source array by method 
    /// which called "Quick sorting"
    /// </summary>
    public class QuickSort
    {
        /// <summary>
        /// Sorts source array by method 
        /// which called "Quick sorting"
        /// </summary>
        /// <param name="array">source array which must be sorted</param>
        public static void Quicksorting(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (array.Length > 1)
            {
                SortingPartsArrays(array, 0, array.Length - 1);
            }
        }
        /// <summary>
        /// Sorts source array before and after pivot element
        /// </summary>
        /// <param name="array">source array</param>
        /// <param name="left">index of start</param>
        /// <param name="right">index of end</param>
        private static void SortingPartsArrays(int[] array, int left, int right)
        {
            if (left == right)
            {
                return;
            }

            int i = left + 1;
            int j = right;
            int pivot = array[left];
            while (i < j)
            {
                if (array[i] <= pivot)
                {
                    i++;
                }
                else if (array[j] > pivot)
                {
                    j--;
                }
                else
                { //// swap i и j element
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            ////case when i=j
            ////when max
            if (array[j] <= pivot)
            {
                int temp = array[left];
                array[left] = array[right];
                array[right] = temp;
                SortingPartsArrays(array, left, right - 1);
            }
            else
            {
                SortingPartsArrays(array, left, i - 1);
                SortingPartsArrays(array, i, right);
            }
        }
    }
}
