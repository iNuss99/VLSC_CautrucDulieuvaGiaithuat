using System;

class Program
{
    static int TinhTong(int n)
    {
        if (n <= 1) return n;
        return n + TinhTong(n - 1);
    }

    static long GiaiThuaDeQuy(int n)
    {
        if (n <= 1) return 1;
        return n * GiaiThuaDeQuy(n - 1);
    }

    static long GiaiThuaVongLap(int n)
    {
        long ketQua = 1;
        for (int i = 1; i <= n; i++)
        {
            ketQua *= i;
        }
        return ketQua;
    }

    static long GetFibonacci(int n)
    {
        if (n <= 0) return 0;
        if (n == 1) return 1;

        long a = 0, b = 1, temp;

        for (int i = 2; i <= n; i++)
        {
            temp = a + b;
            a = b;
            b = temp;
        }

        return b;
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.Write("Nhập n: ");
        if (int.TryParse(Console.ReadLine(), out int n) && n >= 0)
        {
            Console.WriteLine($"--- Kết quả cho n = {n} ---");
            Console.WriteLine($"Tổng S (Đệ quy): {TinhTong(n)}");
            Console.WriteLine($"Giai thừa (Đệ quy): {GiaiThuaDeQuy(n)}");
            Console.WriteLine($"Giai thừa (Vòng lặp): {GiaiThuaVongLap(n)}");
            Console.WriteLine($"Số Fibonacci thứ {n}: {GetFibonacci(n)}");
        }
        else
        {
            Console.WriteLine("Vui lòng nhập số nguyên không âm hợp lệ!");
        }

        Console.ReadKey();
    }
}