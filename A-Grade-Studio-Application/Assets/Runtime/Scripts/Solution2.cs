

public class Solution2
{
    /// <summary>
    /// A non-empty array of integers A of size N indicate where a leaf falls on a river of width X each second.  This function determines the earliest time when the leaves will transverse the river.
    /// </summary>
    /// <param name="X">River Width</param>
    /// <param name="A">Array of leaf positions over time</param>
    /// <returns>Earliest time to cross in seconds</returns>
    public int solution(int X, int[] A)
    {
        bool[] bitMap = new bool[X];
        int leafPathCount = 0;
        for (int i = 0; i < A.Length; i++)
        {
            if (bitMap[A[i]-1]==false)
            {
                bitMap[A[i] - 1] = true;
                leafPathCount++;
            }

            if (leafPathCount == X)
                return i;
        }
        return -1;

    }
}
