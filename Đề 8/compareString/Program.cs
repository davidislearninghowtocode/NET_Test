/*
Câu 2: Chủ đề nâng cao (Lambda Expressions):
a) Định nghĩa delegate CompareHandler. (1 điểm)
b) Sử dụng biểu thức lambda để so sánh hai chuỗi và trả về kết quả. (1 điểm)
c) Gọi biểu thức lambda với hai chuỗi bất kỳ. (1.5 điểm)
d) Giải thích cách biểu thức lambda rút gọn cú pháp của phương thức. (1.5 điểm)

*/
using System;

public delegate bool CompareHandler(string a, string b);

class Program{

    public static string ValidString(string prompt){
        string s;
        do{
            Console.Write(prompt);
            s = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(s)){
                Console.WriteLine("Chuoi khong duoc de trong. Nhap lai: ");
            }
        }while(string.IsNullOrWhiteSpace(s));
        return s;
    }
    static void Main(){
        while(true){
        string s1 = ValidString("Nhap vao chuoi so 1: ");
        string s2 = ValidString("Nhap vao chuoi so 2: ");

        CompareHandler ss = (a,b) => a.Equals(b);
        bool result = ss(s1, s2);

        if(result){
            Console.WriteLine($"Hai chuoi {s1} va {s2} giong nhau.");
        }else{
            Console.WriteLine($"Hai chuoi {s1} va {s2} khac nhau.");
        }

        string answer;
        do{
            Console.Write("Ban co muon nhap tiep (y/n): ");
            answer = Console.ReadLine()?.Trim().ToLower();
        }while(answer != "y" && answer != "n");
        if(answer == "n") break;
        }
        Console.WriteLine();
    }
}