/*
-định nghĩa một event OnCompleted trong lớp Task
-tạo phương thức CompleteTák() để kích hoạt event OnCompleted
-Đăng ký một phương thức xử lý event để thông báo khi task hoàn thành
-tạo một đối tượng của task và kích hoạt event OnCompleted
*/

using System;
using System.Threading;

//lớp lưu trữ thông tin của sự kiện
public class TaskEventArgs : EventArgs{
    public string TaskName{get;}
    public DateTime FinishTime{get;}

    public TaskEventArgs(string nameTask){
        TaskName = nameTask;
        FinishTime = DateTime.Now;
    }
}

//quản lý công việc và kích hoạt sự kiện
public class Task{
    public event EventHandler<TaskEventArgs> OnCompleted;
    public string Name {get;}

    public Task(string name){
        Name = name;
    }

    public void CompleteTask(){
        Console.WriteLine($"Request {Name} is working ...");
        Thread.Sleep(500);
        OnCompleted?.Invoke(this, new TaskEventArgs(Name));
    }
}

class Program{
    public static void FinishTask(object sender, TaskEventArgs e){
        Console.WriteLine($"[Notification]: Request [{e.TaskName}] is done.");
        Console.WriteLine($"[Notification]: Finished [{e.FinishTime}]");
        Console.WriteLine();
    }

    static void Main(){
        //Tạo yêu cầu
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