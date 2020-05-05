using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using ALK;
using Microsoft.VisualBasic.CompilerServices;

namespace ALK
{
    partial class Test
    {
        public unsafe string returnStringXXX(int x)
        {
#if LINUX
            var __ret = new global::std.basic_string.__Internalc__N_std_N___cxx11_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C();
            __Internal.returnString(new IntPtr(&__ret), __Instance, x);
            return (((int) __ret._M_string_length) > 15 ? global::System.Text.Encoding.UTF8.GetString((byte*)__ret._M_dataplus._M_p, (int) __ret._M_string_length) : global::System.Text.Encoding.UTF8.GetString((byte*)__ret._M_local_buf, (int) __ret._M_string_length));
#else
            var __ret = new global::std.basic_string.__Internalc__N_std_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C();
            __Internal.returnString(__Instance, new IntPtr(&__ret), x);
            return (((int) __ret._Mypair._Myval2._Mysize) > 15 ? global::System.Text.Encoding.UTF8.GetString((byte*) __ret._Mypair._Myval2._Bx._Ptr, (int) __ret._Mypair._Myval2._Mysize) : global::System.Text.Encoding.UTF8.GetString((byte*) __ret._Mypair._Myval2._Bx._Buf, (int) __ret._Mypair._Myval2._Mysize));
#endif

        }
    }
}

namespace PolarCppSharpTest
{
    class TestStrings
    {
        public static bool test()
        {
            Test test = Test.getStaticTest();
            Console.WriteLine("************** C++ *************");
            test.print();
            try
            {
                bool pass = true;
                Console.WriteLine("************** C# *************");
                Console.WriteLine("******* Properties *******");
                Console.WriteLine("Test Addr = " + test.addr());
                pass &= test.item1 == "item1";
                Console.WriteLine("Test.item1: " + test.aItem1() + " % " + test.oItem1() + " '" + test.item1 + "'");
                pass &= test.item2 == "item2";
                Console.WriteLine("Test.item2: " + test.aItem2() + " % " + test.oItem2() + " '" + test.item2 + "'");
                pass &= test.item3 == "item3";
                Console.WriteLine("Test.item3: " + test.aItem3() + " % " + test.oItem3() + " '" + test.item3 + "'");
                pass &= test.item4 == "item4";
                Console.WriteLine("Test.item4: " + test.aItem4() + " % " + test.oItem4() + " '" + test.item4 + "'");
                Console.WriteLine("******* Function Calls *******");
                pass &= test.returnString(1) == "item1";
                Console.WriteLine("Test.returnString(1): " + test.returnString(1));
                pass &= test.returnString(2) == "item2";
                Console.WriteLine("Test.returnString(2): " + test.returnString(2));
                pass &= test.returnString(3) == "item3";
                Console.WriteLine("Test.returnString(3): " + test.returnString(3));
                pass &= test.returnString(4) == "item4";
                Console.WriteLine("Test.returnString(4): " + test.returnString(4));
                Console.WriteLine("******* Function Calls using StringVal *******");
                pass &= test.returnStringXXX(1) == "item1";
                Console.WriteLine("Test.returnStringXXX(1): " + test.returnStringXXX(1));
                pass &= test.returnStringXXX(2) == "item2";
                Console.WriteLine("Test.returnStringXXX(2): " + test.returnStringXXX(2));
                pass &= test.returnStringXXX(3) == "item3";
                Console.WriteLine("Test.returnStringXXX(3): " + test.returnStringXXX(3));
                pass &= test.returnStringXXX(4) == "item4";
                Console.WriteLine("Test.returnStringXXX(4): " + test.returnStringXXX(4));
                Console.WriteLine(@"******* END TEST ((({0}))) *******",  pass ? "PASSED" : "FAILED" );
                Console.WriteLine("Test passes if 'item?' is returned from every item/returnString print");
                test.print();
            }
            catch (Exception e)
            {
                Console.WriteLine("******* TestStrings ERROR *******");
                Console.WriteLine(e);
                test.print();
                return false;
            }

            Console.WriteLine("******* TestStrings DONE *******");
            return true;
        }
    }
}