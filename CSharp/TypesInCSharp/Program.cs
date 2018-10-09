using System;

namespace TypesInCSharp
{
    class Program
    {
        enum day //it is used a int for each item (default)
        {
            monday,//the enumeration stars with number 0 (default)
            tuesday,
            wednesday,
            thursday,
            friday,
            saturday,
            sunday
        }
        enum month:byte //it is used a byte
        {
            january = 2,//the enumeration stars with number 2
            february,
            march,
            april,
            may,
            june,
            july,
            agust,
            september,
            october,
            novermber,
            december
        }
        struct point
        {

            public int x;
            public int y;
            public int z; 

            public point(int x, int y)
            {
                this.x = x;
                this.y = y;
                this.z = 0;
            }

            public point(int x, int y, int z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }

        class person
        {
            public int age;
            public string name;

            public person(int age, string name)
            {
                this.age = age;
                this.name = name;
            }
        }

        class student : person
        {
           

            public student(int age, string name):base(age, name)
            {
                
            }

        }

        static void Main(string[] args)
        {
            //examples();
            //struturef();
            classes();

            Console.ReadLine();
        }

        static void classes()
        {
            student Student = new student(name: "angel", age: 39);
            Console.WriteLine("the student's name is {0} and is {1} years old",Student.name,Student.age);
        }
        static void struturef()
        {

            //Struct is used to encapsulate the attribute and behavior of an entity. It’s used to define those objects which
            //hold small memory. Most primitive types(int, float, bool) in C# are made up from struct. Struct doesn’t
            //support all object-oriented principles.


            //Default Constructor(parameter less) is not allowed in struct.
            //Constructor is optional in struct but if included it must not be parameterless.
            //Constructor can be overload but each overloaded constructor must initialize all
            //data members.
            //Data members or fields cannot be initialized in the struct body. Use constructor to
            //initialize them.
            //Creating the object (without a new keyword) would not cause constructor calling
            //even though a constructor is present.
            point Point = new point(2, 3, 5);
            Console.WriteLine("x = {0}, y = {1}, z = {2}", Point.x, Point.y, Point.z);

            point P;
            P.x = 1;
            P.y = 2;
            P.z = 3;

            Console.WriteLine("x = {0}, y = {1}, z = {2}", P.x, P.y, P.z);
        }

        static void examples()
        {
            day Day = day.monday;
            Console.Write("Enter a day (0-6)");
            int iDay  = int.Parse(Console.ReadLine()) ;
            Day = (day)iDay;

            switch (Day)
            {
                case day.saturday:
                    Console.WriteLine("It is a day of weekend (number of day {0})",(int)Day);
                    break;
                case day.sunday:
                    goto case day.saturday;
                default:
                    Console.WriteLine("It is a day of week (number of day {0})", (int)Day);
                    break;
             
            }
        }

    }

}
        
