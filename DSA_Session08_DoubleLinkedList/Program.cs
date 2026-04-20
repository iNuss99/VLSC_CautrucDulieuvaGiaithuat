namespace DSA_Session08_DoubleLinkedList;

using System;

//Author: Do Minh Khoa - 2500114713

//Lop dai dien cho 1 sinh vien
public class Student
{
    // ma sinh vien , ten sinh vien
    public string Id { get; set; }
    public string Name { get; set; }

    public Student(string id, string name)
    {
        Id = id;
        Name = name;
    }

    public override string ToString()
    {
        return $"Student(Id: {Id}, Name: {Name})";
    }
}

// Lop dai dien cho 1 phan tu( Node)
public class DoubleNode
{
    public Student student;
    public DoubleNode? Prev;
    public DoubleNode? Next;

    // Da sua ten ham khoi tao va sua loi viet sai 'null'
    public DoubleNode(Student student)
    {
        this.student = student;
        Prev = null;
        Next = null;
    }
}

// Lop quan ly danh sach
public class DoubleLinkedList
{
    public DoubleNode? Head;
    public DoubleNode? Tail;

    public DoubleLinkedList()
    {
        Head = null;
        Tail = null;
    }

    // Them phan tu vao cuoi (Add Last)
    public void AddLast(Student student)
    {
        DoubleNode newNode = new DoubleNode(student);

        if (Head == null)
        {
            Head = Tail = newNode;
            return;
        }

        Tail.Next = newNode; // Moc tail hien tai voi node moi
        newNode.Prev = Tail; // Moc node moi quay nguoc lai tail cu
        Tail = newNode;      // Cap nhat Tail la node moi
    }

    // Duyet danh sach tu dau den cuoi
    public void PrintForward()
    {
        DoubleNode? current = Head;
        Console.Write("Tien: null <-> ");
        while (current != null)
        {
            Console.Write($"{current.student} <-> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }

    // Duyet danh sach tu cuoi ve dau (Uu the tuyet doi cua DLL)
    public void PrintBackward()
    {
        DoubleNode? current = Tail;
        Console.Write("Lui: null <-> ");
        while (current != null)
        {
            Console.Write($"{current.student} <-> ");
            current = current.Prev;
        }
        Console.WriteLine("null");
    }

    // 8.1. Viet ham AddFirst(Student student) de them phan tu vao dau danh sach
    public void AddFirst(Student student)
    {
        DoubleNode newNode = new DoubleNode(student);

        if (Head == null)
        {
            Head = Tail = newNode;
            return;
        }

        newNode.Next = Head; // Moc node moi voi head hien tai
        Head.Prev = newNode; // Moc head hien tai quay nguoc lai node moi
        Head = newNode;      // Cap nhat Head la node moi
    }

    // 8.2. Viet ham GetSize() de dem xem danh sach hien co bao nhieu Node
    public int GetSize()
    {
        int count = 0;
        DoubleNode? current = Head;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }

    // 8.3. Viet ham RemoveNode(string studentId) tim va xoa Node dau tien chua ma sinh vien studentId.
    // Nho cap nhat lai con tro Next cua Node truoc va Prev cua Node sau.
    public void RemoveNode(string studentId)
    {
        DoubleNode? current = Head;
        while (current != null)
        {
            if (current.student.Id == studentId)
            {
                // Neu node can xoa la head
                if (current == Head)
                {
                    Head = current.Next;
                    if (Head != null)
                    {
                        Head.Prev = null;
                    }
                }
                // Neu node can xoa la tail
                else if (current == Tail)
                {
                    Tail = current.Prev;
                    if (Tail != null)
                    {
                        Tail.Next = null;
                    }
                }
                // Neu node can xoa nam giua
                else
                {
                    current.Prev!.Next = current.Next;
                    current.Next!.Prev = current.Prev;
                }
                return; // Ket thuc sau khi xoa
            }
            current = current.Next;
        }
    }

    // 8.4. Viet ham InsertAfterIndex(int index, Student student) de chen sinh vien vao sau vi tri index thu i.
    public void InsertAfterIndex(int index, Student student)
    {
        if (index < 0 || index >= GetSize())
        {
            Console.WriteLine("Vi tri chen khong hop le.");
            return;
        }

        DoubleNode newNode = new DoubleNode(student);
        DoubleNode? current = Head;

        if (current == null)
        {
            // Neu danh sach rong, them node moi lam head va tail
            Head = Tail = newNode;
            return;
        }
        else
        {
            // Di chuyen den vi tri index
            for (int i = 0; i < index; i++)
            {
                current = current!.Next;
            }

            // Chen node moi sau node tai vi tri index
            newNode.Next = current!.Next;
            newNode.Prev = current;
            if (current.Next != null)
            {
                current.Next.Prev = newNode;
            }
            else
            {
                Tail = newNode; // Neu chen vao sau cung thi cap nhat Tail
            }
            current.Next = newNode;
        }
    }

    // 8.5. Dao nguoc DLL (Reverse in place):
    // Viet ham chi su dung vong lap va doi cho cac con tro Next / Prev cua tung Node de dao nguoc toan bo danh sach
    // ma khong tao mang hay danh sach moi.
    public void Reverse()
    {
        DoubleNode? current = Head;
        DoubleNode? temp = null;

        while (current != null)
        {
            // Doi cho Next va Prev
            temp = current.Prev;
            current.Prev = current.Next;
            current.Next = temp;

            // Di chuyen den node tiep theo (truoc khi doi cho)
            current = current.Prev; // Vi da doi cho, Prev bay gio la Next
        }

        // Sau khi hoan thanh, temp se tro den node cuoi cung da duoc dao nguoc
        if (temp != null)
        {
            Head = temp.Prev; // Cap nhat Head moi
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        DoubleLinkedList list = new DoubleLinkedList();
        
        // Test them du lieu
        list.AddLast(new Student("250011459", "Hai"));
        list.AddLast(new Student("250011460", "Hoang"));
        list.AddLast(new Student("250011461", "Duy"));

        Console.WriteLine("--- Danh sach ban dau ---");
        list.PrintForward();

        list.Reverse();
        Console.WriteLine("\n--- Sau khi Reverse ---");
        list.PrintForward();
    }
}