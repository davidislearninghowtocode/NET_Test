/* Anonymous and Lambda expression
1. Định nghĩa delegate MathOperation
2. Sử dụng anonymous method để tính phép chia
3. Sử dụng biểu thức lambda để thực hiện phép nhân
4. So sánh cách sử dụng giữa anonymous và lambda
*/

using System;

public delegate float MathOperation(float a, float b);

class Program
{
    public static float ValidNum(string prompt)
    {
        float num;
        Console.Write(prompt);
        while (!float.TryParse(Console.ReadLine(), out num))
        {
            Console.Write("Nhập lại: ");
        }
        return num;
    }

    public static void Main(string[] args)
    {
        while (true)
        {
            float a = ValidNum("Nhập a: ");
            float b = ValidNum("Nhập b: ");

            Console.WriteLine("1. Divide (anonymous)");
            Console.WriteLine("2. Multiply (lambda)");
            Console.Write("Your choice: ");

            // anonymous 
            MathOperation divide = delegate (float a, float b)
            {
                return a / b;
            };

            // lambda
            MathOperation multiply = (x, y) => x * y;

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2)
            {
                Console.Write("Lựa chọn không hợp lệ. Nhập lại: ");
            }

            switch (choice)
            {
                case 1:
                    while (b == 0)
                    {
                        Console.Write("Không thể chia cho 0. Nhập lại b: ");
                        b = ValidNum("");
                    }
                    Console.WriteLine($"{a} / {b} = {divide(a, b)}");
                    break;

                case 2:
                    Console.WriteLine($"{a} * {b} = {multiply(a, b)}");
                    break;
            }

            string answer;
            do
            {
                Console.Write("Bạn có muốn nhập tiếp (y/n): ");
                answer = Console.ReadLine()?.Trim().ToLower();
            } while (answer != "y" && answer != "n");

            if (answer == "n") break;
        }
    }
}
