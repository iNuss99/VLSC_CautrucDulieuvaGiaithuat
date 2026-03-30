using System;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("--- Bài 1 ---");
        Console.Write("Nhập họ tên: ");
        string name = Console.ReadLine();
        Console.Write("Nhập mã số sinh viên: ");
        string mssv = Console.ReadLine();
        Console.WriteLine($"Chào mừng sinh viên {name} (MSSV: {mssv}) đến với lớp CTDL&GT!");
        Console.WriteLine();

        Console.WriteLine("--- Bài 2 ---");
        Console.Write("Nhập số a: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Nhập số b: ");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine($"Tổng: {a + b}");
        Console.WriteLine($"Hiệu: {a - b}");
        Console.WriteLine($"Tích: {a * b}");
        if (b != 0)
        {
            Console.WriteLine($"Thương: {(double)a / b}");
        }
        else
        {
            Console.WriteLine("Không thể chia cho 0!");
        }
        Console.WriteLine();

        Console.WriteLine("--- Bài 3 ---");
        int x = 5, y = 10;
        Console.WriteLine($"Truoc khi swap: x={x}, y={y}");
        int temp = x;
        x = y;
        y = temp;
        Console.WriteLine($"Sau khi swap: x={x}, y={y}");
    }
}