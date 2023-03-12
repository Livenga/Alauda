namespace Alauda.UIAutomation;

using Alauda.Native;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;


/// <summary></summary>
public static class UIText
{
    /// <summary></summary>
    private static bool OnEnumPropProc(IntPtr hWnd, IntPtr lpString, IntPtr hData, IntPtr lParam)
    {
        var propName = User32.IsWindowUnicode(hWnd)
            ? Marshal.PtrToStringUni(lpString)
            : Marshal.PtrToStringAnsi(lpString);

        Debug.WriteLine($"DEBUG | {nameof(OnEnumPropProc)} {hWnd.ToInt():X} {lpString.ToInt():X}");
        Debug.WriteLine($"\t{hData.ToInt():X} {propName}");

        return true;
    }


    /// <summary></summary>
    public static string SetText(
            IntPtr hWnd,
            string value)
    {
        var ptr = User32.IsWindowUnicode(hWnd)
            ? Marshal.StringToHGlobalUni(value)
            : Marshal.StringToHGlobalAnsi(value);

        User32.EnumPropsEx(hWnd, OnEnumPropProc, IntPtr.Zero);

        var ret = User32.SendMessage(
                hWnd,
                0x000C/* WM_SETTEXT */,
                IntPtr.Zero,
                ptr).ToInt32() == 1;
#if DEBUG
        Debug.WriteLine($"DEBUG WM_SETTEXT={ret}");
#endif
        if(ptr != IntPtr.Zero)
            Marshal.FreeHGlobal(ptr);

        //UIControl.Change(hWnd);

        return value;
    }

    /// <summary></summary>
    public static string SetTextAE(
            IntPtr hWnd,
            string value)
    {
        var ae = AutomationElement.FromHandle(hWnd);

        //var textPattern = ae.GetCurrentPattern(TextPattern.Pattern) as TextPattern ?? throw new NotSupportedException();
        var valuePattern = ae.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern ?? throw new NotSupportedException();
        valuePattern.SetValue(value);

        return value;
    }


    /// <summary></summary>
    public static int Change(IntPtr hWnd) => UIControl.SendNotifyCode(
            hWnd,
            0x0300/* EN_CHANGE */);

    /// <summary></summary>
    public static int Update(IntPtr hWnd) => UIControl.SendNotifyCode(
            hWnd,
            0x0400/* EN_UPDATE */);
}
