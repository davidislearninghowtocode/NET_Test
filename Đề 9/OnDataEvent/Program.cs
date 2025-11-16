/*
Câu 2: Chủ đề nâng cao (Events and Delegates):
a) Định nghĩa một event OnDataReceived. (1 điểm)
b) Tạo phương thức kích hoạt event khi dữ liệu được nhận. (1 điểm)
c) Đăng ký một phương thức xử lý event để hiển thị thông báo. (1.5 điểm)
d) Kích hoạt event và kiểm tra phương thức xử lý. (1.5 điểm)
Phần này tôi sẽ thêm phần khi nhập vào một kiểu dữ liệu sẽ show ra đó là kiểu dữ liệu gì
*/

using System;
public class DataEvent : EventArgs{
    public string ReceivedData {get;}
    public string DataType {get;}
    public DateTime ReceivedTime{get;}

    public DataEvent(string receivedData, string dataType, DateTime receivedTime){
        ReceivedData = receivedData;
        DataType = dataType;
        ReceivedTime = receivedTime;
    }
}

public class DataHandler{
    public event EventHandler<DataEvent> OnDataReceived;
    
    //ham xac dinh kieu data
    public string DetectData(string input){
        if(int.TryParse(input, out _))
            return "Int";

        if(double.TryParse(input, out _))
            return "Double";

        if(bool.TryParse(input, out _))
            return "Bool";
        
        if(DateTime.TryParse(input, out _))
            return "DateTime";
        
        return "string";
    }

    //phuong thuc kich hoat data
    public void CompleteEvent(string input){
        string detectType = DetectData(input);
        OnDataReceived?.Invoke(this, new DataEvent(input, detectType, DateTime.Now));
    }
}

class Program{
    public static void FinishEvent(object sender, DataEvent e){
        Console.Write("\n[Notification]");
        Console.WriteLine($"Gia tri nhan duoc: {e.ReceivedData}.");
        Console.WriteLine($"Kieu du lieu: {e.DataType}");
        Console.WriteLine($"Thoi gian {e.ReceivedTime}");
        Console.WriteLine();
    }

    static void Main(){
        DataHandler dt = new DataHandler();
        dt.OnDataReceived += FinishEvent;

        while(true){
            string s;
            do{
                Console.Write("Nhap du lieu: ");
                s = Console.ReadLine()?.Trim();
                if(string.IsNullOrWhiteSpace(s)){
                    Console.Write("Khong hop le. Nhap lai: ");
                }
            }while(string.IsNullOrWhiteSpace(s));

            //kich hoat event
            dt.CompleteEvent(s);

            string answer;
            do{
                Console.Write("Ban co muon tiep tuc (y/n): ");
                answer = Console.ReadLine()?.Trim().ToLower();
            }while(answer != "y" && answer != "n");
            if(answer == "n") break;
        }
    }
}