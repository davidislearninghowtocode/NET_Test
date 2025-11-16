/*
Câu 2: Chủ đề Delegate:
a) Định nghĩa delegate OperationHandler.
b) Tạo phương thức Multiply(int a, int b) để thực hiện phép nhân.
c) Gọi delegate và hiển thị kết quả.
d) Kiểm tra kết quả phép nhân với hai số bất kỳ.
*/

using System;
public delegate int OperationHandler(int a, int b);
public class Operation{
    public int Add(int a, int b) => a + b;
    public int Subtract(int a, int b) => a - b;
    public int Multiply(int a, int b) => a * b;
    public int Divide(int a, int b){
        while(b == 0){
            Console.Write("Khong the chia cho 0. Nhap lai: ");
            int.TryParse(Console.ReadLine(), out b);
        }
        return a/b;
    }
}
public class Program{
    public static int ValidNum(string prompt){
        int number;
        while(true){
            Console.Write(prompt);
            if(int.TryParse(Console.ReadLine(), out number)){
                return number;
            }else{
                Console.Write("So nhap vao khong hop le.");
            }
        }
    }
    static void Main(){
        int a = ValidNum("\nNhap vao so a: ");
        int b = ValidNum("\nNhap vao so b: ");

        Console.WriteLine("\n == Danh sach cac phep tinh ===");
        Console.WriteLine("1. Add");
        Console.WriteLine("2. Subtract");
        Console.WriteLine("3. Multiply");
        Console.WriteLine("4. Divide");
        Console.WriteLine("Enter your choice: ");

        int choice;
        while(!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4){
            Console.Write("Lua chon nhap khong hop le. Chon lai: ");
        }

        OperationHandler op = null;
        string symbol = "";

        switch(choice){
            case 1:
                op = (x,y) => x+y;
                symbol = "+";
                break;
            
            case 2:
                op = (x,y) => x-y;
                symbol = "-";
                break;
            
            case 3:
                op = (x,y) =>x*y;
                symbol = "*";
                break;

            case 4:
                op = (x,y) => x/y;
                symbol = "/";
                break;
        }
        int result = op(a,b);
        Console.WriteLine($"Ket qua {a} {symbol} {b} = {result}");
    }
}