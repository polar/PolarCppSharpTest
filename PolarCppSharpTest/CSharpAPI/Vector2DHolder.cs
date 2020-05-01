
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using static ALK.Interop.Utils;

namespace ALK.Interop
{
    public partial class Vector2DHolder<T>
    {

        public Vector2DHolder(List<List<T>> items)
        {
            for(var i = 0; i < items.Count; i++)
            {
                add();
                foreach (var item in items[i])
                {
                    add(i, item);
                }
            }
        }

        public List<List<T>> toListList()
        {
            return toListList(this);
        }

        public List<T[]> toListOfArray()
        {
            return toListOfArray(this);
        }

        public static List<List<T>> toListList(Vector2DHolder<T> matrix)
        {
            var ll = new List<List<T>>();
            for (var x = 0; x < matrix.xCount(); x++)
            {
                var l = new List<T>();
                for (var y = 0; y < matrix.yCount(x); y++)
                {
                    var __T = typeof(T);
                    if (__T.IsAssignableFrom(typeof(string)))
                    {
                        var __ret = (matrix as Vector2DHolder<string>).get(x: x, y: y);
                        (l as List<string>).Add(__ret);
                    }

                }
                ll.Add(l);
            }

            return ll;
        }
        public static List<T[]> toListOfArray(Vector2DHolder<T> matrix)
        {
            var ll = new List<T[]>();
            for (var x = 0; x < matrix.xCount(); x++)
            {
                var l = new T[matrix.yCount(x)];
                for (var y = 0; y < matrix.yCount(x); y++)
                {
                    var __T = typeof(T);
                    if (__T.IsAssignableFrom(typeof(string)))
                    {
                        var __ret = (matrix as Vector2DHolder<string>).get(x: x, y: y);
                        (l as string[])[y] = __ret;
                    }

                }
                ll.Add(l);
            }

            return ll;
        }

        public List<List<T>> getList()
        {
            return toListList(this);
        }
    }
}
