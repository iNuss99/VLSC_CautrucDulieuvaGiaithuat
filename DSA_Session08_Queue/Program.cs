using System;
//Author: Do Minh Khoa - 2500114713
namespace DSA_Session08_Queue
{
    // Tao mot class quan ly hang doi rieng biet
    public class MyQueue
    {
        private int[] elements; // Mang chua du lieu
        private int front;      // Con tro dau hang
        private int rear;       // Con tro cuoi hang
        private int max;        // Kich thuoc toi da

        // Constructor khoi tao
        public MyQueue(int size)
        {
            elements = new int[size];
            front = -1;
            rear = -1;
            max = size;
        }

        // Ham them phan tu vao hang doi
        public void Enqueue(int item)
        {
            if (rear == max - 1)
            {
                Console.WriteLine("LOI: Hang doi da day (Overflow)!");
                return;
            }

            // Neu la phan tu dau tien duoc them vao
            if (front == -1)
            {
                front = 0;
            }

            rear++; // Tang con tro cuoi len
            elements[rear] = item; // Nap du lieu
            Console.WriteLine($"Da them [{item}] vao hang doi.");
        }

        // Ham lay phan tu ra khoi hang doi
        public int Dequeue()
        {
            if (front == -1 || front > rear)
            {
                Console.WriteLine("LOI: Hang doi trong (Underflow)!");
                return -1;
            }

            int item = elements[front]; // Lay gia tri o dau hang
            front++; // Day con tro dau hang lui ra sau

            // Toi uu: Neu lay het phan tu, reset lai hang doi
            if (front > rear)
            {
                front = -1;
                rear = -1;
            }

            return item;
        }

        // Xem nguoi dau tien ma khong xoa
        public void Peek()
        {
            if (front == -1 || front > rear)
            {
                Console.WriteLine("Hang doi trong rong.");
            }
            else
            {
                Console.WriteLine($"Phan tu dau hang hien tai la: {elements[front]}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== CHUONG TRINH MO PHONG HANG DOI ===");

            MyQueue queue = new MyQueue(3); // Tao queue chua toi da 3 nguoi

            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);

            queue.Enqueue(40); // Se bao loi Overflow vi max = 3

            queue.Peek(); // Xem dau hang: Ket qua la 10

            Console.WriteLine($"Da lay ra: {queue.Dequeue()}"); // Lay 10 ra
            Console.WriteLine($"Da lay ra: {queue.Dequeue()}"); // Lay 20 ra

            queue.Peek(); // Xem dau hang: Gio la 30
        }
    }
}