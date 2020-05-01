//
// Created by polar on 12/31/19.
//

#include <iostream>
#include "StringOptional.hpp"

namespace Interop
{
  StringOptional::StringOptional() : _M_engaged(false)
  {};

  StringOptional::~StringOptional()
  {}


  StringOptional::StringOptional(const StringOptional &x) : _M_engaged(x._M_engaged), _M_payload(x._M_payload)
  {}

  StringOptional::StringOptional(const std::string &payload) : _M_engaged(true), _M_payload(payload)
  {}

  StringOptional &StringOptional::operator=(const StringOptional &x)
  {
      _M_engaged = x._M_engaged;
      if (_M_engaged)
          _M_payload = x._M_payload;
      return *this;
  }

  bool StringOptional::has_value()
  {
      return _M_engaged;
  }

  std::string &StringOptional::value()
  {
      return _M_payload;
  }

  std::ostream &operator<<(std::ostream &x, const StringOptional &s)
  {
      x << (s._M_engaged ? s._M_payload.c_str() : "(null)");
      return x;
  }

  const char *StringOptional::c_str() const
  {
      return _M_engaged ? _M_payload.c_str() : (char *) "";
  }
#ifdef _ALK_
  ALKustring operator+(ALKustring &x, const StringOptional &s)
  {
      ALKustring tmp = x;
      tmp += s.c_str();
      return tmp;
  }
#endif

  std::string operator+(std::string &x, const StringOptional &s)
  {
      std::string tmp = x;
      tmp += (s._M_engaged ? s._M_payload.c_str() : "");
      return tmp;
  }

  std::string operator+(StringOptional &s, const char *x)
  {
      return s._M_engaged ? s._M_payload + x : std::string(x);
  }

  std::string operator+(const char *x, StringOptional &s)
  {
      return s._M_engaged ? std::string(x) + s._M_payload : std::string(x);
  }

  bool StringOptional::empty()
  {
      return !_M_engaged || _M_payload.empty();
  }

  bool StringOptional::nullEmptyOrWhitespace()
  {
      return !_M_engaged || std::all_of(_M_payload.begin(), _M_payload.end(), isspace);
  }

  StringOptional::operator const char *()
  {
      return _M_engaged ? _M_payload.c_str() : (char *) "";
  }

}
