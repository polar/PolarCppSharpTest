using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;
using static ALK.Interop.Utils;

namespace ALK.Interop
{
    public partial class VectorHolder<T>
    {
        public List<T> getList()
        {
            var typeOfHolder = typeof(T);


            if (typeOfHolder.IsAssignableFrom(typeof(ushort)))
            {
                unsafe
                {
                    var list = new List<ushort>();
                    for (uint i = 0; i < count(); i++) list.Add(*(this as VectorHolder<ushort>).get(i));
                    return list as List<T>;
                }
            }

            if (typeOfHolder.IsAssignableFrom(typeof(uint)))
            {
                unsafe
                {
                    var list = new List<uint>();
                    for (uint i = 0; i < count(); i++) list.Add(*(this as VectorHolder<uint>).get(i));
                    return list as List<T>;
                }
            }


            if (typeOfHolder.IsAssignableFrom(typeof(ByteVectorHolder)))
            {
                var list = new List<ByteVectorHolder>();
                for (uint i = 0; i < count(); i++) list.Add(new ByteVectorHolder((this as VectorHolder<ByteVectorHolder>).get(i)));
                return list as List<T>;
            }

            if (typeOfHolder.IsAssignableFrom(typeof(int)))
            {
                unsafe
                {
                    var list = new List<int>();
                    for (uint i = 0; i < count(); i++) list.Add(*(this as VectorHolder<int>).get(i));
                    return list as List<T>;
                }
            }

            if (typeOfHolder.IsAssignableFrom(typeof(string)))
            {
                var list = new List<string>();
                for (uint i = 0; i < count(); i++) list.Add((string) (object) (this as VectorHolder<string>).get(i));
                return list as List<T>;
            }

            if (typeOfHolder.IsAssignableFrom(typeof(long)))
            {
                unsafe
                {
                    var list = new List<long>();
#if LINUX
                    for (uint i = 0; i < count(); i++) list.Add(*(this as VectorHolder<long>).get(i));
#else
                    // Windows seems to conflate long and int in the code generation.
                    for (uint i = 0; i < count(); i++) list.Add((long)*(this as VectorHolder<int>).get(i));
#endif
                    return list as List<T>;
                }
            }
            // We do not have need for a short in the interop. Perhaps we should add it.
#if false
            if (typeOfHolder.IsAssignableFrom(typeof(short)))
            {
                unsafe
                {
                    var list = new List<short>();
                    for (uint i = 0; i < count(); i++) list.Add(*(this as VectorHolder<short>).get(i));
                    return list as List<T>;
                }
            }
#endif
            if (typeOfHolder.IsAssignableFrom(typeof(ushort)))
            {
                unsafe
                {
                    var list = new List<ushort>();
                    for (uint i = 0; i < count(); i++) list.Add(*(this as VectorHolder<ushort>).get(i));
                    return list as List<T>;
                }
            }

            if (typeOfHolder.IsAssignableFrom(typeof(float)))
            {
                unsafe
                {
                    var list = new List<float>();
                    for (uint i = 0; i < count(); i++) list.Add(*(this as VectorHolder<float>).get(i));
                    return list as List<T>;
                }
            }

            if (typeOfHolder.IsAssignableFrom(typeof(bool)))
            {
                unsafe
                {
                    var list = new List<bool>();
                    for (uint i = 0; i < count(); i++) list.Add(*(this as VectorHolder<bool>).get(i));
                    return list as List<T>;
                }
            }
            
            throw new IndexOutOfRangeException($"Type is out of range (not implemented) for template<T> in VectorHolder<{typeof(T)}>::getList()");
        }
        
