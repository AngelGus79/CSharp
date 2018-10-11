using System;

namespace GettingStartedwithPOO
{


    abstract class cVehicle
    {
        public int wheels { get; set; }
        public int maxSpeed { get; set; }

        public abstract void run();
    }

    class jet: cVehicle
    {
        public override void run()
        {
            base.wheels = 8;
            base.maxSpeed = 900;
        }
    }

    class car: cVehicle
    {
        public override void run()
        {
            base.wheels = 4;
            base.maxSpeed = 350;
        }
    }

    class boat: cVehicle
    {
        public override void run()
        {
            base.wheels = 0;
            base.maxSpeed = 200;
        }
    }
    enum landscape: byte
    {
        air,
        road,
        water
    }
    class person
    {
        public string name { get; set; }
        public string lastName { get; set; }
        public DateTime birthDay  { get; set; }
        public bool sex { get; set; }

        protected person(string name, string lastName, DateTime birthDay, bool sex)
        {
            this.name = name;
            this.lastName = lastName;
            this.birthDay = birthDay;
            this.sex = sex;
        }
    }
    class student: person
    {
        private string _enrollment;
        public string enrollment {
            get {
                return _enrollment;
            }
            set {
                value = _enrollment;
                    }
        }

        public student(string name, string lastName, DateTime birthDay, bool sex) :base(name,  lastName,  birthDay, sex)
        {
            

        }

        class teacher: person
        {
            public string id { get; } //read-only property
            public DateTime beginningDateLikeTeacher { get; private set; } // another way to make a read-only property
            public teacher(string name, string lastName, DateTime birthDay, bool sex) : base(name, lastName, birthDay, sex)
            {

            }
        }
    }
    class temperature
    {
        private float[] temp = { 1.2F, 2.2F, 3.5F, 5.2F, 6.3F, 3.6F, 6.6F };
        private int[] tem = { 1, 2, 3 };
        public float this [int index]
        {
            get {
                if (index >= 0 && index < temp.Length )
                {
                    return temp[index];

                }else
                {
                    Console.WriteLine("index must be greater or equal than 0 and less than {0}", temp.Length);
                    return 0;
                }

                }
            set {

                if (index >= 0 && index < temp.Length)
                {
                    temp[index] = value;

                }
                else
                {
                    Console.WriteLine("index must be greater or equal than 0 and less than {0}", temp.Length);
                }
            }
        }
        public int this[byte index]
        {
            get { return tem[index]; }
            set { tem[index] = value; }
        }
    }
    abstract class vehicle
    {
        protected int wheels;
        public int Wheels { get { return wheels; } set { wheels = value; } }
        public abstract int ringsize();
    }
    class bike : vehicle
    {
        public bike()
        {
            base.wheels = 2;
        }
        public override int ringsize()
        {
            return 12;
        }
    }
    class distance
    {
        public int meters { get; set; }
        public distance()
        {
            this.meters = 0;
        }
        public distance(int meters)
        {
            this.meters = meters;
        }
        
        public static distance operator ++(distance Distance)
        {
            Distance.meters ++;
            return Distance;
        }

        public static distance operator +(distance D1, distance D2)
        {
            distance D3 = new distance();
            D3.meters = D1.meters + D2.meters;
            return D3;
        }

