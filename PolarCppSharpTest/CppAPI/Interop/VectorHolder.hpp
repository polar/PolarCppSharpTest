#pragma once

#include <vector>
#include <string>

#include "CppSharp.hpp"

namespace Interop
{
  template<typename T>
  struct _DLLEXPORT_ VectorHolder
  {
    VectorHolder()
    {}

    ~VectorHolder()
    {}

    VectorHolder(const VectorHolder &x) : myVec(x.myVec)
    {}

    void assignFrom(void *items)
    {
        // overrides myVec;
        myVecPtr = (std::vector<T> *) items;
    }

    CS_IGNORE virtual void assignFrom(T *items, unsigned int size)
    {
        for (int i = 0; i < size; i++)
        {
            myVecPtr->emplace_back(items[i]);
        }
    };

    static int itemSize()
    {
        return sizeof(T);
    }

    void addByRef(void *ref)
    {
        myVecPtr->emplace_back(*(T *) ref);
    }

    void add(T item)
    {
        myVecPtr->emplace_back(item);
    };

    T &get(unsigned int i)
    {
        return (*myVecPtr)[i];
    };

    unsigned int count()
    {
        return static_cast<unsigned int>(myVecPtr->size());
    };

    void *ref()
    {
        return (void *) myVecPtr;
    }

  private:
    std::vector<T> myVec;
    std::vector<T> *myVecPtr = &myVec;
  };
}
