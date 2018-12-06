using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters;
using System.IO;
using System.Xml.Serialization;
using System.Web.Script.Serialization;

namespace Serialization_and_Deserialization
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            //BinarySerialization();
            //XmlSerializerMethod();
            //ConfiguringXmlSerialization();
            //DataContractMethod();
            //DataContractJsonSerilization();
            //JavaScripSerializerMethod();
            Challenge01();
            Console.ReadLine();
        }

        [Serializable]
        class person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            private decimal Salary { get; set; }
            public DateTime BirthDay { get; set; }
        }

        [Serializable]
        class person1
        {
            public string Name { get; set; }
            public int Age { get; set; }

            [NonSerialized] //it is a field. it is not an property
            public decimal Salary;

            public DateTime BirthDay { get; set; }
        }
        [Serializable]
        public class teacher
        {
            public string Name { get; set; }
            public int Age { get; set; }
            private DateTime BirthDay { get; set; }
            public bool Sex { get; set; }
        }

        public static void XmlSerializerMethod()
        {


            teacher t = new teacher()

            // With XML serialization you can serialize an object into XML format or an XML stream. 
            //this serialization DOES NOT save inf about the fields  like object’s Type information including       version, public token, culture, and assembly name  creating the object

            {
                Name = "johana",
                Age = 23,
                //BirthDay = new DateTime(1980, 11, 12),
                Sex = true

            };

            //TO EXECUTE THIS SNIPPET OF CODE, I HAD TO SET PUBLIC THE PROGRAM CLASS, THE METHOD  AND THE CLASS TO BE SERIALIZED

            //serializing xml. Converts an object in xml format
            // with this method you can not serialize private fields 
            //XML serialization works without specifying [Serializable] up the class type, but it is bad approach.
            //This serializing DOES NOT save information about the field like Type information (including version, public token, culture, and assembly name  creating the object) as binary serialization
            //public members are serialized by default

            XmlSerializer serializer = new XmlSerializer(typeof(teacher));

            using (FileStream file = new FileStream("XmlSample.xml", FileMode.Create))
            {
                serializer.Serialize(file, t);
            }

            //deserializing. Converts an xml format in a object

            XmlSerializer deserializer = new XmlSerializer(typeof(teacher));
            teacher t1 = null;

            using (FileStream f1 = new FileStream("XmlSample.xml", FileMode.Open))
            {
                t1 = (teacher)deserializer.Deserialize(f1);
            }

            //Console.WriteLine("Name: {0}, Age: {1}, BirthDay: {2}, Sex: {3}",t1.Name, t1.Age, t1.BirthDay, t1.Sex == false ? "Male" : "Female");
            Console.WriteLine("Name: {0}, Age: {1}, Sex: {2}", t1.Name, t1.Age, t1.Sex == false ? "Male" : "Female");

        }
        private static void BinarySerialization()
        {

            //this serialization converts a object in a binary format
            //this serialization apart to save data save also object’s Type information including       version, public token, culture, and assembly name  creating the object
            //this serialization depends upon the .net platform
            //this serialization save public and private fields
            //if you want to avoid serialize an field you must use [NonSerialized] attribute upon the field class
            //if a field is not found by the binary serializer, an exception is thrown.
            //use [OptionalFieldAttribute] to make sure that the binary serializer if some of the serialized objects does not have some field-

            person p = new person()
            {
                Name = "stephany",
                Age = 23,
                BirthDay = new DateTime(1989, 2, 22)

            };

            //serializing. Convert the class in bytes to save them in a file
            BinaryFormatter serializer = new BinaryFormatter();

            using (FileStream file = File.Create("sample.bin"))
            {
                serializer.Serialize(file, p);
            }

            //deserializing
            BinaryFormatter deserializing = new BinaryFormatter();
            person p1 = null;
            using (FileStream file = File.Open("sample.bin", FileMode.Open))
            {
                p1 = (person)deserializing.Deserialize(file);
            }


            Console.WriteLine(p1.Name);
            Console.WriteLine(p1.Age);
            Console.WriteLine(p1.BirthDay);

        }

        //configuring the serialization
        [Serializable]
        [XmlRoot("Student")] //put the Student as root
        public class student
        {
            [XmlAttribute("ID")] //put ID as attribute of its parent
            public int id { get; set; }
            [XmlElement("Name")] //put Name as element
            public string Name { get; set; }
            [XmlIgnore] //avoid to be serialized
            public decimal Salary { get; set; }
            [XmlElement("Marks")]
            public mark Mark { get; set; }
            //[XmlArray], [XmlArrayItem]: for collection type fields

        }
        [Serializable]
        public class mark
        {
            [XmlElement]
            public int math { get; set; }
            [XmlElement]
            public int english { get; set; }
            [XmlElement]
            public int computing { get; set; }
        }

        public static void ConfiguringXmlSerialization()
        {
            //instancing a student class

            student Student = new student()
            {
                Name = "Holiday",
                id = 1,
                Mark = new mark
                {
                    math = 90,
                    english = 100,
                    computing = 90
                },
                Salary = 100000
            };

            //serializing the object
            XmlSerializer serializer = new XmlSerializer(typeof(student));

            using (FileStream file = File.Create("XmlSample02.xml"))
            {
                serializer.Serialize(file, Student);
            }

            //deserialize
            XmlSerializer deserializer = new XmlSerializer(typeof(student));
            student s1 = null;
            using (FileStream file = File.Open("XmlSample02.xml", FileMode.Open))
            {
                s1 = (student)deserializer.Deserialize(file);
            }


            Console.WriteLine("ID: {0}, Name: {1}, Marks: {2},{3},{4} ", s1.id, s1.Name, s1.Mark.math, s1.Mark.english, s1.Mark.computing);
        }

        [DataContract]
        public class car
        {
            [DataMember]
            public int ID { get; set; }
            [DataMember]
            public int wheels { get; set; }
            [DataMember]
            public string color { get; set; }
            [DataMember]
            private int model = 1980;
        }
        public static void DataContractMethod()
        {
            //system.Runtime.Serialization. Add system.Runtime.Serialization assembly
            //this serialization serializes to xml format
            //this serialization DOES NOT serialize by default the members
            //if it is specified, this serialization can serialize private members
            car c = new car
            {
                wheels = 4,
                ID = 1,
                color = "red"

            };

            //serializing
            DataContractSerializer serializer = new DataContractSerializer(typeof(car));

            using (FileStream file = new FileStream("XmlSample03.xml", FileMode.Create))
            {
                serializer.WriteObject(file, c);
            }

            //deserializing
            DataContractSerializer deserializer = new DataContractSerializer(typeof(car));
            car c1 = null;

            using (FileStream f = new FileStream("XmlSample03.xml", FileMode.Open))
            {
                c1 = (car)deserializer.ReadObject(f);
            }

            Console.WriteLine("id: {0}, wheels: {1}, color: {2}", c1.ID, c1.wheels, c1.color);
        }

        public static void DataContractJsonSerilization()
        {
            //it is used of the same way that DataContract but with the class for json
            car c = new car
            {
                ID = 1,
                wheels = 4,
                color = "blue"

            };

            //serializing
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(car));

            using (FileStream file = new FileStream("jsonSample.json", FileMode.Create))
            {
                serializer.WriteObject(file, c);
            }

            //deserializing

            DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(car));
            car c1 = null;
            using (FileStream file = new FileStream("jsonSample.json", FileMode.Open))
            {
                c1 = (car)deserializer.ReadObject(file);
            }

            Console.WriteLine("id: {0}, wheels: {1}, color: {2}", c1.ID, c1.wheels, c1.color);
        }


        class bill
        {
            public DateTime Date { get; set; }
            public string Description { get; set; }
            public decimal Total { get; set; }
        }
        public static void JavaScripSerializerMethod()
        {
            //using System.Web.Script.Serialization; add the system.web.extensions assembly
            // it does not require attributes

            bill b = new bill
            {
                Date = new DateTime(2018, 12, 01),
                Description = "meals",
                Total = 120
            };


            //serializing
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string StringData = serializer.Serialize(b);

            //deserializing
            JavaScriptSerializer deserializer = new JavaScriptSerializer();
            bill b1 = deserializer.Deserialize<bill>(StringData);

            Console.WriteLine("{0}, {1}, {2}", b1.Date, b1.Description, b1.Total);

        }

        public class Teacher : ISerializable
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public Teacher()
            {

            }
            protected Teacher(SerializationInfo info, StreamingContext context)
            {
                this.ID = info.GetInt32("IDKey");
                this.Name = info.GetString("NameKey");
            }
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue("IDKey", 1);
                info.AddValue("NameKey", "johana");
            }
        }

        public static void CustomSerialization()
        {
            //custom serialization can be implemented with ISerializable interface
            // it implements GetObjectData() method to serialize an a special constructor to deserialize

        }
        public static void Challenge01()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(PurchaseOrder));
            PurchaseOrder p = null;
            using(var file = File.Open("XmlMsdn.xml", FileMode.Open))
            {
                p = (PurchaseOrder)deserializer.Deserialize(file);
            }

            Console.WriteLine("{0}, {1}, {2}, {3}", p.OrderDate, p.ShipCost, p.SubTotal, p.TotalCost);
        }



    }

    [XmlRoot("PurchaseOrder", Namespace = "http://www.cpandl.com",
IsNullable = false)]
    public class PurchaseOrder
    {
        public Address ShipTo;
        public string OrderDate;
        // The XmlArray attribute changes the XML element name  
        // from the default of "OrderedItems" to "Items".  
        [XmlArray("Items")]
        public OrderedItem[] OrderedItems;
        public decimal SubTotal;
        public decimal ShipCost;
        public decimal TotalCost;
    }

    public class Address
    {
        // The XmlAttribute attribute instructs the XmlSerializer to serialize the   
        // Name field as an XML attribute instead of an XML element (the   
        // default behavior).  
        [XmlAttribute]
        public string Name;
        public string Line1;

        // Setting the IsNullable property to false instructs the   
        // XmlSerializer that the XML attribute will not appear if   
        // the City field is set to a null reference.  
        [XmlElement(IsNullable = false)]
        public string City;
        public string State;
        public string Zip;
    }

    public class OrderedItem
    {
        public string ItemName;
        public string Description;
        public decimal UnitPrice;
        public int Quantity;
        public decimal LineTotal;

        // Calculate is a custom method that calculates the price per item  
        // and stores the value in a field.  
        public void Calculate()
        {
            LineTotal = UnitPrice * Quantity;
        }
    }
}