        public static bool operator >(distance D1, distance D2)
        {
            if (D1.meters > D2.meters)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator <(distance D1, distance D2)
        {
            if (D1.meters > D2.meters)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    interface IPrinter
    {
        int print { get; set; }
        int configure { get; set; }
    }
    class LaserPrinter : IPrinter
    {
        public int print { get; set; }
        public int configure { get; set; }
    }
    interface IEnglish
    {
        int marks { get;  }
    }
    interface IMath
    {
        int marks { get; }
    }
    class Scholar : IEnglish, IMath
    {
        private int eMarks;
        private int mMarks;
        int IEnglish.marks { get { return eMarks; }   }
        int IMath.marks { get { return mMarks; } }
        public Scholar(int eMarks, int mMarks)
        {
            this.eMarks = eMarks;
            this.mMarks = mMarks;

        }
        
    }
    class figure
    {
        public figure()
        {

        }

        public int area { get; set; }
        public int perimeter { get; set; }

        public virtual int getArea()
        {
            return area;
        }

        public int getPerimeter()
        {
            return perimeter;
        }
    }

    class circle: figure
    {
        public circle()
        {

        }

        public override int getArea()
        {
            return -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Specifiers();
            //indexers();
            //interfaces();
            //polymorphism();
            challenge1();
            Console.ReadLine();
        }
        static void Specifiers()
        {
            //1.Public, members defined with public access specifiers are accessible within the class as well as outside the class, and outside the project
            //2.Private, members defined with private access specifiers are accessible just within the class 
            //3.Protected, members defined with protected access specifiers are accessible within the class and also within its child classes.
            //4.Internal, members defined with internal access specifiers are accessible within the class as well as outside the class. But they are not accessible to any class which is defined outside the project’s assembly.
            //5.Protected Internal, members defined with protected internal specifiers as accessible within the class and also within its child classes but just in their project's assembly.
           
            student Student = new student("Jhon","Balboa", DateTime.Parse("05/07/1979"),true);
            //if members name, lastname, etc have protected specifier, they would not be accesible in the next code
            Console.WriteLine("the student name is {0} {1} and his/her birthday is {2} and his/her sex is {3}", Student.name, Student.lastName, Student.birthDay, Student.sex);

        }

        public static void indexers()
        {
            //Indexers are used to encapsulate the value of an array. It behaves and works like property. It also uses access
            //specifiers, which give better control to read, write, or manipulate an array’s value. It creates a sandbox over
            //an array, which protects it from:
            //1.saving false data in an array;
            //2. using the wrong index value in an array;
            //3.changing the reference of an array from the outer world.

            temperature Temperature = new temperature();
            Temperature[0] = 10.0F;
            float temp = Temperature[(Byte)2];
            float temp1 = Temperature[10];
            Console.WriteLine("It was set {0}, and get {1}", Temperature[0], temp);

        }
        public static void interfaces()
        {
            //Interfaces
// 1.Do not use access specifiers with interface’s members.
//2. Do not define definition of interface members.
//3. Auto-property, indexer, method, and event can be used as a member of an
//interface.
//4. Class must implement full definition of interface’s members.Otherwise error
//may occur at compile/run time.
//5. Class can implement more than one interface.
            Scholar scholar = new Scholar(10,10);
            Console.WriteLine("English marks: {0}, Math marks: {1}",((IMath)scholar).marks, ((IEnglish)scholar).marks);
        }
        public static void polymorphism()
        {
            /*  1. Static Polymorphism 
                    -1.1 Method Overloading
                    -1.2 Operator Overloading
                         -1.2.1 Unary Operators
                         -1.2.2 Binary Operators
                         -1.2.3 Comparison Operators   
                2. Dynamic Polymorphism 
                    -2.1 Virtual method
                    -2.2 Abstract method
             */
            //1.1 Method Overloading
            distance Distance1 = new distance();
            distance Distance2 = new distance(5); //the constructor method is overloaded

            //-1.2.1 Unary Operators
            distance Distance3 = Distance1++;
            Console.WriteLine("The Distance incremented is {0}", Distance3.meters);
            
            //-1.2.2 Binary Operators
            distance Distance4 = Distance2 + Distance3;
            Console.WriteLine("The sum of distance 1 and 2 is {0}", Distance4.meters);

            //-1.2.3 Comparison Operators
            bool flag = Distance2 > Distance3;

            //-2.1 Virtual method
            figure figure1 = new circle();
            Console.WriteLine("the area from the override method is {0}",figure1.getArea());

            //-2.2 Abstract method
            vehicle Vehicle = new bike();
            Console.WriteLine("the ringzise is {0}", Vehicle.ringsize());

        }
        public static void challenge1()
        {
            landscape Landscape = landscape.air;

            cVehicle vehicle;
            switch (Landscape)
            {
                case landscape.air:
                    vehicle = new jet();
                    vehicle.run();
                    Console.WriteLine("the selected vehicle has {0} wheels and run at {1} km/h", vehicle.wheels, vehicle.maxSpeed);
                    break;
                case landscape.road:
                    vehicle = new car();
                    vehicle.run();
                    Console.WriteLine("the selected vehicle has {0} wheels and run at {1} km/h", vehicle.wheels, vehicle.maxSpeed);
                    break;
                case landscape.water:
                    vehicle = new boat();
                    vehicle.run();
                    Console.WriteLine("the selected vehicle has {0} wheels and run at {1} km/h", vehicle.wheels, vehicle.maxSpeed);
                    break;

            }

            
        }
    }
}
