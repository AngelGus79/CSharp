using System;

namespace TypesInCSharp
{
   static class extensionClass
    {
        public static bool myExtensionMethod(this int age, int compareValue)
        {

            if (age > compareValue)
            {
                return true;

            }
            else
            {
                return false;
            }

        }
    }
    class Byte
    {
        public int bits = 8;
        public static implicit operator int(Byte value)
        {
            return value.bits;
        }

        public string str = "eigth";
        public static explicit operator string(Byte value)
        {
            return value.str;
        }
    }
    class Fahrenheit
    {
        public double temperature;
        public Fahrenheit(double temperature)
        {
            this.temperature = temperature;
        }
        public static implicit operator Celsius(Fahrenheit fahrenheit)
        {
            double celsiusValue = (fahrenheit.temperature - 32) / 1.8;
            Celsius celsius = new Celsius(celsiusValue);
            return celsius;
        }
    }
    class Celsius
    {
        public double temperature;
        public Celsius(double temperature)
        {
            this.temperature = temperature;
        }

        public static implicit operator Fahrenheit(Celsius celsius)
        {
            double faharenheitValue = celsius.temperature * 1.8 + 32;
            Fahrenheit faharenheit = new Fahrenheit(faharenheitValue);
            return faharenheit;
        }
    }

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

            public static implicit operator string(person Person)
            {
                return Person.name;
            }
        }

        class student : person
        {
           

            public student(int age, string name):base(age, name)
            {
                
            }

           
        }

        static class staticClass
        {
            public static int i;

            static staticClass() //the static constructor must not hace parameters and constructor must be private
            {
                i = 20;
            }

            public static void printi()
            {
                Console.WriteLine(i);
            }
            public static void incrementi()
            {
                i++;
            }
        }

        static void Main(string[] args)
        {
            //examples();
            //struturef();
            //classes();
            //specialtypes();
            //staticMethod();
            //TypeConversion();
            challenge();

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

        static void specialtypes()
        {
            //Special Types in C#
            
            // System.Object type

            object integer = 5;
            object sstring = "hello, this is a string";
            object oClass = new student(39, "Angel"); //object do not have age and name fields so it is not posible to access them with oClass object
            //Console.WriteLine("the name is:{0}, and the age is: {1}", oClass.name, oClass.age); this code has a mistake because it can not access to name and age

            // anonymous type

            var anonymus = new { age = 39, name = "Angel", sex = 1, dateofBirth = 1979 };
            Console.WriteLine("this is and anonymus type {0}, {1}, {2}",anonymus.age,anonymus.name, anonymus.sex);

            // dynamic type
            // it can chage the type
            dynamic variable = 3;
            variable = new student(39, "Angel");
            variable = "hello, now I am a string";
            Console.WriteLine(variable);


            // nullable type

            int? i = null;

            int j = i ?? 0;


            Nullable<int> k = null;

            int l = k ?? 0;

            Console.WriteLine("i = {0}, j = {1}, k = {2}, l = {3}", i, j, k, l);

            // static type





        }

       static void ExtensionClass()
        {

//            Extension methods are special static methods.They inject addition methods without changing, deriving, or
//recompiling the original type. They are always called as if they were instance method.
//Extension methods are always defined inside static class.
//The first parameter of extension method must have “this” operator, which tells on
//whose instance this extension method should give access.
//The extension method should be defined in the same namespace in which it is used,
//or import the namespace in which the extension method was defined.
            int a = 22;
            bool flag = a.myExtensionMethod(3);
            
        }

        static void TypeConversion()
        {
            // Conversion of one type to another is called type conversion.Type conversion has three forms:
            //1.Implicit Type Conversion
            //2.Explicit Type Conversion
            //3.User Defined Type Conversion


            //1.Implicit Type Conversion (commonly from derived class to base class)
            person Person = new student(39,"Angel");

            //2.Explicit Type Conversion (commonly from base class to derived class)
            //if it has an speciall sintax is a explicit conversion, in this case 'as' keyword
            //if conversion is not successful then  Student gets null value.
            student Student = Person as student;
            //another way to do explicit conversion 
            
            if(Person is student) //if object Person is convertible to class student, 'is' keyword is used to prevent exception
            {
                Student = (student)Person;
            }

            //3.User Defined Type Conversion
            // it can be Implicit User Defined Conversion or Explicit User Defined Conversion

            //Implicit User Defined Conversion
            //For implicit conversion, a special static method is defined with an implicit and operator keyword
            //inside the type definition.

            Byte bbyte = new Byte();
            int totalBits = bbyte;

            Console.WriteLine("this is a Implicit user defined conversion {0}", totalBits);

            string sTotalBits = (string)bbyte;

            Console.WriteLine("this is a Explicit user defined conversion {0}", sTotalBits);

            student Student2 = new student(name: "Jhon Robinson", age: 39);
            string sStudent = Student2;
            Console.WriteLine("This is a implicit user defined conversion with student class {0}",sStudent);

        }

        static void staticMethod()
        {
            //the constructor runs only once when a member is referenced
            Console.WriteLine(staticClass.i); //before the i was referenced, the constructor ran.
            staticClass.incrementi();
            staticClass.printi();
               
        }

        static void challenge()
        {
            Fahrenheit faharenheit = new Fahrenheit(120);
            Celsius celsius = faharenheit;

            Celsius celsius1 = new Celsius(45);
            Fahrenheit faharenheit1 = celsius1;

            Console.WriteLine("this is an example of a implicit user defined conversion {0}°C, {1}°F", celsius.temperature, faharenheit1.temperature);

        }

    }

}
        
