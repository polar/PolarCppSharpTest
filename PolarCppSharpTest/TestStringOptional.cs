using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Runtime.InteropServices;
using System.Text;
using ALK;
using ALK.Interop;
using Microsoft.VisualBasic.CompilerServices;


namespace PolarCppSharpTest
{
    class TestStringOptional
    {
        public static bool test()
        
        {
            try
            {
                bool pass = true;
                Console.WriteLine("************** C++ *************");
                string withValue = StringOptionalTest.getStaticStringOptionalWithValue();
                Console.WriteLine("Static Item has value: " + withValue);
                pass &= withValue != null;
                
                string withNoValue = StringOptionalTest.getStaticStringOptional();
                Console.WriteLine("Static Item has no value: " + (withNoValue == null));
                pass &= withNoValue == null;

                StringOptionalTest item1 = new StringOptionalTest();
                Console.WriteLine("StringOptionalTest.hasValue is not null: " + item1.hasValue);
                pass &= (item1.hasValue != null);
                
                Console.WriteLine("StringOptionalTest.hasValue should equal 'myValue': " + item1.hasValue);
                pass &= (item1.hasValue == "myValue");
                
                Console.WriteLine("StringOptionalTest.hasNoValue is null: " + item1.hasNoValue);
                pass &= (item1.hasNoValue == null);
                
                Console.WriteLine("StringOptionalTest.getStringOptional('something'): '" +
                                  item1.getStringOptional("something") + "'");
                pass &= (item1.getStringOptional("something") == "something");
                
                Console.WriteLine("StringOptionalTest.getStringOptional() should equal null: " +
                                  item1.getStringOptional() );
                pass &= (item1.getStringOptional() == null);

                Console.WriteLine("StringOptionalTest.doIhaveValue(null) should not: " + item1.doIhaveValue(null));
                pass &= (item1.doIhaveValue(null) == false);
                
                Console.WriteLine("StringOptionalTest.doIhaveValue('something') should: " + item1.doIhaveValue("something"));
                pass &= (item1.doIhaveValue("something") == true);

                Console.WriteLine("************** C# *************");
                
                
                StringOptional aValue = new StringOptional("Hello World!");
                Console.WriteLine("aValue = new StringOptional('Hello World!') has value: has_value()=" + aValue.has_value());
                pass &= aValue.has_value() == true;
                
                Console.WriteLine("aValue = new StringOptional('Hello World!') has value: " + aValue.value());
                pass &= aValue.value() == "Hello World!";

                StringOptional noValue = new StringOptional();
                Console.WriteLine("Static Item has no value: has_value(): " + (noValue.has_value()));
                pass &= withNoValue == null;
                
                StringOptional bValue = new StringOptional(aValue);
                Console.WriteLine("bValue = new StringOptional(aValue) has value: has_value()=" + bValue.has_value());
                pass &= bValue.has_value() == true;
                Console.WriteLine("bValue = new StringOptional(aValue).value() == aValue.value(), aValue: " + aValue.value() + ", bValue: " + bValue.value());
                pass &= bValue.value() == aValue.value();
                
                Console.WriteLine(@"******* END String Optional Tests ((({0}))) *******",  pass ? "PASSED" : "FAILED" );
               
            }
            catch (Exception e)
            {
                Console.WriteLine("******* TestStringOptional ERROR *******");
                Console.WriteLine(e);
                return false;
            }

            Console.WriteLine("******* TestStringOptional DONE *******");
            return true;
        }
    }
}