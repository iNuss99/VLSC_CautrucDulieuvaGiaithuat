using System;
//Author: Do Minh Khoa - 2500114713
namespace DSA_Session08_Queue_02
{
    public class CircularQueue
    {
        private int[] elements;
        private int front;
        private int rear;
        private int max;
        private int count; // Them bien count de de dang kiem tra mang day/rong

        public CircularQueue(int size)
        {
            max = size;
            elements = new int[max];
            front = 0;    // front bat dau o 0
            rear = -1;   // rear lui lai 1 buoc cho phan tu dau tien
            count = 0;   // So luong hien tai bang 0
        }

        // Them vao hang doi vong
        public void Enqueue(int item)
        {
            if (count == max)
            {
                Console.WriteLine($"LOI: Hang doi da day! Khong the them {item}.");
                return;
            }

            // Dung Modulo de vong rear lai dau mang neu cham day
            rear = (rear + 1) % max;
            elements[rear] = item;
            count++;
            Console.WriteLine($"[+] Da them: {item} (vao Index {rear})");
        }

        // Lay ra tu hang doi vong
        public int Dequeue()
        {
            if (count == 0)
            {
                Console.WriteLine("LOI: Hang doi rong!");
                return -1;
            }

            int item = elements[front];
            // Dung Modulo de vong front lai dau mang neu cham day
            front = (front + 1) % max;
            count--;
            Console.WriteLine($"[-] Da lay ra: {item}");
            return item;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            CircularQueue cq = new CircularQueue(3); // Mang toi da 3 phan tu

            cq.Enqueue(10);
            cq.Enqueue(20);
            cq.Enqueue(30);
            // Hien tai mang da DAY: [10, 20, 30]

            cq.Dequeue(); // Lay 10 ra. Vi tri Index 0 dang trong.

            // O Queue tuyen tinh binh thuong, lenh duoi se loi.
            // Nhung voi Circular Queue, 40 se duoc vong lai dien vao Index 0!
            cq.Enqueue(40);
        }
    }
}