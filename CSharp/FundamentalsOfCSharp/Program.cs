﻿using System;

namespace FundamentalsOfCSharp
{
    class Program
    {
        static void Main(params string[] args)
        {
            //casting();
            //arrays();
            decisionOperators();
        }
        static void Main2(string[] args)
        {
            //Variables and Datatypes
            int i = 10; //4 bytes
            float f = 10f; // 4 bytes
            double d = 10D; // 8 bytes
            decimal dd = 10; // 16 bytes
            Console.WriteLine("{0}, {1}, {2}, {3}", i, f, d, dd);
            Console.ReadLine();

            //Arithmetic operator

            float sum = i + f;
            double dsum = i + d;
            decimal ddsum = dd + i;

            float sus = i - sum;
            double dsus = dsum - f;
            decimal ddsus = ddsum - i;

            float fmod = sum % i;
            double dmod = dsum % f;


            Console.WriteLine("{0}, {1}, {2}", sum, dsum, ddsum);
            Console.ReadLine();

            //Relational Operator

            bool rbool = i > f;
            bool r1bool = dd > (decimal)d;
            bool r2bool = (float)dd != f;

            Console.WriteLine("{0}, {1}, {2}", rbool, r1bool, r2bool);
            Console.ReadLine();

            //Logic operators

            bool r1 = true && true;
            bool r2 = true || true;
            bool r3 = !true;

            Console.WriteLine("{0}, {1}, {2}", r1, r2, r3);
            Console.ReadLine();

            //Type casting
            //implicit, Compilator makes the conversion automatically (from large to less or equal large size)

            double cinteger = i;
            double cfloat = f;
            float cint = i;

            //explicit, it is posible to lose information

            int ii = (int)dd;
            float ff = (float)d;

            //for casting strings

            string num = "10";

            int si = int.Parse(num);
            float sf = float.Parse(num);
            double sd = double.Parse(num);

            //            var keyword is recommended when:
            // you prefer good variable names over type;
            // The type name is long;
            // the expression is complex and you don’t know the type of value it returns.

            var vi = 10;
            var li = System.PlatformID.Unix;
            //Always initialize the var variable with a value. Otherwise the compiler will generate an error.

            //Linear arrays 

            int[] aInt = new int[4];

            aInt[0] = 1;
            aInt[1] = 2;
            aInt[2] = 3;
            aInt[3] = 4;

            for (i = 0; i < 4; i++)
            {
                Console.WriteLine("{0}", aInt[i]);
            }

            Console.ReadLine();

            //another way to declare and inicialize  single dimension array

            int[] a1 = { 1, 2, 3, 4 };

            //another way

            int[] a2 = new int[4] { 1, 2, 3, 4 };

            //another way

            int[] a3 = new int[] { 1, 2, 3, 4 };

            //multidimension array

            int[,] a4 = new int[2, 2];

            a4[0, 0] = 0;
            a4[0, 1] = 1;
            a4[1, 0] = 2;
            a4[1, 1] = 3;

            for (int row = 0; row < a4.GetLength(0); row++)
            {
                for (int col = 0; col < a4.GetLength(1); col++)
                {
                    Console.WriteLine("{0}", a4[row, col]);
                }
            }

            Console.ReadLine();
            //another way to declare and inicialize multidimension array

            int[,] a5 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            //or
            int[,] a6 = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            //or
            int[,] a7 = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            int[,,] a8 = { 
                { { 1, 2, 3 }, { 1, 2, 3 }, { 1, 2, 3 } },
                { { 2, 3, 4 }, { 2, 3, 4 }, { 2, 3, 4 } }
            };

            //Jagged array
            int[][] a9 = new int[3][];

            a9[0] = new int[] { 0, 1, 2, 3, 4 };
            a9[1] = new int[] { 0, 1, 2 };
            a9[2] = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };

            for (int row = 0; row < a9.Length; row++)
            {
                for (int col = 0; col < a9[row].Length; col++)
                {
                    Console.Write("{0}", a9[row][col]);
                }
                Console.WriteLine();
            }
            Console.ReadLine();

            //another way to declare and inicialize jagged array

            int[][] a10 =
            {
                new int[] {0,1,2,3},
                new int[] {0,1,2},
                new int[] {0}
            };

            int[][][] a11 =
                {
                new int[][]{ new int[]{1,3,2}},
                new int[][]{ new int[]{1,2}} ,
                new int[][]{ new int[]{2,3,4,5 } } 
            };

            //we control the flow of execution by introducing:
            //Decision Structure
            //Decision Operators
            //Loops
            //Jump Statements

            //Decision structure
            //if
            if (i > d)
            {
                Console.WriteLine("i greater than d");
            }

