using System;
using std;

namespace Std
{
#if LINUX
    public class BitIterator
    {
        private const int BITS_PER_BYTE = 8;

        public BitIterator(_Bit_iterator.__Internal native)
        {
            _M_impl = native;
        }

        BitIterator(uint offset, System.IntPtr ptr)
        {
            _M_impl = new _Bit_iterator.__Internal();
            _M_impl._M_offset = offset;
            _M_impl._M_p = ptr;
        }

        _Bit_iterator.__Internal _M_impl;

        public static unsafe BitIterator operator ++(BitIterator h1)
        {
            return h1.next();
        }

        public static unsafe BitIterator operator +(BitIterator h1, int i)
        {
            BitIterator ret = h1;
            for (; i > 0; i--) ret = ret.next();
            return ret;
        }

        public override bool Equals(object o)
        {
            if (o != null && o is BitVector)
            {
                BitIterator h2 = (BitIterator) o;
                return _M_impl._M_offset == h2._M_impl._M_offset && _M_impl._M_p == h2._M_impl._M_p;
            }

            return false;
        }

        public static unsafe bool operator ==(BitIterator h1, BitIterator h2)
        {
            return h1._M_impl._M_offset == h2._M_impl._M_offset && h1._M_impl._M_p == h2._M_impl._M_p;
        }

        public static unsafe bool operator !=(BitIterator h1, BitIterator h2)
        {
            return h1._M_impl._M_p != h2._M_impl._M_p || h1._M_impl._M_offset != h2._M_impl._M_offset;
        }

        public static unsafe implicit operator bool(BitIterator h)
        {
            int shift = (int) h._M_impl._M_offset;
            uint mask = (uint) 1 >> shift;
            return ((*((uint*) h._M_impl._M_p)) & mask) != 0;
        }

        public BitIterator next()
        {
            if (_M_impl._M_offset == IntPtr.Size * BITS_PER_BYTE)
            {
                return new BitIterator(0, IntPtr.Add(_M_impl._M_p, IntPtr.Size));
            }
            else
            {
                return new BitIterator(_M_impl._M_offset + 1, _M_impl._M_p);
            }
        }
    }

    public partial class BitVector
    {
        private std._Bvector_base._Bvector_impl.__Internal _M_impl;

        public BitVector(std._Bvector_base._Bvector_impl.__Internal native)
        {
            _M_impl = native;
        }

        private const int BITS_PER_BYTE = 8;

        public ulong size()
        {
            ulong start = (ulong) _M_impl._M_finish._M_p.ToInt64();
            ulong finish = (ulong) _M_impl._M_start._M_p.ToInt64();
            // Just in case some machines go the other way in their pointer arithmetic.
            // And we need a positive number.
            ulong diff = start > finish ? start - finish : finish - start;

            return (BITS_PER_BYTE * diff) + _M_impl._M_finish._M_offset;
        }

        public BitIterator begin()
        {
            return new BitIterator(_M_impl._M_start);
        }

        public BitIterator end()
        {
            return new BitIterator(_M_impl._M_finish);
        }
    }
#endif
}