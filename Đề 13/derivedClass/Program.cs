/*
a) Định nghĩa lớp BaseClass với phương thức ảo Display(). (1 điểm)
b) Tạo lớp DerivedClass kế thừa BaseClass và ghi đè phương thức Display(). (1 điểm)
c) Tạo đối tượng của DerivedClass và gọi phương thức Display(). (1.5 điểm)
d) Minh họa sự khác biệt khi gọi phương thức thông qua lớp cha và lớp con. (1.5 điểm)
*/

using System;

public class BaseClass{
    public virtual void Display(){
        Console.WriteLine("This is from Base class");
    }
}

public class DerivedClass : BaseClass{
    public override void Display()
    {
        Console.WriteLine("This is from Derived class");
    }
}

class Program{
    static void Main(){
        BaseClass bc = new BaseClass();
        bc.Display();

        DerivedClass dc = new DerivedClass();
        dc.Display();

        //polymorphsm
        BaseClass poly = new DerivedClass();
        poly.Display();
    }
}