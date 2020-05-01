using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using ALK;
using ALK.Interop;

namespace PolarCppSharpTest
{
    class Program
    {
        static unsafe void Main(string[] args)
        {
            Test test = Test.getStaticTest();
            Console.WriteLine("************** C++ *************");
            test.print();
            Console.WriteLine("************** C# *************");
            Console.WriteLine("Test addr = " + test.addr());
            Console.WriteLine("Test.item1: " + test.aItem1() + " % " + test.oItem1() + " '" + test.item1 + "'");
            test.print();
            Console.WriteLine("Test.item2: " + test.aItem2() + " % " + test.oItem2() + " '" + test.item2 + "'");
            test.print();
            Console.WriteLine("Test.item3: " + test.aItem3() + " % " + test.oItem3() + " '" + test.item3 + "'");
            test.print();
            Console.WriteLine("Test.item4: " + test.aItem4() + " % " + test.oItem4() + " '" + test.item4 + "'");
            test.print();
        }
    }
}