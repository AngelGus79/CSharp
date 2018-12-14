#define _mySymbol_
//#undef _mySymbol_
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Configuration;
using System.Threading; 

namespace Debugging_and_Diagnostics
{
    class Program
    {
        static void Main(string[] args)
        {
            //using System.Diagnostics;
            //The process of identifying and removing errors is called debugging.
            //Build type
            //1. Debug Mode. Extra information is added to the assembly for debugging pruposes. Code is not optimized.
            //2. Release Mode. No extra information is added to assembly. optimized code.
            //DebugClass();
            //PreprocessorDirectives();
            //DebugAndTraceClass("");
            // DebugAndTraceClass("test.txt");
            //TraceClass1();
            //TraceListeners();
            //TraceListeners01();
            //UsingConfigFile();
            //EventLogTraceListenerMethod();
            //ReadingEventLog();
            //EventLogWithTraceSource();
            // ProfilingTheApplication();
            //CreatingPerformanceCounters();
            //UsingCounters();
            Challenge01();
            Console.ReadLine();



        }

        static void DebugClass()
        {

            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    //Debug class is just used in debug mode
                    //In debug mode, in the output (salida) window the message "There is a debug" is written
                    //In Release mode, no message is written
                    Debug.WriteLine("There is a debug");
                }
            }
        }

        static void PreprocessorDirectives()
        {
            // the preprocessor compiler directives are used to make code easier to modify or to send instructions to the compiler how to compile specific code blocks. 
            //For example in xamarin you use #if __ANDROID__ , #if __IOS__ to compile a code block for differents environments
            //some of the directives are:
            //#define  used to define a symbol  
            //#undef   used to undefine the defined symbol using #define directive 
            //#if #else #elif #endif   used to evaluate the symbol defined and execute its code if it finds the symbol defined. 
            //#error   used to generate error from a specific location in the code.
            //#warning  use to generate warning from a specific location in the code.
            //#line  used to modify the existing line number of compiler and output filename for errors and warnings.

            //Also you can create symbols in  <properties> of project / <build> tab / <conditional compilation symbols> entry. 

#if _mySymbol_
            Console.WriteLine("True. This code is going to be compiled");

#else
            Console.WriteLine("False. This code is going to be compiled");
#error No symbol Defined.
#endif

            Console.WriteLine("Normal number line");
#line 200 "Special"
            int i;
            int j;
#line default
            char c;
            float f;
#line hidden // numbering not affected  
            string s;
            double d;

            //you can see how the compiler line change by the output, compilation order option
        }

        static void DiagnosisMethod()
        {
            //Diagnosis helps you to face with performance-related issues
            //Features of diagnostics means to add code for logging and tracing or to monitor applications’ health.
            //you can instrument your application to perform diagnosis
            //1.Logging and Tracing
            //  Logging means recording errors.
            //  You can track the program’s execution to inquire which calling methods, which decision statement it is making,  errors and warnings, etc. 
            //          Tracing has three phases:
            //            1.Instrumenting: Adding tracing code in your application.
            //            2.Tracing and logging: The tracing code traces the issues and writes to a specified target.The target might be an output window, file, database, or event log.
            //            3.Analysis: After getting the issues described in a specific format or written in a specific target, you analyze the details and identify the problem.
            //  
            //            
            //2.Profiling the Application

        }

        static void DebugAndTraceClass(string FileName)
        {
            Debug.Assert(!(FileName.Length == 0), "File Name is missing");
            try
            {

                Debug.WriteLineIf(File.Exists(FileName), "The File allready Exists");

                using (FileStream myFile = File.Create(FileName))
                {
                    Debug.WriteLine("The File is created successfully");
                    using (StreamWriter writer = new StreamWriter(myFile))
                    {
                        writer.WriteLine("This is a text");
                        writer.WriteLine("This another piece of text");
                        Debug.Indent();
                        Debug.WriteLine("Some information has been added to the file successfully");
                        Debug.Unindent();
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("An exception has occurred: " + ex.Message.ToString());
            }


        }

        static void TraceClass1()
        {


            string connectionString = @"Data Source = (Local)\SQLEXPRESS2016; Initial Catalog = Users; Integrated Security = True";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmdInsert = new SqlCommand("insert into Users(UserName, PassWord, Salt) Values( @UserName, @PassWord, @Salt)", connection);
            SqlCommand cmdDelete = new SqlCommand("delete from Users Where Id = @Id", connection);
            SqlCommand cmdUpdate = new SqlCommand("update Users Set UserName = @UserName, PassWord=@PassWord, Salt=@Salt Where id = @id", connection);
            SqlCommand cmdSelect = new SqlCommand("Select * from Users", connection);

            cmdInsert.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, int.MaxValue, "Id"));
            cmdInsert.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 100, "UserName"));
            cmdInsert.Parameters.Add(new SqlParameter("@PassWord", SqlDbType.NVarChar, 100, "PassWord"));
            cmdInsert.Parameters.Add(new SqlParameter("@Salt", SqlDbType.NVarChar, 1000, "Salt"));

            cmdDelete.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, int.MaxValue, "Id"));
            cmdDelete.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 100, "UserName"));
            cmdDelete.Parameters.Add(new SqlParameter("@PassWord", SqlDbType.NVarChar, 100, "PassWord"));
            cmdDelete.Parameters.Add(new SqlParameter("@Salt", SqlDbType.NVarChar, 1000, "Salt"));

            cmdUpdate.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, int.MaxValue, "Id"));
            cmdUpdate.Parameters.Add(new SqlParameter("@UserName", SqlDbType.NVarChar, 100, "UserName"));
            cmdUpdate.Parameters.Add(new SqlParameter("@PassWord", SqlDbType.NVarChar, 100, "PassWord"));
            cmdUpdate.Parameters.Add(new SqlParameter("@Salt", SqlDbType.NVarChar, 1000, "Salt"));

            SqlDataAdapter da = new SqlDataAdapter();
            da.InsertCommand = cmdInsert;
            da.DeleteCommand = cmdDelete;
            da.UpdateCommand = cmdUpdate;
            da.SelectCommand = cmdSelect;

            DataSet ds = new DataSet();

            connection.Open();
            da.Fill(ds);
            connection.Close();
            Trace.WriteLine("The rows were retrieved successfully");

            DataRow dr = ds.Tables[0].NewRow();

            string UserName = "July";
            string PassWord = "A3s";
            string Salt = "Salt";

            Trace.Indent();
            Trace.WriteLineIf(UserName.Length > 0, "UserName is greather than zero");
            Trace.Unindent();

            string patternName = @"^[A-Z]{1}[a-z]*$";
            string patterPassWord = @"^\w*[A-Z]+[0-9]+[a-z]+$";

            Trace.Assert(!Regex.IsMatch(UserName, patternName), "User Name is not strong");
            Trace.Assert(!Regex.IsMatch(PassWord, patterPassWord), "Password is not strong");

            dr["UserName"] = UserName;
            dr["PassWord"] = PassWord;
            dr["Salt"] = Salt;

            ds.Tables[0].Rows.Add(dr);

            connection.Open();

            da.Update(ds);
            connection.Close();
            Trace.WriteLine("The DataBase was updated Successfully");
        }

        static void TraceSourceMethod()
        {
            //It is preferable to use TraceSource than trace static class
            //first parameter is the name of TraceSource, you can create all you need
            //second parameter is Source Level, which indicates if you want to trace errors, warnings, all, etc.
            TraceSource ts = new TraceSource("TraceSource1", SourceLevels.All);


            ts.TraceInformation("Tracing the application..");
            //this method (TraceEvent) send to the listener the  event type, identifier, and a message
            ts.TraceEvent(TraceEventType.Error, 0, "Error trace Event");
            //this method (TraceData) send to the listener the tracetype, identifier and message array
            ts.TraceData(TraceEventType.Information, 1, new string[] { "Info1", "Info2" });
            ts.Flush();//flush the buffers
            ts.Close();//close the listeners (in this case listener is outout window)
        }

        static void PDBfileMethod()
        {    //Program Data Base File contains information about the program used for debugging or throwing error at a specific location.
             //This file is created when a program is compiled
             // <properties> of project / <buid> Tab / <advance> button / <debug info> combobox. You can modify the information stored in the PDB file
             // <full> is the default option in debug mode. In addition to create the PDB file, an assembly with debug information is created.
             // <pdb-only> is for realease mode. In addition to create the PDB dile, an assembly without debug information is created.
             // <none> you do not create PDB file, thus you can not debbug the program
             //The reason a PDB file is generated in Release Mode is to have information for exception messages about
             //where the error occurred, i.e., stack trace or target of error, etc.Most importantly, you cannot trace your
             //errors or message without having a PDB file.

        }

        static void TraceListeners()
        {
            //Trace listeners get information from Debug, Trace, TraceSource to write in event log, files, output window etc...
            //The listeners in .Net are
            //1.ConsoleTraceListener
            //2.DelimitedTraceListener
            //3.EventLogTraceListener
            //4.TextWriterTraceListener
            //5.XmlWriterTraceListener

            //1. create a tracesource object
            TraceSource traceSource = new TraceSource("TraceSource1", SourceLevels.All);

            //2. cleare all listeners
            traceSource.Listeners.Clear();

            //3. create a listener, this is added in the console
            ConsoleTraceListener consoleListener = new ConsoleTraceListener();

            //4. Add the listener to the trace object
            traceSource.Listeners.Add(consoleListener);
            try
            {
                traceSource.TraceInformation("inicializing tracing application...");
                Console.Write("User Name: ");
                string UserName = Console.ReadLine();

                if (UserName.Length == 0)
                    throw new MissingUserNameException("User Name is missing");

                traceSource.TraceEvent(TraceEventType.Information, 0, "The user name has been entered successfully");

                Console.Write("Password: ");
                string Password = null;
                while (true)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter)
                        break;
                    Password = Password + key.KeyChar;
                    Console.Write("*");
                };

                traceSource.TraceData(TraceEventType.Information, 1, new string[] { "The Password has been added", "The process was successful" });


                HashAlgorithm sha512 = SHA512.Create();

                byte[] PasswordBytes = Encoding.UTF8.GetBytes(Password);
                byte[] hashedPasswordBytes = sha512.ComputeHash(PasswordBytes, 0, PasswordBytes.Length);

                traceSource.TraceEvent(TraceEventType.Information, 2, "The hashed password has been created successfully");

                StringBuilder hashedPassword = new StringBuilder();

                foreach (byte item in hashedPasswordBytes)
                {
                    hashedPassword.AppendFormat("{0:x2}", item);
                }

                traceSource.TraceEvent(TraceEventType.Information, 3, "The hashed password was casting to string successfully");
                Console.WriteLine("\n{0} The Hashed Password is: {1}", hashedPassword.Length, hashedPassword.ToString());
            }
            catch (MissingUserNameException ex)
            {
                traceSource.TraceEvent(TraceEventType.Critical, 0, ex.Message);
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                traceSource.TraceEvent(TraceEventType.Critical, 0, ex.Message);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                traceSource.Flush();
                traceSource.Close();
            }

        }

        static void TraceListeners01()
        {
            //1. Create a TraceSource
            TraceSource traceSource = new TraceSource("TraceSource1", SourceLevels.All);

            //2. clear listeners from traceSource object
            traceSource.Listeners.Clear();

            //3. create an stream
            Stream file = new FileStream("myLog.txt", FileMode.Append);

            //4. Create a listenerWriter
            TextWriterTraceListener listener = new TextWriterTraceListener(file);

            //5. Add the listener to the TraceSource
            traceSource.Listeners.Add(listener);

            //6. Very important, add Trace.AutoFlush = true, if you do not add, it is not been written
            Trace.AutoFlush = true;

            traceSource.TraceInformation("Tracing is inializating...");

            UsersEntities UsersDB = new UsersEntities();
            Users UsersRow = new Users();

            try
            {
                //Adding a Row
                UsersRow.Password = Guid.NewGuid().ToString();
                UsersRow.UserName = Guid.NewGuid().ToString();
                UsersRow.Salt = Guid.NewGuid().ToString();

                UsersDB.Users.Add(UsersRow);
                traceSource.TraceEvent(TraceEventType.Information, 0, "A new user is added");

                //Deleting A Row
                Random ran = new Random();
                int id = ran.Next(20, 50);
                var FindItemToRemove = (from user in UsersDB.Users
                                        where user.Id == id
                                        select user).FirstOrDefault();

                if (!(FindItemToRemove == null))
                {
                    UsersDB.Users.Remove(FindItemToRemove);
                    traceSource.TraceEvent(TraceEventType.Information, 1, "the user was deleted");
                }
                else
                    throw new MissingUserNameException("The User that you try to remove does not exists");
                //Updating A Row

                var FindItemToUpdate = (from user in UsersDB.Users
                                        where user.Id == 18
                                        select user).FirstOrDefault();

                FindItemToUpdate.UserName = "Updated Name";
                FindItemToUpdate.Password = "Updated Password";
                FindItemToUpdate.Salt = "Updated Salt";

                traceSource.TraceEvent(TraceEventType.Information, 2, "A user was updated");

                UsersDB.SaveChanges();
                traceSource.TraceEvent(TraceEventType.Information, 3, "Changes have been saved successfully ");

                //selecting rows

                foreach (var item in UsersDB.Users)
                {
                    Console.WriteLine("{0}  {1}  {2}  {3}", item.Id, item.UserName, item.Password, item.Salt);
                }
            }
            catch (MissingUserNameException ex)
            {
                traceSource.TraceEvent(TraceEventType.Critical, 0, ex.Message);
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                traceSource.TraceEvent(TraceEventType.Critical, 0, ex.Message);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                file.Dispose();
                traceSource.Flush();
                traceSource.Close();

            }
        }

        private static TraceSource mySource =
            new TraceSource("SampleTraceSource");

        static void UsingConfigFile()
        {
            //System.Configuration add .dll
            //ConfigurationManager.AppSettings["keyname"]

            mySource.TraceInformation("Initializing Trace Source");
            mySource.TraceEvent(TraceEventType.Critical, 1, "This is a critical log");

            mySource.Flush();
            mySource.Close();

        }

        static void EventLogTraceListenerMethod()
        {
            //EventLogTraceListener is used to get access to the Windows EventLog
            //There are three types of Logs: Application, System, or Custom log.
            // you should run vs in administrator mode
            string SourceName = "Source Name";
            string MachineName = "."; //. it is local machine
            string LogName = "Application";

            if (!EventLog.SourceExists(SourceName, MachineName))
                EventLog.CreateEventSource(SourceName, LogName);

            EventLog.WriteEntry(SourceName, "This is a message", EventLogEntryType.Information);

        }

        static void ReadingEventLog()
        {
            //this method read the last event log entry not necessarily yours

            string SourceName = "Source Name";
            string LogName = "Application";
            string MachineName = ".";

            if (!EventLog.SourceExists(SourceName, MachineName))
                EventLog.CreateEventSource(SourceName, LogName);

            EventLog eventLog = new EventLog(LogName, MachineName, SourceName);

            //get the last entry
            EventLogEntry LastEntry = eventLog.Entries[eventLog.Entries.Count - 1];

            Console.WriteLine(LastEntry.Message);
        }

        static void EventLogWithTraceSource()
        {
            string SourceName = "EventLogWithTraceSource";
            string MachineName = ".";
            string LogName = "Application";

            //1. Verify if the source exists
            if (!EventLog.SourceExists(SourceName, MachineName))
                EventLog.CreateEventSource(SourceName, LogName);

            //2. Create an instance of EventLog and set parameters
            EventLog eventLog = new EventLog();

            eventLog.MachineName = MachineName;
            eventLog.Log = LogName;
            eventLog.Source = SourceName;

            //3. Create a EventLogTraceListener instance and set as parameter the eventlog object
            EventLogTraceListener logListener = new EventLogTraceListener(eventLog);

            //4.Create a TraceSource instance
            TraceSource tracesource = new TraceSource("TraceSource", SourceLevels.All);

            //5.Clear the listeners in the TraceSource instance
            tracesource.Listeners.Clear();

            //6. Add the listener in the tracesource
            tracesource.Listeners.Add(logListener);


            tracesource.TraceInformation("The tracing is starting");
            tracesource.TraceEvent(TraceEventType.Error, 1, "There is a error");
            tracesource.TraceEvent(TraceEventType.Information, 1, "New information");
            tracesource.TraceInformation("The tracing is finishing");



            tracesource.Flush();
            tracesource.Close();

        }

        public static void ProfilingTheApplication()
        {
            //Profiling is about collect information to give a description or analyze it
            //for example how much the application consume memory, processor or how long the application last to be executed

            //you can do profiling
            //1. Using Visual Studio Tool
            //  1.1 <analyze> menu/ <Launch Performance Wizard>/ 
            //  1.2 <start windows> / run / perform (o monitor de rendimiento)
            //2. Profiling by Hand
            //  2.1 StopWatch Class
            //  2.2 PerformanceCounterCategory and PerformanceCounter with the help of monitor de rendimiento and in the <server explorer>/ <servers>/ <counter peform>




        }

        public static void ProfilingByHandStopWatch()
        {
            Stopwatch watcher = new Stopwatch();
            watcher.Start();
            Parallel.For(1, 1000000000, new Action<int>(i => { }));
            watcher.Stop();
            Console.WriteLine("The miliseconds elapsed are: {0}", watcher.ElapsedMilliseconds);

            watcher.Reset();

            watcher.Start();
            for (int i = 1; i < 1000000000; i++)
            {

            }
            watcher.Stop();
            Console.WriteLine("The miliseconds elapsed are: {0}", watcher.ElapsedMilliseconds);

        }

        public static void ProfilingByHandPerformanceCounter()
        {
            //the perform counters are a set of values updated constantly to monitor the performance

           
        }

        public static void CreatingPerformanceCounters()
        {
            //1.Verify if the category exists
            if (!PerformanceCounterCategory.Exists("myCounterCategory"))
            {
                //2. Create a counter Collection
                CounterCreationDataCollection myCounterCollection = new CounterCreationDataCollection();

                //3. Create counters and add them to the collection
                CounterCreationData myCounter01 = new CounterCreationData();
                myCounter01.CounterName = "Counter01";
                myCounter01.CounterHelp = "Total number of something done";
                myCounter01.CounterType = PerformanceCounterType.NumberOfItems32;
                myCounterCollection.Add(myCounter01);

                CounterCreationData myCounter02 = new CounterCreationData();
                myCounter02.CounterName = "Counter02";
                myCounter02.CounterHelp = "Total number of something not done";
                myCounter02.CounterType = PerformanceCounterType.NumberOfItems32;
                myCounterCollection.Add(myCounter02);


                //4. Create a new category
                PerformanceCounterCategory.Create("myCounterCategory", "Count something done and not done", myCounterCollection);

                
            }
        }

        public static void UsingCounters()
        {
            PerformanceCounter myCounter01 = new PerformanceCounter();

            myCounter01.CategoryName = "myCounterCategory";
            myCounter01.CounterName = "Counter01";
            myCounter01.MachineName = ".";
            myCounter01.ReadOnly = false;

            PerformanceCounter myCounter02 = new PerformanceCounter();

            myCounter02.CategoryName = "myCounterCategory";
            myCounter02.CounterName = "Counter02";
            myCounter02.MachineName = ".";
            myCounter02.ReadOnly = false;

            int counter01 = 20;
            int counter02 = 40;

            for (int i = 0; i < counter01; i++)
            {
                Console.WriteLine("Counter01");
                myCounter01.Increment();
            }
            for (int i = 0; i < counter02; i++)
            {
                Console.WriteLine("Counter02");
                myCounter02.Increment();
            }

            //after this step you can monitor your app. 
            //1. go to  <start windows> / run / perform (o monitor de rendimiento)
            //2. select the green plus
            //3. you will see a list of Category counters, select yours
            //4. click on <add> button
            //5. run your application 
        }

        public static void Challenge01()
        {
            string MachineName = ".";
            string LogName = "Application";
            string SourceName = "My Source";

            if (!EventLog.SourceExists(SourceName, MachineName))
                EventLog.CreateEventSource(SourceName, LogName);

            EventLog eventLog = new EventLog(LogName,MachineName,SourceName);

            try
            {
                eventLog.WriteEntry("The tracing start...");

                int divisor = 0;
                int numerator = 23;
                eventLog.WriteEntry("divisor and numerator was set successfully" + numerator.GetType() + "  " + divisor.GetType());

                Console.WriteLine("The division is {0}", numerator/divisor);
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                eventLog.WriteEntry(ex.Message,EventLogEntryType.Error);
            }
            finally
            {
                
                eventLog.Close();
                eventLog.Dispose();
            }


        }


        public static void Challenge02()
        {

        }

        class MissingUserNameException : Exception
        {
            public MissingUserNameException(string Message) : base(Message)
            {

            }
        }
    }
}
