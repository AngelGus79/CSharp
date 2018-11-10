using System;
using System.ComponentModel;
namespace ImplementingDelegatesAndEvents
{
    class Program
    {
        //definnig a delegate. 
        public delegate void printFormats1(int number);
        public delegate void printFormats2(int number);
        static void Main(string[] args)
        {
            //delegates();
            //commonBuiltInDelegates();
            //varianceInDelegates();
            //AnonymusMethod();
            //lamdaFunctions();
            //Events();
            //BuiltInDelegates();
            //propertyChanged();
            //ChallengeOne();
            ChallengeTwo();
            Console.ReadLine();


        }


        class Parent { }
        class Child : Parent { }

        delegate Parent Covariance();
        delegate void Contravariance(Child c);

        static void BuiltInDelegates()
        {
            //EventHandler
            //PropertyChangedEventHandler

            sensor Sensor = new sensor();
            Sensor.Alert += Sensor_Alert;
            Sensor.signalRecived = true;


        }

        private static void Sensor_Alert(object sender, EventArgs e)
        {
            Console.WriteLine("The sensor recived a signal");
        }

        static void propertyChanged()
        {
            person p = new person();
            p.PropertyChanged += P_PropertyChanged;

            p.Name = "Pandora";

        }

        private static void P_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine("A property has changed");
        }

        static void Events()
        {
            Room room = new Room();
            room.Alert += OnAlert;
            room.Temperature = 61;
        }

        private static void OnAlert(object obj)
        {
            Room room = (Room)obj;

            Console.WriteLine("ShutDown the temperature is {0}", room.Temperature);
        }

        static void AnonymusMethod()
        {
            Action writeTitle = delegate ()
            {
                Console.WriteLine("The Main Title");
            };

            writeTitle();

            Func<int, string> Num2Text = delegate (int number)
            {
                switch (number)
                {
                    case 1:
                        return "one";
                    case 2:
                        return "two";
                    case 3:
                        return "three";
                    default:
                        return "it is not in the list";

                }

            };

            Predicate<string> IsNumber = delegate (string s)
            {
                int i;
                float f;

                return int.TryParse(s, out i) || float.TryParse(s, out f) ? true : false;

            };

            Console.Write("Write a number(1-4):");
            string value = Console.ReadLine();

            if (IsNumber(value))
            {
                Console.WriteLine("The Text of the number {0} is : {1}", value, Num2Text(int.Parse(value)));
            }

            printFormats1 format = delegate (int i)
            {
                format1(i);
            };

            format(int.Parse(value));

            anonymus(delegate () {
                Console.WriteLine("This is anonymus method as a parameter");
            });


        }

        static void lamdaFunctions()
        {
            Func<string> retriveValue = () =>
            {
                Console.Write("input a number:");
                return Console.ReadLine();
            };

            Predicate<string> IsInt = (string s) =>
            {
                int i;
                return int.TryParse(s, out i);
            };

            //it is not necesary the type of the parameter in the definition
            Func<int, string> Number2Text = Number =>
            {
                switch (Number)
                {
                    case 1:
                        return "one";
                    case 2:
                        return "two";
                    case 3:
                        return "three";
                    case 4:
                        return "four";
                    case 5:
                        return "five";
                    case 6:
                        return "six";
                    case 7:
                        return "seven";
                    case 8:
                        return "eight";
                    case 9:
                        return "nine";
                    case 0:
                        return "zero";
                    default:
                        return "it is not in the list";
                }
            };

            string value = retriveValue();
            string NumberInText = "";

            if (IsInt(value))
            {
                int number = int.Parse(value);
                NumberInText = Number2Text(number);
            }

            anonymus(() => Console.WriteLine("The number {0} in text is {1}", value, NumberInText));

        }

        static void anonymus(Action A) {
            A();
        }
        static void varianceInDelegates()
        {
            //with variance, the method does not need to match with the delegate
            //Covariance      | return type    | Delegate return Parent                | Method return a Child
            //ContraVariance  | parameter type | Delegate recive as parameter a Child  | Method recive as parameter Parent 

            Covariance conv = new Covariance(covarianceMethod);
            conv();

            Contravariance cont = new Contravariance(contraVarianceMethod);
            Child c = new Child();
            contraVarianceMethod(c);

        }

        static Child covarianceMethod()
        {
            Child c = new Child();
            Console.WriteLine("covariance Method");
            return c;
        }

        static void contraVarianceMethod(Parent p)
        {
            Child c = p as Child;

            Console.WriteLine("ContraVariance Method");
        }

