using System;

// Author: Do Minh Khoa - 2500114713

namespace DSA_Session06_Array
{
    class Program
    {
        // Bien toan cuc (Global) de luu tru mang dang lam viec
        static int[] currentArray;

        static void Main(string[] args)
        {
            int choice; // Bien de luu lua chon cua nguoi dung
            do
            {
                Console.WriteLine("\n===========================================");
                Console.WriteLine("    MODULE QUAN LY MANG (MIDTERM) ");
                Console.WriteLine("===========================================");
                Console.WriteLine("1. Tao mang so ngau nhien");
                Console.WriteLine("2. In mang hien tai");
                Console.WriteLine("3. Sap xep mang (Bubble Sort)");
                Console.WriteLine("4. Tim kiem nhi phan (Binary Search)");
                Console.WriteLine("0. Thoat phan mem");
                Console.WriteLine("===========================================");
                Console.Write("Moi ban chon tinh nang (0-4): ");

                // Xu ly ngoai le neu nguoi dung nhap chu thay vi so
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Loi: Vui long nhap so nguyen!");
                    choice = -1; // Gan gia tri tam de vong lap tiep tuc
                    continue; 
                }

                switch (choice)
                {
                    case 1:
                        GenerateRandomArray();
                        break;
                    case 2:
                        PrintArray();
                        break;
                    case 3:
                        BubbleSort();
                        break;
                    case 4:
                        ExecuteBinarySearch();
                        break;
                    case 0:
                        Console.WriteLine("Dong he thong. Chuc cac em diem cao!");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le!");
                        break;
                }
            } while (choice != 0);
        }

        // --- CAC HAM XU LY NGHIEP VU ---

        static void GenerateRandomArray()
        {
            Console.Write("Nhap so luong phan tu cua mang: ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("Loi: Vui long nhap mot so nguyen duong!");
            }

            currentArray = new int[n];
            Random rand = new Random(); 

            for (int i = 0; i < n; i++)
            {
                currentArray[i] = rand.Next(1, 100); 
            }
            Console.WriteLine($"=> Da tao mang thanh cong voi {n} phan tu!");
        }

        static void PrintArray()
        {
            if (currentArray == null)
            {
                Console.WriteLine("Loi: Mang chua duoc khoi tao. Hay chon chuc nang 1 truoc!");
                return;
            }

            Console.Write("Du lieu mang: ");
            foreach (int num in currentArray)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        static void BubbleSort()
        {
            if (currentArray == null)
            {
                Console.WriteLine("Loi: Mang rong!"); 
                return;
            }

            int n = currentArray.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (currentArray[j] > currentArray[j + 1])
                    {
                        int temp = currentArray[j];
                        currentArray[j] = currentArray[j + 1];
                        currentArray[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("=> Da sap xep mang tang dan bang Bubble Sort!");
        }

        static void ExecuteBinarySearch()
        {
            if (currentArray == null)
            {
                Console.WriteLine("Loi: Mang rong!"); 
                return;
            }

            Console.Write("Nhap so can tim: ");
            int target;
            while (!int.TryParse(Console.ReadLine(), out target))
            {
                Console.WriteLine("Loi: Vui long nhap mot so nguyen!");
            }

            int left = 0;
            int right = currentArray.Length - 1;
            int position = -1; 

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (currentArray[mid] == target)
                {
                    position = mid;
                    break; 
                }

                if (currentArray[mid] < target)
                    left = mid + 1; 
                else
                    right = mid - 1; 
            }

            if (position != -1)
            {
                Console.WriteLine($"=> Tuyet voi! Da tim thay so {target} tai vi tri Index = {position}.");
            }
            else
            {
                Console.WriteLine($"=> Khong tim thay so {target} trong mang.");
                Console.WriteLine("(Luu y: Mang phai duoc sap xep truoc khi tim nhi phan!)");
            }
        }
    }
}