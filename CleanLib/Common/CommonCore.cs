namespace CleanLib.Common;

public static class CommonCore {
    public static void Swap(ref object obj1, ref object obj2) => (obj2, obj1) = (obj1, obj2);
}