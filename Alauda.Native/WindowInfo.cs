namespace Alauda.Native;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary></summary>
public class WindowInfo
{
    /// <summary></summary>
    public IntPtr Handle => _handle;

    /// <summary></summary>
    public string? Text => _text;

    /// <summary></summary>
    public int ProcessId => _processId;

    /// <summary></summary>
    public int ThreadId => _threadId;

    /// <summary></summary>
    public bool IsVisible => User32.IsWindowVisible(_handle);


    private readonly IntPtr _handle;
    private readonly string? _text;
    private readonly int _processId;
    private readonly int _threadId;


    /// <summary></summary>
    private WindowInfo(
            IntPtr  handle,
            string? text,
            int     processId,
            int     threadId)
    {
        _handle    = handle;
        _text      = text;
        _processId = processId;
        _threadId  = threadId;
    }



    private static List<WindowInfo>? _windowInfos = null;

    /// <summary></summary>
    public static WindowInfo[] Get()
    {
        if(_windowInfos != null)
            throw new Exception();

        _windowInfos = new ();

        User32.EnumWindows(OnEnumWindowsProc, IntPtr.Zero);

        var ret = _windowInfos.ToArray();
        _windowInfos.Clear();
        _windowInfos = null;

        return ret;
    }

    /// <summary></summary>
    private static bool OnEnumWindowsProc(IntPtr hWnd, IntPtr lParam)
    {
        if(_windowInfos == null)
            return false;

        int processId;
        int threadId = User32.GetWindowThreadProcessId(hWnd, out processId);

        var wi = new WindowInfo(
                hWnd,
                User32.GetWindowText(hWnd),
                processId,
                threadId);

        lock(_windowInfos)
        {
            _windowInfos.Add(wi);
        }

        return true;
    }
}
