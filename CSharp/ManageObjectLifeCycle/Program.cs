using System;
using System.IO;
using System.Net;
namespace ManageObjectLifeCycle
{

    class student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //tryCachFinally();
            //CallDisposeInsideUsingStatement();
                    


            Challenge01();
            Console.ReadLine();
        }
        static void FundamentalsofObjectLifeCycle()
        {
            //the life cycle of an object involves the following two steps:
            //  1.Creation of an Object
            //  2.Deletion of an Object

            //Creation of an Object
            //  new keyword is used to instantiate a new object.
            //  A block of memory is allocated. This block of memory is big enough to hold the object (CLR handles the
            //  allocation of memory for managed objects).

            //Deletion of an Object
            //  destruction is used to reclaim any resources used by that object.

            //With Garbage Collection, the CLR handles the release of memory used by managed objects; however,
            //if we use unmanaged objects, we may need to manually release the memory by implementing IDisposable

            //When Garbage Collection Run
            //  1.When the system runs out of physical memory.
            //  2.When the GC.Collect method is called manually.
            //  3.When allocated objects in memory need more space.

            //Garbage Collector and Managed Heap
            //  Garbage collector calls a win32 VirtualAlloc method to reserve a segment of memory in managed heap.
            //  When garbage collector needs to release a segment of memory, it calls a win32 VirtualFree method.
            // KeepAlive() method You need to ensure that the garbage collector does not release the object's resources until the process completes.


            //Managed heap organizes objects into generations.

            //Generations

            //  There are three generations:
            //      Generation 0
            //          When an object is allocated on heap, it belongs to generation 0.
            //          If newly allocated objects are larger in size, they will go on the large object heap in a generation 2 collection.
            //          Temporary and newly allocated objects are moved into generation 0.
            //      Generation 1
            //          When objects survive from a garbage collection of generation 0, they go to generation 1.                        
            //      Generation 2
            //          When objects survive from a garbage collection of generation 1, they go to generation 2. If objects still survived in generation 2, they remain in generation 2  till they're alive.
            //          Generation 2 is a place where long-lived objects are compacted.


            // Steps Involved in Garbage Collection
            //      1.Suspend all managed threads except for the thread that triggered the garbage collection.
            //      2.Find a list of all live objects.
            //      3.Remove dead objects and reclaim their memory.
            //      4.Compact the survived objects and promote them to an older generation.

            //Manage Unmanaged Resource
            //      Implement IDisposable to Release Unmanaged Resource
            //          Types that use unmanaged resources must implement IDisposable to reclaim the unmanaged memory.
            //          Dispose method is used to release the unmanaged resource from the memory.
            //          To prevent garbage collector from calling an object's finalizer (Destructor), dispose method uses GC.SuppressFinalize method.

            //Dispose method can be called by following two ways:
            //1. try/finally block
            //2. using statement

            //Disposable Pattern
            //  Disposable pattern is a standard way to implement IDisposable interface.

            //Memory Leaks

            //      If an application doesn't free the allocated resource on memory after it is finished using it, it will create a
            //      memory leak because the same allocated memory is not being used by the application anymore.
            //      If memory leaks aren't managed properly, the system will eventually run out of memory; consequently,
            //      the system starts giving a slow response time and the user isn’t able to close the application. The only trick is
            //      to reboot the computer, period.

            //1.Holding references to managed objects for a long time.
            //      If a managed object's references stay longer than necessary, performance counters can show a steady
            //      increase in memory consumption and an OutOfMemoryException may arise.This may happen due to a
            //      variable global scope, because GC can't destroy an active variable even though it’s not being used by an
            //      application anymore.
            //      The developer needs to handle it by telling how long a variable can hold a reference and destroying it
            //      after it is no longer needed.
            //2.Unable to manage unmanaged resource.
            //      Garbage collector cannot release the memory of unmanaged resource.The developer needs to explicitly
            //      release resources of unmanaged resources. To do that, the developer needs to implement an IDisposable
            //      interface on types which use unmanage resource.Otherwise, memory leaks occur.
            //3.Static reference.
            //      If an object is referenced by a static field, then it will never be released.Such objects become long-lived.The
            //      developer needs to make sure unnecessary static field objects get destroyed when they're finished being
            //      used by the application.
            //4.Event with missing unsubscription.
            //      If an event handler is subscribed (+=), the publisher of the event holds a reference to the subscriber via the
            //      event handler delegate (assuming the delegate is an instance method). If the publisher lives longer than the
            //      subscriber, then it will keep the subscriber alive even when there are no other references to the subscriber.
            //      This is the cause of memory leak when unsubscription of an event isn't defined.
            //      If the developer unsubscribes (-=) from the event with an equal handler, it will remove the handler and
            //      manage memory leaks.

        }
        static void Challenge01()
        {
            string httpUrl = "http://www.google.com";
            Client client = new Client(httpUrl);

            Console.WriteLine("the http code is of {0} is {1}", httpUrl, client.httpString);

            client.Dispose();
        }
        static void tryCachFinally()
        {
            myClass class01 = null;
            try
            {
               
                class01 = new myClass();
             }
       
            finally
            {
                class01.Dispose();
            }
        }
        static void CallDisposeInsideUsingStatement()
        {
            using(myClass c = new myClass())
            {

            }

            Console.WriteLine("End");
        }
    }

    class patternClass: IDisposable
    {
        Stream file;
        bool disposed= false;

       
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                if(!(file == null))
                    file.Dispose();
            }

            disposed = true;

        }
        ~patternClass(){
            Dispose(false);
        }

    }
        
    class Client: IDisposable
    {
        bool disposed = false;
        WebClient client;
        public string httpString { get; set; }

        public Client(string url)
        {
            client = new WebClient();
            httpString = client.DownloadString(url);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
               if (!(client == null))
                    client.Dispose();

            disposed = false;

        }

        ~Client()
        {
            Dispose(false);
        }
    }

    class myClass: IDisposable
    {
        public Stream reader;

        public void Dispose()
        {
            if (!(reader == null))
            {
                reader.Dispose();
            }
            GC.SuppressFinalize(this);
            Console.WriteLine("Disposed");
        }
        
    }
}
