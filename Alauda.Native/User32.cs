namespace Alauda.Native;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


/// <summary></summary>
public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

/// <summary></summary>
public delegate bool EnumPropProc(IntPtr hWnd, IntPtr lpString, IntPtr hData, IntPtr lParam);

/// <summary></summary>
public delegate void SendAsyncProc(IntPtr hWnd, uint uMsg, IntPtr wData, IntPtr lResult);


/// <summary></summary>
public static class User32
{
    private const string L = "user32";

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(SetActiveWindow), SetLastError = true, CharSet = CharSet.Auto)]
    public static extern IntPtr SetActiveWindow(IntPtr hWnd);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(SetForegroundWindow), SetLastError = true, CharSet = CharSet.Auto)]
    public static extern bool SetForegroundWindow(IntPtr hWnd);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(EnumWindows), SetLastError = true, CharSet = CharSet.Auto)]
    public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(EnumChildWindows), SetLastError = true, CharSet = CharSet.Auto)]
    public static extern bool EnumChildWindows(
            [In]IntPtr          hWndParent,
            [In]EnumWindowsProc lpEnumFunc,
            [In]IntPtr          lParam);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetParent), SetLastError = true, CharSet = CharSet.Auto)]
    public static extern IntPtr GetParent(IntPtr hWnd);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(IsWindowUnicode), SetLastError = true, CharSet = CharSet.Auto)]
    public static extern bool IsWindowUnicode(IntPtr hWnd);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(IsWindowVisible), SetLastError = true, CharSet = CharSet.Auto)]
    public static extern bool IsWindowVisible(IntPtr hWnd);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(EnableWindow), SetLastError = true, CharSet = CharSet.Auto)]
    public static extern int EnableWindow(IntPtr hWnd, bool bEnable);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetWindowRect), SetLastError = true, CharSet = CharSet.Auto)]
    public static extern bool GetWindowRect(
            [In]IntPtr hWnd,
            [Out]out Rect lpRect);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetDlgCtrlID), SetLastError = true, CharSet = CharSet.Auto)]
    public static extern int GetDlgCtrlID(IntPtr hWnd);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetWindowTextLengthA), SetLastError = true, CharSet = CharSet.Ansi)]
    public static extern int GetWindowTextLengthA(IntPtr hWnd);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetWindowTextLengthW), SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern int GetWindowTextLengthW(IntPtr hWnd);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetWindowTextA), SetLastError = true, CharSet = CharSet.Ansi)]
    public static extern int GetWindowTextA(
            [In]IntPtr hWnd,
            [Out]StringBuilder lpString,
            [In]int nMaxCount);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetWindowTextW), SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern int GetWindowTextW(
            [In]IntPtr hWnd,
            [Out]StringBuilder lpString,
            [In]int nMaxCount);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetWindowThreadProcessId), SetLastError = true, CharSet = CharSet.Auto)]
    public static extern int GetWindowThreadProcessId(
            [In]IntPtr hWnd,
            [Out]out int lpdwProcessId);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(SendMessageA), SetLastError = true, CharSet = CharSet.Ansi)]
    public static extern IntPtr SendMessageA(
            [In]IntPtr hWnd,
            [In]uint msg,
            [In, Out]IntPtr wParam,
            [In, Out]IntPtr lParam);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(SendMessageW), SetLastError = true, CharSet = CharSet.Ansi)]
    public static extern IntPtr SendMessageW(
            [In]IntPtr hWnd,
            [In]uint msg,
            [In, Out]IntPtr wParam,
            [In, Out]IntPtr lParam);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(SendMessageCallbackA), SetLastError = true, CharSet = CharSet.Ansi)]
    public static extern IntPtr SendMessageCallbackA(
            [In]IntPtr        hWnd,
            [In]uint          msg,
            [In, Out]IntPtr   wParam,
            [In, Out]IntPtr   lParam,
            [In]SendAsyncProc lpResultCallback,
            [In]IntPtr        dwData);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(SendMessageCallbackW), SetLastError = true, CharSet = CharSet.Ansi)]
    public static extern IntPtr SendMessageCallbackW(
            [In]IntPtr        hWnd,
            [In]uint          msg,
            [In, Out]IntPtr   wParam,
            [In, Out]IntPtr   lParam,
            [In]SendAsyncProc lpResultCallback,
            [In]IntPtr        dwData);

    /// <summary></summary>
    public static IntPtr SendMessageCallback(
            [In]IntPtr        hWnd,
            [In]uint          msg,
            [In, Out]IntPtr   wParam,
            [In, Out]IntPtr   lParam,
            [In]SendAsyncProc lpResultCallback,
            [In]IntPtr        dwData) => IsWindowUnicode(hWnd)
        ? SendMessageCallbackW(hWnd, msg, wParam, lParam, lpResultCallback, dwData)
        : SendMessageCallbackA(hWnd, msg, wParam, lParam, lpResultCallback, dwData);


    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetClassNameA), SetLastError = true, CharSet = CharSet.Ansi)]
    public static extern int GetClassNameA(
            [In]IntPtr hWnd,
            [Out]StringBuilder lpClassName,
            [In]int nMaxCount);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetClassNameW), SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern int GetClassNameW(
            [In]IntPtr hWnd,
            [Out]StringBuilder lpClassName,
            [In]int nMaxCount);

    /// <summary></summary>
    public static string GetClassName(IntPtr hWnd, int maxCount = 4096)
    {
        var sb = new StringBuilder(maxCount);

        var ret = IsWindowUnicode(hWnd)
            ? GetClassNameW(hWnd, sb, maxCount)
            : GetClassNameA(hWnd, sb, maxCount);

        return (ret > 0)
            ? sb.ToString(0, ret)
            : throw new Win32Exception(Kernel32.GetLastError());
    }


    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(EnumPropsExA), SetLastError = true, CharSet = CharSet.Ansi)]
    public static extern int EnumPropsExA(IntPtr hWnd, EnumPropProc lpEnumFunc, IntPtr lParam);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(EnumPropsExW), SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern int EnumPropsExW(IntPtr hWnd, EnumPropProc lpEnumFunc, IntPtr lParam);

    /// <summary></summary>
    public static int EnumPropsEx(IntPtr hWnd, EnumPropProc lpEnumFunc, IntPtr lParam) =>
        IsWindowUnicode(hWnd)
        ? EnumPropsExW(hWnd, lpEnumFunc, lParam)
        : EnumPropsExA(hWnd, lpEnumFunc, lParam);


    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetPropA), SetLastError = true, CharSet = CharSet.Ansi)]
    public static extern IntPtr GetPropA([In]IntPtr hWnd, [In]string lpString);

    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(GetPropW), SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern IntPtr GetPropW([In]IntPtr hWnd, [In]string lpString);

    /// <summary></summary>
    public static IntPtr GetProp(IntPtr hWnd, string lpString) => IsWindowUnicode(hWnd)
        ? GetPropW(hWnd, lpString)
        : GetPropA(hWnd, lpString);


    /// <summary></summary>
    [DllImport(L, EntryPoint = nameof(CheckDlgButton), SetLastError = true, CharSet = CharSet.Auto)]
    public static extern bool CheckDlgButton(
            [In]IntPtr hDlg,
            [In]int    nIDButton,
            [In]uint   uCheck);

    /// <summary></summary>
    public static IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam) =>
        IsWindowUnicode(hWnd)
            ? SendMessageW(hWnd, msg, wParam, lParam)
            : SendMessageA(hWnd, msg, wParam, lParam);


    /// <summary></summary>
    public static int GetWindowTextLength(IntPtr hWnd) =>
        IsWindowUnicode(hWnd) ? GetWindowTextLengthW(hWnd) : GetWindowTextLengthA(hWnd);


    /// <summary></summary>
    public static string? GetWindowText(IntPtr hWnd)
    {
        var length = GetWindowTextLength(hWnd);
        if(length == 0)
        {
            return null;
        }

        var sb = new StringBuilder(length + 1);
        var ret = IsWindowUnicode(hWnd)
            ? GetWindowTextW(hWnd, sb, length + 1)
            : GetWindowTextA(hWnd, sb, length + 1);

        // TODO ret の値で判定

        return sb.ToString();
    }
}
