using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeScripts
{
    public class UniqueTriplets
    {
        public static List<int[]> findUniqueTriplets(int[] arr)
        {
            List<int[]> triplets = new List<int[]>();
            Array.Sort(arr);
            for (int i = 0;i<arr.Length - 2;i++)
            {
                if(i > 0 && arr[i]== arr[i-1])
                {
                    continue;
                }
                searchPair(arr, -arr[i], i + 1, triplets);
            }
             
            return triplets; 
        }

        private static void searchPair(int[] arr, int targetSum, int left, List<int[]> triplets )
        {
            int right = arr.Length - 1;
            while(left <= right)
            {
                int currentSum = arr[left] + arr[right];
                if (currentSum == targetSum)
                {
                    triplets.Add(new int[] {-targetSum,arr[left], arr[right]});
                    left++;
                    right--;
                }else if(currentSum > targetSum)
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }
        }
    }
}
