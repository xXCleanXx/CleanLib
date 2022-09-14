using System.Text;

namespace CleanLib.Common.Strings.Extensions;

public static class StringBuilderExtensions {
    public static StringBuilder Prepend(this StringBuilder stringBuilder, object value) {
        return stringBuilder.Insert(0, value);
    }

    public static StringBuilder Prepend(this StringBuilder stringBuilder, char value) {
        return stringBuilder.Insert(0, value);
    }

    public static StringBuilder Prepend(this StringBuilder stringBuilder, char[] value) {
        return stringBuilder.Insert(0, value);
    }

    public static StringBuilder Prepend(this StringBuilder stringBuilder, string value) {
        return stringBuilder.Insert(0, value);
    }

    public static StringBuilder Prepend(this StringBuilder stringBuilder, bool value) {
        return stringBuilder.Insert(0, value);
    }

    public static StringBuilder Prepend(this StringBuilder stringBuilder, sbyte value) {
        return stringBuilder.Insert(0, value);
    }

    public static StringBuilder Prepend(this StringBuilder stringBuilder, byte value) {
        return stringBuilder.Insert(0, value);
    }

    public static StringBuilder Prepend(this StringBuilder stringBuilder, short value) {
        return stringBuilder.Insert(0, value);
    }

    public static StringBuilder Prepend(this StringBuilder stringBuilder, ushort value) {
        return stringBuilder.Insert(0, value);
    }

    public static StringBuilder Prepend(this StringBuilder stringBuilder, int value) {
        return stringBuilder.Insert(0, value);
    }

    public static StringBuilder Prepend(this StringBuilder stringBuilder, uint value) {
        return stringBuilder.Insert(0, value);
    }

    public static StringBuilder Prepend(this StringBuilder stringBuilder, long value) {
        return stringBuilder.Insert(0, value);
    }

    public static StringBuilder Prepend(this StringBuilder stringBuilder, ulong value) {
        return stringBuilder.Insert(0, value);
    }

    public static StringBuilder Prepend(this StringBuilder stringBuilder, float value) {
        return stringBuilder.Insert(0, value);
    }

    public static StringBuilder Prepend(this StringBuilder stringBuilder, double value) {
        return stringBuilder.Insert(0, value);
    }

    public static StringBuilder Prepend(this StringBuilder stringBuilder, decimal value) {
        return stringBuilder.Insert(0, value);
    }
}