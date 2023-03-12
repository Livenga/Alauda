namespace Alauda.Native;

using System;


/// <summary></summary>
public static class ExtdIntPtr
{
    /// <summary></summary>
    public static long ToInt(this IntPtr ptr) => IntPtr.Size switch
    {
        8 => ptr.ToInt64(),
        _ => ptr.ToInt32(),
    };
}
