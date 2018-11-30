using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace FileIOOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            DriveClass();
            Console.ReadLine();
        }

        static void DriveClass()
        {
            DriveInfo drive = new DriveInfo(@"C:\");
            Console.WriteLine("Name: {0}",drive.Name);
            Console.WriteLine("Type: {0}", drive.DriveType);
            Console.WriteLine("Free space: {0}", drive.TotalFreeSpace);
            Console.WriteLine("Size: {0}", drive.TotalSize);
            Console.WriteLine("Available free space: {0}", drive.AvailableFreeSpace);
            Console.WriteLine("Drive Formal: {0}", drive.DriveFormat);
            Console.WriteLine("Volumen Label: {0}", drive.VolumeLabel);
        }
        static void DriveInfoClass()
        {

        }

        static void DirectoryClass()
        {
            DirectoryInfo directory = Directory.CreateDirectory(@"C:/");
        }
        static void DirectoryInfoClass()
        {

        }
    }
}
