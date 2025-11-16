/*
Chủ đề OOP- static members
- định nghĩa lớp Counter với thuộc tính count
- tạo phouwng thức tĩnh Increment() để tăng giá trị count
- tạo các đối tượng Counter và gọi phương thức Increment()
- kiểm tra giá trị của thuộc tính tĩnh count
*/
using System;
public class Counter{//dem số lần tạo đối tượng hoặc số lần gọi Increment
    public static int Count{get; private set;}

    public static void Increment(){
        Count++;
    }

    public Counter(){ //constructor
        Increment();
        //số lượng object Counter được tạo sẽ làm Count constructor tăng
    }

    public static void Reset(){
        Count = 0;
        //vì để private set nên dùng reset để back về 0
    }
}

class Program{
    static void Main(){
        Counter.Reset(); //đặt count = 0 để bắt đầu

        Counter c1 = new Counter();
        Counter c2 = new Counter();

        Console.WriteLine($"Static count = {Counter.Count}");

        Counter.Increment();
        Console.WriteLine($"Static count sau khi Increment = {Counter.Count}");
    }
}