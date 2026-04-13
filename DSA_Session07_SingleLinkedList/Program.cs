using System; 
//Author: DO MINH KHOA - 2500114713 

namespace DSA_Session07_SingleLinkedList 
{     
    // 1. ĐỊNH NGHĨA CLASS NODE: MỘT MẮT XÍCH TRONG DANH SÁCH     
    public class Node     
    {         
        public int Data;    // Dữ liệu của mắt xích (lưu số nguyên)
        public Node Next;   // Con trỏ trỏ đến mắt xích tiếp theo

        // Constructor: Khởi tạo Node khi được tạo mới         
        public Node(int data)         
        {             
            Data = data;             // Gán dữ liệu cho node
            Next = null;             // Ban đầu chưa nối với node nào         
        }     
    }      

    // 2. ĐỊNH NGHĨA CLASS SINGLE LINKED LIST: DANH SÁCH LIÊN KẾT ĐƠN     
    public class SingleLinkedList     
    {         
        private Node head;  // Node đầu tiên của danh sách (điểm bắt đầu)

        // Constructor: Khởi tạo danh sách rỗng         
        public SingleLinkedList()         
        {             
            head = null;    // Danh sách ban đầu chưa có phần tử nào        
        }          

        // 3. PHƯƠNG THỨC THÊM MẮT XÍCH VÀO CUỐI DANH SÁCH         
        public void AddLast(int data)         
        {             
            Node newNode = new Node(data); // Tạo node mới

            // Nếu danh sách rỗng → node mới sẽ là head
            if (head == null) 
            {                 
                head = newNode; 
                return;             
            }              

            // Nếu danh sách đã có phần tử → duyệt đến cuối
            Node current = head; 
            while (current.Next != null) // lặp cho đến node cuối cùng
            {                 
                current = current.Next; 
            }             

            // Gắn node mới vào cuối danh sách
            current.Next = newNode; 
        }          

        // 4. PHƯƠNG THỨC IN RA DANH SÁCH         
        public void PrintList()         
        {             
            Node current = head; // bắt đầu từ head

            // Nếu danh sách rỗng
            if (current == null)             
            {                 
                Console.WriteLine("Danh sách đang rỗng!");                 
                return;             
            }              

            // Duyệt từng node và in ra
            while (current != null)             
            {                 
                Console.Write(current.Data + " -> "); // in dữ liệu                 
                current = current.Next; // di chuyển sang node tiếp theo            
            }             

            Console.WriteLine("null"); // kết thúc danh sách        
        }         

        // 8.1 Viet ham dem va  tra ve tong so luong node dang co trong danh sach         
        public int CountNodes()         
        {             
            int count = 0; //Bien dem so luong Node             
            Node current = head; //Bat dau tu head             

            // Duyệt toàn bộ danh sách
            while (current != null)             
            {                 
                count++; // mỗi lần gặp node thì tăng biến đếm                 
                current = current.Next; // đi tiếp            
            }             

            return count; // trả về tổng số node        
        }         

        // 8.2 Tim xem mot so target co ton tai trong danh sach hay khong.         
        //(Goi y: Tra ve true hoac false)         
        public bool SearchNode(int target)         
        {             
            Node current = head; // bắt đầu từ head             

            // Duyệt danh sách
            while (current != null)             
            {                 
                // Nếu tìm thấy giá trị cần tìm
                if (current.Data == target)                 
                {                     
                    return true; // trả về true ngay lập tức                 
                }                 

                current = current.Next; // tiếp tục duyệt            
            }             

            return false; // duyệt hết mà không thấy        
        }         

        // 8.3 Xóa node đầu tiên của danh sách        
        public void DeleteFirst()         
        {             
            // Nếu danh sách không rỗng
            if (head != null)             
            {                 
                head = head.Next; // bỏ node đầu            
            }         
        }         

