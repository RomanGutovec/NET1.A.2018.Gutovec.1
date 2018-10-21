using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET1.A._2018.Gutovec._1.Tests
{
    [TestClass]
    public class QuickSortTests
    {
        private Random rnd = new Random();
        [TestMethod]
        public void QuickSortingMethod_CompareTwoArraysWithLength10000000FilledRandomNumbers_SortedByMethodArraySortandQuickSorting_ReturnedSortedArray()
        {
            int capasity = 1000000;
            int[] expectedArray = new int[capasity];

            for (int i = 0; i < expectedArray.Length; i++)
            {
                expectedArray[i] = this.rnd.Next();
            }

            int[] actualArray = new int[capasity];
            Array.Copy(expectedArray, actualArray, expectedArray.Length);

            QuickSortMergeSortLib.SortQuickAndMerge.QuickSort(actualArray);
            Array.Sort(expectedArray);

            int index = this.rnd.Next(0, capasity);
            Assert.AreEqual(expectedArray[index], actualArray[index]);
        }

        [TestMethod]
        public void QuickSortingMethod_UnsortedArray_15_35_48_neg17_0_ReturnedArray_neg17_0_15_35_48()
        {
            int[] expectedArray = { -17, 0, 15, 35, 48 };
            int[] actualArray = { 15, 35, 48, -17, 0 };

            QuickSortMergeSortLib.SortQuickAndMerge.QuickSort(actualArray);

            for (int i = 0; i < expectedArray.Length; i++)
            {
                Assert.AreEqual(actualArray[i], expectedArray[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void QuickSortingMethod_ArrayEqualsNull_ThrowArgumentNullException()
        => QuickSortMergeSortLib.SortQuickAndMerge.QuickSort(null);
    }
}
