using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using ALK;
using Microsoft.VisualBasic.CompilerServices;


namespace PolarCppSharpTest
{
    class Program
    {
        static unsafe int Main(string[] args)
        {
            try
            {
                bool pass = true;
                //pass &= TestStrings.test();
                pass &= TestStringOptional.test();

                if (pass)
                {
                    Console.WriteLine("********* ALL TESTS (PASSED) ************");
                }
                else
                {
                    Console.WriteLine("********* ALL TESTS (FAILED) ************");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("******* ERROR *******");
                Console.WriteLine(e);
            }

            Console.WriteLine("******* DONE *******");
            return 0;
        }
    }
}