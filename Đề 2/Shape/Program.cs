/*
Chủ đề OOP (Tính đa hình):
a) Định nghĩa lớp Shape với phương thức Draw0 không có nội dung. (1 điểm)
b) Tạo lớp Circle kế thừa Shape, ghi đè phương thức Draw0 để vẽ hình tròn. (1 điểm)
c) Tạo lớp Rectangle kế thừa Shape, ghi đè phương thức Draw() để vẽ hình chữ nhật. (1.5 điểm)
d) Sử dụng đa hình để tạo danh sách các đối tượng Shape và gọi phương thức Draw). (1.5 điểm)
*/

using System;
using System.Collections.Generic;
using System.Threading;

public abstract class Shape{
    public abstract void Draw();
}

public class Circle : Shape{
    public override void Draw()
    {
        Console.WriteLine("Drawing circle ....");
        Thread.Sleep(1000);
        Console.WriteLine("Done drawing.");
        Console.WriteLine();
    }
}

public class Rectangle : Shape{
    public override void Draw()
    {
        Console.WriteLine("Drawing rectangle ...");
        Thread.Sleep(1000);
        Console.WriteLine("Done Drawing rectangle");
    }
}

class Program{
    static void Main(){
        List<Shape> ds = new List<Shape>();
        while(true){
            Console.WriteLine("\n === Danh sach hinh ===");
            Console.WriteLine("1. Circle");
            Console.WriteLine("2. Rectangle");
            Console.Write("Your choice: ");

            int choice;
            while(!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2){
                Console.Write("Nhap lai: ");
            }

            switch(choice){
                case 1:
                    ds.Add(new Circle());
                    break;
                
                case 2:
                    ds.Add(new Rectangle());
                    break;
            }

            foreach(Shape i in ds){
                i.Draw();
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