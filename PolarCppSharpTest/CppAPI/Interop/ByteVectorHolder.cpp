//
// Created by polar on 12/31/19.
//

#include "ByteVectorHolder.hpp"

namespace Interop
{
  ByteVectorHolder::ByteVectorHolder() = default;

  ByteVectorHolder::~ByteVectorHolder() = default;

  ByteVectorHolder::ByteVectorHolder(int n_items) : m_Buffer(n_items)
  {}

  ByteVectorHolder::ByteVectorHolder(const ByteVectorHolder &holder) : m_Buffer(holder.m_Buffer)
  {}

  void ByteVectorHolder::resize(int size)
  {
      items = -1;
      m_Buffer.resize(size);
  }

  void ByteVectorHolder::copy(const char *buf, int size)
  {
      m_Buffer.insert(m_Buffer.begin(), buf, buf + size);
  }

  ByteVectorHolder::ByteVectorHolder(int items, const char *base) : items(items), base(const_cast<char *>(base))
  {}

  ByteVectorHolder::ByteVectorHolder(int items, const char &base) : m_Buffer(items, base)
  {}

  int ByteVectorHolder::size()
  {
      return items < 0 ? m_Buffer.size() : items;
  }

  void ByteVectorHolder::set(int i, char item)
  {
      if (items < 0)
          m_Buffer[i] = item;
      else
          base[i] = item;
  }

  char ByteVectorHolder::get(int i)
  {
      return items < 0 ? m_Buffer[i] : base[i];
  }

  char *ByteVectorHolder::get_data()
  {
      return items < 0 ? m_Buffer.data() : base;
  }
}
