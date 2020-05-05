#pragma once

#include <string>
#include "Interop/StringOptional.hpp"
#include "Interop/CppSharp.hpp"

  struct _DLLEXPORT_ StringOptionalTest
  {
    StringOptionalTest();
    Interop::StringOptional hasValue; // This gets initialized with "myValue"
    Interop::StringOptional hasNoValue; // This is initalized with no value.
    
    Interop::StringOptional getStringOptional(std::string &value);
    Interop::StringOptional getStringOptional();
    
    bool doIhaveValue(Interop::StringOptional &questionable);
    
    static Interop::StringOptional &getStaticStringOptionalWithValue();
    static Interop::StringOptional &getStaticStringOptional();
    
    
  };