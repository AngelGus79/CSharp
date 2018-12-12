using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAssembly;
using System.Reflection;
namespace AssemblyAndReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            //AssemblyMethod();
            //ReflectionMethod();
            //ReflectionToDataAcess();
            //GetPrivateMembersWithReflection();
            //AttributesMethod();
            AttributeUsageMethod();

            Console.ReadLine();
        }

        static void AssemblyMethod()
        {
            //When code is compiled, it is converted in MSIL(Microsoft Intermediate Language).
            //The CLR(Common Language Runtime) uses a JIT (Just in Time) Compiler to compile MSIL To Native Code.
            //An assembly is an code block in MSIL(Microsoft Intermediate Language) of a .Net application.
            //When compiler creates an Assembly, it creates its Metadata in the same file.
            //Metadata contains information that the assembly contains, like its types, namespaces, base class of the classes, interfaces, methods, properties etc.., METADATA DOES NOT CONTAINS CODE, JUST THE NAMES, TYPES ETC. 
            //When Assembly is compiled successfully, also an assembly manifest file is created. it is an xml file which contains the name, version number, and an optional strong name that identify the assembly.

            //there are 2 types of assembly
            //1. Private (.dll, .exe). It can be used just in one application
            //2. Public  (.dll, .exe). It can be used for several application. It is stored in GAC (Global Assembly Cache). It must have a strong name.

            //Importance of assemblies
            //1. promote reuse
            //2. help in versioning
            //3. enable security due to you can specify trust level for code from a specific site or zone.
            //4. supports culture and language

            //Create a Custom Dll Assembly (.DLL) 
            //1. create a new project -class library(.Net Framework)-
            //2. build the assembly

            //Use a Custom Assembly. We can use just the public members
            //1. Copy the custom library (.dll) in the root directory of your application
            //2. Right- click on references folder of your application, add reference and select the assembly

            //Executable Assembly (.EXE)
            //They have main method defined such as Console App, Windows Form, WPF App etc.

            //WinMD Assembly. It allows communication between different programming languages. It is possible through Windows Runtime Component. All Types must be sealed.
            // Create a new project by -selecting  Windows Runtime Component-

            ArithmeticOperation arithmeticOperation = new ArithmeticOperation();
            arithmeticOperation.numA = 5;
            arithmeticOperation.numB = 3;
            Console.WriteLine("The sum is {0}, the sustraction is {1}", arithmeticOperation.sum(), arithmeticOperation.sus());


        }

        static void GlobalAssembyCache()
        {
            //GAC is a location to share Assemblies
            // The Assemblies in GAC just can be removed by Administrator Users

            //To install Assembly in GAC, the Assembly must have a strong name. 
            // You have to 
            //1. generate a strong name 
            //2. associate it with the assembly.
            //3. Add to a GAC

            //1. Create a strong name key
            //1.1 Create a Class Library project
            //1.2 run visual studio command prompt as administrator and (simbolo de sistema para desarrolladores de VS 2017) navigate to the root folder of project  
            //1.3 Create a strong name executing the command   sn -k KEYNAME.snk

            //2. Associate the strong name with the assembly
            //2.1 Open the AssemblyInfo.cs in Visual Studio and add and assembly attribute and location of the strong name key [assembly: AssemblyKeyFile("myClassLibrarykey.snk")]
            //2.2 Compile the solution. Visual Studio must be running as Administrator

            //3. Install the strong name assembly into GAC using Gacutil.exe
            //3.1 Run Visual Studio Command Promp as Administrator
            //3.2 Execute the command  gacutil -i "STRONGNAMEASSEMBLYWITHPATH.dll"   or navigate to the strong name assembly to avoid the path

            //When an assembly is created also an AssemblyInfo.cs is created, it contains attributes to define name, version, description, culture, Copyright and so on.
            //You can control the version modifying the attribute AssemblyVersion
            // [assembly: AssemblyVersion("1.0.0.0")] 
            //for convention first digit is incremented when news members are added like methods, properties, classes etc.
            //second digit is incremented when the existing members are updated.
            //third digit is incremented with every successfull bild, it can be automatically
            //fourth digit is incremented over bilds with patches
            //[assembly: AssemblyVersion("1.0.*")]

        }

        static void ReflectionMethod()
        {
            //System.Reflection.Assembly
            //Reflection read Assembly's metadata in a running program to get the type, methods and so on.. of the assembly
            //Reflection converts binary data from the assembly in readable data for reading data and controlling the behavior of a runtime program.

            //reading an assembly to get the name
            Assembly assembly = Assembly.GetExecutingAssembly();
            Console.WriteLine("the current assembly name is : {0}", assembly.GetName());

            //Getting Assembly types 

            //1. Get the current Executing Assembly
            Assembly assembly1 = Assembly.GetExecutingAssembly();
            //2. Get all the types from the assembly
            Type[] types = assembly1.GetTypes();

            Console.WriteLine("The types in the assembly are:");
            foreach (Type t in types)
            {
                Console.WriteLine("type: {0}  base type: {1}", t.GetType(), t.BaseType);
            }

            //Reading Properties from metadata
            //1. Get the current executing Assembly
            Assembly a2 = Assembly.GetExecutingAssembly();
            //2. Get the types from the assembly
            Type[] types2 = a2.GetTypes();
            Console.WriteLine("The Assembly types are:");
            //3. Iterate each type
            foreach (Type t in types2)
            {
                Console.WriteLine("Name: {0}   Base Type: {1}", t.Name, t.BaseType);
                //4.Get all the properties of each type, by default get all non-static public properties
                PropertyInfo[] properties = t.GetProperties();
                foreach (PropertyInfo p in properties)
                {
                    Console.WriteLine("Property: {0} Property type: {1}", p.Name, p.PropertyType);
                }

            }

            //Reading methods from metadata

            //1. Get the current executing Assembly
            Assembly a3 = Assembly.GetExecutingAssembly();

            Console.WriteLine("The types in the Assembly {0} are:", a3.FullName);
            //2. Get all the types that assembly contains
            Type[] t3 = a3.GetTypes();

            //3. Iterate each type
            foreach (Type t in t3)
            {
                Console.WriteLine("type name: {0}  base type: {1}", t.Name, t.BaseType);

                //4. Get all methods from each type, by default get all non-static public methods
                MethodInfo[] methods = t.GetMethods();
                foreach (var m in methods)
                {
                    Console.WriteLine("Name: {0} Return type: {1}", m.Name, m.ReturnType);
                }
            }

        }

        static void ReflectionToDataAcess()
        {
            //1. you need instances
            person p1 = new person
            {
                Name = "heisen",
                Age = 34
               
            };

            person p2 = new person
            {
                Name = "strusen",
                Age = 32
                
            };

            //2.-Get type with typeof or GetType method
            var typePerson = typeof(person);

            //3.-Specify the property
            PropertyInfo property = typePerson.GetProperty("Name");

            //4.-Specify the instance where you want to get the property
            string Name = (string)property.GetValue(p1);

            Console.WriteLine("The name of p1 is {0}", Name);

            //setting a value in a instance

            //1.- Get the type of the object that you want to change
            Type t1 = typeof(person);

            //2.- specify a property
            PropertyInfo property1 = t1.GetProperty("Age");

            //3.-specify the instance and set the value
            property1.SetValue(p2, 10);

            Console.WriteLine("the age of p2 is {0}", p2.Age);


            //invoke a method 

            //1.- get the type
            Type t3 = typeof(person);
            //2.- specify a method
            MethodInfo method = t3.GetMethod("PrintPerson");
            //3.-invoke the method if you do not have parameters set null
            method.Invoke(p1, null);

        }

        static void GetPrivateMembersWithReflection()
        {
            //the only difference is that when you invoke the method GetProperties or GetMethods you have to pass a parameter BindingFlags.NonPublic | BindingFlags.Instance

            person p1 = new person
            {
                Name = "heisen",
                Age = 34

            };

            //1. Get the type
            Type type = typeof(person);

            //2. get the properies of type
            PropertyInfo[] privateProperties = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);

            //3. iterate properties
            foreach (PropertyInfo property in privateProperties)
            {
                
                Console.WriteLine("The property {0} has a value of {1}", property.Name, property.GetValue(p1).ToString());
            }


        }

        public static void GetStaticMembersWithReflection()
        {
            //you just need to change the flags to BindingFlags.Public | BindingFlags.Static

            //1.-get the Assembly or the type
            Type type = typeof(person);

            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Static);

            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
            }
        }

        public static void AttributesMethod()
        {
            //attribute is a class that inherit of Attribute class.
            //One function of attibutes is tag methods, classes, types and so on, in order to query down tagged members in  reflection.
            //you can create properties in an attribute (must have get; set; statements) and assign values when you tag members
            //you can create a constructor in an attribute and assign parameters when you tag members
            //you can make restrictions in attributes (to use just in clases, delegates, methods ans so on)
            
            
            //1. Get the assembly
            Assembly assembly = Assembly.GetExecutingAssembly();

            // select all the types which have at least one tag or attribute with myCustomAttribute
            var myCustomAttributeQuery = from t in assembly.GetTypes()
                                         where t.GetCustomAttributes<myCustomAttribute>().Count() > 0
                                         select t;

            foreach (var type in myCustomAttributeQuery)
            {
                Console.WriteLine(type.Name);
                //Get all properties tagged with myCustomAttribute

                var properties = from property in type.GetProperties()
                                 where property.GetCustomAttributes<myCustomAttribute>().Count() > 0
                                 select property;

                foreach (PropertyInfo property in properties)
                {
                    Console.WriteLine(property.Name);
                }

                var methods = from method in type.GetMethods()
                              where method.GetCustomAttributes<myCustomAttribute>().Count() > 0
                              select method;

                foreach (MethodInfo method in methods)
                {
                    Console.WriteLine(method.Name);
                }



            }

            //Getting the property values of a custom Attribute
            //1. get the type of the tagged class and of the attibute
            Type TransportationType = typeof(transportation);
            Type customAttrType = typeof(CustomAttr);

            //2.execute the GetCustomAttribute method from the abstract class Attribute
            CustomAttr ca = (CustomAttr)Attribute.GetCustomAttribute(TransportationType, customAttrType);

            Console.WriteLine("{0}, {1}",ca.antiguity, ca.medium);

            //You can create a constructor in an attribute an  inicialize in when you tag the member

           
        }

       

        class myCustomAttribute : Attribute
        {

        }
        [myCustom] //[myCustom] = [myCustomAttribute] c# ignores the Attribute
        class animal
        {
            [myCustom]
            public int LegNumber { get; set; }
            public int ArmNumber { get; set; }

            
            public animal()
            {

            }
            [myCustom]
            public void Run()
            {

            }
            [myCustom]
            public void Jump()
            {

            }


        }


        class CustomAttr: Attribute
        {
            public string medium { get; set; } //must have get and set statements
            public int antiguity { get; set; }
        }

        [CustomAttr (medium = "Hira", antiguity = 23)]
        class transportation
        {
            [CustomAttr(medium = "air", antiguity = 20)]
            public bool AirPlane { get; set; }

            [CustomAttr(medium = "land", antiguity = 100)]
            public bool Car { get; set; }

            [CustomAttr(medium = "land", antiguity = 80)]
            public bool Bus { get; set; }

            [CustomAttr]
            public void Stop()
            {

            }

            public void Run()
            {

            }
        }

        class Attrowner : Attribute
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public Attrowner(string name, int Age = 18)
            {
                this.Name = name;
                this.Age = Age;
            }
        }
        [Attrowner("Cotue", 33)] //you do not specify the name of parameters unlike properties
        class house
        {
            public int windowsNumber { get; set; }
            public int doorsNumber { get; set; }

        }

        public static void AttributeUsageMethod()
        {
            //You can make restrictions granting which kind of members can use attributes
            //example you can make a restriction in the attribute in order to be able to be used in classes

            //AttributeTargets Enums 
            //All           for applying to any C# code element
            //Class         for applying to to C# classes
            //Constructor   for applying to constructors
            //Delegate      for applying to delegates
            //Enum          for applying to enumerations
            //Field         for applying to fields
            //Interface     for applying to interfaces
            //Method        for applying to methods
            //Property      for applying to parameters
            //Struct        for applying to structs

            // you can use | to add more than one AttributeTargets
            // the AttributeTargets are added up to the attributes

            Assembly assembly = Assembly.GetExecutingAssembly();

            //select all the classes that have at least one attribute attrPerson

            var typesTagged = from type in assembly.GetTypes()
                              where type.GetCustomAttributes<attrPerson>().Count() > 0
                              select type;


            foreach (Type type in typesTagged)
            {

                Console.WriteLine(type.Name);
                var properties = from property in type.GetProperties()
                                 where property.GetCustomAttributes<attrPerson>().Count() > 0
                                 select property;

                foreach (var property in properties)
                {
                    Console.WriteLine(property.Name);
                }

                                 
            }

        }

       


        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
        class attrPerson: Attribute
        {
            
        }

        [attrPerson]
        class student
        {
            

          
            public int Age { get; set; }
            [attrPerson]
            public string Name { get; set; }

            //[attrPerson] it can not be tagged
            public void getBirthYear()
            {

            }
        }

        public static void Use_ILdasm_exe_ToViewAssemblyContent()
        {
            //you can view the content of a Assembly in a readable way using ILdasm.exe (INTERMEDIATE LANGUAGE DISASSEMBLER)
            //ILDASM is a tool to convert msil to readable human language
            //to do it follow the next steps
            //1.-execute visual studio command prompt 
            //2.-navigate to the root of the assembly
            //3.- execute the command     ildasm ASSEMBLYNAME 

        }

    }

    

    class person
    {
        public delegate void myDelegate(string Name);

        public event myDelegate myEvent;

        public string Name { get; set; }
        private int IdPerson { get; set; }
        
        public int Age { get; set; }
        public person()
        {

        }

        public int this[int index]
        {
            get
            {
                return 1;
            }
            set
            {

            }
        }

        public void PrintPerson()
        {
            Console.WriteLine("Id Person: {0}  Name: {1} Age: {2}", IdPerson, Name, Age);
        }

        public static person[] GetPeople()
        {

            Random ran = new Random();
            int size = ran.Next();
            return new person[size];
        }

        private int CalculateAge()
        {
            Random ran = new Random();
            return ran.Next();
        }


        public static implicit operator string(person p)
        {
            return p.Name;
        }

        public static bool operator > (person p1, person p2)
        {
           
            return p1.Age > p2.Age;
        }

        public static bool operator <(person p1, person p2)
        {

            return p1.Age < p2.Age;
        }

        public override string ToString()
        {
            return Name;
        }
       
    }

    class student: person
    {

    }
    enum days:byte
    {
        mon = 1,
        tue,
        wed,
        thu,
        fry,
        sat,
        sun
    }

    struct Coodinates
    {
        public int x{ get; set; }
        public int y { get; set; }
        public int z { get; set; }
    }
}
