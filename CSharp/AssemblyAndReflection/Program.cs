using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyAndReflection
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static void Assembly()
        {
            //When code is compiled, it is converted in MSIL(Microsoft Intermediate Language).
            //The CLR(Common Language Runtime) uses a JIT (Just in Time) Compiler to compile MSIL To Native Code.
            //An assembly is an code block in MSIL(Microsoft Intermediate Language) of a .Net application.
            //When compiler creates an Assembly, it creates its Metadata in the same file.
            //Metadata contains information that the assembly contains, like its types, namespaces, base class of the classes, interfaces, methods, properties etc.., IT DOES NOT CONTAINS CODE, JUST THE NAMES, TYPES ETC. 
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
            



        }
    }
}
