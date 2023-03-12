namespace Alauda.UIAutomation;

using Alauda.Native;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


/// <summary></summary>
public static class UISelector
{
    /// <summary></summary>
    public static int SetFocusState(
            IntPtr hWnd,
            bool state)
    {
        return UIControl.SendNotifyCode(hWnd, state ? 3 : 4);
    }


    /// <summary></summary>
    public static string[] GetItems(IntPtr hWnd)
    {
        var count = User32.SendMessage(
                hWnd,
                0x0146/* CB_GETCOUNT */,
                IntPtr.Zero,
                IntPtr.Zero).ToInt32();

        if(count == 0)
            throw new Exception();

        string[] items = new string[count];
        for(var i = 0; i < count; ++i)
        {
            var size = User32.SendMessage(
                    hWnd,
                    0x0149, /* CB_GETLBLTEXTLEN */
                    new IntPtr(i),
                    IntPtr.Zero)
                .ToInt32();

            if(size > 0)
            {
                var length = (size + 1) * (User32.IsWindowUnicode(hWnd) ? 2 : 1);
                var ptr = Marshal.AllocHGlobal(cb: length);
                if(ptr == IntPtr.Zero)
                    throw new NullReferenceException();

                var ret = User32.SendMessage(
                        hWnd,
                        0x0148, /* CB_GETLBLTEXT */
                        new IntPtr(i),
                        ptr)
                    .ToInt32();

                items[i] = (ret > 0)
                    ? (User32.IsWindowUnicode(hWnd) ? Marshal.PtrToStringUni(ptr) : Marshal.PtrToStringAnsi(ptr))
                    : string.Empty;
                Marshal.FreeHGlobal(ptr);
            }
        }

        return items;
    }

    /// <summary></summary>
    public static int StringSelect(
            IntPtr hWnd,
            string value,
            int    startIndex = 0)
    {
        var ptr = User32.IsWindowUnicode(hWnd)
            ? Marshal.StringToHGlobalUni(s: value)
            : Marshal.StringToHGlobalAnsi(s: value);

        var index = User32.SendMessage(
                hWnd,
                0x014d, /* CB_SELECTSTRING */
                new IntPtr(startIndex),
                ptr)
            .ToInt32();

        Marshal.FreeHGlobal(ptr);

        return index;
    }

    /// <summary></summary>
    public static bool ShowDropDown(
            IntPtr hWnd,
            bool state)
    {
        return User32.SendMessage(
                hWnd,
                0x14f, /* CB_SHOWDROPDOWN */
                new IntPtr(state ? 1 : 0),
                IntPtr.Zero)
            .ToInt32() == 1;
    }

    /// <summary></summary>
    public static bool Expand(IntPtr hWnd) => ShowDropDown(hWnd, true);

    /// <summary></summary>
    public static bool Collapse(IntPtr hWnd) => ShowDropDown(hWnd, false);
}
