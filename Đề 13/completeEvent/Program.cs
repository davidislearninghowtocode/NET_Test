/*
Câu 2: Chủ đề Event:
a) Định nghĩa một event OnProcessCompleted trong lớp Process.
b) Tạo phương thức CompleteProcess() để kích hoạt event.
c) Đăng ký một phương thức xử lý event để hiển thị thông báo khi quá trình hoàn tất.
d) Kích hoạt event và hiển thị kết quả.
*/

using System;
using System.Threading;

public class ProcessEventArgs : EventArgs{
    public string TaskName{get;}
    public DateTime FinishTime{get;}

    public ProcessEventArgs(string taskName){
        TaskName = taskName;
        FinishTime = DateTime.Now;
    }
}

public class Process{
    public event EventHandler<ProcessEventArgs> OnProcessCompleted;
    public string Name;
    public Process(string name){
        Name = name;
    }

    public void CompleteProcess(){
        Console.WriteLine($"Request {Name} is being worked ...");
        Thread.Sleep(500);
        OnProcessCompleted?.Invoke(this, new ProcessEventArgs(Name));
    }
}

class Program{
    public static void FinishTask(object sender, ProcessEventArgs e){
        Console.WriteLine($"[Notification]: Request [{e.TaskName}] is done.");
        Console.WriteLine($"[Notification]: Finished [{e.FinishTime}]");
        Console.WriteLine();
    }

    static void Main(){
        Task yc1 = new Task("working with marketing team.");
        Task yc2 = new Task("sending report for dev team");

        //đăng ký sự kiện
        yc1.OnCompleted += FinishTask;
        yc2.OnCompleted += FinishTask;

        //kích hoạt thông báo
        yc1.CompleteTask();
        yc2.CompleteTask();
    }
}