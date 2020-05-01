#pragma once

#include "CppSharp.hpp"

#ifndef GENERATE

#include <iostream>

#endif

#include "CppSharp.hpp"

namespace Interop
{
  // This class _DLLEXPORT_ is the closest thing to std::optional without any of the fancy stuff.
  template<typename T>
  struct _DLLEXPORT_ Optional
  {
    Optional() : _M_engaged(false), _M_payload()
    {}

    // We do not generate code to use the destructor from the C# side.
    // We do not specify it, or it will become a missing symbol.
    // ~Optional() {}

    Optional(const Optional<T> &x) : _M_engaged(x._M_engaged), _M_payload()
    {
        if (_M_engaged)
            _M_payload = x._M_payload;
    }

    Optional(T payload) : _M_engaged(true), _M_payload(payload)
    {}

    Optional<T> &operator=(const Optional<T> &x)
    {
        _M_engaged = x._M_engaged;
        if (_M_engaged)
            _M_payload = x._M_payload;
        return *this;
    }


#ifndef GENERATE

    CS_IGNORE friend std::ostream &operator<<(std::ostream &x, const Optional<T> &s)
    {
        if (s._M_engaged)
            x << s._M_payload;
        else
            x << "(null)";
        return x;
    }

#endif

    bool _M_engaged;
    T _M_payload;

    bool has_value()
    {
        return _M_engaged;
    }

    T &get_value_or_default()
    {
        return _M_payload;
    }

    T &get_value_or_default(T &x)
    {
        if (_M_engaged)
            return _M_payload;
        else
            return x;
    }

    T get_value_or_default(T x)
    {
        if (_M_engaged)
            return _M_payload;
        else
            return x;
    }

    T &value()
    {
        return _M_payload;
    }
  };
}
