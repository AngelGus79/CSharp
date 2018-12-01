using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
namespace FileIOOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            //DriveInfoClass();
            //DirectoryClass();
            //DirectoryInfoClass();
            //FileClass();
            //FileInfoClass();
            //FileStreamClass();
            //MemoryStream();
            //BufferedStreamClass();
            //FileReaderAndWriter();
            //BinaryReaderAndBinaryWriter();
            //StreamReaderAndStreamWriter();
            //CommunicationOverTheNetwork();
            //AsyncAndAwaitFileIO();
            challenge01();
            Console.ReadLine();
        }

        static void DriveInfoClass()
        {
            
            //Access to a specific drive
            DriveInfo d = new DriveInfo(@"C:\");
            
            
            //Get all the drives
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (var drive in drives)
            {
                try
                {
                    Console.WriteLine("Name: {0}", drive.Name);
                    Console.WriteLine("Type: {0}", drive.DriveType);
                    Console.WriteLine("Free space: {0}", drive.TotalFreeSpace);
                    Console.WriteLine("Size: {0}", drive.TotalSize);
                    Console.WriteLine("Available free space: {0}", drive.AvailableFreeSpace);
                    Console.WriteLine("Drive Formal: {0}", drive.DriveFormat);
                    Console.WriteLine("Volumen Label: {0}", drive.VolumeLabel);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.GetType());
                }
                finally
                {
                    Console.WriteLine();
                }
                
            }




        }

        static void DirectoryClass()
        {
            //you can create a new directory with the static method CreateDirectory
            //it is recommended if you just need to create a directory.
            //in this case, the directory would be creater in the current path

            DirectoryInfo directory = Directory.CreateDirectory(@"Directory.CreateDirectory");

            //you can also create a directory without return anything
            //Directory.CreateDirectory(@"Directory.CreateDirectory"); 

            //To verify that the directory exists
            if (Directory.Exists(@"Directory.CreateDirectory"))
            {
                Console.WriteLine("The Directory allready exists");
                Directory.Delete(@"Directory.CreateDirectory");
            }

            //another way to verify if it exists, with the directory object
            if (directory.Exists)
            {
                Console.WriteLine("The Directory allready exists, with the directory object");

            }
        }
            
        static void DirectoryInfoClass()
        {
            DirectoryInfo directory = new DirectoryInfo(@"DirectoryInfo");
            directory.Create();

            //Creating a subdirectory level 1
            DirectoryInfo FolLevel1 = directory.CreateSubdirectory(@"FolLevel1");

            //Creating a subdirectory level 2
            DirectoryInfo FolLevel2 = FolLevel1.CreateSubdirectory(@"FolLevel2");

            //Lazy Loading or Deferred Execution directory.EnumerateDirectories()
            foreach (DirectoryInfo dir in directory.EnumerateDirectories())
            {
                Console.WriteLine(dir.Name);

                
            }

            if (Directory.Exists(@"..\Moved FolLevel2"))
            {
                FolLevel2.Delete();
            }
            else
            {
                FolLevel2.MoveTo(@"..\Moved FolLevel2");
            }

            if (directory.Exists)
            {

                Console.WriteLine("the Directory {0} allready exists", directory.Name);
                try
                {
                    //throw a exception because the folder has content
                    directory.Delete();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Message: {0}", ex.Message);
                }
            }

            //To delete the folder with content
            directory.Delete(true);
            Console.WriteLine("The folder {0} was deleted successfully", directory.Name);
        }

        static void FileClass()
        {

            //Create a file
            //After the creation of the file, it must be closed
            File.Create("sample.txt").Close();

            //Writting a content
            string content = "Hello this is a content with the File class";
            File.WriteAllText("sample.txt", content);

            //Reading the file
            string readContent = File.ReadAllText("sample.txt");
            Console.WriteLine(readContent);

            //deleting a file
            if (File.Exists(@"..\sample.txt"))
            {
                File.Delete(@"..\sample.txt");
            }

            //Moving the file
            File.Move(@"sample.txt", @"..\sample.txt");

            //copying file
            File.Copy(@"..\sample.txt", @"sample.txt");


            if (File.Exists(@"..\sample.txt"))
            {
                File.Delete(@"..\sample.txt");
            }

            if (File.Exists(@"sample.txt"))
            {
                File.Delete(@"sample.txt");
            }

            //create many files in the current path

            for(int i = 0; i<10; i++)
            {
                File.Create("sample" + i + ".txt").Close();
                File.WriteAllText("sample" + i + ".txt", "Hello this is the content of the sample"+i+".txt");
            }

            string[] FileNames = Directory.GetFiles(Directory.GetCurrentDirectory());

            foreach(var f in FileNames)
            {
                Console.WriteLine(f);
            }

            for (int i = 0; i < 10; i++)
            {
                File.Delete("sample" + i + ".txt");
            }

            Console.WriteLine("The process has finished");
        }

        static void FileInfoClass()
        {
            FileInfo file = new FileInfo("sample1.txt");
            file.Create().Close();

            using(StreamWriter sw = file.AppendText())
            {
                sw.WriteLine("tittle");
                sw.WriteLine("Line 1");
                sw.WriteLine("Line 2");

            }
            
            using (StreamReader fs = file.OpenText())
            {
                string s;
                while ((s = fs.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }

            file.CopyTo(@"..\Moved FolLevel2\sample1.txt");

            if (file.Exists)
            {
                file.Delete();
            }
        }

        static void stream()
        {
            //            Stream is an abstract class used for writing and reading bytes.It is for File I/O operations. A file is stored on your computer HD
            //in a sequence of bytes also a file is transferred in the form of a sequence
            //of bytes and in memory the information is stored in the form of a sequence of bytes.
            //Stream has three main tasks:
            //1. Writing: Writing means to convert the object or data into bytes and then store it in memory or a file, or it can be sent across the network.
            //2. Reading: Reading means to read the bytes and convert them into something meaningful, such as Text, or to deserialize them into an object.
            //3. Seeking: It is the concept of query for the current position of a cursor and
            //moving it around. Seeking is not supported by all the streams, i.e., you cannot
            //move forward or backward in a stream of bytes that is being sent over a network.

            //types of Stream:
            //1.FileStream
            //2.MemoryStream
            //3.BufferedStream
            //4.NetwrokStream
            //5.CryptoStream

        }

        static void FileStreamClass()
        {
            FileStream file = File.Create("myFileStream.txt");
            string content = "hello this is my content";
            byte[] bytes = Encoding.UTF8.GetBytes(content);
            file.Write(bytes, 0, bytes.Length);
            
            file.Close();

            //File_Name File_Name is the name of a file on which an operation will perform.
            //FileMode FileMode is an enumeration that gives a different method to open the file:
            //            1.Append: It Creates the file if the file does not exist and, if it exists, it puts the cursor at the end of the file.
            //            2.Create: Creates a new file and, if the file already exists, it will override it.
            //            3. CreateNew: Creates a new file and, if the file already exists, it will throw an exception.
            //            4. Open: Opens the file.
            //            5. OpenOrCreate: Opens the existing file; if it’s not found, then it creates a new one.
            //            6. Truncate: opens the existing file and truncates its size to zero bytes.
            //FileAccess FileAccess is an enumeration that gives a different method to access a file:
            //            1. Read: tells the file has just read access.
            //            2. ReadWrite: tells the file has read and write access.
            //            3. Write: tells the file has just write access.
            //FileShare FileShare is an enumetation that gives different methods:
            //            1. Delete: Allows subsequent deleting of a file.
            //            2. Inheritable: Allows the file to handle child process inheritance.
            //            3. None: Stops to share the file.File must be closed before access by another process.
            //            4. Read: Allows file for reading.
            //            5. ReadWrite: Allows file for reading and writing.
            //            6. Write: Allows file to write.

            FileStream myFile = new FileStream(@"..\Moved FolLevel2\sample2.txt", FileMode.Create, FileAccess.Write, FileShare.Write);

            string strcontent = "Hello this is the content";

            byte[] mybytes = Encoding.UTF8.GetBytes(strcontent);

            myFile.Write(mybytes, 0, mybytes.Length);

            myFile.Close();

            

        }

        static void MemoryStream()
        {
            MemoryStream memory = new System.IO.MemoryStream();

            //write in the memory
            string content = "Hello, this message is a stream in the memory";
            byte[] bytes = Encoding.UTF8.GetBytes(content);
            memory.Write(bytes, 0, bytes.Length);




            //Set the position to the begninig of stream
            memory.Seek(0,SeekOrigin.Begin);
            
            //Create an byte array to retrieve the memory bytes
            byte[] bytesToRead = new byte[memory.Length];
            
            int count = memory.Read(bytesToRead, 0, bytesToRead.Length);
            //bytesToRead. When this method returns, contains the specified byte array with the values between offset and(offset +count - 1) replaced by the characters read from the current stream.
            //count. The total number of bytes written into the buffer.This can be less than the number of bytes requested if that number of bytes are not currently available, or zero if the end of the stream is reached before any bytes are read.

            for (int i = count; i < memory.Length; i++)
            {
                bytesToRead[i] = Convert.ToByte(memory.ReadByte());
            }


            string message = Encoding.UTF8.GetString(bytesToRead);

            Console.WriteLine(message);

        }

        static void BufferedStreamClass()
        {
           // Buffer is a block of bytes in memory used to cache the data. BufferedStream needs stream to be buffered.
           //Listing 10 - 11 shows how you can write and read from Buffer using BufferStream.

              FileStream file = File.Create("sample2.txt");
            BufferedStream buffered = new BufferedStream(file);

            string content = "this is a buffered stream message";
            byte[] bytes = Encoding.UTF8.GetBytes(content);
            buffered.Write(bytes, 0, bytes.Length);

            //very important
            buffered.Seek(0, SeekOrigin.Begin);
            byte[] bytesToRead = new byte[buffered.Length];
            int TotalReadBytes = buffered.Read(bytesToRead, 0, bytesToRead.Length);

            for(int i = TotalReadBytes; i<buffered.Length; i++)
            {
                bytesToRead[i] = Convert.ToByte(buffered.ReadByte());
            }

            string RetrievedBytes = Encoding.UTF8.GetString(bytesToRead);

            Console.WriteLine(RetrievedBytes);




        }

        static void FileReaderAndWriter()
        {
            //     To convert bytes into readable form or to write or read values as bytes or as string, .NET offers the following classes in such a case. For those purposes, we have:
            //1.StringRead and StringWriter
            //2.BinaryReader and BinaryWriter
            //3.StreamReader and StreamWriter

            //            StringReader and StringWriter
            //These classes are used to read and write characters to and from the string.Listing 10 - 12 shows the use of
            //StringReader and StringWriter.

            StringWriter writer = new StringWriter();
            writer.Write("Hello ");
            writer.WriteLine("again hello");
            writer.Write("this hello in a new line");
            Console.WriteLine(writer.ToString());

            //just read one line from the writer
            StringReader reader = new StringReader(writer.ToString());
            Console.WriteLine(reader.ReadLine());
        }

        static void BinaryReaderAndBinaryWriter()
        {
            FileStream file = File.Create("sample.dat");
            BinaryWriter writer = new BinaryWriter(file);
            
            writer.Write("hello");
            writer.Write(3);
            writer.Write(true);
            writer.Close();

            FileStream fileToOpen = File.Open("sample.dat",FileMode.Open);
            BinaryReader reader = new BinaryReader(fileToOpen);
            Console.WriteLine(reader.ReadString());
            Console.WriteLine(reader.ReadInt32());
            Console.WriteLine(reader.ReadBoolean());
            

        }

        static void StreamReaderAndStreamWriter()
        {
            //StreamWriter writes character(s) to the stream.
            //StreamReader reads bytes or string. 
            StreamWriter writer = new StreamWriter("sample3.txt");
            writer.WriteLine("Hello");
            writer.Write('A');
            writer.Close();
            

            StreamReader reader = new StreamReader("sample3.txt");
            Console.WriteLine(reader.ReadLine());
            Console.WriteLine(reader.ReadLine());
            reader.Close();
        }

        static void CommunicationOverTheNetwork()
        {
            //it is possible to comunicate over the network. The namespace System.Net provide classes to do it
            //WebRequest (which send a request) and WebResponse (get the response) are the most common classes
            //you can find implementations about the some protocols to communicate like HttpWebRequest and HttpWebResponse class

            WebRequest request = WebRequest.Create(@"http://www.google.com");
            WebResponse response = request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string content =reader.ReadToEnd();

            Console.WriteLine(content);
            response.Close();


        }

        static async void AsyncAndAwaitFileIO()
        {
            FileStream file = File.Create("sample5.txt");
            StreamWriter writer = new StreamWriter(file);

            await writer.WriteAsync("hello this is a async write message");
            writer.Close();

            FileStream fileToOpen = File.Open("sample5.txt",FileMode.Open);
            StreamReader reader = new StreamReader(fileToOpen);
            string content = await reader.ReadToEndAsync();
            reader.Close();
            Console.WriteLine(content);
            ;


        }

        static async void challenge01()
        {

            WebRequest request = WebRequest.Create("https://i.blogs.es/dcc721/url1/450_1000.jpg");
            WebResponse response = await request.GetResponseAsync();

            BinaryReader reader = new BinaryReader(response.GetResponseStream());
            
            

            long length = response.ContentLength;
            byte[] bytes = new byte[length];

            bytes = reader.ReadBytes((Int32)length);
            reader.Close();

            FileStream file = File.Create("ImageData");
            await file.WriteAsync(bytes, 0, (Int32)length);

            file.Close();
            response.Close();

            //read the file
            FileStream FileToRead = File.Open("ImageData",FileMode.Open);
            BinaryReader readerBin = new BinaryReader(FileToRead);

            //save in a new file
            FileStream FileToWrite = File.Create("Image.jpg");
            await FileToWrite.WriteAsync(readerBin.ReadBytes((int)length), 0, (int)length);

            FileToWrite.Close();
            FileToRead.Close();

        }
    }
}
