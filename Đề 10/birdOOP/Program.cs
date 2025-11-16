/*
Câu 1: Chủ đề OOP (Polymorphism - Tính đa hình):
a) Định nghĩa lớp Bird với phương thức Fly(). (1 điểm)
b) Tạo lớp Eagle kế thừa Bird và ghi đè phương thức Fly(). (1 điểm)
c) Tạo lớp Penguin kế thừa Bird và ghi đè phương thức Fly() (không bay được). (1.5 điểm)
d) Tạo danh sách các đối tượng Bird và gọi phương thức Fly(). (1.5 điểm)
*/

using System;
using System.Collections.Generic;

public class Bird{
    public virtual void Fly(){
        Console.WriteLine("Animal flies.");
    }
}

public class Eagle : Bird{
    public override void Fly()
    {
        Console.WriteLine("Eagle is flying ...");
    }
}

public class Penguin : Bird{
    public override void Fly()
    {
        Console.WriteLine("Penguin cannot fly.");
    }
}

class Program{
    static void Main(){
        List<Bird> ds = new List<Bird>();
        
        while(true){
            Console.WriteLine("\n === Danh sach dong vat ===");
            Console.WriteLine("1. Eagle");
            Console.WriteLine("2. Penguin");
            Console.WriteLine("Your choice: ");

            int choice;
            while(!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2){
                Console.Write("Nhap khong hop le. Nhap lai; ");
            }

            switch(choice){
                case 1:  
                    ds.Add(new Eagle());
                    break;

                case 2:
                    ds.Add(new Penguin());
                    break;
            }

            foreach(Bird i in ds){
                i.Fly();
            }    
        string answer;
        do{
            Console.Write("Ban co muon lam tiep (y/n): ");
            answer = Console.ReadLine()?.Trim().ToLower();
        }while(answer != "y" && answer != "n");
        if(answer == "n") break;        
        }
    }
}