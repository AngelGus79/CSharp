using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
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
            //priorityProperty();
            //ThreadStatic();
            //myThreadPool();
            //myTasks();
            //FactoryStartNew();
            //TaskRun();
            //TaskRunLamda();
            //myTaskFunc();
            //MyTaskFuncFactoryStartNew();
            //MyTaskFuncRun();
            //MyTaskFuncLamda();
            //TaskWait();
            //TaskAll();
            //AnyTask();
            //ChainMultipleTasksWithContinuationsFunc();
            //ContinuationOptions();
            //NestedTask();
            //ChildTask();
            //SynchronizationOfVariablesInMultithreading();
            //SynchronizationOfVariablesMonitor();
            //SynchronizationOfVariablesInterLocked();
            //DeadLock();
            //CancellationToken();
            //ConcurrentCollection();
            //ParallelFor_ParallelForeach();
            PLINQ();
            Console.ReadLine();

            

        }

        static void myTasks()
        {
            //Task doesn’t create new threads.Instead it efficiently manages the threads of a
            //threadpool.Tasks are executed by TaskScheduler, which queues tasks onto threads.
            //Task provides the following powerful features over thread and threadpool.
            //1.Task allows you to return a result.
            //2.It gives better programmatical control to run and wait for a task.
            //3.It reduces the switching time among multiple threads.
            //4.It gives the ability to chain multiple tasks together and it can execute each task
            //one after the other by using ContinueWith().
            //5.It can create a parent/ child relationship when one task is started from
            //another task.
            //6.Task can cancel its execution by using cancellation tokens.
            //7.Task leaves the CLR from the overhead of creating more threads; instead it
            //implicitly uses the thread from threadpool.
            //8.Asynchronous implementation is easy in task, by using “async” and “await”
            //keywords.
            //9.Task waits for all of the provided Task objects to complete execution.


            //            Methods & Properties Explanation
            //Run()             Returns a Task that queues the work to run on ThreadPool
            //Start()           Starts a Task
            //Wait()            Wait for the specified task to complete its execution
            //WaitAll()         Wait for all provided task objects to complete execution
            //WaitAny()         Wait for any provided task objects to complete execution
            //ContinueWith()    Create a chain of tasks that run one after another
            //Status            Get the status of current task
            //IsCanceled        Get a bool value to determine if a task is canceled
            //IsCompleted       Get a bool value to determine if a task is completed
            //IsFaulted         Gets if the Task is completed due to an unhandled exception.
            //Factory           Provide factory method to create and configure a Task
            Task myTask = new Task(new Action(myTaskMethod));
            myTask.Start();
            myTask.Wait();
        }
        static void FactoryStartNew()
        {
            //In the net framework 4.0 the more efficient way to create a task is with Factory.StartNew
            Task myTask = Task.Factory.StartNew(new Action(myTaskMethod));
            myTask.Wait();

        }
        static void TaskRun()
        {
            //In the 4.5 netFramework the more efficient way to create a task is in Task.Run
            Task myTask = Task.Run(new Action(myTaskMethod));
            myTask.Wait();

        }
        static void TaskRunLamda()
        {
            Task myTask = Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("{0}", i);
                }
            });

            myTask.Wait();

            Console.WriteLine("Hello my main Thread");
        }
        static void myTaskMethod()
        {
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0}",i);
            }
        }

        static void myTaskFunc()
        {
            Task<int> myTask = new Task<int>(myTaskFuncMethod);

            myTask.Start();
            int i = myTask.Result;

            Console.WriteLine("Hello my main Thread {0}", i);
        }
        static void MyTaskFuncFactoryStartNew()
        {
            //in the 4.0 version .net framework Task<Tresult>.Factory.StartNew is more efficient than Start() method
            Task<int> myTask = Task<int>.Factory.StartNew(new Func<int>(myTaskFuncMethod));
            int i = myTask.Result;
            Console.WriteLine("hello my main thread the result is {0}", i);
        }
        static void MyTaskFuncRun()
        {
            Task<int> myTask = Task.Run<int>(new Func<int>(myTaskFuncMethod));

            int i = myTask.Result;
            Console.WriteLine("Hello my main Thread the result is {0}",i);
        }
        static void MyTaskFuncLamda()
        {
            var myTask = Task.Run<int>(() =>
            { //it knows that must return a value due to Task<int>.Run
                return 10;
            });

            var myTask2 = Task.Run(() =>
            {
                return 9; ////it knows that must return a value due to return
            });

            int i = myTask.Result;
            int j = myTask2.Result;

            Console.WriteLine("Hello my Task 1 return {0}",i);
            Console.WriteLine("Hello my Task 2 return {0}", j);


        }


        static int myTaskFuncMethod()
        {
            Console.WriteLine("My Task");
            return 10;
        }
        

        static bool stop;

        //with ThreadStatic each thread takes its own local static variable count
        [ThreadStatic]
        static int count = 0;
        //To share the static count variable just remove the ThreadStatic attribute

        static void ThreadStatic()
        {
            Thread myThread1 = new Thread(() =>
            {
                string Name = Thread.CurrentThread.Name.ToString();
                string Priority = Thread.CurrentThread.Priority.ToString();
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("This is thread {0} with {1} priority: {2}", Name, Priority, count++);
                }
                
            });

            Thread myThread2 = new Thread(() =>
           {
               string Name = Thread.CurrentThread.Name.ToString();
               string Priority = Thread.CurrentThread.Priority.ToString();
               for (int i = 0; i < 10; i++)
               {
                   Console.WriteLine("This is thread {0} with {1} priority: {2}", Name, Priority, count++);
               }
           });

            myThread1.Name = "Thread 1";
            myThread2.Name = "Thread 2";

            myThread1.Start();
            myThread2.Start();

            myThread1 = new Thread(() =>
            {

                Console.WriteLine("hello");
            });

            myThread1.Start();
        }

        static void myThreadPool()
        {
            //The cost of instantiating a managed thread is higher than reusing a free thread. In.NET, a thread pool is
            //helpful to reuse the free threads. A thread pool is a collection of background threads created by a system
            //and are available to perform any task when required.


            //.NET has implemented its own definition of thread pool through the ThreadPool class. It has a method,
            //QueueUserWorkItem, which helps to queue the execution of available threads in a thread pool.

            //Limitation of Thread Pool
            //• It is hard to tell when a thread of a threadpool has finished its execution.
            //• There is no “Start” method, so we cannot tell when a thread of a thread pool has
            //started its execution because it is being managed by the system.
            //• It can’t manage a thread which returns a value.

            //the method has to have an parameter of object type, for the state of the info
            ThreadPool.QueueUserWorkItem(new WaitCallback(WorkingwithThreadsPool));

        }
        
        static void WorkingwithThreadsPool(object state)
        {
            //string name = Thread.CurrentThread.Name.ToString(); not work
            //string priority = Thread.CurrentThread.Priority.ToString(); not work
            for(int i = 0;i<10; i++)
            {
                Console.WriteLine("number {0}", i);
            }
        }
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

        static void TaskWait()
        {
            Task myTask1 = Task.Run(() =>
            {
                Thread.Sleep(500);
                Console.WriteLine("Hello Task 1");

            });

            Task myTask2 = Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Hello Task 2");
            });

            Task myTask3 = Task.Run(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine("Hello Task3");
            });

            myTask3.Wait(); //block the manin thread until task3 finishes.
            Console.WriteLine("Main Thread first");

            myTask1.Wait(1000); // wait until either task1 finishes or time elapsed, after that continue with the calling thread but the task does not stop.
            Console.WriteLine("Main Thread second");

            myTask2.Wait(1000);
            Console.WriteLine("Main Thread third");
        }

        static void TaskAll()
        {
            Task myTask1 = Task.Run(() =>
            {
                Thread.Sleep(1500);
                Console.WriteLine("Task 1");
            });

            Task myTask2 = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Task 2");
            });

            Task myTask3 = Task.Run(() =>
            {
                Thread.Sleep(500);
                Console.WriteLine("Thread 3");
            });

            Task[] allTasks = { myTask1, myTask2, myTask3 };

           // Task.WaitAll(allTasks);
           // Console.WriteLine("Hello Main thread, Wait while all tasks finish");

            Task.WaitAll(allTasks,1000); //if time is elapsed the remainig tasks DO NOT ABORT, just continue the calling thread
            Console.WriteLine("Hello Main Thread, Wait while either all task finish or time be elapsed");
        }
        static void AnyTask()
        {
            Task myTask1 = Task.Run(() =>
            {
                Thread.Sleep(1500);
                Console.WriteLine("Task 1");
            });

            Task myTask2 = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Task 2");
            });

            Task myTask3 = Task.Run(() =>
            {
                Thread.Sleep(500);
                Console.WriteLine("Task 3");
            });

            Task[] Tasks = { myTask1, myTask2, myTask3 };

            //Task.WaitAny(Tasks); //wait until the first task finish after that continue with the main thread but DOES NOT stop the remaining tasks

            Task.WaitAny(Tasks, 500); //wait until either the first task finish or the time is elapsed
            Console.WriteLine("Hello Main Thread");

        }

        static void ChainMultipleTasksWithContinuations()
        {
            //Task.ContinueWith method is used to make chains of multiple tasks.Each next task in a chain will not be
            //scheduled for execution until the current task has completed successfully, faulted due to an unhandled
            //exception, or exited out early due to being canceled.


            //            TaskContinuationOption
            //TaskContinuationOption is an enumeration that is used to specify when a task in a continuewith chain gets
            //executed.The following are some of the most commong enums for TaskContinuationOption:
            //• OnlyOnFaulted Specifies that the continuation task should be scheduled only if its
            //antecedent threw an unhandled exception.
            //• NotOnFaulted Specifies that the continuation task should be scheduled if its
            //antecedent doesn't throw an unhandled exception.
            //• OnlyOnCanceled Specifies that the continuation should be scheduled only if
            //its antecedent was canceled.A task is canceled if its Task.Status property upon
            //completion is TaskStatus.Canceled.
            //• NotOnCanceled Specifies that the continuation task should be scheduled if its
            //antecedent was not canceled.
            //• OnlyOnRanToCompletion Specifies that the continuation task should be scheduled
            //if its antecedent ran to completion.
            //• NotOnRanToCompletion Specifies that the continuation task should be scheduled
            //if its antecedent doesn't run to completion.


            Task myTask1 = Task.Run(() =>
            {
                Console.WriteLine("Task 1");


            });

            Task myTask2 = myTask1.ContinueWith((t) =>
            {
                Console.WriteLine("Task 2");
            });

            //Task 2 is executed after Task 1
            myTask2.Wait();
        }
        
        static void ChainMultipleTasksWithContinuationsFunc()
        {
            var myTask1  = Task.Run(() =>
            {
                Console.Write("Write a Name: ");
                string Name = Console.ReadLine();
                return Name;
            });


            var myTask2 = myTask1.ContinueWith((t) =>
            {
                Console.WriteLine("The Name is: {0}", t.Result);
            });

            myTask2.Wait();
        }

        static void ContinuationOptions()
        {
            //TaskContinuationOptions is a enumeration to control when a task continues in a Task.ContinueWith method
            Task myTask1 = Task.Run(() =>
            {
                Console.WriteLine("Task 1");
                throw new Exception();
                
            });

            Task myTask2 = myTask1.ContinueWith((t) =>
            {
                Console.WriteLine("Task 2");
            },TaskContinuationOptions.OnlyOnRanToCompletion);

            myTask2.Wait();
        }

        static void NestedTask()
        {
            //A nested task is just a Task instance that is created in the user delegate of another task.
            //The outer task DO NOT wait that inner tasks terminate their execution 
            Task myTask1 = Task.Run(() =>
            {
                Console.WriteLine("Hello Task 1");

                Task myTask2 = Task.Run(() =>
                {
                    Console.WriteLine("Hello Task 2");
                    Thread.Sleep(1000);
                    Console.WriteLine("Bye Task 2");
                    
                });
               
                Console.WriteLine("Bye Task 1");

            });
            //each Task works independently, When an outer task completes its execution, it will move out and sync with the main thread.
            myTask1.Wait();
            Console.WriteLine("Hello Main Thread");
        }

        static void ChildTask()
        {
            //A child task is a nested task that is created with the AttachedToParent option.
            //It’s important to not use “Task.Run()” while making a child task that depends on its parent.
            //The parent task cannot terminate its execution until all its attached child tasks complete their execution.
            Task myTask1 = new Task(() =>
            {
                Console.WriteLine("Hello Task 1");

                Task myTask2 = new Task(() =>
                {
                    Console.WriteLine("Hello Task 2");
                    Thread.Sleep(1000);
                    Console.WriteLine("Bye Task 2");
                });
                myTask2.Start();

                Console.WriteLine("Bye Task 1");
            },TaskCreationOptions.AttachedToParent);

            
            myTask1.Start();
            myTask1.Wait();
        }

        static void SynchronizationOfVariablesInMultithreading()
        {
            //In a multithreading enviroment, the same variable can be accessed by two or more threads. If the operation
            //performed on a shared variable is atomic or thread - safe, then it produces an accurate result. If the operation
            //is non - atomic or not thread - safe, then it produces inaccurate results.

            //In atomic operation, only a single thread at a time can execute a single statement and produce accurate
            //results; while, in a non-atomic operation, more than one thread is accessing and manipulating the value of
            //a shared variable, which produces an inaccurate result(for example, if one thread is reading a value and the
            //other thread at the same time is editing it).

            // Imagine if Main thread read the value of count = 6 but the other thread read the value of count = 3.When
            //Main thread decrements the value of “count”, it becomes 5.But the other thread already read the value of
            //count = 3; when it increments it the value of count becomes “4”, which is entirely wrong because the other
            //thread must get the latest value of num and then increment it and the result should be “6”.

            int count = 0;
            Task myTask = Task.Run(() =>
            {
                for (int i = 0; i < 100000; i++)
                {
                    count +=  1;
                }
            });

            
            for(int i = 0; i < 100000; i++)
            {
                count -= 1;
            }
            myTask.Wait();

            Console.WriteLine("the value of count is: {0}", count);
        }

        static void SynchronizationOfVariablesLock()
        {
            //            The following are three common ways to handle synchronization variables in a multithreaded enviroment.
            //1.Lock
            //2.Monitor
            //3.Interlock

            
        }

        private static object thisLock = new object();

        static void SynchronizationOfVariablesMonitor()
        {
//• Monitor.Enter or Monitor.TryEnter method is used to lock a block of code for other threads and prevent other threads from executing it.
//• Monitor.Exit method is used to unlock the locked code for another thread and allow other threads to execute it.
            int count = 0;
            Task myTask = Task.Run(() =>
            {
                for( int i = 0; i<100000; i++)
                {
                    Monitor.Enter(thisLock);
                    count += 2;
                    Monitor.Exit(thisLock);
                }
            });

            for(int i = 0; i < 100000; i++)
            {
                Monitor.Enter(thisLock);
                count -= 1;
                Monitor.Exit(thisLock);
            }

            myTask.Wait();
            Console.WriteLine("the value of count is: {0}", count);
        }

        static void SynchronizationOfVariablesInterLocked()
        {
            //            Interlocked class is used to synchronize the access of shared memory objects among multiple threads.
            //Interlocked class provides the following useful operation on shared memory:
            //1. Increment and Decrement methods, used to increment or decrement a value of
            //variable.
            //2. Add and Read method, used to add an integer value to a variable or read a 64-bit
            //integer value as an atomic operation.
            //3. Exchange and CompareExchange methods, used to perform an atomic
            //exchange by returnning a value and replacing it with a new value, or it will be
            //contingent on the result of a comparison.
            int count = 0;
            int length = 100000;

            Task myTask = Task.Run(() =>
            {
                for (int i = 0; i < length; i++)
                {
                    Interlocked.Increment(ref count);
                }
            });

            for(int i = 0; i < length; i++)
            {
                Interlocked.Decrement(ref count);
            }

            myTask.Wait();

            Console.WriteLine("the value of count is: {0}", count);

// • Interlocked.Increment takes the reference of a shared memory, i.e., “num” and
//increments it by thread - safing it.
//• Interlocked.Decrement takes the reference of a shared memory, i.e., “num” and
//decrements it by thread - safing it.
        }

        static object thisLockA = new object();
        static object thisLockB = new object();

        static void DeadLock()
        {
            // In a multithreaded enviroment, a dead lock may occur; it freezes the application because two or more
            //activities are waiting for each other to complete.Usually it occurs when a shared resource is locked by one
            //thread and another thread is waiting to access it.

            Task myTask1 = Task.Run(() =>
            {
                lock(thisLockA)
                {
                    Console.WriteLine("Hello thisLockA");
                    lock (thisLockB)
                    {
                        Console.WriteLine("Hello thisLockB");
                        Thread.Sleep(500);
                    }
                }
            });

            Task myTask2 = Task.Run(() =>
            {
                lock (thisLockB)
                {
                    Console.WriteLine("Hello thisLockB");
                    lock (thisLockA)
                    {
                        Console.WriteLine("Hello thisLockA");
                        Thread.Sleep(500);
                    }
                }
            });

            Task[] tasks = { myTask1, myTask2 };

            Task.WaitAll(tasks);

            Console.WriteLine("Hello Main Thread");

//            Here is how the application got frozen.
//1.Tsk1 acquires lock “thislockA”.
//2.Tsk2 acquires lock “thislockB”.
//3.Tsk1 attempts to acquire lock “thislockB”, but it is already held by Tsk2 and thus
//Tsk1 blocks until “thislockB” is released.
//4.Tsk2 attempts to acquire lock “thislockA”, but it is held by Tsk1 and thus Tsk2
//blocks until “thislockA” is released.
        }

        static void CancellationToken()
        {
            // CancellationToken propagates a cancel notification to operations like threads, thread pool work items, or task objects.
            //Cancellation occurs when requesting a code calling the CancellationTokenSource.Cancel method, and
            //then the user delegate terminates the operation. However, an operation can be terminated:
            //            1.by simply returning from the delegate;
            //            2.by calling the CancellationTokenSource.Cancel method.
            //The following are general steps for implementing the cancellation model:
            //1.Instantiate a CancellationTokenSource.
            //2.Get a CancellationToken from CancellationTokenSource.Token property.
            //3.Pass the CancellationToken to each task or thread that listens for cancellation.
            //4.Provide a mechanism for each task or thread to respond to cancellation.
            //5.Call the CancellationTokenSource.Cancel method to provide notification of cancellation.

            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            Task myTask = Task.Run(() =>
            {
                int i = -1;
                while (true)
                {
                    Console.WriteLine("Task is running {0}", ++i);
                    Thread.Sleep(1000);

                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Task stop");
                        return;
                    }
                }
            });
            Console.WriteLine("Hello main thread");
            Thread.Sleep(5000);
            source.Cancel();//source is cancelled
            Thread.Sleep(5000);
            Console.WriteLine("Bye Main Thread");
            
        }

        static void ParallelProgramming()
        {
            //            Parallel Programming
            //In the modern era, computers and workstations have at least two or four cores that help multiple threads to
            //execute simultaneously. .NET provides easy ways to handle multiple threads on multiple cores.
            //In.NET, you can take advantage of parallelism by:
            //1.Concurrent Collection
            //2.Parallel.For & Parallel.Foreach
            //3.PLINQ

            //Concurrent Collection
            //1. ConcurrentDictionary<K,V>: Thread-safe dictionary in key value pairs
            //2.ConcurrentQueue<T>: Thread - safe FIFO data structure
            //3.ConcurrentStack<T>: Thread - safe LIFO data structure
            //4.ConcurrentBag<T>: Thread - safe implementation of an unordered collection
            //5.BlockingCollection<T>: Provides a Classical Producer Consumer pattern

        }

        static void ConcurrentCollection()
        {
            ConcurrentDictionary<int, string> dictionary = new ConcurrentDictionary<int, string>();

            Task myTask1 = Task.Run(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    dictionary.TryAdd(i,"Task1 " + i.ToString());
                }
            });

            Task myTask2 = Task.Run(() =>
            {
                for(int i = 0; i<1000; i++)
                {
                    dictionary.TryAdd(i + 1, "Task2 " + i.ToString());
                }
            });

            Task[] tasks = { myTask1, myTask2 };

            Task.WaitAll(tasks);

            Console.WriteLine("The process was successfull");

            //Other methods
            //1.ConcurrentQueue<T>, it has Enque() method to enque an item and TryDeque() method to remove and return the first item.
            //2.ConcurrentStack < T > it has Push() method to push an item and TryPop() method to remove and return the last item.
            //3.ConcurrentBack < T > it has Add() method to add an item and TryTake() method to remove and return the item.
        }

        static void ParallelFor_ParallelForeach()
        {
            //they iterate statements over multiple threads
            int[] numbers = new int[1000];



            Stopwatch watch = new Stopwatch();

           
            Parallel.For(1, 1000, (i) =>
             {
                 numbers[i] = i;
               
             });
            

            watch.Start();
            Parallel.For(1, 1000, (i) =>
            {
                Thread.Sleep(10);

            });
            watch.Stop();

            Console.WriteLine("The elapsed time was {0}", watch.ElapsedMilliseconds);
            Stopwatch watch1 = new Stopwatch();
            watch1.Start();
            Parallel.ForEach(numbers, (n) =>
            {
                Thread.Sleep(10);
            });
            watch1.Stop();
            Console.WriteLine("The elapsed time was {0}", watch1.ElapsedMilliseconds);

            Stopwatch watch2 = new Stopwatch();
            watch2.Start();
            for(int i = 0; i<1000; i++)
            {
                Thread.Sleep(10);
            }
            watch2.Stop();

            Console.WriteLine("The elapsed Time was {0}", watch2.ElapsedMilliseconds);
            

        }

        static void PLINQ()
        {
            //            PLINQ is the parallel version of LINQ.It means queries can be executed on multiple threads by partitioning
            //the data source into segments. Each segment executes on separate worker threads in parallel on multiple
            //processors.Usually, parallel execution significantly runs faster than sequential LINQ. However, parallelism
            //can slow down the execution on complicated queries.

            // It has the following common methods to help in parallelism:
            //1.AsParallel() Divide the data source in segments on multiple threads
            //2.AsSequential() Specify the query shall be executed sequentially
            //3.AsOrdered() Specify the query shall preserve the ordering of data
            //4.AsUnordered() Specity the query shall not preserve the ordering of data
            //5.ForAll() Process the result in parallel

            var numbers = Enumerable.Range(1, 500000000);

            
            Stopwatch watch1 = new Stopwatch();
            watch1.Start();
            var resultP = from n in numbers.AsParallel()
                          where n % 10 == 0
                          select n;
            foreach(var n in resultP)
            {

            }

            watch1.Stop();
            Console.WriteLine("the elapsed time with plinq is {0}", watch1.ElapsedMilliseconds);

            Stopwatch watch = new Stopwatch();
            watch.Start();
            var result = from n in numbers
                         where n % 10 == 0
                         select n;
            

            foreach (var n in result)
            {
            }
            watch.Stop();
            Console.WriteLine("the elapsed time is {0}", watch.ElapsedMilliseconds);

        }
    }
    }
    
