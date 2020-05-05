
#include "StringOptionalTest.hpp"


static Interop::StringOptional staticOptionalWithValue("static value");
static Interop::StringOptional staticOptionalWithNoValue;

StringOptionalTest::StringOptionalTest() : hasValue("myValue"), hasNoValue()
{
}

Interop::StringOptional StringOptionalTest::getStringOptional(std::string &value)
{
    return value;
}

Interop::StringOptional StringOptionalTest::getStringOptional()
{
    return Interop::StringOptional();
}

bool StringOptionalTest::doIhaveValue(Interop::StringOptional &questionable)
{
    return questionable.has_value();
}

Interop::StringOptional &StringOptionalTest::getStaticStringOptionalWithValue()
{
    return staticOptionalWithValue;
}

Interop::StringOptional &StringOptionalTest::getStaticStringOptional()
{
printf("staticOptinalWithNoValue : %lx\n", &staticOptionalWithNoValue);
    return staticOptionalWithNoValue;
}