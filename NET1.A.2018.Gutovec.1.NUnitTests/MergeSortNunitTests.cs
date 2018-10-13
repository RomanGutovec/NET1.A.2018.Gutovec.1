namespace NET1.A._2018.Gutovec._1.NUnitTests
{
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
    [TestFixture]
    public class MergeSortNunitTests
    {
        private static Random rnd = new Random();
        [Test]
        public void MergeSortingMethod_UnsortedArray_neg100_neg500_18_3_25_ReturnedArray_neg100_neg500_3_18_25()
        {
            ////Arrange
            int[] expectedArray = { -500, -100, 3, 18, 25 };
            int[] actualArray = { -100, -500, 18, 3, 25 };

            ////Act
            actualArray = QuickSortMergeSortLib.MergeSort.MergeSorting(actualArray);

            ////Assert
            for (int i = 0; i < expectedArray.Length; i++)
            {
                Assert.AreEqual(expectedArray[i], actualArray[i]);
            }
        }

        [Test]
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

        public void MergeSortingMethod_WithNull_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => QuickSortMergeSortLib.MergeSort.MergeSorting(null));
    }
}