        static void commonBuiltInDelegates()
        {
            //common built-in delegates
            // Action      | no value to return | no list parameters
            // Action <>   | no value to return | at least 1 until 16 parameters
            // Func <>     | return a value     | may have a parameter list, the last one is the return value. it has 17 overloads (16 for parameters and 1 for the return value) 
            // Predicate<> | return a bool      | takes one parameter 

            Action handler3 = formats;

            handler3();

            Action<int> handler4 = new Action<int>(format1);
            handler4 += format2;
            handler4 += format3;
            handler4 += format4;
            handler4 += format5;

            handler4.Invoke(50);

            Func<int, string> handler5 = numToText;
            Console.Write("Write a number(1-4): ");

            string input = Console.ReadLine();

            Console.WriteLine("the number is: {0} ", handler5(int.Parse(input)));

            Predicate<string> handler6 = new Predicate<string>(IsInt);
            handler6 += IsFloat;

            foreach (Predicate<string> item in handler6.GetInvocationList())
            {
                Console.WriteLine("the input {0} is number : {1}", input, handler6(input));
            }


        }
        static void delegates()
        {
            //declaring a delegate
            printFormats1 handler1 = new printFormats1(format1);
            //adding method references to delegate1
            handler1 += format2;
            handler1 += format3;
            handler1 += format4;
            handler1 += format5;
            //invoking methods
            handler1(10);

            //deleting methods from a delegate instance
            handler1 -= format3;
            handler1 -= format4;
            handler1 -= format5;

            //other way to instance a delegate
            printFormats2 handler2 = format3;
            handler2 += format4;
            handler2 += format5;

            //anoter way to invoke methods
            handler2.Invoke(30);
        }

        static bool IsInt(string value)
        {
            int n;
            return int.TryParse(value, out n);
        }

        static bool IsFloat(string value)
        {
            float f;
            return float.TryParse(value, out f);
        }

        static string numToText(int number)
        {
            switch (number)
            {
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                default:
                    return "It is not in the list";
            }
        }

        static void formats()
        {
            Console.WriteLine("format Currency");
            Console.WriteLine("format Digits");
            Console.WriteLine("format Exponential");
            Console.WriteLine("format Float");
            Console.WriteLine("format hex");

        }

        static public void format1(int number)
        {
            Console.WriteLine("format Currency: {0,-5}", number.ToString("c"));
        }
        static public void format2(int number)
        {
            Console.WriteLine("format three Digits: {0,-5}", number.ToString("D3"));
        }
        static public void format3(int number)
        {
            Console.WriteLine("format exponential: {0,-5}", number.ToString("e"));
        }
        static public void format4(int number)
        {
            Console.WriteLine("format float: {0,-5}", number.ToString("f"));
        }
        static public void format5(int number)
        {
            Console.WriteLine("format hex: {0,-5}", number.ToString("X"));
        }

        static void ChallengeOne()
        {
            student Student = new student();

            Student.Name = "Yoshua";

            Student.PropertyChanged += Student_PropertyChanged;

            Student.English = 24;
            Student.Cs = 25;
            Student.Math = 25;

        }

        static void ChallengeTwo()
        {
            scholar s = new scholar();

            s.PropertyChanged += S_PropertyChanged;
            s.PropertyNoChanged += S_PropertyNoChanged;

            s.Name = "Cotue";
            s.Name = "Cotue";

        }

        private static void S_PropertyNoChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine("The Name has not changed");
        }

        private static void S_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine("The Name has changed");
        }

        private static void Student_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            student s = sender as student;
            if (s.Math + s.English + s.Cs >= 75)
            {
                Console.WriteLine("Congratulations you pass the exam with {0} pts!", s.Math + s.English + s.Cs);
            }else
            {
                Console.WriteLine("F {0,-2}pts!", s.Math + s.English + s.Cs);
            }
        }
    }
    class sensor
    {
        public event EventHandler Alert;
        bool _signalRecived;
        public sensor()
        {
            _signalRecived = false;
        }

        public bool signalRecived {
            get
            {
                return false;
            }
            set
            {
                _signalRecived = value;

                if (_signalRecived)
                {
                    if(Alert != null)
                    {
                        Alert(this, EventArgs.Empty);
                    }
                }
            }

        }

    }
    class person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;

               

               OnPropertyChanged("Name");
            }

        }

        void OnPropertyChanged(string value)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(value));
            }
        }
    }
    class Room
    {
        public event Action<object> Alert;

        private int _Temperature;
        
        public Room()
        {
            _Temperature = 30;
        }


        public int Temperature {
            get
            {
                return _Temperature;
            } set
            {
                _Temperature = value;

                if(_Temperature > 60)
                {
                    Alert?.Invoke(this);
                }
            }
        }
    }

    class scholar : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangedEventHandler PropertyNoChanged;
        private string name;

        public scholar()
        {
            name = "";
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {

               
                if (name == value)
                {
                  
                    OnPropertyNoChanged("Name");
                }
                else
                {
                    
                    name = value;
                    OnPropertyChanged("Name");
                }

              
            }
        }

        private void OnPropertyNoChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyNoChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    class student : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        public string Name { get; set; }

        private int _math;
        private int _cs;
        private int _english;
        private bool bmath;
        private bool bcs;
        private bool benglish;
       

        public student()
        {
            _math = 0;
            _cs = 0;
            _english = 0;
          
            bmath = false;
            benglish = false;
            bcs = false;
            
           
        }
        public int Math
        {
            get
            {
                return _math;
            }
            set
            {
                _math = value;

                bmath = true;

                OnPropertyChanged("Math");
            }
        }

        public int Cs
        {
            get
            {
                return _cs;
            }
            set
            {
                _cs = value;

               
                bcs = true;
               
                OnPropertyChanged("Cs");
            }
        }

        public int English
        {
            get
            {
                return _english;
            }
            set
            {
                _english = value;
                benglish = true;
                OnPropertyChanged("English");
            }
        }
        void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if(handler != null)
            {
                if (bmath && bcs && benglish)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
}
