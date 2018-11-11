using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;
namespace DeepDiveintoLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //TypesOfLinq();
            //LinqToObject();
            LinqXml();
            Console.ReadLine();
        }

        static void TypesOfLinq()
        {
            //Types of Linq

            //LINQ to Object
            //LINQ to Entities
            //LINQ to Dataset
            //LINQ to SQL
            //LINQ to XML
            //Parallel LINQ

            //LINQ Operators

            // Filtering Operator   | where
            // Projection Operator  | select
            // Joining Operator     | join..in..on, equals
            // Grouping Operator    | group…..by <or> group…by..into   or    GroupBy(<predicate>) note: GroupBy and ToLookup are grouping operators
            // Partition Operator   | skip, take
            // Aggregation          | Average, Count, Max, Min, Sum


            //There are two ways or syntaxes of LINQ query:
            //1.Method Syntax  note: Method Syntax is also called Fluent Syntax because it allows a series of extension methods to call.
            //2.Query Syntax

            //Parts of Query Operation

            //1.Obtain the Data Source
            //2.Create a Query
            //3.Execute the Query
            //  3.1 Deferred
            //      3.1.1 ToList<T>, ToArray<T>
            //      3.1.2 Aggregation methods
            //  3.2 Inmediate

            string[] names = {"Angy", "Peter", "Pimi", "Josua", "Jessica", "Johana","Juliet","Mary ann", "Bryan", "Sasha" };
            //method sintax
            IEnumerable<string> namesFiltered = names.Where(n => n.StartsWith("J"));

            foreach(string n in namesFiltered)
            {
                Console.WriteLine("{0}", n);
            }

            //Query sintax. 
            IEnumerable<string> namesFilteredQ = from n in names
                                                 where n.StartsWith("J")
                                                 select n;
            
            foreach(var n in namesFilteredQ)
            {
                Console.WriteLine("{0}", n);
            }

           
        }
        static void LinqToObject()
        {
            List<person> people = new List<person>();

            people.Add(new person() { Name = "joseph", Adress = "Bronsville", Age = 32, IDPerson = 1, Salary = 20000F });
            people.Add(new person() { Name = "johana", Adress = "Texas", Age = 23, IDPerson = 2, Salary = 20000F });
            people.Add(new person() { Name = "joseph", Adress = "Mcalen", Age = 20, IDPerson = 3, Salary = 25000F });
            people.Add(new person() { Name = "july", Adress = "New York", Age = 18, IDPerson = 4, Salary = 30000F });
            people.Add(new person() { Name = "june", Adress = "Washinton", Age = 19, IDPerson = 5, Salary = 32000F });
            people.Add(new person() { Name = "Mark", Adress = "Bronsville", Age = 35, IDPerson = 6, Salary = 24000F });
            people.Add(new person() { Name = "Dany", Adress = "Texas", Age = 32, IDPerson = 7, Salary = 21000F });
            people.Add(new person() { Name = "Mia", Adress = "Bronsville", Age = 22, IDPerson = 8, Salary = 23000F });
            people.Add(new person() { Name = "Standley", Adress = "Washinton", Age = 29, IDPerson = 9, Salary = 18000F });
            people.Add(new person() { Name = "Maryan", Adress = "New York", Age = 40, IDPerson = 10, Salary = 17000F });

            List<property> properties = new List<property>();
            properties.Add(new property() { IDPerson=1, PropertyName="House"});
            properties.Add(new property() { IDPerson = 1, PropertyName = "Deparment" });
            properties.Add(new property() { IDPerson = 2, PropertyName = "House" });
            properties.Add(new property() { IDPerson = 2, PropertyName = "Deparment" });
            properties.Add(new property() { IDPerson = 3, PropertyName = "Deparment" });
            properties.Add(new property() { IDPerson = 4, PropertyName = "Deparment" });
            properties.Add(new property() { IDPerson = 5, PropertyName = "buiding" });
            properties.Add(new property() { IDPerson = 6, PropertyName = "House" });
            properties.Add(new property() { IDPerson = 7, PropertyName = "buiding" });
            properties.Add(new property() { IDPerson = 8, PropertyName = "buiding" });
            properties.Add(new property() { IDPerson = 9, PropertyName = "car" });
            properties.Add(new property() { IDPerson = 10, PropertyName = "car" });
            properties.Add(new property() { IDPerson = 9, PropertyName = "buiding" });
            properties.Add(new property() { IDPerson = 8, PropertyName = "car" });
            properties.Add(new property() { IDPerson =3, PropertyName = "car" });
            properties.Add(new property() { IDPerson = 4, PropertyName = "ranch" });
            properties.Add(new property() { IDPerson = 5, PropertyName = "ranch" });

            //filtering operator

            IEnumerable<person> peopleFromWashinton = from p in people
                                                      where p.Adress.Equals("Washinton")
                                                      select p;


            foreach(var p in peopleFromWashinton)
            {
                Console.WriteLine("name: {0}, address: {1}, age: {2}, salary: {3:c} ", p.Name, p.Adress, p.Age, p.Salary);
            }


            //if a new person is added to people and the query is executed, the new person is taken into account
            people.Add(new person() { Name = "Susan", Adress = "Washinton", Age = 21, IDPerson = 11, Salary = 28000F });
            Console.WriteLine();
            Console.WriteLine("Susan was added to the list. The execution of the query is deferred \n");
            foreach (var p in peopleFromWashinton)
            {
                Console.WriteLine("name: {0}, address: {1}, age: {2}, salary: {3:c} ", p.Name, p.Adress, p.Age, p.Salary);
            }


            //projection operator
            //1.- select
            //2.- select many

            var peopleWithSalaryGreatherThan20000 = from p in people
                                                    where p.Salary > 20000
                                                    select p;
            Console.WriteLine();
            Console.WriteLine("People with salary greather than 20000 \n");

            foreach (var p in peopleWithSalaryGreatherThan20000)
            {
                Console.WriteLine("id {4:d2}.- name: {0,5}, address: {1,5}, age: {2,5}, salary: {3:c} ", p.Name, p.Adress, p.Age, p.Salary, p.IDPerson);
            }
            //2.- select many
            var peopleLessThan20Age = from p in people
                                      where p.Age < 20
                                      select new
                                      {
                                          namePerson = p.Name,
                                          agePerson = p.Age,
                                          id = p.IDPerson,
                                          salary = p.Salary,
                                          adress = p.Adress
                                      };

            Console.WriteLine();
            Console.WriteLine("People with age less than 20 \n");

            foreach (var p in peopleLessThan20Age)
            {
                Console.WriteLine("id {4:d2}.- name: {0,5}, address: {1,5}, age: {2,5}, salary: {3:c} ", p.namePerson, p.adress, p.agePerson, p.salary, p.id);
            }


            //Joining Operator

            var peopleWithHose = from pe in people join pr in properties
                                on pe.IDPerson equals pr.IDPerson
                                 where pr.PropertyName.Equals("House")
                                 select new
                                 {
                                     name = pe.Name,
                                     proper = pr.PropertyName,
                                     salary = pe.Salary

                                 };

            Console.WriteLine();
            Console.WriteLine("People with House \n");

            foreach (var p in peopleWithHose)
            {
                Console.WriteLine("name: {0,5}, property: {1,5}, salary: {2:c} ", p.name, p.proper, p.salary);
            }

            //Grouping Operator
            var peopleByAddress = from pe in people
                                  group pe by pe.Adress;
              

            Console.WriteLine();
            Console.WriteLine("Number of people grouped by Address \n");

            foreach (var pe in peopleByAddress)
            {
                Console.WriteLine(pe.Key);
                foreach (var p in pe)
                {
                    Console.WriteLine("id {4:d2}.- name: {0,5}, address: {1,5}, age: {2,5}, salary: {3:c} ", p.Name, p.Adress, p.Age, p.Salary, p.IDPerson);
                }
            }

            Console.WriteLine();
            Console.WriteLine("2 People with Department \n");

            //Partition Operator take
            var Takes2PeopleWithDepartment = (from p in people
                                        join pr in properties
                       on p.IDPerson equals pr.IDPerson
                                        where pr.PropertyName.ToUpper().Trim() == "DEPARMENT"
                                             select p).Take(2);

            foreach (var p in Takes2PeopleWithDepartment)
            {
                Console.WriteLine("id {4:d2}.- name: {0,5}, address: {1,5}, age: {2,5}, salary: {3:c} ", p.Name, p.Adress, p.Age, p.Salary, p.IDPerson);
            }


            Console.WriteLine();
            Console.WriteLine("skip one person with building and bring the rest \n");

            //Partition Operator skip
            var skip1PeopleWithbildingAndBringTheRest = (from p in people
                                              join pr in properties
                             on p.IDPerson equals pr.IDPerson
                                              where pr.PropertyName.ToUpper().Trim() == "BUIDING"
                                                         select p).Skip(1);

            foreach (var p in skip1PeopleWithbildingAndBringTheRest)
            {
                Console.WriteLine("id {4:d2}.- name: {0,5}, address: {1,5}, age: {2,5}, salary: {3:c} ", p.Name, p.Adress, p.Age, p.Salary, p.IDPerson);
            }

            //Agregations inmediat (No Deferred) 

            int PeopleInWashinton = (from p in people
                                    where p.Adress == "Washinton"
                                    select p).Count();

            Console.WriteLine("people from washinton are: {0}", PeopleInWashinton);

        }
        static void LinqXml()
        {
            //Create XML data
            XElement element = new XElement("RootElement");
            XElement element1 = new XElement("Name");
            element.Add(element1);

            element1.Add(new XElement("FirstName", "Yolanda"));
            element1.Add(new XElement("LastName", "Hernandez"));

            element.Add(new XElement("Age", "23"));
            element.Add(new XElement("Salary", "34000"));
            element.Add(new XElement("City", "Mexico"));
            element.Save("sample.xml");

            //Update XML data

            string xmlData = @" <RootElement>
                            <Name>Yolanda Hdez</Name>
                            <Age>22</Age>
                            <Address>Mexico</Address>
                             <Name>Peter</Name>
                            <Age>23</Age>
                            <Address>Mexico</Address>
                            </RootElement>";

            XDocument document = new XDocument();
            document = XDocument.Parse(xmlData);

            var ReadNode = (from n in document.Descendants()
                            where n.Element("Age").Value == "22"
                            select n.Element("Name")).FirstOrDefault();

            ReadNode.ReplaceWith("Juana Crazy");

            document.Save("Sample1.Xml");

            document.Descendants().Where(n => n.Value.Equals("Peter")).Remove();
            document.Save("updatedSample1.xml");

            //Read XML data
            //from File
            Stream file = File.Open("sample.xml", FileMode.Open);

            StreamReader reader = new StreamReader(file);
            string DataXml = reader.ReadToEnd();

            //Read from string

            XDocument doc = new XDocument();
            doc = XDocument.Parse(xmlData);

            var query = (from d in doc.Elements()
                        select d).ToList();

            foreach (var l in query)
            {
                Console.WriteLine("{0}", l.ToString());
            }


            


        }
    }

    class person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int IDPerson { get; set; }
        public string Adress { get; set; }
        public float Salary { get; set; }

    }
    class property
    {
        public int IDPerson { get; set; }
        public string PropertyName { get; set; }
    }

}

    

