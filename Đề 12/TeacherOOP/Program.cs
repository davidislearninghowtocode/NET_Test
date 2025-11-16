/*
Câu 1: Chủ đề OOP (Constructor Inheritance - Kế thừa constructor):
a) Định nghĩa lớp Person với constructor nhận tham số name. (1 điểm)
b) Tạo lớp Student kế thừa từ Person và sử dụng constructor của lớp cha. (1 điểm)
c) Tạo lớp Teacher kế thừa từ Person và sử dụng constructor của lớp cha. (1.5 điểm)
d) Tạo các đối tượng Student và Teacher, hiển thị thông tin. (1.5 điểm)
*/

using System;

public class Person{
    public string Name{get;set;}
    
    public Person(string name){
        Name = name;
    }

    public virtual void Display(){
        Console.WriteLine($"Ten {Name}");
    }
}

public class Student : Person{
    public string StudentID {get;set;}
    public string Major {get;set;}

    public Student(string name, string studentID, string major) : base(name){
        StudentID = studentID;
        Major = major;
    }

    public override void Display()
    {
        Console.WriteLine("=== Thong tin sinh vien ===");
        base.Display();//gọi phương thức của lớp cha
        Console.WriteLine($"Ma sinh vien: {StudentID}");
        Console.WriteLine($"Chuyen nganh {Major}");
        Console.WriteLine();
    }
}

public class Teacher : Person{
    public string TeacherID{get;set;}
    public string Subject{get;set;}

    public Teacher(string name, string teacherID, string subject) : base(name){
        TeacherID = teacherID;
        Subject = subject;
    }

    public override void Display()
    {
        Console.WriteLine("=== Thong tin giao vien===");
        base.Display();
        Console.WriteLine($"Ma giao vien: {TeacherID}");
        Console.WriteLine($"Mon hoc giang day: {Subject}");
        Console.WriteLine();
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


        while(true){
            Console.WriteLine("\nDanh sach chon");
            Console.WriteLine("1. Teacher");
            Console.WriteLine("2. Student");
            Console.WriteLine("Your choice: ");

            int choice;
            while(!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 2){
                Console.Write("Nhap sai. Nhap lai: ");
            }

            string message;
            switch(choice){
                case 1:
                    Console.WriteLine("\n  Nhap thon tin giao vien  ");
                    string teacherName = ValidString("Nhap ten: ");
                    string teacherID = ValidString("Nhap ma giao vien: ");
                    string subject = ValidString("Nhap mon giang day");

                    Teacher gv = new Teacher(teacherName, teacherID, subject);
                    gv.Display();
                    Console.WriteLine();
                    break;

                case 2:
                    Console.WriteLine("\n  Nhap thong tin hoc sinh  ");
                    string studentName = ValidString("Nhap ten hoc sinh: ");
                    string studentID = ValidString("Nhap ma so hoc sinh: ");
                    string major = ValidString("Nhap chuyen nganh: ");
                    Console.WriteLine();
                    Student hs = new Student(studentName, studentID, major);
                    hs.Display();
                    break;                  
            }

            string answer;
            do{
                Console.Write("Ban co muon tiep tuc nhap (y/n): ");
                answer = Console.ReadLine()?.Trim().ToLower();
            }while(answer != "y" && answer != "n");
            if(answer == "n") break;
        }
    }
}