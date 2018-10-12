using System;

namespace Advance_CSharp
{
    interface IVehicle
    {
        int wheels { get; set; }
        string printWheels();
    }

    class car : IVehicle
    {
        public int wheels { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string printWheels()
        {
            throw new NotImplementedException();
        }
    }
    class person
    {
        public string name { get; set; }
        public int age { get; set; }
        
        public person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public person()
        {

        }

    }
    class student: person
    {
        public student(string name, int age): base(name, age)
        {

        }

    }

    class myGenericClass<T>
    {
        public T MyProperty { get; set; }
        public T myMethod(T myParameter)
        {
            return myParameter;
        }
    }
    class myGenericClass01 <T> where T: struct
    {
        private T myField;
        public T myMethod(T myParameter)
        {
            this.myField = myParameter;
            return this.myField;
        }
    }

    class myGenericClass02<T> where T: class
    {
        public T MyProperty { get; set; }
        public T myMethod(T myParameter)
        {
            MyProperty = myParameter;
            return MyProperty;
        }
    }

    class myGenericClass03 <T> where T: person
    {
        public T MyProperty { get; set; }
        public T myMethod(T myParameter)
        {
            MyProperty = myParameter;
            return MyProperty;
        }
    }
    class myGenericClass04<T> where T : new()
    {
        public T MyProperty { get; set; }
        public T myMethod(T myParameter)
        {
            MyProperty = myParameter;
            return MyProperty;
        }
    }

    class myGenericClass05<T> where T : IVehicle
    {
        public T MyProperty { get; set; }
        public T myMethod(T myParameter)
        {
            MyProperty = myParameter;
            return MyProperty;
        }
    }

    class myGenericClass06<T, U> where T : U
    {
        public T MyProperty { get; set; }
        public T myMethod(T myParameter)
        {
            MyProperty = myParameter;
            return MyProperty;
        }
    }

    class myGenericClass07<T, M>  //it is posible to set many Generic types

    {
        public T MyProperty { get; set; }
        public T myMethod(T myParameter)
        {
            MyProperty = myParameter;
            return MyProperty;
        }
    }

    class myGenericClass08<T> where T: class, new()  //it is posible to set many constraints

    {
        public T MyProperty { get; set; }
        public T myMethod(T myParameter)
        {
            MyProperty = myParameter;
            return MyProperty;
        }
    }
    class Program
    {
        static void boxingUnboxing()
        {
            int i = 0;
            object iBoxed = i; //i is boxed

            int iUnboxed = (int)iBoxed; //iBoxed is unboxed
            //During boxing CLR makes the following operation
            /*
             1-verify weather the type of the boxed variable is the same that the type of the new varible 
             2.-Assign the value from the boxed variable
             */

        }
        static void generics()
        {
            myGenericClass<int> myClass1 = new myGenericClass<int>();
            int number = myClass1.myMethod(50);
            Console.WriteLine(number);

            myGenericClass<string> myClass2 = new myGenericClass<string>();
            string s = myClass2.myMethod("This is a generic class");
            Console.WriteLine(s);

            /*              
            where T : struct Type “T” must be a value type
            where T : class Type “T” must be a reference type
            where T : BaseClass, class Type must be BaseClass or its child
            where T : new() Type “T” must has a definition of public default constructor
            where T : U Type “T” must be or child of type “U”
            where T : interfaceName Type “T” must be or implement a specified interface             
             */

            //just accept value type
            myGenericClass01<int> i = new myGenericClass01<int>();

            //just accept ref type
            myGenericClass02<string> s1 = new myGenericClass02<string>();

            //just accept baseclass or its child
            myGenericClass03<person> personClass = new myGenericClass03<person>();
            myGenericClass03<student> studentClass = new myGenericClass03<student>();

            //just accept class with a default constructor, it means without parameters
            myGenericClass04<person> pClass = new myGenericClass04<person>();

            //just accept class implemented with the set interface
            myGenericClass05<car> Car = new myGenericClass05<car>();
            myGenericClass05<IVehicle> vehicle = new myGenericClass05<IVehicle>();

            //just accept class implemented with itself or its child
            myGenericClass06<person, person> Person = new myGenericClass06<person, person>();
            myGenericClass06<student, person> Student = new myGenericClass06<student, person>();
        }
        static void Main(string[] args)
        {
            generics();
            Console.ReadLine();
        }
    }
}
