namespace Alauda.Native;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


/// <summary></summary>
public static class Kernel32
{
    private const string L = "kernel32";


    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetLastError), SetLastError = true, CharSet = CharSet.Auto)]
    public static extern int GetLastError();
}
