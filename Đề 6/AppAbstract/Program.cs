/*
Câu 1: Chủ đề OOP (Abstraction):
 a) Định nghĩa một lớp trừu tượng Appliance với phương thức TurnOn() và TurnOff(). (1 điểm)
 b) Tạo lớp WashingMachine kế thừa từ Appliance và triển khai các phương thức. (1 điểm)
 c) Tạo lớp Refrigerator kế thừa từ Appliance và triển khai các phương thức. (1.5 điểm)
 d) Tạo danh sách các đối tượng Appliance và gọi các phương thức TurnOn() và TurnOff(). (1.5 điểm)
*/
using System;
using System.Collections.Generic;
using System.Formats.Asn1;

public abstract class Appliance{
    public abstract void TurnOn();
    public abstract void TurnOff();
}

public class WashingMachine : Appliance{
    public override void TurnOn() => Console.WriteLine("Washing machine is on.");
    public override void TurnOff() => Console.WriteLine("Washing machine is off.");
}

public class Refrigerator : Appliance{
    public override void TurnOn() => Console.WriteLine("Refrigerator is on.");
    public override void TurnOff() => Console.WriteLine("Refrigerator is off.");
}

public class Program{
    static void Main(){
        List<Appliance> ds = new List<Appliance>();

        while(true){
        Console.WriteLine("\n== Danh sach thiet bi ==");
        Console.WriteLine("1. Washing machine.");
        Console.WriteLine("2. Refrigerator.");
        Console.Write("You choose: ");
        int choice;
        while(!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2){
            Console.Write("Lua chon nhap khong hop le. Nhap lai: ");
        }

        switch(choice){
            case 1:
                ds.Add(new WashingMachine());
                break;

            case 2:
                ds.Add(new Refrigerator());
                break;
        }

        Console.WriteLine("\n == Hoat dong cua cac thiet bi ==");
        foreach(Appliance i in ds){
            i.TurnOn();
            i.TurnOff();
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