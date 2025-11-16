using System;
using System.Collections.Generic;

public class Animal{
    public string Name{get;set;}
    public int Age{get;set;}

    public Animal(string name, int age){
        Name = name;
        Age = age;
    }

    public virtual void DisplayInfo(){
        Console.WriteLine($"Name  : {Name}");
        Console.WriteLine($"Age   : {Age}");
    }
}

public class Dog : Animal{
    public string Breed {get;set;}
    public Dog(string name, int age, string breed) : base(name, age){
        Breed = breed;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Breed : {Breed}");
    }
}

class Program{
    public static string ValidString(string prompt){
        string input;
        do{
            Console.Write(prompt);
            input = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(input)){
                Console.Write("Khong duoc de trong. Nhap lai: ");
            }
        }while(string.IsNullOrWhiteSpace(input));
        return input;
    }

    static void Main(){
        List<Animal> ds = new List<Animal>();

        while(true){
            string name = ValidString("Enter name: ");
            string breed = ValidString("Enter breed: ");

            Console.Write("Enter age: ");
            int age;
            while(!int.TryParse(Console.ReadLine(), out age) || age < 0){
                Console.Write("Re input: ");
            }

            Dog dog = new Dog(name, age, breed);
            ds.Add(dog);

            Console.WriteLine("\n List Dog");
            foreach(Animal i in ds){
                i.DisplayInfo();
            }

            string answer;
            do{
                answer = ValidString("Ban co muon nhap tiep (y/n): ")?.Trim().ToLower();
            }while(answer != "y" && answer != "n");
            if(answer == "n")break;
        }
    }
}