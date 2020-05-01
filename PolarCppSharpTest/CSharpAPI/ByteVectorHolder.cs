
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;

using static ALK.Interop.Utils;

namespace ALK.Interop
{
    public partial class ByteVectorHolder
    {
        public ByteVectorHolder(byte[] bytes) : this(bytes.Length)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                set(i, (sbyte) bytes[i]);
            }
        }

        public ByteVectorHolder(sbyte[] bytes) : this(bytes.Length)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                set(i, bytes[i]);
            }
        }

        public byte[] getByteArray()
        {
            var ret = new byte[size()];
            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = (byte) get(i);
            }
            return ret;
        }
    }
}
