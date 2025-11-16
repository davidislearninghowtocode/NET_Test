/*
Mã số: 40742
Câu 1: Chủ đề OOP (Inheritance - Kế thừa):
a) Định nghĩa lớp Animal với phương thức MakeSound(). (1 điểm)
b) Tạo lớp Dog kế thừa Animal và ghi đè phương thức MakeSound(). (1 điểm)
c) Tạo lớp Cat kế thừa Animal và ghi đè phương thức MakeSound(). (1.5 điểm)
d) Tạo danh sách các đối tượng Animal và gọi phương thức MakeSound(). (1.5 điểm)
*/

using System;
public class Animal{
    public virtual void MakeSound(){
        Console.WriteLine("Animal making sound.");
    }
}

public class Dog : Animal{
    public override void MakeSound()
    {
        Console.WriteLine("Dog goes woof woof");
    }
}

public class Cat : Animal{
    public override void MakeSound()
    {
        Console.WriteLine("Cat goes moew moew");
    }
}

class Program{
    static void Main(){
        List<Animal> ds = new List<Animal>();

        while(true){
            Console.WriteLine(" === Chon dong vat ===");
            Console.WriteLine("1. Dog");
            Console.WriteLine("2. Cat");
            Console.Write("Your choice: ");

            int choice;
            while(!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2){
                Console.Write("Lua chon khong hop le. Nhap lai: ");
            }

            switch(choice){
                case 1:
                    ds.Add(new Dog());
                    break;

                case 2:
                    ds.Add(new Cat());
                    break;
            }

            Console.WriteLine("\nSound of the animal.");
            foreach(Animal i in ds){
                i.MakeSound();
            }
        
            string answer;
            do{
                Console.Write("Ban co muon tiep tuc (y/n): ");
                answer = Console.ReadLine()?.Trim().ToLower();
            }while(answer != "y" || answer != "n");
            if(answer == "n") break;
        }
    }
}