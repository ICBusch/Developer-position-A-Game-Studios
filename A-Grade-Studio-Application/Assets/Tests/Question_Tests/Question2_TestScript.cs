using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Question2_TestScript
{
    // A Test behaves as an ordinary method
    [Test]
    [TestCase(5, 8, 6)]
    [TestCase(6, 25, -1)]
    [TestCase(7, 25, 15)]
    [TestCase(1,1,0)]
    [TestCase(10000, 100000, 25000)]
    [TestCase(5, 10, 9)]
    public void TestArrayCreator(int riverWidth, int arrayLength, int expectedCrossingTime)
    {
        int[] riverArray = CreateLeavesArraywithCrossTime(riverWidth, arrayLength, expectedCrossingTime);

        if(expectedCrossingTime >= riverWidth)
            Assert.AreEqual(riverArray[expectedCrossingTime], riverWidth);
        if(expectedCrossingTime < riverWidth-1)
        {
            CollectionAssert.DoesNotContain(riverArray, riverWidth);
            
        }
       
    }

    [Test]
    [TestCase(5, 8, 6)]
    [TestCase(6, 25, -1)]
    [TestCase(7, 25, 15)]
    [TestCase(1, 1, 0)]
    [TestCase(10000, 100000, 25000)]
    [TestCase(5, 10, 9)]
    public void TestSolution2(int riverWidth, int arrayLength, int expectedCrossingTime)
    {
        int[] riverArray = CreateLeavesArraywithCrossTime(riverWidth, arrayLength, expectedCrossingTime);
        Solution2 Solution = new Solution2();
        int earliestTimeToCross = Solution.solution(riverWidth, riverArray);

        Assert.AreEqual(expectedCrossingTime, earliestTimeToCross);
    }

    private int[] CreateLeavesArraywithCrossTime(int riverWidth, int arrayLength, int expectedCrossingTime)
    {
        int[] leafArray = new int[arrayLength];



        for (int i = 0; i < leafArray.Length; i++)
        {
            if (i < expectedCrossingTime)
            {
                if (i < riverWidth - 1)
                    leafArray[i] = i + 1;
                else
                    leafArray[i] = Random.Range(1, riverWidth);
            }
            else if (i == expectedCrossingTime)
            {
                leafArray[i] = riverWidth;
            }
            else
                leafArray[i] = Random.Range(1, riverWidth);
        }
        return leafArray;
    }

}
