/* OOP Interface
1. Định nghĩa một interface IMovable với phương thức Move()
2. Tạo lớp Car và Bike triển khai interface IMovable
3. Ghi đè phương thức Move() cho từng lớp
4. Tạo danh sách các đối tượng IMovable và gọi phương thức Move()
*/

using System;
using System.Collections.Generic;

//định nghĩa interface
public interface IMovable{
    public void Move(); 
    //phương thức chung, ai dùng interface đều phải có nó
}

public class Car : IMovable{
    public void Move(){
        Console.WriteLine("Car is moving ...");
    }
}

public class Bike : IMovable{
    public void Move(){
        Console.WriteLine("Bike is moving ....");
    }
}

public class Program{
    static void Main(){
        //Tạo danh sách các đối tuộng có thể di chuyển
        List<IMovable> ds = new List<IMovable>();

        //thêm đối tượng vào danh sách
        ds.Add(new Car());
        ds.Add(new Bike());

        //duyệt và gọi phương thức Move()
        Console.WriteLine("Các phương tiện bắt đầu ...");
        foreach(IMovable i in ds){
            i.Move();
        }
    }
}