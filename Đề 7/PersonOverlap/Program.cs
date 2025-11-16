/*
Câu1: chủ đề OOP - Nạp chồng
- định nghĩa lớp Person với thuộc tính Name, Age
- tạo constructor mặc định không tham số
- tạo constructor có tham số để khởi tạo Name, Age
- tạo đối tượng Person với 2 cách khởi tạo để hiển thị thông itn
*/
using System;
public class Person{
    public string Name{get;set;}
    public int Age{get;set;}

    //constructor mặc định không tham số
    public Person(){
        Name = "Unknown";
        Age = 0;
    }

    //constructor có tham số
    public Person(string name, int age){
        Name = name;
        Age = age;
    }

    public void DisplayInfo(){
        Console.WriteLine($"Name: {Name}\nAge: {Age}");
    }
}

class Program{
    static void Main(){
        //dùng constructor mặc định
        Person p1 = new Person();
        Console.WriteLine("Thong tin nguoi so 1 (default constructor)");
        p1.DisplayInfo();

        string name;
        while(true){
            Console.Write("\nNhap ten nguoi dung: ");
            name = Console.ReadLine();
            if(!string.IsNullOrWhiteSpace(name))break;
            else{
                Console.Write("Ten khong hop le. ");
            }
        }

        int age;
        Console.Write("Nhap tuoi: ");
        while(!int.TryParse(Console.ReadLine(), out age) || age < 0){
            Console.Write("Tuoi nhap khong hop le.");
        }

        Person p2 = new Person(name, age);
        Console.WriteLine("\nThong tin nguoi dung thu 2 (constructor co tham so)");
        p2.DisplayInfo();
    }
}