using System;

namespace DSA_Session05_Basics;

class Program
{
    // Do Minh Khoa
    // 2500114713
    static void Main(string[] args)
    {
        // Bai 1; Hoan doi 2 so khong dung bien tam (Toan hoc)
        // nguoi dunng co the nhap 2 so tu ban phimm va sau do thuc hien  hoa doi
        Console.WriteLine("Bai 1: Hoan doi 2 so khong dung bien tam");
        Console.Write("Nhap so a: ");
        // Doc chuoi nhap vao tu ban phim va luu vao bien inputA
        string inputA = Console.ReadLine();

        int a; 
        while (!int.TryParse(inputA, out a))
        {
            Console.Write("So a khong hop le. Vui lonf nhap lai: ");
            inputA = Console.ReadLine();
        }
        
        Console.Write("Nhap so b: ");
        // Doc chuoi nhap vao tu ban phim ca luu vao bien inputB
        string inputB = Console.ReadLine();
        int b;
        while (!int.TryParse(inputB, out b))
        {
            Console.Write("So b khong hop le. Vui long nhap lai: ");
            inputB = Console.ReadLine();
        }

        // Thuc hien hoan doi
        a = a + b;
        b = a - b;
        a = a - b;

        Console.WriteLine($"a={a}, b={b}");

        Console.WriteLine("=========================");
        Console.WriteLine("Bai 2: Ve hinh vuong dau sao (n x n)");

        // nguoi dung co the nhap kich thuoc n tu ban phim
        // va sau do in ra hinh vuong tuong ung
        Console.Write("Nhap kich thuoc n cua hinh vuong: ");
        string inputN = Console.ReadLine();
        int n;
        // Sua tu IndexOutOfRangeException thanh inputN
        while (!int.TryParse(inputN, out n) || n <= 0)
        {
            Console.Write("Kich thuoc n khong hop le. Vui long nhap lai: ");
            inputN = Console.ReadLine();
        }

        // Dung 2 vong lap for de in ra hinh vuong dau sao
        for(int i = 0; i < n; i++){
            for(int j = 0; j < n; j++)
            {
                Console.Write("* ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("================");
        Console.WriteLine("Bai 3: In bang cuu chuong ( 2 den 9)");
        for (int i = 2 ; i <= 9; i++)
        {
            Console.WriteLine($"---Bang cuu chuong {i} ---");
            // Sua i <= 10 thanh j <= 10 de tranh vong lap vo tan
            for (int j = 1; j <= 10; j++)
            {
                Console.WriteLine($"{i} x {j} = {i * j}");
            }
        }
    } 
} 