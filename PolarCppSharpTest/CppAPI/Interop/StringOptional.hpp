#pragma once

#include "CppSharp.hpp"

#include <string>
#include <ostream>

#ifndef GENERATE

#ifdef _ALK_
#include "dalkutil/alkstring.h"
#endif
#endif


namespace Interop
{
  /*
   * This class _DLLEXPORT_ is a special incarnation of something that would be std::optional<std::string>.
   * It is needed because there are various places in the C# code where nulls are given for strings.
   * Nulls for strings cannot happen in C++, yet we need to explicitly take into account whether
   * a string exists or not.
   *
   * This class _DLLEXPORT_ gets marshalled on the C# side as a string. In the C# code generation, it will return null or
   * the string accordingly.
   *
   * There are a bunch of operators <<, + that make dealing with ALKustring, osstream and std::string
   * on the C++ side, easier.
   */
  struct _DLLEXPORT_ StringOptional
  {
    StringOptional();

    ~StringOptional();

    StringOptional(const StringOptional &payload);

    StringOptional(const std::string &payload);

    bool has_value();

    std::string &value();

#ifndef GENERATE
// The following methods are not called from C#, but we need them for internal operations on the C++ side.
    CS_IGNORE StringOptional &operator=(const StringOptional &x);

    CS_IGNORE friend std::ostream &operator<<(std::ostream &x, const StringOptional &s);

    CS_IGNORE const char *c_str() const;

#ifdef _ALK_
    CS_IGNORE friend ALKustring operator+(ALKustring &x, const StringOptional &s);
#endif
    CS_IGNORE friend std::string operator+(std::string &x, const StringOptional &s);

    CS_IGNORE friend std::string operator+(StringOptional &s, const char *x);

    CS_IGNORE friend std::string operator+(const char *x, StringOptional &s);

    CS_IGNORE bool empty();

    CS_IGNORE bool nullEmptyOrWhitespace();

    CS_IGNORE explicit operator const char *();

#endif

    bool _M_engaged;
    std::string _M_payload;
  };
}
