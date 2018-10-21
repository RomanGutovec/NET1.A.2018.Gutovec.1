using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET1.A._2018.Gutovec._1.Tests
{
    [TestClass]
    public class MergeSortTests
    {
        private static Random rnd = new Random();

        [TestMethod]
        public void MergeSortingMethod_UnsortedArray_17_neg15_0_36_1500_ReturnedArray_neg15_0_17_36_1500()
        {
            int[] expectedArray = { -15, 0, 17, 36, 1500 };
            int[] actualArray = { 17, -15, 0, 36, 1500 };

            actualArray = QuickSortMergeSortLib.SortQuickAndMerge.MergeSort(actualArray);

            for (int i = 0; i < expectedArray.Length; i++)
            {
                Assert.AreEqual(expectedArray[i], actualArray[i]);
            }
        }

        [TestMethod]
        public void MergeSortingMethod_CompareTwoArraysWithLength10000000FilledRandomNumbers_SortedByMethodArraySortandQuickSorting_ReturnedSortedArray()
        {
            int capasity = 100000;
            int[] expectedArray = new int[capasity];

            for (int i = 0; i < expectedArray.Length; i++)
            {
                expectedArray[i] = rnd.Next();
            }

            int[] actualArray = new int[capasity];
            Array.Copy(expectedArray, actualArray, expectedArray.Length);

            actualArray = QuickSortMergeSortLib.SortQuickAndMerge.MergeSort(actualArray);
            Array.Sort(expectedArray);

            int index = rnd.Next(0, capasity);
            Assert.AreEqual(expectedArray[index], actualArray[index]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSortingMethod_ArrayEqualsNull_ThrowArgumentNullException()
                => QuickSortMergeSortLib.SortQuickAndMerge.MergeSort(null);
    }
}
