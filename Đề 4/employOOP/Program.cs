/*
Câu 1: Chủ đề OOP (Tính kế thừa):
a) Định nghĩa lớp Employee với thuộc tính Name và Position. (1 điểm)
b) Tạo lớp Manager kế thừa từ Employee, thêm thuộc tính Department. (1 điểm)
c) Tạo lớp Developer kế thừa từ Employee, thêm thuộc tính ProgrammingLanguage. (1.5 điểm)
d) Tạo các đối tượng Manager và Developer, hiển thị thông tin của từng đối tượng. (1.5 điểm)
*/
using System;
public class Employee{
    public string Name{get;set;}
    public string Position{get;set;}

    public Employee(string name, string position){
        Name = name;
        Position = position;
    }

    public virtual void DisplayInfo(){
        Console.WriteLine($"Name:     {Name}");
        Console.WriteLine($"Position: {Position}");
    }
}

public class Manager : Employee{
    public string Department{get;set;}

    public Manager(string name, string position, string department) : base(name, position){
        Department = department;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Department:   {Department}");
    }
}

public class Developer : Employee{
    public string ProgramLang{get;set;}
    public Developer(string name, string position, string programLang) : base(name, position){
        ProgramLang = programLang;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Programing Language:  {ProgramLang}");
    }
}

class Program{
    public static string ValidString(string prompt){
        string input;
        do{
            Console.Write(prompt);
            input = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(input)){
                Console.Write("khong duoc de trong. nhap lai: ");
            }
        }while(string.IsNullOrWhiteSpace(input));
        return input;
    }

    static void Main(){
        while(true){
            Console.WriteLine("\n Thong tin nhan vien");
            Console.WriteLine("1. Manager");
            Console.WriteLine("2. Developer");
            Console.Write("Your choice: ");

            int choice;
            while(!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2){
                Console.Write("Nhap lai: ");
            }

            switch(choice){
                case 1:
                    string name = ValidString("Nhap ten: ");
                    string position = ValidString("Nhap chuc vu: ");
                    string department = ValidString("Nhap phong ban: ");
                    Console.WriteLine();
                    Manager mg = new Manager(name, position, department);
                    mg.DisplayInfo();
                    break;
                
                case 2:
                    string dName = ValidString("Nhap ten: ");
                    string dPosition = ValidString("Nhap chuc vu: ");
                    string dProLanguage = ValidString("Nhap ngon ngu lap trinh: ");
                    Console.WriteLine();
                    Developer dv = new Developer(dName, dPosition, dProLanguage);
                    dv.DisplayInfo();
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