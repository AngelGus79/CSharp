using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Xml;
using Newtonsoft.Json;
namespace ConsumeData
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectedLayer();
            //DisconnectedLayer();
            //EntityFramework();
            //ConsumeXMLAndJSONData();
            //XmlWriterMethod();
            //NewtonSoft();
            //proxyWebService();
            //Challenge01();
            Console.ReadLine();
        }
        static void ConnectedLayer()
        {

            //all those are connected layer

            //Namespace System.Data
            //.Net Framewort provides a set of libraries (ADO.Net) to connect with relational, XML, and application data.
            // ADO. Net provides sets of clases  to connect with many DataBases, they are called Data Providers
            // There are Data Providers to connect to Sql Server (System.Data.SqlClient namespace to find the clases), Oracle, MySql and so on.

            //    CONNECTION
            //You must establish a connection with the Data Base to work with.
            //A connectionstring is required to establish the connection wich contains data location, database name, data provider, and authentication
            //The base class about connections is DbConnection
            //The derived class of DbConnection to connect to sql server data base is SqlConnection

            //       COMMAND
            //sql command class is used to execute statements like insert, delete , update, store procedures
            //sqlcommand object
            // ExecuteNonQuery. it is used to execute delete, insert and update. Return a integer with the affected rows
            // ExecuteScalar. it is used to execute a query that returns a scalar value, like aggregate functions (sum, count, avg and so on).
            // ExecuteReader. it is used when you need to re retrieve data, as when you use select to retrieve rows. This methos return a SqlDataReader object. This is forward only and it has good performance
            // ExecuteXMLReader. the same that ExecuteReader but this returns XmlReader to convert data in xml format

            //Example of ExecuteReader 
            string connectionString = @"Data Source = (local)\SQLEXPRESS2016; Initial Catalog = db1; Integrated Security = True";
            SqlConnection con = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand();
            command.Connection = con;
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "select * from tb_usuarios";

            con.Open();
            SqlDataReader reader = command.ExecuteReader();
           

            while (reader.Read())
            {
                Console.WriteLine("{0}, {1}, {2}", reader[0], reader[1], reader[2]); // the connection MUST BE open
            };
            con.Close();//you must close the connection after performing the operation
            //if you exceed the number of connections it will not allow to connect other users.

            //other way to connect a database
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

            builder.DataSource = "";
            builder.InitialCatalog = "";
            builder.IntegratedSecurity = true;

            string conString = builder.ToString();
           
            //Example with ExecuteNonQuery
            command = new SqlCommand("update tb_usuarios set age = 23 where name = 'johana'", con);
            con.Open();
            int affectedRows = command.ExecuteNonQuery();
            con.Close();

            //Example with ExecuteScalar
            command = new SqlCommand("select max(age) from tb_usuarios", con);
            con.Open();
            var maxAge = command.ExecuteScalar();
            con.Close();

            Console.WriteLine("the maximum age is {0}", maxAge);


        }

        static void DisconnectedLayer()
        {
            //With disconnected layer you can create a memory structure (DateSet) similar than relational database structure. You can modify various rows and after that they can be updated in the database using DataAdapter object
            //DataTable object (memory object) is similar that table structure in the database
            //You can move in a DataTable rows in foreward and backward way.

            SqlConnection con = new SqlConnection(@"Data Source= (local)\SQLEXPRESS2016; Initial Catalog= db1; Integrated Security= true ");

            //creating a SqlDataAdapter
            SqlDataAdapter adapter = new SqlDataAdapter("select * from tb_usuarios", con);
            //creating a SqlDataTable
            DataTable table = new DataTable();
            adapter.Fill(table);
            con.Close();

            foreach (DataRow r in table.Rows)
            {
                Console.WriteLine("{0}, {1}, {2}", r[0], r[1], r[2]);
            }

            //if you have many tables you can retrieve them using a DataSet

            SqlConnection connection = new SqlConnection(@"Data Source=(local)\SQLEXPRESS2016; Initial Catalog= db1; Integrated Security=true");

            SqlDataAdapter adap = new SqlDataAdapter("select * from Marks; select * from tb_usuarios", connection);

            DataSet ds = new DataSet();
            adap.Fill(ds);
            connection.Close();

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                Console.WriteLine("{0}, {1}, {2}", dr[0], dr[1], dr[2]);
            }

            DataRow newRow = ds.Tables[0].NewRow();
            newRow["id"] = 0;
            newRow["Math"] = 95;
            newRow["English"] = 70;
            newRow["Computing"] = 80;

            //to add a new Row
            //ds.Tables[0].Rows.Add(newRow);

            //To update the new added row in the dataBase, we can to create the commands in the dataAdapter to insert them

            SqlCommand insertCommand = new SqlCommand("insert into Marks(id, Math,English,Computing) values(@id, @Math, @English, @Computing)", connection);

            insertCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, Int32.MaxValue, "id"));
            insertCommand.Parameters.Add(new SqlParameter("@Math", SqlDbType.Float,8,"Math" ));
            insertCommand.Parameters.Add(new SqlParameter("@English", SqlDbType.Float, 8, "English"));
            insertCommand.Parameters.Add(new SqlParameter("@Computing", SqlDbType.Float, 8, "Computing"));

            adap.InsertCommand = insertCommand;

            connection.Open();
            adap.Update(ds);
            connection.Close();

            foreach(DataRow r in ds.Tables[0].Rows)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}", r[0], r[1], r[2], r[3]);
            }


        }

        static void EntityFramework()
        {
            //A way to interact with database of a object-oriented way is using Entity Framework
            //1.You do not have to worry of using layer connected or disconnected objects
            //2. you do not have to worry connecting/disconnecting to the database
            //3. you do not need strong knowledges about sql queries
            //To make queries you can use LINQ
            //Entity framework has less performance than using connected and disconnected layer objects

            //there are 4 ways to use Entity Framework
            //1.EF Designer from database
            //2.Empty EF Designer model
            //3.Empty Code First model
            //4.Code first from database

            //using Code first from database

            usersDB users = new usersDB();
            
            
            //deleting a item

            var deleteItem = (from i in users.Marks
                              where i.Id == 2
                              select i).FirstOrDefault();

            users.Marks.Remove(deleteItem);
           
            users.SaveChanges(); //save changes in the data base

           

            //Adding new item
            Mark mark = new Mark();
            
            mark.Id = 2;
            mark.Math = 32;
            mark.English = 32;
            mark.Computing = 33;

            //from the users object wich represents the DB you select the table
            users.Marks.Add(mark);

            var query = from m in users.Marks
                        select m;

            foreach( var r in query )
            {
                Console.WriteLine("{0}, {1}, {2}, {3}", r.Id, r.Math, r.Computing, r.English);
            }

            users.SaveChanges();//save changes in the data base

            foreach (var r in query)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}", r.Id, r.Math, r.Computing, r.English);
            }

            //updating rows

            Mark item = (from m in users.Marks
                         where m.Id == 0
                         select m).FirstOrDefault();

            if (item != null)
            {
                item.Math = 43;
                users.SaveChanges();
            }

            foreach(Mark m in users.Marks)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}", m.Id, m.Math, m.Computing, m.English);
            }

        }

        static void ConsumeXMLAndJSONData()
        {


            string myXml = @"<students><student><id>1</id><name>pricila</name> </student><student><id>2</id><name>madyson</name> </student></students>";

            StringReader stream = new StringReader(myXml);
            //it does not charge all document that is way is more efficient
            XmlReader reader = XmlReader.Create(stream);

            while (reader.Read())
            {
                Console.WriteLine("{0}", reader.Value);
            }

            //reading a document

            StringReader st = new StringReader(myXml);

            XmlDocument document = new XmlDocument();
            document.Load(st);

            foreach(XmlNode node in document.DocumentElement)
            {
                Console.WriteLine(node.InnerText);
            }

            
        }

        static void XmlWriterMethod()
        {
            //StringWriter stream = new StringWriter();

            FileStream stream = File.Create("xmlwriter.xml");

            using (XmlWriter writer = XmlWriter.Create(stream, new XmlWriterSettings { Indent = true }))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("students");
                writer.WriteAttributeString("id", "1");
                writer.WriteElementString("Name", "jhon");
                writer.WriteEndElement();
                writer.WriteEndDocument();
            };

            //Console.WriteLine("{0}", stream);
        }

        class product
        {
            public string name { get; set; }
            public decimal price { get; set; }
            public List<string> size { get; set; }
        }

        static void NewtonSoft()
        {
            //this library is more efficient than DataContractJsonSerializer and JavaScriptSerializer
            //using Newtonsoft.Json;
            product p = new product();
            p.name = "shirt";
            p.price = 23.3m;

            List<string> size = new List<string>() {"large", "Medium" };
            //size.Add("large");
            //size.Add("medium");
            p.size = size;

            string jsonString = JsonConvert.SerializeObject(p);
            Console.WriteLine(jsonString);

            product p1 = JsonConvert.DeserializeObject<product>(jsonString);

            Console.WriteLine("{0}, {1}, {2}", p1.name, p1.price, p1.size[0]);


            

        }

        static void webServices()
        {
            //for use web services you need to know:
            // 1. the address of the web service
            // 2. And know how to call it

            //ASMX Web Service
            //To create a web service throw visually designed class for web service, need to do:
            //1. Creating the web service
            //2. creating proxy and consuming the web service


            //creating the web service.
            //1.-create a new asp.net empty project-you will fing it in .net framework 3.5
            //2.-add a new item and select web service (ASMX)
        }

        static void proxyWebService()
        {
            //for creating a web proxy
            //1. add the service reference to the project of the web service
            //2. create the proxy for your service to use the methods

            ServiceReference.WebService1SoapClient proxy = new ServiceReference.WebService1SoapClient();

            string numberType = proxy.IsOdd(3);
            Console.WriteLine("the number {0}", numberType);
            Console.WriteLine("{0}", proxy.HelloWorld());
        }

        static void WCFWebService()
        {
            //WCF is a modern ASMX web service

            //WCF service can be hosted in IIS, WAS, Console, WCF Provided Host
            //ASMX service can just be hosted in IIS

            //WFC service supports various protocols like HTTP, TCP, MSMQ, and NamedPipes
            //ASMX service on support HTTP

            //WCF service uses DataContracSerializer
            //ASMX service uses XMLSerializer
        }

        static void Challenge01()
        {
            SchoolServiceReference.WebService1SoapClient proxy = new SchoolServiceReference.WebService1SoapClient();

            string jsonData = proxy.ReadAll();

            List<StudentS> students = JsonConvert.DeserializeObject<List<StudentS>>(jsonData);

            foreach(var s in students)
            {
                Console.WriteLine(s.IdStudent);
                Console.WriteLine(s.NameStudent);
            }
            //proxy.Add(2, "Dany");


        }

        class StudentS
        {
            public int IdStudent { get; set; }
            public string NameStudent { get; set; }
        }
    }
}
