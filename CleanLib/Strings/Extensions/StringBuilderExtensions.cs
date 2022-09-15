using System.Text;

namespace CleanLib.Common.Strings.Extensions;

public static class StringBuilderExtensions {
    public static StringBuilder Prepend(this StringBuilder stringBuilder, object value)
        => stringBuilder.Insert(0, value);

    public static StringBuilder Prepend(this StringBuilder stringBuilder, char value)
        => stringBuilder.Insert(0, value);

    public static StringBuilder Prepend(this StringBuilder stringBuilder, char[] value)
        => stringBuilder.Insert(0, value);

    public static StringBuilder Prepend(this StringBuilder stringBuilder, string value)
        => stringBuilder.Insert(0, value);

    public static StringBuilder Prepend(this StringBuilder stringBuilder, bool value)
        => stringBuilder.Insert(0, value);

    public static StringBuilder Prepend(this StringBuilder stringBuilder, sbyte value)
        => stringBuilder.Insert(0, value);

    public static StringBuilder Prepend(this StringBuilder stringBuilder, byte value)
        => stringBuilder.Insert(0, value);

    public static StringBuilder Prepend(this StringBuilder stringBuilder, short value)
        => stringBuilder.Insert(0, value);

    public static StringBuilder Prepend(this StringBuilder stringBuilder, ushort value)
        => stringBuilder.Insert(0, value);

    public static StringBuilder Prepend(this StringBuilder stringBuilder, int value)
        => stringBuilder.Insert(0, value);

    public static StringBuilder Prepend(this StringBuilder stringBuilder, uint value)
        => stringBuilder.Insert(0, value);

    public static StringBuilder Prepend(this StringBuilder stringBuilder, long value)
        => stringBuilder.Insert(0, value);

    public static StringBuilder Prepend(this StringBuilder stringBuilder, ulong value)
        => stringBuilder.Insert(0, value);

    public static StringBuilder Prepend(this StringBuilder stringBuilder, float value)
        => stringBuilder.Insert(0, value);

    public static StringBuilder Prepend(this StringBuilder stringBuilder, double value)
        => stringBuilder.Insert(0, value);

    public static StringBuilder Prepend(this StringBuilder stringBuilder, decimal value)
        => stringBuilder.Insert(0, value);
}