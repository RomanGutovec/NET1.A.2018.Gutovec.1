using System;
using NUnit.Framework;

namespace NET1.A._2018.Gutovec._1.NUnitTests
{
    public class QuickSortNUnitTests
    {
        private static Random rnd = new Random();
        [Test]
        public void QuickSortingMethod_UnsortedArray_neg200_neg600_118_103_125_ReturnedArray_neg600_neg200_103_118_125()
        {
            int[] expectedArray = { -600, -200, 103, 118, 125 };
            int[] actualArray = { -200, -600, 118, 103, 125 };

            QuickSortMergeSortLib.SortQuickAndMerge.QuickSort(actualArray);

            for (int i = 0; i < expectedArray.Length; i++)
            {
                Assert.AreEqual(expectedArray[i], actualArray[i]);
            }
        }

        [Test]
        public void QuickSortingMethod_CompareTwoArraysWithLength10000000FilledRandomNumbers_SortedByMethodArraySortandQuickSorting_ReturnedSortedArray()
        {
            int capasity = 1000000;
            int[] expectedArray = new int[capasity];

            for (int i = 0; i < expectedArray.Length; i++)
            {
                expectedArray[i] = rnd.Next();
            }

            int[] actualArray = new int[capasity];
            Array.Copy(expectedArray, actualArray, expectedArray.Length);

            QuickSortMergeSortLib.SortQuickAndMerge.QuickSort(actualArray);
            Array.Sort(expectedArray);

            int index = rnd.Next(0, capasity);
            Assert.AreEqual(expectedArray[index], actualArray[index]);
        }

        [Test]
        public void MergeSortingMethod_WithNull_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => QuickSortMergeSortLib.SortQuickAndMerge.QuickSort(null));
    }
}
