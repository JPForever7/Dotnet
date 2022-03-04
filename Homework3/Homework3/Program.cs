using System;

public interface Shape {
    int calculateArea();
    void islegal();
}
public class Square : Shape
{
    int edge;
   
    public int calculateArea()
    {
        return edge * edge;
    }
    public void islegal()
    {
        if (edge < 0) throw new Exception("ilegal edge");
    }
    public Square(int edge1)
    {
        edge = edge1;
        islegal();
    }
}
public class Rectangle :Shape
{
    int edgeA;
    int edgeB;
    public int calculateArea()
    {
        return edgeA * edgeB;
    }
    public void islegal()
    {
        if (edgeA <= 0 || edgeB<=0) throw new Exception("ilegal edge");
    }
    public Rectangle (int edge1 , int edge2)
    {
        edgeA = edge1;
        edgeB = edge2;
        islegal();
    }
}
public class Triangle : Shape
{
    int edgeA;
    int edgeB;
    int edgeC;
    public int calculateArea()
    {
        int p = (edgeA + edgeB + edgeC) / 2;
        double area = Math.Sqrt(p * (p - edgeA) * (p - edgeB) * (p - edgeC));
        return (int)area;
    }
    public void islegal()
    {
        if (edgeA < 0||edgeB<0||edgeC<0) throw new Exception("ilegal edge");
        if(edgeA<edgeB+edgeC && edgeB<edgeA+edgeC && edgeC<edgeA+edgeB)
        {

        }else
        {
            throw new Exception("ilegal edge");
        }
    }
    public Triangle(int edge1,int edge2 ,int edge3)
    {
        edgeA = edge1;
        edgeB = edge2;
        edgeC = edge3;
        islegal();
    }

}
public class ShapeFactory
{

    //使用 getShape 方法获取形状类型的对象
    public Shape getShape(String shapeType,params int[] list)
    {
       
        
        if ("Square".Equals(shapeType))
        { 
            return new Square(list[0]);
        }
        else if ("Rectangle".Equals(shapeType))
        {
            return new Rectangle(list[0] , list[1]);
        }
        else if ("Triangle".Equals(shapeType))
        {
            return new Triangle(list[0],list[1],list[2]);
        }
        else
        {
            throw new Exception("Object creation exception");
        }
    }
}

namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            ShapeFactory sf = new ShapeFactory();
            Shape s1 = sf.getShape("Square", 1);
            Shape s2 = sf.getShape("Square", 1);
            Shape s3 = sf.getShape("Square", 1);
            Shape s4 = sf.getShape("Rectangle", 1,2);
            Shape s5 = sf.getShape("Rectangle", 1, 2);
            Shape s6 = sf.getShape("Rectangle", 1, 2);
            Shape s7 = sf.getShape("Rectangle", 1, 2);
            Shape s8 = sf.getShape("Rectangle", 1, 2);
            Shape s9 = sf.getShape("Triangle", 3, 4, 5);
            Shape s10 = sf.getShape("Triangle", 3, 4, 5);
            Shape[] slist = { s1, s2, s3, s4, s5, s6, s7, s8, s9, s10 };
            int sum=0;
            int ave;
            foreach (Shape s in slist) 
            {
                sum += s.calculateArea();
            }
            ave = sum / 10;
            Console.WriteLine("平均面积是"+ave);


           





        }
    }
}
