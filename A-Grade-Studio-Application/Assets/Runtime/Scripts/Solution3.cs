

public class Solution3
{
    /// <summary>
    /// This function will provide the number of passing cars in the Array given
    /// </summary>
    /// <param name="A"></param>
    /// <returns>number of east/west passing pairs</returns>
    public int solution(int[] A)
    {
        int passingCars = 0;
        int numEastCars = 0;

        for (int i = 0; i < A.Length; i++)
        {
            if(A[i] == 0)
                numEastCars++;
            else
            {
                passingCars += numEastCars;
               
            }
        }
        if (passingCars > 1000000000)
            return -1; //This code will never be active due to maximum array size of 100,000
        return passingCars;
    }

}
