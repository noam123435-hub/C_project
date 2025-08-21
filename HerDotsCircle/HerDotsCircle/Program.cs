using System.Runtime.InteropServices;

namespace HerDotsCircle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Circle[] circles=new Circle[3];
            circles[0] = new Circle(5,5,3);
            circles[1] = new Circle(10);
            circles[2] = new Circle();
            for (int i = 0; i< 3; i++)
                circles[i].printCircle();
            DotAt3D dotAt3D = new DotAt3D();
            dotAt3D.setX(5);
            dotAt3D.setY(4);
            dotAt3D.setZ(10);
            dotAt3D.printDotAt3D();
            Dot dot;
            for (int i = 0; i < 3; i++)
            {
                dot = circles[i];
                dot.print();
            }
            dot = dotAt3D;
            dot.print();
        }
        class Dot
        {
            double x;
            double y;
            public void print()
            {
                Console.WriteLine("the Coordinates of the dot are X({0},Y({1})",this.x,this.y);
            }
            public bool setX(double x)
            {
                this.x = x;
                return true;
            }
            public double getX()
            {
                return this.x;
            }
            public bool setY(double y)
            {
                this.y = y;
                return true;
            }
            public double getY()
            {
                return this.y;
            }
            public Dot(double x, double y)
            {
                this.setX(x);
                this.setY(y);
            }
            public Dot() { }
        }
        class Circle:Dot
        {
            double radius;
            public void printCircle()
            {
                Console.WriteLine("The Circle's radius is {0} and ",this.radius);
                this.print();
            }
            public bool setRadius(double radius)
            {
                this.radius = radius;
                return true;
            }
            public double getRadius()
            {
                return this.radius;
            }
            public Circle(double x, double y,double radius):base(x,y)
            {
                this.setRadius(radius);
            }
            public Circle(double radius):base(10,10)
            {
                this.setRadius(radius);
            }
            public Circle() : base(100, 100) { }
        }
        class DotAt3D:Dot
        {
            double z;
            public void printDotAt3D()
            {
                this.print();
                Console.WriteLine("And Z({0}).",this.z);
            }
            public bool setZ(double z)
            {
                this.z = z;
                return true;
            }
            public double getZ()
            {
                return this.z;
            }
        }
    }
}
