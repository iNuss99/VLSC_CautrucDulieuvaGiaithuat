using System;
using System.Diagnostics;

class DoMinhKhoa
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int n = 10000000; // 10 triệu phần tử
        int[] arr = new int[n];

        // Tạo mảng đã sắp xếp
        for (int i = 0; i < n; i++)
            arr[i] = i * 2;

        int x = arr[n - 1]; // phần tử cuối (worst case)

        Stopwatch sw = new Stopwatch();

        // Linear Search
        sw.Start();
        int idx1 = LinearSearch(arr, x);
        sw.Stop();
        Console.WriteLine($"Linear Search: Index = {idx1}, Time = {sw.Elapsed.TotalMilliseconds} ms");

        // Binary Search (Đệ quy)
        sw.Restart();
        int idx2 = BinarySearchRecursive(arr, 0, arr.Length - 1, x);
        sw.Stop();
        Console.WriteLine($"Binary Search (Recursive): Index = {idx2}, Time = {sw.Elapsed.TotalMilliseconds} ms");

        // Nhận xét
        Console.WriteLine("\\nNhan xet:");
        Console.WriteLine("- Linear Search: Thoi gian tang tuyen tinh theo n (O(n))");
        Console.WriteLine("- Binary Search: Tang rat cham theo log(n) (O(log n))");
        Console.WriteLine("=> Binary Search nhanh hon rat nhieu khi du lieu lon");
    }

    static int LinearSearch(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
            if (arr[i] == target)
                return i;
        return -1;
    }

    static int BinarySearchRecursive(int[] arr, int left, int right, int target)
    {
        if (left > right) return -1;

        int mid = (left + right) / 2;

        if (arr[mid] == target)
            return mid;
        else if (arr[mid] > target)
            return BinarySearchRecursive(arr, left, mid - 1, target);
        else
            return BinarySearchRecursive(arr, mid + 1, right, target);
    }
}