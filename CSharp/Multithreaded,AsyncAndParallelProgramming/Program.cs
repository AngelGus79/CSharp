using System;
using System.Threading;
namespace Multithreaded_AsyncAndParallelProgramming
{
    class Program
    {
        static void Main(string[] args)
        {

            //ThreadStart();
            //ThreadJoin();
            //ForegroundThread();
            //BackGroundThread(); //in this case application is terminated before mythread has been compleated
            //parametrizedThreadStart();
            //Sleepthread();
            priorityProperty();
            Console.ReadLine();

        }
        static bool stop;
        static void priorityProperty()
        {
            Thread myThread1 = new Thread(new ThreadStart(myPriorityMethod));
            Thread myThread2 = new Thread(new ThreadStart(myPriorityMethod));
            Thread myThread3 = new Thread(new ThreadStart(myPriorityMethod));
            stop = true;

            myThread1.Name = "thread 1";
            myThread1.Priority = System.Threading.ThreadPriority.Lowest;

            myThread2.Name = "thread 2";
            myThread2.Priority = System.Threading.ThreadPriority.Normal;

            myThread3.Name = "thread 3";
            myThread3.Priority = System.Threading.ThreadPriority.Highest;


            myThread1.Start();
            myThread2.Start();
            myThread3.Start();
            Thread.Sleep(20000);

            stop = false;
            Console.WriteLine("Hello main thread");
        }
        static void Sleepthread()
        {
            Thread myThread = new Thread(new ThreadStart(mySleepMethod));
            myThread.Start();
            myThread.Join();
            Console.WriteLine("hello my main method");
        
        }
        static void parametrizedThreadStart()
        {
            Thread myThread = new Thread(new ParameterizedThreadStart(myParametrizedMethod));
            myThread.Start(10);
            Console.WriteLine("hello main thread");
        }
        static void BackGroundThread()
        {
            Thread myThread = new Thread(WorkingwithThreads);
            myThread.IsBackground = true;
            Console.WriteLine("Hello main thread");
        }
        static void ForegroundThread()
        {
            Thread MyThread = new Thread(new ThreadStart(WorkingwithThreads));
            //by default the property is inicialized in false.
            MyThread.IsBackground = false;
            MyThread.Start();
            Console.WriteLine("Hello Main thread");
        }
        static void ThreadJoin()
        {
            Thread myThread = new Thread(WorkingwithThreads);

            myThread.Start();
            //MainThread wait until mythread is terminated
            myThread.Join();

            Console.WriteLine("Hello MainThread");
        }
        static void ThreadStart()
        {
            Console.Clear();
            Thread mythread = new Thread(new ThreadStart(WorkingwithThreads));
            // Thread mythread = new Thread(WorkingwithThreads); other way to instantiate

            //Start the execution of thread
            mythread.Start();

            //It's the part of Main Method
            Console.WriteLine("Hello MainThread");
        }
        public static void WorkingwithThreads()
        {
            //A thread controls the flow of an executable program. By default, a program has one thread called Main Thread.
            //If the execution of a program is controlled by more than one thread, it’s called a Multithreaded Application.

            /*
                        states of the thread
            State                   Explanation
            Unstarted       Thread is created but not started yet
            Running         Thread is executing a program
            WaitSleepJoin   Thread is blocked due to Wait, Sleep or Join method
            Suspended       Thread is suspended
            Stopped         Thread is stopped, either normally or aborted
            
            Methods & properties of the thread class
            Methods & Properties            Explanation
            Start()                         Changes state of thread to Running
            Join()                          Wait for finishing a thread before executing calling thread
            Sleep()                         Suspend a thread for specified number of miliseconds
            Resume()                        Resume the execution of suspended thread
            Abort()                         Terminates the execution of a thread
            CurrentThread                   Returns a reference of the current thread
            IsAlive                         Returns true if thread has not been terminated or aborted
            IsBackground                    Get or set to indicate a thread is or is not a background thread
            Name                            Get or set name of a thread
            ThreadState                     Returns the current state of thread
            */

            Console.WriteLine("hello thread");
            for(int i = 0; i<10; i++)
            {
                Console.Write("{0} ", i);
            }

            Console.WriteLine("\nbye thread");
        }

        static void myParametrizedMethod(object number)
        {
            Console.WriteLine("hello thread");
            int num = (int)number;
            for(int i= 0; i<num; i++)
            {
                Console.Write("{0} ",i);
            }
            Console.WriteLine("\nbye thread");

        }

        public static void mySleepMethod()
        {

            Console.WriteLine("hello thread");
            for (int i= 0; i < 10; i++)
            {
                Console.Write("{0:D2} ", i);
            }
            Thread.Sleep(10000);
            Console.WriteLine("\nbye thread");
        }

        public static void ThreadPriority()
        {
            /*
             Threadpriority defines how much CPU time a thread will have for execution. When a thread is created,
             initially it is assigned with Normal priority.

            Priority        Explanation
            High            Thread will schedule before threads with any priority
            AboveNormal     Thread will schedule before Threads with Normal priority
            Normal          Will schedule before Threads with BelowNormal priority
            BelowNormal     Thread will schedule before Threads with Lowest priority
            Lowest          Will schedule after Threads with BelowNormal priority
             */
        }

        static void myPriorityMethod()
        {
            string name = Thread.CurrentThread.Name.ToString();
            string priority = Thread.CurrentThread.Priority.ToString();

            uint count = 0;
            while (stop)
            {
                count += 1;
            }

            Console.WriteLine("the thread {0} with priority {1} got {2} numbers", name, priority, count);

        }
        public static void ForegroundAndBackgroundThread()
        {
            /* There are two kinds of threads; Foreground thread and Background thread. By default,
   all threads are initialized as foreground thread. An application cannot terminate its execution until all its
   foreground threads are completed. In the other hand if a background thread has not compleated its execution and and the Main thread is compleated, the Main Thread will terminate the application and not wait for the background thread to
   be completed. 

    */
        }
    }
}
