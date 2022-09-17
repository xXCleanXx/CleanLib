using System;

namespace CleanLib.Xaml.Extensions;

public struct EnumDescription {
    public Enum Value { get; }
    public string Description { get; }

    public EnumDescription(Enum value, string description) {
        this.Value = value;
        this.Description = description;
    }
}