

public class Solution1
{
    /// <summary>
    /// Finds the smallest missing number from the array that is greater than 0
    /// </summary>
    /// <param name="A"></param>
    /// <returns>smallest missing number</returns>    
    public int Solution(int[] A)
    {
        bool[] bitMap = new bool[A.Length];
        //Create bit map
        for (int i = 0; i < A.Length; i++)
        {
            if (A[i] > 0 && A[i] <= A.Length)
                bitMap[A[i] - 1] = true;
        }
        //Test bit map for first missing number
        int missingNumber = 1;
        for (int i = 0; i < bitMap.Length; i++)
        {
            if (bitMap[i] == true)
                missingNumber++;
            else
                return missingNumber;
        }
        return missingNumber;
    }
}
