using System;

namespace CleanLib.Enumerations.Extensions;

public static class EnumerationsExtensions {
    public static int CountFlags(this Enum @enum) {
        int x = (int)(IConvertible)@enum;
        int count = 0;

        while (x != 0) {
            if ((x & 1) != 0) count++;

            x >>= 1;
        }

        return count;
    }
}