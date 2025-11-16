using System;
public class Calculator{
    public static float Divide(float a, float b){
        if(b == 0){
            throw new DivideByZeroException("Cannot divide by 0");
        }
        return a / b;
    }
}

class Program{
    public static float ValidNum(string prompt){
        float num;
        Console.WriteLine(prompt);
        while(!float.TryParse(Console.ReadLine(), out num)){
            Console.Write("Nhap sai, nhap lai: ");
        }
        return num;
    }

    static void Main(){
        try{
            float a = ValidNum("Nhap a: ");
            float b = ValidNum("Nhap b: ");

            int result = Calculator.Divide(a,b);
            Console.WriteLine($"{a} / {b} = {result}");
        }catch(DivideByZeroException){
            Console.WriteLine("Khong the chia duoc cho 0");
        }catch(Exception){
            Console.WriteLine("Other errors");
        }finally{
            Console.WriteLine("Closing the program");
        }
    }
}