            //if - else
            if(d>f)
            {
                Console.WriteLine("d greater than f");

            }
            else
            {
                Console.WriteLine("f greater or equal to d");
            }

            //if- else if
            if (d > f)
            {
                Console.WriteLine("d greater than f");
            }
            else if (d == f)
            {
                Console.WriteLine("d equal than f");
            }
            else
            {
                Console.WriteLine("d less than f");
            }
            Console.ReadLine();
            //switch

            switch (i)
            {
                case 1:
                    Console.WriteLine("one");
                    break;
                case 2:
                    Console.WriteLine("two");
                    break;
                case 3:
                    Console.WriteLine("three");
                    break;
                default:
                    Console.WriteLine("No found");
                    break;
                    
            }
            Console.ReadLine();
            //Decision operators
            //Conditional Operator (? :)
            string result = i > f ? "i greater than f" : "f greater or equal than i";
            Console.WriteLine(result);
            //Null Coalescing Operator (??)
            string s1 = null;

            string s2 = s1 ?? "0";
            Console.WriteLine(s2);
            Console.ReadLine();

            //Loops

            //while loop
            bool band = false;
            while (band)
            {
                Console.WriteLine("this message is not going to be printed");
            }

            //do -while loop
            do
            {
                Console.WriteLine("do while loop, enter at least one time");    
            } while (band);
            //for loop
            Console.WriteLine("Loop for");
            for(int j = 0; j< i; j=j+1)
            {
                Console.WriteLine("j = {0}", j);
            }
            Console.ReadLine();
            //foreach loop
            //We cannot modify the value of a collection while iterating over it in a foreach loop.
            Console.WriteLine("loop foreach");
            foreach(var item in a1)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
            //Jump Statements 

            // Jump statements allow program controls to move from one point to another at any particular location
            //during the execution of a program. Below are the jump statements that we can use in C#:
            //Goto

            switch (i)
            {
                case 1:
                    Console.WriteLine("less than ten");
                    break;
                case 2:
                    goto case 1;
                case 3:
                    goto case 1;
                case 4:
                    goto case 1;
                default:
                    Console.WriteLine("greater than ten");
                    break;
            }

            foreach(int item in a1)
            {
                if (item == 3)
                {
                    goto salto;
                }
                Console.WriteLine(item);
            }
            salto:
            Console.WriteLine("goto salto");
            Console.ReadLine();


            //Break
            Console.WriteLine("break in for loop");
            for(int item = 0; item< 5; item++)
            {
                if(item == 2)
                {
                    break;
                }
                Console.WriteLine(item);
            }
            //Continue
            Console.WriteLine("continue in for loop");
            for(int item = 0; item < 5; item++)
            {
                if(item == 2)
                {
                    continue;
                }

                Console.WriteLine(item);
            }
            Console.ReadLine();
            //Return 
            //Return is also a jump statement, which moves back the program control to calling method.
            int age = GetAge();
            //it is posible to use return statement in the main method

            //If return statement is used in try/catch block and this try/catch has finally block,
            //then finally block will execute in this condition also and after it control will be
            //returned to calling method.
            // Tip: code after return statement is unreachable.Therefore it is wise to use the return
            //statement inside the if-else block, if we are willing to skip the remaining statement
            //of method only when a certain condition satisfies.Otherwise execute the complete
            //method.
            //Throw

            Console.WriteLine("write method 1 {0}", method1(1, 2));
            Console.WriteLine("write method 1 {0}", method1(b:1, a:2));
            Console.WriteLine("write method 2 {0}", method2(2));
            
            Console.WriteLine("write method 3, reference {0}", method3(ref i));
            int jj;
            Console.WriteLine("write method 4, out {0}", method4(out jj));

            Console.WriteLine("write method 5, params {0}", method5(2,2,3,4,2,4,5,5,5,9));
            Console.ReadLine();

            studentCard();
        }

        static int GetAge()
        {
            return 10;
        }

        static int method1(int a, int b)
        {
            int add = a + b;
            return add;
        }

        static int method2(int a, int b=0 )
        {
            return a + b;
        }

        static int method3(ref int i)
        {
            return i + 1;
        }
        static int method4(out int i)
        {
            i = 0;
            return i + 1;
        }

        static int method5(params int[] parameters)
        {
            int add = 0;
            foreach (int parameter in parameters)
            {
                add = add + parameter;
            }

            return add;
        }

