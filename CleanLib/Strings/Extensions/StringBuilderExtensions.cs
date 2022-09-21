using System.Text;

namespace CleanLib.Strings.Extensions;

/// <summary>Extensions for the <see cref="StringBuilder"/>.</summary>
public static class StringBuilderExtensions {
    /// <summary>Prepends a value to a <see cref="StringBuilder"/>.</summary>
    /// <param name="stringBuilder">The <see cref="StringBuilder"/> instance.</param>
    /// <param name="value">The value to prepend.</param>
    /// <returns>A reference to this <see cref="StringBuilder"/> instance.</returns>
    public static StringBuilder Prepend(this StringBuilder stringBuilder, object value)
        => stringBuilder.Insert(0, value);

    /// <summary>Prepends a value to a <see cref="StringBuilder"/>.</summary>
    /// <param name="stringBuilder">The <see cref="StringBuilder"/> instance.</param>
    /// <param name="value">The value to prepend.</param>
    /// <returns>A reference to this <see cref="StringBuilder"/> instance.</returns>
    public static StringBuilder Prepend(this StringBuilder stringBuilder, char value)
        => stringBuilder.Insert(0, value);

    /// <summary>Prepends a value to a <see cref="StringBuilder"/>.</summary>
    /// <param name="stringBuilder">The <see cref="StringBuilder"/> instance.</param>
    /// <param name="value">The value to prepend.</param>
    /// <returns>A reference to this <see cref="StringBuilder"/> instance.</returns>
    public static StringBuilder Prepend(this StringBuilder stringBuilder, char[] value)
        => stringBuilder.Insert(0, value);

    /// <summary>Prepends a value to a <see cref="StringBuilder"/>.</summary>
    /// <param name="stringBuilder">The <see cref="StringBuilder"/> instance.</param>
    /// <param name="value">The value to prepend.</param>
    /// <returns>A reference to this <see cref="StringBuilder"/> instance.</returns>
    public static StringBuilder Prepend(this StringBuilder stringBuilder, string value)
        => stringBuilder.Insert(0, value);

    /// <summary>Prepends a value to a <see cref="StringBuilder"/>.</summary>
    /// <param name="stringBuilder">The <see cref="StringBuilder"/> instance.</param>
    /// <param name="value">The value to prepend.</param>
    /// <returns>A reference to this <see cref="StringBuilder"/> instance.</returns>
    public static StringBuilder Prepend(this StringBuilder stringBuilder, bool value)
        => stringBuilder.Insert(0, value);

    /// <summary>Prepends a value to a <see cref="StringBuilder"/>.</summary>
    /// <param name="stringBuilder">The <see cref="StringBuilder"/> instance.</param>
    /// <param name="value">The value to prepend.</param>
    /// <returns>A reference to this <see cref="StringBuilder"/> instance.</returns>
    public static StringBuilder Prepend(this StringBuilder stringBuilder, sbyte value)
        => stringBuilder.Insert(0, value);

    /// <summary>Prepends a value to a <see cref="StringBuilder"/>.</summary>
    /// <param name="stringBuilder">The <see cref="StringBuilder"/> instance.</param>
    /// <param name="value">The value to prepend.</param>
    /// <returns>A reference to this <see cref="StringBuilder"/> instance.</returns>
    public static StringBuilder Prepend(this StringBuilder stringBuilder, byte value)
        => stringBuilder.Insert(0, value);

    /// <summary>Prepends a value to a <see cref="StringBuilder"/>.</summary>
    /// <param name="stringBuilder">The <see cref="StringBuilder"/> instance.</param>
    /// <param name="value">The value to prepend.</param>
    /// <returns>A reference to this <see cref="StringBuilder"/> instance.</returns>
    public static StringBuilder Prepend(this StringBuilder stringBuilder, short value)
        => stringBuilder.Insert(0, value);

    /// <summary>Prepends a value to a <see cref="StringBuilder"/>.</summary>
    /// <param name="stringBuilder">The <see cref="StringBuilder"/> instance.</param>
    /// <param name="value">The value to prepend.</param>
    /// <returns>A reference to this <see cref="StringBuilder"/> instance.</returns>
    public static StringBuilder Prepend(this StringBuilder stringBuilder, ushort value)
        => stringBuilder.Insert(0, value);

    /// <summary>Prepends a value to a <see cref="StringBuilder"/>.</summary>
    /// <param name="stringBuilder">The <see cref="StringBuilder"/> instance.</param>
    /// <param name="value">The value to prepend.</param>
    /// <returns>A reference to this <see cref="StringBuilder"/> instance.</returns>
    public static StringBuilder Prepend(this StringBuilder stringBuilder, int value)
        => stringBuilder.Insert(0, value);

    /// <summary>Prepends a value to a <see cref="StringBuilder"/>.</summary>
    /// <param name="stringBuilder">The <see cref="StringBuilder"/> instance.</param>
    /// <param name="value">The value to prepend.</param>
    /// <returns>A reference to this <see cref="StringBuilder"/> instance.</returns>
    public static StringBuilder Prepend(this StringBuilder stringBuilder, uint value)
        => stringBuilder.Insert(0, value);

    /// <summary>Prepends a value to a <see cref="StringBuilder"/>.</summary>
    /// <param name="stringBuilder">The <see cref="StringBuilder"/> instance.</param>
    /// <param name="value">The value to prepend.</param>
    /// <returns>A reference to this <see cref="StringBuilder"/> instance.</returns>
    public static StringBuilder Prepend(this StringBuilder stringBuilder, long value)
        => stringBuilder.Insert(0, value);

    /// <summary>Prepends a value to a <see cref="StringBuilder"/>.</summary>
    /// <param name="stringBuilder">The <see cref="StringBuilder"/> instance.</param>
    /// <param name="value">The value to prepend.</param>
    /// <returns>A reference to this <see cref="StringBuilder"/> instance.</returns>
    public static StringBuilder Prepend(this StringBuilder stringBuilder, ulong value)
        => stringBuilder.Insert(0, value);

    /// <summary>Prepends a value to a <see cref="StringBuilder"/>.</summary>
    /// <param name="stringBuilder">The <see cref="StringBuilder"/> instance.</param>
    /// <param name="value">The value to prepend.</param>
    /// <returns>A reference to this <see cref="StringBuilder"/> instance.</returns>
    public static StringBuilder Prepend(this StringBuilder stringBuilder, float value)
        => stringBuilder.Insert(0, value);

    /// <summary>Prepends a value to a <see cref="StringBuilder"/>.</summary>
    /// <param name="stringBuilder">The <see cref="StringBuilder"/> instance.</param>
    /// <param name="value">The value to prepend.</param>
    /// <returns>A reference to this <see cref="StringBuilder"/> instance.</returns>
    public static StringBuilder Prepend(this StringBuilder stringBuilder, double value)
        => stringBuilder.Insert(0, value);

    /// <summary>Prepends a value to a <see cref="StringBuilder"/>.</summary>
    /// <param name="stringBuilder">The <see cref="StringBuilder"/> instance.</param>
    /// <param name="value">The value to prepend.</param>
    /// <returns>A reference to this <see cref="StringBuilder"/> instance.</returns>
    public static StringBuilder Prepend(this StringBuilder stringBuilder, decimal value)
        => stringBuilder.Insert(0, value);
}