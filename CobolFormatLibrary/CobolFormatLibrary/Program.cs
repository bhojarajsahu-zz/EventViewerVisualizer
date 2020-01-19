using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            CobolFormatLibrary c1 = new CobolFormatLibrary();
            string input=string.Empty,format=string.Empty;


            while(true)
            {
                Console.WriteLine("enter the value: ");
                input = Console.ReadLine();
                Console.WriteLine("enter the format: ");
                format = Console.ReadLine();

                Console.WriteLine("the output is : '" + c1.ConvertToByteString(input, format) + "'");

            }

            Console.ReadKey();

        }
    }
}
