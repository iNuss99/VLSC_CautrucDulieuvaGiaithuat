using System;
//Author: DO MINH KHOA - 2500114713
namespace DSA_Session07_SingleLinkedList
{
    // 1. ĐỊNH NGHĨA CLASS NODE: MỘT MẮT XÍCH TRONG DANH SÁCH
    public class Node
    {
        public int Data;    // Dữ liệu của mắt xích
        public Node Next;   // "Sợi dây" trỏ đến mắt xích tiếp theo

        // Constructor: Khởi tạo giá trị khi tạo Node mới
        public Node(int data)
        {
            Data = data;
            Next = null;    // Mặc định sinh ra chưa nối với ai cả
        }
    }

    // 2. ĐỊNH NGHĨA CLASS SINGLE LINKED LIST: DANH SÁCH LIÊN KẾT ĐƠN
    public class SingleLinkedList
    {
        private Node head;  // "Cái đầu" của danh sách, nơi bắt đầu

        // Constructor: Khởi tạo danh sách rỗng
        public SingleLinkedList()
        {
            head = null;    // Ban đầu chưa có mắt xích nào
        }

        // 3. PHƯƠNG THỨC THÊM MẮT XÍCH VÀO CUỐI DANH SÁCH
        public void AddLast(int data)
        {
            Node newNode = new Node(data); // Tạo mắt xích mới với dữ liệu
            if (head == null) // O(1)
            {
                head = newNode; // Nếu danh sách rỗng, newNode trở thành head
                return;
            }

            Node current = head; // Bắt đầu từ head
            while (current.Next != null) // O(n)
            {
                current = current.Next; // Đi tiếp đến mắt xích cuối cùng
            }
            current.Next = newNode; // Nối mắt xích cuối cùng với newNode
        }

        // 4. PHƯƠNG THỨC IN RA DANH SÁCH
        public void PrintList()
        {
            Node current = head; // Bắt đầu từ head
            if (current == null)
            {
                Console.WriteLine("Danh sách đang rỗng!");
                return;
            }

            while (current != null) // O(n)
            {
                Console.Write(current.Data + " -> "); // In dữ liệu của mắt xích
                current = current.Next; // Đi tiếp đến mắt xích tiếp theo
            }
            Console.WriteLine("null"); // Kết thúc danh sách
        }
    }

    // 5. CHƯƠNG TRÌNH CHÍNH: TEST DANH SÁCH LIÊN KẾT ĐƠN
    class Program
    {
        static void Main(string[] args)
        {
            // Thiết lập Console để hiển thị tiếng Việt (nếu cần)
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Tạo một instance của SingleLinkedList để quản lý danh sách
            SingleLinkedList list = new SingleLinkedList();
            Console.WriteLine("Chào mừng đến với danh sách liên kết đơn!");

            // tạo menu để người dùng chọn thao tác
            while (true)
            {
                Console.WriteLine("\nVui lòng chọn thao tác:");
                Console.WriteLine("1. Thêm mắt xích vào cuối danh sách");
                Console.WriteLine("2. In ra danh sách hiện tại");
                Console.WriteLine("3. Xoá danh sách");
                Console.WriteLine("4. Thoát");

                Console.Write("\nLựa chọn của bạn: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": // Thêm mắt xích vào cuối danh sách
                        Console.Write("Nhập dữ liệu cho mắt xích mới: ");
                        if (int.TryParse(Console.ReadLine(), out int data))
                        {
                            list.AddLast(data);
                        }
                        else
                        {
                            Console.WriteLine("Dữ liệu không hợp lệ, vui lòng nhập số!");
                        }
                        break;

                    case "2": // In ra danh sách hiện tại
                        list.PrintList();
                        break;

                    case "3": // Xoá danh sách bằng cách tạo một instance mới, "đánh rơi" instance cũ
                        list = new SingleLinkedList();
                        Console.WriteLine("Danh sách đã được xoá.");
                        break;

                    case "4": // Thoát khỏi chương trình
                        return; // Kết thúc hàm Main, thoát chương trình

                    default: // Nếu người dùng nhập lựa chọn không hợp lệ
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }
            }
        }
    }
}