namespace Alauda.UIAutomation;

using Alauda.Native;
using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


/// <summary></summary>
public static class UIControl
{
    /// <summary></summary>
    public static void Change(IntPtr hWnd)
    {
        var cid = User32.GetDlgCtrlID(hWnd);

        var ret = User32.SendMessage(
                User32.GetParent(hWnd),
                0x0111/* WM_COMMAND */,
                new IntPtr((0x0300/* EN_CHANGE */ << 16) | (cid & 0xffff)),
                hWnd);
    }


    /// <summary></summary>
    public static int SendNotifyCode(
            IntPtr hWnd,
            int code)
    {
        var cid     = User32.GetDlgCtrlID(hWnd);
        var hParent = User32.GetParent(hWnd);
        var hCode   = new IntPtr((code << 16) | (cid & 0xffff));

        var ret = User32.SendMessage(
                hParent,
                0x0111, /* WM_COMMAND */
                hCode,
                hWnd)
            .ToInt32();

#if DEBUG
        Debug.WriteLine($"DEBUG | {ret} = {nameof(UIControl)}.{nameof(SendNotifyCode)}({hParent.ToInt():X}, 0x0111, {hCode.ToInt():X8}, {hWnd.ToInt():X})");
#endif

        return ret;
    }
}
