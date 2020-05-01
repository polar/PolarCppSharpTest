#pragma once

#include <vector>

#include "CppSharp.hpp"

/*
 * This implementation is called punting on
 * getting std::vector<std::vector<T>> to work.
 */
#include "CppSharp.hpp"

namespace Interop
{
  template<typename T>
  struct _DLLEXPORT_ Vector2DHolder
  {
    Vector2DHolder()
    {}

    ~Vector2DHolder()
    {}

    Vector2DHolder(const Vector2DHolder &x) : myVec(x.myVec)
    {}

    static int itemSize()
    {
        return sizeof(T);
    }

    void add()
    {
        myVec.emplace_back();
    }


    void addByRef(int x, void *ref)
    {
        myVec[x].emplace_back(*(T *) ref);
    }

    void add(int x, T item)
    {
        myVec[x].emplace_back(item);
    };

    T &get(int x, int y)
    {
        return myVec[x][y];
    };
    /**
     * This return is problematic in an template class, and probably not very efficient or useful.
     * The real problem due to my punting on the issue and giving up on thinking about it for now.
     * The problem comes down a widening of the typed return to List<T> where T is already instantiated,
     * For example you cannot return a List<std::string> in C# and cast it to a generic type.
     * Probably could if you had some base type.
     */
#if 0
    std::vector<T> getX(int x) {
      return myVec[x];
    }
#endif


    int xCount()
    {
        return static_cast<int>(myVec.size());
    };

    int yCount(int x)
    {
        return myVec[x].size();
    }

    CS_IGNORE std::vector<T> &last()
    {
        return myVec[myVec.size() - 1];
    }

    CS_IGNORE std::vector<T> &add_new()
    {
        add();
        return last();
    }

  private:
    std::vector<std::vector<T>> myVec;
  };
}
