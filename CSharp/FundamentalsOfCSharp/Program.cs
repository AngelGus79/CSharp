using System;

namespace FundamentalsOfCSharp
{
    class Program
    {
        static void Main(string[] args)
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
        }
    }
}
