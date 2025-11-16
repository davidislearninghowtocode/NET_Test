/* Multicast Delegate
1. Định nghĩa một multicast delegate NotificationHandler
2. Tạo các phương thức EmailNotification() và SmsNotification()
3. Đăng ký cả hai phương thức vào multicast delegate
4. Kích hoạt delegate và kiểm tra các phương thức được gọi
*/

using System;

//multicast delegate
public delegate void NotificationHandler(string message);

class Program{
    public static void EmailNotification(string messgae){
        Console.WriteLine($"[Email] Gui thanh cong noi dung: {messgae}");
        Console.WriteLine($"[Email] Gui vao luc: {DateTime.Now}");
        Console.WriteLine();
    }

    public static void SmsNotification(string message){
        Console.WriteLine($"[SMS] Gui thanh cong noi dung: {message}");
        Console.WriteLine($"[SMS] Gui vao luc {DateTime.Now}");
        Console.WriteLine();
    }

    //ham kiem tra nhap chuoi
    public static string ValidString(string prompt){
        string input;
        do{
            Console.Write(prompt);
            input = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(input)){
                Console.Write("Khong duoc de trong. Nhap lao: ");
            }
        }while(string.IsNullOrWhiteSpace(input));
        return input;
    }

    static void Main(){
        while(true){
            string message = ValidString("Nhap noi dung thong bao: ");
            Console.WriteLine();


            Console.WriteLine("\nHe thong gui thong bao");
            Console.WriteLine("1. Email");
            Console.WriteLine("2. SMS");
            Console.WriteLine("3. Both");
            Console.WriteLine("Your choice: ");

            int choice;
            while(!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3){
                Console.Write("Lua chon khong hop le. Nhap lai: ");
            }

            NotificationHandler dv = null;

            switch(choice){
                case 1: //chỉ gửi email
                    dv += EmailNotification;
                    break;

                case 2: //chi gui sms
                    dv += SmsNotification;
                    break;

                case 3: //send both
                    dv += EmailNotification;
                    dv += SmsNotification;
                    break;
            }

            //kich hoat delegate va kiem tra phuong thuc duoc goi
            Console.WriteLine("Ket qua gui thong bao");
            dv?.Invoke(message);

            string answer;
            do{
                Console.Write("Ban co muon tiep tuc (y/n): ");
                answer = Console.ReadLine()?.Trim().ToLower();
            }while(answer != "y" && answer != "n");
            if(answer == "n") break;
        }
    }
}