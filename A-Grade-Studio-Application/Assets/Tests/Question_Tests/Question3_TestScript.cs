using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Question3_TestScript
{
    // A Test behaves as an ordinary method
    [Test]
    [TestCase(5, 5)]
    [TestCase(15, 5)]
    [TestCase(15, 14)]
    [TestCase(15, 56)]
    [TestCase(50, 65)]
    [TestCase(1, 0)]
    [TestCase(5000, 7852)]
    public void Question3_TestArrayCreator(int arraySize, int numberOfPassingCars)
    {
        int[] carArray = CreateArrayOfPassingCars(arraySize, numberOfPassingCars);
        int passingCars = 0;
        int numEastCars = 0;

        for (int i = 0; i < carArray.Length; i++)
        {
            if (carArray[i] == 0)
                numEastCars++;
            else
                passingCars += numEastCars;
            Debug.Log($"index: {i}, Value: {carArray[i]}");
        }
        Assert.AreEqual(numberOfPassingCars, passingCars);
    }

    [Test]
    [TestCase(5, 5)]
    [TestCase(15, 5)]
    [TestCase(15, 15)]
    [TestCase(50, 65)]
    [TestCase(1, 0)]
    [TestCase(100000, 999901)]
    [TestCase(100000, 1)]
    public void TestSolution3(int arraySize, int numberOfPassingCars)
    {
        int[] carArray = CreateArrayOfPassingCars(arraySize, numberOfPassingCars);

        Solution3 Solution = new Solution3();
        int results = Solution.solution(carArray);

        Assert.AreEqual(results, numberOfPassingCars);

    }

    /// <summary>
    /// Creates an array of east and west cars with a specific number of passes.
    /// </summary>
    /// <param name="arraySize"></param>
    /// <param name="numberOfPassingCars"></param>
    /// <returns></returns>
    private int[] CreateArrayOfPassingCars(int arraySize, int numberOfPassingCars)
    {
        int[] carArray = new int[arraySize];
        for (int i = 0; i < arraySize; i++)
        {
            carArray[i] = 1;
        }
        int carPassCount = 0;
            
        int passes = 0;
        while (carPassCount < numberOfPassingCars)
        {
            
            for (int i = 1; i < carArray.Length - passes; i++)
            {
                carPassCount++;
                if(carPassCount == numberOfPassingCars)
                {
                    carArray[i] = 0;
                    return ReverseArray(carArray);
                }
            }
            if(carPassCount <= numberOfPassingCars)
            {
                carArray[carArray.Length - passes-1] = 0;
                carPassCount -= passes + 1;
            }

            passes++;
        }
        return ReverseArray(carArray);

    }

    private int[] ReverseArray(int[] array)
    {
        int[] reversedArray = new int[array.Length];
        for (int i = 0; i < reversedArray.Length; i++)
        {
            reversedArray[i] = array[array.Length - 1 - i];
        }
        return reversedArray;
    }
}
