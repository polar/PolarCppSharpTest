#pragma once

#include <vector>

#include "CppSharp.hpp"

namespace Interop
{
  struct _DLLEXPORT_ ByteVectorHolder
  {
    ByteVectorHolder();;

    ByteVectorHolder(int n_items);

    ~ByteVectorHolder();

    CS_IGNORE ByteVectorHolder(int items, const char &base);

    CS_IGNORE ByteVectorHolder(int items, const char *base);

    ByteVectorHolder(const ByteVectorHolder &holder);

    void resize(int size);

    CS_IGNORE void copy(const char *buf, int size);

    int size();

    void set(int i, char item);

    char get(int i);

    char *get_data();

  private:
    char *base;
    int items = -1;
    std::vector<char> m_Buffer;
  };
}
