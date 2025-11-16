/*
1. Định nghĩa một delegate CalculationHandler nhận vào 2 số nguyên
2. Định nghĩa phương thức Multiply để thực hiện phép nhân
3. Sử dụng delegate để gọi phương thức Multiply và thực hiện phép tính
4. Định nghĩa event OnCalculationComplete, kích hoạt event khi phép tính hoàn thành

*/

using System;
using System.Threading;

public delegate int CalculationHandler(int a, int b);
public class CalculationTaskArgs : EventArgs{
    public int Num1 {get;}
    public int Num2 {get;}
    public int Result {get;}
    public DateTime FinishTime {get;}

    public CalculationTaskArgs(int num1, int num2, int result){
        Num1 = num1;
        Num2 = num2;
        Result = result;
        FinishTime = DateTime.Now;
    }
}

public class Calculator{
    public event EventHandler<CalculationTaskArgs> OnCalculationComplete;
    public void CompleteTask(int num1, int num2){
        Console.WriteLine("\n Calculating ...");
        Thread.Sleep(500);

        int result = Multiply(num1, num2);
        OnCalculationComplete?.Invoke(this, new CalculationTaskArgs(num1, num2, result));
    }

    public int Multiply(int a, int b) => a*b;
}

class Program{
    public static void FinishTask(object sender, CalculationTaskArgs e){
        Console.WriteLine($"{e.Num1} * {e.Num2} = {e.Result}");
        Console.WriteLine($"Finished at: {e.FinishTime}");
        Console.WriteLine();
    }

    public static int ValidNum(string prompt){
        int num;
        Console.Write(prompt);
        while(!int.TryParse(Console.ReadLine(), out num)){
            Console.Write("Nhap lai: ");
        }
        return num;
    }

    static void Main(){
        while(true){
            int a = ValidNum("Nhap a: ");
            int b = ValidNum("Nhap b: ");

            Calculator cacl = new Calculator();
            cacl.OnCalculationComplete += FinishTask;

            cacl.CompleteTask(a,b);

            // Hỏi có tiếp tục không
            string q;
            do{
                Console.Write("Continue (y/n): ");
                q = Console.ReadLine()?.Trim().ToLower();
            }while(q != "y" && q != "n");
            if(q == "n") break;
        }
    }
}