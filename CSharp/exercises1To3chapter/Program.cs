using System;

namespace exercises1To3chapter
{

    static class extensionMethod
    {
        public static bool isGreaterThan(this int origin, int value)
        {
            if (origin > value)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    class temperature
    {
        private float[] temperatures = { 20.3F, 30.2F, 49.2F, 29.3F, 23.5F, 23.5F, 43.2F };

        public float this[int index] { get
            {
                if (index < temperatures.Length && index >= 0)
                {
                    return temperatures[index];
                }
                else
                {
                    return 0;
                }
            }
            set {

                if (index < temperatures.Length && index >= 0)
                {
                    temperatures[index] = value;
                }
                else
                {
                    Console.WriteLine("index must be greater than 0 and less than {}", temperatures.Length);
                }

            } }


    }
    class person
    {
        public string name { get; set; }
        public int age { get; set; }

        public static implicit operator string(person Person)
        {
            return Person.name;
        }

        public person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public static person operator +(person P1, person P2)
        {
            person P3 = new person("Silvana",23);
            P3.age = P1.age + P2.age;

            return P3;
        }

    }
    static class extension
    {
        public static string concatenate(this string origin, string value){
            return origin + value;
        }
    }
    class day
    {
        string[] days = { "monday", "tuesday", "wednesday", "thursday", "friday" };
        public string this[int index] { get
            {
                if(index>=0 && index < days.Length)
                {
                    return days[index];
                }else
                {
                    return days[0];
                }

           } set {

                if (index >= 0 && index < days.Length)
                {
                    days[index]=value;
                }
                else
                {
                    Console.WriteLine("index must be greater or equal than {0} and less than {1}", 0, days.Length);
                }
            } }



    }
    class student
    {
        public string name { get; set; }
        public int age { get; set; }
        public student(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        public static implicit operator string(student Student)
        {
            return Student.name;
        }
        public static bool operator >(student S1, student S2)
        {
            return S1.age > S2.age;
        }
        public static bool operator <(student S1, student S2)
        {
            return S1.age < S2.age;
        }

    }
    static class ext
    {
        public static bool greaterThan (this string origin, string value)
        {
            return origin.Length > value.Length;
        }
    }
    class month
    {
        private string[] months = { "january", "february" };

        public string this [byte index] { get { return months[index]; } set { months[index] = value; } }

        public static implicit operator string(month Month)
        {
            return Month[0];
        }

        public static bool operator >(month m1, month m2)
        {
            return m1[0].Length > m2[0].Length;
        }
        public static bool operator <(month m1, month m2)
        {
            return m2[0].Length > m1[0].Length;
        }

    }
    static class ext01
    {
        public static bool lessThan(this int origin, int value)
        {
            return origin < value;
        }
    }
    class ind01
    {
        private double[] array = { 12.1, 3.4, 34.2, 2.5 };
        public double this[int index] { get { return array[index]; } set { array[index] = value; }  }

        public static implicit operator double[] (ind01 array)
        {
            return array;
        }

        public static ind01 operator +(ind01 i1, ind01 i2)
        {
            ind01 i3 = new ind01();
            i3[0] = i1[0] + i2[0];
            return i3;
            
        }
    }
    

    class Program
    {
        static void Main(string[] args)
        {
            int number = 5;

            Console.WriteLine("{0} es greater than {1}: {2} ", number, 3, number.isGreaterThan(3));

            temperature Temperature = new temperature();
            Console.WriteLine("The temperature is : {0}", Temperature[0]);

            person Person = new person("Anna",22);
            string Name = Person;

            Console.WriteLine("the name of the person is: {0}", Name);

            person P1 = new person("Jhon", 43);
            P1 = P1 + Person;
            Console.WriteLine("the sum of the ages is: {0}", P1.age);

            string s = "hellow ";
            string s1 = s.concatenate("world!");
            Console.WriteLine(s1);

            day Day = new day();

            Console.WriteLine("The first day is {0}", Day[0]);

            student Student = new student("Paul", 22);
            string StudentName = Student;
            Console.WriteLine("The name of the student is {0}", StudentName);

            student st1 = new student("Johana", 23);
            student st2 = new student("jessica", 21);

            Console.WriteLine("Johana is older tha Jessica: {0}", st1 > st2);
            Console.ReadLine();
        }
    }
}
