using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
//Author: Do Minh Khoa - 2500114713
namespace DSA_Session08_Queue_03
{
    // 1. Xay dung Class doi tuong PrintJob
    public class PrintJob
    {
        public string TenTaiLieu { get; set; }
        public int SoTrang { get; set; }

        public PrintJob(string ten, int trang)
        {
            TenTaiLieu = ten;
            SoTrang = trang;
        }
    }

    class Program
    {
        // Khoi tao hang doi va mot "o khoa" de bao ve luong an toan (Thread-safe)
        static Queue<PrintJob> printQueue = new Queue<PrintJob>();
        static readonly object _lock = new object();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== HE THONG DIEU PHOI MAY IN MANG LAN ===");
            Console.WriteLine("Go ten tai lieu de in. Nhap 'exit' de tat may.");

            // Kich hoat luong chay ngam cua May in (Background Worker)
            Task.Run(() => PrinterEngine());

            // Luong chinh: Lang nghe nguoi dung nhap lieu lien tuc
            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToLower() == "exit") break;

                // Gia lap so trang ngau nhien tu 1 den 20 trang
                int pages = new Random().Next(1, 20);
                PrintJob newJob = new PrintJob(input, pages);

                // KHOA Queue lai de day du lieu vao an toan
                lock (_lock)
                {
                    printQueue.Enqueue(newJob);
                }
                Console.WriteLine(
                    $"[HE THONG] Da nhan lenh in: '{newJob.TenTaiLieu}'. Dang cho toi luot...\n");
            }
        }

        // 2. Co may in chay ngam doc lap
        static void PrinterEngine()
        {
            while (true)
            {
                PrintJob jobToPrint = null;

                // KHOA Queue lai de lay du lieu ra an toan
                lock (_lock)
                {
                    if (printQueue.Count > 0)
                    {
                        jobToPrint = printQueue.Dequeue();
                    }
                }

                // Neu co tai lieu can in
                if (jobToPrint != null)
                {
                    Console.WriteLine(
                        $"\n[MAY IN DANG CHAY] Dang in tai lieu '{jobToPrint.TenTaiLieu}'...");
                    Console.WriteLine($"[MAY IN] Thoi gian in du kien: {jobToPrint.SoTrang} giay.");

                    // Gia lap thoi gian may in hoat dong (Moi trang ton 1s, de Demo nhanh thay fixed 3s)
                    Thread.Sleep(3000);

                    Console.WriteLine($"[MAY IN] Hoan tat in tai lieu '{jobToPrint.TenTaiLieu}'.\n");
                }
                else
                {
                    // Tranh viec may in kiem tra qua nhanh lam nong CPU khi ranh roi
                    Thread.Sleep(1000);
                }
            }
        }
    }
}