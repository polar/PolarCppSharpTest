#pragma once

#include <vector>
#include <string>

#include "ByteVectorHolder.hpp"
#include "VectorHolder.hpp"
#include "Vector2DHolder.hpp"

namespace Interop
{
    struct Bootstrap
    {
        std::vector<unsigned short> ushortArray;
        std::vector<unsigned long> ulongArray;
        std::vector<unsigned int> uintArray;
        std::vector<short> shortArray;
        std::vector<long> longArray;
        std::vector<int> intArray;
        std::vector<float> floatArray;
        std::vector<bool> boolArray;
        std::vector<std::string> stringArray;
        std::vector<ByteVectorHolder> byteVectorHolderArray;
        void Get2DArray(Vector2DHolder<std::string> &holder);
    };
}