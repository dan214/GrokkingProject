using CodeScripts;
using System.Runtime.CompilerServices;

internal class Program
{
    public static void Main(string[] args)
    {
        //Contiguous Array
        /*    int[] arr = new int[] { 1, 3, 2, 6, -1, 4, 1, 8, 2 };
           int k = 5;
           double[] result = contiguous(arr, k);
           for (int j = 0; j < result.Length; j++)
           {
               Console.WriteLine(result[j]);
           } */

        //Maximum sum
        /*    int[] arr2 = new int[] { 2, 3, 4, 1, 2 };
           int k2 = 2;
           int result = maximumSum(arr2, k2);
           Console.WriteLine(result); */

        //Smallest SubArray
        //string str = "cbbebi";
        //int k2 = 3;
        //int result = longestSubstring(str, k2);
        //Console.WriteLine(result);

        //two pointers
        //int[] arr = {2,5,9,11};
        //int target = 11;
        //int[] result = pairArray(arr, target);
        //for (int j = 0; j < result.Length; j++)
        //{
        //    Console.WriteLine(result[j]);
        //}

        //Remove duplicates
        //int[] arr = { 2, 11, 2, 2, 1 };
        ////int target = 11;
        ////Console.WriteLine(removeDuplicates(arr));
        //int result = removeKeyInPlace(arr, 2);
        //Console.WriteLine(result);
        ////for (int j = 0; j < result.Length; j++)
        ////{
        ////    Console.WriteLine(result[j]);
        ////}

        //Squaring a sorted array
        //int[] arr = new int[] { -3, -1, 0, 1, 2 };
        //int[] result = squareSorted(arr);

        var result = UniqueTriplets.findUniqueTriplets(new int[] { -3, 0, 1, 2, -1, 1, -2 });
        Console.WriteLine(result);
    }

    private static double[] contiguous(int[] arr, int k)
    {
        double[] result = new double[arr.Length - k + 1];
        int windowStart = 0;
        double windowResult = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            windowResult += arr[i];
            if (i >= k - 1)
            {
                result[windowStart] = windowResult / 5;
                windowResult -= arr[windowStart];
                windowStart++;
            }
        }
        return result;
    }

    private static int maximumSum(int[] arr, int k)
    {
        int windowStart = 0;
        int windowResult = 0;
        int maximumSum = 0;
        for (int windowEnd = 0; windowEnd < arr.Length; windowEnd++)
        {
            windowResult += arr[windowEnd];
            if (windowEnd >= k - 1)
            {
                maximumSum = (windowResult > maximumSum) ? windowResult : maximumSum;
                windowResult -= arr[windowStart];
                windowStart++;
            }

        }
        return maximumSum;
    }

    private static int smallestSubArray(int[] arr, int s)
    {
        int windowStart = 0;
        int windowResult = 0;
        int smallestLength = 9999999;

        for (int windowEnd = 0; windowEnd < arr.Length; windowEnd++)
        {
            windowResult += arr[windowEnd];

            if (windowResult >= s)
            {
                smallestLength = (windowEnd - windowStart + 1 < smallestLength) ? windowEnd - windowStart + 1 : smallestLength;

                windowResult -= arr[windowStart];

                windowStart++;
            }
        }
        return 0;
    }

    private static int longestSubstring(string str, int K)
    {
        Dictionary<char, int> chars = new Dictionary<char, int>();
        int maxLength = 0;
        int windowStart = 0;
        for (int windowEnd = 0; windowEnd < str.Length; windowEnd++)
        {

            if (!chars.ContainsKey(str[windowEnd]))
            {
                chars.Add(str[windowEnd], 1);
            }
            else
            {
                chars[str[windowEnd]] = chars[str[windowEnd]] + 1;
            }

            if (chars.Count > K)
            {
                maxLength = (maxLength < (windowEnd - windowStart)) ? (windowEnd - windowStart) : maxLength;
                chars[str[windowStart]] -= 1;
                if (chars[str[windowStart]] == 0)
                {
                    chars.Remove(str[windowStart]);
                }
                windowStart++;
            }
        }
        return maxLength;
    }

    private static int[] pairArray(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left < right)
        {
            if (arr[left] + arr[right] > target)
            {
                right--;
            }else if(arr[left] + arr[right] < target)
            {
                left++;
            }
            else
            {
                return new int[] {left, right };
            };
        }
        return new int[] {0,0};
    }

    private static int removeDuplicates(int[] arr)
    {
        HashSet<int> result = new HashSet<int>();

        int fast = 0, slow = 0;

        while (fast <= arr.Length - 1)
        {
            if (!result.Contains(arr[fast]))
            {
                result.Add(arr[fast]);
                arr[slow] = arr[fast];
                slow++;
            }
            fast++;
        }
        return slow;
    }

    private static int removeKeyInPlace(int[] arr, int key)
    {
        int slow = 0;
        for(int fast = 0; fast <= arr.Length -1;fast++)
        {
            if (arr[fast] != key)
            {
                arr[slow] = arr[fast];
                slow++;
            }
        }
        return slow;
    }

    private static int[] squareSorted(int[] arr)
    {
        int[] result = new int[arr.Length];
        int low = 0;
        int high = arr.Length - 1;
        int resultCount = arr.Length - 1;
        while (low <= high)
        {
            int lowSquared = arr[low] * arr[low];
            int highSquared = arr[high] * arr[high];

            if (highSquared > lowSquared)
            {
                result[resultCount] = highSquared;
                high--;
            }
            else
            {
                result[resultCount] = lowSquared;
                low++;
            }
            resultCount--;
            
        }

        foreach(var i in result)
        {
            Console.WriteLine(i);
        }

        return result;
    }


}

//Time complexity: 0(n)
//Space complexity: 0(n)