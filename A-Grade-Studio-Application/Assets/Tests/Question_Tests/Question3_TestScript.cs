using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Question3_TestScript
{
    // A Test behaves as an ordinary method
    [Test]
    [TestCase(5,5)]
    [TestCase(15, 15)]
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
        int carPassCount = numberOfPassingCars;
        int passes = 1;
        while (carPassCount >0)
        {
            for (int i = arraySize - 1; i >= passes; i--)
            {
                
                if (carPassCount == 0)
                {
                    carArray[i-1] = 0;
                    break;
                }
                carPassCount--;
            }
            if (carPassCount > 0)
                carArray[passes-1] = 0;
            passes++;
        }
        return carArray;
        
    }
}
