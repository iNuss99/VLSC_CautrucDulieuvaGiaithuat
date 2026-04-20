using System;
using System.Collections.Generic; // Bat buoc khai bao de dung Queue co san
//Author : Do Minh Khoa - 2500114713
namespace DSA_Session08_Queue_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Khoi tao hang doi chua ten khach hang
            Queue<string> callQueue = new Queue<string>();

            Console.WriteLine("=== HE THONG TONG DAI CSKH ===");
            Console.WriteLine("- Nhap ten khach hang de dua vao hang doi.");
            Console.WriteLine("- de trong va nhan [ENTER] de nhan vien nhan cuoc goi.");
            Console.WriteLine("- Nhap 'exit' de dong he thong.\n");

            while (true)
            {
                Console.Write("Lenh (Ten KH / [Enter] / exit): ");
                string input = Console.ReadLine();

                // 1. Thoat chuong trinh
                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("He thong da tat.");
                    break;
                }

                // 2. Nhan Enter de Dequeue (Phuc vu khach)
                if (string.IsNullOrEmpty(input))
                {
                    if (callQueue.Count > 0)
                    {
                        string nextCustomer = callQueue.Dequeue();
                        Console.WriteLine(
                            $"\n>>> Dang ket noi nay... Xin chao anh/chi: {nextCustomer}!\n");
                    }
                    else
                    {
                        Console.WriteLine("\n>>> Tong dai dang ranh, " +
                            "khong co khach hang nao cho.\n");
                    }
                }
                // 3. Nhap ten de Enqueue (Khach vao hang doi)
                else
                {
                    callQueue.Enqueue(input);
                    Console.WriteLine($"[+] Da them khach hang '{input}' vao hang doi. " +
                        $"(Dang cho: {callQueue.Count})\n");
                }
            }
        }
    }
}