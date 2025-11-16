/*Chủ đề OOP (Encapsulation - tính đóng gói)
1. Định nghĩa lớp Account với thuộc tính balance (được encapsulation)
2. Tạo các phương thức Deposit và Withdraw để cập nhật giá trị cho balance
3. Đảm bảo tính bảo mật cho thuộc tính balance khi không cho phép thay đổi từ outside
4. Tạo đối tượng Account và kiểm tra các phương thức Deposit và Withdraw
*/

using System;
public class Account{
    private decimal balance; //field
    public decimal Balance => balance; //property (read only) Balance kết nói với balance

    public Account(decimal sodu){
        if(sodu < 0){
            Console.WriteLine("So du ban dau khong the am.");
            balance = 0;
        }else{
            balance = sodu;
        }

        Console.WriteLine($"Tai khoan khoi tao voi so du {balance:C}");
    }

    //rut tien
    public void Deposit(decimal sotien){
        if(sotien < 0){
            Console.WriteLine("So tien gui phai lon hon 0");
            return;
        }
        balance += sotien;
        Console.WriteLine($"Da gui {sotien:C} thanh cong");
        Console.WriteLine($"So du hien tai: {balance:C}");
    }

    public void Withdraw(decimal sotien){
        if(sotien <= 0){
            Console.WriteLine("So tien rut phai lon hon 0");
            return;
        }
        if(sotien > balance){
            Console.WriteLine("So tien rut vuot qua so du");
            return;
        }
        balance -= sotien;
        Console.WriteLine($"Da rut {sotien:C} thanh cong");
        Console.WriteLine($"So du hien tai: {balance:C}");
    }
}

class Program{
    static void Main(){
        while(true){
            Console.Write("Nhap so tien ban dau");
            decimal tien;
            while(!decimal.TryParse(Console.ReadLine(), out tien) || tien < 0){
                Console.Write("Nhap lai: ");
            }

            Account ac = new Account(tien); //khoi tao voi tien vua nhap
            Console.WriteLine();

            Console.Write("Nhap so tien gui: ");
            decimal gui;
            while(!decimal.TryParse(Console.ReadLine(), out gui) || gui <= 0){
                Console.Write("Nhap lai: ");
            }
            ac.Deposit(gui);
            Console.WriteLine();

            Console.Write("Nhap so tien rut: ");
            decimal rut;
            while(!decimal.TryParse(Console.ReadLine(), out rut) || rut <= 0 || rut > ac.Balance){
                Console.WriteLine("nhap lai: ");
            }
            ac.Withdraw(rut);
            Console.WriteLine();

            Console.WriteLine($"so du hien tai: {ac.Balance:C} vnd");

            string answer;
            do{
                Console.Write("Ban co muon tiep tuc lam viec (y/n): ");
                answer = Console.ReadLine()?.Trim().ToLower();
            }while(answer != "y" && answer != "n");
            if(answer == "n") break;
        }
    }
}