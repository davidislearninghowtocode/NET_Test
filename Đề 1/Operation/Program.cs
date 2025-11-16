using System;
public delegate int Operation(int a, int b);
public class Tinh{
    public static int Add(int a, int b) => a+b;
    public static int Subtract(int a, int b) => a-b;
    public static int Multiply(int a, int b) => a*b;
    public static int Divide(int a, int b){
        if(b == 0){
            throw new DivideByZeroException("Khong the chia cho 0.");
        }
        return a/b;
    }
}

class Program{
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

            Console.WriteLine("\n === Operation List ===");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.WriteLine("3. Multiply");
            Console.WriteLine("4. Divide");
            Console.Write("Your choice: ");

            int choice;
            while(!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4){
                Console.Write("Nhap lai: ");
            }

            int result;
            switch(choice){

                case 1:
                    Operation add = new Operation(Tinh.Add);
                    result = add(a,b);
                    Console.WriteLine($"{a} + {b} = {result}");
                    break;

                case 2:
                    Operation subtract = new Operation(Tinh.Subtract);
                    result = subtract(a,b);
                    Console.WriteLine($"{a} - {b} = {result}");
                    break;
                
                case 3:
                    Operation multiply = new Operation(Tinh.Multiply);
                    result = multiply(a,b);
                    Console.WriteLine($"{a} * {b} = {result}");
                    break;
                
                case 4:
                    Operation divide = new Operation(Tinh.Divide);
                    result = divide(a,b);
                    Console.WriteLine($"{a} -/ {b} = {result}");
                    break;
            }

            string answer;
            do{
                Console.Write("Ban co muon tiep tuc (y/n): ");
                answer = Console.ReadLine()?.Trim().ToLower();
            }while(answer != "y" && answer != "n");
            if(answer == "n") break;
        }
    }
}