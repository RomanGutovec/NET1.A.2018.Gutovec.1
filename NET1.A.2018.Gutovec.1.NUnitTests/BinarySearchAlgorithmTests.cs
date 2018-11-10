using System;
using NUnit.Framework;

namespace NET1.A._2018.Gutovec._1.NUnitTests
{
    [TestFixture]
    public class BinarySearchAlgorithmTests
    {
        [TestCase(new int[] { 1, 5, 7, 9, 9, 15 }, 9, ExpectedResult = 3)]
        [TestCase(new int[] { 1, 3, 5, 7, 9, 15 }, 3, ExpectedResult = 1)]
        [TestCase(new int[] { -1, 1, 1, 156, 160, 950 }, 1, ExpectedResult = 1)]
        [TestCase(new int[] { -19, -18, 20, 20 }, 20, ExpectedResult = 2)]
        [TestCase(new int[] { 13, 15, 18, 36 }, 29, ExpectedResult = null)]
        [TestCase(new int[] { -78, -35, 0, 16, 18 }, 17, ExpectedResult = null)]
        public int? BinarySearchTest_InputSortedArrayAndKeyForFinding_ExpectIndexOfKeyorNull(int[] array, int key)
           => Algorithms.BinarySearchAlgorithm<int>.BinarySearch(array, key);

        [TestCase(null)]
        [TestCase(new int[0])]
        public void BinarySearchTest_InputEmptyArray_ArgumentNullException(int[] array)
            => Assert.Throws<ArgumentNullException>(() => Algorithms.BinarySearchAlgorithm<int>.BinarySearch(array, 0));

        [TestCase(new int[] { 1, 5, 9, 7, 9, 15 })]
        [TestCase(new int[] { 0, 0, 0, 0, 2, 1 })]
        public void BinarySearchTest_InputUnsortedArray_ArgumentException(int[] array)
            => Assert.Throws<ArgumentException>(() => Algorithms.BinarySearchAlgorithm<int>.BinarySearch(array, 0));
    }
}