        static void calculator()
        {
            
            string response = "N";
            string option = null;
            byte op;
            string auxop;
            string a, b;
            int aa, bb, result;
            string report=null;
            do
            {
                Console.Clear();
                Console.WriteLine("Press any following key to perform an arithmetic operation:");
                Console.WriteLine("1 - Addition");
                Console.WriteLine("2 - Sustraction");
                Console.WriteLine("3 - Multipliation");
                Console.WriteLine("4 - Division");
                option = Console.ReadLine();

                auxop = option ?? "1";
                op = byte.Parse(auxop);

                Console.Write("Enter value 1: ");
                a = Console.ReadLine();
                Console.Write("Enter value 2: ");
                b = Console.ReadLine();

                aa = int.Parse(a);
                bb = int.Parse(b);
                result = 0;


                switch (op)
                {
                    case 1:
                        result = aa + bb;
                        report = "{0} + {1} = {2}";
                        break;
                    case 2:
                        result = aa - bb;
                        report = "{0} - {1} = {2}";
                        break;
                    case 3:
                        result = aa * bb;
                        report = "{0} * {1} = {2}";
                        break;
                    case 4:
                        result = aa / bb;
                        report = "{0} / {1} = {2}";
                        break;
                }


                Console.WriteLine(report,aa,bb,result);
                Console.Write("Do you want to continue again (Y/N)?");
                response = Console.ReadLine();
            } while (response != "N");
        }

        static void studentCard()
        {
            string sstudentsNumber = null;
            int studentsNumber = 0;
            int i ;

           
                Console.Clear();
                Console.Write("Enter Total Students :");
                sstudentsNumber = Console.ReadLine();
                studentsNumber = int.Parse(sstudentsNumber);

                i = 0;

                int[,] marks = new int[studentsNumber, 3];
                string[] studentNames = new string[studentsNumber];
            for (int iStudent = 0; iStudent < studentsNumber; iStudent++)
            {
                Console.Write("Enter Student Name :");
                studentNames[iStudent] = Console.ReadLine();

                Console.Write("Enter English Marks (Out Of 100) :");
                marks[iStudent, 0] = int.Parse(Console.ReadLine());

                Console.Write("Enter Math Marks (Out Of 100) :");
                marks[iStudent, 1] = int.Parse(Console.ReadLine());

                Console.Write("Enter Computer Marks (Out Of 100) :");
                marks[iStudent, 2] = int.Parse(Console.ReadLine());
            }
                Console.WriteLine("****************Report Card*******************");
                Console.WriteLine("********************************");

                int position = 1;
                for (int row = marks.GetLength(0)-1; row >= 0; row--)
                {
                    Console.WriteLine("Student Name: {0}, Position:{1}, Total:{2}/300", studentNames[row], position, marks[row, 0] + marks[row, 1] + marks[row, 2]);
                    Console.WriteLine("********************************");
                    position++;
                }
            Console.ReadLine();
            }

        static void casting()
        {
            byte varByte = 34;
            int varInt = varByte;

            float varFloat = varInt;
            double varDouble = varFloat;

            int varInt1 = (int)varFloat;

            string sInt = "36";
            int varInt3 = int.Parse(sInt);

            int varInt4 = Convert.ToInt32(sInt);
        }
        static void arrays()
        {
            int[] a1 = { 1, 2, 3, 4, 5 };
            int[] a2 = new int[4];
            a2[0] = 1;
            a2[1] = 2;
            a2[2] = 3;
            a2[3] = 4;

            for (int item = 0; item < a1.GetLength(0); item++)
            {
                Console.WriteLine("item: {0}", item);
            }

            Console.ReadLine();

            string[,] a3 = new string[2, 2];
            a3[0, 0] = "one";
            a3[0, 1] = "two";
            a3[1, 0] = "three";
            a3[1, 1] = "four";

            string[,] a4 = { { "one", "two" }, { "three", "four" } };

            for (int rows = 0; rows < a4.GetLength(0); rows++)
            {
                for (int cols = 0; cols < a4.GetLength(1); cols++)
                {
                    Console.WriteLine("row: {0}, col: {1} = {2}", rows, cols, a4[rows, cols]);
                }
            }
            Console.ReadLine();

            int[][] a5 = new int[3][];

            a5[0] = new int[5] { 1, 2, 3, 4, 5 };
            a5[1] = new int[2] { 2, 3 };
            a5[2] = new int[1] { 1 };

            int[][] a6 =
            {
                new int[]{1,2,3},
                new int[]{1,2},
                new int[]{ 1,2,3,4,5}

            };

            for (int rows = 0; rows < a6.Length; rows++)
            {
                for (int cols = 0; cols < a6[rows].Length; cols++)
                {
                    Console.Write("{0}, ",a6[rows][cols]);

                }
                Console.WriteLine();
            }

            Console.ReadLine();



        }
        static void decisionOperators()
        {
            string userName;
            string userName1 = null;

            userName = userName1 ?? "User1";

            string userName2 = (userName == "User1") ? "User2" : "User1";

            Console.WriteLine(userName2);
            Console.ReadLine();
        }

        }
    }

