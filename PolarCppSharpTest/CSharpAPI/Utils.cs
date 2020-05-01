using ALK.Interop;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using Std;

/*
using System.Xml.Xsl.Runtime;
using ALK.Interop.Link;
using ALK.Interop.Map;
using ALK.Interop.Trip;
*/
namespace ALK.Interop
{
    public class Utils
    {
       // This function cannot be effectively be used, because the calling context of the RVO
       // (return value optimization) will have been relinquished if this call was made. So, code
       // like the following is placed directly in the generated code upon a return of a std::string
       // from the C++ code interop.
       // I leave it here to document what has to happen from the CppSharp code generation and the differences
       // between Linux and Windows, which is based on the defintion of #include <string> for their respective platforms.
#if LINUX
        public static unsafe string toString(std.basic_string.__Internalc__N_std_N___cxx11_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C __ret)
        {
            return (((int)__ret._M_string_length) > 15 ?
                global::System.Text.Encoding.UTF8.GetString((byte*)__ret._M_dataplus._M_p, (int)__ret._M_string_length) :
                global::System.Text.Encoding.UTF8.GetString((byte*)__ret._M_local_buf, (int)__ret._M_string_length));
        }
#else
        public static unsafe string toString(std.basic_string.__Internalc__N_std_S_basic_string__C___N_std_S_char_traits__C___N_std_S_allocator__C __ret)
        {
            var x = (((int)__ret._Mypair._Myval2._Mysize) > 15 ?
                global::System.Text.Encoding.UTF8.GetString((byte*)__ret._Mypair._Myval2._Bx._Ptr, (int)__ret._Mypair._Myval2._Mysize) :
                global::System.Text.Encoding.UTF8.GetString((byte*)__ret._Mypair._Myval2._Bx._Buf, (int)__ret._Mypair._Myval2._Mysize));
            return x;
        }
#endif

#if LINUX
        public static unsafe T[] toEnumArrayFromNative<T>(std._Vector_base._Vector_impl.__Internal native) where T : Enum
        {
            var interval = IntPtr.Size;
            var finish = native._M_finish.ToInt64();
            var start = native._M_start.ToInt64();
            var size = (finish - start) / interval;
            var ret = new T[size];
            for (var i = 0; i < size; i++)
            {
                ret[i] = (T)Enum.ToObject(typeof(T), *(int*)IntPtr.Add(native._M_start, i).ToPointer());
            }

            return ret;
        }
#else
        public static unsafe T[] toEnumArrayFromNative<T>(std._Vector_val.__Internal native) where T : Enum
        {
            var interval = IntPtr.Size;
            var finish = native._Mylast.ToInt64();
            var start = native._Myfirst.ToInt64();
            var size = (finish - start) / interval;
            var ret = new T[size];
            for (var i = 0; i < size; i++)
            {
                ret[i] = (T)Enum.ToObject(typeof(T), *(int*)IntPtr.Add(native._Myfirst, i).ToPointer());
            }

            return ret;
        }
#endif
        public delegate T MyFunc<T>(IntPtr p, bool use = false);

        public delegate int MySize<T>();

        public unsafe static byte byteP(IntPtr ip, bool use = false) => *((byte*) ip.ToPointer());
        public unsafe static sbyte sbyteP(IntPtr ip, bool use = false) => *((sbyte*) ip.ToPointer());
        public unsafe static uint uintP(IntPtr ip, bool use = false) => *((uint*) ip.ToPointer());
        public unsafe static int intP(IntPtr ip, bool use = false) => *((int*) ip.ToPointer());
        public unsafe static bool boolP(IntPtr ip, bool use = false) => *((bool*) ip.ToPointer());
        public unsafe static short shortP(IntPtr ip, bool use = false) => *((short*) ip.ToPointer());
        public unsafe static long longP(IntPtr ip, bool use = false) => *((long*) ip.ToPointer());
        public unsafe static ushort ushortP(IntPtr ip, bool use = false) => *((ushort*) ip.ToPointer());
        public unsafe static ulong ulongP(IntPtr ip, bool use = false) => *((ulong*) ip.ToPointer());
        public unsafe static float floatP(IntPtr ip, bool use = false) => *((float*) ip.ToPointer());
        public unsafe static double doubleP(IntPtr ip, bool use = false) => *((double*) ip.ToPointer());

