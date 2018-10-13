namespace NET1.A._2018.Gutovec._1.Tests
{
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
    [TestClass]
    public class MergeSortTests
    {
        private static Random rnd = new Random();

        [TestMethod]
        public void MergeSortingMethod_UnsortedArray_17_neg15_0_36_1500_ReturnedArray_neg15_0_17_36_1500()
        {
            ////Arrange
            int[] expectedArray = { -15, 0, 17, 36, 1500 };
            int[] actualArray = { 17, -15, 0, 36, 1500 };

            ////Act
            actualArray = QuickSortMergeSortLib.MergeSort.MergeSorting(actualArray);

            ////Assert
            for (int i = 0; i < expectedArray.Length; i++)
            {
                Assert.AreEqual(expectedArray[i], actualArray[i]);
            }
        }

        [TestMethod]
        public void MergeSortingMethod_CompareTwoArraysWithLength10000000FilledRandomNumbers_SortedByMethodArraySortandQuickSorting_ReturnedSortedArray()
        {
            ////Arrange
            int capasity = 1000000;
            int[] expectedArray = new int[capasity];

            for (int i = 0; i < expectedArray.Length; i++)
            {
                expectedArray[i] = rnd.Next();
            }

            int[] actualArray = new int[capasity];
            Array.Copy(expectedArray, actualArray, expectedArray.Length);

            ////Act
            actualArray = QuickSortMergeSortLib.MergeSort.MergeSorting(actualArray);
            Array.Sort(expectedArray);

            ////Assert
            int index = rnd.Next(0, capasity);
            Assert.AreEqual(expectedArray[index], actualArray[index]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MergeSortingMethod_ArrayEqualsNull_ThrowArgumentNullException()
                => QuickSortMergeSortLib.MergeSort.MergeSorting(null);
    }
}
