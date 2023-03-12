namespace Alauda.Native.Test;

using Alauda.Native;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


/// <summary></summary>
[TestClass]
public class UserTest
{
    /// <summary></summary>
    [TestMethod]
    public void EnumWindowsProcTest()
    {
        User32.EnumWindows(OnEnumWindowsProc, IntPtr.Zero);
    }


    /// <summary></summary>
    private bool OnEnumWindowsProc(IntPtr hWnd, IntPtr lParam)
    {
        if(hWnd == IntPtr.Zero)
            return false;

        var windowText = User32.GetWindowText(hWnd);
        Console.Error.WriteLine($"DEBUG | {windowText}#{hWnd.ToInt():X} {User32.GetDlgCtrlID(hWnd)}");
        User32.EnumChildWindows(hWnd, OnEnumWindowsProc, IntPtr.Zero);

        return true;
    }
}
