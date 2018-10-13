using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int[] expectedArray = new int[5];
            int[] actualArray = new int[expectedArray.Length];
            for (int i = 0; i < expectedArray.Length; i++)
            {
                expectedArray[i] = rnd.Next();
                actualArray[i] = expectedArray[i];
            }
            Array.Sort(expectedArray);
            actualArray = QuickSortMergeSortLib.MergeSort.MergeSorting(actualArray);
            Console.WriteLine("expected");
            foreach (var item in expectedArray)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("actual");
            foreach (var item in actualArray)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
