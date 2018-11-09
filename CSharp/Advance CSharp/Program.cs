using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;

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

        public override string ToString()
        {
            return this.name;
        }

    }
    class student : person
    {
        public student(string name, int age) : base(name, age)
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
    class myGenericClass01<T> where T : struct
    {
        private T myField;
        public T myMethod(T myParameter)
        {
            this.myField = myParameter;
            return this.myField;
        }
    }

    class myGenericClass02<T> where T : class
    {
        public T MyProperty { get; set; }
        public T myMethod(T myParameter)
        {
            MyProperty = myParameter;
            return MyProperty;
        }
    }

    class myGenericClass03<T> where T : person
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

    class myGenericClass08<T> where T : class, new()  //it is posible to set many constraints

    {
        public T MyProperty { get; set; }
        public T myMethod(T myParameter)
        {
            MyProperty = myParameter;
            return MyProperty;
        }
    }

    class myGenericClass09<T>
    {
        public T myGenericProperty { get; set; }
        public myGenericClass09(T myGenericParameter)
        {
            myGenericProperty = myGenericParameter;
        }

        public T myGenericMethod()
        {
            return myGenericProperty;
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
            //generics();
            //arrayList();
            //hashtable();
            //queue();
            //stack();
            //genList();
            //genHashTable();
            //genQueue();
            //genStack();
            //myEnum();
            //myGenEnum();
            //myEnum2();
            //myGenEnum2();
            //myComparable();
            //myComparableGen();
            //myComparer();
            //strings();
            //stringBuilder();
            //stringReader();
            stringWriter();
            Console.ReadLine();
        }

        static void arrayList()
        {
            ArrayList aList = new ArrayList();

            aList.Add("Name");
            aList.Add(2);
            aList.Add(true);

            if (!aList.Contains(3))
            {
                aList.Add(3);
            }



            foreach (var item in aList)
            {
                Console.WriteLine("item: {0, 10} ", item);
            }

            aList.Remove(3);
            Console.WriteLine("without three");
            foreach (var item in aList)
            {

                Console.WriteLine("item: {0,10}", item);
            }

            aList.RemoveAt(0);

            Console.WriteLine("without the first item");
            for (int i = 0; i < aList.Count; i++)
            {
                Console.WriteLine("item: {0,10}", aList[i]);
            }



        }
        static void hashtable()
        {
            Hashtable ht = new Hashtable();

            ht.Add(1, "one");
            ht.Add(2, "two");
            ht.Add(3, "three");
            ht.Add("four", 4);


            Console.WriteLine("key: {0, -10}value: {1, -10}", 1, ht[1]);

            foreach (DictionaryEntry item in ht)
            {
                Console.WriteLine("key: {0,-10}, value: {1,-10}", item.Key, item.Value);
            }

            Console.WriteLine("without the key 1");

            ht.Remove(1);
            foreach (DictionaryEntry item in ht)
            {
                Console.WriteLine("key: {0,10}, value:{1, 10}", item.Key, item.Value);
            }



        }
        static void queue()
        {
            Queue q = new Queue();

            q.Enqueue(1);
            q.Enqueue("two");
            q.Enqueue("three");
            q.Enqueue("four");

            for (int item = 0; item < q.Count; item++)
            {
                Console.WriteLine("{0}._  item: {1, 10}", item, q.Dequeue());
            }


        }
        static void stack()
        {
            Stack s = new Stack();

            s.Push(1);
            s.Push("one");
            s.Push(new person { name = "Prisma", age = 33 });
            s.Push(true);

            if (!s.Contains(false))
            {
                s.Push(false);
            }

            while (s.Count > 0)
            {
                Console.WriteLine("item: {0,1}", s.Pop());
            }

        }

        static void genList()
        {
            List<person> list = new List<person>();

            list.Add(new person { name = "jhon", age = 23 });
            list.Add(new person { name = "phillip", age = 32 });
            list.Add(new person { name = "stephan", age = 23 });

            foreach (person item in list)
            {
                Console.WriteLine("the person is:{0,1}", item);
            }

            Console.WriteLine("remove the first person");
            list.RemoveAt(0);

            for (int item = 0; item < list.Count; item++)
            {
                Console.WriteLine("person: {0}", list[item]);
            }

        }
        static void genHashTable()
        {
            Dictionary<int, person> d = new Dictionary<int, person>();

            d.Add(0, new person { name = "jhon", age = 23 });
            d.Add(1, new person { name = "phillip", age = 32 });
            d.Add(2, new person { name = "stephan", age = 23 });

            foreach (var item in d)
            {
                Console.WriteLine("key = {0,1}, value = {1,1}", item.Key, item.Value);
            }
            Console.WriteLine("without the first item");
            d.Remove(0);

            foreach (var item in d)
            {
                Console.WriteLine("key: {0, -5} person: {0,1}", item.Key, item.Value);
            }
        }
        static void genQueue()
        {
            Queue<person> q = new Queue<person>();
            q.Enqueue(new person { name = "jhon", age = 23 });
            q.Enqueue(new person { name = "phillip", age = 32 });
            q.Enqueue(new person { name = "stephan", age = 23 });

            while (q.Count > 0)
            {
                Console.WriteLine("item: {0,1}", q.Dequeue());
            }


        }
        static void genStack()
        {
            Stack<person> s = new Stack<person>();

            s.Push(new person { name = "Stephi", age = 23 });
            s.Push(new person { name = "yoshua", age = 31 });
            s.Push(new person { name = "Mary ann", age = 23 });

            while (s.Count > 0)
            {
                Console.WriteLine("item:{0,1}", s.Pop());
            }

        }

        static void myEnum()
        {
            myEnumerable e = new myEnumerable();

            e.Add("hi");
            e.Add("world");
            e.Add(1);
            e.Add(true);

            foreach (object item in e)
            {
                Console.WriteLine("item: {0}", item);
            }

        }

        static void myGenEnum()
        {
            myEnumerableGen<int> list = new myEnumerableGen<int>();

            list.Add(1);
            list.Add(2);
            list.Add(23);
            list.Add(32);

            foreach (int item in list)
            {
                Console.WriteLine("item: {0}", item);
            }
        }

        static void myEnum2()
        {
            myEnumerable2 list = new myEnumerable2();

            list.Add("hello");
            list.Add("world");
            list.Add(2);
            list.Add(true);

            foreach (object item in list)
            {
                Console.WriteLine("item: {0,10} ", item);
            }
        }

        static void myGenEnum2()
        {
            myEnumerableGen2<int> list = new myEnumerableGen2<int>();

            list.Add(23);
            list.Add(3);
            list.Add(1);
            list.Add(9);

            foreach (int item in list)
            {
                Console.WriteLine("item: {0,10}", item);
            }


        }

        static void myComparable()
        {
            ArrayList list = new ArrayList();

            list.Add(new scholar { name = "pepe", math = 7 });
            list.Add(new scholar { name = "cotue", math = 6 });
            list.Add(new scholar { name = "juliany", math = 9 });

            list.Sort();

            foreach (scholar item in list)
            {
                Console.WriteLine("name: {0,-10} math:{1} ", item.name, item.math);
            }


        }

        static void myComparableGen()
        {
            List<user> users = new List<user>();

            users.Add(new user { name = "Dayana", age = 23, weigth = 60.8F });
            users.Add(new user { name = "Yulian", age = 31, weigth = 50.8F });
            users.Add(new user { name = "Peter", age = 35, weigth = 90.8F });
            users.Add(new user { name = "Estephi", age = 27, weigth = 66.8F });

            users.Sort();

            foreach (user u in users)
            {
                Console.WriteLine("name: {0,-10} age:{1,-10} weigth:{2}", u.name, u.age, u.weigth);
            }
        }

        static void myComparer()
        {
            ArrayList children = new ArrayList();
            children.Add(new child { name = "Rosita", age = 8, weight = 30.5F, height = 103 });
            children.Add(new child { name = "Dany", age = 7, weight = 31.5F, height = 105.6F });
            children.Add(new child { name = "Bertita", age = 8, weight = 27.5F, height = 98.5F });
            children.Add(new child { name = "Brenda", age = 10, weight = 32.5F, height = 105.4F });
            children.Add(new child { name = "Adrian", age = 9, weight = 35.5F, height = 108.2F });

            children.Sort(new orderByName());
            Console.WriteLine("{0,40} \n", "order by Name");
            foreach (child item in children)
            {
                Console.WriteLine("name: {0,-10} age: {1,-10} weight: {2,-10} height: {3,-10}", item.name, item.age, item.weight, item.height);
            }

            children.Sort(new orderByAge());
            Console.WriteLine("{0,40} \n", "order by Age");
            foreach (child item in children)
            {
                Console.WriteLine("name: {0,-10} age: {1,-10} weight: {2,-10} height: {3,-10}", item.name, item.age, item.weight, item.height);
            }

            List<child> Children = new List<child>();
            Children.Add(new child { name = "Rosita", age = 8, weight = 30.5F, height = 103 });
            Children.Add(new child { name = "Dany", age = 7, weight = 31.5F, height = 105.6F });
            Children.Add(new child { name = "Bertita", age = 8, weight = 27.5F, height = 98.5F });
            Children.Add(new child { name = "Brenda", age = 10, weight = 32.5F, height = 105.4F });
            Children.Add(new child { name = "Adrian", age = 9, weight = 35.5F, height = 108.2F });

            Children.Sort(new orderByHeight());
            Console.WriteLine("{0,40} \n", "order by Height");
            foreach (child item in Children)
            {
                Console.WriteLine("name: {0,-10} age: {1,-10} weight: {2,-10} height: {3,-10}", item.name, item.age, item.weight, item.height);
            }

            Children.Sort(new orderByWeight());
            Console.WriteLine("{0,40} \n", "order by Weight");
            foreach (child item in Children)
            {
                Console.WriteLine("name: {0,-10} age: {1,-10} weight: {2,-10} height: {3,-10}", item.name, item.age, item.weight, item.height);
            }

        }

        static void strings()
        {
            Stopwatch watch = new Stopwatch();

            string example = "test";

            watch.Start();
            for(int i = 0; i<100000; i++)
            {
                example += i;
            }

            watch.Stop();

            float time = (float)watch.ElapsedMilliseconds/1000;
            Console.WriteLine("time: {0,1} s", time);

        }

        static void stringBuilder()
        {
            StringBuilder example = new StringBuilder("test");
            Stopwatch watch = new Stopwatch();

            watch.Start();

            for(int i = 0; i<100000; i++)
            {
                example.Append(i);
            }
            watch.Stop();

            float seconds = (float)watch.ElapsedMilliseconds / 1000;
            Console.WriteLine("time: {0,1} s", seconds);
        }

        static void stringReader()
        {
            string text = @"Hi I'm Ali Asad.
I can help you in C# Certification Exam.
I've helped many individuals like you in their exam prep.
I believe if we work together, you can become:
Microsoft Certified Professional & Specialist in C#";

            StringReader s = new StringReader(text);
            string Line;
            int i = 0;
            while ((Line=s.ReadLine()) != null)
            {
                Console.WriteLine("Line{0,1}: {1}", ++i, Line);
            }

        }

        static void stringWriter()
        {
            StringBuilder builder = new StringBuilder();
            StringWriter writer = new StringWriter(builder);

            writer.WriteLine("hello");
            writer.Write("the end");

            Console.Write(builder);
            
        }

        static void methodsString()
        {
            string s = "Hello world!";
            string s1 = s.Clone() as string;
            s1 = s1 + "w";

            if (s.CompareTo(s1)== 0)
            {
                Console.WriteLine("they are the same");
            }
            else
            {
                Console.WriteLine("They are not the same");
            }

            if (s.EndsWith("!"))
            {
                Console.WriteLine("the string ends with !");
            }

            if(s.Equals(s1))
            {
                Console.WriteLine("both are equals");
            }

            Console.WriteLine(s.IndexOf("o"));

            s.Insert(5, "hey");

            s.Replace("hey", "");

            string[] substring = s.Split(" ");

            foreach(string sub in substring)
            {
                Console.WriteLine(sub);
            }

            Console.WriteLine(s.Substring(0, 6));


        }
    }

    class Adult: IEquatable<Adult>
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public bool Equals(Adult other)
        {
            if(this.Name.CompareTo(other.Name)==0 && this.Age == other.Age)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object other)
        {
            Adult o = (Adult)other;
            return this.Equals(o);
        }

        public override int GetHashCode()
        {
            string hash = this.Name + this.Age;
            return hash.GetHashCode();
        }

        public static bool operator ==(Adult a1, Adult a2)
        {
            if (a1.Name.CompareTo(a2.Name) == 0 && a1.Age == a2.Age)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator !=(Adult a1, Adult a2)
        {
            if (a1.Name.CompareTo(a2.Name) == 0 && a1.Age == a2.Age)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }

    class user : IComparable<user>
    {
        public string name { get; set; }
        public int age { get; set; }
        public float weigth { get; set; }

        public int CompareTo(user other)
        {
            return this.weigth.CompareTo(other.weigth);
        }
    }

    class child
    {
        public string name { get; set; }
        public int age { get; set; }
        public float weight { get; set; }
        public float height { get; set; }
    }

    class orderByName : IComparer
    {
        public int Compare(object c1, object c2)
        {
            child child1 = (child)c1;
            child child2 = (child)c2;

            return child1.name.CompareTo(child2.name);
        }
    }

    class orderByAge : IComparer
    {
        public int Compare(object c1, object c2)
        {
            child child1 = (child)c1;
            child child2 = (child)c2;

            return child1.age.CompareTo(child2.age);

        }
    }

    class orderByWeight : IComparer<child>
    {
        
        public int Compare(child c1, child c2)
        {
            return c1.weight.CompareTo(c2.weight);
        }
    }

    class orderByHeight: IComparer<child>
    {
        public int Compare(child c1, child c2)
        {
            return c1.height.CompareTo(c2.height);
        }
    }

    class scholar: IComparable
    {
        public int math { get; set; }
        public string name { get; set; }

        public int CompareTo(object o)
        {
            scholar next = (scholar)o;
            return this.math.CompareTo(next.math);
        }
    }

    class myEnumerable: IEnumerable
    {
        object[] myEnum = new object[4];
        int index;
        public myEnumerable()
        {
            index = -1;
        }
        public void Add(object o)
        {
            if (++index < myEnum.Length)
            {
                myEnum[index] = o;
            }
        }

        public IEnumerator GetEnumerator()
        {
            for(int i = 0; i < myEnum.Length; i++)
            {
                yield return myEnum[i];
            }
        }
    }

    class myGenericClass10<T> where T : struct
        {
            public T MyProperty { get; set; }
            public myGenericClass10()
            {

            }
        }

    class myClass
        {
            public int MyProperty { get; set; }
            public myClass(int myParameter)
            {
                MyProperty = myParameter;
            }

            public T myMethod<T>(T myParameter)
            {
                return myParameter;

            }

            public U myMethod<T, U>(U myParameter) where T : struct
            {

                Type t = myParameter.GetType();
                if (t.Equals(typeof(byte)))
                    Console.WriteLine("the type is: Byte");
                else if (t.Equals(typeof(sbyte)))
                    Console.WriteLine("the type is: sByte");

                else if (t.Equals(typeof(int)))
                    Console.WriteLine("the type is: Int");

                else if (t.Equals(typeof(long)))
                    Console.WriteLine("the type is: long");

                else if (t.Equals(typeof(double)))
                    Console.WriteLine("the type is: double");



                return myParameter;
            }
        }

    class myEnumerableGen<T>: IEnumerable<T>
    {
        T[] myArray = new T[5];
        int index;
        public myEnumerableGen()
        {
            index = -1;
        }
        public void Add(T obj)
        {
            if(++index < myArray.Length)
            {
                myArray[index] = obj;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach(T item in myArray)
            {
                yield return item;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    class myEnumerable2: IEnumerable
    {
        object[] list = new object[4];
        private int index;
        public myEnumerable2()
        {
            index = -1;
        }

        public void Add(object o)
        {
            if(++index < list.Length)
            {
                list[index] = o;
            }
        }
        public IEnumerator GetEnumerator()
        {
            return new myEnumerator(list);
        }
    }

    class myEnumerator : IEnumerator
    {
        object[] obj = new object[4];
        int index; 

        public myEnumerator(object[] obj)
        {
            index = -1;
            this.obj = obj;
        }

        public object Current { get { return obj[index]; }  }
        public bool MoveNext()
        {
            return (++index < obj.Length);
        }
        public void Reset()
        {
            index = -1;
        }
    }

    class myEnumerableGen2<T> : IEnumerable<T>
    {
        T[] list = new T[4];
        int index;
        public myEnumerableGen2()
        {
            index = -1;
        }
        public void Add(T obj)
        {
            if (++index < list.Length)
            {
                list[index] = obj;
            }

        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return new myEnumeratorGen<T>(list);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    class myEnumeratorGen<T> : IEnumerator<T>
    {
        int index;
        T[] list = new T[4];

        public myEnumeratorGen(T[] list)
        {
            this.list = list;
            index = -1;
        }

        public T Current
        {
            get
            {
                return list[index];
            }
        }

       

        object IEnumerator.Current
        {
            get
            {
                return this.Current;
            }
        }

        public bool MoveNext()
        {
            return (++index < list.Length);
        }

        public void Reset()
        {
            index = -1;
        }

        public void Dispose()
        {

        }
    }

    

    
}