        // 8.4. Xóa Node ĐẦU TIÊN có Data bằng với giá trị value. 
        public void DeleteByValue(int value) 
        {     
            // Nếu danh sách rỗng
            if (head == null)     
            {         
                return;     
            }      

            // Nếu node đầu tiên chứa giá trị cần xóa
            if (head.Data == value)     
            {         
                head = head.Next;         
                return;     
            }      

            Node current = head; // bắt đầu từ head     

            // Duyệt để tìm node cần xóa
            while (current.Next != null)     
            {         
                if (current.Next.Data == value)         
                {             
                    // Bỏ qua node cần xóa
                    current.Next = current.Next.Next;             
                    return;         
                }         
                current = current.Next;     
            } 
        } 

        // 8.5. Đảo ngược toàn bộ Danh sách liên kết mà KHÔNG được sử dụng thêm mảng phụ 
        public void ReverseList() 
        {     
            Node prev = null; // node trước         
            Node current = head; // node hiện tại         

            // Duyệt danh sách và đảo chiều liên kết
            while (current != null)     
            {         
                Node next = current.Next; // lưu node tiếp theo         
                current.Next = prev; // đảo chiều con trỏ         
                prev = current; // cập nhật prev         
                current = next; // đi tiếp         
            }          

            head = prev; // cập nhật head mới        
        }     
    }      

    // 5. CHƯƠNG TRÌNH CHÍNH: TEST DANH SÁCH LIÊN KẾT ĐƠN           
    class Program     
    {         
        static void Main(string[] args) 
        {     
            // Khởi tạo danh sách liên kết
            SingleLinkedList list = new SingleLinkedList();     

            Console.WriteLine("Chào mừng đến với danh sách liên kết đơn!");      

            // Menu lặp vô hạn
            while (true)     
            {         
                Console.WriteLine("\nVui lòng chọn thao tác:");         
                Console.WriteLine("1. Thêm mắt xích vào cuối danh sách");         
                Console.WriteLine("2. In ra danh sách");         
                Console.WriteLine("3. Xoá danh sách");         
                Console.WriteLine("4. Đảo ngược danh sách");         
                Console.WriteLine("5. Đếm số lượng Node trong danh sách");         
                Console.WriteLine("6. Tìm kiếm một giá trị trong danh sách");         
                Console.WriteLine("7. Xoá Node đầu tiên");         
                Console.WriteLine("8. Xoá Node có giá trị cụ thể");         
                Console.WriteLine("9. Thoát");          

                string choice = Console.ReadLine(); // đọc lựa chọn người dùng          

                switch (choice)         
                {             
                    case "1":                 
                        Console.Write("Nhập dữ liệu: ");                 
                        int data = int.Parse(Console.ReadLine());                 
                        list.AddLast(data);                 
                        break;              

                    case "2":                 
                        list.PrintList();                 
                        break;              

                    case "3":                 
                        list = new SingleLinkedList(); // reset danh sách                 
                        Console.WriteLine("Danh sách đã được xoá.");                 
                        break;              

                    case "4":                 
                        list.ReverseList();                 
                        Console.WriteLine("Đã đảo ngược danh sách.");                 
                        break;              

                    case "5":                 
                        Console.WriteLine("Số node: " + list.CountNodes());                 
                        break;              

                    case "6":                 
                        Console.Write("Nhập giá trị cần tìm: ");                 
                        int x = int.Parse(Console.ReadLine());                 
                        Console.WriteLine(list.SearchNode(x) ? "Có" : "Không");                 
                        break;              

                    case "7":                 
                        list.DeleteFirst();                 
                        break;              

                    case "8":                 
                        Console.Write("Nhập giá trị cần xoá: ");                 
                        int y = int.Parse(Console.ReadLine());                 
                        list.DeleteByValue(y);                 
                        break;              

                    case "9":                 
                        return;              

                    default:                 
                        Console.WriteLine("Sai lựa chọn!");                 
                        break;         
                }     
            } 
        }     
    } 
}