        public unsafe static string stringP(IntPtr ip, bool use = false)
        {
            var __basicStringRet0 =
                global::std.basic_string<sbyte, global::std.char_traits<sbyte>, global::std.allocator<sbyte>>
                    .__CreateInstance(ip);
            var d = global::std.basic_stringExtensions.data(__basicStringRet0);
            return new String(d);
        }

        public static List<T> toList<T>(VectorHolder<T> holder)
        {
            return holder.getList();
        }

        public static List<T[]> toList<T>(Vector2DHolder<T> matrix)
        {
            return matrix.toListOfArray();
        }

        public static List<List<T>> toListList<T>(Vector2DHolder<T> matrix)
        {
            return matrix.toListList();
        }

        public static List<T> returnIf<T>(bool success, VectorHolder<T> holder)
        {
            if (success)
            {
                return toList(holder);
            }
            else
            {
                return null;
            }
        }

        public static List<T[]> returnIf<T>(bool success, Vector2DHolder<T> holder)
        {
            if (success)
            {
                return toList(holder);
            }
            else
            {
                return null;
            }
        }

        public static List<List<T>> returnListListIf<T>(bool success, Vector2DHolder<T> holder)
        {
            if (success)
            {
                return toListList(holder);
            }
            else
            {
                return null;
            }
        }

#if LINUX
        public static bool[] toBoolArray(std._Bvector_base._Bvector_impl.__Internal native)
        {
            BitVector bv = new Std.BitVector(native);
            var result = new List<bool>();
            for (var i = bv.begin(); i != bv.end(); i++)
                result.Add((bool)i);

            return result.ToArray();
        }
#else
        public static bool[] toBoolArray(std._Vector_val.__Internal native)
        {
            return toList(boolP, 1, native).ToArray();
        }
#endif

#if LINUX
        public static List<T> toList<T>(MyFunc<T> f, int iSize, std._Vector_base._Vector_impl.__Internal native)
        {
            int interval = iSize;
            ulong finish = (ulong)native._M_finish.ToInt64();
            ulong start = (ulong)native._M_start.ToInt64();
            int diff = (int)(finish > start ? finish - start : start - finish);
            int size = diff / interval;
            var ret = new System.Collections.Generic.List<T>();

            for (int i = 0; i < size; i++)
            {
                var itemPtr = IntPtr.Add(native._M_start, i * interval);
                T it;
                if (typeof(T).IsPrimitive || typeof(T) == typeof(String))
                {
                    it = f(itemPtr);
                }
                else
                {
                    it = (T)Activator.CreateInstance(typeof(T), new object[] { f(itemPtr) });
                }

                ret.Add(it);
            }
            return ret;
        }
#else
        public static List<T> toList<T>(MyFunc<T> f, int iSize, std._Vector_val.__Internal native)
        {
            int interval = iSize;

            ulong finish = (ulong)native._Mylast.ToInt64();
            ulong start = (ulong)native._Myfirst.ToInt64();
            int diff = (int)(finish > start ? finish - start : start - finish);
            int size = diff / interval;
            var ret = new System.Collections.Generic.List<T>();

            for (int i = 0; i < size; i++)
            {
                var itemPtr = IntPtr.Add(native._Myfirst, i * interval);
                T it;
                if (typeof(T).IsPrimitive || typeof(T) == typeof(String))
                {
                    it = f(itemPtr);
                }
                else
                {
                    it = (T)Activator.CreateInstance(typeof(T), new object[] { f(itemPtr) });
                }

                ret.Add(it);
            }
            return ret;
        }
#endif
    }
}
