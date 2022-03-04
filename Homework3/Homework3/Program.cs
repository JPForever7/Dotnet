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
    }

}
public class ShapeFactory
{

    //使用 getShape 方法获取形状类型的对象
    public Shape getShape(String shapeType,int edge1,int edge2,int edge3)
    {
        if (shapeType == null)
        {
            return null;
        }

        if (shapeType.Equals("Square"))
        { 
            return new Square(edge1);
        }
        else if (shapeType.Equals("Rectangle"))
        {
            return new Rectangle(edge1 , edge2);
        }
        else if (shapeType.Equals("Triangle"))
        {
            return new Triangle(edge1,edge2,edge3);
        }
        return null;
    }
}

namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ShapeFactory sf = new ShapeFactory();
            Shape s1 = sf.getShape("Square",1,1,1);
            //正常输入 不会出现错误
            s1.islegal();
            //预计输出面积 1
            Console.WriteLine(s1.calculateArea());
            //测试边长为负数 预计会出现 异常
            //Shape s2 = sf.getShape("Square", -1, 1, 1);
            
            //测试矩形的面积
            Shape rec = sf.getShape("Rectangle", 1, 2, 3);
            Console.WriteLine(rec.calculateArea());


            // 测试三角形面积

            Shape tri = sf.getShape("Triangle", 3, 4, 5);
            Console.WriteLine(tri.calculateArea());


            //测试三边 无法组成 三角形是否会报错
            Shape triILegal = sf.getShape("Shape", 3, 2, 1);
           triILegal.islegal();


        }
    }
}
