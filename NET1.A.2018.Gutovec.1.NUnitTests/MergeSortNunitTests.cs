using System;
using NUnit.Framework;

namespace NET1.A._2018.Gutovec._1.NUnitTests
{
    [TestFixture]
    public class MergeSortNunitTests
    {
        private static Random rnd = new Random();
        [Test]
        public void MergeSortingMethod_UnsortedArray_neg100_neg500_18_3_25_ReturnedArray_neg100_neg500_3_18_25()
        {
            int[] expectedArray = { -500, -100, 3, 18, 25 };
            int[] actualArray = { -100, -500, 18, 3, 25 };

            actualArray = Algorithms.SortQuickAndMerge<int>.MergeSort(actualArray);

            for (int i = 0; i < expectedArray.Length; i++)
            {
                Assert.AreEqual(expectedArray[i], actualArray[i]);
            }
        }

        [Test]
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

            actualArray = Algorithms.SortQuickAndMerge<int>.MergeSort(actualArray);
            Array.Sort(expectedArray);

            int index = rnd.Next(0, capasity);
            Assert.AreEqual(expectedArray[index], actualArray[index]);
        }

        [Test]
        public void MergeSortingMethod_WithNull_ThrowArgumentNullException()
            => Assert.Throws<ArgumentNullException>(() => Algorithms.SortQuickAndMerge<int>.MergeSort(null));
    }
}
