/*
Câu 2: Chủ đề Delegate:
a) Định nghĩa delegate MathOperation nhận hai tham số.
b) Tạo phương thức Subtract(int a, int b) để thực hiện phép trừ.
c) Gọi delegate và hiển thị kết quả phép trừ.
d) Thực hiện tính toán với hai số bất kỳ.

*mở rộng code này thêm các phép tính khác
*/

using System;

// Định nghĩa delegate
public delegate int MathOperation(int a, int b);

// Lớp Tinh chứa các phép toán cơ bản
public class Tinh
{
    public static int Add(int a, int b) => a + b;
    public static int Subtract(int a, int b) => a - b;
    public static int Multiply(int a, int b) => a * b;
    public static int Divide(int a, int b)
    {
        if (b == 0)
        {
            Console.WriteLine("Lỗi: Không thể chia cho 0.");
            return 0;
        }
        return a / b;
    }
}

class Program
{
    static void Main()
    {
        int a, b;

        // Nhập a
        Console.Write("Nhập a: ");
        while (!int.TryParse(Console.ReadLine(), out a))
        {
            Console.WriteLine("Giá trị a không hợp lệ. Nhập lại:");
        }

        // Nhập b
        Console.Write("Nhập b: ");
        while (!int.TryParse(Console.ReadLine(), out b))
        {
            Console.WriteLine("Giá trị b không hợp lệ. Nhập lại:");
        }

        // Menu phép toán
        Console.WriteLine("\nChọn phép tính:");
        Console.WriteLine("1. Cộng (Add)");
        Console.WriteLine("2. Trừ (Subtract)");
        Console.WriteLine("3. Nhân (Multiply)");
        Console.WriteLine("4. Chia (Divide)");
        Console.Write("Lựa chọn của bạn (1-4): ");

        int choice;
        // Kiểm tra đầu vào hợp lệ
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
        {
            Console.WriteLine("Lựa chọn không hợp lệ. Nhập lại (1-4): ");
        }

        // Khai báo delegate
        MathOperation op = null;
        string symbol = "";

        // Gán delegate bằng lambda
        switch (choice)
        {
            case 1:
                op = (x, y) => x + y;
                symbol = "+";
                break;

            case 2:
                op = (x, y) => x - y;
                symbol = "-";
                break;

            case 3:
                op = (x, y) => x * y;
                symbol = "×";
                break;

            case 4:
                op = (x, y) =>
                {
                    if (y == 0)
                    {
                        Console.WriteLine("Lỗi: Không thể chia cho 0.");
                        return 0;
                    }
                    return x / y;
                };
                break;
        }

        // Gọi delegate và hiển thị kết quả
        int result = op(a, b);
        Console.WriteLine($"\nKết quả: {a} {symbol} {b} = {result}");
    }
}
