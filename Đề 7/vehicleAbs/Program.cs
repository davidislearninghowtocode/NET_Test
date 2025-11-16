/*
Câu 1: Chủ đề OOP (Abstract Class - Lớp trừu tượng):
a) Định nghĩa lớp trừu tượng Vehicle với phương thức Start() và Stop(). (1 điểm)
b) Tạo lớp Car kế thừa từ Vehicle và triển khai các phương thức. (1 điểm)
c) Tạo lớp Motorbike kế thừa từ Vehicle và triển khai các phương thức. (1.5 điểm)
d) Tạo danh sách các đối tượng Vehicle và gọi phương thức Start() và Stop(). (1.5 điểm)

*/

using System;
using System.Collections.Generic;

public abstract class Vehicle{
    public abstract void Start();
    public abstract void Stop();
}

public class Car : Vehicle{
    public override void Start() => Console.WriteLine("Xe O to dang khoi dong...");
    public override void Stop() => Console.WriteLine("Car stopped.");
}

public class Motorbike : Vehicle{
    public override void Start() => Console.WriteLine("Xe may dang khoi dong ...");
    public override void Stop() => Console.WriteLine("Xe may dung...");
}

public class Program{
    static void Main(){

    List <Vehicle> ds = new List<Vehicle>();

    while(true){
    Console.WriteLine("\nDanh sach phuong tien");
    Console.WriteLine("1. Car");
    Console.WriteLine("2. Motorbike");
    Console.Write("Your choice: ");

    int choice;
    while(!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2){
        Console.Write("Lua chon khong hop le. ");
    }
    switch(choice){
        case 1:
            ds.Add(new Car());
            break;

        case 2:
            ds.Add(new Motorbike());
            break;
    }

    Console.WriteLine("=== Hoat dong cua phuong tien ===");
    foreach(Vehicle i in ds){
        i.Start();
        i.Stop();

    }
        string answer;
        do{
            Console.Write("Ban co muon nhap tiep (y/n): ");
            answer = Console.ReadLine()?.Trim().ToLower();
        }while(answer != "y" && answer != "n");
        if(answer == "n") break;
    }
    }
    }
