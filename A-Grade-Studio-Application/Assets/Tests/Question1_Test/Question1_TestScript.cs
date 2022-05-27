using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Unity.Profiling;


public class Question1_TestScript
{
    // A Test behaves as an ordinary method
    [Test]
    [TestCase(450, 102)]
    [TestCase(100000, 100000)]
    [TestCase(50000, 1)]
    [TestCase(100000, 100001)]
    public void TestCreatedArrayForGapNumber(int arraySize, int missingNumber)
    {

        int[] testArray = CreateArrayWithGap(arraySize, missingNumber);

        int gapNumber = 1;
        List<int> intList = new List<int>();
        intList.AddRange(testArray);
        intList.Sort();

        for (int i = 0; i < intList.Count; i++)
        {
            if (intList[i] < 1)
                continue;
            if (gapNumber == intList[i])
                gapNumber++;
            else
                break;
        }


        Debug.Log($"Array Size: {arraySize}, Missing Number: {missingNumber}, Found Number: {gapNumber}");

        //for (int i = 0; i < intList.Count; i++)
        //{
        //    if (intList[i]<1 || intList[i] > arraySize)
        //    {
        //        Debug.Log($"{intList[i]}");
        //    }

        //}

        Assert.AreEqual(gapNumber, missingNumber);

    }

    [Test]
    [TestCase(450, 102)]
    [TestCase(100000, 100000)]
    [TestCase(50000, 1)]
    [TestCase(100000, 100001)]
    public void TestSolution1(int arraySize, int missingNumber)
    {
        System.Diagnostics.Stopwatch executionTime = new System.Diagnostics.Stopwatch();
        executionTime.Start();
        int[] testArray = CreateArrayWithGap(arraySize, missingNumber);
        executionTime.Stop();

        Solution1 solution1 = new Solution1();

        int solutionNumber = solution1.Solution(testArray);


        Assert.AreEqual(solutionNumber, missingNumber);
        Debug.Log($"Execution Time: {executionTime.ElapsedMilliseconds.ToString()}");
    }

    /// <summary>
    /// Function creates an array with the lowest missing number called gap
    /// </summary>
    /// <param name="size">Size of the array of integers</param>
    /// <param name="gap">Lowest missing integer greater than 0</param>
    /// <returns></returns>
    private int[] CreateArrayWithGap(int size, int gap)
    {
        if (size > 100000)
            Debug.LogError("Array size cannot be larger than 100,000");
        if (gap > size + 1)
            Debug.LogError("gap location cannot be larger than the array size");
        int[] intArray = new int[size];

        //Create gap
        int index;
        for (index = 0; index < (gap - 1); index++)
        {
            intArray[index] = index + 1;
        }

        //Fill remaining array
        for (; index < intArray.Length; index++)
        {
            int number;
            do
            {
                number = Random.Range(-1000000, 1000000);
            } while (number == gap);
            intArray[index] = number;
        }

        List<int> numberList = new List<int>();
        numberList.AddRange(intArray);
        for (int i = 0; i < intArray.Length; i++)
        {
            var randomIndex = Random.Range(0, numberList.Count);
            intArray[i] = numberList[randomIndex];
            numberList.RemoveAt(randomIndex);
        }

        return intArray;

    }

}
