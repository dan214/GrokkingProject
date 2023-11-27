internal class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        int[] arr = new int[] { 1, 3, 2, 6, -1, 4, 1, 8, 2 };
        int k = 5;
        double[] result = contiguous(arr, k);
        for (int j = 0; j < result.Length; j++)
        {
            Console.WriteLine(result[j]);
        }
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
}