        public List<T> assignToList(List<T> retList)
        {
            retList.Clear();
            var typeOfHolder = typeof(T);

            if (typeOfHolder.IsAssignableFrom(typeof(ushort)))
            {
                unsafe
                {
                    var list = retList as List<ushort>;
                    for (uint i = 0; i < count(); i++) list.Add(*(this as VectorHolder<ushort>).get(i));
                    return list as List<T>;
                }
            }
            
            if (typeOfHolder.IsAssignableFrom(typeof(uint)))
            {
                unsafe
                {
                    var list = retList as List<uint>;
                    for (uint i = 0; i < count(); i++) list.Add(*(this as VectorHolder<uint>).get(i));
                    return list as List<T>;
                }
            }

            if (typeOfHolder.IsAssignableFrom(typeof(ByteVectorHolder)))
            {
                var list = retList as List<ByteVectorHolder>;
                for (uint i = 0; i < count(); i++) list.Add(new ByteVectorHolder((this as VectorHolder<ByteVectorHolder>).get(i)));
                return list as List<T>;
            }
            
            if (typeOfHolder.IsAssignableFrom(typeof(int)))
            {
                unsafe
                {
                    var list = retList as List<int>;
                    for (uint i = 0; i < count(); i++) list.Add(*(this as VectorHolder<int>).get(i));
                    return list as List<T>;
                }
            }
            
            if (typeOfHolder.IsAssignableFrom(typeof(string)))
            {
                var list = retList as List<string>;
                for (uint i = 0; i < count(); i++) list.Add((string) (object) (this as VectorHolder<string>).get(i));
                return list as List<T>;
            }

            if (typeOfHolder.IsAssignableFrom(typeof(long)))
            {
                unsafe
                {
                    var list = retList as List<long>;
#if LINUX
                    for (uint i = 0; i < count(); i++) list.Add(*(this as VectorHolder<long>).get(i));
#else
                    // Windows seems to conflate long and int in the code generation.
                    for (uint i = 0; i < count(); i++) list.Add((long)*(this as VectorHolder<int>).get(i));
#endif
                    return list as List<T>;
                }
            }
// We do not have need for short at the moment. Perhaps we should put it in.
#if false
            if (typeOfHolder.IsAssignableFrom(typeof(short)))
            {
                unsafe
                {
                    var list = retList as List<short>;
                    for (uint i = 0; i < count(); i++) list.Add(*(this as VectorHolder<short>).get(i));
                    return list as List<T>;
                }
            }
#endif

            if (typeOfHolder.IsAssignableFrom(typeof(ushort)))
            {
                unsafe
                {
                    var list = retList as List<ushort>;
                    for (uint i = 0; i < count(); i++) list.Add(*(this as VectorHolder<ushort>).get(i));
                    return list as List<T>;
                }
            }

            if (typeOfHolder.IsAssignableFrom(typeof(float)))
            {
                unsafe
                {
                    var list = retList as List<float>;
                    for (uint i = 0; i < count(); i++) list.Add(*(this as VectorHolder<float>).get(i));
                    return list as List<T>;
                }
            }

            if (typeOfHolder.IsAssignableFrom(typeof(bool)))
            {
                unsafe
                {
                    var list = retList as List<bool>;
                    for (uint i = 0; i < count(); i++) list.Add(*(this as VectorHolder<bool>).get(i));
                    return list as List<T>;
                }
            }

            throw new IndexOutOfRangeException($"Type is out of range (not implemented) for template<T> in VectorHolder<{typeof(T)}>::getList()");
        }
    }

    public static unsafe partial class VectorHolderExtensions
    {
        public partial struct __Internal
        {
            [SuppressUnmanagedCodeSecurity]
            [DllImport("ALK", CallingConvention = global::System.Runtime.InteropServices.CallingConvention.Cdecl,
                EntryPoint = "_ZN7Interop12VectorHolderIbE3getEj")]
            internal static extern bool* get_bool(global::System.IntPtr __instance, uint i);
        }

        public static bool* get(this global::ALK.Interop.VectorHolder<bool> @this, uint i)
        {
            var __arg0 = ReferenceEquals(@this, null) ? global::System.IntPtr.Zero : @this.__Instance;
            var __ret = __Internal.get_bool(__arg0, i);
            return __ret;
        }
    }
}
