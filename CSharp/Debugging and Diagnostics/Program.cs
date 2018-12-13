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
            TraceClass1();
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
                
                Debug.WriteLineIf(File.Exists(FileName),"The File allready Exists");
                
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
            catch(Exception ex)
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
            TraceSource ts = new TraceSource("TraceSource1", SourceLevels.All);
            ts.TraceInformation("Tracing the application..");
            ts.TraceEvent(TraceEventType.Error, 0, "Error trace Event");
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

    }
}
