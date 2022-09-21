#pragma warning disable S3358 // Ternary operators should not be nested

namespace CleanLib.Booleans.Extensions;

public static class BooleansExtensions {
    public static string ToWord(this bool boolean, bool german = false)
        => german ? boolean ? "Ja" : "Nein" : boolean ? "Yes" : "No";
}