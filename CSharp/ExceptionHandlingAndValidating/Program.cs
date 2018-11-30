using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace ExceptionHandlingAndValidating
{
    class Program
    {
        static void Main(string[] args)
        {
            //HandlingException();
            //TryCatchExceptionTypeEx();
            //TryCatchExceptionType();
            //TryCatchFinally();
            //TryCatchEx();
            //MultipleCatchBlocks();
            //ThrowingExceptions();
            //Re_Throw();
            //InnerException();
            //myCustomException();
            //ValidatingApplicationInput();
            //RegExMail();
            Challenge01();
            Console.ReadLine();
        }
        static void HandlingException()
        {
            //Exception is an unexpected error that occurs at runtime
            //In terms of programming, an exception is a C# class (System.Exception)

            //            The following is a list of some common.NET exceptions that may occur at runtime.
            //• System.Exception, is either thrown by a system or a running application to report an
            //error.
            //• InvalidOperationException, is thrown when the state of an object cannot invoke a
            //method or execute an expression.
            //• ArgumentException, is thrown when a method is invoked and one of its parameters
            //doesn’t meet the specification of a parameter.
            //• ArgumentNullException, is thrown when a method is invoked and one of its
            //paremeter arguments is null.
            //• ArgumentOutOfRangeException, is thrown when the value of an argument is
            //outside the range of values as defined by the type of the arguments of the invoked
            //method.
            //• NullReferenceException, is thrown when you try to use a reference which is not
            //initialized, or try to access a member of a type which is not initialized in memory.
            //• IndexOutOfRangeException, is thrown when an index of an array tries to access
            //something which is outside of the array’s range.
            //272
            //• StackOverflowException, is thrown when the Stack has too many nested methods
            //and it cannot add more methods to execute it.
            //• OutOfMemoryException, is thrown when there is not enough memory to run a
            //program.
            //• ArithmeticException, is thrown when there is an error in an arithmetic operation.
            //• DivideByZeroException, is thrown when there is an attempt to divide an integral or
            //decimal value with zero.
            //• OverflowException, is thrown when an arithmetic operation returns a value that is
            //outside the range of the data type.
            //• IOException, is thrown when there is an error in an IO operation.
            //• DirectoryNotFoundException, is thrown when there is an attempt to access a
            //directory that is not found in the system.
            //• FileNotFoundException, is thrown when there is an attempt to access a file that is
            //not found in the system.
            //• SqlException, is thrown when an sql server returns a warning or error.

            try
            {
                int[] numbers = new int[2];

                numbers[0] = 1;
                numbers[1] = 2;
                numbers[2] = 3;
            }
            catch
            {
                Console.WriteLine("It has ocurred an exception");
            }
        }

        static void TryCatchExceptionTypeEx()
        {
            int[] num = new int[2];
            try
            {


                num[0] = 1;
                num[1] = 2;
                num[2] = 3;

            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Error message {0} ", ex.Message);
            }
        }

        static void TryCatchExceptionType()
        {
            int[] num = new int[2];
            try
            {

                num[0] = 1;
                num[1] = 2;
                num[2] = 3;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("The index is out of Range");
            }
        }

        static void TryCatchFinally()
        {

            // try-catch-finally is a full version of handling exception in a better way.It comprises of three blocks:
            //• try {}, is used to write a block of code that may throw an exception.
            //• catch {}, is used to handle a specific type of exception.
            //• finally {}, is used to to clean up actions that are performed in a try block.
            // finally block is always run at the end, regardless of whether an exception is thrown or a catch block
            // matching the exception type is found.
            int[] num = new int[2];
            try
            {


                num[0] = 1;
                num[1] = 2;
                num[2] = 3;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("The Index is out of Range");
            }
            finally
            {
                num = null;
                Console.WriteLine("Game over");
            }

            Console.WriteLine("all the instructions given after the try-catch-finally structure are executed wheather a exception is thrown or not");
        }
       
        static void TryCatchEx()
        {
            int[] num = new int[2];
            try
            {
                num[0] = 1;
                num[1] = 2;
                num[2] = 3;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Message error: {0}", ex.Message);
                Console.WriteLine("Type error: {0}", ex.GetType());
            }
    }
        
        static void MultipleCatchBlocks()
        {

            
            try
            {
                using(var fileStream = new FileStream(@"c:\file.txt", FileMode.Open))
                {

                }
            }catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("message error: {0}, type error: {1}", ex.Message, ex.GetType());
            }catch (IOException)
            {
                Console.WriteLine("IO error opertation, try again");
            }catch (Exception ex)
            {
                Console.WriteLine("message error: {0}, type error: {1}", ex.Message, ex.GetType());
            }
            finally
            {
               
            }
        }

        static void ThrowingExceptions()
        {
            //            In C#, an object of exception can be explictly thrown from code by using the throw keyword. A programmer
            //should throw an exception from code if one or more of the following conditions are true:
            //1.When method doesn’t complete its defined functionality, for example,
            //Parameters has null values, etc.
            //2.When an invalid operation is running, for example, trying to write to a read - only
            //file, etc.

            Action<string, int> show = (n, a) =>
            {
                if (n is null)
                {
                    throw new ArgumentException("name is missing", "name");
                }
                Console.WriteLine("The name is {0} and the age is {1}", n, a);
            };

            string name = null;
            int age = 3;
            try
            {
                show(name, age);
            }catch (ArgumentException ex)
            {
                Console.WriteLine("Error message:  {0}. Error type: {1}", ex.Message,ex.GetType());
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                name = null;
                
            }

            
        }

        static void Re_Throw()
        {
            try
            {
                Re_Throw2(23);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message); 
            }
        }

        static void Re_Throw2( int age, string name = null)
        {
            try
            {
                Console.WriteLine("name: {0}, age: {1}",name.ToUpper(), age);
            }
            catch (NullReferenceException)
            {
                throw; //this is not a innerexception becouse is not new
            }
        }

        static void InnerException()
        {
            string name = null;
            int age = 23;
            try
            {
                InnerException1(age, name);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                name = null;
            }
        }

        static void InnerException1(int age, string name = null)
        {
            try
            {
                Console.WriteLine("name: {0}, age: {1}", name.ToUpper(), age);
            }
            catch(NullReferenceException ex)
            {
                throw new Exception("the error is a Null Reference Exception", ex);
            }
        }

        static void myCustomException()
        {
            Action myCustomEx = () => throw new MyCustomException("This is a Custom exception");

            try
            {
                myCustomEx();
            }catch (MyCustomException ex)
            {
                Console.WriteLine(ex.Message);
                
            }
        }
        
        static void ValidatingApplicationInput()
        {
            //• *, matches the previous character for zero or more times.E.g.,“bi*” matches either “b” or “bii”.
            //• +, matches the previous character for one or more times.E.g., “bi +” matches either “bi” or “bii”.
            //• ?, matches the previous element zero or one time.E.g., “As?i” matches either “Ai” or “Asi”
            //• ^, matches the character at the beginning of a string.E.g., “^\d{4}” matches “1234 - ali”
            //• $, matches the character at the end of a string.E.g., “\d{4}$” matches “ali-1231”
            //• { n}, matches the previous element for “n” times.E.g., “\d{4}” matches “1253”
            //• x|y, matches either x or y .E.g., “e|fv” matches “e” or “fv”
            //• [xyz], matches any one of the enclosed characters.E.g., “[asi]” matches “a” in “Fart”
            //• [^xyz], it’s the negation of all enclosed characters.The matches string must not have those character sets.E.g., “[^ac]” matches “film”
            //• \d, matches a digit. Equivalent to[0-9]
            //• \D, matches a non-digit.Equivalent to[^0-9]
            //• \s, matches a whitespace, tab, form-feed, etc.Equivalent to[\f\n\r\t\v]
            //• \S, matches a non-white space.Equivalent to[^\f\n\r\t\v]
            //• \w, matches a word including an underscore. Equivalent to [A-Za-z0-9]
            //• \W, matches a non-word character. Equivalent to [^A-Za-z0-9]

            string pattern =@"^\(\d{3}\)-\d{3}-\d{2}-\d{2}$";
           
            bool flag = true;
            string inputStr = null;
            string option;
            do
            {
                Console.Write("Write a phone number: ");
                inputStr = Console.ReadLine();
                Console.WriteLine();
                if (Regex.IsMatch(inputStr,pattern))
                {
                    Console.WriteLine("It is a valid phone number");
                }
                else
                {
                    Console.WriteLine("It is NOT a valid phone number");
                }

                Console.WriteLine("Do you want to try again (s/n)?");
                option = Console.ReadLine();

                flag = option == "s" ? true : false;
            } while (flag);

        }

        static void RegExMail()
        {
           
            string strOption = null;
            string pattern = @"^\w+[a-zA-Z0-9]+([_.-][a-z0-9]+)*@[a-zA-Z]+\.[a-zA-Z]{2,4}$";
            // ^ match the expression from the start of the input string, if you do not put it the expression could return true if the expression match from the 2do character or 3rd and so on.
            // $ match the expression until the end of the input string
            // \w+ the first character must be _, a-z, A-Z,0-9 and can have more than one.
            // [a-zA-Z0-9]+ can have at least one character from the followings sets a-z, A-Z,0-9.
            // ([_.-][a-z0-9]+)* this pattern indicates that if you write a [_.-] character you must write at least one character from the set a-z, 0-9, and this pattern can be written zero or many times.

            do
            {
                Console.Write("input a e-mail: ");
                if (Regex.IsMatch(Console.ReadLine(), pattern))
                {
                    Console.WriteLine("the expression Match \n");
                }
                else
                {
                    Console.WriteLine("The expression DOES NOT match \n");
                }

                Console.Write("Do you want to continue (s/n)?: ");
                strOption = Console.ReadLine();

            } while (strOption == "s");

        }

        static void Challenge01()
        {
            Person person = new Person();

           
                person.RegExDateOfBirth = @"^\d{2}-\d{2}-\d{4}$";
                person.RegExEmail = @"^\w+[a-zA-Z]+[a-zA-Z0-9]*([._-][a-zA-Z0-9]+)*@[a-zA-Z0-9]+\.[a-zA-Z]{2,4}$";
                person.RegExPhoneNumber = @"^\(\d{3}\)-\d{3}-\d{2}-\d{2}$";
                person.RegExWebSite = @"^(http|https)://www\.[a-zA-Z0-9]+\w*\.[a-zA-Z]{2,4}$";
                person.RegExZipCode = @"^\d{5}$";

            person.PropertyChanged += (sender, e) =>
            {
                Person p = (Person)sender;
                Console.WriteLine("DateOfBirth: {0}", p.DateOfBirth);
                Console.WriteLine("Email: {0}", p.EMail);
                Console.WriteLine("PhoneNumber: {0}", p.PhoneNumber);
                Console.WriteLine("WebSite: {0}", p.WebSite);
                Console.WriteLine("ZipCode: {0}", p.ZipCode);
            };

                do
                {

                try
                {
                    Console.Write("DateOfBirth: ");
                    person.DateOfBirth = Console.ReadLine();

                    Console.WriteLine();

                    Console.Write("Email:  ");
                    person.EMail = Console.ReadLine();

                    Console.WriteLine();

                    Console.Write("Phone Number:  ");
                    person.PhoneNumber = Console.ReadLine();

                    Console.WriteLine();

                    Console.Write("Web Site:  ");
                    person.WebSite = Console.ReadLine();

                    Console.WriteLine();

                    Console.Write("Zip Code:  ");
                    person.ZipCode = Console.ReadLine();
                    

                }
                catch (Exception ex)
                {

                    Console.WriteLine("\n\nError Description: {0} ", ex.Message);
                    Console.WriteLine("Error Type: {0} ", ex.GetType());
                    Console.WriteLine("Error Trace: {0} \n\n", ex.StackTrace);
                }
                Console.Write("Do you want to continue (s/n): ");
            } while (Console.ReadLine() == "s");

            
        }
    }

    class MyCustomException: System.Exception
    {
        public MyCustomException(string message): base(message)
        {

        }
           
    }
    class NotMatchExpressionException : System.Exception
    {
        public NotMatchExpressionException(string message) : base(message)
        {

        }
    }
    class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string _Email;
        public string EMail {
            get
            {
                return _Email;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    BEmail = false;
                }
                else
                {
                    
                    try
                    {
                        if (!Regex.IsMatch(value, RegExEmail))
                        {
                            throw new NotMatchExpressionException("The Email expression DOES NOT match with the pattern");
                        }
                        else
                        {
                            BEmail = true;
                            _Email = value;
                            EverythingIsOk("EMail");
                        }
                    }
                    catch (ArgumentException)
                    {
                        throw new ArgumentException("The pattern for Email is missing", "RegExEmail");

                    }catch (NotMatchExpressionException)
                    {
                        throw;
                    }

                    catch (Exception ex)

                    {
                        throw ex;
                    }
                }
                
            }
        }

        string _PhoneNumber;
        public string PhoneNumber {
            get
            {
                return _PhoneNumber;
            }
            set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    BPhoneNumber = false;
                }
                else
                {
                   
                    try
                    {
                        if (!Regex.IsMatch(value, RegExPhoneNumber))
                        {
                            throw new NotMatchExpressionException("The Phone Number expression DOES NOT match with the pattern");

                        }
                        else
                        {
                            _PhoneNumber = value;
                            BPhoneNumber = true;
                            EverythingIsOk("PhoneNumber");
                        }
                    }
                    catch (ArgumentException)
                    {
                        throw new ArgumentException("The pattern for Phone Number is missing", "RegExPhoneNumber");
                    }
                    catch (NotMatchExpressionException)
                    {
                        throw;
                    }catch (Exception ex)
                    {
                        throw ex;
                    }

                }
                
            }
        }

        string _ZipCode;
        public string ZipCode {
            get
            {
                return _ZipCode;
            }
            set
            {

                if (string.IsNullOrWhiteSpace(value))
                {
                    BZipCode = false;
                }
                else
                {
                   
                    try
                    {
                        if(!Regex.IsMatch(value, RegExZipCode))
                        {
                            throw new NotMatchExpressionException("The ZipCode expression DOES NOT match with the pattern");
                        }
                        else
                        {
                            _ZipCode = value;
                            BZipCode = true;
                            EverythingIsOk("ZipCode");
                        }
                    }
                    catch(ArgumentException)
                    {
                        throw new ArgumentException("The pattern for ZipCode is missing", "RegExZipCode") ;
                    }
                    catch (NotMatchExpressionException)
                    {
                        throw;
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }
                }
                
            }
        }

        string _DateOfBirth;
        public string DateOfBirth {
            get
            {
                return _DateOfBirth;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    BDateOfBirth = false;
                }
                else
                {
                   
                    try
                    {
                        if(!Regex.IsMatch(value, RegExDateOfBirth))
                        {
                            throw new NotMatchExpressionException("The Date Birth expression DOES NOT match with the pattern");
                        }
                        else
                        {
                            BDateOfBirth = true;
                            _DateOfBirth = value;
                            EverythingIsOk("DateOfBirth");
                        }
                    }
                    catch (ArgumentException)
                    {
                        throw new ArgumentException("The pattern for Birth Date is missing","RegExDateOfBirth");
                    }
                    catch (NotMatchExpressionException)
                    {
                        throw;
                    }
                    catch(Exception ex)
                    {
                        throw ex;
                    }

                }
                
            }
        }

        string _WebSite;
        public string WebSite {
            get
            {
                return _WebSite;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    BWebSite = false;
                }
                else
                {
                    
                    try
                    {
                        if (!Regex.IsMatch(value, RegExWebSite))
                        {
                            throw new NotMatchExpressionException("The pattern for Web Site is missing");
                        }
                        else
                        {
                            BWebSite = true;
                            _WebSite = value;
                            EverythingIsOk("WebSite");
                        }
                    }
                    catch (ArgumentException)
                    {
                        throw new ArgumentException("The pattern for Web Site is missing","RegExWebSite");
                    }
                    catch (NotMatchExpressionException)
                    {
                        throw;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                
            }
        }

        bool BEmail;
        bool BPhoneNumber;
        bool BZipCode;
        bool BDateOfBirth;
        bool BWebSite;

        bool BRegExEmail;
        bool BRegExPhoneNumber;
        bool BRegExZipCode;
        bool BRegExDateOfBirth;
        bool BRegExWebSite;

        public string RegExEmail { get; set; }
        public string RegExPhoneNumber { get; set; }
        public string RegExZipCode { get; set; }
        public string RegExDateOfBirth { get; set; }
        public string RegExWebSite { get; set; }

        private void EverythingIsOk(string myPropertyChanged)
        {
            
            var PropertyChangedEvent = PropertyChanged;
            if(PropertyChangedEvent != null)
                {
                if (BEmail && BZipCode && BWebSite && BPhoneNumber && BDateOfBirth)
                {
                    PropertyChangedEvent(this, new PropertyChangedEventArgs(myPropertyChanged));
                }
            }
        }
        public Person()
        {
            BEmail= false;
            BPhoneNumber = false;
            BZipCode = false;
            BDateOfBirth = false;
            BWebSite = false;

            BRegExEmail = false;
            BRegExPhoneNumber = false;
            BRegExZipCode = false;
            BRegExDateOfBirth = false;
            BRegExWebSite = false;

        }

    }

}